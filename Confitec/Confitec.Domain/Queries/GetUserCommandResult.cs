using System;

namespace Confitec.Domain.Queries
{
    public class GetUserCommandResult
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
