using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using super_duper_octo_fortnight.Server.Models;

namespace super_duper_octo_fortnight.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingDetailsController : ControllerBase
    {
        private readonly ShoppingDBContext _context;

        public ShoppingDetailsController(ShoppingDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingDetails>>> GetShoppingDetails()
        {
            return await _context.ShoppingDetails.ToListAsync();
        }

        // GET: api/ShoppingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingDetails>> GetShoppingDetails(int id)
        {
            var shoppingDetails = await _context.ShoppingDetails.FindAsync(id);

            if (shoppingDetails == null)
            {
                return NotFound();
            }

            return shoppingDetails;
        }

        // PUT: api/ShoppingDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingDetails(int id, ShoppingDetails shoppingDetails)
        {
            if (id != shoppingDetails.ShopId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingDetailsExists(id))
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

        // POST: api/ShoppingDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingDetails>> PostShoppingDetails(ShoppingDetails shoppingDetails)
        {
            _context.ShoppingDetails.Add(shoppingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingDetails", new { id = shoppingDetails.ShopId }, shoppingDetails);
        }

        // DELETE: api/ShoppingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingDetails>> DeleteShoppingDetails(int id)
        {
            var shoppingDetails = await _context.ShoppingDetails.FindAsync(id);
            if (shoppingDetails == null)
            {
                return NotFound();
            }

            _context.ShoppingDetails.Remove(shoppingDetails);
            await _context.SaveChangesAsync();

            return shoppingDetails;
        }

        private bool ShoppingDetailsExists(int id)
        {
            return _context.ShoppingDetails.Any(e => e.ShopId == id);
        }
    }
}
