using Confitec.Domain.Entities;
using Confitec.Domain.Queries;
using Confitec.Domain.Repositories;
using Confitec.Infra.DataContetx;
using Dapper;
using System.Linq;

namespace Confitec.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public GetUserCommandResult Get(long id)
        {
            return
                _context
                .Connection
                .QueryFirstOrDefault<GetUserCommandResult>(
                    @"SELECT [Id], [ProfileId], [FirstName], [LastName], [Email], [BirthDate]
                        FROM [User]
                       WHERE ID = @id",
                    new { id });
        }

        public bool CheckUser(long id)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "SELECT [Id] FROM [User] WHERE ID = @id",
                    new { id })
                .FirstOrDefault();
        }

        public void Save(User user)
        {
            _context
               .Connection
               .Execute(
                   @"INSERT INTO [User] ([ProfileId], [FirstName], [LastName], [Email], [BirthDate]) 
                                  Values(@profileid, @firstname, @lastname, @email, @birthdate)",
                   new { user.ProfileId, user.FirstName, user.LastName, user.Email, user.BirthDate });
        }

        public void Update(User user, long id)
        {
            _context
               .Connection
               .Execute(
                   @"UPDATE [User]
                        SET  [ProfileId] = @profileid,
                             [FirstName] = @firstname,
                             [LastName] = @lastname,
                             [Email] = @email,
                             [BirthDate] = @birthdate
                      WHERE ID = @id",
                   new { id, user.ProfileId, user.FirstName, user.LastName, user.Email, user.BirthDate });
        }

        public void Delete(long id)
        {
            _context
               .Connection
               .Execute(
                   @"DELETE FROM [User]
                      WHERE ID = @id",
                   new { id });
        }
    }
}
