using APICaseGM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APICaseGM.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            ViewBag.Sexo = SelectListSexo(null);
            ViewBag.PossuiVeiculo = SelectListPossuiVeiculo(null);
            ViewBag.TipoCNH = SelectListTipoCNH(null);
            ViewBag.Carregado = SelectListCarregado(null);
            ViewBag.Caminhao = SelectListCaminhao(null);

            ViewBag.ListCaminhoneiro = SelectListCaminhoneiro();

            return View();
        }

        public List<SelectListItem> SelectListCaminhoneiro()
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            var listCaminhoneiro = db.Caminhoneiro.ToList();

            foreach (var item in listCaminhoneiro)
            {
                SelectList.Add(new SelectListItem { Text = item.nome, Value = item.idCaminhoneiro.ToString(), Selected = false });
            }

            return SelectList;
        }

        public List<SelectListItem> SelectListSexo(string sexo)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            SelectList.Add(new SelectListItem { Text = "Masculino", Value = "M", Selected = sexo == "M" ? true : false });
            SelectList.Add(new SelectListItem { Text = "Feminino", Value = "F", Selected = sexo == "F" ? true : false });

            return SelectList;
        }

        public List<SelectListItem> SelectListPossuiVeiculo(string pVeiculo)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            SelectList.Add(new SelectListItem { Text = "Sim", Value = "S", Selected = pVeiculo == "S" ? true : false });
            SelectList.Add(new SelectListItem { Text = "Nao", Value = "N", Selected = pVeiculo == "N" ? true : false });

            return SelectList;
        }

        public List<SelectListItem> SelectListTipoCNH(string tpCNH)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            SelectList.Add(new SelectListItem { Text = "A", Value = "A", Selected = tpCNH == "A" ? true : false });
            SelectList.Add(new SelectListItem { Text = "B", Value = "B", Selected = tpCNH == "B" ? true : false });
            SelectList.Add(new SelectListItem { Text = "C", Value = "C", Selected = tpCNH == "C" ? true : false });
            SelectList.Add(new SelectListItem { Text = "D", Value = "D", Selected = tpCNH == "D" ? true : false });
            SelectList.Add(new SelectListItem { Text = "E", Value = "E", Selected = tpCNH == "E" ? true : false });

            return SelectList;
        }

        public List<SelectListItem> SelectListCarregado(string carregado)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            SelectList.Add(new SelectListItem { Text = "Sim", Value = "S", Selected = carregado == "S" ? true : false });
            SelectList.Add(new SelectListItem { Text = "Nao", Value = "N", Selected = carregado == "N" ? true : false });

            return SelectList;
        }

        public List<SelectListItem> SelectListCaminhao(string caminhao)
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            DataContext db = new DataContext();

            var listCaminhao = db.Caminhao.ToList();

            foreach (var item in listCaminhao)
            {
                SelectList.Add(new SelectListItem { Text = item.descricao, Value = item.codigo.ToString(), Selected = caminhao == item.codigo.ToString() ? true : false });
            }

            return SelectList;
        }
    }
}
