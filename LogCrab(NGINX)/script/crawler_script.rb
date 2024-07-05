require "date"
require "json"      
require "csv"
require "http"
require "inifile"
require "nyaplot"

ini_contents = File.read("setup.ini", mode: 'r:UTF-8')

if ini_contents.start_with?("\uFEFF")
  ini_contents = ini_contents.sub("\uFEFF", '')
end

temp_ini_path = "temporary.ini"

File.open(temp_ini_path, 'w') do |file|
    file.write(ini_contents)
end  

setup_ini = IniFile.load(temp_ini_path)

File.delete(temp_ini_path) if File.exist?(temp_ini_path)

nginxLog_path = setup_ini["Setup"]["nginxlog_path"]
API_KEY = setup_ini["Optional"]["abuseip_key"]

daily_ip = {}

current_date = Date.today
previous_date = current_date - 1

def day_before?(date_info, previous_date)
    date = Date.strptime(date_info, "%d/%b/%Y")
  
    if date == previous_date
        return true
    end

    return false
end

def check_ip(ip)
    url = "https://api.abuseipdb.com/api/v2/check"
    response = HTTP.headers(
        "Key" => API_KEY,
        "Accept" => "application/json"
    ).get(url, params: {ipAddress: ip})

    if response.status.success?
        json_response = JSON.parse(response.body.to_s)

        data = json_response["data"]

        return data
    else
        return nil
    end
end

def hour_graph(log_path, daily_ip)
    accesses_by_hour = Hash.new(0)

    daily_ip.each do |ip, command_list|
        command_list.each do |entry|
            timestamp = Time.parse(entry[0])

            hour = timestamp.hour

            accesses_by_hour[hour] += 1
        end
    end

    all_hours = (0..23).to_a
    
    accesses_by_hour_filled = Hash[all_hours.map {|hour| [hour, 0]}]

    accesses_by_hour.each do |hour, count|
        accesses_by_hour_filled[hour] = count
    end

    plot = Nyaplot::Plot.new

    plot.height(1000)
    plot.width(1500)

    x_values = all_hours.map { |hour| "#{hour}:00" }
    y_values = accesses_by_hour_filled
    plot.add(:bar, x_values, y_values)
  
    # Set x-axis and y-axis labels
    plot.x_label("Hour")
    plot.y_label("Accesses")

    # Save the plot to an HTML file
    html_file_path = "#{log_path}.html"
    plot.export_html(html_file_path)
end

def print_log(log_path, daily_ip, setup_ini, previous_date)
    File.open(log_path, "w") do |file|
        file.puts("Activity reported during #{previous_date}")

        daily_ip.each do |ip, command_list|
            data = check_ip(ip)

            file.puts("--» #{ip}")

            command_list.each do |entry|
                file.puts("Time:#{entry[0]}; Command:#{entry[1]}; Answer:#{entry[2]}")
            end

            unless setup_ini["Optional"]["abuseip"] == "no"
                data = check_ip(ip)

                unless data == nil
                    file.puts("\nAbuse IP data:")
                    file.puts "IP: #{data["ipAddress"]}"
                    file.puts "Abuse Confidence Score: #{data["abuseConfidenceScore"]}"
                    file.puts "Country: #{data["countryCode"]}"
                    file.puts "Domain: #{data["domain"]}"
                end
            end

            file.puts "-" * 25
        end
    end
end

def print_csv(log_path, daily_ip)
    CSV.open("#{log_path}.csv", "wb") do |csv|
        csv << ["IP", "Time", "Command", "Answer"]
        
        daily_ip.each do |ip, entries|
            entries.each do |entry|
                csv << [ip, entry[0], entry[1], entry[2]]
            end
        end
    end
end

File.open(nginxLog_path, "r") do |file|
    pattern = /^(\S+) - (?:\S+ )?\[(\d{2}\/\w{3}\/\d{4}):(\d{2}:\d{2}):\d{2} [+-]\d{4}\] "([^"]+)" (\S+) \d+/
    pattern_special = /^(\S+) - - \[(\d{2}\/\w{3}\/\d{4}):(\d{2}:\d{2}):\d{2} [+-]\d{4}\] "" (\S+)/    
    pattern_error = /^(\d{4}\/\d{2}\/\d{2}) (\d{2}:\d{2}:\d{2}) \[error\] \d+#\d+: .+ client: (\S+), server: \S+, request: "([^"]+)", upstream: ".+", host: "\S+"/

    file.each_line do |line|
        matches = pattern.match(line)
        matches_special = pattern_special.match(line)
        matches_error = pattern_error.match(line)

        if matches
            ip = matches[1]
            date_info = matches[2]
            time_info = matches[3]
            command = matches[4]
            answer = matches[5]
        elsif matches_special
            ip = matches_special[1]
            date_info = matches_special[2]
            time_info = matches_special[3]
            command = "EMPTY"
            answer = matches_special[4]
        elsif matches_error
            original_date = matches_error[1]
            parsed_date = Date.parse(original_date)
            date_info = parsed_date.strftime("%d/%b/%Y")
            

            time_info = matches_error[2]
            ip = matches_error[3]
            command = matches_error[4]
            answer = "ERROR"
        else
            next
        end

        next unless day_before?(date_info, previous_date)

        if daily_ip.has_key?(ip)
            daily_ip[ip] << [time_info ,command, answer]
        else
            daily_ip[ip] = [[time_info ,command, answer]]
        end
    end
end

log_folder = File.expand_path('../logs', __dir__)
log_path = File.join(log_folder, "#{previous_date.strftime('%d_%b_%Y')}.log")

if setup_ini["Setup"]["log"] == "yes"
    print_log(log_path, daily_ip, setup_ini, previous_date)
end

if setup_ini["Setup"]["log"] == "yes"
    print_csv(log_path, daily_ip)
end

if setup_ini["Optional"]["hour_graph"]
    hour_graph(log_path, daily_ip)
end