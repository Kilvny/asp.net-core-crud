using ASP.NET_CORE_Course.Data;
using ASP.NET_CORE_Course.Helpers;
using ASP.NET_CORE_Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_Course.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly DatabaseContext _db;
        public ItemsController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var items = await _db.Items.ToListAsync();
            return Ok(items);
        }
        [HttpGet]
        [Route("get-item-by-id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _db.Items.FindAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ItemModel item)
        {
            if (item.IsNull())
            {
                return BadRequest();
            }
            await _db.Items.AddAsync(item); // adds the item to the db context of EF 
            await _db.SaveChangesAsync();
            return Created($"./get-item-by-id?id={item.Id}", item);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var itemToBeDeleted = await _db.Items.FindAsync(id);
            if (itemToBeDeleted == null)
            {
                return NotFound();
            }
            _db.Items.Remove(itemToBeDeleted);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
