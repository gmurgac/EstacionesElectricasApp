﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresClienteApp.Comunicacion
{
    public class ClienteSocket
    {
      
       private int puerto;
        private string ip;
        private Socket comunicacionServidor;
        private StreamReader reader;
        private StreamWriter writer;

        public ClienteSocket(int puerto, string ip)
        {
            this.puerto = puerto;
            this.ip = ip;
        }
        public bool Conectar()
        {
            try
            {
                this.comunicacionServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), puerto);
                this.comunicacionServidor.Connect(endpoint);
                Stream stream = new NetworkStream(this.comunicacionServidor);
                this.reader = new StreamReader(stream);
                this.writer = new StreamWriter(stream);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
