using System;
using System.Drawing;
using System.Text;

namespace theSharp
{
    class Translator
    {
        public int Width = 0;
        public int Height = 0;
        public double ProgressValue { get; private set; }

        private Size _oldSize;

        private int _centerPos; // mul
        private int _greaterCenterPos; // mulP
        private int _smallerCenterPos; // mulM
        private int _advGreaterCenterPos; // mulPA
        private int _advSmallerCenterPos; //mulMA

        private int _detailsValue; // val

        private char[] _alphabet;

        private DateTime _time;

        private bool _baseGraphic;
        private bool _details;

        public void InitSymbols(int brightnessBar, int detailsBar, bool detailsBox, bool baseGraphicBox, bool inversionBox)
        {
            _alphabet = new char[5] { '#', ' ', '.', ' ', ' ' }; // reset

            _baseGraphic = baseGraphicBox;
            _details = detailsBox;

            _centerPos = 25 * brightnessBar;
            _detailsValue = 6;

            if (detailsBox)
                _detailsValue = detailsBar;

            _greaterCenterPos = _centerPos + _centerPos / _detailsValue;
            _smallerCenterPos = _centerPos - _centerPos / _detailsValue;

            _advGreaterCenterPos = _greaterCenterPos - (_greaterCenterPos - _smallerCenterPos) / 3;
            _advSmallerCenterPos = _smallerCenterPos + (_greaterCenterPos - _smallerCenterPos) / 3;

            _greaterCenterPos *= 3;
            _smallerCenterPos *= 3;
            _advGreaterCenterPos *= 3;
            _advSmallerCenterPos *= 3;

            if (baseGraphicBox)
            {
                _alphabet = new char[5] { '\u2588', '▓', '▒', '░', ' ' };
            }

            if (!detailsBox)
            {
                _alphabet[_alphabet.Length / 2] = ' ';
                _greaterCenterPos = _centerPos;
            }

            if (inversionBox)
            {
                Array.Reverse(_alphabet);
            }
        }

        public string Translate(Bitmap target, bool advGraphicBox) // Обработка картинки
        {
            try
            {
                _time = DateTime.Now;
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

                        if (rgb >= _greaterCenterPos)
                            temp = _alphabet[4];
                        else if (rgb > _smallerCenterPos && rgb < _greaterCenterPos) // Сглаживание
                        {
                            if (advGraphicBox && _details && _baseGraphic) // Улучшенное сглаживание
                            {
                                if (rgb > _smallerCenterPos && rgb < _advSmallerCenterPos)
                                    temp = _alphabet[1];
                                else if (rgb > _advSmallerCenterPos && rgb < _advGreaterCenterPos)
                                    temp = _alphabet[2];
                                else
                                    temp = _alphabet[3];
                            }
                            else // Обычное сглаживание
                                temp = _alphabet[2];
                        }
                        else
                            temp = _alphabet[0];

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
                        Width = _oldSize.Width;
                        Height = _oldSize.Height;
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
                        Width = _oldSize.Width;
                        Height = _oldSize.Height;
                    }
                    break;
                default:
                    Width = onResize.Width;
                    Height = onResize.Height;
                    break;
            }
            _oldSize.Height = Height;
            _oldSize.Width = Width;

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
            return Convert.ToString(DateTime.Now - _time) + "\n" + "Вывод " + tik + " кадров: "
                        + Convert.ToDouble((DateTime.Now - _time).TotalMilliseconds) * tik / 1000 + "\nNativeSize:"
                        + _oldSize.Height + "x" + _oldSize.Width;
        }
    }
}
