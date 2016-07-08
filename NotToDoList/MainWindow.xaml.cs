using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace NotToDoList {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void Show_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.DefaultExt = "*.*";
            if (ofd.ShowDialog() == true) {
                textBox.Text = ofd.FileName;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e) {
            /// 項目を動的に追加する
            listBox.Items.Add(textBox.Text);
        }

        private void Del_Click(object sender, RoutedEventArgs e) {
            /// 項目を削除します
            // 選択項目がない場合は処理をしない
            if (listBox.SelectedItems.Count == 0)
                return;

            // 選択された項目を削除
            listBox.Items.RemoveAt(listBox.SelectedIndex);

        }
    }
}
