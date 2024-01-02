using Infrastructure.Data;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class LinhVucController:Controller
    {
        private readonly DataConText _context;
        public LinhVucController(DataConText context)
        {
            _context = context;
        }
         public async Task<IActionResult> Index()
        {
            return View(await _context.tbLinhVuc.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
			var linhVuc = await _context.tbLinhVuc
				.FirstOrDefaultAsync(m => m.Id == id);
			if (linhVuc==null) return NotFound();
            return View(linhVuc);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLinhVuc,TenLinhVuc,MoTa")] LinhVuc linhVuc)
        {
            if(ModelState.IsValid)
            {
                _context.Add(linhVuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }return View(linhVuc);
        }
        public async Task<IActionResult> Edit(int? id) {
            if(id==null) return NotFound();
            var linhVuc =await _context.tbLinhVuc.FindAsync(id);
            if(linhVuc==null) return NotFound();
            return View(linhVuc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLinhVuc,TenLinhVuc,MoTa")] LinhVuc linhVuc)
        {
            if (id !=linhVuc.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhVuc);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!LinhVucExists(linhVuc.Id))
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
            return View(linhVuc);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null) return NotFound();
            var linhVuc = await _context.tbLinhVuc.FirstOrDefaultAsync(m=>m.Id==id);
            if (linhVuc == null) return NotFound();
            return View(linhVuc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var linhVuc= await _context.tbLinhVuc.FindAsync(id);
            if(linhVuc!=null) _context.tbLinhVuc.Remove(linhVuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



        private bool LinhVucExists(int id)
        {
            return _context.tbLinhVuc.Any(x => x.Id == id);
        }
    }
}
