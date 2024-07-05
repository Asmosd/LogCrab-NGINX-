# LogCrab

## Overview
LogCrab is a Windows Forms application that sets up the running of a ruby script which analyses NGINX logs every day and provides some helpful info

## Features
- Sets up the daily running of the ruby script using Task Scheduler
- Creates a .log about the NGINX logs
- Creates a .csv about the NGINX logs
- Allows implementation with AbuseIP api to show IP scan results (needs AbuseIP api key)
- Creates a .html graph which shows accesses per hour

## Requirements
- Windows 8 or later
- Ruby Devkit installed
- Bundler (it comes with Ruby Devkit, so it should be preinstalled)

## Installation
1. Download the latest release.
2. Extract the downloaded zip file to your desired location.
3. Run the `LogCrab(NGINX).exe` file.
4. Click on the "First Run?" tab. It will install the required dependencies.

## Usage
1. Open the application.
2. Select the logging operations you wish.
3. Choose an hour for the script to be run.
4. Select NGINX log files (usually access.txt).
5. Press "Accept".
6. Your logs will now be printed to the logs folder daily.
7. If you ever wish to change anything, just run the application again.

## Notes
The script has some weird kinks due to the interaction between the "ini-parser" C# nuget and the "inifile" gem, due to the former creating the .ini with utf-8 + BOM, which is not supported by the latter. It works fine, anyways.