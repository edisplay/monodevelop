// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Debugger {
    
    
    public partial class ExpressionEvaluatorDialog {
        
        private Gtk.VBox vbox2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Entry entry;
        
        private Gtk.Button buttonEval;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private MonoDevelop.Debugger.ObjectValueTreeView valueTree;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Debugger.ExpressionEvaluatorDialog
            this.Name = "MonoDevelop.Debugger.ExpressionEvaluatorDialog";
            this.Title = Mono.Unix.Catalog.GetString("Expression Evaluator");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.HasSeparator = false;
            // Internal child MonoDevelop.Debugger.ExpressionEvaluatorDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = ((uint)(9));
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.entry = new Gtk.Entry();
            this.entry.CanFocus = true;
            this.entry.Name = "entry";
            this.entry.IsEditable = true;
            this.entry.ActivatesDefault = true;
            this.entry.InvisibleChar = '●';
            this.hbox1.Add(this.entry);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.entry]));
            w2.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.buttonEval = new Gtk.Button();
            this.buttonEval.CanDefault = true;
            this.buttonEval.CanFocus = true;
            this.buttonEval.Name = "buttonEval";
            this.buttonEval.UseUnderline = true;
            this.buttonEval.Label = Mono.Unix.Catalog.GetString("Evaluate");
            this.hbox1.Add(this.buttonEval);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.buttonEval]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.vbox2.Add(this.hbox1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.valueTree = new MonoDevelop.Debugger.ObjectValueTreeView();
            this.valueTree.CanFocus = true;
            this.valueTree.Name = "valueTree";
            this.valueTree.AllowAdding = false;
            this.valueTree.AllowEditing = false;
            this.valueTree.CompactView = false;
            this.GtkScrolledWindow.Add(this.valueTree);
            this.vbox2.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
            w6.Position = 1;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w7.Position = 0;
            // Internal child MonoDevelop.Debugger.ExpressionEvaluatorDialog.ActionArea
            Gtk.HButtonBox w8 = this.ActionArea;
            w8.Name = "dialog1_ActionArea";
            w8.Spacing = 6;
            w8.BorderWidth = ((uint)(5));
            w8.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-close";
            this.AddActionWidget(this.buttonOk, -7);
            Gtk.ButtonBox.ButtonBoxChild w9 = ((Gtk.ButtonBox.ButtonBoxChild)(w8[this.buttonOk]));
            w9.Expand = false;
            w9.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 545;
            this.DefaultHeight = 396;
            this.buttonEval.HasDefault = true;
            this.Show();
            this.buttonEval.Clicked += new System.EventHandler(this.OnButtonEvalClicked);
        }
    }
}
