using System;
using System.Collections.Generic;

namespace RwrTool.KevinTool.Xml_Data_Structure
{
    public class 武器参数
    {
        



        
        // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class weapon
        {

            private weaponTag tagField;

            private weaponSpecification specificationField;

            private weaponnext_in_chain next_In_Chain;

            private List<weaponEffect> effectField;

            private weaponAnimation[] animationField;

            private weaponSound[] soundField;

            private weaponModel modelField;

            private weaponHud_icon hud_iconField;

            private weaponInventory inventoryField;

            private weaponProjectile projectileField;

            private weaponStance[] stanceField;

            private weaponModifier modifierField;

            private string fileField;

            private string qualityField;

            private string on_ground_upField;

            private string keyField;
            public weaponnext_in_chain next_in_chain
            {
                get
                {
                    return this.next_In_Chain;
                }
                set
                {
                    this.next_In_Chain = value;
                }
            }

            /// <remarks/>
            public weaponTag tag
            {
                get
                {
                    return this.tagField;
                }
                set
                {
                    this.tagField = value;
                }
            }

            /// <remarks/>
            public weaponSpecification specification
            {
                get
                {
                    return this.specificationField;
                }
                set
                {
                    this.specificationField = value;
                }
            }

            /// <remarks/>
            public List<weaponEffect> effect
            {
                get
                {
                    return this.effectField;
                }
                set
                {
                    this.effectField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("animation")]
            public weaponAnimation[] animation
            {
                get
                {
                    return this.animationField;
                }
                set
                {
                    this.animationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("sound")]
            public weaponSound[] sound
            {
                get
                {
                    return this.soundField;
                }
                set
                {
                    this.soundField = value;
                }
            }

            /// <remarks/>
            public weaponModel model
            {
                get
                {
                    return this.modelField;
                }
                set
                {
                    this.modelField = value;
                }
            }

            /// <remarks/>
            public weaponHud_icon hud_icon
            {
                get
                {
                    return this.hud_iconField;
                }
                set
                {
                    this.hud_iconField = value;
                }
            }

            /// <remarks/>
            public weaponInventory inventory
            {
                get
                {
                    return this.inventoryField;
                }
                set
                {
                    this.inventoryField = value;
                }
            }

            /// <remarks/>
            public weaponProjectile projectile
            {
                get
                {
                    return this.projectileField;
                }
                set
                {
                    this.projectileField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("stance")]
            public weaponStance[] stance
            {
                get
                {
                    return this.stanceField;
                }
                set
                {
                    this.stanceField = value;
                }
            }

            /// <remarks/>
            public weaponModifier modifier
            {
                get
                {
                    return this.modifierField;
                }
                set
                {
                    this.modifierField = value;
                }
            }

            /// <summary>
            /// 父类可以继承一些内容
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string file
            {
                get
                {
                    return this.fileField;
                }
                set
                {
                    this.fileField = value;
                }
            }

            /// <summary>
            /// 似乎是品质
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string quality
            {
                get
                {
                    return this.qualityField;
                }
                set
                {
                    this.qualityField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string on_ground_up
            {
                get
                {
                    return this.on_ground_upField;
                }
                set
                {
                    this.on_ground_upField = value;
                }
            }

            /// <summary>
            /// 武器注册key
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

           
        }
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponnext_in_chain
        {
            public string key { get; set; }
            public string share_ammo { get; set; }


        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponTag
        {

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

        public partial class weaponSpecification
        {

            private string retrigger_timeField;

            private string accuracy_factorField;

            private string sustained_fire_grow_stepField;

            private string sustained_fire_diminish_rateField;

            private string magazine_sizeField;

            private string can_shoot_standingField;

            private string suppressedField;

            private string nameField;

            private string classField;

            private string projectile_speedField;

            private string sight_range_modifierField;

            private string barrel_offsetField;

            private string slotField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string retrigger_time
            {
                get
                {
                    return this.retrigger_timeField;
                }
                set
                {
                    this.retrigger_timeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string accuracy_factor
            {
                get
                {
                    return this.accuracy_factorField;
                }
                set
                {
                    this.accuracy_factorField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sustained_fire_grow_step
            {
                get
                {
                    return this.sustained_fire_grow_stepField;
                }
                set
                {
                    this.sustained_fire_grow_stepField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sustained_fire_diminish_rate
            {
                get
                {
                    return this.sustained_fire_diminish_rateField;
                }
                set
                {
                    this.sustained_fire_diminish_rateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string magazine_size
            {
                get
                {
                    return this.magazine_sizeField;
                }
                set
                {
                    this.magazine_sizeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string can_shoot_standing
            {
                get
                {
                    return this.can_shoot_standingField;
                }
                set
                {
                    this.can_shoot_standingField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string suppressed
            {
                get
                {
                    return this.suppressedField;
                }
                set
                {
                    this.suppressedField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Class
            {
                get
                {
                    return this.classField;
                }
                set
                {
                    this.classField = value;
                }
            }

         

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string projectile_speed
            {
                get
                {
                    return this.projectile_speedField;
                }
                set
                {
                    this.projectile_speedField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string sight_range_modifier
            {
                get
                {
                    return this.sight_range_modifierField;
                }
                set
                {
                    this.sight_range_modifierField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string barrel_offset
            {
                get
                {
                    return this.barrel_offsetField;
                }
                set
                {
                    this.barrel_offsetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string slot
            {
                get
                {
                    return this.slotField;
                }
                set
                {
                    this.slotField = value;
                }
            }

            public string spread_range { get; internal set; }
            public string projectiles_per_shot { get; internal set; }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponEffect
        {

            private string classField;

            private string refField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string @class
            {
                get
                {
                    return this.classField;
                }
                set
                {
                    this.classField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string @ref
            {
                get
                {
                    return this.refField;
                }
                set
                {
                    this.refField = value;
                }
            }

            public static implicit operator List<object>(weaponEffect v)
            {
                throw new NotImplementedException();
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponAnimation
        {

            private string keyField;

            private string refField;

            private bool refFieldSpecified;

            private string state_keyField;

            private string animation_keyField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string @ref
            {
                get
                {
                    return this.refField;
                }
                set
                {
                    this.refField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool refSpecified
            {
                get
                {
                    return this.refFieldSpecified;
                }
                set
                {
                    this.refFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string state_key
            {
                get
                {
                    return this.state_keyField;
                }
                set
                {
                    this.state_keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string animation_key
            {
                get
                {
                    return this.animation_keyField;
                }
                set
                {
                    this.animation_keyField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponSound
        {

            private string keyField;

            private string filerefField;

            private string pitch_varietyField;

            private bool pitch_varietyFieldSpecified;

            private string volumeField;

            private bool volumeFieldSpecified;

            private string classField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string fileref
            {
                get
                {
                    return this.filerefField;
                }
                set
                {
                    this.filerefField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string pitch_variety
            {
                get
                {
                    return this.pitch_varietyField;
                }
                set
                {
                    this.pitch_varietyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool pitch_varietySpecified
            {
                get
                {
                    return this.pitch_varietyFieldSpecified;
                }
                set
                {
                    this.pitch_varietyFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string volume
            {
                get
                {
                    return this.volumeField;
                }
                set
                {
                    this.volumeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool volumeSpecified
            {
                get
                {
                    return this.volumeFieldSpecified;
                }
                set
                {
                    this.volumeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string @class
            {
                get
                {
                    return this.classField;
                }
                set
                {
                    this.classField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponModel
        {

            private string filenameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string filename
            {
                get
                {
                    return this.filenameField;
                }
                set
                {
                    this.filenameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponHud_icon
        {

            private string filenameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string filename
            {
                get
                {
                    return this.filenameField;
                }
                set
                {
                    this.filenameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponInventory
        {

            private string encumbranceField;

            private string priceField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string encumbrance
            {
                get
                {
                    return this.encumbranceField;
                }
                set
                {
                    this.encumbranceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string price
            {
                get
                {
                    return this.priceField;
                }
                set
                {
                    this.priceField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponProjectile
        {

            private weaponProjectileResult resultField;

            private weaponProjectileTrail trailField;

            private string fileField;

            /// <remarks/>
            public weaponProjectileResult result
            {
                get
                {
                    return this.resultField;
                }
                set
                {
                    this.resultField = value;
                }
            }

            /// <remarks/>
            public weaponProjectileTrail trail
            {
                get
                {
                    return this.trailField;
                }
                set
                {
                    this.trailField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string file
            {
                get
                {
                    return this.fileField;
                }
                set
                {
                    this.fileField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponProjectileResult
        {

            private string classField;

            private string kill_probabilityField;

            private string kill_decay_start_timeField;

            private string kill_decay_end_timeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string @class
            {
                get
                {
                    return this.classField;
                }
                set
                {
                    this.classField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string kill_probability
            {
                get
                {
                    return this.kill_probabilityField;
                }
                set
                {
                    this.kill_probabilityField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string kill_decay_start_time
            {
                get
                {
                    return this.kill_decay_start_timeField;
                }
                set
                {
                    this.kill_decay_start_timeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string kill_decay_end_time
            {
                get
                {
                    return this.kill_decay_end_timeField;
                }
                set
                {
                    this.kill_decay_end_timeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponProjectileTrail
        {

            private string probabilityField;

            private string keyField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string probability
            {
                get
                {
                    return this.probabilityField;
                }
                set
                {
                    this.probabilityField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponStance
        {

            private string state_keyField;

            private string accuracyField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string state_key
            {
                get
                {
                    return this.state_keyField;
                }
                set
                {
                    this.state_keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string accuracy
            {
                get
                {
                    return this.accuracyField;
                }
                set
                {
                    this.accuracyField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class weaponModifier
        {

            private string classField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string @class
            {
                get
                {
                    return this.classField;
                }
                set
                {
                    this.classField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }


    }
}
