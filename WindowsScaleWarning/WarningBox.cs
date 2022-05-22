using System.Diagnostics;

namespace WSW
{
    public partial class WarningBox : Form
    {
        private Process process;
        private ProcessWatch watch;

        public WarningBox(Process process, ProcessWatch watch)
        {
            InitializeComponent();
            this.process = process;
            this.watch = watch;

            if (watch.Message == null)
            {
                message.Text = message.Text.Replace("{name}", watch.Name);
            }
            else
            {
                message.Text = watch.Message;
            }

            if (watch.AutoKill)
            {
                btnKill.Visible = false;
                btnIgnore.Text = "OK";
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            this.process.Kill();
            Close();
        }
        private void btnIgnore_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Shows the warning.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="watch"></param>
        public static void Show(Process process, ProcessWatch watch)
        {
            new WarningBox(process, watch).ShowDialog();
        }
    }
}
