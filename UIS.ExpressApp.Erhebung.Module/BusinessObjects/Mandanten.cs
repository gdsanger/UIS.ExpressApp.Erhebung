using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
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
    [XafDisplayName("Mandanten")]
    [XafDefaultProperty("Name")]
    [CreatableItem(false)]

    public class Mandanten : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Mandanten(Session session)
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
        [Size(2)]
        public string Berichtsland
        {
            get { return GetPropertyValue<string>("Berichtsland"); }
            set { SetPropertyValue<string>("Berichtsland", value); }
        }
        [Size(4)]
        public string KeyHochschule
        {
            get { return GetPropertyValue<string>("KeyHochschule"); }
            set { SetPropertyValue<string>("KeyHochschule", value); }
        }
      
        public string UisOnlineStudentenLink
        {
            get { return GetPropertyValue<string>("UisOnlineStudentenLink"); }
            set { SetPropertyValue<string>("UisOnlineStudentenLink", value); }
        }

        [Association("Mandant-Erhebung")]
        public XPCollection<Erhebung> Erhebungen
        { get { return GetCollection<Erhebung>("Erhebungen"); } }


       

    }
}