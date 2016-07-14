using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;

namespace NotToDoList {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        // データテーブル
        private DataTable m_dt;

        public MainWindow() {
            InitializeComponent();
            
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
      
       

        

        private void comboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {

        }
        
    }
}
