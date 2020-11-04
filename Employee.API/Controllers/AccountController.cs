using Employee.API.Helpers;
using Employee.BLL.Interfaces;
using Employee.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("signin")]
        public IActionResult SignIn([FromBody] DonorSignInViewModel model)
        {
            var result = accountService.SignIn(model);

            var token = JWTTokenHandler.GenerateJwtToken(result.Email);

            return Ok(new DonorSignInResponseViewModel
            {
                Email = result.Email,
                Token = token
            });

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register([FromBody] DonorRegisterViewModel model)
        {
            var result = accountService.Register(model);

            if(result)
            {
                return Ok("registered successfully");
            }

            return BadRequest();
           
        }

        [HttpPost]
        [Authorize]
        [Route("test")]
        public IActionResult test()
        {
            return Ok("Something is working");
        }

    }
}
