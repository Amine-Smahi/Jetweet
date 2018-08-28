using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jetweet.Data;
using Jetweet.Models;

namespace Jetweet.Controllers {
  public class TweetController : Controller {
    private readonly ApplicationDbContext _context;

    public TweetController (ApplicationDbContext context) {
      _context = context;
    }

    // GET: Tweet
    public async Task<IActionResult> Index () {
      if (User.Identity.IsAuthenticated) {
        return View (await _context.Tweet.OrderByDescending (d => d.Id).ToListAsync ());
      } else {
        return Redirect ("/Identity/Account/Login");
      }
    }

    // GET: Tweet/Details/5
    public async Task<IActionResult> Details (int? id) {
      if (id == null) {
        return NotFound ();
      }

      var Tweet = await _context.Tweet
        .FirstOrDefaultAsync (m => m.Id == id);
      if (Tweet == null) {
        return NotFound ();
      }

      return View (Tweet);
    }

    // GET: Tweet/Create
    public IActionResult Create () {
      if (User.Identity.IsAuthenticated) {
        return View ();
      } else {
        return RedirectToAction (actionName: "Index");
      }
    }

    // POST: Tweet/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create ([Bind ("Id,Text,ImageUrl")] Tweet Tweet) {
      if (ModelState.IsValid) {
        _context.Add (Tweet);
        await _context.SaveChangesAsync ();
        return RedirectToAction (nameof (Index));
      }

      return View (Tweet);
    }

    // GET: Tweet/Edit/5
    public async Task<IActionResult> Edit (int? id) {
      if (id == null) {
        return NotFound ();
      }

      var Tweet = await _context.Tweet.FindAsync (id);
      if (Tweet == null) {
        return NotFound ();
      }

      return View (Tweet);
    }

    // POST: Tweet/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit (int id, [Bind ("Id,Text,ImageUrl")] Tweet Tweet) {
      if (id != Tweet.Id) {
        return NotFound ();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update (Tweet);
          await _context.SaveChangesAsync ();
        } catch (DbUpdateConcurrencyException) {
          if (!TweetExists (Tweet.Id)) {
            return NotFound ();
          } else {
            throw;
          }
        }

        return RedirectToAction (nameof (Index));
      }

      return View (Tweet);
    }

    // GET: Tweet/Delete/5
    public async Task<IActionResult> Delete (int? id) {
      if (id == null) {
        return NotFound ();
      }

      var Tweet = await _context.Tweet
        .FirstOrDefaultAsync (m => m.Id == id);
      if (Tweet == null) {
        return NotFound ();
      }

      return View (Tweet);
    }

    // POST: Tweet/Delete/5
    [HttpPost, ActionName ("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed (int id) {
      var Tweet = await _context.Tweet.FindAsync (id);
      _context.Tweet.Remove (Tweet);
      await _context.SaveChangesAsync ();
      return RedirectToAction (nameof (Index));
    }

    private bool TweetExists (int id) {
      return _context.Tweet.Any (e => e.Id == id);
    }

    [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error () {
      return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Privacy () {
      return View ();
    }
  }
}