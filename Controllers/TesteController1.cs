using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);
            if(aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post edit
        public IActionResult Edit(int id,[Bind("Id,Nome,Sexo,Email,Nascimento")]Aluno aluno)
        {
            if(id != aluno.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    _context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!AlunoExist(aluno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);

            if(aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        
        private bool AlunoExist(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirma(int? id)
        {
            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var aluno = _context.Alunos.SingleOrDefault(a => a.Id == id);

            if(aluno==null)
            {
                return NotFound();
            }
            return View(aluno);
        }
    }

}
