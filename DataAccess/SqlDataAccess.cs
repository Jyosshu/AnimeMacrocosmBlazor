using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ClassLibrary.Models;
using Dapper;
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

        public List<Post> GetAllPosts(string sqlQuery)
        {
            List<Post> output;

            using (IDbConnection connection = new SqlConnection(ConnectionStringName))
            {
                output = connection.Query<Post, User, Post>(sqlQuery,
                    map: (post, user) =>
                    {
                        post.User = user;
                        return post;
                    }, splitOn: "UserId"
                    ).ToList();
            }

            return output;
        }
    }
}
