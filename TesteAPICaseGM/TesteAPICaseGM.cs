using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APICaseGM;
using APICaseGM.Models;
using APICaseGM.Controllers;
using APICaseGM.Data;
using System.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Net;

namespace TesteAPICaseGM
{
    [TestClass]
    public class TesteAPICaseGM
    {
        private DataContext db = new DataContext();

        [TestMethod]
        public void Teste_PostCaminhoneiro()
        {
            //Parametros
            Caminhoneiro caminhoneiro = new Caminhoneiro();

            caminhoneiro.nome = "Caminhoneiro Teste";
            caminhoneiro.idade = 28;
            caminhoneiro.sexo = "M";
            caminhoneiro.possuiVeiculo = "S";
            caminhoneiro.tipoCNH = "D";
            caminhoneiro.carregado = "S";
            caminhoneiro.caminhao = 1;
            caminhoneiro.dataChegada = DateTime.Now;

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Cadastrado")
            };

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.PostCaminhoneiro(caminhoneiro);

            //Assert
            Assert.ReferenceEquals(response, teste);
        }

        [TestMethod]
        public void Teste_GetCaminhoneiro()
        {
            //Parametros
            var caminhoneiro = db.Caminhoneiro.Where(c => c.idCaminhoneiro == 8).First();

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.GetCaminhoneiro("8");

            //Assert
            Assert.ReferenceEquals(caminhoneiro, teste);
        }

        [TestMethod]
        public void Teste_EditCaminhoneiro()
        {
            //Parametros
            var caminhoneiro = db.Caminhoneiro.Where(c => c.idCaminhoneiro == 8).First();
            var caminhoneitoEdit = new Caminhoneiro();

            caminhoneitoEdit.idCaminhoneiro = caminhoneiro.idCaminhoneiro;
            caminhoneitoEdit.nome = "Caminhoneiro Teste 8";
            caminhoneitoEdit.idade = caminhoneiro.idade;
            caminhoneitoEdit.sexo = caminhoneiro.sexo;
            caminhoneitoEdit.possuiVeiculo = caminhoneiro.possuiVeiculo;
            caminhoneitoEdit.tipoCNH = caminhoneiro.tipoCNH;
            caminhoneitoEdit.carregado = caminhoneiro.carregado;
            caminhoneitoEdit.caminhao = caminhoneiro.caminhao;
            caminhoneitoEdit.dataChegada = caminhoneiro.dataChegada;
            caminhoneitoEdit.origem = caminhoneiro.origem;
            caminhoneitoEdit.destino = caminhoneiro.destino;

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Editado")
            };

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.EditCaminhoneiro(caminhoneitoEdit);

            //Assert
            Assert.ReferenceEquals(response, teste);
        }

        [TestMethod]
        public void Teste_CaminhoneiroComVeiculos()
        {
            //Parametros
            string count = db.Caminhoneiro.Where(c => c.possuiVeiculo == "S").Count().ToString();

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.GetListCaminhoneiroComVeiculos();

            //Assert
            Assert.AreEqual(count, teste);
        }

        [TestMethod]
        public void Teste_GetListCaminhoneiroPeriodo()
        {
            //Parametros
            string dataInicio = "01/05/2019";
            string dataFinal = "10/05/2019";

            var listCaminhoneiros = db.Caminhoneiro.ToList();
            listCaminhoneiros = listCaminhoneiros.Where(c => c.dataChegada >= Convert.ToDateTime(dataInicio) && c.carregado == "S").ToList();
            listCaminhoneiros = listCaminhoneiros.Where(c => c.dataChegada <= Convert.ToDateTime(dataFinal) && c.carregado == "S").ToList();

            string count = listCaminhoneiros.Count().ToString();

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.GetListCaminhoneiroPeriodo(dataInicio, dataFinal);

            //Assert
            Assert.AreEqual(count, teste);
        }

        [TestMethod]
        public void Teste_CaminhoneiroCarga()
        {
            //Parametros
            string id = "S";

            var listCaminhoneiros = db.Caminhoneiro.Where(c => c.carregado == id).ToList();

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.GetListCaminhoneiroCarga(id);

            //Assert
            Assert.ReferenceEquals(listCaminhoneiros, teste);
        }

        [TestMethod]
        public void Teste_CaminhoneiroPeriodo()
        {
            //Parametros
            string dataInicio = "01/05/2019";
            string dataFinal = "10/05/2019";

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

            //Objeto API
            APIController apiController = new APIController();

            var teste = apiController.GetListCaminhoneiroPeriodo(dataFinal, dataFinal);

            //Assert
            Assert.ReferenceEquals(listCaminhoneiros, teste);
        }
    }
}
