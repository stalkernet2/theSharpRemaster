using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GleamTech.VideoUltimate;
using System.Threading.Tasks;

namespace theSharp
{
    class Buffer
    {
        public Bitmap ImageBuffer;
        public double FrameRate;

        private Queue<Bitmap> VideoBuffer = new Queue<Bitmap>();

        private VideoFrameReader reader;
        private bool CanBeRead = false;

        public Buffer() { }

        public Buffer(string file)
        {
            reader = new VideoFrameReader(file);
            FrameRate = reader.FrameRate;

            CanBeRead = true;
        }

        public Bitmap Get()
        {
            if (VideoBuffer.Count < 4 && CanBeRead)
            {
                AsyncUpdate();  
            }
            return VideoBuffer.Dequeue();
        }

        private async void AsyncUpdate()
        {
            await Update();
        }

        private Task Update()
        {
            for (int i = 0; i < 16; i++)
            {
                if(reader.Read())
                {
                    Bitmap target = reader.GetFrame();

                    Bitmap ReSized = new Bitmap(target, new Size((int)(target.Size.Width * 0.4), (int)(target.Size.Height * 0.4)));
                    VideoBuffer.Enqueue(ReSized);
                }
                else
                {
                    CanBeRead = false;
                    break;
                }
            }
            return Task.CompletedTask;
        }
    }
}
