using Confitec.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Confitec.Domain.Commands.UserCommands.Inputs
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public long ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        bool ICommand.Valid()
        {
            return Valid;
        }
    }
}
