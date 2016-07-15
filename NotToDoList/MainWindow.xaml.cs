using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NotToDoList {
    public partial class MainWindow : Window {
        private DataTable m_dt;
        
        public MainWindow() {
            InitializeComponent();
            m_dt = new DataTable("TaskData");

            m_dt.Columns.Add(new DataColumn("State", typeof(string)));
            m_dt.Columns.Add(new DataColumn("Name", typeof(string)));
            m_dt.Columns.Add(new DataColumn("Time", typeof(string)));
            m_dt.Columns.Add(new DataColumn("Path", typeof(string)));
        }
        private void Show_Click(object sender, RoutedEventArgs e) {
            //ファイル名の取得
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.DefaultExt = "*.*";
            if (ofd.ShowDialog() == true) {
                textBox.Text = ofd.FileName;
            }
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e) {

            DataRow newRowItem;
            newRowItem = m_dt.NewRow();
            newRowItem["State"] = "未起動";
            newRowItem["Name"] = textBox1.Text;
            newRowItem["Time"] = textBox2.Text + "分";
            newRowItem["Process"] = textBox.Text;

            m_dt.Rows.Add(newRowItem);

            dataGrid.DataContext = m_dt;
            dataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;

            textBox.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void OnDelButtonClick(object sender, RoutedEventArgs e) {
            m_dt.Rows[dataGrid.SelectedIndex].Delete();
        }

        


        private void ShowProcess(object sender, RoutedEventArgs e) {
            Process[] hProcesses = Process.GetProcesses();
            
            string stPrompt = string.Empty;

            // 取得できたプロセスからプロセス名を取得する
            foreach (Process hProcess in hProcesses) {
                listBox.Items.Add(hProcess.ProcessName);
                
            }
        }

        private void processAdd(object sender, RoutedEventArgs e) {
            ListBoxItem lbi = (ListBoxItem)listBox.SelectedItem;
            textBox3.Text = lbi.Content.ToString();
        }

        
    }



    
}
