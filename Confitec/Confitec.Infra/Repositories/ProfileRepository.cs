using Confitec.Domain.Queries;
using Confitec.Domain.Repositories;
using Confitec.Infra.DataContetx;
using Dapper;
using System.Linq;

namespace Confitec.Infra.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _context;
        public ProfileRepository(DataContext context)
        {
            _context = context;
        }

        public bool CheckProfile(long id)
        {
            return
               _context
               .Connection
               .Query<bool>(
                   "SELECT [Id] FROM [Profile] WHERE ID = @id",
                   new { id })
               .FirstOrDefault();
        }
    }
}
