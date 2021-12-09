using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AccountController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accountList = _dataAccessProvider.GetAccounts().ToList();

            return Ok(accountList);

        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddUserRecord(account);
                return Ok(account);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleAccount(int id)
        {
            var account = _dataAccessProvider.GetSingleAccount(id);

            if(account == null)
            {
                return NotFound();
            }

            return Ok(account);

        }

        [HttpPut]
        public IActionResult EditAccount([FromBody] Account account)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateUser(account);
                return Ok();
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var data = _dataAccessProvider.GetSingleAccount(id);
            if (data == null)
            {
                return NotFound();
            }

            _dataAccessProvider.DeleteUser(id);
            return Ok();
        }



    }
}
