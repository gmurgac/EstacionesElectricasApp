﻿
using MedidoresClienteApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresClienteApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iniciando conexion");
            ClienteSocket clienteSocket = new ClienteSocket(puerto, ip);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("HOLA");
            }   
           
        }
    }
}