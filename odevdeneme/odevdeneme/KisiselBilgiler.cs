using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odevdeneme
{
	class KisiselBilgiler
	{
	 	private string tc;
		public string Tc { get { return tc; } set { tc = value; } }
		private string adi;
		public string Adi { get { return adi; } set { adi = value; } }
		private string soyAdi;
		public string SoyAdi { get { return soyAdi; } set { soyAdi = value; } }
		private int yas;
		public int Yas { get { return yas; } set { yas = value; } }
		private int calismaSuresi;
		public int CalismaSuresi { get { return calismaSuresi; } set { calismaSuresi = value; } }
		private char evlilikDurumu;
		public char EvlilikDurumu { get { return evlilikDurumu; } set { evlilikDurumu = value; } }
		private char esiCalisiyorMu;
		public char EsiCalisiyorMu { get { return esiCalisiyorMu; } set { esiCalisiyorMu = value; } }

		private int cocukSayisi;
		public int CocukSayisi { get { return cocukSayisi; } set { cocukSayisi = value; } }
		private int tabanMaas;
		public int TabanMaas { get { return tabanMaas; } set { tabanMaas = value; } }
		private int makamTazminati;
		public int MakamTazminati { get { return makamTazminati; } set { makamTazminati = value; } }
		private int idariGorevTazminati;
		public int IdariGorevTazminati { get { return idariGorevTazminati; } set { idariGorevTazminati = value; } }
		private int fazlaMesaiSaati;
		public int FazlaMesaiSaati { get { return fazlaMesaiSaati; } set { fazlaMesaiSaati = value; } }
		private int fazlaMesaiSaatUcreti;
		public int FazlaMesaiSaatUcreti { get { return fazlaMesaiSaatUcreti; } set { fazlaMesaiSaatUcreti = value; } }
		private int vergiMatrahi;
		public int VergiMatrahi { get { return vergiMatrahi; } set { vergiMatrahi = value; } }
		private string resimYolu;
		public string ResimYolu { get { return resimYolu; } set { resimYolu = value; } }
		double burutMaas ;
		public double BurutMaas { get { return burutMaas; } set { burutMaas = value; } }
		double damgaVergisi;
		public double DamgaVergisi { get { return damgaVergisi; } set { damgaVergisi = value; } }
		double gelirVergisi;
		public double GelirVergisi { get { return gelirVergisi; } set { gelirVergisi = value; } }
		double emekliKesintisi;
		public double EmekliKesintisi { get { return emekliKesintisi; } set { emekliKesintisi = value; } }
		double netMaas ;
		public double NetMaas { get { return netMaas; } set { netMaas = value; } }

		public void KayitBul(string TC,ref string richTextBox2Text)
		{
			if(TC==tc) // textBox1'e girilen aranan tcnin text dosyasi icinde olup olmadigini kontrol etmek icin
			{
				string s = "";
				s = "" + Adi + " isimli kisinin";
				if (EvlilikDurumu == 'H' || EsiCalisiyorMu == 'E')  //gerekli hesaplamalarin kisinin durumuna gore olmasi icin
				{
					BurutMaas =TabanMaas + MakamTazminati + IdariGorevTazminati + CocukSayisi * 30 + FazlaMesaiSaati * FazlaMesaiSaatUcreti;
					richTextBox2Text = "" + s + "\n BURUT MAASI=" +BurutMaas;
				}
				else
				{
					BurutMaas = TabanMaas +MakamTazminati + IdariGorevTazminati + 200 + CocukSayisi * 30 + FazlaMesaiSaati * FazlaMesaiSaatUcreti;
					richTextBox2Text = "" + s + "\n BURUT MAASI=" + BurutMaas;
				}

				DamgaVergisi = BurutMaas * 10 / 100;

				if (VergiMatrahi < 10000)    // kisinin durumuna gore hesaplamalari dogru yapmak icin
					GelirVergisi =BurutMaas * 15 / 100;
				else if (VergiMatrahi < 20000)
					GelirVergisi = BurutMaas * 20 / 100;
				else if (VergiMatrahi < 30000)
					GelirVergisi = BurutMaas * 25 / 100;
				else
					GelirVergisi = BurutMaas * 30 / 100;

				EmekliKesintisi = BurutMaas * 15 / 100;

				NetMaas = BurutMaas - (EmekliKesintisi + GelirVergisi +DamgaVergisi);

				richTextBox2Text += "" + "\n DAMGA VERGISI=" + DamgaVergisi + "\n GELIR VERGISI=" + GelirVergisi + "\n EMEKLI KESINTISI=" + EmekliKesintisi + "\n NET MAAS=" + NetMaas + "\n RESIM YOLU: " + ResimYolu;

			}
			
		}
		
	}
}
