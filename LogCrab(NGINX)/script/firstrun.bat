@echo off
echo Installing required gems and Bundler...

rem Create a temporary Gemfile if not already present
if not exist Gemfile (
    echo source 'https://rubygems.org' > Gemfile
    echo gem 'http' >> Gemfile
    echo gem 'inifile' >> Gemfile
    echo gem 'nyaplot' >> Gemfile
)

rem Install gems using Bundler
bundle install

echo Gem installation complete.
pause