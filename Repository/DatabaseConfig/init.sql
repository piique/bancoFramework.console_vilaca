USE master;

IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = N'BancoFramework'
)
BEGIN
    CREATE DATABASE BancoFramework;
END

GO

USE BancoFramework;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='Clientes' AND type='U')
BEGIN
CREATE TABLE Clientes
(
    Id INT PRIMARY KEY,
    Nome VARCHAR(255),
    Cpf VARCHAR(14),
    Saldo FLOAT
);
END

GO
