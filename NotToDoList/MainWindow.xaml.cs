using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace NotToDoList {
    public partial class MainWindow : Window {
        private DataTable m_dt;
        
        public MainWindow() {
            InitializeComponent();
            m_dt = new DataTable("TaskData");

            m_dt.Columns.Add(new DataColumn("State", typeof(string)));
            m_dt.Columns.Add(new DataColumn("Name", typeof(string)));
            m_dt.Columns.Add(new DataColumn("Time", typeof(double)));
            m_dt.Columns.Add(new DataColumn("Process", typeof(string)));
        }
        /*
        private void Show_Click(object sender, RoutedEventArgs e) {
            //ファイル名の取得
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.DefaultExt = "*.*";
            if (ofd.ShowDialog() == true) {
               // textBox.Text = ofd.FileName;
            }
        }
        */

        private void OnAddButtonClick(object sender, RoutedEventArgs e) {

            DataRow newRowItem;
            newRowItem = m_dt.NewRow();
 
            newRowItem["State"] = "";
            newRowItem["Name"] = textBox1.Text;
            newRowItem["Time"] = textBox2.Text;
            newRowItem["Process"] = textBox3.Text;

            m_dt.Rows.Add(newRowItem);

            dataGrid.DataContext = m_dt;
            dataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;            
        }

        private void OnDelButtonClick(object sender, RoutedEventArgs e) {
            m_dt.Rows[dataGrid.SelectedIndex].Delete();
        }

        


        private void ShowProcess(object sender, RoutedEventArgs e) {
            Process[] hProcesses = Process.GetProcesses();
            
            // 取得できたプロセスからプロセス名を取得する
            foreach (Process hProcess in hProcesses) {
                listBox.Items.Add(hProcess.ProcessName);
                
            }
        }

        
        private void processGet(object sender, RoutedEventArgs e) {
            ListBoxItem lbi = (ListBoxItem)listBox.SelectedItem;
            textBox3.Text = lbi.Content.ToString();
        }

        private void taskKill(object sender, RoutedEventArgs e) {
            int num = int.Parse(textBox2.Text);
            Stopwatch sw = new Stopwatch();

            MessageBox.Show("計測を開始します。");
            sw.Start();
            Thread.Sleep(num * 1000);  
            sw.Stop();
            MessageBox.Show("規定時間に達したためアプリケーションを終了します");
            while (true) {
                bool flg = false;
                Process[] processList = Process.GetProcesses();
                foreach (Process p in processList) {
                    if (p.ProcessName == textBox3.Text) {
                        flg = true;
                        if (p.Responding) {
                            p.CloseMainWindow();
                        }
                    }
                }
                break;
            }

        }

        
    }



    
}
