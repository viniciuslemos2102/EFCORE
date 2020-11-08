using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    public class AlunoTipoSocioController1 : Controller
    {
        private AlunoContext contexto;

        public AlunoTipoSocioController1(AlunoContext _alunoContext)
        {
            contexto = _alunoContext;
        }
        public IActionResult Index()
        {
            var infoAluno = contexto.Alunos.Include(tp=> tp.TipoSocio);
            return View(infoAluno);
        }
    }
}
