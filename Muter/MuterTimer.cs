using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Muter
{
    class MuterTimer
    {
        Timer timer;
        CoreAudioDevice defaultPlaybackDevice;
        public MuterTimer()
        {
            defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        }

        public void Start()
        {
            timer = new Timer(60000);
            timer.Elapsed += Mute;
            timer.Enabled = true;
        }

        public void Stop()
        {
            if (timer.Enabled)
                timer.Dispose();
            UnMute();
        }

        public bool GetMuteStatus()
        {
            return defaultPlaybackDevice.IsMuted;
        }

        public void Mute(object sender, ElapsedEventArgs e)
        {
            if (!GetMuteStatus())
                defaultPlaybackDevice.Mute(true);
        }

        public void UnMute()
        {
            if (GetMuteStatus())
                defaultPlaybackDevice.Mute(false);
        }
    }
}
