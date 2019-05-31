using APICaseGM.Data;
using APICaseGM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICaseGM.Controllers
{
    public class APIController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpPost]
        public HttpResponseMessage PostCaminhoneiro([FromBody] Caminhoneiro caminhoneiro)
        {
            db.Caminhoneiro.Add(caminhoneiro);
            db.SaveChanges();

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Cadastrado")
            };

            return response;
        }

        public Caminhoneiro GetCaminhoneiro(string id)
        {
            return db.Caminhoneiro.Where(c => c.idCaminhoneiro.ToString() == id).First();
        }

        [HttpPost]
        public HttpResponseMessage EditCaminhoneiro([FromBody] Caminhoneiro caminhoneiro)
        {
            db.Entry(caminhoneiro).State = EntityState.Modified;
            db.SaveChanges();

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Editado")
            };

            return response;
        }

        public IEnumerable<Caminhoneiro> GetListCaminhoneiroCarga(string id)
        {
            return db.Caminhoneiro.Where(c => c.carregado == id).ToList();
        }

        public string GetListCaminhoneiroPeriodo(string dataInicio, string dataFinal)
        {
            var listCaminhoneiros = db.Caminhoneiro.ToList();

            if (string.IsNullOrEmpty(dataFinal))
            {
                listCaminhoneiros = listCaminhoneiros.Where(c => c.dataChegada == Convert.ToDateTime(dataInicio) && c.carregado == "S").ToList();
            }
            else
            {
                listCaminhoneiros = listCaminhoneiros.Where(c => c.dataChegada >= Convert.ToDateTime(dataInicio) && c.carregado == "S").ToList();
                listCaminhoneiros = listCaminhoneiros.Where(c => c.dataChegada <= Convert.ToDateTime(dataFinal) && c.carregado == "S").ToList();
            }

            return listCaminhoneiros.Count().ToString();
        }

        public string GetListCaminhoneiroComVeiculos()
        {
            return db.Caminhoneiro.Where(c => c.possuiVeiculo == "S").Count().ToString();
        }

        public IEnumerable<dynamic> GetListCaminhoneiroPorCaminhao()
        {
            return db.Caminhoneiro.ToList().Select(c => new { c.CaminhaoCaminhoneiro.descricao, c.origem, c.destino }).GroupBy(c => c.descricao);
        }
    }
}
