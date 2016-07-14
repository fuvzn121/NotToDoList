using System.Windows;
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
            //ファイル名の取得
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.DefaultExt = "*.*";
            if (ofd.ShowDialog() == true) {
                textBox.Text = ofd.FileName;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e) {
            /// 項目を動的に追加
            listBox.Items.Add(textBox.Text);
            textBox.Text = "";
        }

        private void Del_Click(object sender, RoutedEventArgs e) {
            /// 項目を削除
            // 選択項目がない場合は処理をしない
            if (listBox.SelectedItems.Count == 0)
                return;

            // 選択された項目を削除
            while (listBox.SelectedItems.Count > 0)
                listBox.Items.Remove(
                    listBox.SelectedItems[0]
                );

        }

        private void comboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {

        }
        private void 
    }
}
