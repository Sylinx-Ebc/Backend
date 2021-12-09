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
    public class ProductController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public ProductController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productList = _dataAccessProvider.GetProducts().ToList();

            return Ok(productList);
            
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddProductRecord(product);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            var product = _dataAccessProvider.GetSingleProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpPut]
        public IActionResult EditProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateProduct(product);
                return Ok();
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var data = _dataAccessProvider.GetSingleProduct(id);
            if(data == null)
            {
                return NotFound();
            }

            _dataAccessProvider.DeleteProduct(id);
            return Ok();
        }



    }
}
