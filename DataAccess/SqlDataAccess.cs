using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ClassLibrary
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SqlDataAccess> _log;
        public string ConnectionStringName { get; set; } = "AnimeMacrocom_Docker";

        public SqlDataAccess(IConfiguration config, ILogger<SqlDataAccess> log)
        {
            _config = config;
            _log = log;
        }


    }
}
