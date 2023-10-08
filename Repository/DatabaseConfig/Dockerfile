# Usar a imagem oficial do SQL Server
FROM mcr.microsoft.com/mssql/server:2022-latest

# Copiar os scripts para o diretório de trabalho no contêiner
COPY init.sql .
COPY entrypoint.sh .

# Aceitar a EULA e definir a senha SA
ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=DataBase!PassWord222

# Tornar o entrypoint.sh executável e definir como comando de entrada
CMD /entrypoint.sh
