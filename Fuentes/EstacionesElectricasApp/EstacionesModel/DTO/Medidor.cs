using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public class Medidor
    {
        private int id;
        private DateTime fechaInstalacion;

        public Medidor(int id, DateTime fechaInstalacion)
        {
            this.id = id;
            this.fechaInstalacion = fechaInstalacion;
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



        public Boolean EnviarLectura(Medicion medicion)
        {
            return true;
        }
    }
}
