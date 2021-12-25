using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DersKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string okunan;
        public int zorunluAkts;
        public int secmeliAkts;
        public int toplamAkts;

        void clearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox8.Text = "";
            radioButton1.Checked = true;
            radioButton8.Checked = true;
            radioButton9.Checked = true;
            radioButton4.Checked = true;
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
            zorunluAkts = 0;
            secmeliAkts = 0;
            label11.Text = "0";
            label12.Text = "0";
            label32.Text = "";
            label33.Text = "";
            label34.Text = "";
        }
        void dersGuncelle()
        {
            StreamReader Reader;
            Reader = File.OpenText(@"..\..\zorunludersler.txt");
            while ((okunan = Reader.ReadLine()) != null)
            {
                checkedListBox1.Items.Add(okunan);
            }
            Reader.Close();

            Reader = File.OpenText(@"..\..\secmelidersler.txt");
            while ((okunan = Reader.ReadLine()) != null)
            {
                checkedListBox2.Items.Add(okunan);
            }
            Reader.Close();
        }

        void zorunluYazdir()
        {
            string[] item;
            item = new string[checkedListBox1.Items.Count];//eleman dizisinin boyutunu belirleyelim.
            TextWriter writer = new StreamWriter("..\\..\\zorunludersler.txt");//TextWriter sınıfından yeni bir yazici adlı nesne üretelim ve klasor yolunu streamWriter içine yazalım.
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                item[i] = checkedListBox1.Items[i].ToString();//diziye listboxtaki elemanları tek tek atalım.
                writer.WriteLine(item[i]);//txt dosyasına yazdırıp sırayla bir satır aşağı indirelim
            }
            writer.Flush();//txt metnine tüm verileri gömelim.
            writer.Close();// son olarak nesnemizi kapatalım.
        }

        void secmeliYazdir()
        {
            string[] item;
            item = new string[checkedListBox2.Items.Count];//eleman dizisinin boyutunu belirleyelim.
            TextWriter writer = new StreamWriter("..\\..\\secmelidersler.txt");//TextWriter sınıfından yeni bir yazici adlı nesne üretelim ve klasor yolunu streamWriter içine yazalım.
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                item[i] = checkedListBox2.Items[i].ToString();//diziye listboxtaki elemanları tek tek atalım.
                writer.WriteLine(item[i]);//txt dosyasına yazdırıp sırayla bir satır aşağı indirelim
            }
            writer.Flush();//txt metnine tüm verileri gömelim.
            writer.Close();// son olarak nesnemizi kapatalım.
        }
        void tBoxKontrol(int tur, TextBox input)
        {
            if (tur==0) //Sadece Sayı
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(input.Text, "^[0-9]+$"))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    if (input.Text.Length == 0)
                    {
                        input.Text = "";
                    }
                    else
                    {
                        input.Text = input.Text.Remove(input.Text.Length - 1);
                    }
                    input.Focus();
                    input.SelectionStart = input.Text.Length;
                }
            }
            else if (tur==1) //Sadece Yazı
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(input.Text, "^[a-zA-Z_ğüşıöçĞÜŞİÖÇ ]+$"))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    if (input.Text.Length==0)
                    {
                        input.Text = "";
                    }
                    else
                    {
                        input.Text = input.Text.Remove(input.Text.Length-1);
                    }
                    input.Focus();
                    input.SelectionStart = input.Text.Length;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(0, textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(0,textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(1,textBox3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(1,textBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            if (textBox1.TextLength == 11 && textBox2.TextLength == 10 && textBox3.Text != "" && textBox4.Text != "" && Convert.ToInt32(label11.Text) >= 22 && Convert.ToInt32(label12.Text) >= 8 && Convert.ToInt32(label11.Text)+ Convert.ToInt32(label12.Text)==30)
            {

                StreamReader Reader;
                Reader = File.OpenText(@"..\..\ogrenciler.txt");
                while ((okunan = Reader.ReadLine()) != null)
                {
                    string[] ogr = okunan.Split('-');
                    for (int i = 0; i < ogr.Length; i++)
                    {
                        if (ogr[i] == textBox1.Text || ogr[i] == textBox2.Text)
                        {
                            MessageBox.Show("Girmiş olduğunuz veriler kayıtlarda bulunmakta!");
                            kontrol = false;
                            break;
                        }
                    }
                }
                Reader.Close();

                if (kontrol == true)
                {
                    ogrenci ogrenciEkle = new ogrenci();
                    ogrenciEkle.okulNo = textBox2.Text;
                    ogrenciEkle.tc = textBox1.Text;
                    ogrenciEkle.adi = textBox3.Text;
                    ogrenciEkle.soyadi = textBox4.Text;
                    if (radioButton1.Checked)
                    {
                        ogrenciEkle.sinif = "1";
                    }
                    else
                    {
                        ogrenciEkle.sinif = "2";
                    }

                    if (radioButton8.Checked)
                    {
                        ogrenciEkle.sube = "A";
                    }
                    else
                    {
                        ogrenciEkle.sube = "B";
                    }

                    if (radioButton4.Checked)
                    {
                        ogrenciEkle.donem = "1";
                    }
                    else if (radioButton3.Checked)
                    {
                        ogrenciEkle.donem = "2";

                    }
                    else if (radioButton5.Checked)
                    {
                        ogrenciEkle.donem = "3";

                    }
                    else if (radioButton6.Checked)
                    {
                        ogrenciEkle.donem = "4";

                    }
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        ogrenciEkle.aldıgıDersler += checkedListBox1.CheckedItems[i] + "|";
                    }
                    for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
                    {
                        ogrenciEkle.aldıgıDersler += checkedListBox2.CheckedItems[i] + "|";
                    }
                    StreamReader oku;
                    oku = File.OpenText("..\\..\\ogrenciler.txt");
                    okunan = oku.ReadToEnd();
                    oku.Close();


                    TextWriter writer = new StreamWriter("..\\..\\ogrenciler.txt");//TextWriter sınıfından yeni bir yazici adlı nesne üretelim ve klasor yolunu streamWriter içine yazalım.
                    writer.WriteLine(okunan + ogrenciEkle.ogrenciBirlestir());
                    writer.Flush();//txt metnine tüm verileri gömelim.
                    writer.Close();// son olarak nesnemizi kapatalım.
                    clearAll();
                    MessageBox.Show("Öğrenci Kaydedildi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen verileri doğru girdiğinizden emin olun!");
            }
            kontrol = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                ders ekle = new ders();
                ekle.dersAdi = textBox7.Text;
                ekle.dersAkts = Convert.ToInt32(textBox8.Text);
                ekle.dersKodu = textBox6.Text;

                if (radioButton9.Checked)
                {
                    string[] item;
                    item = new string[checkedListBox1.Items.Count];//eleman dizisinin boyutunu belirleyelim.
                    TextWriter writer = new StreamWriter("..\\..\\zorunludersler.txt");//TextWriter sınıfından yeni bir yazici adlı nesne üretelim ve klasor yolunu streamWriter içine yazalım.
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        item[i] = checkedListBox1.Items[i].ToString();//diziye listboxtaki elemanları tek tek atalım.
                        writer.WriteLine(item[i]);//txt dosyasına yazdırıp sırayla bir satır aşağı indirelim
                    }
                    writer.WriteLine(ekle.dersAdiBirlestir());
                    writer.Flush();//txt metnine tüm verileri gömelim.
                    writer.Close();// son olarak nesnemizi kapatalım.
                    checkedListBox1.Items.Add(ekle.dersAdiBirlestir());
                }
                else
                {
                    string[] item;
                    item = new string[checkedListBox2.Items.Count];//eleman dizisinin boyutunu belirleyelim.
                    TextWriter writer = new StreamWriter("..\\..\\secmelidersler.txt");//TextWriter sınıfından yeni bir yazici adlı nesne üretelim ve klasor yolunu streamWriter içine yazalım.
                    for (int i = 0; i < checkedListBox2.Items.Count; i++)
                    {
                        item[i] = checkedListBox2.Items[i].ToString();//diziye listboxtaki elemanları tek tek atalım.
                        writer.WriteLine(item[i]);//txt dosyasına yazdırıp sırayla bir satır aşağı indirelim
                    }
                    writer.WriteLine(ekle.dersAdiBirlestir());
                    writer.Flush();//txt metnine tüm verileri gömelim.
                    writer.Close();// son olarak nesnemizi kapatalım.
                    checkedListBox2.Items.Add(ekle.dersAdiBirlestir());
                }

                clearAll();
            }
            else
            {
                MessageBox.Show("Lütfen verileri tam girdiğinizden emin olun!");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dersGuncelle();
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string[] akts = checkedListBox2.Items[e.Index].ToString().Split(' ');
            if (!checkedListBox2.GetItemChecked(e.Index))
            {
                secmeliAkts += Convert.ToInt32(akts[akts.Length - 1]);
                toplamAkts += Convert.ToInt32(akts[akts.Length - 1]);
                label37.Text = toplamAkts.ToString();
            }
            else
            {
                secmeliAkts -= Convert.ToInt32(akts[akts.Length - 1]);
                toplamAkts -= Convert.ToInt32(akts[akts.Length - 1]);
                label37.Text = toplamAkts.ToString();

            }
            label12.Text = secmeliAkts.ToString();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string[] akts = checkedListBox1.Items[e.Index].ToString().Split(' ');
            if (!checkedListBox1.GetItemChecked(e.Index))
            {
                zorunluAkts += Convert.ToInt32(akts[akts.Length - 1]);
                toplamAkts += Convert.ToInt32(akts[akts.Length - 1]);
                label37.Text = toplamAkts.ToString();
            }
            else
            {
                zorunluAkts -= Convert.ToInt32(akts[akts.Length - 1]);
                toplamAkts -= Convert.ToInt32(akts[akts.Length - 1]);
                label37.Text = toplamAkts.ToString();
            }
            label11.Text = zorunluAkts.ToString();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(0,textBox6);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(0, textBox8);
        }

        private void label11_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label11.Text) < 22)
            {
                label11.ForeColor = Color.Red;
            }
            else
            {
                label11.ForeColor = Color.Green;
            }

        }

        private void label12_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label12.Text) < 8)
            {
                label12.ForeColor = Color.Red;
            }
            else
            {
                label12.ForeColor = Color.Green;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Seçili olan dersleri silmek istediğinizden emin misiniz?", "Ders Silme İşlemi", buttons);
            if (result == DialogResult.Yes)
            {
                        
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        checkedListBox1.Items.RemoveAt(i--);  
                    }
                }
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (checkedListBox2.GetItemChecked(i))
                    {
                        checkedListBox2.Items.RemoveAt(i--);
                    }
                }
                zorunluYazdir();
                secmeliYazdir();
                checkedListBox1.Items.Clear();
                checkedListBox2.Items.Clear();
                dersGuncelle();
            }
            clearAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearAll();
            StreamReader Reader;
            Reader = File.OpenText(@"..\..\ogrenciler.txt");
            while ((okunan = Reader.ReadLine()) != null)
            {
                string[] ogr = okunan.Split('-');
                for (int i = 0; i < ogr.Length; i++)
                {
                    if (ogr[i] == textBox5.Text)
                    {
                        textBox11.Text = ogr[i + 1];
                        textBox10.Text = ogr[i];
                        textBox9.Text = ogr[i + 2];
                        textBox12.Text = ogr[i + 3];
                        label32.Text = ogr[i + 4];
                        label33.Text = ogr[i + 5];
                        label34.Text = ogr[i + 6];

                        string[] dersler = ogr[i + 7].Split('|');
                        for (int d = 0; d < dersler.Length; d++)
                        {
                            listBox1.Items.Add(dersler[d]);
                        }
                    }
                }
            }
            Reader.Close();
            if (textBox11.Text=="")
            {
                MessageBox.Show("Girdiğiniz öğrenci numarasına ait öğrenci bilgisi bulunamadı!");
            }
            textBox5.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            tBoxKontrol(0,textBox5);
        }

        private void label37_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label37.Text)==30)
            {
                label37.ForeColor = Color.Green;
            }
            else
            {
                label37.ForeColor = Color.Red;
            }
        }
    }
}
