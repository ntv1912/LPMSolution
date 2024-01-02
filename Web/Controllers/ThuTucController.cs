using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models;

namespace MVC.Controllers
{
    public class ThuTucController : Controller
    {
        private readonly DataConText _context;

        public ThuTucController(DataConText context)
        {
            _context = context;
        }

        // GET: ThuTucs
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.tbThuTuc.Include(t => t.LinhVuc);
            return View(await mVCContext.ToListAsync());
        }

        // GET: ThuTucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuTuc = await _context.tbThuTuc
                .Include(t => t.LinhVuc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thuTuc == null)
            {
                return NotFound();
            }

            return View(thuTuc);
        }

        // GET: ThuTucs/Create
        public IActionResult Create()
        {
            ViewData["LinhVucId"] = new SelectList(_context.tbLinhVuc, "Id", "Id");
            return View();
        }

        // POST: ThuTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaThuTuc,TenThuTuc,MoTa,LinhVucId")] ThuTuc thuTuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("CustomError", "Thông tin không hợp lệ");
            }
            ViewData["LinhVucId"] = new SelectList(_context.tbLinhVuc, "Id", "Id", thuTuc.LinhVucId);
            return View(thuTuc);
        }

        // GET: ThuTucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuTuc = await _context.tbThuTuc.FindAsync(id);
            if (thuTuc == null)
            {
                return NotFound();
            }
            ViewData["LinhVucId"] = new SelectList(_context.tbLinhVuc, "Id", "Id", thuTuc.LinhVucId);
            return View(thuTuc);
        }

        // POST: ThuTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaThuTuc,TenThuTuc,MoTa,LinhVucId")] ThuTuc thuTuc)
        {
            if (id != thuTuc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuTucExists(thuTuc.Id))
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
            ViewData["LinhVucId"] = new SelectList(_context.tbLinhVuc, "Id", "Id", thuTuc.LinhVucId);
            return View(thuTuc);
        }

        // GET: ThuTucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuTuc = await _context.tbThuTuc
                .Include(t => t.LinhVuc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thuTuc == null)
            {
                return NotFound();
            }

            return View(thuTuc);
        }

        // POST: ThuTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuTuc = await _context.tbThuTuc.FindAsync(id);
            if (thuTuc != null)
            {
                _context.tbThuTuc.Remove(thuTuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuTucExists(int id)
        {
            return _context.tbThuTuc.Any(e => e.Id == id);
        }
    }
}
