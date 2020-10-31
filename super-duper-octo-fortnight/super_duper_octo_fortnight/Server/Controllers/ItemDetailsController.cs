using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using super_duper_octo_fortnight.Shared.Models;

namespace super_duper_octo_fortnight.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private readonly ShoppingDBContext _context;

        public ItemDetailsController(ShoppingDBContext context)
        {
            _context = context;
        }

        // GET: api/ItemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDetails>>> GetItemDetails()
        {
            return await _context.ItemDetails.ToListAsync();
        }

        // GET: api/ItemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDetails>> GetItemDetails(int id)
        {
            var itemDetails = await _context.ItemDetails.FindAsync(id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return itemDetails;
        }

        // PUT: api/ItemDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetails(int id, ItemDetails itemDetails)
        {
            if (id != itemDetails.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemDetails>> PostItemDetails(ItemDetails itemDetails)
        {
            _context.ItemDetails.Add(itemDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemDetails", new { id = itemDetails.ItemId }, itemDetails);
        }

        // DELETE: api/ItemDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDetails>> DeleteItemDetails(int id)
        {
            var itemDetails = await _context.ItemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();

            return itemDetails;
        }

        private bool ItemDetailsExists(int id)
        {
            return _context.ItemDetails.Any(e => e.ItemId == id);
        }
    }
}
