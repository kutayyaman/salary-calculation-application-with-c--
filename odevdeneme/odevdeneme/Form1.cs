
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace odevdeneme
{
	public partial class Form1 : Form
	{
		Button bTextOku;
		RichTextBox richTextBox1;
		RichTextBox richTextBox2;
		OpenFileDialog openFileDialog1;
		SaveFileDialog saveFileDialog1;
		Label label1;
		TextBox textBox1;
		Button bSorgula;
		KisiselBilgiler[] kayitliKisiler;


		public Form1()
		{
			kayitliKisiler = new KisiselBilgiler[500];
			this.Text = "1. ODEV";
			this.Width = 750;
			this.Height = 530;

			bTextOku = new Button();
			richTextBox1 = new RichTextBox();
			richTextBox2 = new RichTextBox();
			openFileDialog1 = new OpenFileDialog();
			saveFileDialog1 = new SaveFileDialog();
			label1 = new Label();
			textBox1 = new TextBox();
			bSorgula = new Button();

			bTextOku.Text = "TEXT OKU";
			bTextOku.Top = 150;
			bTextOku.Left = 500;

			this.Controls.Add(bTextOku);

			richTextBox1.Top = 10;
			richTextBox1.Left = 10;
			richTextBox1.Width = 490;
			richTextBox1.Height = 300;

			this.Controls.Add(richTextBox1);

			richTextBox2.Top = 350;
			richTextBox2.Left = 10;
			richTextBox2.Width = 490;
			richTextBox2.Height = 120;

			this.Controls.Add(richTextBox2);

			label1.Top = 320;
			label1.Left = 10;
			label1.Width = 30;
			label1.Text = "TC";

			this.Controls.Add(label1);

			textBox1.Top = 320;
			textBox1.Left = 50;

			this.Controls.Add(textBox1);


			bSorgula.Top = 320;
			bSorgula.Left = 170;
			bSorgula.Text = "SORGULA";

			this.Controls.Add(bSorgula);

			bTextOku.Click += BTextOku_Click;
			bSorgula.Click += BSorgula_Click;
			textBox1.KeyPress += TextBox1_KeyPress;
		}

		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			// 48 57 8
			int x = Convert.ToInt32(e.KeyChar);
			if ((x <= 57 && x >= 48) || x == 8) // tc sayı dışında bir şey olamayacagı icin sayı dışında karakter girişini yasaklamak icin
			{                                   // ayrıca backspace tusuna basarak yazdiğini silebilmesi icin kosullar
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
				MessageBox.Show("SAYI GIRINIZ", "uygun olmayan karakter", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void BSorgula_Click(object sender, EventArgs e)
		{
			
			int i = 0; //foreach dongusunun icinde kayitli kisileri tek tek atayabilmek icin
			if (textBox1.Text != "")  //bos olup olmadıgını kontrol etmek icin
			{
				string[] satirlar = null;
				
		
				string hepsi = richTextBox1.Text;

				satirlar = hepsi.Split('\n');
				string[] kontrol = satirlar[0].Split(' ');
				if (kontrol.Length == 15)
				{
					foreach (string s in satirlar)
					{
						string[] kelimeler = s.Split(' ');

						kayitliKisiler[i] = new KisiselBilgiler();               //butun calisanlarin bilgisini tutmus olmak icin
						kayitliKisiler[i].Tc = Convert.ToString(kelimeler[0]);
						kayitliKisiler[i].Adi = Convert.ToString(kelimeler[1]);
						kayitliKisiler[i].SoyAdi = Convert.ToString(kelimeler[2]);
						kayitliKisiler[i].Yas = Convert.ToInt32(kelimeler[3]);
						kayitliKisiler[i].CalismaSuresi = Convert.ToInt32(kelimeler[4]);
						kayitliKisiler[i].EvlilikDurumu = Convert.ToChar(kelimeler[5]);
						kayitliKisiler[i].EsiCalisiyorMu = Convert.ToChar(kelimeler[6]);
						kayitliKisiler[i].CocukSayisi = Convert.ToInt32(kelimeler[7]);
						kayitliKisiler[i].TabanMaas = Convert.ToInt32(kelimeler[8]);
						kayitliKisiler[i].MakamTazminati = Convert.ToInt32(kelimeler[9]);
						kayitliKisiler[i].IdariGorevTazminati = Convert.ToInt32(kelimeler[10]);
						kayitliKisiler[i].FazlaMesaiSaati = Convert.ToInt32(kelimeler[11]);
						kayitliKisiler[i].FazlaMesaiSaatUcreti = Convert.ToInt32(kelimeler[12]);
						kayitliKisiler[i].VergiMatrahi = Convert.ToInt32(kelimeler[13]);
						kayitliKisiler[i].ResimYolu = Convert.ToString(kelimeler[14]);

						i++;
					}
				}
				else
				{
					MessageBox.Show("DOGRU TEXTI OKUMADINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				string richTextBox2Text = "";
				for(int j=0;j<i;j++)
				{
					kayitliKisiler[j].KayitBul(textBox1.Text, ref richTextBox2Text);
				}
				richTextBox2.Text = richTextBox2Text;
				if(richTextBox2Text=="") //yani KayitBul metodu hala richTextBox2Text stringini degistirmediyse kayit bulunamamistir
				{
					MessageBox.Show("Aradıgnız Kayıt Bulunamadi", "BULUNAMADI", MessageBoxButtons.OK,MessageBoxIcon.Error);
				}

			}
			else //121. satirdaki if' in else si yani bos birakildiysa calisacak
			{
				MessageBox.Show("ARAMAK ISTEDIGNIZ TCYI GIRIN", "BOS BIRAKTINIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			
		}

		private void BTextOku_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
			}


		}
	}
}
