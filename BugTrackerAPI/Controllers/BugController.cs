﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTrackerAPI.Database;
using BugTrackerAPI.Models;

namespace BugTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly BugContext _context;

        public BugController(BugContext context)
        {
            _context = context;
        }

        // GET: api/Bug
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetBugs()
        {
            return await _context.Bugs.ToListAsync();
        }

        // GET: api/Bug/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetBug(long id)
        {
            var bug = await _context.Bugs.FindAsync(id);

            if (bug == null)
            {
                return NotFound();
            }

            return bug;
        }

        // PUT: api/Bug/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBug(long id, Bug bug)
        {
            if (id != bug.Id)
            {
                return BadRequest();
            }

            _context.Entry(bug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugExists(id))
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

        // POST: api/Bug
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bug>> PostBug(Bug bug)
        {
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBug), new { id = bug.Id }, bug);
        }

        // DELETE: api/Bug/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(long id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }

            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BugExists(long id)
        {
            return _context.Bugs.Any(e => e.Id == id);
        }
    }
}
