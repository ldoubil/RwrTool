using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Windows.Threading;
using System.IO;
using RwrTool.KevinTool.Xml_Data_Structure;
using RwrTool.KevinTool;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace RwrTool
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer m_Timer1s = null; //定义1S计时器
        TimeSpan _timeSpan = new TimeSpan(0, 0, 0, 0, 0);
        KevinTool.Json_Data.AllConfig allconfig = new();
        /// <summary>
        /// 状态
        /// </summary>
        State _state = State.End;
        enum State
        {
            Start,
            Pause,
            End
        }
        /// <summary>
        /// 状态
        /// </summary>


        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void AppRun(object sender, EventArgs e)
        {
            



            

            //创建一个定时
        }

        private void win_loaded(object sender, RoutedEventArgs e)
        {

        

        }

        

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("鼠标左键");
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("鼠标左键");
            //执行移动
            this.DragMove();
        }





        private void exitapp(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("软件退出");
            this.Close();
        }

        private void BtnWindowMax_Click(object sender, RoutedEventArgs e)
        {
            //判断是否以及最大化，最大化就还原窗口，否则最大化
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;

        }

        private void ColorZone_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Title = "选择RWR模型文件";
            openFileDialog.Filter = "RWR武器模型文件|*.xml";
            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = "xml";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            string txtFile = openFileDialog.FileName;
            Debug.Write(txtFile);



            //主页面准备完成开始执行
            //导入xml
            string xml_url = txtFile;
           KevinTool.Kevin.模型_ADD(vi3d,xml_url);

           

        }
        public void 按钮测试(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("按钮测试");
            var ss = sender as Button;

            var SSD = ss.DataContext as 武器模型预览;
            //Debug.WriteLine(SSD.ID+SSD.img);
            //KevinTool.Kevin.模型_ADD(vi3d, @"D:\steam\steamapps\workshop\content\270150\2513537759\media\packages\GFLNP\models\" + SSD.MXurl);
            tablist.SelectedIndex = 1;
        }
        private void 打开项目_Click(object sender, RoutedEventArgs e)
        {
            allconfig =  Kevin.读取项目(武器列表);
            Debug.WriteLine("");
            初始化项目();

        }

        private void 初始化项目()
        {
            //进入武器目录读取武器
            
            DirectoryInfo directoryInfo = new DirectoryInfo(allconfig.xm + "/weapons");
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (var item in fileInfos)
            {
                if (Path.GetExtension(item.FullName) == ".weapon")
                {
                    Debug.WriteLine(item.FullName);
                }
                
            }

        }

        private void 创建项目_Click(object sender, RoutedEventArgs e)
        {
            新建项目 s = new 新建项目();
            s.ShowDialog();
            if(s.allconfig != null)
            {
                Debug.WriteLine(s.allconfig);
                allconfig = s.allconfig;
            }
        }


        
    }
}
