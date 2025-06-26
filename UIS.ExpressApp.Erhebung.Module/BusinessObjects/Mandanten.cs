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
        public string MSSQLServer
        {
            get { return GetPropertyValue<string>("MSSQLServer"); }
            set { SetPropertyValue<string>("MSSQLServer", value); }
        }
        public string Datenbank
        {
            get { return GetPropertyValue<string>("Datenbank"); }
            set { SetPropertyValue<string>("Datenbank", value); }
        }
        public string Benutzername
        {
            get { return GetPropertyValue<string>("Benutzername"); }
            set { SetPropertyValue<string>("Benutzername", value); }
        }
        public string Passwort
        {
            get { return GetPropertyValue<string>("Passwort"); }
            set { SetPropertyValue<string>("Passwort", value); }
        }

        [Association("Mandant-Erhebung")]
        public XPCollection<Erhebung> Erhebungen
        { get { return GetCollection<Erhebung>("Erhebungen"); } }


        [Browsable(false)]
        public string ConnectionString
        {
            get
            {
                if (MSSQLServer != null && Benutzername != null && Passwort != null && Datenbank != null)
                    return string.Format("Data Source = {0}; Initial Catalog = {1}; Persist Security Info = True; User ID = {2}; Password = {3}", MSSQLServer, Datenbank, Benutzername, Passwort);
                return "";
            }
        }

    }
}