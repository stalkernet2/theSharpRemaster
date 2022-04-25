using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theSharp
{
    public partial class Form1 : Form
    {
        #region Поля

        private string textemp;
        private int swFlag = 0;
        private bool IsVideo = false;

        private Translator Translator = new Translator();
        private Buffer Buff;

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
            Fast = await Task.Run(() => Translator.Translate(target, advGraphicBox));
        }

        private Task StartTranslate(Bitmap target)
        {
            Translator.InitSymbols(BrightnessBar.Value, DetailsBar.Value, DetailsBox.Checked, BaseGraphicBox.Checked, InversionBox.Checked);

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
                    Buff = new Buffer();
                    StartButton.Enabled = false;
                    using (Bitmap onResize = new Bitmap(PathBox.Text))
                    {
                        if (Buff.ImageBuffer == null || PathBox.Text != textemp || onResize.Height * (Convert.ToDouble(SizeBox.Text) / 100) != 1)
                        {
                            Buff.ImageBuffer = Translator.ImgCurse(swFlag, SizeBox.Text, WidthBox.Text, HeightBox.Text, onResize);
                            textemp = PathBox.Text;
                        }
                    }
                    OutPutTimer.Start();
                    await StartTranslate(Buff.ImageBuffer);
                }
                else // Видево
                {
                    Buff = new Buffer(PathBox.Text);

                    IsVideo = true;
                    OutPutTimer.Interval = (int)(1000 / Buff.FrameRate * 0.95);
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
                if (Translator.Width != 0 && Translator.Height != 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Image Files(*.jpg)|*.jpg|Image Files(*.png)|*.png";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        float zc = FontSizeBar.Value;

                        int _Ewidth = Convert.ToInt32(Convert.ToDouble(Translator.Width) * zc); //* 1.018f
                        int _Eheight = Convert.ToInt32(Convert.ToDouble(Translator.Height) * zc);//* 1.052f
                        try
                        {
                            label3.Text = "\nHeight:" + _Eheight + "\nWidth:" + _Ewidth;

                            using (Bitmap saveImage = new Bitmap(_Ewidth, _Eheight * 2))
                            {
                                Graphics image = Graphics.FromImage(saveImage);

                                image.Clear(Color.White);
                                image.DrawString(OutPutBox.Text, new Font("Consolas", 1.35f * zc), new SolidBrush(Color.Black), -6, -2);

                                if (saveFileDialog.FileName != "")
                                {
                                    saveImage.Save(saveFileDialog.FileName, Format.Get(saveFileDialog.FilterIndex));
                                }
                                saveImage.Dispose();
                            }
                        }
                        catch (Exception qe)
                        {
                            if (Translator.Width >= 32768 || Translator.Height >= 32768)
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
                IsVideo = false;
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
            if (IsVideo)
            {
                try
                {
                    Bitmap cursedImage = Translator.ImgCurse(swFlag, SizeBox.Text, WidthBox.Text, HeightBox.Text, Buff.Get());
                    StartTranslate(cursedImage);
                }
                catch
                {
                    OutPutTimer.Stop();
                    IsVideo = false;
                }
            }
            else
            {
                progressBar1.Value = (int)Translator.ProgressValue;
            }
            if (Fast != "")
            {
                OutPutBox.Text = Fast;
                Fast = "";
                label5.Text = Translator.DebugTime(Buff.FrameRate);
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
            swFlag = 1;

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
            swFlag = 2;

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
            if (!IsVideo)
                StartTranslate(Buff.ImageBuffer);
        }

        private void BrightnessBar_Scroll(object sender, EventArgs e)
        {
            if (!IsVideo)
                StartTranslate(Buff.ImageBuffer);
        }

        #endregion
    }
}
