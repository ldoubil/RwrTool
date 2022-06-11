using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwrTool.KevinTool.Xml_Data_Structure
{
    
    public class Weapon
    {
        
        // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        
        public partial class model
        {

            private modelVoxel[]? voxelsField;

            
            private object? skeletonField;

            private object? skeletonVoxelBindingsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("voxel", IsNullable = false)]
            public modelVoxel[] voxels
            {
                get
                {
                    return this.voxelsField;
                }
                set
                {
                    this.voxelsField = value;
                }
            }

            /// <remarks/>
            public object skeleton
            {
                get
                {
                    return this.skeletonField;
                }
                set
                {
                    this.skeletonField = value;
                }
            }

            /// <remarks/>
            public object skeletonVoxelBindings
            {
                get
                {
                    return this.skeletonVoxelBindingsField;
                }
                set
                {
                    this.skeletonVoxelBindingsField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class modelVoxel
        {

            private sbyte xField;

            private sbyte yField;

            private sbyte zField;

            private decimal rField;

            private decimal gField;

            private decimal bField;

            private decimal aField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public sbyte x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public sbyte y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public sbyte z
            {
                get
                {
                    return this.zField;
                }
                set
                {
                    this.zField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal r
            {
                get
                {
                    return this.rField;
                }
                set
                {
                    this.rField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal g
            {
                get
                {
                    return this.gField;
                }
                set
                {
                    this.gField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal b
            {
                get
                {
                    return this.bField;
                }
                set
                {
                    this.bField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal a
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }
        }


    }
}
