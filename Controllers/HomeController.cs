using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using injecaoDependencia.Models;
using injecaoDependencia.Repository;

namespace injecaoDependencia.Controllers
{
    public class HomeController : Controller
    {

        private IPeopleRepository _peopleRepository;

        public HomeController(IPeopleRepository repository)
        {
            //jeito errado
            //a HomeController esta sabendo de detalhes demais
            //isso é nao utilizacao de injecao de dependecia
            
            //_peopleRepository = new PeopleRepository("minhaStringSqlFake");

            //Jeito certo
            //a home nao estao sabendo de detalhes demais
            //injecao de depencia
            _peopleRepository = repository;

        }

        public IActionResult Index()
        {

            ViewData["Name"] = _peopleRepository.GetNameById(123);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
