using Infrastructure.Data;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Web.Controllers
{
	public class QuyTrinhController:Controller
	{
		private readonly DataConText _context;
		public QuyTrinhController(DataConText context)
		{
			_context = context;
		}
		public async Task<IActionResult>Index() 
		{ 
			return View(await _context.tbQuyTrinh.Include(m=>m.ThuTuc).ToListAsync());
		}
		public async Task<IActionResult> Details(int id)
		{
			if (id == null) return NotFound();
			var quyTrinh= await _context.tbQuyTrinh.Include(mbox=>mbox.ThuTuc).FirstOrDefaultAsync(m=>m.Id==id);
			if(quyTrinh == null) return NotFound();
			return View(quyTrinh);
		}
		public IActionResult Create() 
		{
			ViewData["ThuTucId"] = new SelectList(_context.tbThuTuc, "Id", "Id");
			return View();

		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id, MaQuyTrinh,TenQuyTrinh,MoTa,ThuTucId")] QuyTrinh quyTrinh) 
		{
			if (ModelState.IsValid)
			{
				_context.Add(quyTrinh);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			else
			{
				ModelState.AddModelError("Custom Error", "Không hợp lệ");
			}
			ViewData["ThuTucId"]= new SelectList(_context.tbQuyTrinh, "Id", "Id", quyTrinh.ThuTucId);
			return View();
		}
		public async Task<IActionResult> Edit (int id)
		{
			if(id == null) return NotFound();
			var quyTrinh = await _context.tbQuyTrinh.FindAsync(id);
			if (quyTrinh == null) return NotFound();
			ViewData["ThuTucId"] = new SelectList(_context.tbLinhVuc, "Id", "Id", quyTrinh.ThuTucId);
			return View(quyTrinh);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,MaQuyTrinh,TenQuyTrinh,MoTa,ThuTucId")] QuyTrinh quyTrinh)
		{
			if (quyTrinh.Id != id) return NotFound();
			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(quyTrinh);
					await _context.SaveChangesAsync();
				} catch (DbUpdateConcurrencyException) {
					if (QuyTrinhExists(id))
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
			ViewData["ThuTucId"] = new SelectList(_context.tbQuyTrinh, "Id", "Id", quyTrinh.Id);
			return View();

		}
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null) return NotFound();
			var quytrinh = await _context.tbQuyTrinh
				.Include(n => n.ThuTuc).FirstOrDefaultAsync(m=>m.Id==id);
			if(quytrinh == null) return NotFound();
			return View(quytrinh);
		}
		[HttpPost,ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id )
		{
			var quyTrinh = await _context.tbQuyTrinh.FindAsync(id);
			if (quyTrinh != null)
			{
				_context.tbQuyTrinh.Remove(quyTrinh);
			}
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public bool QuyTrinhExists(int quyTrinhId)
		{
			return _context.tbQuyTrinh.Any(m => m.Id == quyTrinhId);
		}
	}
}
