using Bicycles.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bicycles.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private BikeContext db;
        public BikeController(BikeContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Bike> Get()
        {
            return db.Bicycles.ToList();
        }

        [HttpGet("StatusTrue")]
        public List<Bike> GetStatusTrue()
        {
            List<Bike> bicycles = db.Bicycles.ToList();
            List<Bike> status = new List<Bike>();
            foreach(Bike bike in bicycles)
            {
                if(bike.Status == true)
                {
                    status.Add(bike);
                }
            }
            return status;
        }

        [HttpGet("StatusFalse")]
        public List<Bike> GetStatusFalse()
        {
            List<Bike> bicycles = db.Bicycles.ToList();
            List<Bike> status = new List<Bike>();
            foreach (Bike bike in bicycles)
            {
                if(bike.Status == false)
                {
                    status.Add(bike);
                }
            }
            return status;
        }

        [HttpPost]
        public void Add(Bike request)
        {
            Bike bike = new Bike { Name = request.Name, Type = request.Type, Price = request.Price, Status=false };
            db.Bicycles.Add(bike);
            db.SaveChangesAsync();
        }

        [HttpGet("{id}")]
        public void Edit(int id)
        {
            Bike bike = db.Bicycles.Find(id);
            if (bike != null) 
            { 
                if (bike.Status == false)
                {
                    bike.Status = true;
                }
                else
                    bike.Status = false;
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Bike bike = db.Bicycles.Find(id);
            if (bike != null)
            {
                db.Bicycles.Remove(bike);
                db.SaveChanges();
            }
        }
    }
}