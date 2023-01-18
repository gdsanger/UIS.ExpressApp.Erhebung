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
using System.IO;
using System.Linq;
using System.Text;

namespace UIS.ExpressApp.Erhebung.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Erhebung")]
    [XafDisplayName("Erhebung")]
    [XafDefaultProperty("MatchKey")]
    [CreatableItem(false)]

    public class Erhebung : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Erhebung(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        [Association("Mandant-Erhebung")]
        [RuleRequiredField()]
        public Mandanten Mandant
        {
            get { return GetPropertyValue<Mandanten>("Mandant"); }
            set { SetPropertyValue<Mandanten>("Mandant", value); }
        }
        public string MatchKey
        {
            get
            {
                return string.Format("{0} {1} {2}", Berichtsjahr.ToString("0000"), Semester.ToString(), Berichtsart.ToString());
            }
        }
        public Berichtsarten Berichtsart
        {
            get { return GetPropertyValue<Berichtsarten>("Berichtsart"); }
            set { SetPropertyValue<Berichtsarten>("Berichtsart", value); }
        }
        [RuleRequiredField()]
        public int Berichtsjahr
        {
            get { return GetPropertyValue<int>("Berichtsjahr"); }
            set { SetPropertyValue<int>("Berichtsjahr", value); }
        }
        [RuleRequiredField()]
        public BerichtSemester Semester
        {
            get { return GetPropertyValue<BerichtSemester>("Semester"); }
            set { SetPropertyValue<BerichtSemester>("Semester", value); }
        }

        [Association("Erhebung-Erhebungsunterlagen")]
        public XPCollection<Erhebungsdaten> Erhebungsdaten
        {
            get { return GetCollection<Erhebungsdaten>("Erhebungsdaten"); }
        }
        [Association("Erhebung-Fehlerprotokoll")]
        public XPCollection<FehlerProtokoll> FehlerProtokoll
        {
            get { return GetCollection<FehlerProtokoll>("FehlerProtokoll"); }
        }
        public int AnzahlFehler
        {
            get
            {
                return (from Erhebungsdaten ed in Erhebungsdaten select ed.FehlerCount).Sum();
            }
        }

        #region Actions
        [Action(Caption = "Import IDEV Datei", AutoCommit = true)]
        public void ImportIdevFile(ImportFileArgs args)
        {
            
            if(args.File!=null)
            {
                using (MemoryStream s = new MemoryStream())
                {
                    args.File.SaveToStream(s);
                    using (StreamReader sr = new StreamReader(s))
                    {
                        ImportArgs targs = new ImportArgs
                        {
                            ImportData = sr.ReadToEnd()
                        };
                        ImportIdevCSV(targs);
                    }
                }
            }
        }

        [Action(Caption = "Import IDEV CSV", AutoCommit = true)]
        public void ImportIdevCSV(ImportArgs args)
        {
            string[] Lines = args.ImportData.Split(Environment.NewLine.ToCharArray());
            foreach (string Line in Lines)
            {
                if (Line != "")
                {
                    string[] Colums = Line.Split(';');
                    Erhebungsdaten ed = Session.FindObject<Erhebungsdaten>(new GroupOperator(GroupOperatorType.And,
                        new BinaryOperator("EF6", ConvertToString(Colums[5])),
                        new BinaryOperator("Erhebung", this)));
                    if (ed == null)
                    {
                        ed = new Erhebungsdaten(Session);
                        ed.EF6 = ConvertToString(Colums[5]);
                    }
                    ed.EF5 = ConvertToString(Colums[4]);
                    ed.EF6 = ConvertToString(Colums[5]);
                    ed.EF7 = (Geschlechter)Convert.ToInt32(Colums[6]);
                    ed.EF8U1 = ConvertToString(Colums[7]);
                    ed.EF8U2 = ConvertToString(Colums[8]);
                    ed.EF8U3 = ConvertToString(Colums[9]);
                    ed.EF9 = ConvertToString(Colums[10]);
                    ed.EF10 = ConvertToString(Colums[11]);
                    ed.EF11 = ConvertToString(Colums[12]);
                    ed.EF12U1 = ConvertToString(Colums[13]);
                    ed.EF12U2 = ConvertToString(Colums[14]);
                    ed.EF13U1 = ConvertToString(Colums[15]);
                    ed.EF13U2 = ConvertToString(Colums[16]);
                    ed.EF14 = ConvertToString(Colums[17]);
                    ed.EF15 = ConvertToString(Colums[18]);
                    ed.EF16 = ConvertToString(Colums[19]);
                    ed.EF17 = ConvertToString(Colums[20]);
                    ed.EF18 = ConvertToString(Colums[21]);
                    ed.EF19 = ConvertToString(Colums[22]);
                    ed.EF20 = ConvertToString(Colums[23]);
                    ed.EF21 = ConvertToString(Colums[24]);
                    ed.EF22 = ConvertToString(Colums[25]);
                    ed.EF23 = ConvertToString(Colums[26]);
                    ed.EF24 = ConvertToString(Colums[27]);
                    ed.EF25 = ConvertToString(Colums[28]);
                    ed.EF26 = ConvertToString(Colums[29]);
                    ed.EF27 = ConvertToString(Colums[30]);
                    ed.EF28 = (EinschreibungsArt)Convert.ToInt32((Colums[31]));
                    ed.EF29 = ConvertToString(Colums[32]);
                    ed.EF30 = ConvertToString(Colums[33]);
                    ed.EF31 = (Studienart)Convert.ToInt32((Colums[34]));
                    ed.EF32 = ConvertToString(Colums[35]);
                    ed.EF33 = ConvertToString(Colums[36]);
                    ed.EF34U1 = ConvertToString(Colums[37]);
                    ed.EF34U2 = ConvertToString(Colums[38]);
                    ed.EF35 = ConvertToString(Colums[39]);
                    ed.EF36 = ConvertToString(Colums[40]);
                    ed.EF37 = ConvertToString(Colums[41]);
                    ed.EF38 = ConvertToString(Colums[42]);
                    ed.EF39 = ConvertToString(Colums[43]);
                    ed.EF40 = ConvertToString(Colums[44]);
                    ed.EF41 = ConvertToString(Colums[45]);
                    ed.EF42 = ConvertToString(Colums[46]);
                    ed.EF43 = ConvertToString(Colums[47]);
                    ed.EF44 = ConvertToString(Colums[48]);
                    ed.EF45 = ConvertToString(Colums[49]);
                    ed.EF46 = ConvertToString(Colums[50]);
                    ed.EF47 = ConvertToString(Colums[51]);
                    ed.EF48 = ConvertToString(Colums[52]);
                    ed.EF49 = ConvertToString(Colums[53]);
                    ed.EF50U1 = ConvertToString(Colums[54]);
                    ed.EF50U2 = ConvertToString(Colums[55]);
                    ed.EF51 = ConvertToString(Colums[56]);
                    ed.EF52 = ConvertToString(Colums[57]);
                    ed.EF53 = ConvertToString(Colums[58]);
                    ed.EF54 = ConvertToString(Colums[59]);
                    ed.EF55 = ConvertToString(Colums[60]);
                    ed.EF56 = ConvertToString(Colums[61]);
                    ed.EF57 = ConvertToString(Colums[62]);
                    ed.EF58 = ConvertToString(Colums[63]);
                    ed.EF59 = ConvertToString(Colums[64]);
                    ed.EF60 = ConvertToString(Colums[65]);
                    ed.EF61 = ConvertToString(Colums[66]);
                    ed.EF62 = ConvertToString(Colums[67]);
                    ed.EF63 = ConvertToString(Colums[68]);
                    ed.EF64 = ConvertToString(Colums[69]);
                    ed.EF65 = ConvertToString(Colums[70]);
                    ed.EF66 = ConvertToString(Colums[71]);
                    ed.EF67 = ConvertToString(Colums[72]);
                    ed.EF68 = ConvertToString(Colums[73]);
                    ed.EF69 = ConvertToString(Colums[74]);
                    ed.EF70 = ConvertToString(Colums[75]);
                    ed.EF71 = ConvertToString(Colums[76]);
                    ed.EF72 = ConvertToString(Colums[77]);
                    ed.EF73 = ConvertToString(Colums[78]);
                    ed.EF74 = ConvertToString(Colums[79]);
                    ed.EF75 = ConvertToString(Colums[80]);
                    ed.EF76 = ConvertToString(Colums[81]);
                    ed.EF77 = ConvertToString(Colums[82]);
                    ed.EF78 = ConvertToString(Colums[83]);
                    ed.EF79 = ConvertToString(Colums[84]);
                    ed.EF80 = ConvertToString(Colums[85]);
                    ed.EF81 = ConvertToString(Colums[86]);
                    ed.EF82 = ConvertToString(Colums[87]);
                    ed.EF83 = ConvertToString(Colums[88]);
                    ed.EF84 = ConvertToString(Colums[89]);
                    ed.EF85 = ConvertToString(Colums[90]);
                    ed.EF86 = ConvertToString(Colums[91]);
                    ed.EF87 = ConvertToString(Colums[92]);
                    ed.EF88 = ConvertToString(Colums[93]);
                    ed.EF89 = ConvertToString(Colums[94]);
                    ed.EF90 = ConvertToString(Colums[95]);
                    ed.EF91 = ConvertToString(Colums[96]);
                    ed.EF92 = ConvertToString(Colums[97]);
                    ed.EF93 = ConvertToString(Colums[98]);
                    ed.EF94 = ConvertToString(Colums[99]);
                    ed.EF95 = ConvertToString(Colums[100]);
                    ed.EF96 = ConvertToString(Colums[101]);
                    ed.EF97 = ConvertToString(Colums[102]);
                    ed.EF98 = ConvertToString(Colums[103]);
                    ed.EF99 = ConvertToString(Colums[104]);
                    ed.EF100 = ConvertToString(Colums[105]);
                    ed.EF101 = ConvertToString(Colums[106]);
                    ed.EF102 = ConvertToString(Colums[107]);
                    ed.EF103 = ConvertToString(Colums[108]);
                    ed.EF104 = ConvertToString(Colums[109]);
                    ed.EF105 = ConvertToString(Colums[110]);
                    ed.EF106 = ConvertToString(Colums[111]);
                    ed.EF107 = ConvertToString(Colums[112]);
                    ed.EF108 = ConvertToString(Colums[113]);
                    ed.EF109 = ConvertToString(Colums[114]);
                    ed.EF110 = ConvertToString(Colums[115]);
                    ed.EF111 = ConvertToString(Colums[116]);
                    ed.EF112 = ConvertToString(Colums[117]);
                    ed.EF113 = ConvertToString(Colums[118]);
                    ed.EF114 = ConvertToString(Colums[119]);
                    ed.EF115 = ConvertToString(Colums[120]);
                    ed.EF116 = ConvertToString(Colums[121]);
                    ed.EF117 = ConvertToString(Colums[122]);
                    ed.EF118 = ConvertToString(Colums[123]);
                    ed.EF119U1 = ConvertToString(Colums[124]);
                    ed.EF119U2 = ConvertToString(Colums[125]);
                    ed.EF120 = ConvertToString(Colums[126]);
                    ed.EF121 = ConvertToString(Colums[127]);
                    ed.EF122 = ConvertToString(Colums[128]);
                    ed.EF123 = ConvertToString(Colums[129]);
                    ed.EF124 = ConvertToString(Colums[130]);
                    ed.EF125 = ConvertToString(Colums[131]);
                    ed.EF126 = ConvertToString(Colums[132]);
                    ed.EF127 = ConvertToString(Colums[133]);
                    ed.EF128 = ConvertToString(Colums[134]);
                    ed.EF129 = ConvertToString(Colums[135]);
                    ed.EF130 = ConvertToString(Colums[136]);
                    ed.EF131 = ConvertToString(Colums[137]);
                    ed.EF132 = ConvertToString(Colums[138]);
                    ed.EF133 = ConvertToString(Colums[139]);
                    ed.EF134 = ConvertToString(Colums[140]);
                    ed.EF135 = ConvertToString(Colums[141]);
                    ed.EF136 = ConvertToString(Colums[142]);
                    ed.EF137 = ConvertToString(Colums[143]);
                    ed.EF138 = ConvertToString(Colums[144]);
                    ed.EF139 = ConvertToString(Colums[145]);
                    ed.EF140 = ConvertToString(Colums[146]);
                    ed.EF141 = ConvertToString(Colums[147]);
                    ed.EF142 = ConvertToString(Colums[148]);
                    ed.EF143 = ConvertToString(Colums[149]);
                    ed.EF144 = ConvertToString(Colums[150]);
                    ed.EF145 = ConvertToString(Colums[151]);
                    ed.EF146 = ConvertToString(Colums[152]);
                    ed.EF147 = ConvertToString(Colums[153]);
                    ed.EF148 = ConvertToString(Colums[154]);
                    ed.EF149 = ConvertToString(Colums[155]);
                    ed.EF150 = ConvertToString(Colums[156]);
                    ed.EF151 = ConvertToString(Colums[157]);
                    ed.EF152 = ConvertToString(Colums[158]);
                    ed.EF153 = ConvertToString(Colums[159]);
                    ed.EF154 = ConvertToString(Colums[160]);
                    ed.EF155 = ConvertToString(Colums[161]);
                    ed.EF156 = ConvertToString(Colums[162]);
                    ed.EF157 = ConvertToString(Colums[163]);
                    ed.EF158 = ConvertToString(Colums[164]);
                    ed.EF159 = ConvertToString(Colums[165]);
                    ed.EF160 = ConvertToString(Colums[166]);
                    ed.EF161 = ConvertToString(Colums[167]);
                    ed.EF162 = ConvertToString(Colums[168]);
                    ed.EF163 = ConvertToString(Colums[169]);
                    ed.EF164 = ConvertToString(Colums[170]);
                    ed.EF165 = ConvertToString(Colums[171]);
                    ed.EF166 = ConvertToString(Colums[172]);
                    ed.EF167 = ConvertToString(Colums[173]);
                    ed.EF168 = ConvertToString(Colums[174]);
                    ed.EF169 = ConvertToString(Colums[175]);
                    ed.EF170 = ConvertToString(Colums[176]);
                    ed.EF171 = ConvertToString(Colums[177]);
                    ed.EF172 = ConvertToString(Colums[178]);
                    ed.EF173 = ConvertToString(Colums[179]);
                    ed.EF174 = ConvertToString(Colums[180]);
                    ed.EF175 = ConvertToString(Colums[181]);
                    ed.EF176 = ConvertToString(Colums[182]);
                    ed.EF177 = ConvertToString(Colums[183]);
                    ed.EF178 = ConvertToString(Colums[184]);
                    ed.EF179 = ConvertToString(Colums[185]);
                    ed.EF180 = ConvertToString(Colums[186]);
                    ed.EF181 = ConvertToString(Colums[187]);
                    ed.EF182 = ConvertToString(Colums[188]);
                    ed.EF183 = ConvertToString(Colums[189]);
                    ed.EF184 = ConvertToString(Colums[190]);
                    ed.EF185 = ConvertToString(Colums[191]);
                    ed.EF186 = ConvertToString(Colums[192]);
                    ed.EF187 = ConvertToString(Colums[193]);
                    ed.EF188 = ConvertToString(Colums[194]);
                    ed.EF189 = ConvertToString(Colums[195]);
                    ed.EF190 = ConvertToString(Colums[196]);
                    ed.EF191 = ConvertToString(Colums[197]);
                    ed.EF192 = ConvertToString(Colums[198]);
                    ed.EF193 = ConvertToString(Colums[199]);
                    ed.EF194 = ConvertToString(Colums[200]);
                    ed.EF195 = ConvertToString(Colums[201]);
                    ed.EF196 = ConvertToString(Colums[202]);
                    ed.EF197 = ConvertToString(Colums[203]);
                    ed.EF198 = ConvertToString(Colums[204]);
                    ed.EF199 = ConvertToString(Colums[205]);
                    Erhebungsdaten.Add(ed);
                    Session.Save(ed);
                }
            }
        }

        public string ConvertToString(string text)
        {
            return text.Replace("\"", "");
        }
        [Action(Caption = "Reset", AutoCommit = true, ConfirmationMessage ="Wollen Sie die Erhebung wirklich zurücksetzten? Es werden alle Daten in dieser Erhebung gelöscht!", ImageName = "Action_Clear")]
        public void Reset()
        {
            Session.ExecuteNonQuery("Delete from FehlerProtokoll where Erhebung='" + Oid + "'");
            Session.ExecuteNonQuery("Delete from Erhebungsdaten where Erhebung='" + Oid + "'");
        }

        public void ExportIdevCsv()
        {
            


        }

        [Action(Caption ="Daten prüfen", AutoCommit =true, ImageName = "Action_Validation_Validate")]
        public void CheckData()
        {
            XPCollection<PlPrüfungen> Prüfungen = new XPCollection<PlPrüfungen>(Session, new BinaryOperator("Aktiv", true));
            Session.ExecuteNonQuery("Delete from FehlerProtokoll where Erhebung='" + Oid + "'");
            foreach(PlPrüfungen plp in Prüfungen)
            {
                string sqlCommand;
                if (!string.IsNullOrEmpty(plp.Prüfbedingung))
                {
                    sqlCommand = string.Format("Insert Into FehlerProtokoll(Oid, Erhebung, Erhebungsdaten, Prüfung) Select NewId(), Erhebung, Oid, '{0}' from Erhebungsdaten where Erhebung = '{1}' and {2}", plp.Oid, Oid, plp.Prüfbedingung);
                    sqlCommand = sqlCommand.Replace("[EF1]", Mandant.Berichtsland);
                    sqlCommand = sqlCommand.Replace("[EF2]", ((int)Semester).ToString());
                    sqlCommand = sqlCommand.Replace("[EF3]", Berichtsjahr.ToString());
                    sqlCommand = sqlCommand.Replace("[EF4]", Mandant.KeyHochschule);

                }
                else
                {
                    sqlCommand = plp.CustomSqlCommand;
                    sqlCommand = sqlCommand.Replace("[Prüfung]", plp.Oid.ToString());
                    sqlCommand = sqlCommand.Replace("[Erhebung]", Oid.ToString());
                    sqlCommand = sqlCommand.Replace("[EF1]", Mandant.Berichtsland);
                    sqlCommand = sqlCommand.Replace("[EF2]", ((int)Semester).ToString());
                    sqlCommand = sqlCommand.Replace("[EF3]", Berichtsjahr.ToString());
                    sqlCommand = sqlCommand.Replace("[EF4]", Mandant.KeyHochschule);

                }
                if(!string.IsNullOrEmpty(sqlCommand))
                {
                    Session.ExecuteNonQuery(sqlCommand);
                }
            }
        }
        #endregion
        [NonPersistent]
        public class ImportFileArgs
        {
            public FileData File { get; set; }
        }
    }
}