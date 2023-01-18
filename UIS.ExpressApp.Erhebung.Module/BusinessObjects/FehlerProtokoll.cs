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
    [NavigationItem(false)]
    [XafDisplayName("FehlerProtokoll")]
    [XafDefaultProperty("MatchKey")]
    [CreatableItem(false)]
    public class FehlerProtokoll : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public FehlerProtokoll(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        [Association("Erhebung-Fehlerprotokoll")]
        public Erhebung Erhebung
        {
            get { return GetPropertyValue<Erhebung>("Erhebung"); }
            set { SetPropertyValue<Erhebung>("Erhebung", value); }
        }
        [Association("Erhebungsdaten-Fehlerprotokoll")]
        public Erhebungsdaten Erhebungsdaten
        {
            get { return GetPropertyValue<Erhebungsdaten>("Erhebungsdaten"); }
            set { SetPropertyValue<Erhebungsdaten>("Erhebungsdaten", value); }
        }
        public PlPrüfungen Prüfung
        {
            get { return GetPropertyValue<PlPrüfungen>("Prüfung"); }
            set { SetPropertyValue<PlPrüfungen>("Prüfung", value); }
        }



    }
}