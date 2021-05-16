using EstacionesModel.DAL;
using EstacionesModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesElectricasApp.Hilos
{
   public class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private IMedidoresDAL dal = MedidoresDALFactory.CreateDAL();
        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            
            clienteSocket.Escribir("Ingrese FECHA | NUMERO | TIPO");
            string lectura1 = clienteSocket.Leer().Trim();
            string[] textoArray = lectura1.Split('|');
            string[] fechas = textoArray[0].Split('-');
           
                int anio = Convert.ToInt32(fechas[0]);
                int mes = Convert.ToInt32(fechas[1]);
                int dia = Convert.ToInt32(fechas[2]);
                int horas = Convert.ToInt32(fechas[3]);
                int minutos = Convert.ToInt32(fechas[4]);
                int segundos = Convert.ToInt32(fechas[5]);
                Medicion lectura = new Medicion()
                {
                    Fecha = new DateTime(anio, mes, dia, horas, minutos, segundos),
                    Id = Convert.ToInt32(textoArray[1]),
                    Tipo = textoArray[2]
                };
            //}
            //catch(Exception ex)
            //{
            //    clienteSocket.Escribir("Algo ocurrio mal");
            //}

            
           
            clienteSocket.CerrarConexion();
        }
    }
}
