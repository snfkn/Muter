using System;
using System.Windows.Forms;

namespace Muter
{
    class MuterContext : ApplicationContext
    {
        NotifyIcon notifyIcon;
        MuterTimer muter;
        public MuterContext()
        {
            muter = new MuterTimer();
            MenuItem startMenuItem = new MenuItem("Start", new EventHandler(Start));
            MenuItem stopMenuItem = new MenuItem("Stop", new EventHandler(Stop));
            MenuItem closeMenuItem = new MenuItem("Close", new EventHandler(Close));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Muter.Properties.Resources.icon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { startMenuItem, stopMenuItem, closeMenuItem });
            notifyIcon.Visible = true;
        }

        public  void Start(object sender, EventArgs e)
        {
            muter.Start();
            notifyIcon.Text = "Running";
        }

        public void Stop(object sender, EventArgs e)
        {
            muter.Stop();
            notifyIcon.Text = "Stopped";
        }

        public void Close(object sender, EventArgs e)
        {
            notifyIcon.Icon = null;
            Application.Exit();
        }
    }
}
