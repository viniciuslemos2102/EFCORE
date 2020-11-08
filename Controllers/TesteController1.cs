using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EFCORE.Controllers
{
    public class TesteController1 : Controller
    {
        private AlunoContext _context;
        public TesteController1(AlunoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var alunos = _context.Alunos.ToList();
            return View(alunos);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Sexo,Email,Nascimento")]Aluno aluno)
        {
           if(ModelState.IsValid)
            {
                _context.Add(aluno);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
    }
}
