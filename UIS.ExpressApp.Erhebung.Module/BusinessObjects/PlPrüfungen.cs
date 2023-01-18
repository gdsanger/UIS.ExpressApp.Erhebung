using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace UIS.ExpressApp.Erhebung.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Stammdaten")]
    [XafDisplayName("Pl-Prüfungen")]
    [XafDefaultProperty("Name")]
    [CreatableItem(false)]
    public class PlPrüfungen : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public PlPrüfungen(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }
        public bool Aktiv
        {
            get { return GetPropertyValue<bool>("Aktiv"); }
            set { SetPropertyValue<bool>("Aktiv", value); }
        }
        public string FehlertextKurz
        {
            get { return GetPropertyValue<string>("FehlertextKurz"); }
            set { SetPropertyValue<string>("FehlertextKurz", value); }
        }
        [Size(-1)]
        public string FehlertextLang
        {
            get { return GetPropertyValue<string>("FehlertextLang"); }
            set { SetPropertyValue<string>("FehlertextLang", value); }
        }
        [Size(-1)]
        public string CustomSqlCommand
        {
            get { return GetPropertyValue<string>("CustomSqlCommand"); }
            set { SetPropertyValue<string>("CustomSqlCommand", value); }
        }
        [ValueConverter(typeof(TypeToStringConverter)), ImmediatePostData]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type Objekt
        {
            get { return GetPropertyValue<Type>("Objekt"); }
            set
            {
                SetPropertyValue<Type>("Objekt", value);
                Prüfbedingung = String.Empty;
            }
        }
        [CriteriaOptions("Objekt"), Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public string Prüfbedingung
        {
            get { return GetPropertyValue<string>("Prüfbedingung"); }
            set { SetPropertyValue<string>("Prüfbedingung", value); }
        }
        public Prüfungsart Prüfungsart
        {
            get { return GetPropertyValue<Prüfungsart>("Prüfungsart"); }
            set { SetPropertyValue<Prüfungsart>("Prüfungsart", value); }
        }
    }
}