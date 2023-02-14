using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteProject.Models;
using NoteProject.NoteDataContexts;

namespace NoteProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NoteDataContext db;
    public HomeController(ILogger<HomeController> logger, NoteDataContext _db)
    {
        _logger = logger;
        db = _db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        try
        {
            var notes = await db.Notes.OrderBy(o => o.ID).Select(s => new{s.ID,s.NoteDesc,s.ParentNoteID }).ToListAsync();
            return Ok(notes);
        }
        catch (Exception ex)
        {
            return BadRequest("Bir Hata Oldu");
        }
    }
    [HttpPost]
    public async Task<IActionResult> SendNote(NoteCreateModel model)
    {
        try
        {
            var noteModel = new NoteModel()
            {
                NoteDesc = model.NoteDesc,
                ParentNoteID=(model.ParentID==0)?null:model.ParentID,
            };
            await db.AddAsync(noteModel);
            await db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest("Bir Hata Oluştu");
        }
    }

}

