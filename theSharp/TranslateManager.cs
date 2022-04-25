using System;
using System.Text;
using System.Drawing;

namespace theSharp
{
    class Translator
    {
        public int Width = 0;
        public int Height = 0;
        public double ProgressValue { get; private set; }

        private int OldWidth, OldHeight;

        private int CenterPos; // mul
        private int GreaterCenterPos; // mulP
        private int SmallerCenterPos; // mulM
        private int AdvGreaterCenterPos; // mulPA
        private int AdvSmallerCenterPos; //mulMA

        private int DetailsValue; // val

        private char[] Alphabet;

        private DateTime Time;

        private bool BaseGraphic;
        private bool Details;

        public void InitSymbols(int brightnessBar, int detailsBar, bool detailsBox, bool baseGraphicBox, bool inversionBox)
        {
            Alphabet = new char[5] { '#', ' ', '.', ' ', ' ' }; // reset

            BaseGraphic = baseGraphicBox;
            Details = detailsBox;

            CenterPos = 25 * brightnessBar;
            DetailsValue = 6;

            if (detailsBox)
                DetailsValue = detailsBar;

            GreaterCenterPos = CenterPos + CenterPos / DetailsValue;
            SmallerCenterPos = CenterPos - CenterPos / DetailsValue;

            AdvGreaterCenterPos = GreaterCenterPos - (GreaterCenterPos - SmallerCenterPos) / 3;
            AdvSmallerCenterPos = SmallerCenterPos + (GreaterCenterPos - SmallerCenterPos) / 3;

            GreaterCenterPos *= 3;
            SmallerCenterPos *= 3;
            AdvGreaterCenterPos *= 3;
            AdvSmallerCenterPos *= 3;

            if (baseGraphicBox)
            {
                Alphabet = new char[5] { '\u2588', '▓', '▒', '░', ' ' };
            }

            if (!detailsBox)
            {
                Alphabet[Alphabet.Length / 2] = ' ';
                GreaterCenterPos = CenterPos;
            }

            if (inversionBox)
            {
                Array.Reverse(Alphabet);
            }
        }

        public string Translate(Bitmap target, bool advGraphicBox) // Обработка картинки
        {
            try
            {
                Time = DateTime.Now;
                StringBuilder buildfast = new StringBuilder();

                Width = target.Width;
                Height = target.Height;

                for (int y = 0; y < Height; y++) // Вычислительный блок
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Color col = target.GetPixel(x, y);
                        int rgb = col.R + col.G + col.B;

                        char temp;

                        if (rgb >= GreaterCenterPos)
                            temp = Alphabet[4];
                        else if (rgb > SmallerCenterPos && rgb < GreaterCenterPos) // Сглаживание
                        {
                            if (advGraphicBox && Details && BaseGraphic) // Улучшенное сглаживание
                            {
                                if (rgb > SmallerCenterPos && rgb < AdvSmallerCenterPos)
                                    temp = Alphabet[1];
                                else if (rgb > AdvSmallerCenterPos && rgb < AdvGreaterCenterPos)
                                    temp = Alphabet[2];
                                else
                                    temp = Alphabet[3];
                            }
                            else // Обычное сглаживание
                                temp = Alphabet[2];
                        }
                        else
                            temp = Alphabet[0];

                        buildfast.Append(temp);
                    }
                    buildfast.AppendLine();

                    ProgressValue = (float)y / (float)Height * 100;
                }

                ProgressValue = 0;
                return buildfast.ToString();
            }
            catch 
            {
                return "Сломался, слишком быстро дергал ползунки";
            }
        }

        /// <summary>
        /// Определяет размеры изображения, где <paramref name="swFlag"></paramref> определяет метод изменения, 
        /// <paramref name="Textbox"></paramref> множитель размеров,
        /// <paramref name="Textbox2"></paramref> и <paramref name="Textbox3"></paramref> являются значениями X и Y соотвественно.
        /// <paramref name="onResize"></paramref> - изображение над которым происходит манипуляция.
        /// </summary>
        /// <returns>Возвращает изображение с измененными размерами</returns>
        public Bitmap ImgCurse(int swFlag, string Textbox, string Textbox2, string Textbox3, Bitmap onResize)
        {

            int Width;
            int Height;
            switch (swFlag) 
            {
                case 1:
                    if (Textbox != "")
                    {
                        Width = Convert.ToInt32(onResize.Width * (Convert.ToDouble(Textbox) / 100));
                        Height = Convert.ToInt32(onResize.Height * (Convert.ToDouble(Textbox) / 100));
                    }
                    else
                    {
                        Width = OldWidth;
                        Height = OldHeight;
                    }
                    break;
                case 2:
                    if (Textbox2 != "" && Textbox3 != "")
                    {
                        Width = Convert.ToInt32(Textbox2);
                        Height = Convert.ToInt32(Textbox3);
                    }
                    else
                    {
                        Width = OldWidth;
                        Height = OldHeight;
                    }
                    break;
                default:
                    Width = onResize.Width;
                    Height = onResize.Height;
                    break;
            }
            OldHeight = Height;
            OldWidth = Width;

            return new Bitmap(onResize, (int)((float)(Width) * 2.0675f), Height); //2.0675f
        }
        /// <summary>
        /// Примимает <paramref name="tik"></paramref> кадров и возвращает затраченое время для 1 кадра и для <paramref name="tik"></paramref> кадров, а также размеры изображения
        /// </summary>
        /// 
        /// <returns>Возвращает затраченное время и размеры</returns>
        /// 
        public string DebugTime(double tik)
        {
            return Convert.ToString(DateTime.Now - Time) + "\n" + "Вывод " + tik + " кадров: "
                        + Convert.ToDouble((DateTime.Now - Time).TotalMilliseconds) * tik / 1000 + "\nNativeSize:"
                        + OldHeight + "x" + OldWidth;
        }
    }
}
