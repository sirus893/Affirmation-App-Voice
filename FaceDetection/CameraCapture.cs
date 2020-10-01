using Emgu.CV;
using System;


namespace LoveVision
{
    public class CameraCapture : IDisposable
    {
        private VideoCapture _videoCapture;
        private HandlePhrases _handlePhrases = new HandlePhrases();

        public bool AutoDetect { get; set; }
        private bool _disposed = false;

        public CameraCapture(VideoCapture videoCapture)
        {
            _videoCapture = videoCapture;
        }

        public void ProcessFrameEverySecond()
        {
            using (var frame = new Mat())
            {
                _videoCapture.Retrieve(frame, 0);

                if (AutoDetect)
                {
                    using (FaceDetection faceDetector = new FaceDetection())
                    {
                        var foundFace = faceDetector.DetectFace(frame);
                        if (foundFace)
                        {
                            Console.WriteLine(_handlePhrases.GetSaying());
                        }
                        else
                        {
                            Console.WriteLine("I didn't find you!!");
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                    _videoCapture.Dispose();
                    _videoCapture = null;
                    _handlePhrases = null;
                }

                if (!AutoDetect)
                {
                    _handlePhrases = null;
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}