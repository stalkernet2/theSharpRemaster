using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theSharp
{
    public partial class Form1 : Form
    {
        #region Поля

        private string _textemp;
        private int _swFlag = 0;
        private bool _isVideo = false;

        private Translator _translator = new Translator();
        private Buffer _buff;

        public static string Fast = "";
        #endregion

        public Form1()
        {
            InitializeComponent();
            timer2.Start();
            MinimumSize = new Size(Size.Width, Size.Height);
        }

        private async void AsyncConvert(Bitmap target, bool advGraphicBox)
        {
            Fast = await Task.Run(() => _translator.Translate(target, advGraphicBox));
        }

        private Task StartTranslate(Bitmap target)
        {
            _translator.InitSymbols(BrightnessBar.Value, DetailsBar.Value, DetailsBox.Checked, BaseGraphicBox.Checked, InversionBox.Checked);

            AsyncConvert(target, AdvGraphicBox.Checked);
            return Task.CompletedTask;
        }

        #region Кнопки
        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (PathBox.Text != "")
            {
                if (PathBox.Text.EndsWith(".png") || PathBox.Text.EndsWith(".jpg"))
                {
                    _buff = new Buffer();
                    StartButton.Enabled = false;
                    using (Bitmap onResize = new Bitmap(PathBox.Text))
                    {
                        if (_buff.ImageBuffer == null || PathBox.Text != _textemp || onResize.Height * (Convert.ToDouble(SizeBox.Text) / 100) != 1)
                        {
                            _buff.ImageBuffer = _translator.ImgCurse(_swFlag, SizeBox.Text, WidthBox.Text, HeightBox.Text, onResize);
                            _textemp = PathBox.Text;
                        }
                    }
                    OutPutTimer.Start();
                    await StartTranslate(_buff.ImageBuffer);
                }
                else // Видево
                {
                    _buff = new Buffer(PathBox.Text);

                    _isVideo = true;
                    OutPutTimer.Interval = (int)(1000 / _buff.FrameRate * 0.95);
                    OutPutTimer.Start();
                }
            }
            else
                Debug.MesError("Путь к картинке или к директории не существует");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            OutPutTimer.Stop();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            OutPutTimer.Start();
        }

        private void SaveButton_Click(object sender, EventArgs e) // Кнопка сохранения
        {
            if (OutPutBox.Text != "")
            {
                if (_translator.Width != 0 && _translator.Height != 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    saveFileDialog.Filter = "Image Files(*.jpg)|*.jpg|Image Files(*.png)|*.png";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        float fontSizeFactor = FontSizeBar.Value;

                        int width = Convert.ToInt32(Convert.ToDouble(_translator.Width) * fontSizeFactor); //* 1.018f
                        int height = Convert.ToInt32(Convert.ToDouble(_translator.Height) * fontSizeFactor);//* 1.052f

                        try
                        {
                            label3.Text = "\nHeight:" + height + "\nWidth:" + width;

                            using (Bitmap saveImage = new Bitmap(width, height * 2))
                            {
                                Graphics image = Graphics.FromImage(saveImage);

                                image.Clear(Color.White);
                                image.DrawString(OutPutBox.Text, new Font("Consolas", 1.35f * fontSizeFactor), new SolidBrush(Color.Black), -6, -2);

                                if (saveFileDialog.FileName != "")
                                {
                                    saveImage.Save(saveFileDialog.FileName, Format.Get(saveFileDialog.FilterIndex));
                                }
                                saveImage.Dispose();
                            }
                        }
                        catch (Exception qe)
                        {
                            if (_translator.Width >= 32768 || _translator.Height >= 32768)
                                Debug.MesError("Картинка слишком большая");
                            else
                                Debug.MesError("Что-то сломалось \n" + qe);
                        }
                    }
                }
            }
            else
                Debug.MesError("Нечего сохранять");
        }

        private void LoadButton_Click(object sender, EventArgs e) // Кнопка открытия файла
        {
            if (OutPutTimer.Enabled)
            {
                OutPutTimer.Stop();
                _isVideo = false;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png| Video Files(*.mp4)|*.mp4";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                PathBox.Text = openFileDialog.FileName;
            else
                OutPutTimer.Start();
        }

        #endregion

        #region Таймеры

        private void OutPutTimer_Tick(object sender, EventArgs e) // Обработка и вывод изображения по времени
        {
            if (_isVideo)
            {
                try
                {
                    Bitmap cursedImage = _translator.ImgCurse(_swFlag, SizeBox.Text, WidthBox.Text, HeightBox.Text, _buff.Get());
                    StartTranslate(cursedImage);
                }
                catch
                {
                    OutPutTimer.Stop();
                    _isVideo = false;
                }
            }
            else
            {
                progressBar1.Value = (int)_translator.ProgressValue;
            }
            if (Fast != "")
            {
                OutPutBox.Text = Fast;
                Fast = "";
                label5.Text = _translator.DebugTime(_buff.FrameRate);
                StartButton.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e) // Динамические элементы контроля
        {
            OutPutBox.Height = this.ClientSize.Height - 24;
            OutPutBox.Width = this.ClientSize.Width - (304 + 36);
            OutPutBox.Font = new Font(OutPutBox.Font.Name, float.Parse(Convert.ToString(trackBar3.Value)), OutPutBox.Font.Style);

            groupBox4.Location = new Point(ClientSize.Width - 316, groupBox2.Location.Y);
            groupBox4.Height = ClientSize.Height - 30;
        }

        #endregion

        #region Текстбоксы 
        private void SizeBox_TextChanged(object sender, EventArgs e)
        {
            _swFlag = 1;

            WidthBox.Text = "";
            HeightBox.Text = "";
            if (SizeBox.Text == "0" || SizeBox.Text == "")
                SizeBox.Text = "1";
            else if (Convert.ToInt32(SizeBox.Text) > 100)
                SizeBox.Text = "100";
            SizeBar.Value = Convert.ToInt32(SizeBox.Text) / 5;
        }

        private void WidthHeight_TextChanged(object sender, EventArgs e)
        {
            _swFlag = 2;

            SizeBox.Text = "";
        }

        private void TextCheck(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }

        #endregion

        #region Трекбары

        private void SizeBar_Scroll(object sender, EventArgs e)
        {
            SizeBox.Text = Convert.ToString(SizeBar.Value * 5);
        }


        private void DetailsBar_Scroll(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void BrightnessBar_Scroll(object sender, EventArgs e)
        {
            ChangeImage();
        }
        private void ChangeImage()
        {
            if (!_isVideo && _buff != null)
                StartTranslate(_buff.ImageBuffer);
        }
        #endregion
    }
}
