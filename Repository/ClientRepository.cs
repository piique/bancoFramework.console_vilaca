using System.Data.SqlClient;
using Dapper;
using Domain.Model;

namespace Repository
{
    public class ClientRepository
    {
        public static async Task<bool> AddCliente(Cliente cliente)
        {
            await using var connection = new SqlConnection(DatabaseConfig.DatabaseConfig.DefaultConnectionString);
            await connection.OpenAsync();

            const string insertQuery = @"INSERT INTO Clientes (Id, Nome, Cpf, Saldo) 
                                       VALUES (@Id, @Nome, @Cpf, @Saldo)";

            var result = await connection.ExecuteAsync(insertQuery, cliente);
            
            return result == 1;
        }
        
        public static async Task<Cliente?> GetCliente(int id)
        {
            await using var connection = new SqlConnection(DatabaseConfig.DatabaseConfig.DefaultConnectionString);
            await connection.OpenAsync();

            const string selectQuery = @"SELECT * FROM Clientes WHERE Id = @Id";

            var result = await connection.QueryFirstOrDefaultAsync<Cliente>(selectQuery, new {Id = id});
            
            return result;
        }
    }
}