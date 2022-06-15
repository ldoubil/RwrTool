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

            
         //   var jo = new JsonObject
         //   {
         //       ["Message"] = "个人信息",
         //       ["Father"] = new JsonObject { ["Name"] = "张三" },
         //       ["Son"] = new JsonArray(
         //new JsonObject
         //{
         //    ["Name"] = "张小小",
         //    ["Pet"] = new JsonArray("小花狗", "小花猫"),
         //    ["Age"] = ""
         //},
         //new JsonObject
         //{
         //    ["Name"] = "张大大",
         //    ["Pet"] = new JsonArray("小狼狗", "小公鸡"),
         //    ["Age"] = 2
         //})
         //   };
         //   var js = jo.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
         //   Debug.WriteLine(js);

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
            System.Windows.Forms.FolderBrowserDialog l = new System.Windows.Forms.FolderBrowserDialog();

            if (l.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string txtFile = l.SelectedPath;
                Debug.WriteLine(txtFile);
                DirectoryInfo root = new DirectoryInfo(txtFile);
                FileInfo[] fileStreams =  root.GetFiles();
                foreach (var item in fileStreams)
                {

                    var ssss = System.IO.Path.GetExtension(item.FullName);
                    if (ssss == ".weapon")
                    {
                        Debug.WriteLine(item.FullName);
                        XmlDocument xmlDoc = new XmlDocument();
                        XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                        xmlReaderSettings.IgnoreWhitespace = true;
                        XmlReader xmlReader = XmlReader.Create(item.FullName, xmlReaderSettings);
                        xmlDoc.Load(xmlReader);

                        XmlNode xmlweapon = Kevin.xml_get_root(xmlDoc,"weapon");
                        XmlNode xmltag = Kevin.xml_get_root(xmlDoc, "weapon/tag");
                        XmlNode xmlspecification = Kevin.xml_get_root(xmlDoc, "weapon/specification");
                        XmlNode next_in_chain = Kevin.xml_get_root(xmlDoc, "weapon/next_in_chain");
                        XmlNode xmleffect = Kevin.xml_get_root(xmlDoc, "weapon/effect");
                        XmlNode xmlanimation = Kevin.xml_get_root(xmlDoc,"weapon/animation");
                        XmlNode xmlsound = Kevin.xml_get_root(xmlDoc,"weapon/sound");
                        XmlNode xmlhud_icon = Kevin.xml_get_root(xmlDoc,"weapon/hud_icon");
                        XmlNode xmlinventory = Kevin.xml_get_root(xmlDoc,"weapon/inventory");
                        XmlNode xmlprojectile = Kevin.xml_get_root(xmlDoc,"weapon/projectile");
                        XmlNode xmlprojectileresult = Kevin.xml_get_root(xmlDoc,"weapon/projectile/result");
                        XmlNode xmlprojectiletrail = Kevin.xml_get_root(xmlDoc,"weapon/projectile/etrail");
                        XmlNode xmlstance = Kevin.xml_get_root(xmlDoc,"weapon/stance");
                        XmlNode xmlmodifier = Kevin.xml_get_root(xmlDoc, "weapon/modifier");
                        //XmlNodeList xmlNodeList = xmlDoc.ChildNodes;
                        if (xmlweapon != null)
                        {
                            Debug.WriteLine(xmlweapon);
                            武器模型预览 wqmx = new 武器模型预览();
                            wqmx.武器参数 = new 武器参数.weapon(); 
                            wqmx.武器参数.tag = new 武器参数.weaponTag();
                            wqmx.武器参数.specification = new 武器参数.weaponSpecification();
                            wqmx.武器参数.next_in_chain = new 武器参数.weaponnext_in_chain();
                            wqmx.武器参数.effect = new List<武器参数.weaponEffect>();
                            Debug.WriteLine(Kevin.Xml_get_att(xmlweapon,"file"));
                        
                            wqmx.武器参数.file = Kevin.Xml_get_att(xmlweapon,"file");
                            wqmx.武器参数.key = Kevin.Xml_get_att(xmlweapon, "key");
                            wqmx.武器参数.quality = Kevin.Xml_get_att(xmlweapon, "quality");

                            if (xmltag!=null)
                            {
                                wqmx.武器参数.tag.name = Kevin.Xml_get_att(xmltag, "name");
                            }
                            wqmx.武器参数.specification.retrigger_time = Kevin.Xml_get_att(xmlspecification, "retrigger_time");
                            wqmx.武器参数.specification.accuracy_factor = Kevin.Xml_get_att(xmlspecification, "accuracy_factor");
                            wqmx.武器参数.specification.spread_range = Kevin.Xml_get_att(xmlspecification, "spread_range");
                            wqmx.武器参数.specification.sustained_fire_grow_step = Kevin.Xml_get_att(xmlspecification, "sustained_fire_grow_step");
                            wqmx.武器参数.specification.sustained_fire_diminish_rate = Kevin.Xml_get_att(xmlspecification, "sustained_fire_diminish_rate");
                            wqmx.武器参数.specification.magazine_size = Kevin.Xml_get_att(xmlspecification, "magazine_size");
                            wqmx.武器参数.specification.can_shoot_standing = Kevin.Xml_get_att(xmlspecification, "can_shoot_standing");
                            wqmx.武器参数.specification.suppressed = Kevin.Xml_get_att(xmlspecification, "suppressed");
                            wqmx.武器参数.specification.name = Kevin.Xml_get_att(xmlspecification, "name");
                            wqmx.武器参数.specification.Class = Kevin.Xml_get_att(xmlspecification, "class");
                            wqmx.武器参数.specification.sight_range_modifier = Kevin.Xml_get_att(xmlspecification, "sight_range_modifier");
                            wqmx.武器参数.specification.projectile_speed = Kevin.Xml_get_att(xmlspecification, "projectile_speed");
                            wqmx.武器参数.specification.projectiles_per_shot = Kevin.Xml_get_att(xmlspecification, "projectiles_per_shot");
                            wqmx.武器参数.next_in_chain.key = Kevin.Xml_get_att(next_in_chain, "retrigger_time");
                            wqmx.武器参数.next_in_chain.share_ammo = Kevin.Xml_get_att(xmlspecification, "retrigger_time");
                            var ls = new 武器参数.weaponEffect();
                            ls.@ref = Kevin.Xml_get_att(xmleffect, "ref");
                            ls.@class = Kevin.Xml_get_att(xmleffect, "class");
                            wqmx.武器参数.effect.Add(ls);
                            wqmx.模型ID.Text = wqmx.武器参数.key;
                            if (wqmx.武器参数.key !=null)
                            {
                                武器列表.Children.Add(wqmx);
                            }
                            
                            


                        }
                        else
                        {
                            Debug.WriteLine(item.FullName + "为不正常");
                        }
                        
                        //XmlElement xmlElement = (XmlElement)xmlNodeList[0];
                        //foreach (XmlNode ds in xmlNodeList)
                        //{

                        //    //XmlElement xmlElement = (XmlElement)ds;
                        //    //var file = xmlElement.GetAttribute("file");
                        //    //Attributes["id"].Value
                           
                        //        Debug.WriteLine(ds.Attributes["file"].Value);
                            

                        //}
                    }
                    
                    
                }
            }
            
        }

        private void 创建项目_Click(object sender, RoutedEventArgs e)
        {
            新建项目 是 = new 新建项目();
            是.ShowDialog();
        }
    }
}
