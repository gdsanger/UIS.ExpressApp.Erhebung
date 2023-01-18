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
    [XafDisplayName("Erhebungsdaten")]
    [XafDefaultProperty("MatchKey")]
    [CreatableItem(false)]
    public class Erhebungsdaten : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Erhebungsdaten(Session session)
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
            get { return string.Format("{0} ({1})", EF6, EF9); }
        }
        [Association("Erhebung-Erhebungsunterlagen")]
        public Erhebung Erhebung
        {
            get { return GetPropertyValue<Erhebung>("Erhebung"); }
            set { SetPropertyValue<Erhebung>("Erhebung", value); }
        }     
        public bool IsFehlerhaft
        {
           get
            {
                if (FehlerProtokoll.Count == 0)
                    return false;
                else
                    return true;
            }           
        }   
        
        public int FehlerCount
        {
            get { return FehlerProtokoll.Count; }
        }
        public string Fehlerliste
        {
            get 
            {
                string t = "";
                foreach (FehlerProtokoll fp in FehlerProtokoll)
                    t += fp.Prüfung.Name + ", ";
                return t;
            }
        }

        [Association("Erhebungsdaten-Fehlerprotokoll")]
        public XPCollection<FehlerProtokoll> FehlerProtokoll
        {
            get { return GetCollection<FehlerProtokoll>("FehlerProtokoll"); }
        }

        [Size(2), ToolTip("Basisdaten - Berichtsland")] 
        public string EF1 
        { 
            get 
            {
                if (Erhebung != null)
                    return Erhebung.Mandant.Berichtsland;
                else
                    return "  ";
            }          
        }
        [Size(1), ToolTip("Basisdaten - Berichtssemester")] 
        public string EF2
        {
            get 
            {
                if (Erhebung != null)
                    return ((int)Erhebung.Semester).ToString();
                else
                    return " ";
            }
        }
        [Size(4), ToolTip("Basisdaten - Berichtsjahr")] 
        public string EF3 
        {
            get
            {
                if (Erhebung != null)
                    return Erhebung.Berichtsjahr.ToString("0000");
                else
                    return " ";
            }
        }
        [Size(4), ToolTip("Basisdaten - Hochschulstandort")] 
        public string EF4 
        {
            get
            {
                if (Erhebung != null)
                    return Erhebung.Mandant.KeyHochschule;
                else
                    return " ";
            }
        }
        public Staatsangehörigkeit Staatsangehörigkeit
        {
            get
            {
                if (EF10 == "000")
                    return Staatsangehörigkeit.Deutsche;
                else
                    return Staatsangehörigkeit.Ausländer;
            }
        }
        [Size(6), ToolTip("Basisdaten - Paginiernummer")] public string EF5 { get { return GetPropertyValue<string>("EF5"); } set { SetPropertyValue<string>("EF5", value); } }
        [Size(12), ToolTip("Basisdaten - Matrikelnummer")] public string EF6 { get { return GetPropertyValue<string>("EF6"); } set { SetPropertyValue<string>("EF6", value); } }
        [Size(1), ToolTip("Basisdaten - Geschecht")] public Geschlechter EF7 { get { return GetPropertyValue<Geschlechter>("EF7"); } set { SetPropertyValue<Geschlechter>("EF7", value); } }
        [Size(2), ToolTip("Basisdaten - Geburtsdatum Tag")] public string EF8U1 { get { return GetPropertyValue<string>("EF8U1"); } set { SetPropertyValue<string>("EF8U1", value); } }
        [Size(2), ToolTip("Basisdaten - Geburtsdatum Monat")] public string EF8U2 { get { return GetPropertyValue<string>("EF8U2"); } set { SetPropertyValue<string>("EF8U2", value); } }
        [Size(4), ToolTip("Basisdaten - Geburtsdatum Jahr")] public string EF8U3 { get { return GetPropertyValue<string>("EF8U3"); } set { SetPropertyValue<string>("EF8U3", value); } }
        [Size(4), ToolTip("Basisdaten - Name (Ersten 4 Buchstaben)")] public string EF9 { get { return GetPropertyValue<string>("EF9"); } set { SetPropertyValue<string>("EF9", value); } }
        [Size(3), ToolTip("Basisdaten - Staatsangehörigkeit")] public string EF10 { get { return GetPropertyValue<string>("EF10"); } set { SetPropertyValue<string>("EF10", value); } }
        [Size(3), ToolTip("Basisdaten - weitere Staatsangehörigkeit")] public string EF11 { get { return GetPropertyValue<string>("EF11"); } set { SetPropertyValue<string>("EF11", value); } }
        [Size(2), ToolTip("Basisdaten - Semesterwohnsitz Bundesland")] public string EF12U1 { get { return GetPropertyValue<string>("EF12U1"); } set { SetPropertyValue<string>("EF12U1", value); } }
        [Size(3), ToolTip("Basisdaten - Semesterwohnsitz Kreis")] public string EF12U2 { get { return GetPropertyValue<string>("EF12U2"); } set { SetPropertyValue<string>("EF12U2", value); } }
        [Size(2), ToolTip("Basisdaten - Heimatwohnsitz Bundesland")] public string EF13U1 { get { return GetPropertyValue<string>("EF13U1"); } set { SetPropertyValue<string>("EF13U1", value); } }
        [Size(3), ToolTip("Basisdaten - Heimatwohnsitz Kreis")] public string EF13U2 { get { return GetPropertyValue<string>("EF13U2"); } set { SetPropertyValue<string>("EF13U2", value); } }
        [Size(1), ToolTip("Basisdaten - Hörerstatus")] public string EF14 { get { return GetPropertyValue<string>("EF14"); } set { SetPropertyValue<string>("EF14", value); } }
        [Size(2), ToolTip("Basisdaten - Frei")] public string EF15 { get { return GetPropertyValue<string>("EF15"); } set { SetPropertyValue<string>("EF15", value); } }
        [Size(2), ToolTip("Basisdaten - Frei")] public string EF16 { get { return GetPropertyValue<string>("EF16"); } set { SetPropertyValue<string>("EF16", value); } }
        [Size(4), ToolTip("Ersteinschreibung / Hochschulsemester - Hochschulstandort")] public string EF17 { get { return GetPropertyValue<string>("EF17"); } set { SetPropertyValue<string>("EF17", value); } }
        [Size(3), ToolTip("Ersteinschreibung / Hochschulsemester - Staat der Hochschule")] public string EF18 { get { return GetPropertyValue<string>("EF18"); } set { SetPropertyValue<string>("EF18", value); } }
        [Size(1), ToolTip("Ersteinschreibung / Hochschulsemester - Semester")] public string EF19 { get { return GetPropertyValue<string>("EF19"); } set { SetPropertyValue<string>("EF19", value); } }
        [Size(4), ToolTip("Ersteinschreibung / Hochschulsemester - Jahr")] public string EF20 { get { return GetPropertyValue<string>("EF20"); } set { SetPropertyValue<string>("EF20", value); } }
        [Size(2), ToolTip("Ersteinschreibung / Hochschulsemester - Anzahl HS")] public string EF21 { get { return GetPropertyValue<string>("EF21"); } set { SetPropertyValue<string>("EF21", value); } }
        [Size(2), ToolTip("Ersteinschreibung / Hochschulsemester - Urlaubssemester")] public string EF22 { get { return GetPropertyValue<string>("EF22"); } set { SetPropertyValue<string>("EF22", value); } }
        [Size(1), ToolTip("Ersteinschreibung / Hochschulsemester - Praxissemester")] public string EF23 { get { return GetPropertyValue<string>("EF23"); } set { SetPropertyValue<string>("EF23", value); } }
        [Size(1), ToolTip("Ersteinschreibung / Hochschulsemester - Semester im Studienkolleg")] public string EF24 { get { return GetPropertyValue<string>("EF24"); } set { SetPropertyValue<string>("EF24", value); } }
        [Size(2), ToolTip("Ersteinschreibung / Hochschulsemester - Unterbrechnungssemester")] public string EF25 { get { return GetPropertyValue<string>("EF25"); } set { SetPropertyValue<string>("EF25", value); } }
        [Size(2), ToolTip("Studienunterbrechnung - Art der Studienunterbrechnung")] public string EF26 { get { return GetPropertyValue<string>("EF26"); } set { SetPropertyValue<string>("EF26", value); } }
        [Size(3), ToolTip("Studienunterbrechnung - Frei")] public string EF27 { get { return GetPropertyValue<string>("EF27"); } set { SetPropertyValue<string>("EF27", value); } }
        [Size(1), ToolTip("1. Studiengang an der Hochschule - Art der Einschreibung")] public EinschreibungsArt EF28 { get { return GetPropertyValue<EinschreibungsArt>("EF28"); } set { SetPropertyValue<EinschreibungsArt>("EF28", value); } }
        [Size(1), ToolTip("1. Studiengang an der Hochschule - Grund der Beurlaubung / Exmatrikulation")] public string EF29 { get { return GetPropertyValue<string>("EF29"); } set { SetPropertyValue<string>("EF29", value); } }
        [Size(1), ToolTip("1. Studiengang an der Hochschule - Art des Studiums")] public string EF30 { get { return GetPropertyValue<string>("EF30"); } set { SetPropertyValue<string>("EF30", value); } }
        [Size(1), ToolTip("1. Studiengang an der Hochschule - Voll-/Teil-/Duales Studium")] public Studienart EF31 { get { return GetPropertyValue<Studienart>("EF31"); } set { SetPropertyValue<Studienart>("EF31", value); } }
        [Size(2), ToolTip("1. Studiengang an der Hochschule - Anzahl der FS")] public string EF32 { get { return GetPropertyValue<string>("EF32"); } set { SetPropertyValue<string>("EF32", value); } }
        [Size(3), ToolTip("1. Studiengang an der Hochschule - Angestrebte Abschlussprüfung")] public string EF33 { get { return GetPropertyValue<string>("EF33"); } set { SetPropertyValue<string>("EF33", value); } }
        [Size(2), ToolTip("1. Studiengang an der Hochschule - Bundesland der angestrebten Abschlussprüfung")] public string EF34U1 { get { return GetPropertyValue<string>("EF34U1"); } set { SetPropertyValue<string>("EF34U1", value); } }
        [Size(3), ToolTip("1. Studiengang an der Hochschule - Kreis der angestrebten Abschlussprüfung")] public string EF34U2 { get { return GetPropertyValue<string>("EF34U2"); } set { SetPropertyValue<string>("EF34U2", value); } }
        [Size(2), ToolTip("1. Studiengang an der Hochschule - Regekstudienzeit")] public string EF35 { get { return GetPropertyValue<string>("EF35"); } set { SetPropertyValue<string>("EF35", value); } }
        [Size(3), ToolTip("1. Studiengang an der Hochschule - 1. Studienfach")] public string EF36 { get { return GetPropertyValue<string>("EF36"); } set { SetPropertyValue<string>("EF36", value); } }
        [Size(3), ToolTip("1. Studiengang an der Hochschule - 2. Studienfach")] public string EF37 { get { return GetPropertyValue<string>("EF37"); } set { SetPropertyValue<string>("EF37", value); } }
        [Size(2), ToolTip("1. Studiengang an der Hochschule - Frei")] public string EF38 { get { return GetPropertyValue<string>("EF38"); } set { SetPropertyValue<string>("EF38", value); } }
        [Size(3), ToolTip("1. Studiengang an der Hochschule - 3. Studienfach")] public string EF39 { get { return GetPropertyValue<string>("EF39"); } set { SetPropertyValue<string>("EF39", value); } }
        [Size(2), ToolTip("1. Studiengang an der Hochschule - Frei")] public string EF40 { get { return GetPropertyValue<string>("EF40"); } set { SetPropertyValue<string>("EF40", value); } }
        [Size(3), ToolTip("1. Studiengang an der Hochschule - Frei")] public string EF41 { get { return GetPropertyValue<string>("EF41"); } set { SetPropertyValue<string>("EF41", value); } }
        [Size(2), ToolTip("1. Studiengang an der Hochschule - Frei")] public string EF42 { get { return GetPropertyValue<string>("EF42"); } set { SetPropertyValue<string>("EF42", value); } }
        [Size(5), ToolTip("1. Studiengang an der Hochschule - Frei")] public string EF43 { get { return GetPropertyValue<string>("EF43"); } set { SetPropertyValue<string>("EF43", value); } }
        [Size(1), ToolTip("2. Studiengang an der Hochschulen - Art der Einschreibung")] public string EF44 { get { return GetPropertyValue<string>("EF44"); } set { SetPropertyValue<string>("EF44", value); } }
        [Size(1), ToolTip("2. Studiengang an der Hochschulen - Grund der Beurlaubung / Exmatrikulation")] public string EF45 { get { return GetPropertyValue<string>("EF45"); } set { SetPropertyValue<string>("EF45", value); } }
        [Size(1), ToolTip("2. Studiengang an der Hochschulen - Art des Studiums")] public string EF46 { get { return GetPropertyValue<string>("EF46"); } set { SetPropertyValue<string>("EF46", value); } }
        [Size(1), ToolTip("2. Studiengang an der Hochschulen - Voll-/Teil-/Duales Studium")] public string EF47 { get { return GetPropertyValue<string>("EF47"); } set { SetPropertyValue<string>("EF47", value); } }
        [Size(2), ToolTip("2. Studiengang an der Hochschulen - Anzahl der FS")] public string EF48 { get { return GetPropertyValue<string>("EF48"); } set { SetPropertyValue<string>("EF48", value); } }
        [Size(3), ToolTip("2. Studiengang an der Hochschulen - Angestrebte Abschlussprüfung")] public string EF49 { get { return GetPropertyValue<string>("EF49"); } set { SetPropertyValue<string>("EF49", value); } }
        [Size(2), ToolTip("2. Studiengang an der Hochschulen - Bundesland der angestrebten Abschlussprüfung")] public string EF50U1 { get { return GetPropertyValue<string>("EF50U1"); } set { SetPropertyValue<string>("EF50U1", value); } }
        [Size(3), ToolTip("2. Studiengang an der Hochschulen - Kreis der angestrebten Abschlussprüfung")] public string EF50U2 { get { return GetPropertyValue<string>("EF50U2"); } set { SetPropertyValue<string>("EF50U2", value); } }
        [Size(2), ToolTip("2. Studiengang an der Hochschulen - Regekstudienzeit")] public string EF51 { get { return GetPropertyValue<string>("EF51"); } set { SetPropertyValue<string>("EF51", value); } }
        [Size(3), ToolTip("2. Studiengang an der Hochschulen - 1. Studienfach")] public string EF52 { get { return GetPropertyValue<string>("EF52"); } set { SetPropertyValue<string>("EF52", value); } }
        [Size(3), ToolTip("2. Studiengang an der Hochschulen - 2. Studienfach")] public string EF53 { get { return GetPropertyValue<string>("EF53"); } set { SetPropertyValue<string>("EF53", value); } }
        [Size(2), ToolTip("2. Studiengang an der Hochschulen - Frei")] public string EF54 { get { return GetPropertyValue<string>("EF54"); } set { SetPropertyValue<string>("EF54", value); } }
        [Size(3), ToolTip("2. Studiengang an der Hochschulen - 3. Studienfach")] public string EF55 { get { return GetPropertyValue<string>("EF55"); } set { SetPropertyValue<string>("EF55", value); } }
        [Size(2), ToolTip("2. Studiengang an der Hochschulen - Frei")] public string EF56 { get { return GetPropertyValue<string>("EF56"); } set { SetPropertyValue<string>("EF56", value); } }
        [Size(3), ToolTip("2. Studiengang an der Hochschulen - Frei")] public string EF57 { get { return GetPropertyValue<string>("EF57"); } set { SetPropertyValue<string>("EF57", value); } }
        [Size(2), ToolTip("2. Studiengang an der Hochschulen - Frei")] public string EF58 { get { return GetPropertyValue<string>("EF58"); } set { SetPropertyValue<string>("EF58", value); } }
        [Size(5), ToolTip("2. Studiengang an der Hochschulen - Frei")] public string EF59 { get { return GetPropertyValue<string>("EF59"); } set { SetPropertyValue<string>("EF59", value); } }
        [Size(4), ToolTip("Ersteinschreibung an einer anderen Hochschule - Hochschulstandort")] public string EF60 { get { return GetPropertyValue<string>("EF60"); } set { SetPropertyValue<string>("EF60", value); } }
        [Size(3), ToolTip("Ersteinschreibung an einer anderen Hochschule - Staat der Hochschule")] public string EF61 { get { return GetPropertyValue<string>("EF61"); } set { SetPropertyValue<string>("EF61", value); } }
        [Size(3), ToolTip("Ersteinschreibung an einer anderen Hochschule - Angestrebte Abschlussprüfung")] public string EF62 { get { return GetPropertyValue<string>("EF62"); } set { SetPropertyValue<string>("EF62", value); } }
        [Size(3), ToolTip("Ersteinschreibung an einer anderen Hochschule - 1. Studienfach")] public string EF63 { get { return GetPropertyValue<string>("EF63"); } set { SetPropertyValue<string>("EF63", value); } }
        [Size(3), ToolTip("Ersteinschreibung an einer anderen Hochschule - 2. Studienfach")] public string EF64 { get { return GetPropertyValue<string>("EF64"); } set { SetPropertyValue<string>("EF64", value); } }
        [Size(3), ToolTip("Ersteinschreibung an einer anderen Hochschule - 3. Studienfach")] public string EF65 { get { return GetPropertyValue<string>("EF65"); } set { SetPropertyValue<string>("EF65", value); } }
        [Size(3), ToolTip("Ersteinschreibung an einer anderen Hochschule - Frei")] public string EF66 { get { return GetPropertyValue<string>("EF66"); } set { SetPropertyValue<string>("EF66", value); } }
        [Size(2), ToolTip("Ersteinschreibung an einer anderen Hochschule - Frei")] public string EF67 { get { return GetPropertyValue<string>("EF67"); } set { SetPropertyValue<string>("EF67", value); } }
        [Size(5), ToolTip("Ersteinschreibung an einer anderen Hochschule - Frei")] public string EF68 { get { return GetPropertyValue<string>("EF68"); } set { SetPropertyValue<string>("EF68", value); } }
        [Size(1), ToolTip("Studium im vorherigen Semester - Kennziffer für jetzigen oder anderen Hochschulstandort")] public string EF69 { get { return GetPropertyValue<string>("EF69"); } set { SetPropertyValue<string>("EF69", value); } }
        [Size(1), ToolTip("Studium im vorherigen Semester - Studiengang gleich Berichtssemester")] public string EF70 { get { return GetPropertyValue<string>("EF70"); } set { SetPropertyValue<string>("EF70", value); } }
        [Size(4), ToolTip("1. Studiengang - Hochschulstandort")] public string EF71 { get { return GetPropertyValue<string>("EF71"); } set { SetPropertyValue<string>("EF71", value); } }
        [Size(3), ToolTip("1. Studiengang - Staat der Hochschule")] public string EF72 { get { return GetPropertyValue<string>("EF72"); } set { SetPropertyValue<string>("EF72", value); } }
        [Size(3), ToolTip("1. Studiengang - Angestrebte Abschlussprüfung")] public string EF73 { get { return GetPropertyValue<string>("EF73"); } set { SetPropertyValue<string>("EF73", value); } }
        [Size(3), ToolTip("1. Studiengang - 1. Studienfach")] public string EF74 { get { return GetPropertyValue<string>("EF74"); } set { SetPropertyValue<string>("EF74", value); } }
        [Size(3), ToolTip("1. Studiengang - 2. Studienfach")] public string EF75 { get { return GetPropertyValue<string>("EF75"); } set { SetPropertyValue<string>("EF75", value); } }
        [Size(3), ToolTip("1. Studiengang - 3. Studienfach")] public string EF76 { get { return GetPropertyValue<string>("EF76"); } set { SetPropertyValue<string>("EF76", value); } }
        [Size(3), ToolTip("1. Studiengang - Frei")] public string EF77 { get { return GetPropertyValue<string>("EF77"); } set { SetPropertyValue<string>("EF77", value); } }
        [Size(2), ToolTip("1. Studiengang - Frei")] public string EF78 { get { return GetPropertyValue<string>("EF78"); } set { SetPropertyValue<string>("EF78", value); } }
        [Size(5), ToolTip("1. Studiengang - Frei")] public string EF79 { get { return GetPropertyValue<string>("EF79"); } set { SetPropertyValue<string>("EF79", value); } }
        [Size(4), ToolTip("2. Studiengang - Hochschulstandort")] public string EF80 { get { return GetPropertyValue<string>("EF80"); } set { SetPropertyValue<string>("EF80", value); } }
        [Size(3), ToolTip("2. Studiengang - Staat der Hochschule")] public string EF81 { get { return GetPropertyValue<string>("EF81"); } set { SetPropertyValue<string>("EF81", value); } }
        [Size(3), ToolTip("2. Studiengang - Angestrebte Abschlussprüfung")] public string EF82 { get { return GetPropertyValue<string>("EF82"); } set { SetPropertyValue<string>("EF82", value); } }
        [Size(3), ToolTip("2. Studiengang - 1. Studienfach")] public string EF83 { get { return GetPropertyValue<string>("EF83"); } set { SetPropertyValue<string>("EF83", value); } }
        [Size(3), ToolTip("2. Studiengang - 2. Studienfach")] public string EF84 { get { return GetPropertyValue<string>("EF84"); } set { SetPropertyValue<string>("EF84", value); } }
        [Size(3), ToolTip("2. Studiengang - 3. Studienfach")] public string EF85 { get { return GetPropertyValue<string>("EF85"); } set { SetPropertyValue<string>("EF85", value); } }
        [Size(3), ToolTip("2. Studiengang - Frei")] public string EF86 { get { return GetPropertyValue<string>("EF86"); } set { SetPropertyValue<string>("EF86", value); } }
        [Size(2), ToolTip("2. Studiengang - Frei")] public string EF87 { get { return GetPropertyValue<string>("EF87"); } set { SetPropertyValue<string>("EF87", value); } }
        [Size(5), ToolTip("2. Studiengang - Frei")] public string EF88 { get { return GetPropertyValue<string>("EF88"); } set { SetPropertyValue<string>("EF88", value); } }
        [Size(4), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Hochschulstandort")] public string EF89 { get { return GetPropertyValue<string>("EF89"); } set { SetPropertyValue<string>("EF89", value); } }
        [Size(3), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Staat der Hochschule")] public string EF90 { get { return GetPropertyValue<string>("EF90"); } set { SetPropertyValue<string>("EF90", value); } }
        [Size(3), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Art der Prüfung")] public string EF91 { get { return GetPropertyValue<string>("EF91"); } set { SetPropertyValue<string>("EF91", value); } }
        [Size(3), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - 1. Studienfach")] public string EF92 { get { return GetPropertyValue<string>("EF92"); } set { SetPropertyValue<string>("EF92", value); } }
        [Size(3), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - 2. Studienfach")] public string EF93 { get { return GetPropertyValue<string>("EF93"); } set { SetPropertyValue<string>("EF93", value); } }
        [Size(3), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - 3. Studienfach")] public string EF94 { get { return GetPropertyValue<string>("EF94"); } set { SetPropertyValue<string>("EF94", value); } }
        [Size(2), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Monat des Prüfungsabschlusses")] public string EF95 { get { return GetPropertyValue<string>("EF95"); } set { SetPropertyValue<string>("EF95", value); } }
        [Size(4), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Jahr des Prüfungsabschlusses")] public string EF96 { get { return GetPropertyValue<string>("EF96"); } set { SetPropertyValue<string>("EF96", value); } }
        [Size(1), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Prüfungsergebnis")] public string EF97 { get { return GetPropertyValue<string>("EF97"); } set { SetPropertyValue<string>("EF97", value); } }
        [Size(1), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Gesamtnote")] public string EF98 { get { return GetPropertyValue<string>("EF98"); } set { SetPropertyValue<string>("EF98", value); } }
        [Size(1), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Frei")] public string EF99 { get { return GetPropertyValue<string>("EF99"); } set { SetPropertyValue<string>("EF99", value); } }
        [Size(3), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - frei")] public string EF100 { get { return GetPropertyValue<string>("EF100"); } set { SetPropertyValue<string>("EF100", value); } }
        [Size(2), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - frei")] public string EF101 { get { return GetPropertyValue<string>("EF101"); } set { SetPropertyValue<string>("EF101", value); } }
        [Size(5), ToolTip("Bereits vor Berichtssemester abgelegte Prüfungen - Frei")] public string EF102 { get { return GetPropertyValue<string>("EF102"); } set { SetPropertyValue<string>("EF102", value); } }
        [Size(4), ToolTip("ggfls. Vorletzte Prüfung - Hochschulstandort")] public string EF103 { get { return GetPropertyValue<string>("EF103"); } set { SetPropertyValue<string>("EF103", value); } }
        [Size(3), ToolTip("ggfls. Vorletzte Prüfung - Staat der Hochschule")] public string EF104 { get { return GetPropertyValue<string>("EF104"); } set { SetPropertyValue<string>("EF104", value); } }
        [Size(3), ToolTip("ggfls. Vorletzte Prüfung - Art der Prüfung")] public string EF105 { get { return GetPropertyValue<string>("EF105"); } set { SetPropertyValue<string>("EF105", value); } }
        [Size(3), ToolTip("ggfls. Vorletzte Prüfung - 1. Studienfach")] public string EF106 { get { return GetPropertyValue<string>("EF106"); } set { SetPropertyValue<string>("EF106", value); } }
        [Size(3), ToolTip("ggfls. Vorletzte Prüfung - 2. Studienfach")] public string EF107 { get { return GetPropertyValue<string>("EF107"); } set { SetPropertyValue<string>("EF107", value); } }
        [Size(3), ToolTip("ggfls. Vorletzte Prüfung - 3. Studienfach")] public string EF108 { get { return GetPropertyValue<string>("EF108"); } set { SetPropertyValue<string>("EF108", value); } }
        [Size(2), ToolTip("ggfls. Vorletzte Prüfung - Monat des Prüfungsabschlusses")] public string EF109 { get { return GetPropertyValue<string>("EF109"); } set { SetPropertyValue<string>("EF109", value); } }
        [Size(4), ToolTip("ggfls. Vorletzte Prüfung - Jahr des Prüfungsabschlusses")] public string EF110 { get { return GetPropertyValue<string>("EF110"); } set { SetPropertyValue<string>("EF110", value); } }
        [Size(1), ToolTip("ggfls. Vorletzte Prüfung - Prüfungsergebnis")] public string EF111 { get { return GetPropertyValue<string>("EF111"); } set { SetPropertyValue<string>("EF111", value); } }
        [Size(1), ToolTip("ggfls. Vorletzte Prüfung - Gesamtnote")] public string EF112 { get { return GetPropertyValue<string>("EF112"); } set { SetPropertyValue<string>("EF112", value); } }
        [Size(2), ToolTip("ggfls. Vorletzte Prüfung - Frei")] public string EF113 { get { return GetPropertyValue<string>("EF113"); } set { SetPropertyValue<string>("EF113", value); } }
        [Size(3), ToolTip("ggfls. Vorletzte Prüfung - frei")] public string EF114 { get { return GetPropertyValue<string>("EF114"); } set { SetPropertyValue<string>("EF114", value); } }
        [Size(2), ToolTip("ggfls. Vorletzte Prüfung - frei")] public string EF115 { get { return GetPropertyValue<string>("EF115"); } set { SetPropertyValue<string>("EF115", value); } }
        [Size(5), ToolTip("ggfls. Vorletzte Prüfung - Frei")] public string EF116 { get { return GetPropertyValue<string>("EF116"); } set { SetPropertyValue<string>("EF116", value); } }
        [Size(4), ToolTip("Hochschulzugangsberechtigung - Jahr des Erwerbs")] public string EF117 { get { return GetPropertyValue<string>("EF117"); } set { SetPropertyValue<string>("EF117", value); } }
        [Size(2), ToolTip("Hochschulzugangsberechtigung - Art der ersten HZB")] public string EF118 { get { return GetPropertyValue<string>("EF118"); } set { SetPropertyValue<string>("EF118", value); } }
        [Size(2), ToolTip("Hochschulzugangsberechtigung - Erwerb der HZB (Bundesland oder 99)")] public string EF119U1 { get { return GetPropertyValue<string>("EF119U1"); } set { SetPropertyValue<string>("EF119U1", value); } }
        [Size(3), ToolTip("Hochschulzugangsberechtigung - Erwerb der HZB (Kreis oder Land)")] public string EF119U2 { get { return GetPropertyValue<string>("EF119U2"); } set { SetPropertyValue<string>("EF119U2", value); } }
        [Size(3), ToolTip("Hochschulzugangsberechtigung - Frei")] public string EF120 { get { return GetPropertyValue<string>("EF120"); } set { SetPropertyValue<string>("EF120", value); } }
        [Size(2), ToolTip("Hochschulzugangsberechtigung - Frei")] public string EF121 { get { return GetPropertyValue<string>("EF121"); } set { SetPropertyValue<string>("EF121", value); } }
        [Size(1), ToolTip("Berufspraktische Tätigkeit vor dem Studium - Berufsausbildung mit Abschluss")] public string EF122 { get { return GetPropertyValue<string>("EF122"); } set { SetPropertyValue<string>("EF122", value); } }
        [Size(1), ToolTip("Berufspraktische Tätigkeit vor dem Studium - Praktikum oder Volontariat")] public string EF123 { get { return GetPropertyValue<string>("EF123"); } set { SetPropertyValue<string>("EF123", value); } }
        [Size(3), ToolTip("Berufspraktische Tätigkeit vor dem Studium - frei")] public string EF124 { get { return GetPropertyValue<string>("EF124"); } set { SetPropertyValue<string>("EF124", value); } }
        [Size(3), ToolTip("Berufspraktische Tätigkeit vor dem Studium - frei")] public string EF125 { get { return GetPropertyValue<string>("EF125"); } set { SetPropertyValue<string>("EF125", value); } }
        [Size(7), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Prüfungsamt")] public string EF126 { get { return GetPropertyValue<string>("EF126"); } set { SetPropertyValue<string>("EF126", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Anzahl Fs")] public string EF127 { get { return GetPropertyValue<string>("EF127"); } set { SetPropertyValue<string>("EF127", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Anzahl der angerechneten FS")] public string EF128 { get { return GetPropertyValue<string>("EF128"); } set { SetPropertyValue<string>("EF128", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - FS aus einem anderen Studiengang")] public string EF129 { get { return GetPropertyValue<string>("EF129"); } set { SetPropertyValue<string>("EF129", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Berufspraktische Tätigkeit vor der Einschreibung")] public string EF130 { get { return GetPropertyValue<string>("EF130"); } set { SetPropertyValue<string>("EF130", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - aus einem Auslandsstudium")] public string EF131 { get { return GetPropertyValue<string>("EF131"); } set { SetPropertyValue<string>("EF131", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Anzahl erworbene ECTS")] public string EF132 { get { return GetPropertyValue<string>("EF132"); } set { SetPropertyValue<string>("EF132", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Außerhlab der HS erworbene ECTS Punkte")] public string EF133 { get { return GetPropertyValue<string>("EF133"); } set { SetPropertyValue<string>("EF133", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - im Ausland erworbene ECTS Punkt")] public string EF134 { get { return GetPropertyValue<string>("EF134"); } set { SetPropertyValue<string>("EF134", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Staat des Auslandsaufenthalts")] public string EF135 { get { return GetPropertyValue<string>("EF135"); } set { SetPropertyValue<string>("EF135", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Dauer des Aufenthalts in Monaten")] public string EF136 { get { return GetPropertyValue<string>("EF136"); } set { SetPropertyValue<string>("EF136", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Art des Auslandsaufenthalts")] public string EF137 { get { return GetPropertyValue<string>("EF137"); } set { SetPropertyValue<string>("EF137", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Art des Mobilitätsprograms")] public string EF138 { get { return GetPropertyValue<string>("EF138"); } set { SetPropertyValue<string>("EF138", value); } }
        [Size(3), ToolTip("Zweiter Studienbezogener Auslandsaufenthalt - Staat des Auslandsaufenthalts")] public string EF139 { get { return GetPropertyValue<string>("EF139"); } set { SetPropertyValue<string>("EF139", value); } }
        [Size(2), ToolTip("Zweiter Studienbezogener Auslandsaufenthalt - Dauer des Aufenthalts in Monaten")] public string EF140 { get { return GetPropertyValue<string>("EF140"); } set { SetPropertyValue<string>("EF140", value); } }
        [Size(2), ToolTip("Zweiter Studienbezogener Auslandsaufenthalt - Art des Auslandsaufenthalts")] public string EF141 { get { return GetPropertyValue<string>("EF141"); } set { SetPropertyValue<string>("EF141", value); } }
        [Size(2), ToolTip("Zweiter Studienbezogener Auslandsaufenthalt - Art des Mobilitätsprograms")] public string EF142 { get { return GetPropertyValue<string>("EF142"); } set { SetPropertyValue<string>("EF142", value); } }
        [Size(3), ToolTip("Dritter Studienbezogener Auslandsaufenthalt - Staat des Auslandsaufenthalts")] public string EF143 { get { return GetPropertyValue<string>("EF143"); } set { SetPropertyValue<string>("EF143", value); } }
        [Size(2), ToolTip("Dritter Studienbezogener Auslandsaufenthalt - Dauer des Aufenthalts in Monaten")] public string EF144 { get { return GetPropertyValue<string>("EF144"); } set { SetPropertyValue<string>("EF144", value); } }
        [Size(2), ToolTip("Dritter Studienbezogener Auslandsaufenthalt - Art des Auslandsaufenthalts")] public string EF145 { get { return GetPropertyValue<string>("EF145"); } set { SetPropertyValue<string>("EF145", value); } }
        [Size(2), ToolTip("Dritter Studienbezogener Auslandsaufenthalt - Art des Mobilitätsprograms")] public string EF146 { get { return GetPropertyValue<string>("EF146"); } set { SetPropertyValue<string>("EF146", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Art der Prüfung")] public string EF147 { get { return GetPropertyValue<string>("EF147"); } set { SetPropertyValue<string>("EF147", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Promotion")] public string EF148 { get { return GetPropertyValue<string>("EF148"); } set { SetPropertyValue<string>("EF148", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Regelstudienzeit")] public string EF149 { get { return GetPropertyValue<string>("EF149"); } set { SetPropertyValue<string>("EF149", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - 1. Studienfach")] public string EF150 { get { return GetPropertyValue<string>("EF150"); } set { SetPropertyValue<string>("EF150", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - 2. Studienfach")] public string EF151 { get { return GetPropertyValue<string>("EF151"); } set { SetPropertyValue<string>("EF151", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Frei")] public string EF152 { get { return GetPropertyValue<string>("EF152"); } set { SetPropertyValue<string>("EF152", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - 3. Studienfach")] public string EF153 { get { return GetPropertyValue<string>("EF153"); } set { SetPropertyValue<string>("EF153", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Frei")] public string EF154 { get { return GetPropertyValue<string>("EF154"); } set { SetPropertyValue<string>("EF154", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Monat des Prüfungsabschlusses")] public string EF155 { get { return GetPropertyValue<string>("EF155"); } set { SetPropertyValue<string>("EF155", value); } }
        [Size(4), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Jahr des Prüfungsabschlusses")] public string EF156 { get { return GetPropertyValue<string>("EF156"); } set { SetPropertyValue<string>("EF156", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Prüfungsergebnis")] public string EF157 { get { return GetPropertyValue<string>("EF157"); } set { SetPropertyValue<string>("EF157", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Gesamtnote")] public string EF158 { get { return GetPropertyValue<string>("EF158"); } set { SetPropertyValue<string>("EF158", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Frei")] public string EF159 { get { return GetPropertyValue<string>("EF159"); } set { SetPropertyValue<string>("EF159", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene Prüfungen - Frei")] public string EF160 { get { return GetPropertyValue<string>("EF160"); } set { SetPropertyValue<string>("EF160", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF161 { get { return GetPropertyValue<string>("EF161"); } set { SetPropertyValue<string>("EF161", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF162 { get { return GetPropertyValue<string>("EF162"); } set { SetPropertyValue<string>("EF162", value); } }
        [Size(7), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Prüfungsamt")] public string EF163 { get { return GetPropertyValue<string>("EF163"); } set { SetPropertyValue<string>("EF163", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Anzahl der FS")] public string EF164 { get { return GetPropertyValue<string>("EF164"); } set { SetPropertyValue<string>("EF164", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Anzahl der angerechneten FS")] public string EF165 { get { return GetPropertyValue<string>("EF165"); } set { SetPropertyValue<string>("EF165", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - FS aus einem anderen Studiengang")] public string EF166 { get { return GetPropertyValue<string>("EF166"); } set { SetPropertyValue<string>("EF166", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Berufspraktische Tätigkeit vor der Einschreibung")] public string EF167 { get { return GetPropertyValue<string>("EF167"); } set { SetPropertyValue<string>("EF167", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - aus einem Auslandsstudium")] public string EF168 { get { return GetPropertyValue<string>("EF168"); } set { SetPropertyValue<string>("EF168", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Anzahl erworbene ECTS")] public string EF169 { get { return GetPropertyValue<string>("EF169"); } set { SetPropertyValue<string>("EF169", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - ")] public string EF170 { get { return GetPropertyValue<string>("EF170"); } set { SetPropertyValue<string>("EF170", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - ")] public string EF171 { get { return GetPropertyValue<string>("EF171"); } set { SetPropertyValue<string>("EF171", value); } }
        [Size(3), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 1. Auslandsaufenthalt - Staat des Auslandsaufenthalts")] public string EF172 { get { return GetPropertyValue<string>("EF172"); } set { SetPropertyValue<string>("EF172", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 1. Auslandsaufenthalt - Dauer des Aufenthalts in Monaten")] public string EF173 { get { return GetPropertyValue<string>("EF173"); } set { SetPropertyValue<string>("EF173", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 1. Auslandsaufenthalt - Art des Auslandsaufenthalts")] public string EF174 { get { return GetPropertyValue<string>("EF174"); } set { SetPropertyValue<string>("EF174", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 1. Auslandsaufenthalt - Art des Mobilitätsprograms")] public string EF175 { get { return GetPropertyValue<string>("EF175"); } set { SetPropertyValue<string>("EF175", value); } }
        [Size(3), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 2. Auslandsaufenthalt - Staat des Auslandsaufenthalts")] public string EF176 { get { return GetPropertyValue<string>("EF176"); } set { SetPropertyValue<string>("EF176", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 2. Auslandsaufenthalt - Dauer des Aufenthalts in Monaten")] public string EF177 { get { return GetPropertyValue<string>("EF177"); } set { SetPropertyValue<string>("EF177", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 2. Auslandsaufenthalt - Art des Auslandsaufenthalts")] public string EF178 { get { return GetPropertyValue<string>("EF178"); } set { SetPropertyValue<string>("EF178", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 2. Auslandsaufenthalt - Art des Mobilitätsprograms")] public string EF179 { get { return GetPropertyValue<string>("EF179"); } set { SetPropertyValue<string>("EF179", value); } }
        [Size(3), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 3. Auslandsaufenthalt - Staat des Auslandsaufenthalts")] public string EF180 { get { return GetPropertyValue<string>("EF180"); } set { SetPropertyValue<string>("EF180", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 3. Auslandsaufenthalt - Dauer des Aufenthalts in Monaten")] public string EF181 { get { return GetPropertyValue<string>("EF181"); } set { SetPropertyValue<string>("EF181", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 3. Auslandsaufenthalt - Art des Auslandsaufenthalts")] public string EF182 { get { return GetPropertyValue<string>("EF182"); } set { SetPropertyValue<string>("EF182", value); } }
        [Size(2), ToolTip("Studienbezogene Auslandsaufenthalte 2. Prüfung - 3. Auslandsaufenthalt - Art des Mobilitätsprograms")] public string EF183 { get { return GetPropertyValue<string>("EF183"); } set { SetPropertyValue<string>("EF183", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Art der Prüfung")] public string EF184 { get { return GetPropertyValue<string>("EF184"); } set { SetPropertyValue<string>("EF184", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Promotion")] public string EF185 { get { return GetPropertyValue<string>("EF185"); } set { SetPropertyValue<string>("EF185", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Regelstudienzeit")] public string EF186 { get { return GetPropertyValue<string>("EF186"); } set { SetPropertyValue<string>("EF186", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - 1. Studienfach")] public string EF187 { get { return GetPropertyValue<string>("EF187"); } set { SetPropertyValue<string>("EF187", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - 2. Studienfach")] public string EF188 { get { return GetPropertyValue<string>("EF188"); } set { SetPropertyValue<string>("EF188", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF189 { get { return GetPropertyValue<string>("EF189"); } set { SetPropertyValue<string>("EF189", value); } }
        [Size(3), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - 3. Studienfach")] public string EF190 { get { return GetPropertyValue<string>("EF190"); } set { SetPropertyValue<string>("EF190", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF191 { get { return GetPropertyValue<string>("EF191"); } set { SetPropertyValue<string>("EF191", value); } }
        [Size(2), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Monat des Prüfungsabschlusses")] public string EF192 { get { return GetPropertyValue<string>("EF192"); } set { SetPropertyValue<string>("EF192", value); } }
        [Size(4), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Jahr des Prüfungsabschlusses")] public string EF193 { get { return GetPropertyValue<string>("EF193"); } set { SetPropertyValue<string>("EF193", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Prüfungsergebnis")] public string EF194 { get { return GetPropertyValue<string>("EF194"); } set { SetPropertyValue<string>("EF194", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Gesamtnote")] public string EF195 { get { return GetPropertyValue<string>("EF195"); } set { SetPropertyValue<string>("EF195", value); } }
        [Size(4), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF196 { get { return GetPropertyValue<string>("EF196"); } set { SetPropertyValue<string>("EF196", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF197 { get { return GetPropertyValue<string>("EF197"); } set { SetPropertyValue<string>("EF197", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF198 { get { return GetPropertyValue<string>("EF198"); } set { SetPropertyValue<string>("EF198", value); } }
        [Size(1), ToolTip("Seit der letzten Semestermeldung abgschlossene 2. Prüfungen - Frei")] public string EF199 { get { return GetPropertyValue<string>("EF199"); } set { SetPropertyValue<string>("EF199", value); } }

        #region Actions
        [Action(Caption ="UIS Online")]
        public void OpenUis()
        {
            if(!string.IsNullOrEmpty(Erhebung.Mandant.UisOnlineStudentenLink))
            {
                string url = string.Format("{0}/Stud_Details.aspx?id={1}", Erhebung.Mandant.UisOnlineStudentenLink, Convert.ToInt32(EF6));
                System.Diagnostics.Process.Start(url);
            }
        }

        public void Check()
        {

        }
        #endregion

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
           
        }

    }
}