using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeListAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;

        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return await dbConnection.QueryAsync<Employee>("SELECT * FROM Employees");
        }
    }
}
