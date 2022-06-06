using GleamTech.VideoUltimate;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace theSharp
{
    class Buffer
    {
        public Bitmap ImageBuffer;
        public double FrameRate;

        private Queue<Bitmap> _videoBuffer = new Queue<Bitmap>();

        private VideoFrameReader _reader;
        private bool _canBeRead = false;

        public Buffer() { }

        public Buffer(string file)
        {
            _reader = new VideoFrameReader(file);
            FrameRate = _reader.FrameRate;

            _canBeRead = true;
        }

        public Bitmap Get()
        {
            if (_videoBuffer.Count < 4 && _canBeRead)
            {
                AsyncUpdate();
            }
            return _videoBuffer.Dequeue();
        }

        private async void AsyncUpdate()
        {
            await Update();
        }

        private Task Update()
        {
            for (int i = 0; i < 16; i++)
            {
                if (_reader.Read())
                {
                    Bitmap target = _reader.GetFrame();

                    Bitmap ReSized = new Bitmap(target, new Size((int)(target.Size.Width * 0.4), (int)(target.Size.Height * 0.4)));
                    _videoBuffer.Enqueue(ReSized);
                }
                else
                {
                    _canBeRead = false;
                    break;
                }
            }
            return Task.CompletedTask;
        }
    }
}
