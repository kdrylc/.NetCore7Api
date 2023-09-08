using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Bussiness.Abstract;
using NetCoreWebApi.Models.Concrete;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prod;

        public ProductController(IProductRepository prod)
        {
            _prod = prod;
        }

        [HttpGet("GettAllProducts")]
        public async Task<IActionResult> GettAll()
        {
            var prod = await _prod.GetAll();
            return Ok(prod);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prod = await _prod.GetById(id);
            return Ok(prod);
        }

        
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            var prod = await _prod.Create(productDTO);
            return Ok(prod);    
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update (ProductDTO productDTO)
        {
            var prod = await _prod.Update(productDTO);
            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var prod = await _prod.DeleteById(id);
            return Ok(prod);
        }

        [HttpGet("GetProductFromCategoryID/{id}")]
        public async Task<IActionResult> GetProductFromCategoryID(int id)
        {
            var result = await _prod.GetProductByCategoryId(id);
            return Ok(result);
        }

    }
}
