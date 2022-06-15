using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RwrTool
{
    /// <summary>
    /// 新建项目.xaml 的交互逻辑
    /// </summary>
    public partial class 新建项目 : Window
    {
        public List<String> ml;
        public 新建项目()
        {
            InitializeComponent();
            ml = new List<String>();    
        }
        
        

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            Debug.WriteLine("拖动");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog l = new System.Windows.Forms.FolderBrowserDialog();

            if (l.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string txtFile = l.SelectedPath;
                Debug.WriteLine(txtFile);
                ml.Add(txtFile);
                Label lblFile = new Label();
                lblFile.Content = txtFile;
                url_list.Children.Add(lblFile);
                Debug.WriteLine("添加");
            }
            
        }
    }
}
