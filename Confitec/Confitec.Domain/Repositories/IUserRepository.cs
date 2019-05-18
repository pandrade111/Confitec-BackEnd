using Confitec.Domain.Entities;
using Confitec.Domain.Queries;

namespace Confitec.Domain.Repositories
{
    public interface IUserRepository
    {
        GetUserCommandResult Get(long id);
        bool CheckUser(long id);
        void Save(User user);
        void Update(User user, long id);
        void Delete(long id);
    }
}
