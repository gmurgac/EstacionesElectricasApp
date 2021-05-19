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
            try
            {
                clienteSocket.Escribir("Ingrese FECHA | NUMERO | TIPO");
                string lectura1 = clienteSocket.Leer().Trim();
                string[] textoArray = lectura1.Split('|');
                string[] fechas = textoArray[0].Split('-');
                try
                {
                    DateTime actual = DateTime.Now;
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
                    if (dal.EncontrarMedidor(lectura.Id, lectura.Tipo))
                    {

                        int diferenciaMinutos = (lectura.Fecha - actual).Minutes;
                        if (diferenciaMinutos > 30)
                        {
                            clienteSocket.Escribir("Paso màs de 30 minuto");
                            clienteSocket.CerrarConexion();
                        }
                        else
                        {
                            string fechaActual = actual.ToString("yyyy-MM-dd-HH-mm-ss");
                            string respuesta = "" + fechaActual + "|WAIT)";
                            clienteSocket.Escribir(respuesta);
                            string lectura2 = clienteSocket.Leer().Trim();
                            string[] textoArray2 = lectura2.Split('|');
                            string[] fechas2 = textoArray2[1].Split('-');
                            try
                            {
                                anio = Convert.ToInt32(fechas[0]);
                                mes = Convert.ToInt32(fechas[1]);
                                dia = Convert.ToInt32(fechas[2]);
                                horas = Convert.ToInt32(fechas[3]);
                                minutos = Convert.ToInt32(fechas[4]);
                                segundos = Convert.ToInt32(fechas[5]);

                                Medicion lectura3 = new Medicion()
                                {
                                    Fecha = new DateTime(anio, mes, dia, horas
                                    , minutos, segundos),
                                    Id = Convert.ToInt32(textoArray2[0]),
                                    Tipo = textoArray2[2],
                                    Valor = Convert.ToInt32(textoArray2[3]),

                                };
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                    else
                    {
                        clienteSocket.Escribir("Medidor no registrado o no coincide tipo");
                        clienteSocket.CerrarConexion();
                    }


                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }

            

            //}
            //catch(Exception ex)
            //{
            //    clienteSocket.Escribir("Algo ocurrio mal");
            //}




        }
    }
}
