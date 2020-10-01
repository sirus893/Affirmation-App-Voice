using Emgu.CV;
using LoveVisionVoice.Voice;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LoveVisionVoice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program Started..");

            // First think we need to do is make sure the mic is working and on
            // for the duration of the app running

            var listen = new Listen();
            while(true)
            {
                var speech = new MainClass();
                speech.Main();
            }

        }
    }
}
