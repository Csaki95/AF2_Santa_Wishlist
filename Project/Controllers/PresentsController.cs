using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Controllers
{
    public class PresentsController : Controller
    {
        private readonly EFContext _context;

        public PresentsController(EFContext context)
        {
            _context = context;
        }

        // GET: Presents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presents.OrderByDescending(a => a.Priority).ToListAsync());
        }

        // GET: Presents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presents = await _context.Presents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (presents == null)
            {
                return NotFound();
            }

            return View(presents);
        }

        // GET: Presents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Colour,Weight,Priority")] Presents presents)
        {
            if (ModelState.IsValid)
            {
                // Alert üzenet a Create ablakhoz már létező név esetén
                if (PresentsNameExists(presents.Name))
                {
                    ViewBag.Message = string.Format("Present with name: {0} already exists!", presents.Name);
                    ViewBag.ShowDialog = true;
                }
                else
                {
                    _context.Add(presents);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(presents);
        }

        // GET: Presents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presents = await _context.Presents.FindAsync(id);
            if (presents == null)
            {
                return NotFound();
            }
            return View(presents);
        }

        // POST: Presents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Colour,Weight,Priority")] Presents presents)
        {
            if (id != presents.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Csak a szin, es prioritas property lesz lementve
                    _context.Attach(presents);
                    _context.Entry(presents).Property(p => p.Colour).IsModified = true;
                    _context.Entry(presents).Property(p => p.Priority).IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentsExists(presents.ID))
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
            return View(presents);
        }

        private bool PresentsExists(int id)
        {
            return _context.Presents.Any(e => e.ID == id);
        }

        private bool PresentsNameExists(string name)
        {
            return _context.Presents.Any(e => e.Name == name);
        }
    }
}
