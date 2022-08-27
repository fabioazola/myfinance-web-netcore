using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    //[Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        public TransacaoController(ILogger<TransacaoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.ListaTransacoes();
            return View();

        }

        [HttpGet]
        public IActionResult CriarTransacao()
        {
            ViewBag.ListaPlanoContas = new PlanoContaModel().ListaPlanoContas();
            return View();
        }


        [HttpPost]
        public IActionResult CriarTransacao(TransacaoModel formulario)
        {
            var transacao = new Transacao();

            if ((formulario.Id == null) || (formulario.Id.Equals(0)))
                transacao.Inserir(formulario);
            //else
              //  formulario.Atualizar(formulario.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirTransacao(int id)
        {
            var transacao = new Transacao();

            transacao.Excluir(id);
            return RedirectToAction("Index");
        }



    }
}