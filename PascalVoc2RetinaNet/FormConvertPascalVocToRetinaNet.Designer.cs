namespace PascalVoc2RetinaNet
{
    partial class FormConvertPascalVocToRetinaNet
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
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.buttonSaveAsRetinaNetFormat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Location = new System.Drawing.Point(11, 10);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(639, 507);
            this.listViewFiles.TabIndex = 8;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragEnter);
            this.listViewFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewFiles_KeyDown);
            // 
            // buttonSaveAsRetinaNetFormat
            // 
            this.buttonSaveAsRetinaNetFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveAsRetinaNetFormat.Location = new System.Drawing.Point(11, 528);
            this.buttonSaveAsRetinaNetFormat.Name = "buttonSaveAsRetinaNetFormat";
            this.buttonSaveAsRetinaNetFormat.Size = new System.Drawing.Size(639, 31);
            this.buttonSaveAsRetinaNetFormat.TabIndex = 7;
            this.buttonSaveAsRetinaNetFormat.Text = "Save As RetinaNet Format";
            this.buttonSaveAsRetinaNetFormat.UseVisualStyleBackColor = true;
            this.buttonSaveAsRetinaNetFormat.Click += new System.EventHandler(this.buttonSaveAsRetinaNetFormat_Click);
            // 
            // ConvertPascalVocToRetinaNetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 570);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.buttonSaveAsRetinaNetFormat);
            this.Name = "ConvertPascalVocToRetinaNetForm";
            this.Text = "ConvertPascalVocToRetinaNetForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.Button buttonSaveAsRetinaNetFormat;
    }
}