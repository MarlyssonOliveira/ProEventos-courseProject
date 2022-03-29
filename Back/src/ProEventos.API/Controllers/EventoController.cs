using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        IEnumerable<Evento>  _evento = new Evento[]
            {
                new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular 11 e .NET 5",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImagemURL = "foto.png"
                },
                new Evento()
                {
                    EventoId = 2,
                    Tema = "Git e ETC",
                    Local = "SP",
                    Lote = "3º Lote",
                    QtdPessoas = 550,
                    DataEvento = DateTime.Now.AddDays(6).ToString(),
                    ImagemURL = "fotoCapa.png"
                }
            };

        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "metodo post usado";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"metodo put usado e o id foi {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"metodo Delete usado e o id foi {id}";
        }
    }
}
