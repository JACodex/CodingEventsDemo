using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext _db;

       public EventsController(EventDbContext dbContext)
        {
            _db = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());
            List<Event> events = _db.Events.ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type
                };

                //EventData.Add(newEvent);
                _db.Events.Add(newEvent);
                _db.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //controller code will go here
            Event editedEvent = EventData.GetById(eventId);
            ViewBag.editedEvent = editedEvent;
            ViewBag.eventId = eventId;
            ViewBag.title = $"Edit Event {editedEvent.Name} id = {editedEvent.Id}";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            ViewBag.editedEvent = EventData.GetById(eventId);
            ViewBag.editedEvent.Name = name;
            ViewBag.editedEvent.Description = description;
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = _db.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = _db.Events.Find(eventId);
                if (theEvent != null)
                {
                    _db.Events.Remove(theEvent);
                }
            }
            _db.SaveChanges();

            return Redirect("/Events");
        }
    }
}
