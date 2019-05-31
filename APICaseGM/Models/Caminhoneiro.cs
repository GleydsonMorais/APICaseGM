using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICaseGM.Models
{
    public class Caminhoneiro
    {
        public int idCaminhoneiro { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string sexo { get; set; }
        public string possuiVeiculo { get; set; }
        public string tipoCNH { get; set; }
        public string carregado { get; set; }
        public int caminhao { get; set; }
        public DateTime dataChegada { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }

        public virtual Caminhao CaminhaoCaminhoneiro { get; set; }
    }
}