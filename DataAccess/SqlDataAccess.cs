using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ClassLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SqlDataAccess> _log;
        public string ConnectionStringName { get; set; } = "AnimeMacrocosm_Docker";

        public SqlDataAccess(IConfiguration config, ILogger<SqlDataAccess> log)
        {
            _config = config;
            _log = log;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            string sqlQuery = @"SELECT p.PostId
, p.PostTitle
, p.PostDate
, p.PostContent
, u.UserId
, u.UserEmailAddress
, u.UserScreenName
FROM Posts p
INNER JOIN Users u ON u.UserId = p.UserId";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var output = await connection.QueryAsync<Post, User, Post>(sqlQuery + " Order By p.PostDate DESC",
                    map: (post, user) =>
                    {
                        post.User = user;
                        return post;
                    }, splitOn: "UserId"
                    );

                return output.ToList();
            }            
        }

        public async Task<IList<Series>>GetAllSeries()
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            string sqlQuery = "SELECT SeriesId, Title FROM Series ORDER BY Title ASC";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var output = await connection.QueryAsync<Series>(sqlQuery);

                return output.ToList();
            }
        }
    }
}
