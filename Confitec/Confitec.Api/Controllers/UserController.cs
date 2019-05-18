using Confitec.Domain.Commands;
using Confitec.Domain.Commands.UserCommands.Inputs;
using Confitec.Domain.Handlers;
using Confitec.Domain.Queries;
using Confitec.Domain.Repositories;
using Confitec.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Confitec.Api.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserRepository _userRepository;
        public readonly UserHandler _userHandler;

        public UserController(IUserRepository userRepository,
            UserHandler userHandler)
        {
            _userRepository = userRepository;
            _userHandler = userHandler;
        }

        [HttpGet]
        [Route("v1/users/{id}")]
        public GetUserCommandResult GetById(long id)
        {
            return _userRepository.Get(id);
        }

        [HttpPost]
        [Route("v1/users")]
        public ICommandResult Post([FromBody]CreateUserCommand command)
        {
            var result = (CommandResult)_userHandler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/users")]
        public ICommandResult Put([FromBody]ChangeUserCommand command)
        {
            var result = (CommandResult)_userHandler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/users")]
        public ICommandResult Delete([FromBody]DeleteUserCommand command)
        {
            var result = (CommandResult)_userHandler.Handle(command);
            return result;
        }
    }
}
