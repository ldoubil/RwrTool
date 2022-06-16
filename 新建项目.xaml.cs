using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace RwrTool
{
    /// <summary>
    /// 新建项目.xaml 的交互逻辑
    /// </summary>
    public partial class 新建项目 : Window
    {
        public List<String> ml;
        public string xm;

        public KevinTool.Json_Data.AllConfig allconfig;
        public 新建项目()
        {
            InitializeComponent();
            ml = new List<String>();
            xm = null;

            
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

        private void add项目路径_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog l = new System.Windows.Forms.FolderBrowserDialog();

            if (l.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string txtFile = l.SelectedPath;
                Debug.WriteLine(txtFile);
                Label lblFile = new Label();
                项目路径.Text = txtFile;
                xm = txtFile;
                Debug.WriteLine("添加");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存项目配置";
            
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "json文件|*.json";
            saveFileDialog.FileName = 项目名.Text+".json";
            if (!(bool)saveFileDialog.ShowDialog())
            {
                return; //被点了取消
            }
            var filename = saveFileDialog.FileName; //得到保存路径及文件名
            Debug.WriteLine(filename);
            allconfig.name = 项目名.Text;
            allconfig.ml = ml;
            allconfig.xm = xm;
            String json转 = JsonConvert.SerializeObject(allconfig);
            Debug.WriteLine(json转);
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(json转);
           
            sw.Close();
            fs.Close();
            Debug.WriteLine("保存成功！");
            this.Close();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.allconfig = null;
            this.Close();
        }
    }

    
}
