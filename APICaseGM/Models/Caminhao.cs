using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICaseGM.Models
{
    public class Caminhao
    {
        public Caminhao()
        {
            this.CaminhoneiroCaminhao = new HashSet<Caminhoneiro>();
        }

        public int codigo { get; set; }
        public string descricao { get; set; }

        public virtual ICollection<Caminhoneiro> CaminhoneiroCaminhao { get; set; }
    }
}