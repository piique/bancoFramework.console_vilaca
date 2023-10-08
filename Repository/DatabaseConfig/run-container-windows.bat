:: Construir a imagem
docker build -t custom_sql_server_image .

:: Rodar o contêiner
docker run -it -p 1433:1433 -v sql_server_data:/var/opt/mssql --name my_sql_server_instance custom_sql_server_image
