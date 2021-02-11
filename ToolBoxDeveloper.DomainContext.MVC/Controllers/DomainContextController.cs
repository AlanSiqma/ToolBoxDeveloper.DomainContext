using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.MVC.Controllers
{
    public class DomainContextController : Controller
    {
        private readonly IDomainContextService _domainContextService;
        public DomainContextController(IDomainContextService domainContextService)
        {
            this._domainContextService = domainContextService;
        }
        // GET: DomainContextController

        public async Task<ActionResult> Index()
        {
            List<DomainContextDto> list = await this._domainContextService.GetAll();

            return View(list);
        }

        // GET: DomainContextController/Create
        public ActionResult Create()
        {
            return View(new DomainContextDto());
        }

        // POST: DomainContextController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DomainContextDto dto)
        {
            try
            {
                await this._domainContextService.AddOrUpdate(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dto);
            }
        }

        // GET: DomainContextController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            DomainContextDto result = await this._domainContextService.Find(id);

            return View(result);
        }

        // POST: DomainContextController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DomainContextDto dto)
        {
            try
            {
                await this._domainContextService.AddOrUpdate(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await this._domainContextService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
