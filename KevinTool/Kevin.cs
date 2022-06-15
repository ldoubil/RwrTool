using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



    }
}
