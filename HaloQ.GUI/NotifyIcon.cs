using System;
using System.Windows.Forms;

namespace HaloQ {

    public class NotifyIcon {

        static System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon() {
            ContextMenu = new ContextMenu(new MenuItem[] { 
                new MenuItem("Exit HaloQ", new EventHandler(ExitLSMW_Click))
            }),
            Icon = Properties.Resources.MainIcon,
            Visible = true
        };

        public NotifyIcon() {
            icon.DoubleClick += new EventHandler(NotifyIcon_DoubleClick);
        }

        private static void NotifyIcon_DoubleClick(object e, EventArgs args) { }

        private static void ExitLSMW_Click(object e, EventArgs args) {
            icon.Dispose();
            Application.Exit();
        }

        public void ShowBalloonTip(int timeout, String title, String description, ToolTipIcon toolTipIcon) {
            icon.ShowBalloonTip(timeout, title, description, toolTipIcon);
        }
        
    }
}
