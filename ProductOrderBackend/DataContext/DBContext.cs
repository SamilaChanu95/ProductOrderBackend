using Npgsql;

namespace ProductOrderBackend.DataContext
{
    public class DBContext
    {
        private readonly IConfiguration _configuration;
        private string? _connection;
        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetSection("ConnectionStrings:PgsqlConnection").Value;
        }
        public NpgsqlConnection CreateDBConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connection);
            return connection;
        }
    }
}
