
namespace CodeFirst.TelefonRehberi.UI
{
    partial class FrmDetayDuzenle
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
            this.lstBilgiListesi = new System.Windows.Forms.ListBox();
            this.txtEklenecekBilgi = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstBilgiListesi
            // 
            this.lstBilgiListesi.FormattingEnabled = true;
            this.lstBilgiListesi.Location = new System.Drawing.Point(12, 32);
            this.lstBilgiListesi.Name = "lstBilgiListesi";
            this.lstBilgiListesi.Size = new System.Drawing.Size(141, 186);
            this.lstBilgiListesi.TabIndex = 0;
            // 
            // txtEklenecekBilgi
            // 
            this.txtEklenecekBilgi.Location = new System.Drawing.Point(173, 59);
            this.txtEklenecekBilgi.Name = "txtEklenecekBilgi";
            this.txtEklenecekBilgi.Size = new System.Drawing.Size(139, 20);
            this.txtEklenecekBilgi.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(205, 97);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(205, 129);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(205, 161);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(75, 23);
            this.btnDuzenle.TabIndex = 4;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Location = new System.Drawing.Point(12, 9);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(35, 13);
            this.lblBaslik.TabIndex = 5;
            this.lblBaslik.Text = "label1";
            // 
            // FrmDetayDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 244);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtEklenecekBilgi);
            this.Controls.Add(this.lstBilgiListesi);
            this.Name = "FrmDetayDuzenle";
            this.Text = "FrmDetayDuzenle";
            this.Load += new System.EventHandler(this.FrmDetayDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBilgiListesi;
        private System.Windows.Forms.TextBox txtEklenecekBilgi;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Label lblBaslik;
    }
}