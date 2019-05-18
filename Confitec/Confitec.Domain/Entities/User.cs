using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Confitec.Domain.Entities
{
    public class User : Notifiable
    {
        public User(long profileId,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate)
        {
            ProfileId = profileId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(FirstName, "FirstName", "Nome não pode ser nulo ou vazio.")
               .HasMinLen(FirstName, 3, "FirstName", "Nome deve conter pelo menos 3 caracteres")
               .HasMaxLen(FirstName, 45, "FirstName", "Nome deve conter no máximo 60 caracteres")
               .IsNotNullOrEmpty(LastName, "LastName", "Sobrenome não pode ser nulo ou vazio.")
               .HasMinLen(LastName, 3, "LastName", "Sobrenome deve conter pelo menos 3 caracteres")
               .HasMaxLen(LastName, 45, "LastName", "Sobrenome deve conter no máximo 60 caracteres")
               .IsEmailOrEmpty(Email, "Email", "E-mail inválido")
               .IsLowerOrEqualsThan(BirthDate,DateTime.Today,"BirthDate", "A data de nascimento não pode ser maior que hoje.")
            );
        }

        public long Id { get; private set; }
        public long ProfileId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
