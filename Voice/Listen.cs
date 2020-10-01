using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoveVisionVoice.Voice
{ 
    public class Listen
    {
        private IUtils utils;

        public Listen()
        {
            utils = new Utils();
        }
        public string ListenForCommand()
        {
            if (WaveIn.DeviceCount == 0)
            {
                utils.Log("Cant find microphone", ConsoleColor.Red);
            }

            var ddd = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 1)
            };


            return "";

        }
    }
}
