using System.Drawing.Imaging;

namespace theSharp
{
    class Format
    {
        public static ImageFormat Get(int index)
        {
            switch (index)
            {
                case 0:
                    return ImageFormat.Jpeg;
                case 1:
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Png;
            }
        }
    }
}
