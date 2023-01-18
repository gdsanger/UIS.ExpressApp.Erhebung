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
    [XafDisplayName("Hochschulen")]
    [XafDefaultProperty("MatchKey")]
    [CreatableItem(false)]
    public class Hochschulen : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Hochschulen(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        public string MatchKey
        {
            get { return string.Format("{0} ({1})", Name, Key); }
        }
        [Size(4), Key(false)]
        public string Key
        {
            get { return GetPropertyValue<string>("Key"); }
            set { SetPropertyValue<string>("Key", value); }
        }
        [Size(300), ToolTip("jiji")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }
        public bool Obsolet
        {
            get { return GetPropertyValue<bool>("Obsolet"); }
            set { SetPropertyValue<bool>("Obsolet", value); }
        }
        public Hochschulen ErsatzHochschule
        {
            get { return GetPropertyValue<Hochschulen>("ErsatzHochschule"); }
            set { SetPropertyValue<Hochschulen>("ErsatzHochschule", value); }
        }

        #region Actions
        [Action(Caption = "Import", AutoCommit = true)]
        public void ImportData(ImportArgs args)
        {
            string[] Lines = args.ImportData.Split(Environment.NewLine.ToCharArray());
            foreach (string Line in Lines)
            {
                bool obs = false;
                if (Line != "")
                {
                    string[] Colums = Line.Split('\t');
                    string Key = Colums[0];
                    string Name = Colums[1];
                    if(Key.IndexOf("(") > -1)
                    {
                        // Änderung, obsolet!!
                        obs = true;
                        Key = Key.Substring(1, 4);
                    }
                   

                    Hochschulen h = Session.FindObject<Hochschulen>(new BinaryOperator("Key", Key));
                    if (h == null)
                    {
                        h = new Hochschulen(Session);
                        h.Key = Key;

                    }
                    h.Name = Name;
                    h.Obsolet = obs;
                    Session.Save(h);
                }
            }
        }


        #endregion

    }
}