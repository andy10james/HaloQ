using System;

namespace HaloQ {

    public class App {

        [STAThread]
        public static void Main(string[] args) {
            var server = GetHaloServerFromArgs(args);
            foreach (var record in server.GetDictionaryResponse()) {
                Console.WriteLine(string.Format("{0,12}  {1,0}", record.Key, record.Value));
            }
        }

        private static HaloServer GetHaloServerFromArgs(string[] args) {
            var serverArgs = args;
            string host; int port;
            if (args.Length == 1) serverArgs = args[0].Split(':');
            if (serverArgs.Length == 0 || serverArgs.Length > 2) {
                Console.WriteLine("haloq (host[:port] | host [port])");
                Environment.Exit(0);
            }
            host = serverArgs[0];
            if (serverArgs.Length == 1) port = 2302;
            else port = int.Parse(serverArgs[1]);
            return new HaloServer(host, port);
        }

    }
}
