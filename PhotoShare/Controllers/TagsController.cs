﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class TagsController : Controller
    {
        private readonly PhotoShareContext _context;

        public TagsController(PhotoShareContext context)
        {
            _context = context;
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            var photoShareContext = _context.Tag.Include(t => t.Photo);
            return View(await photoShareContext.ToListAsync());
        }

        // GET: Tags/Details/5
       

        // GET: Tags/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["PhotoId"] = id;

            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,Name,PhotoId")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();

                // re-direct to /Photos/Edit/5
                return RedirectToAction("Edit", "Photos", new { id = tag.PhotoId });
            }
            ViewData["PhotoId"] = new SelectList(_context.Photo, "PhotoId", "PhotoId", tag.PhotoId);
            return View(tag);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            ViewData["PhotoId"] = new SelectList(_context.Photo, "PhotoId", "PhotoId", tag.PhotoId);
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TagId,Name,PhotoId")] Tag tag)
        {
            if (id != tag.TagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.TagId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoId"] = new SelectList(_context.Photo, "PhotoId", "PhotoId", tag.PhotoId);
            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // id is the tag id
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FirstOrDefaultAsync(m => m.TagId == id);

            if (tag == null)
            {
                return NotFound();
            }

            // set the photo id to pass to return to the Photo Details page
            var photoId = tag.PhotoId;

            // Remove the tag
            _context.Tag.Remove(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Photos", new { id = photoId });
        }


        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _context.Tag
                .Include(t => t.Photo)
                .FirstOrDefaultAsync(m => m.TagId == id);

            if (tag != null)
            {
                _context.Tag.Remove(tag);
                await _context.SaveChangesAsync();

                //Re-direct to /photos/edit/5
                return RedirectToAction("Edit", "Photos", new { id = tag.Photo?.PhotoId });
            }

            return View(tag);

            
        }

        private bool TagExists(int id)
        {
            return _context.Tag.Any(e => e.TagId == id);
        }
    }
}