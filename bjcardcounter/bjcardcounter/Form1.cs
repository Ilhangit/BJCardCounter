using System.Windows.Forms;

namespace bjcardcounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Text = "BlackJack Card Counter";

        }
        int sayac = 0;
        float toplamoyun = 0;
        float kazanma = 0;
        int sayacart = 0;
        int sayacazal = 0;
        int sayacstabil = 0;
        public void renkDegis()
        {
            if (sayac >= 5)
            {
                label6.ForeColor = Color.FromArgb(5, 250, 13);
                label7.ForeColor = Color.FromArgb(5, 250, 13);
            }
            else if (sayac > 2)
            {
                label6.ForeColor = Color.FromArgb(38, 212, 32);
                label7.ForeColor = Color.FromArgb(38, 212, 32);
            }
            else if (sayac > 0)
            {
                label6.ForeColor = Color.FromArgb(8, 143, 3);
                label7.ForeColor = Color.FromArgb(8, 143, 3);
            }
            else if (sayac > -1)
            {
                label6.ForeColor = Color.FromArgb(0, 0, 0);
                label7.ForeColor = Color.FromArgb(0, 0, 0);
            }
            else if (sayac > -3)
            {
                label6.ForeColor = Color.FromArgb(133, 12, 12);
                label7.ForeColor = Color.FromArgb(133, 12, 12);
            }
            else
            {
                label6.ForeColor = Color.FromArgb(255, 0, 0);
                label7.ForeColor = Color.FromArgb(255, 0, 0);
            }
        }
        private void girGirme()
        {
            if (sayac >= 5)
            {
                textBox2.Text = "Oyuna kesin gir";
                label6.Text = "bir sonraki kart yüksek gelir!!!";
                label7.Text = "↑↑↑";

            }
            else if (sayac > 2)
            {
                textBox2.Text = "Oyuna gir";
                label6.Text = "bir sonraki kart yüksek gelebilir!";
                label7.Text = "↑↑";
            }
            else if (sayac > 0)
            {
                textBox2.Text = "Oyuna girilebir";
                label6.Text = "bir sonraki kart yüksek gelebilir!";
                label7.Text = "↑";
            }
            else if (sayac > -1)
            {
                textBox2.Text = "Oyun Nötr";
                label6.Text = "bir sonraki kart rastgele";
                label7.Text = "0";
            }
            else if (sayac > -3)
            {
                textBox2.Text = "Oyuna girmeyebilirsin";
                label6.Text = "bir sonraki kart düşük gelebilir!";
                label7.Text = "↓↓";
            }
            else
            {
                textBox2.Text = "Oyuna girme";
                label6.Text = "bir sonraki kart düşük gelir!!!";
                label7.Text = "↓↓↓";
            }
        }

        private void arttır()
        {
            sayac++;
            sayacart++;
            label3.Text = "1 puan eklendi";
            textBox1.Text = sayac.ToString();
            girGirme();
            renkDegis();
            listBox1.Items.Add("2-6");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            label8.Text = sayacart.ToString();
        }
        private void azalt()
        {
            sayac--;
            sayacazal++;
            label3.Text = "1 puan çıkarıldı";
            textBox1.Text = sayac.ToString();
            girGirme();
            renkDegis();
            listBox1.Items.Add("10-A-K-Q-J");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            label10.Text = sayacazal.ToString();
        }
        private void stabil()
        {
            sayacstabil++;
            label3.Text = "0 puan eklendi ";
            textBox1.Text = sayac.ToString();
            girGirme();
            renkDegis();
            listBox1.Items.Add("7-9");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            label9.Text = sayacstabil.ToString();
        }
        private void gerial()
        {
            if (listBox1.Items.Count > 0)
            {
                string lastItem = listBox1.Items[listBox1.Items.Count - 1].ToString();
                if (lastItem == "2-6")
                {
                    azaltgerial();

                }
                else if (lastItem == "7-9")
                {
                    sayacstabil--;
                    label9.Text = sayacstabil.ToString();
                    textBox1.Text = sayac.ToString();
                    label3.Text = "geri alındı";
                    girGirme();
                    renkDegis();
                    listBox1.SelectedIndex = listBox1.Items.Count - 2;
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);

                }
                else if (lastItem == "10-A-K-Q-J")
                {
                    arttırgerial();

                }
            }
        }
        private void azaltgerial()
        {
            sayacart--;
            label8.Text = sayacart.ToString();
            sayac--;
            textBox1.Text = sayac.ToString();
            label3.Text = "geri alındı";
            girGirme();
            renkDegis();
            listBox1.SelectedIndex = listBox1.Items.Count - 2;
            listBox1.Items.RemoveAt(listBox1.Items.Count-1);
        }
        private void arttırgerial()
        {
            sayacazal--;
            label10.Text = sayacazal.ToString();
            sayac++;
            textBox1.Text = sayac.ToString();
            label3.Text = "geri alındı";
            girGirme();
            renkDegis();
            listBox1.SelectedIndex = listBox1.Items.Count - 2;
            listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            arttır();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stabil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            azalt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toplamoyun++;
            kazanma++;
            label5.Text = ((kazanma / toplamoyun) * 100).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toplamoyun++;
            label5.Text = ((kazanma / toplamoyun) * 100).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sayac = 0;
            textBox1.Text = "0".ToString();
            textBox2.Text = "0".ToString();
            label5.Text = "0".ToString();
            label5.Text = "0".ToString();
            listBox1.Items.Clear();
            sayacart = 0;
            sayacazal = 0;
            sayacstabil = 0;
            label9.Text = "0".ToString();
            label10.Text = "0".ToString();
            label8.Text = "0".ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    arttır();
                    break;
                case 'A':
                    arttır();
                    break;
                case 'd':
                    azalt();
                    break;
                case 'D':
                    azalt();
                    break;
                case 's':
                    stabil();
                    break;
                case 'S':
                    stabil();
                    break;
                case 'r':
                    gerial();
                    break;
                case 'R':
                    gerial();
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gerial();
        }
    }
}