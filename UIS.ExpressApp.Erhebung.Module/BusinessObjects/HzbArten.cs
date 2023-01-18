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
    [XafDisplayName("HZB Arten")]
    [XafDefaultProperty("MatchKey")]
    [CreatableItem(false)]
    public class HzbArten : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public HzbArten(Session session)
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
        [Size(2), Key(false)]
        public string Key
        {
            get { return GetPropertyValue<string>("Key"); }
            set { SetPropertyValue<string>("Key", value); }
        }
        [Size(300)]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }
        #region Actions
        [Action(Caption = "Import", AutoCommit = true)]
        public void ImportData(ImportArgs args)
        {
            string[] Lines = args.ImportData.Split(Environment.NewLine.ToCharArray());
            foreach (string Line in Lines)
            {
                if (Line != "")
                {
                    string[] Colums = Line.Split(';');
                    string Key = Colums[0];
                    string Name = Colums[2];

                    HzbArten h = Session.FindObject<HzbArten>(new BinaryOperator("Key", Key));
                    if (h == null)
                    {
                        h = new HzbArten(Session);
                        h.Key = Key;
                    }
                    h.Name = Name;
                    Session.Save(h);
                }
            }
        }
        #endregion
    }
}