using ElSaiys.Helper;
using ElSaiys.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElSaiys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRrpo;
        private readonly IError _error;

        public UsersController(IUserRepository userRrpo, IError error)
        {
            _userRrpo = userRrpo;
            _error = error;
        }

        [HttpGet("slug")]
        [Authorize]
        public async Task<IActionResult> WhoseCart(string slug)
        {
            var userResault = await _userRrpo.CarOwner(slug);

            if (userResault.Success)
                return Ok(userResault);

            _error.LoadError(userResault.ErrorCode);
            ModelState.AddModelError(_error.ErrorProp, _error.ErrorMessage);
            return ValidationProblem();
        }
    }
}
