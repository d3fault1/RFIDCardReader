using System;
using System.Windows.Forms;

namespace RFIDReader
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            idListView.AutoGenerateColumns = false;
            AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
            {
                Backend.Dispose();
            };
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Backend.Init();
            idListView.DataSource = Backend.DataModels;
        }

        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            Backend.DeInit();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            Backend.StartReader();
            start_btn.Enabled = false;
            stop_btn.Enabled = true;
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            Backend.StopReader();
            stop_btn.Enabled = false;
            start_btn.Enabled = true;
        }
    }
}
