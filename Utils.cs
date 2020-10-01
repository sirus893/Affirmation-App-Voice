using Emgu.CV.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveVisionVoice
{
    public class Utils : IUtils
    {
        public void Log(string message, ConsoleColor messageColour)
        {
            Console.ForegroundColor = messageColour;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public interface IUtils
    {
        void Log(string message, ConsoleColor messageColour);
    }
}
