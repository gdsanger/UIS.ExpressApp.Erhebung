using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UIS.ExpressApp.Erhebung.Module.BusinessObjects;

namespace UIS.ExpressApp.Erhebung.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class Erhebung_Controller : ViewController
    {
        public Erhebung_Controller()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void Export2IDevFile_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace os = View.ObjectSpace;
            BusinessObjects.Erhebung eh = (BusinessObjects.Erhebung)View.CurrentObject;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "CSV Datei (*.csv)|*.csv|Text-Datei (*.txt)|*.txt",
                Title = "Export IDEV Datei",                
                DefaultExt = "csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)            
            {
                StreamWriter wr = File.CreateText(saveFileDialog1.FileName);
                foreach(Erhebungsdaten ed in eh.Erhebungsdaten)
                {
                    string Line;
                    Line = PrepareField(ed.EF1);
                    Line += PrepareField(ed.EF2);
                    Line += PrepareField(ed.EF3);
                    Line += PrepareField(ed.EF4);
                    Line += PrepareField(ed.EF5);
                    Line += PrepareField(ed.EF6);
                    Line += PrepareField(((int)ed.EF7).ToString());
                    Line += PrepareField(ed.EF8U1);
                    Line += PrepareField(ed.EF8U2);
                    Line += PrepareField(ed.EF8U3);
                    Line += PrepareField(ed.EF9);
                    Line += PrepareField(ed.EF10);
                    Line += PrepareField(ed.EF11);
                    Line += PrepareField(ed.EF12U1);
                    Line += PrepareField(ed.EF12U2);
                    Line += PrepareField(ed.EF13U1);
                    Line += PrepareField(ed.EF13U2);
                    Line += PrepareField(ed.EF14);
                    Line += PrepareField(ed.EF15);
                    Line += PrepareField(ed.EF16);
                    Line += PrepareField(ed.EF17);
                    Line += PrepareField(ed.EF18);
                    Line += PrepareField(ed.EF19);
                    Line += PrepareField(ed.EF20);
                    Line += PrepareField(ed.EF21);
                    Line += PrepareField(ed.EF22);
                    Line += PrepareField(ed.EF23);
                    Line += PrepareField(ed.EF24);
                    Line += PrepareField(ed.EF25);
                    Line += PrepareField(ed.EF26);
                    Line += PrepareField(ed.EF27);
                    Line += PrepareField(((int)ed.EF28).ToString());
                    Line += PrepareField(ed.EF29);
                    Line += PrepareField(ed.EF30);
                    Line += PrepareField(((int)ed.EF31).ToString());
                    Line += PrepareField(ed.EF32);
                    Line += PrepareField(ed.EF33);
                    Line += PrepareField(ed.EF34U1);
                    Line += PrepareField(ed.EF34U2);
                    Line += PrepareField(ed.EF35);
                    Line += PrepareField(ed.EF36);
                    Line += PrepareField(ed.EF37);
                    Line += PrepareField(ed.EF38);
                    Line += PrepareField(ed.EF39);
                    Line += PrepareField(ed.EF40);
                    Line += PrepareField(ed.EF41);
                    Line += PrepareField(ed.EF42);
                    Line += PrepareField(ed.EF43);
                    Line += PrepareField(ed.EF44);
                    Line += PrepareField(ed.EF45);
                    Line += PrepareField(ed.EF46);
                    Line += PrepareField(ed.EF47);
                    Line += PrepareField(ed.EF48);
                    Line += PrepareField(ed.EF49);
                    Line += PrepareField(ed.EF50U1);
                    Line += PrepareField(ed.EF50U2);
                    Line += PrepareField(ed.EF51);
                    Line += PrepareField(ed.EF52);
                    Line += PrepareField(ed.EF53);
                    Line += PrepareField(ed.EF54);
                    Line += PrepareField(ed.EF55);
                    Line += PrepareField(ed.EF56);
                    Line += PrepareField(ed.EF57);
                    Line += PrepareField(ed.EF58);
                    Line += PrepareField(ed.EF59);
                    Line += PrepareField(ed.EF60);
                    Line += PrepareField(ed.EF61);
                    Line += PrepareField(ed.EF62);
                    Line += PrepareField(ed.EF63);
                    Line += PrepareField(ed.EF64);
                    Line += PrepareField(ed.EF65);
                    Line += PrepareField(ed.EF66);
                    Line += PrepareField(ed.EF67);
                    Line += PrepareField(ed.EF68);
                    Line += PrepareField(ed.EF69);
                    Line += PrepareField(ed.EF70);
                    Line += PrepareField(ed.EF71);
                    Line += PrepareField(ed.EF72);
                    Line += PrepareField(ed.EF73);
                    Line += PrepareField(ed.EF74);
                    Line += PrepareField(ed.EF75);
                    Line += PrepareField(ed.EF76);
                    Line += PrepareField(ed.EF77);
                    Line += PrepareField(ed.EF78);
                    Line += PrepareField(ed.EF79);
                    Line += PrepareField(ed.EF80);
                    Line += PrepareField(ed.EF81);
                    Line += PrepareField(ed.EF82);
                    Line += PrepareField(ed.EF83);
                    Line += PrepareField(ed.EF84);
                    Line += PrepareField(ed.EF85);
                    Line += PrepareField(ed.EF86);
                    Line += PrepareField(ed.EF87);
                    Line += PrepareField(ed.EF88);
                    Line += PrepareField(ed.EF89);
                    Line += PrepareField(ed.EF90);
                    Line += PrepareField(ed.EF91);
                    Line += PrepareField(ed.EF92);
                    Line += PrepareField(ed.EF93);
                    Line += PrepareField(ed.EF94);
                    Line += PrepareField(ed.EF95);
                    Line += PrepareField(ed.EF96);
                    Line += PrepareField(ed.EF97);
                    Line += PrepareField(ed.EF98);
                    Line += PrepareField(ed.EF99);
                    Line += PrepareField(ed.EF100);
                    Line += PrepareField(ed.EF101);
                    Line += PrepareField(ed.EF102);
                    Line += PrepareField(ed.EF103);
                    Line += PrepareField(ed.EF104);
                    Line += PrepareField(ed.EF105);
                    Line += PrepareField(ed.EF106);
                    Line += PrepareField(ed.EF107);
                    Line += PrepareField(ed.EF108);
                    Line += PrepareField(ed.EF109);
                    Line += PrepareField(ed.EF110);
                    Line += PrepareField(ed.EF111);
                    Line += PrepareField(ed.EF112);
                    Line += PrepareField(ed.EF113);
                    Line += PrepareField(ed.EF114);
                    Line += PrepareField(ed.EF115);
                    Line += PrepareField(ed.EF116);
                    Line += PrepareField(ed.EF117);
                    Line += PrepareField(ed.EF118);
                    Line += PrepareField(ed.EF119U1);
                    Line += PrepareField(ed.EF119U2);
                    Line += PrepareField(ed.EF120);
                    Line += PrepareField(ed.EF121);
                    Line += PrepareField(ed.EF122);
                    Line += PrepareField(ed.EF123);
                    Line += PrepareField(ed.EF124);
                    Line += PrepareField(ed.EF125);
                    Line += PrepareField(ed.EF126);
                    Line += PrepareField(ed.EF127);
                    Line += PrepareField(ed.EF128);
                    Line += PrepareField(ed.EF129);
                    Line += PrepareField(ed.EF130);
                    Line += PrepareField(ed.EF131);
                    Line += PrepareField(ed.EF132);
                    Line += PrepareField(ed.EF133);
                    Line += PrepareField(ed.EF134);
                    Line += PrepareField(ed.EF135);
                    Line += PrepareField(ed.EF136);
                    Line += PrepareField(ed.EF137);
                    Line += PrepareField(ed.EF138);
                    Line += PrepareField(ed.EF139);
                    Line += PrepareField(ed.EF140);
                    Line += PrepareField(ed.EF141);
                    Line += PrepareField(ed.EF142);
                    Line += PrepareField(ed.EF143);
                    Line += PrepareField(ed.EF144);
                    Line += PrepareField(ed.EF145);
                    Line += PrepareField(ed.EF146);
                    Line += PrepareField(ed.EF147);
                    Line += PrepareField(ed.EF148);
                    Line += PrepareField(ed.EF149);
                    Line += PrepareField(ed.EF150);
                    Line += PrepareField(ed.EF151);
                    Line += PrepareField(ed.EF152);
                    Line += PrepareField(ed.EF153);
                    Line += PrepareField(ed.EF154);
                    Line += PrepareField(ed.EF155);
                    Line += PrepareField(ed.EF156);
                    Line += PrepareField(ed.EF157);
                    Line += PrepareField(ed.EF158);
                    Line += PrepareField(ed.EF159);
                    Line += PrepareField(ed.EF160);
                    Line += PrepareField(ed.EF161);
                    Line += PrepareField(ed.EF162);
                    Line += PrepareField(ed.EF163);
                    Line += PrepareField(ed.EF164);
                    Line += PrepareField(ed.EF165);
                    Line += PrepareField(ed.EF166);
                    Line += PrepareField(ed.EF167);
                    Line += PrepareField(ed.EF168);
                    Line += PrepareField(ed.EF169);
                    Line += PrepareField(ed.EF170);
                    Line += PrepareField(ed.EF171);
                    Line += PrepareField(ed.EF172);
                    Line += PrepareField(ed.EF173);
                    Line += PrepareField(ed.EF174);
                    Line += PrepareField(ed.EF175);
                    Line += PrepareField(ed.EF176);
                    Line += PrepareField(ed.EF177);
                    Line += PrepareField(ed.EF178);
                    Line += PrepareField(ed.EF179);
                    Line += PrepareField(ed.EF180);
                    Line += PrepareField(ed.EF181);
                    Line += PrepareField(ed.EF182);
                    Line += PrepareField(ed.EF183);
                    Line += PrepareField(ed.EF184);
                    Line += PrepareField(ed.EF185);
                    Line += PrepareField(ed.EF186);
                    Line += PrepareField(ed.EF187);
                    Line += PrepareField(ed.EF188);
                    Line += PrepareField(ed.EF189);
                    Line += PrepareField(ed.EF190);
                    Line += PrepareField(ed.EF191);
                    Line += PrepareField(ed.EF192);
                    Line += PrepareField(ed.EF193);
                    Line += PrepareField(ed.EF194);
                    Line += PrepareField(ed.EF195);
                    Line += PrepareField(ed.EF196);
                    Line += PrepareField(ed.EF197);
                    Line += PrepareField(ed.EF198);
                    Line += PrepareField(ed.EF199, true);

                    wr.WriteLine(Line);
                }
                wr.Close();
                Function.ShowMessage("Success", "Der Export wurde erfolgreich erstellet", InformationType.Success, Application);
            }
        }

        public string PrepareField(string data, bool Last = false)
        {
            if(Last)
                return string.Format("\"{0}\"", data);
            else
                return string.Format("\"{0}\";", data);
        }
    }
}