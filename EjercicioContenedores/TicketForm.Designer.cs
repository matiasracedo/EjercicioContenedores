namespace EjercicioContenedores
{
    partial class TicketForm
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
            this.lBticket = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lBvalores = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lBticket
            // 
            this.lBticket.FormattingEnabled = true;
            this.lBticket.Location = new System.Drawing.Point(3, 4);
            this.lBticket.Name = "lBticket";
            this.lBticket.Size = new System.Drawing.Size(136, 394);
            this.lBticket.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(181, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lBvalores
            // 
            this.lBvalores.FormattingEnabled = true;
            this.lBvalores.Location = new System.Drawing.Point(139, 4);
            this.lBvalores.Name = "lBvalores";
            this.lBvalores.Size = new System.Drawing.Size(136, 394);
            this.lBvalores.TabIndex = 2;
            // 
            // TicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 450);
            this.Controls.Add(this.lBvalores);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lBticket);
            this.Name = "TicketForm";
            this.Text = "TicketForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lBticket;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox lBvalores;
    }
}