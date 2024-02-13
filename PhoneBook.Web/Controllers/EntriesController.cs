using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;
using PhoneBook.Web.Services;

namespace PhoneBook.Web.Controllers
{
    public class EntriesController : Controller
    {
        // GET: Entries by Search
        public async Task<IActionResult> Index(int id, string searchString)
        {
            Model.PhoneBook parentPhoneBook = await PhoneBookRequestService.GetPhoneBookAsync(id);

            if (parentPhoneBook != null)
            {
                ViewBag.PhoneBookId = parentPhoneBook.Id;
                ViewBag.PhoneBookName = parentPhoneBook.Name;
            }

            return View(await EntriesRequestService.SearchEntriesAsync(id, searchString));
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await EntriesRequestService.GetEntryAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create(int Id)
        {
            Entry entry = new Entry();
            entry.PhoneBookId = Id;
            return View(entry);
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PhoneNumber,PhoneBookId")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                await EntriesRequestService.PostEntryAsync(entry);
                return RedirectToAction("Index", new { id = entry.PhoneBookId });
            }
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await EntriesRequestService.GetEntryAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,PhoneBookId")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await EntriesRequestService.PutEntryAsync(entry);
                return RedirectToAction("Index", new { id = entry.PhoneBookId });
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await EntriesRequestService.GetEntryAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await EntriesRequestService.GetEntryAsync(id);
            await EntriesRequestService.DeleteEntryAsync(id);
            return RedirectToAction("Index", new { id = entry.PhoneBookId });
        }

    }
}
