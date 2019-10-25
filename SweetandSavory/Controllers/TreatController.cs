using Microsoft.AspNetCore.Mvc;
using SweetandSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace SweetandSavory.Controllers
{
  
  public class TreatController : Controller
  {
    private readonly SweetandSavoryContext _db;

    public TreatController(SweetandSavoryContext db)
    {
      _db = db;
    }


    public ActionResult Index()
    {

      return View(_db.Treat.ToList());
    }
    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treat
      .Include(treat => treat.Flavor)
      .ThenInclude(join => join.Flavor)
      .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavor, "FlavorId", "FlavorName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat, int FlavorId)
    {
      _db.Treat.Add(treat);
      if (FlavorId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



    [HttpPost]
    public ActionResult Index(string search)
    {
      List<Treat> model = _db.Treat.ToList();
      if (!String.IsNullOrEmpty(search))
      {
        model = model.Where(treat => treat.TreatName.ToLower().Contains(search.ToLower())).Select(treat => treat).ToList();
      }
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavor, "FlavorId", "FlavorName");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavor, "FlavorId", "FlavorName");
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treat.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treat.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatFlavor.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}