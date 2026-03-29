namespace Interfaz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelheader = new Panel();
            buttonIniciar = new Button();
            labelTítulo = new Label();
            panelAmbiente = new Panel();
            panelIzquierda = new Panel();
            panelheader.SuspendLayout();
            panelAmbiente.SuspendLayout();
            SuspendLayout();
            // 
            // panelheader
            // 
            panelheader.BackColor = SystemColors.AppWorkspace;
            panelheader.Controls.Add(buttonIniciar);
            panelheader.Controls.Add(labelTítulo);
            panelheader.Location = new Point(-2, 1);
            panelheader.Name = "panelheader";
            panelheader.Size = new Size(986, 99);
            panelheader.TabIndex = 0;
            // 
            // buttonIniciar
            // 
            buttonIniciar.Cursor = Cursors.Hand;
            buttonIniciar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonIniciar.Location = new Point(839, 34);
            buttonIniciar.Name = "buttonIniciar";
            buttonIniciar.Size = new Size(99, 40);
            buttonIniciar.TabIndex = 1;
            buttonIniciar.Text = "Iniciar";
            buttonIniciar.UseVisualStyleBackColor = true;
            buttonIniciar.Click += buttonIniciar_Click;
            // 
            // labelTítulo
            // 
            labelTítulo.AutoSize = true;
            labelTítulo.Font = new Font("Nirmala UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTítulo.Location = new Point(14, 20);
            labelTítulo.Name = "labelTítulo";
            labelTítulo.Size = new Size(204, 54);
            labelTítulo.TabIndex = 0;
            labelTítulo.Text = "Semáforo";
            // 
            // panelAmbiente
            // 
            panelAmbiente.BackColor = Color.FromArgb(0, 192, 0);
            panelAmbiente.Controls.Add(panelIzquierda);
            panelAmbiente.Location = new Point(-2, 96);
            panelAmbiente.Name = "panelAmbiente";
            panelAmbiente.Size = new Size(986, 670);
            panelAmbiente.TabIndex = 1;
            // 
            // panelIzquierda
            // 
            panelIzquierda.BackColor = Color.FromArgb(64, 64, 64);
            panelIzquierda.Location = new Point(3, 260);
            panelIzquierda.Name = "panelIzquierda";
            panelIzquierda.Size = new Size(348, 150);
            panelIzquierda.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(panelAmbiente);
            Controls.Add(panelheader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelheader.ResumeLayout(false);
            panelheader.PerformLayout();
            panelAmbiente.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelheader;
        private Label labelTítulo;
        private Button buttonIniciar;
        private Panel panelAmbiente;
        private Panel panelIzquierda;
    }
}
