using AspNetCore.Identity.Localization.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIdentity.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public IdentityController(UserManager<IdentityUser> userManager, IStringLocalizer<SharedResource> localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
        }

        // GET: api/<IdentityController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _localizer.GetAllStrings().Select(l => $"key:{l.Name},value:{string.Format(l.Value, "test")}");
            return Ok(result);
        }

        // POST api/<IdentityController>
        //
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddUserDto userDto)
        {
            var result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
            }, userDto.Password);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors);
        }
    }

    public class AddUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}