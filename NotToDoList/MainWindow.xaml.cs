using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NotToDoList {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        private DataTable m_dt;
        
        public MainWindow() {
            InitializeComponent();
            m_dt = new DataTable("TaskData");

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
            newRowItem["Name"] = textBox1.Text;
            newRowItem["Time"] = textBox2.Text + "分";
            newRowItem["Path"] = textBox.Text;
            m_dt.Rows.Add(newRowItem);

            dataGrid.DataContext = m_dt;

            textBox.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        
    }

    
}
