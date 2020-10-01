using System;
using Syn.Speech.Api;
using System.IO;
using Syn.Logging;

namespace LoveVisionVoice
{
    class MainClass
    {
        static Configuration speechConfiguration;
        static StreamSpeechRecognizer speechRecognizer;

        void LogReceived(object sender, LogReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void Main()
        {
            Logger.LogReceived += LogReceived;

            var modelsDirectory = Path.Combine(Directory.GetCurrentDirectory());
            var audioDirectory = Path.Combine(Directory.GetCurrentDirectory());
            var audioFile = Path.Combine(audioDirectory, "Long Audio 2.wav");

            if (!Directory.Exists(modelsDirectory) || !Directory.Exists(audioDirectory))
            {
                Console.WriteLine("No Models or Audio directory found!! Aborting...");
                Console.ReadLine();
                return;
            }

            speechConfiguration = new Configuration();
            //speechConfiguration.AcousticModelPath = modelsDirectory;
            //speechConfiguration.DictionaryPath = Path.Combine(modelsDirectory, "cmudict-en-us.dict");
            //speechConfiguration.LanguageModelPath = Path.Combine(modelsDirectory, "en-us.lm.dmp");

            speechRecognizer = new StreamSpeechRecognizer(speechConfiguration);
            speechRecognizer.StartRecognition(new FileStream(audioFile, FileMode.Open));

            Console.WriteLine("Transcribing...");
            var result = speechRecognizer.GetResult();

            if (result != null)
            {
                Console.WriteLine("Result: " + result.GetHypothesis());
            }
            else
            {
                Console.WriteLine("Sorry! Couldn't Transcribe");
            }

            Console.ReadLine();
        }
    }
}