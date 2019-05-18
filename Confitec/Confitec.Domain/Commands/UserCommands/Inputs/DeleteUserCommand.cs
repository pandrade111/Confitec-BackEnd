using Confitec.Shared.Commands;
using Flunt.Notifications;

namespace Confitec.Domain.Commands.UserCommands.Inputs
{
    public class DeleteUserCommand : Notifiable, ICommand
    {
        public long Id { get; set; }

        bool ICommand.Valid()
        {
            return Valid;
        }
    }
}
