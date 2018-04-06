namespace ChatAppV9
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtMsg = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtMsgPrep = new System.Windows.Forms.TextBox();
            this.txtReadOnly = new System.Windows.Forms.TextBox();
            this.tblMsgBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.tblMsgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMsgBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblLoginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMsgBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoginBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(284, 237);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(55, 59);
            this.txtMsg.TabIndex = 1;
            this.txtMsg.Text = "&Send";
            this.txtMsg.UseVisualStyleBackColor = true;
            this.txtMsg.Click += new System.EventHandler(this.txtMsg_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(284, 302);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtMsgPrep
            // 
            this.txtMsgPrep.Location = new System.Drawing.Point(12, 237);
            this.txtMsgPrep.MaxLength = 200;
            this.txtMsgPrep.Multiline = true;
            this.txtMsgPrep.Name = "txtMsgPrep";
            this.txtMsgPrep.Size = new System.Drawing.Size(266, 97);
            this.txtMsgPrep.TabIndex = 0;
            // 
            // txtReadOnly
            // 
            this.txtReadOnly.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadOnly.Location = new System.Drawing.Point(12, 12);
            this.txtReadOnly.Multiline = true;
            this.txtReadOnly.Name = "txtReadOnly";
            this.txtReadOnly.ReadOnly = true;
            this.txtReadOnly.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReadOnly.Size = new System.Drawing.Size(327, 219);
            this.txtReadOnly.TabIndex = 3;
            // 
            // tblMsgBindingSource
            // 
            this.tblMsgBindingSource.DataMember = "TblMsg";
            // 
            // tblMsgBindingSource1
            // 
            this.tblMsgBindingSource1.DataMember = "TblMsg";
            // 
            // tblLoginBindingSource
            // 
            this.tblLoginBindingSource.DataMember = "TblLogin";
            // 
            // tblMsgBindingSource2
            // 
            this.tblMsgBindingSource2.DataMember = "TblMsg";
            // 
            // frmMain
            // 
            this.AcceptButton = this.txtMsg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 346);
            this.Controls.Add(this.txtReadOnly);
            this.Controls.Add(this.txtMsgPrep);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtMsg);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messages";
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLoginBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMsgBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button txtMsg;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtMsgPrep;
        private System.Windows.Forms.TextBox txtReadOnly;
       // private ChattAppV9DbDataSet chattAppV9DbDataSet;
        private System.Windows.Forms.BindingSource tblMsgBindingSource;
       // private ChattAppV9DbDataSetTableAdapters.TblMsgTableAdapter tblMsgTableAdapter;
        private System.Windows.Forms.BindingSource tblMsgBindingSource1;
        private System.Windows.Forms.BindingSource tblLoginBindingSource;
        private System.Windows.Forms.BindingSource tblMsgBindingSource2;
        //private System.Windows.Forms.BindingSource chattAppV9DbDataSet11BindingSource;
        //private ChattAppV9DbDataSet1_1 chattAppV9DbDataSet1_1;
        private System.Windows.Forms.BindingSource tblMsgBindingSource3;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}