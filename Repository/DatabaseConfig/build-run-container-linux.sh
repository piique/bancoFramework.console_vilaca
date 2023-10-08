#!/bin/bash

# Construir a imagem
docker build -t custom_sql_server_image .

# Rodar o contêiner em background
printf "Rodando o contêiner em background na porta 1433 \n"
#docker run -d -p 1433:1433 -v sql_server_data:/var/opt/mssql --name my_sql_server_instance custom_sql_server_image

# Rodar o contêiner em foreground
# printf "Rodando o contêiner em foreground na porta 1433 \n"
 docker run -it -p 1433:1433 -v sql_server_data:/var/opt/mssql --name my_sql_server_instance custom_sql_server_image
