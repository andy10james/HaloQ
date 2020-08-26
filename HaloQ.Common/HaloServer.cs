using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace HaloQ {

    public class HaloServer {

        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp) { ReceiveTimeout = 1000 };

        public string ServerHost;
        public int ServerPort;

        public HaloServer(string host, int port) {
            this.ServerHost = host;
            this.ServerPort = port;
        }

        public string GetRawResponse() {
            socket.Connect(this.ServerHost, this.ServerPort);
            byte[] buffer = Encoding.Default.GetBytes("\\status\\");
            int received = 0;
            socket.Send(buffer);
            buffer = new byte[4096];
            received = socket.Receive(buffer);
            socket.Close();
            return Encoding.Default.GetString(buffer, 0, received);
        }

        public Dictionary<string, string> GetDictionaryResponse(string rawResponse = null) {
            if (rawResponse == null) rawResponse = this.GetRawResponse();
            string[] dataPart = rawResponse.Split('\\');
            Dictionary<string, string> parsedResponse = new Dictionary<string, string>();
            for (int i = 1; i < dataPart.Length; i += 2) {
                parsedResponse.Add(dataPart[i], dataPart[i + 1]);
            }
            return parsedResponse;
        }

    }
}
