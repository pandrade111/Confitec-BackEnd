using System;

namespace Confitec.Domain.Queries
{
    public class GetProfileCommandResult
    {
        public long Id { get; set; }
        public string Profile { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
