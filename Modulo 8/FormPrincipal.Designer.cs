namespace Modulo_8
{
    partial class FormPrincipal
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
            btnComando = new Button();
            groupBox1 = new GroupBox();
            lbStatus = new Label();
            txbComando = new TextBox();
            pbGrafico = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).BeginInit();
            SuspendLayout();
            // 
            // btnComando
            // 
            btnComando.Location = new Point(695, 22);
            btnComando.Name = "btnComando";
            btnComando.Size = new Size(75, 23);
            btnComando.TabIndex = 0;
            btnComando.Text = "Enviar";
            btnComando.UseVisualStyleBackColor = true;
            btnComando.Click += btnComando_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbStatus);
            groupBox1.Controls.Add(txbComando);
            groupBox1.Controls.Add(btnComando);
            groupBox1.Location = new Point(12, 361);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 77);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Comandos";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            lbStatus.Location = new Point(6, 49);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(0, 21);
            lbStatus.TabIndex = 2;
            // 
            // txbComando
            // 
            txbComando.Location = new Point(6, 23);
            txbComando.Name = "txbComando";
            txbComando.Size = new Size(683, 23);
            txbComando.TabIndex = 1;
            // 
            // pbGrafico
            // 
            pbGrafico.Location = new Point(12, 12);
            pbGrafico.Name = "pbGrafico";
            pbGrafico.Size = new Size(776, 343);
            pbGrafico.TabIndex = 2;
            pbGrafico.TabStop = false;
            // 
            // FormPrincipal
            // 
            AcceptButton = btnComando;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbGrafico);
            Controls.Add(groupBox1);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Módulo 8 - Ferramentas de Versionamento";
            Load += FormPrincipal_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbGrafico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnComando;
        private GroupBox groupBox1;
        private Label lbStatus;
        private TextBox txbComando;
        private PictureBox pbGrafico;
    }
}