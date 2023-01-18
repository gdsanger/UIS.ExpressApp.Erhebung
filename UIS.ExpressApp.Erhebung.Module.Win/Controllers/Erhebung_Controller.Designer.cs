
namespace UIS.ExpressApp.Erhebung.Module.Win.Controllers
{
    partial class Erhebung_Controller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Export2IDevFile = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // Export2IDevFile
            // 
            this.Export2IDevFile.Caption = "Export  Idev Datei";
            this.Export2IDevFile.Category = "RecordEdit";
            this.Export2IDevFile.ConfirmationMessage = null;
            this.Export2IDevFile.Id = "Export2IDevFile";
            this.Export2IDevFile.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.Export2IDevFile.TargetObjectType = typeof(UIS.ExpressApp.Erhebung.Module.BusinessObjects.Erhebung);
            this.Export2IDevFile.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.Export2IDevFile.ToolTip = null;
            this.Export2IDevFile.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.Export2IDevFile.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.Export2IDevFile_Execute);
            // 
            // Erhebung_Controller
            // 
            this.Actions.Add(this.Export2IDevFile);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction Export2IDevFile;
    }
}
