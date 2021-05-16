using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public class Medidor
    {
        protected int id;
        protected DateTime fechaInstalacion;
        protected string tipo;

        public Medidor(int id, DateTime fechaInstalacion, string tipo)
        {
            this.id = id;
            this.fechaInstalacion = fechaInstalacion;
            this.Tipo = tipo;
        }

        protected int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        protected DateTime FechaInstalacion
        {
            get
            {
                return fechaInstalacion;
            }

            set
            {
                fechaInstalacion = value;
            }
        }

        protected string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public Boolean EnviarLectura(Medicion medicion)
        {
            return true;
        }
    }
}
