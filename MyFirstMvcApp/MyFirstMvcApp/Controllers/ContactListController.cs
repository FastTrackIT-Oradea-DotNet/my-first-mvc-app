using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Models;
using MyFirstMvcApp.Services;

namespace MyFirstMvcApp.Controllers
{
    public class ContactListController : Controller
    {
        private readonly IContactListService _service;

        public ContactListController(IContactListService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: ContactList
        public async Task<IActionResult> Index()
        {
            var entries = await _service.GetEntriesAsync();

            return View(entries);
        }

        // GET: ContactList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _service.GetByIdAsync(id.Value);

            if (contactListEntry == null)
            {
                return NotFound();
            }

            return View(contactListEntry);
        }

        // GET: ContactList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactType,Name,DateOfBirth,PhoneNumber,Email")] ContactListEntry contactListEntry)
        {
            if (ModelState.IsValid)
            {
                var success = await _service.CreateEntryAsync(contactListEntry);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong while creating contact list entry, please try again ...";
                }
            }

            return View(contactListEntry);
        }

        // GET: ContactList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _service.GetByIdAsync(id.Value);

            if (contactListEntry == null)
            {
                return NotFound();
            }

            return View(contactListEntry);
        }

        // POST: ContactList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactType,Name,DateOfBirth,PhoneNumber,Email")] ContactListEntry contactListEntry)
        {
            if (id != contactListEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _service.UpdateEntryAsync(contactListEntry);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Something went wrong while updating contact list entry, please try again ...";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    var entry = await _service.GetByIdAsync(contactListEntry.Id);

                    if (entry is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(contactListEntry);
        }

        // GET: ContactList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _service.GetByIdAsync(id.Value);

            if (entry is null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: ContactList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _service.DeleteEntryAsync(id);
            if (!success)
            {
                return RedirectToAction(nameof(Delete), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
