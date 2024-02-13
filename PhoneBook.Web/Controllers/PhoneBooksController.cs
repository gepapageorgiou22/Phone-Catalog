using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Web.Services;

namespace PhoneBook.Web
{
    public class PhoneBooksController : Controller
    {

        // GET: PhoneBooks
        public async Task<IActionResult> Index()
        {
            return View(await PhoneBookRequestService.GetPhoneBooksAsync());
        }

        // GET: PhoneBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await PhoneBookRequestService.GetPhoneBookAsync(id);

            if (phoneBook == null)
            {
                return NotFound();
            }

            return View(phoneBook);
        }

        // GET: PhoneBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Model.PhoneBook phoneBook)
        {
            if (ModelState.IsValid)
            {
                await PhoneBookRequestService.PostPhoneBookAsync(phoneBook);  
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBook);
        }

        // GET: PhoneBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await PhoneBookRequestService.GetPhoneBookAsync(id);
            if (phoneBook == null)
            {
                return NotFound();
            }
            return View(phoneBook);
        }

        // POST: PhoneBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Model.PhoneBook phoneBook)
        {
            if (id != phoneBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                phoneBook = await PhoneBookRequestService.PutPhoneBookAsync(phoneBook);                           
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBook);
        }

        // GET: PhoneBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await PhoneBookRequestService.GetPhoneBookAsync(id);

            if (phoneBook == null)
            {
                return NotFound();
            }

            return View(phoneBook);
        }

        // POST: PhoneBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await PhoneBookRequestService.DeletePhoneBookAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
