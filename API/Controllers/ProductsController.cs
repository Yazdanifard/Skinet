using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;

namespace API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var Products = await _context.Prodcuts.ToListAsync();
            return Products;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _context.Prodcuts.FindAsync(id);

        }
    }
}