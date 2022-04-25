using System.Windows.Forms;

namespace theSharp
{
    class Debug
    {
        public static void MesError(string Mess)
        {
            MessageBox.Show(Mess, "TwT",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
