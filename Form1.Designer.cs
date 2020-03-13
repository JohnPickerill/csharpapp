namespace restClient
{
    partial class Form1
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
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.btnTitles = new System.Windows.Forms.Button();
            this.btnVersions = new System.Windows.Forms.Button();
            this.btnObject = new System.Windows.Forms.Button();
            this.btnObjects = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.bPG = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbResponse
            // 
            this.tbResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResponse.Location = new System.Drawing.Point(27, 88);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResponse.Size = new System.Drawing.Size(159, 287);
            this.tbResponse.TabIndex = 1;
            // 
            // btnTitles
            // 
            this.btnTitles.Location = new System.Drawing.Point(27, 22);
            this.btnTitles.Name = "btnTitles";
            this.btnTitles.Size = new System.Drawing.Size(75, 23);
            this.btnTitles.TabIndex = 2;
            this.btnTitles.Text = "Titles";
            this.btnTitles.UseVisualStyleBackColor = true;
            this.btnTitles.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnVersions
            // 
            this.btnVersions.Location = new System.Drawing.Point(146, 22);
            this.btnVersions.Name = "btnVersions";
            this.btnVersions.Size = new System.Drawing.Size(75, 23);
            this.btnVersions.TabIndex = 3;
            this.btnVersions.Text = "Versions";
            this.btnVersions.UseVisualStyleBackColor = true;
            this.btnVersions.Click += new System.EventHandler(this.btnVersions_Click);
            // 
            // btnObject
            // 
            this.btnObject.Location = new System.Drawing.Point(413, 21);
            this.btnObject.Name = "btnObject";
            this.btnObject.Size = new System.Drawing.Size(75, 23);
            this.btnObject.TabIndex = 4;
            this.btnObject.Text = "Object";
            this.btnObject.UseVisualStyleBackColor = true;
            this.btnObject.Click += new System.EventHandler(this.btnObject_Click);
            // 
            // btnObjects
            // 
            this.btnObjects.Location = new System.Drawing.Point(282, 21);
            this.btnObjects.Name = "btnObjects";
            this.btnObjects.Size = new System.Drawing.Size(75, 23);
            this.btnObjects.TabIndex = 5;
            this.btnObjects.Text = "Objects";
            this.btnObjects.UseVisualStyleBackColor = true;
            this.btnObjects.Click += new System.EventHandler(this.btnObjects_Click_1);
            // 
            // imageBox
            // 
            this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(213, 88);
            this.imageBox.MaximumSize = new System.Drawing.Size(180, 280);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(51, 280);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 6;
            this.imageBox.TabStop = false;
            // 
            // btnImage
            // 
            this.btnImage.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnImage.Location = new System.Drawing.Point(657, 21);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 7;
            this.btnImage.Text = "image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // bPG
            // 
            this.bPG.Location = new System.Drawing.Point(521, 22);
            this.bPG.Name = "bPG";
            this.bPG.Size = new System.Drawing.Size(75, 23);
            this.bPG.TabIndex = 8;
            this.bPG.Text = "PG";
            this.bPG.UseVisualStyleBackColor = true;
            this.bPG.Click += new System.EventHandler(this.bPG_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bPG);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.btnObjects);
            this.Controls.Add(this.btnObject);
            this.Controls.Add(this.btnVersions);
            this.Controls.Add(this.btnTitles);
            this.Controls.Add(this.tbResponse);
            this.Name = "Form1";
            this.Text = "Rest Client";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion
    private System.Windows.Forms.TextBox tbResponse;
    private System.Windows.Forms.Button btnTitles;
        private System.Windows.Forms.Button btnVersions;
        private System.Windows.Forms.Button btnObject;
        private System.Windows.Forms.Button btnObjects;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button bPG;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        }
}

