using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTimes_MVC.Repositorio;
using WebTimes_MVC.Models;

namespace WebTimes_MVC.Controllers
{
    public class TimeController : Controller
    {
        private TimesRepositorio _repositorio;

        // GET: Time
        public ActionResult ObterTimes()
        {
            _repositorio = new TimesRepositorio();
            ModelState.Clear();
            return View(_repositorio.ObterTimes());
        }

        public ActionResult IncluirTime()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirTime(Times timeObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new TimesRepositorio();

                    if (_repositorio.AdicionarTime(timeObj))
                    {
                        ViewBag.Mensagem = "Time cadastrado com sucesso!!";
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                return View("ObterTimes");
            }
        }


        public ActionResult EditarTime(int id)
        {
            _repositorio = new TimesRepositorio();
            return View(_repositorio.ObterTimes().Find(t => t.TimeId == id));
        }

        [HttpPost]
        public ActionResult EditarTime(int id,Times timeObj)
        {
            try
            {
                _repositorio = new TimesRepositorio();

                _repositorio.AtualizarTime(timeObj);

                return RedirectToAction("ObterTimes");
            }catch (Exception ex)
            {
                return View("ObterTimes");
            }
        }

        public ActionResult ExcluirTime(int id)
        {
            try
            { 
                _repositorio = new TimesRepositorio();
                if (_repositorio.ExcluirTime(id))
                {
                    ViewBag.Mensagem = "Time excluído com sucesso!!";
                }

                return RedirectToAction("ObterTimes");
            }catch (Exception ex)
            {
                return View("ObterTimes");
            }
        }
    }
}