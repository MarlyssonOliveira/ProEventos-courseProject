using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet("GetUser/{userName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(string userName)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um erro ao tentar recuperar o usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            try
            {
                if (await _accountService.UserExists(userDto.UserName))
                {
                    return BadRequest("Usuario já existe");
                }

                var user = await _accountService.CreateAccountAsync(userDto);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("Usuario não criado, tente novamente");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um erro ao tentar recuperar o usuario. Erro: {ex.Message}");
            }
        }
    }
}
