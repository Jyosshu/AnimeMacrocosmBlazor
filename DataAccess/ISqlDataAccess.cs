using ClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<Post>> GetAllPosts();
        Task<IList<Series>> GetAllSeries();
    }
}