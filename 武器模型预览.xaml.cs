using RwrTool.KevinTool.Xml_Data_Structure;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace RwrTool
{
    /// <summary>
    /// 武器模型预览.xaml 的交互逻辑
    /// </summary>
    public partial class 武器模型预览 : UserControl
    {

        public 武器模型预览()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public 武器参数.weapon 武器参数 { get; set; }

        
    }
}
