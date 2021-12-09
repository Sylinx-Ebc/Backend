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
    public class PurchaseController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public PurchaseController(IDataAccessProvider dataAccessProvider)
        {

            _dataAccessProvider = dataAccessProvider;

        }

        [HttpPost]
        public async Task<IActionResult> AddPurchases([FromBody] Purchase purchase)
        {
 
              _dataAccessProvider.AddUserPurchase(purchase);

               return Ok();

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllPurchases(int id)
        {
            var purchases = _dataAccessProvider.GetPurchases(id);

            if (purchases == null)
            {
                return NotFound();
            }

            return Ok(purchases);

        }
    }
}
