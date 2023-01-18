using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIS.ExpressApp.Erhebung.Module.BusinessObjects
{
    public enum Berichtsland
    {

    }

    public enum BerichtSemester
    {
        Sommersemester = 1,
        Wintersemetser = 2
    }

    public enum Berichtsarten
    {
        Studierendenstatistk = 1,
        Prüfungsstatistik = 2
    }

    public enum Geschlechter
    {
        männlich = 1,
        weiblich = 2,
        divers = 3,
        ohneAngabe = 4
    }
    public enum Staatsangehörigkeit
    {
        Deutsche=0,
        Ausländer=1
     }
    public enum EinschreibungsArt
    {
        Ersteinschreibung=1,
        Neueinschreibung=2,
        Rückmeldung=3,
        Beurlaubung=4,
        Exmatrikulation=5,
        FrühereExmatrikulation=6
    }
    public enum Studienart
    {
        Vollzeit=1,
        Teilzeit=2,

    }
    public enum Prüfungsart
    {
        [XafDisplayName("Stufe 1 (Mussfehler, Technisch)")]
        Stufe1=1,
        [XafDisplayName("Stufe 2 (Mussfehler, Inhaltlich)")]
        Stufe2 =2,
        [XafDisplayName("Stufe 3 (meist Mussfehler, Problem-Hinweise)")]
        Stufe3 =3,
        [XafDisplayName("Stufe 4 (Kannfehler, Problem-Hinweise)")]
        Stufe4 = 4,
        [XafDisplayName("Stufe 5 (Kannfehler, Auffälligkeiten)")]
        Stufe5 = 5,
    }
}
