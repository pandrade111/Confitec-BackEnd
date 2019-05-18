using Confitec.Domain.Commands;
using Confitec.Domain.Commands.UserCommands.Inputs;
using Confitec.Domain.Entities;
using Confitec.Domain.Repositories;
using Confitec.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Confitec.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<ChangeUserCommand>,
        ICommandHandler<DeleteUserCommand>
    {
        public readonly IUserRepository _userRepository;
        public readonly IProfileRepository _profileRepository;

        public UserHandler(IUserRepository userRepository,
            IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            if (!_profileRepository.CheckProfile(command.ProfileId))
            {
                AddNotification("ProfileId", "Perfil não existe.");
            }

            User user = new User(command.ProfileId, command.FirstName, command.LastName, command.Email, command.BirthDate);

            AddNotifications(user.Notifications);

            if (Invalid)
            {
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);
            }

            _userRepository.Save(user);

            return new CommandResult(true, "Usuário criado com sucesso.", new
            {
                Nome = user.ToString()
            });
        }

        public ICommandResult Handle(ChangeUserCommand command)
        {
            if (!_userRepository.CheckUser(command.Id))
            {
                AddNotification("user", "Usuário não existe.");
            }

            User user = new User(command.ProfileId, command.FirstName, command.LastName, command.Email, command.BirthDate);

            AddNotifications(user.Notifications);

            if (Invalid)
            {
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);
            }

            _userRepository.Update(user, command.Id);

            return new CommandResult(true, "Usuário alterado com sucesso.", new
            {
                Nome = user.ToString()
            });
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            if (!_userRepository.CheckUser(command.Id))
            {
                AddNotification("user", "Usuário não existe.");
            }

            if (Invalid)
            {
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);
            }

            Queries.GetUserCommandResult user = _userRepository.Get(command.Id);

            _userRepository.Delete(command.Id);

            return new CommandResult(true, "Usuário excluido com sucesso.", new
            {
                Nome = $"{user.FirstName} {user.LastName}"
            });
        }
    }
}
