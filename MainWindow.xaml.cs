using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Timers;
using System.Windows.Threading;



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
            //主页面准备完成开始执行
            //导入xml
            string xml_url = "C:\\Users\\baika\\Desktop\\rwrmod\\mod\\happy_server_extend\\models\\hp_ak105.xml";
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
            Debug.WriteLine("测试");
            foreach (XmlNode xmlNode2 in xmlNodeList)
            {
                XmlElement xmlElement = (XmlElement)xmlNode2;
                Debug.WriteLine(xmlElement.GetAttribute("x"));

            }





            //底面三角网格
            MeshGeometry3D bottom_mesh = new MeshGeometry3D() { Positions = new Point3DCollection(), TriangleIndices = new Int32Collection() };
            //顶面三角网格
            MeshGeometry3D top_mesh = new MeshGeometry3D() { Positions = new Point3DCollection(), TriangleIndices = new Int32Collection() };
            //侧面三角网格
            MeshGeometry3D side_mesh = new MeshGeometry3D() { Positions = new Point3DCollection(), TriangleIndices = new Int32Collection() };

            Point3D bottom_center = new Point3D(0, 0, 0);//底面中心
            Point3D top_center = new Point3D(0, 2, 0);//顶面中心
            top_mesh.Positions.Add(top_center);
            bottom_mesh.Positions.Add(bottom_center);

            int parts = 50;//把圆切成50份
            double angle = Math.PI * 2 / parts;
            for (int i = 0; i < parts; i++)
            {
                double x1 = 1 * Math.Cos(angle * i);
                double z1 = 1 * Math.Sin(angle * i);
                double x2 = 1 * Math.Cos(angle * (i + 1));
                double z2 = 1 * Math.Sin(angle * (i + 1));

                Point3D bottom1 = new Point3D(x1, 0, z1);//底面
                Point3D bottom2 = new Point3D(x2, 0, z2);
                Point3D top1 = new Point3D(x1, 2, z1);
                Point3D top2 = new Point3D(x2, 2, z2);

                //底面
                bottom_mesh.Positions.Add(bottom1);
                bottom_mesh.Positions.Add(bottom2);

                bottom_mesh.TriangleIndices.Add(i * 2 + 1);
                bottom_mesh.TriangleIndices.Add(i * 2 + 2);
                bottom_mesh.TriangleIndices.Add(0);

                //顶面
                top_mesh.Positions.Add(top1);
                top_mesh.Positions.Add(top2);

                top_mesh.TriangleIndices.Add(i * 2 + 2);
                top_mesh.TriangleIndices.Add(i * 2 + 1);
                top_mesh.TriangleIndices.Add(0);

                //侧面
                if (i == 0)
                {
                    side_mesh.Positions.Add(bottom1);
                    side_mesh.Positions.Add(top1);
                }
                side_mesh.Positions.Add(bottom2);
                side_mesh.Positions.Add(top2);

                side_mesh.TriangleIndices.Add(i * 2 + 1);
                side_mesh.TriangleIndices.Add(i * 2 + 3);
                side_mesh.TriangleIndices.Add(i * 2 + 2);

                side_mesh.TriangleIndices.Add(i * 2 + 1);
                side_mesh.TriangleIndices.Add(i * 2 + 2);
                side_mesh.TriangleIndices.Add(i * 2 + 0);
            }

            DiffuseMaterial bottom_material = new DiffuseMaterial(Brushes.Aqua);//底面绿色
            DiffuseMaterial top_material = new DiffuseMaterial(Brushes.Red);//顶面蓝色
            DiffuseMaterial side_material = new DiffuseMaterial(Brushes.Cyan);//侧面红色

            GeometryModel3D top = new GeometryModel3D(top_mesh, top_material);
            GeometryModel3D bottom = new GeometryModel3D(bottom_mesh, bottom_material);
            GeometryModel3D side = new GeometryModel3D(side_mesh, side_material);
            //相机
            Camera camera = new PerspectiveCamera(new Point3D(3, 6, 10), new Vector3D(-3, -6, -10), new Vector3D(0, 1, 0), 45);
            //光源
            Light light = new AmbientLight(Colors.White);

            Model3DGroup group = new Model3DGroup();
            group.Children.Add(light);
            group.Children.Add(top);
            group.Children.Add(bottom);
            group.Children.Add(side);

            RotateTransform3D rotateTransform3D = new RotateTransform3D( );
            AxisAngleRotation3D axisAngleRotation3D = new AxisAngleRotation3D(new Vector3D(0,1,2),20);
            rotateTransform3D.Rotation = axisAngleRotation3D;
            ModelVisual3D model = new ModelVisual3D();
            model.Content = group;
            model.Transform = rotateTransform3D;
            
            view3d.Children.Add(model);
            
            view3d.Camera = camera;
            

            //创建一个定时
        }

        private void win_loaded(object sender, RoutedEventArgs e)
        {
            m_Timer1s = new DispatcherTimer();
            m_Timer1s.Interval = new TimeSpan(0, 0, 0, 0,1);
            m_Timer1s.Tick += Timer1s_Tick;
            m_Timer1s.IsEnabled = true;
            //m_Timer1s.Stop();
            m_Timer1s.Start();
        }
        int a = 0;
        private void Timer1s_Tick(object sender, EventArgs e)//计时执行的程序
        {
            switch (_state)
            {
                case State.Start: //开始
                    {
                        _timeSpan += new TimeSpan(0, 0, 0, 0,1);
                    }
                    break;
                case State.Pause: //暂停
                    {

                    }
                    break;
                case State.End: //结束
                    {
                        _timeSpan = new TimeSpan(); //结束完就归零，重新开始
                        //_timeSpan = new TimeSpan(0, 23, 12, 45, 54);
                    }
                    break;
            }
            var time = string.Format("{0:00}:{1:00}:{2:00}", _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds);
            Debug.WriteLine(time);
            a++;
            Camera camera = new PerspectiveCamera(new Point3D(3, 6, 10), new Vector3D(-3, -6, -10), new Vector3D(0, 1, 0), 45);
            //view3d.Camera = camera;
            foreach (var item in view3d.Children)
            {
                RotateTransform3D rotateTransform3D = new RotateTransform3D();
                AxisAngleRotation3D axisAngleRotation3D = new AxisAngleRotation3D(new Vector3D(KevinTool.Kevin.GetRandomNumber(0, 5, 1), KevinTool.Kevin.GetRandomNumber(0, 5, 1), KevinTool.Kevin.GetRandomNumber(0, 5, 1)), 20);
                rotateTransform3D.Rotation = axisAngleRotation3D;
                item.Transform = rotateTransform3D;
            }
            Debug.WriteLine(view3d.Children);
        }

        private void view3d_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            foreach (var item in view3d.Children)
            {
                RotateTransform3D rotateTransform3D = new RotateTransform3D();
                AxisAngleRotation3D axisAngleRotation3D = new AxisAngleRotation3D(new Vector3D(KevinTool.Kevin.GetRandomNumber(0,5,1), KevinTool.Kevin.GetRandomNumber(0, 5, 1), KevinTool.Kevin.GetRandomNumber(0, 5, 1)), 20);
                rotateTransform3D.Rotation = axisAngleRotation3D;
                Debug.WriteLine(item.Transform = rotateTransform3D);
            }
        }
    }
}
