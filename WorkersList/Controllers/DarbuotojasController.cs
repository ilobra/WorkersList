using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkersList.Models;

namespace WorkersList.Controllers
{
    public class DarbuotojasController : Controller
    {
        private DarbuotojuModel db = new DarbuotojuModel();
     

        // GET: Darbuotojas
        public ActionResult Index()
        {
            return View(db.Darbuotojas.ToList());
        }
        [HttpPost]
        // POST: Darbuotojas
        public ActionResult Index(FormCollection collection)
        {
          
            bool active = Boolean.Parse(collection[0].Split(',')[0]);
            bool unactive = Boolean.Parse(collection[1].Split(',')[0]);
            if (active == true)
            {            
                string query = "SELECT * FROM Darbuotojas WHERE Aktyvumo_pozymis='1'";
                IEnumerable<Darbuotojas> data = db.Database.SqlQuery<Darbuotojas>(query);
                return View(data.ToList());
            }
            else if (unactive == true)
            {
                string query = "SELECT * FROM Darbuotojas WHERE Aktyvumo_pozymis='0'";
                IEnumerable<Darbuotojas> data = db.Database.SqlQuery<Darbuotojas>(query);
                return View(data.ToList());
            }
            else return View(db.Darbuotojas.ToList());
            
        }

        // GET: Darbuotojas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Darbuotojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vardas,Pavarde,Asmens_kodas,Gimimo_data,Adresas,Aktyvumo_pozymis")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                darbuotojas.Aktyvumo_pozymis = true;
                db.Entry(darbuotojas).State = EntityState.Modified;
                db.Darbuotojas.Add(darbuotojas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(darbuotojas);
        }

        // GET: Darbuotojas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vardas,Pavarde,Asmens_kodas,Gimimo_data,Adresas,Aktyvumo_pozymis")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darbuotojas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas.Aktyvumo_pozymis == false)
            {
                darbuotojas.Aktyvumo_pozymis = true;
            }
            else darbuotojas.Aktyvumo_pozymis = false;
            db.Entry(darbuotojas).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
