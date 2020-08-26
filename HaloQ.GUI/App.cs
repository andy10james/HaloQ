using System;
using System.Windows.Forms;

namespace HaloQ {

    public class App {

        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new App();
            Application.Run();
        }

        private App() {
            new NotifyIcon().ShowBalloonTip(2000, "Listening to server!", "We're now listening to your Halo Server, you'll be notified when players join or leave or when your server disconnects", ToolTipIcon.Info);
        }

    }
}
