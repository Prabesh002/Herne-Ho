using Herne_ho.Data;
using Herne_ho.Models;
using Herne_ho.Models.Entities;
using Herne_ho.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public IActionResult Clients()
        {
            var data = _appDb.ClientModels.ToList();
            List<ClientViewModel> clients = new List<ClientViewModel>();

            foreach(var client in data)
            {
                clients.Add(new ClientViewModel()
                {
                    ClientId = client.ClientId,
                    ClientEmail = client.ClientEmail,
                    ClientName = client.ClientName,
                    CLientPhone = client.CLientPhone,
                    HiredWorker = client.HiredWorker
                });
                
            }
            return View(clients);
        }

        public IActionResult UpdateClient(Guid ClientId)
        {
            var data = _appDb.ClientModels.FirstOrDefault(x => x.ClientId == ClientId);
            if (data == null)
            {
                TempData["Sucess"] = $"The ID {data.ClientId} was not registered on the server";
                return RedirectToAction("Index");
            }
            return View(data);
        }

        
        public IActionResult DeleteClient(Guid clientId)
        {
            var data = _appDb.ClientModels.Find(clientId);
            if (clientId != null)
            {
               
                _appDb.ClientModels.Remove(data);
                _appDb.SaveChanges();
                TempData["Sucess"] = $"{data.ClientName} was removed";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult UpdateClient(ClientModel cm)
        {
            if (ModelState.IsValid)
            {
                var data = _appDb.ClientModels.Find(cm.ClientId);
                if(data != null)
                {
                    data.ClientName = cm.ClientName;
                    data.ClientEmail = cm.ClientEmail;
                    data.CLientPhone = cm.CLientPhone;
                    _appDb.ClientModels.Update(data);
                    _appDb.SaveChanges();
                    TempData["Sucess"] = $"The Client {data.ClientName} was Updated Sucessfully!";
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }
        public IActionResult AddClients()
        {
            List<ClientModel> clientModels = _appDb.ClientModels.ToList();
            ViewBag.Clients = clientModels;
            List<WorkerModel> workerModels = _appDb.WorkerModels.ToList();
            ViewBag.Workers = workerModels;
            return View();
        }
        [HttpPost]
        public IActionResult AddClients(ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new ClientModel()
                {
                    ClientName = clientViewModel.ClientName,
                    ClientEmail = clientViewModel.ClientEmail,
                    CLientPhone= clientViewModel.CLientPhone,
                    HiredWorker = clientViewModel.HiredWorker

                };
                _appDb.ClientModels.Add(client);
                _appDb.SaveChanges();
                TempData["Sucess"] = $"{client.ClientName} was updated sucessfully";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
