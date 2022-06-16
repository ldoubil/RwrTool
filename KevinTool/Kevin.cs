using HelixToolkit.Wpf;
using Newtonsoft.Json;
using RwrTool.KevinTool.Xml_Data_Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;

namespace RwrTool.KevinTool
{
    public class Kevin
    {
        /// <summary>
        /// 获取随机整数
        /// </summary>
        /// <param name="count">你需要几个随机数</param>
        /// <param name="minNum">下限</param>
        /// <param name="maxNum">上限</param>
        /// <returns>返回随机数的数组，长度根据个数而定</returns>
        public static int[] GetRandomArray(int count, int minNum, int maxNum)
        {
            int[] randomArr = new int[count];
            Random r = new Random();
            for (int j = 0; j < count; j++)
            {
                int i = r.Next(minNum, maxNum + 1);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (randomArr[k] == i) num = num + 1;
                }
                if (num == 0)
                    randomArr[j] = i;
                else
                    j = j - 1;
            }
            return randomArr;
        }

        /// <summary>
        /// 获取随机浮点数
        /// </summary>
        /// <param name="minimum">下限</param>
        /// <param name="maximum">上限</param>
        /// <param name="Len">小数点保留位数</param>
        /// <returns>随机的浮点数</returns>
        public static double GetRandomNumber(double minimum, double maximum, int Len)
        {
            Random random = new Random();
            //注意：不用间隔时间，使用for循环获取，返回的几个随机数会一模一样
            System.Threading.Thread.Sleep(1);
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, Len);
        }


        /// <summary>
        /// 给盒子设置坐标以及颜色
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="point3D">坐标</param>
        /// <returns>返回Box</returns>
        public static BoxVisual3D box_run(Color color,Point3D point3D)
        {
            var box = new BoxVisual3D();
            //Color.FromRgb(255, 255, 255)
            Material mat = new DiffuseMaterial(new SolidColorBrush(color));
            box.Material = mat;
            box.Center = point3D;
            return box;
        }
        /// <summary>
        /// 添加模型的接口
        /// </summary>
        /// <param name="helixViewport3D"></param>
        /// <param name="xml_url"></param>
        public static void 模型_ADD(HelixViewport3D helixViewport3D,string xml_url)
        {
            helixViewport3D.Children.Clear();
            XmlDocument xmlDocument = new XmlDocument();
            //根据目录获取内容
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.IgnoreComments = true; //忽略文档注释
            XmlReader xmlReader = XmlReader.Create(xml_url, xmlReaderSettings);
            xmlDocument.Load(xmlReader);

            //获取root节点

            XmlNode xmlNode = xmlDocument.SelectSingleNode("model");

            XmlNode xmlNode1 = xmlNode.SelectSingleNode("voxels");

            XmlNodeList xmlNodeList = xmlNode1.ChildNodes;
            DefaultLights defaultLights = new DefaultLights();

            helixViewport3D.Children.Add(defaultLights);
            //Debug.WriteLine("测试");
            foreach (XmlNode xmlNode2 in xmlNodeList)
            {
                XmlElement xmlElement = (XmlElement)xmlNode2;
                //Debug.WriteLine(xmlElement.GetAttribute("g"));
                int a = Convert.ToInt32(Double.Parse(xmlElement.GetAttribute("a")) * 255);
                int r = Convert.ToInt32(Double.Parse(xmlElement.GetAttribute("r")) * 255);
                int g = Convert.ToInt32(Double.Parse(xmlElement.GetAttribute("g")) * 255);
                int b = Convert.ToInt32(Double.Parse(xmlElement.GetAttribute("b")) * 255);
                helixViewport3D.Children.Add(KevinTool.Kevin.box_run(Color.FromRgb((byte)r, (byte)g, (byte)b), new Point3D(Double.Parse(xmlElement.GetAttribute("x")), Double.Parse(xmlElement.GetAttribute("y")), Double.Parse(xmlElement.GetAttribute("z")))));
            }
        }
        /// <summary>
        ///  解析mxlnode然后返回空值或者获取的字符
        ///  
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Xml_get_att(XmlNode xmlNode,string str)
        {

            try
            {

                return  xmlNode.Attributes[str].Value;
                
            }
           catch
            {
                return null;
            }
                
            
        }


        public static XmlNode xml_get_root(XmlDocument xmlDocument,string str)
        {
            try
            {
               return xmlDocument.SelectSingleNode(str);
            }
            catch
            {
                return null;
            }
        }

        public static Json_Data.AllConfig 读取项目(WrapPanel mainWindow)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Title = "选择项目文件";
            openFileDialog.Filter = "json项目文件|*.json";
            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = "json";
            if (openFileDialog.ShowDialog() == false)
            {
                return null;
            }
            string txtFile = openFileDialog.FileName;
            Debug.Write(txtFile);
            try
            {
                string s_con = string.Empty;
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(txtFile))
                {
                    string line;
                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null)
                    {
                        s_con += line;
                    }
                }
                Debug.WriteLine(s_con);
                KevinTool.Json_Data.AllConfig list = JsonConvert.DeserializeObject<KevinTool.Json_Data.AllConfig>(s_con);
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }



        }

        public static void 读取武器配置XML()
        {
            //var ssss = System.IO.Path.GetExtension(item.FullName);
            //if (ssss == ".weapon")
            //{
            //    Debug.WriteLine(item.FullName);
            //    XmlDocument xmlDoc = new XmlDocument();
            //    XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            //    xmlReaderSettings.IgnoreWhitespace = true;
            //    XmlReader xmlReader = XmlReader.Create(item.FullName, xmlReaderSettings);
            //    xmlDoc.Load(xmlReader);

            //    XmlNode xmlweapon = Kevin.xml_get_root(xmlDoc, "weapon");
            //    XmlNode xmltag = Kevin.xml_get_root(xmlDoc, "weapon/tag");
            //    XmlNode xmlspecification = Kevin.xml_get_root(xmlDoc, "weapon/specification");
            //    XmlNode next_in_chain = Kevin.xml_get_root(xmlDoc, "weapon/next_in_chain");
            //    XmlNode xmleffect = Kevin.xml_get_root(xmlDoc, "weapon/effect");
            //    XmlNode xmlanimation = Kevin.xml_get_root(xmlDoc, "weapon/animation");
            //    XmlNode xmlsound = Kevin.xml_get_root(xmlDoc, "weapon/sound");
            //    XmlNode xmlhud_icon = Kevin.xml_get_root(xmlDoc, "weapon/hud_icon");
            //    XmlNode xmlinventory = Kevin.xml_get_root(xmlDoc, "weapon/inventory");
            //    XmlNode xmlprojectile = Kevin.xml_get_root(xmlDoc, "weapon/projectile");
            //    XmlNode xmlprojectileresult = Kevin.xml_get_root(xmlDoc, "weapon/projectile/result");
            //    XmlNode xmlprojectiletrail = Kevin.xml_get_root(xmlDoc, "weapon/projectile/etrail");
            //    XmlNode xmlstance = Kevin.xml_get_root(xmlDoc, "weapon/stance");
            //    XmlNode xmlmodifier = Kevin.xml_get_root(xmlDoc, "weapon/modifier");
            //    //XmlNodeList xmlNodeList = xmlDoc.ChildNodes;
            //    if (xmlweapon != null)
            //    {
            //        Debug.WriteLine(xmlweapon);
            //        武器模型预览 wqmx = new 武器模型预览();
            //        wqmx.武器参数 = new 武器参数.weapon();
            //        wqmx.武器参数.tag = new 武器参数.weaponTag();
            //        wqmx.武器参数.specification = new 武器参数.weaponSpecification();
            //        wqmx.武器参数.next_in_chain = new 武器参数.weaponnext_in_chain();
            //        wqmx.武器参数.effect = new List<武器参数.weaponEffect>();
            //        Debug.WriteLine(Kevin.Xml_get_att(xmlweapon, "file"));

            //        wqmx.武器参数.file = Kevin.Xml_get_att(xmlweapon, "file");
            //        wqmx.武器参数.key = Kevin.Xml_get_att(xmlweapon, "key");
            //        wqmx.武器参数.quality = Kevin.Xml_get_att(xmlweapon, "quality");

            //        if (xmltag != null)
            //        {
            //            wqmx.武器参数.tag.name = Kevin.Xml_get_att(xmltag, "name");
            //        }
            //        wqmx.武器参数.specification.retrigger_time = Kevin.Xml_get_att(xmlspecification, "retrigger_time");
            //        wqmx.武器参数.specification.accuracy_factor = Kevin.Xml_get_att(xmlspecification, "accuracy_factor");
            //        wqmx.武器参数.specification.spread_range = Kevin.Xml_get_att(xmlspecification, "spread_range");
            //        wqmx.武器参数.specification.sustained_fire_grow_step = Kevin.Xml_get_att(xmlspecification, "sustained_fire_grow_step");
            //        wqmx.武器参数.specification.sustained_fire_diminish_rate = Kevin.Xml_get_att(xmlspecification, "sustained_fire_diminish_rate");
            //        wqmx.武器参数.specification.magazine_size = Kevin.Xml_get_att(xmlspecification, "magazine_size");
            //        wqmx.武器参数.specification.can_shoot_standing = Kevin.Xml_get_att(xmlspecification, "can_shoot_standing");
            //        wqmx.武器参数.specification.suppressed = Kevin.Xml_get_att(xmlspecification, "suppressed");
            //        wqmx.武器参数.specification.name = Kevin.Xml_get_att(xmlspecification, "name");
            //        wqmx.武器参数.specification.Class = Kevin.Xml_get_att(xmlspecification, "class");
            //        wqmx.武器参数.specification.sight_range_modifier = Kevin.Xml_get_att(xmlspecification, "sight_range_modifier");
            //        wqmx.武器参数.specification.projectile_speed = Kevin.Xml_get_att(xmlspecification, "projectile_speed");
            //        wqmx.武器参数.specification.projectiles_per_shot = Kevin.Xml_get_att(xmlspecification, "projectiles_per_shot");
            //        wqmx.武器参数.next_in_chain.key = Kevin.Xml_get_att(next_in_chain, "retrigger_time");
            //        wqmx.武器参数.next_in_chain.share_ammo = Kevin.Xml_get_att(xmlspecification, "retrigger_time");
            //        var ls = new 武器参数.weaponEffect();
            //        ls.@ref = Kevin.Xml_get_att(xmleffect, "ref");
            //        ls.@class = Kevin.Xml_get_att(xmleffect, "class");
            //        wqmx.武器参数.effect.Add(ls);
            //        wqmx.模型ID.Text = wqmx.武器参数.key;
            //        if (wqmx.武器参数.key != null)
            //        {
            //            mainWindow.Children.Add(wqmx);
            //        }




            //    }
            //    else
            //    {
            //        Debug.WriteLine(item.FullName + "为不正常");
            //    }

              
           
        }

    }
}
