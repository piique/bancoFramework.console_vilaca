#!/bin/bash

# Function to execute the init script after a delay
function run_init_script {
    # Wait for SQL Server to start
    sleep 30

    # Execute the initialization script
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "DataBase!PassWord222" -i init.sql
}

# Start the init script in the background
run_init_script &

# Start SQL Server in the foreground
/opt/mssql/bin/sqlservr
