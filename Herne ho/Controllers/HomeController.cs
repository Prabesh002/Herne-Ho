using Herne_ho.Data;
using Herne_ho.Models;
using Herne_ho.Models.Entities;
using Herne_ho.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Herne_ho.Controllers
{
    public class HomeController : Controller
    { 
        private readonly AppDb _appDb;

        public HomeController(AppDb appDb)
        {
            _appDb = appDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddWorkers()
        {
            List<WorkerModel> workers = _appDb.WorkerModels.ToList();
            ViewBag.Workers = workers;
            return View();
        }

   
        public IActionResult Workers()
        {
            var data = _appDb.WorkerModels.ToList();
            List<WorkerViewModel> workers = new List<WorkerViewModel>();
            foreach(var worker in data)
            {
                var workerData = new WorkerViewModel()
                {
                    WorkerId = worker.WorkerId,
                    WorkerName = worker.WorkerName,
                    WorkerEmail = worker.WorkerEmail,
                    WorkerPhone = worker.WorkerPhone,
                    WorkerType = worker.WorkerType,
                };
                workers.Add(workerData);
            }
            return View(workers);
        }

        public IActionResult DeleteWorker(Guid workerId)
        {
            var data = _appDb.WorkerModels.Find(workerId);
            if(data != null)
            {
                _appDb.WorkerModels.Remove(data);
                _appDb.SaveChanges();
                TempData["Sucess"] = $"{data.WorkerName} Was Deleted sucessfully";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateWorker(Guid workerId)
        {
            var data = _appDb.WorkerModels.FirstOrDefault(x => x.WorkerId == workerId);
            if(data == null)
            {
                TempData["Sucess"] = $"The ID {data.WorkerId} was not registered on the server";
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateWorker(WorkerModel workerModel)
        {
            if (ModelState.IsValid)
            {
              var data = _appDb.WorkerModels.Find(workerModel.WorkerId);
               if(data != null)
                {
                    data.WorkerName = workerModel.WorkerName;
                    data.WorkerEmail = workerModel.WorkerEmail;
                    data.WorkerType = workerModel.WorkerType;
                    data.WorkerPhone = workerModel.WorkerPhone;
                }
               _appDb.WorkerModels.Update(data);
               _appDb.SaveChanges();
                TempData["Sucess"] = $"{data.WorkerName} was updated sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddWorkers(WorkerViewModel workerViewModel)
        {
            if (ModelState.IsValid)
            {
                var worker = new WorkerModel {
                   
                   WorkerName = workerViewModel.WorkerName,
                   WorkerEmail = workerViewModel.WorkerEmail,
                   WorkerType = workerViewModel.WorkerType,
                   WorkerPhone = workerViewModel.WorkerPhone
                
                };

                _appDb.WorkerModels.Add(worker);
                _appDb.SaveChanges();
                TempData["Sucess"] = $"{worker.WorkerName} was Added Sucessfully";
               

            }
            return RedirectToAction("Index");
        }
    }
}
