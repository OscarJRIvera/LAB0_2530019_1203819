using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB0_2530019_1203819.Data;
using LAB0_2530019_1203819.Models;

namespace LAB0_2530019_1203819.Controllers
{
    public class ClientModelsController : Controller
    {
        private readonly LAB0_2530019_1203819Context _context;
        private readonly Models.Data.Singleton C; 

        public ClientModelsController(LAB0_2530019_1203819Context context)
        {
            // _context = context;
            C = Models.Data.Singleton.Instance; //BUSCA LA DATA 
        }

        // GET: ClientModels
        public IActionResult Index()
        {
            //return View(await _context.ClientModel.ToListAsync());
            return View(C.ClientList);
        }
        public IActionResult IndexSortName()
        {
            //return View(await _context.ClientModel.ToListAsync());
            return View(C.SortName());
        }
        public IActionResult IndexSortLastName()
        {
            //return View(await _context.ClientModel.ToListAsync());
            return View(C.SortLastName());
        }

        // GET: ClientModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // GET: ClientModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,LastName,phone,Description")] ClientModel clientModel)
        {
            try
            {

                clientModel.Id = C.ClientList.Count + 1;
                C.ClientList.Add(clientModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: ClientModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }
            return View(clientModel);
        }

        // POST: ClientModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,phone,Description")] ClientModel clientModel)
        {
            if (id != clientModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.Id))
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
            return View(clientModel);
        }

        // GET: ClientModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // POST: ClientModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientModel = await _context.ClientModel.FindAsync(id);
            _context.ClientModel.Remove(clientModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return _context.ClientModel.Any(e => e.Id == id);
        }
    }
}
