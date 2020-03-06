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
using System.Security.Cryptography;
using System.Numerics;

namespace systzahinf
{
    public partial class Form1 : Form
    {
        string[,] data;

        string a;
        int[] el = new int[33];
        string sss = "abcdefghijklmnopqrstuvwxyz";
        string ss = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        int countL = 0;



        public Form1()
        {
            InitializeComponent();

            datazamina.AllowUserToAddRows = false;
        }

        public int[] varRad;


        //////////////////////ЗАМІНИ//////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false && radioButton4.Checked == false)
                MessageBox.Show("Виберіть мову!");
            datazamina.Rows.Clear();
            char[] mas1;
            char[] mas2;

            if (radioButton3.Checked)
            {
                mas1 = new char[33];
                mas2 = new char[33];
                for (int i = 0; i < 33; i++)
                {
                    mas1[i] = ss[i];
                    mas2[i] = ss[i];

                }

                var rand = new Random();                   // Запвнення датагрід рандомом(укр)
                for (int i = mas2.Length - 1; i >= 0; i--)
                {
                    int j = rand.Next(i);
                    var temp = mas2[i];
                    mas2[i] = mas2[j];
                    mas2[j] = temp;
                }

                for (int i = 0; i < mas1.Length; i++)
                {
                    datazamina.Rows.Add(mas1[i], mas2[i]);
                }


            }

            else if (radioButton4.Checked)
            {
                mas1 = new char[26];
                mas2 = new char[26];


                for (int i = 0; i < 26; i++)
                {
                    mas1[i] = sss[i];
                    mas2[i] = sss[i];

                }

                var rand = new Random();                   // Запвнення датагрід рандомом(укр)
                for (int i = mas2.Length - 1; i >= 0; i--)
                {
                    int j = rand.Next(i);
                    var temp = mas2[i];
                    mas2[i] = mas2[j];
                    mas2[j] = temp;
                }

                for (int i = 0; i < mas1.Length; i++)
                {
                    datazamina.Rows.Add(mas1[i], mas2[i]);
                }
            }

        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false && radioButton4.Checked == false)
                MessageBox.Show("Виберіть мову!");
            char[] x;
            char[] y;
            if (radioButton3.Checked == true)
            {
                x = new char[33];
                y = new char[33];

                for (int i = 0; i < 33; i++)    //Зчитуэмо з датагрід в масив
                {
                    x[i] = Convert.ToChar(datazamina[0, i].Value);
                    y[i] = Convert.ToChar(datazamina[1, i].Value);
                }
                string res = "";
                for (int i = 0; i < input2.Text.Length; i++)
                {
                    for (int j = 0; j < 33; j++)
                    {
                        if (input2.Text[i] == x[j])
                        {
                            res += y[j];
                        }
                    }
                }
                output2.Text = res;
            }

            if (radioButton4.Checked == true)
            {
                x = new char[26];
                y = new char[26];

                for (int i = 0; i < 26; i++)    //Зчитуэмо з датагрід в масив
                {
                    x[i] = Convert.ToChar(datazamina[0, i].Value);
                    y[i] = Convert.ToChar(datazamina[1, i].Value);
                }
                string res = "";
                for (int i = 0; i < input2.Text.Length; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (input2.Text[i] == x[j])
                        {
                            res += y[j];
                        }
                   }
                }
                output2.Text = res;
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false && radioButton4.Checked == false)
                MessageBox.Show("Виберіть мову!");

            char[] x;
            char[] y;
            if (radioButton3.Checked == true)
            {
                x = new char[33];
                y = new char[33];

                for (int i = 0; i < 33; i++)    //Зчитуэмо з датагрід в масив
                {
                    x[i] = Convert.ToChar(datazamina[0, i].Value);
                    y[i] = Convert.ToChar(datazamina[1, i].Value);
                }


                string res = "";
                for (int i = 0; i < input2.Text.Length; i++)
                {
                    for (int j = 0; j < 33; j++)
                    {
                        if (input2.Text[i] == y[j])
                        {
                            res += x[j];
                        }
                        //else if (input2.Text[i] == ' ')
                        //{
                        //    res += input2.Text[i];
                        //}
                    }


                }
                output2.Text = res;


            }
            if (radioButton4.Checked == true)
            {
                x = new char[26];
                y = new char[26];

                for (int i = 0; i < 26; i++)    //Зчитуэмо з датагрід в масив
                {
                    x[i] = Convert.ToChar(datazamina[0, i].Value);
                    y[i] = Convert.ToChar(datazamina[1, i].Value);
                }
                string res = "";
                for (int i = 0; i < input2.Text.Length; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (input2.Text[i] == y[j])
                        {
                            res += x[j]; ;
                        }


                    }
                }
                output2.Text = res;
            }


        }

        private void OpenKey_Click(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true || radioButton4.Checked == true)
            {
                datazamina.Rows.Clear();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string line;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                    while (reader.EndOfStream != true)
                    {
                        line = reader.ReadLine();

                        datazamina.Rows.Add(line[0], line[2]);
                    }

                }


            }
        }

        private void SaveKey_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog2 = new SaveFileDialog();

            saveFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog2.OpenFile(), System.Text.Encoding.Default))
                {
                    List<int> col_n = new List<int>();
                    foreach (DataGridViewColumn col in datazamina.Columns)
                        if (col.Visible)
                        {
                            //sw.Write(col.HeaderText + "\t");
                            col_n.Add(col.Index);
                        }
                    //sw.WriteLine();
                    int x = datazamina.RowCount;
                    if (datazamina.AllowUserToAddRows) x--;

                    for (int i = 0; i < x; i++)
                    {
                        for (int y = 0; y < col_n.Count; y++)
                            sw.Write(datazamina[col_n[y], i].Value + "\t");
                        sw.Write(" \r\n");
                    }
                    sw.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(output2.Text);
                    sw.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    input2.AppendText(s);
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            input2.Clear();
            output2.Clear();
            datazamina.Rows.Clear();

        }

        ///////////////////БЛОКНОТ////////////////////////////////////////////////////////////////////////

        private void button11_Click(object sender, EventArgs e)
        {

            if (radioButton7.Checked == false && radioButton8.Checked == false)
                MessageBox.Show("Виберіть мову!");

            int ltext = 0;
            int temp = 0;
            char temp1;
            string temp3;
            string temp2;
            string tt = "";
            int tchar;
            while (ltext < Inp.Text.Length)
            {
                tchar = Inp.Text[ltext];

                temp = temp + 1;
                tt = tt + Convert.ToString((char)tchar);


                ++ltext;
            }
            Inp.Clear();
            Inp.Text = tt;
            Random rand = new Random();
            if (radioButton7.Checked)
            {
                varRad = new int[temp];

                for (int i = 0; i < temp; ++i)
                {
                    varRad[i] = rand.Next(65, 90);
                    temp1 = Convert.ToChar(varRad[i]);
                    temp2 = Convert.ToString(temp1);
                    key.AppendText(temp2);

                }
            }

            else if (radioButton8.Checked)
            {
                char[] key2 = new char[temp];
                int z;
                for (int i = 0; i < temp; ++i)
                {
                    z = rand.Next(0, 33);
                    key2[i] = ss[z];
                    key.AppendText(Convert.ToString(key2[i]));

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Inp.Clear();
            ou.Clear();
            key.Clear();
        }

        private void OpenN_Click(object sender, EventArgs e)
        {
            Inp.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    Inp.AppendText(s);
                }

            }
        }

        private void SeveN_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(ou.Text);
                    sw.Close();
                }
            }
        }

        private void EN_Click(object sender, EventArgs e)
        {
            int ltext = 0;
            int tchar;
            int tchar1;
            char temp;
            int temp1;
            while (ltext < key.Text.Length)
            {
                tchar = Inp.Text[ltext];
                tchar1 = key.Text[ltext];

                temp1 = tchar ^ tchar1;
                temp = (char)temp1;
                ou.AppendText(Convert.ToString(temp));

                // }


                ++ltext;
            }
        }

        private void DN_Click(object sender, EventArgs e)
        {
            int ltext = 0;
            int tchar;
            int tchar1;
            char temp;
            int temp1;
            while (ltext < key.Text.Length)
            {
                tchar = Inp.Text[ltext];
                tchar1 = key.Text[ltext];
                temp1 = tchar ^ tchar1;
                temp = (char)temp1;
                ou.AppendText(Convert.ToString(temp));

                ++ltext;
            }
        }

        private void OKN_Click(object sender, EventArgs e)
        {
            key.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    key.AppendText(s);
                }

            }
        }

        private void SKN_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(key.Text);
                    sw.Close();
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////ВИЖЕНЕРА///////////////////////////////////////////////////////////////////////////////////////
        private void buttonEV_Click(object sender, EventArgs e)
        {

            if (radioButton5.Checked == false && radioButton6.Checked == false)
                MessageBox.Show("Виберіть мову!");

            string text = inp3.Text.ToUpper();
            string key = key3.Text.ToUpper();
            char[] characters = null;

            if (radioButton6.Checked)
            {
                characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Є', 'Ж', 'З', 'И',
                                                'І', 'Ї', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П',
                                                'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь',
                                                'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            }

            else if (radioButton5.Checked)
            {
                characters = new char[]
                {
                'A','B','C','D','E','F','G','H','I',
                'J','K','L','M','N','O','P','Q','R',
                'S','T','U','V','W','X','Y','Z', ' ',
                    '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
                };
            }

            string result = "";

            int keyword_index = 0;

            string alf = sss.ToUpper();


            //char[] characters = alf.ToCharArray();

            int n = characters.Length;


            foreach (char symbol in text)
            {

                int c = (Array.IndexOf(characters, symbol) +
                      Array.IndexOf(characters, key[keyword_index])) % n;

                result += characters[c];

                keyword_index++;


                if ((keyword_index + 1) == key.Length)
                    keyword_index = 0;
            }

            out3.Text += result;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (radioButton5.Checked == false && radioButton6.Checked == false)
                MessageBox.Show("Виберіть мову!");          
            
            char temp1;           
            string temp2;
                     
            int n = inp3.Text.Length;
            
            
            Random rand = new Random();
            if (radioButton5.Checked)
            {
                varRad = new int[n];

                for (int i = 0; i <n; ++i)
                {
                    varRad[i] = rand.Next(65, 90);
                    temp1 = Convert.ToChar(varRad[i]);
                    temp2 = Convert.ToString(temp1);
                    key3.AppendText(temp2);

                }
            }

            else if (radioButton6.Checked)
            {
                char[] key2 = new char[n];
                int z;
                for (int i = 0; i <n; ++i)
                {
                    z = rand.Next(0, 33);
                    key2[i] = ss[z];
                    key3.AppendText(Convert.ToString(key2[i]));

                }
            }



        }
        //дешифрування
        private void button11_Click_1(object sender, EventArgs e)
        {
            string text = inp3.Text.ToUpper();
            string key = key3.Text.ToUpper();
            char[] characters = null;

            if (radioButton6.Checked)
            {
                characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Є', 'Ж', 'З', 'И',
                                                'І', 'Ї', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П',
                                                'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь',
                                                'Ю', 'Я', ' ' , '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            }


            else if (radioButton5.Checked)
            {
                characters = new char[]
                {
                'A','B','C','D','E','F','G','H','I',
                'J','K','L','M','N','O','P','Q','R',
                'S','T','U','V','W','X','Y','Z', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
                };
            }


            string result = "";

            int keyword_index = 0;

            string alf = sss;
            alf += " ";


            int n = characters.Length;


            foreach (char symbol in text)
            {

                int p = (Array.IndexOf(characters, symbol) + n -
              Array.IndexOf(characters, key[keyword_index])) % n;

                result += characters[p];

                keyword_index++;


                if ((keyword_index + 1) == key.Length)
                    keyword_index = 0;
            }

            out3.Text += result;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            inp3.Clear();
            out3.Clear();
            key3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inp3.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    inp3.AppendText(s);
                }

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(out3.Text);
                    sw.Close();
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(key3.Text);
                    sw.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            key3.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    key3.AppendText(s);
                }

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////


        ///////////////нові форми для опису///////////////////////////////
        private void button13_Click(object sender, EventArgs e)
        {
            Zamina f = new Zamina();
            f.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Blocnot f = new Blocnot();
            f.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Vigeneracs f = new Vigeneracs();
            f.ShowDialog();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            Perest f = new Perest();
            f.ShowDialog(); ;

        }
        private void button25_Click(object sender, EventArgs e)
        {
             RSA f = new RSA();
            f.ShowDialog(); ;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            DES f = new DES();
            f.ShowDialog(); ;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            AES f = new AES();
            f.ShowDialog(); ;
        }
         private void button52_Click(object sender, EventArgs e)
        {
            El f = new El();
            f.ShowDialog(); ;
        }

        /////////////////////////////////////////////////////////////////

        ///////////////////// ПЕРЕСТАНОВКИ///////////////////////////////////////////////////////

        private void button17_Click(object sender, EventArgs e)
        {
            inp1.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    inp4.AppendText(s);
                }

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(out1.Text);
                    sw.Close();
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            key1.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    key1.AppendText(s);
                }

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(key1.Text);
                    sw.Close();
                }
            }
        }

        class Peres
        {

            private static int[] key = null;


            public static void SetKey(int[] _key)
            {
                key = new int[_key.Length];

                for (int i = 0; i < _key.Length; i++)
                    key[i] = _key[i];
            }

            public static void SetKey(string[] _key)
            {
                key = new int[_key.Length];

                for (int i = 0; i < _key.Length; i++)
                    key[i] = Convert.ToInt32(_key[i]);
            }

            public static void SetKey(string _key)
            {
                SetKey(_key.Split(' '));
            }

            public static string Encrypt(string input)
            {
                for (int i = 0; i < input.Length % key.Length; i++)
                    input += input[i];

                string result = "";

                for (int i = 0; i < input.Length; i += key.Length)
                {
                    char[] transposition = new char[key.Length];

                    for (int j = 0; j < key.Length; j++)
                        transposition[key[j] - 1] = input[i + j];

                    for (int j = 0; j < key.Length; j++)
                        result += transposition[j];
                }

                return result;
            }
            public static string Decrypt(string input)
            {
                string result = "";

                for (int i = 0; i < input.Length; i += key.Length)
                {
                    char[] transposition = new char[key.Length];

                    for (int j = 0; j < key.Length; j++)
                        transposition[j] = input[i + key[j] - 1];

                    for (int j = 0; j < key.Length; j++)
                        result += transposition[j];
                }

                return result;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (key1.Text.Length == 0)
                MessageBox.Show("Введіть секретний ключ!");

            if ((key1.Text.Length - ((key1.Text.Length - 1) / 2)) <= inp1.Text.Length)
            {
                out1.Text = "";
                Peres.SetKey(key1.Text);
                out1.Text = Peres.Encrypt(inp1.Text);
            }
            else
                MessageBox.Show("Ключ завеликий для довжини тексту!");


        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (key1.Text.Length == 0)
                MessageBox.Show("Введіть секретний ключ!");

            if ((key1.Text.Length - ((key1.Text.Length - 1) / 2)) <= inp1.Text.Length)
            {
                out1.Text = "";
                Peres.SetKey(key1.Text);
                out1.Text = Peres.Decrypt(inp1.Text);
            }
            else
                MessageBox.Show("Ключ завеликий для довжини тексту!");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (inp1.Text.Length >= 10)
            {
                Random rnd = new Random();
                int[] a = new int[8];
                a[0] = rnd.Next(1, 9);
                for (int i = 1; i < 8;)
                {
                    int num = rnd.Next(1, 9);
                    int j;

                    for (j = 0; j < i; j++)
                    {
                        if (num == a[j])
                            break;
                    }
                    if (j == i)
                    {
                        a[i] = num;
                        i++;
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    key1.Text += a[i].ToString() + " ";
                }
            }
            if (inp1.Text.Length < 10)
            {

                Random rnd = new Random();
                int[] a = new int[inp1.Text.Length];
                a[0] = rnd.Next(1, inp1.Text.Length + 1);
                for (int i = 1; i < inp1.Text.Length;)
                {
                    int num = rnd.Next(1, inp1.Text.Length + 1);
                    int j;

                    for (j = 0; j < i; j++)
                    {
                        if (num == a[j])
                            break;
                    }
                    if (j == i)
                    {
                        a[i] = num;
                        i++;
                    }
                }
                for (int i = 0; i < inp1.Text.Length; i++)
                {
                    key1.Text += a[i].ToString() + " ";
                }
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            inp1.Clear();
            out1.Clear();
            key1.Clear();
        }


        ///////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////RSA//////////////////////////////////////////////////////////
        private void button27_Click(object sender, EventArgs e)
        {
            inp4.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    inp4.AppendText(s);
                }

            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(out4.Text);
                    sw.Close();
                }
            }
        }

        char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Ґ',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь',
                                                        'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0' , 'Q', 'W', 'E', 'R', 'T', 'U', 'Y', 'I',
                                                        'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'O', 'L', 'Z', 'X',
                                                        'C', 'V', 'B', 'N', 'M' , '.', '?', '!', ':', ';', ',', '%', ')', '(', '+',
                                                         '=', '-', '"', '*' ,' ' , 'а', 'б', 'в', 'г', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'ґ',
                                                        'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                        'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я', 'q', 'w', 'e', 'r', 't', 'u', 'y', 'i',
                                                        'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'o', 'l', 'z', 'x',
                                                        'c', 'v', 'b', 'n', 'm'
};

        private bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }


        private List<string> Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        private string Dedoce(List<double> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (double item in input)
            {

                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }


        private long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }

            return d;
        }


        private long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }


        private void button31_Click(object sender, EventArgs e)
        {
            if ((P.Text.Length > 0) && (Q.Text.Length > 0))
            {
                long p = Convert.ToInt64(P.Text);
                long q = Convert.ToInt64(Q.Text);

                if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
                {
                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long d = Calculate_d(m);
                    long e_ = Calculate_e(d, m);

                    List<string> result = Endoce(inp4.Text, e_, n);
                    foreach (string item in result)
                        out4.Text += item.ToString() + "\r\n";


                    D.Text = d.ToString();
                    N.Text = n.ToString();


                }
                else
                    MessageBox.Show("Якесь із чисел не є простим!");
            }
            else
                MessageBox.Show("Введіть прості числа!");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if ((D.Text.Length > 0) && (N.Text.Length > 0))
            {
                long d = Convert.ToInt64(D.Text);
                long n = Convert.ToInt64(N.Text);

                List<double> input = new List<double>();
                string[] txt = inp4.Text.Split('\n');
                foreach (string nbr in txt)
                {
                    int number = int.Parse(nbr);
                    input.Add(number);
                }

                // input.Add(Input.Text);

                string result = Dedoce(input, d, n);

                out4.Text = result.ToString();
            }
            else
                MessageBox.Show("Введіть секретний ключ!");

        }

        private void button33_Click(object sender, EventArgs e)
        {
            int n,k ;
            Random rand = new Random();            
            do
            {
                n = rand.Next(0,500);            
            }while(!IsTheNumberSimple(n));
            do
            {
                k = rand.Next(500, 999);
            } while (!IsTheNumberSimple(k));

            Q.Text = n.ToString();
            P.Text = k.ToString();


        }

        private void button29_Click(object sender, EventArgs e)
        {
            var list = new List<int>();
            list.Add(Convert.ToInt32(D.Text));
            list.Add(Convert.ToInt32(N.Text));

            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    foreach (var item in list)
                        sw.Write(item.ToString() + " ");
                    sw.Close();
                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                while (reader.EndOfStream != true)
                {
                    string q = reader.ReadToEnd();

                    List<string> P = new List<string>(q.Split(' '));
                    var listOfInt = P.Select(int.Parse);
                    D.Text = P[0].ToString();
                    N.Text = P[1].ToString();
                }

            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            inp4.Clear();
            out4.Clear();
            P.Clear();
            Q.Clear();
            N.Clear();
            D.Clear();
        }
        ///////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////DES//////////////////////////////////////////
        private void button36_Click(object sender, EventArgs e)
        {

            inp5.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    inp5.AppendText(s);
                }

            }
        }

        private void button37_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(out5.Text);
                    sw.Close();
                }
            }
        }


        private const int sizeOfBlock = 128;
        private const int sizeOfChar = 16;
        private const int shiftKey = 2;
        private const int quantityOfRounds = 16;

        string[] Blocks;
        private string StringToRightLength(string input)
        {
            while (((input.Length * sizeOfChar) % sizeOfBlock) != 0)
                input += "#";

            return input;
        }

        
        private void CutStringIntoBlocks(string input)
        {
            Blocks = new string[(input.Length * sizeOfChar) / sizeOfBlock];

            int lengthOfBlock = input.Length / Blocks.Length;

            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
                Blocks[i] = StringToBinaryFormat(Blocks[i]);
            }
        }

       
        private void CutBinaryStringIntoBlocks(string input)
        {
            Blocks = new string[input.Length / sizeOfBlock];

            int lengthOfBlock = input.Length / Blocks.Length;

            for (int i = 0; i < Blocks.Length; i++)
                Blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
        }

        
        private string StringToBinaryFormat(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                string char_binary = Convert.ToString(input[i], 2);

                while (char_binary.Length < sizeOfChar)
                    char_binary = "0" + char_binary;

                output += char_binary;
            }

            return output;
        }

        
        private string CorrectKeyWord(string input, int lengthKey)
        {
            if (input.Length > lengthKey)
                input = input.Substring(0, lengthKey);
            else
                while (input.Length < lengthKey)
                    input = "0" + input;

            return input;
        }

        
        private string EncodeDES_One_Round(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (R + XOR(L, f(R, key)));
        }

        
        private string DecodeDES_One_Round(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (XOR(f(L, key), R) + L);
        }

        
        private string XOR(string s1, string s2)
        {
            string result = "";

            for (int i = 0; i < s1.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(s1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(s2[i].ToString()));

                if (a ^ b)
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }

        
        private string f(string s1, string s2)
        {
            return XOR(s1, s2);
        }

        private string KeyToNextRound(string key)
        {
            for (int i = 0; i < shiftKey; i++)
            {
                key = key[key.Length - 1] + key;
                key = key.Remove(key.Length - 1);
            }

            return key;
        }

        
        private string KeyToPrevRound(string key)
        {
            for (int i = 0; i < shiftKey; i++)
            {
                key = key + key[0];
                key = key.Remove(0, 1);
            }

            return key;
        }

        
        private string StringFromBinaryToNormalFormat(string input)
        {
            string output = "";

            while (input.Length > 0)
            {
                string char_binary = input.Substring(0, sizeOfChar);
                input = input.Remove(0, sizeOfChar);

                int a = 0;
                int degree = char_binary.Length - 1;

                foreach (char c in char_binary)
                    a += Convert.ToInt32(c.ToString()) * (int)Math.Pow(2, degree--);

                output += ((char)a).ToString();
            }

            return output;
        }


        private void button40_Click(object sender, EventArgs e)
        {
            if (EnKey.Text.Length > 0)
            {
                string key = EnKey.Text;

                inp5.Text = StringToRightLength(inp5.Text);

                CutStringIntoBlocks(inp5.Text);

                key = CorrectKeyWord(key, inp5.Text.Length / (2 * Blocks.Length));
                EnKey.Text = key;
                key = StringToBinaryFormat(key);

                for (int j = 0; j < quantityOfRounds; j++)
                {
                    for (int i = 0; i < Blocks.Length; i++)
                        Blocks[i] = EncodeDES_One_Round(Blocks[i], key);

                    key = KeyToNextRound(key);
                }

                key = KeyToPrevRound(key);

                DKey.Text = StringFromBinaryToNormalFormat(key);

                string result = "";

                for (int i = 0; i < Blocks.Length; i++)
                    result += Blocks[i];
                out5.Text = StringFromBinaryToNormalFormat(result);

            }
            else
                MessageBox.Show("Введіть ключове слово!");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (DKey.Text.Length > 0)
            {

                string key = StringToBinaryFormat(DKey.Text);

                inp5.Text = StringToBinaryFormat(inp5.Text);

                CutBinaryStringIntoBlocks(inp5.Text);

                for (int j = 0; j < quantityOfRounds; j++)
                {
                    for (int i = 0; i < Blocks.Length; i++)
                        Blocks[i] = DecodeDES_One_Round(Blocks[i], key);

                    key = KeyToPrevRound(key);
                }

                key = KeyToNextRound(key);

                DKey.Text = StringFromBinaryToNormalFormat(key);

                string result = "";

                for (int i = 0; i < Blocks.Length; i++)
                    result += Blocks[i];

                out5.Text = StringFromBinaryToNormalFormat(result);

            }
            else
                MessageBox.Show("Введіть ключове слово!");
        }

        private void button42_Click(object sender, EventArgs e)
        {
            char temp1;
            string temp2;
            int n = 7;
            Random rand = new Random();           
            varRad = new int[n];
            for (int i = 0; i < n; ++i)
            {
                varRad[i] = rand.Next(65, 90);
                temp1 = Convert.ToChar(varRad[i]);
                temp2 = Convert.ToString(temp1);
                EnKey.AppendText(temp2);

            }
            
        }

        private void button39_Click(object sender, EventArgs e)
        {
            DKey.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.Default);
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    DKey.AppendText(s);
                }

            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(DKey.Text);
                    sw.Close();
                }
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            inp5.Clear();
            out5.Clear();
            DKey.Clear();
            EnKey.Clear();

        }
        // //////////////////////////////////////////////////////////////////////////////

        // ////////////////////////////// AES//////////////////////////////////////////////////////

        private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int BlockSize = 128;
        private void button45_Click(object sender, EventArgs e)
        {
            inp6.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    inp6.AppendText(s);
                }

            }
        }

        private void button46_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(out6.Text);
                    sw.Close();
                }
            }
        }
        private void button51_Click_1(object sender, EventArgs e)
        {
            char temp1;
            string temp2;
            int n = 7;
            Random rand = new Random();
            varRad = new int[n];
            for (int i = 0; i < n; ++i)
            {
                varRad[i] = rand.Next(65, 90);
                temp1 = Convert.ToChar(varRad[i]);
                temp2 = Convert.ToString(temp1);
                key4.AppendText(temp2);

            }

        }

        private void button48_Click(object sender, EventArgs e)
        {
            key4.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.Default);
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    DKey.AppendText(s);
                }

            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(key4.Text);
                    sw.Close();
                }
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (key4.Text.Length > 0)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(inp6.Text);
                //Encrypt
                SymmetricAlgorithm crypt = Aes.Create();
                HashAlgorithm hash = MD5.Create();
                crypt.BlockSize = BlockSize;
                crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key4.Text));
                crypt.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }

                    out6.Text = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            else
                MessageBox.Show("Введіть ключове слово!");

        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (key4.Text.Length > 0)
            {
                byte[] bytes = Convert.FromBase64String(inp6.Text);
                SymmetricAlgorithm crypt = Aes.Create();
                HashAlgorithm hash = MD5.Create();
                crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key4.Text));
                crypt.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream(bytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[bytes.Length];
                        cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                        out6.Text = Encoding.Unicode.GetString(decryptedBytes);
                    }
                }
            }
            else
                MessageBox.Show("Введіть ключове слово!");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            inp6.Clear();
            out6.Clear();
            key4.Clear();
            
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void button54_Click(object sender, EventArgs e)
        {

            inp7.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251));
                while (!streamReader.EndOfStream)
                {
                    string s = (streamReader.ReadToEnd());
                    inp7.AppendText(s);
                }

            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(out7.Text);
                    sw.Close();
                }
            }
        }

        private int Rand()//Ф-я получения случайного числа
        {
            Random random = new Random();
            return random.Next();
        }
        int power(int a, int b, int n) 
        {
            int tmp = a;
            int sum = tmp;
            for (int i = 1; i < b; i++)
            {
                for (int j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                    {
                        sum -= n;
                    }
                }
                tmp = sum;
            }
            return tmp;
        }
        int mul(int a, int b, int n)
        {
            int sum = 0;
            for (int i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                {
                    sum -= n;
                }
            }
            return sum;
        }
        void crypt(int p, int g, int x, string strIn)
        {
            
            int y = power(g, x, p);
            Y.Text = y.ToString();
            if (strIn.Length > 0)
            {
                char[] temp = new char[strIn.Length - 1];
                temp = strIn.ToCharArray();
                for (int i = 0; i <= strIn.Length - 1; i++)
                {
                    int m = (int)temp[i];
                    if (m > 0)
                    {
                        int k = Rand() % (p - 2) + 1; // 1 < k < (p-1)
                        int a = power(g, k, p);
                        int b = mul(power(y, k, p), m, p);
                        out7.Text = out7.Text + a + " " + b + " ";
                    }
                }
            }
        }
        void decrypt(int p, int x, string strIn)
        {
            if (strIn.Length > 0)
            {
                
                string[] strA = strIn.Split(' ');
                if (strA.Length > 0)
                {
                    for (int i = 0; i < strA.Length - 1; i += 2)
                    {
                        char[] a = new char[strA[i].Length];
                        char[] b = new char[strA[i + 1].Length];
                        int ai = 0;
                        int bi = 0;
                        a = strA[i].ToCharArray();
                        b = strA[i + 1].ToCharArray();
                        for (int j = 0; (j < a.Length); j++)
                        {
                            ai = ai * 10 + (int)(a[j] - 48);
                        }
                        for (int j = 0; (j < b.Length); j++)
                        {
                            bi = bi * 10 + (int)(b[j] - 48);
                        }
                        if ((ai != 0) && (bi != 0))
                        {
                            int deM = mul(bi, power(ai, p - 1 - x, p), p);
                            char m = (char)deM;
                            out7.Text = out7.Text + m;
                        }
                    }
                }

            }
        }
        private void button60_Click(object sender, EventArgs e)
        {
            int p = 0; int g = 0;
            Random random = new Random();
            do
            {
                p = random.Next(0, 5000);
            } while (!IsTheNumberSimple(p));
            g = random.Next(2000,5000);
            int x = random.Next(1, p - 1); 
            BigInteger y = BigInteger.Pow(g, x) % p; 
            pp.Text = p.ToString();
            G.Text = g.ToString();        
            X.Text = x.ToString();

        }

        private void button58_Click(object sender, EventArgs e)
        {

            if ((pp.Text.Length > 0) && (G.Text.Length > 0) && (X.Text.Length > 0))
            {
                
                int p = Convert.ToInt32(pp.Text);                              
                int g = Convert.ToInt32(G.Text);
                int x = Convert.ToInt32(X.Text);
                
                if (IsTheNumberSimple(p))
                {
                    crypt(p, g, x, inp7.Text);
                }
                else
                    MessageBox.Show("Число не є простим!");
            }
            else
                MessageBox.Show("Введіть всі числа!");

        }

        private void button59_Click(object sender, EventArgs e)
        {
            if ((pp.Text.Length > 0) && (X.Text.Length > 0))
            {
                int p = Convert.ToInt32(pp.Text);
                int x = Convert.ToInt32(X.Text);
                decrypt(p, x, inp7.Text);
            }
            else
                MessageBox.Show("Введіть всі числа!");
            }

        private void button53_Click(object sender, EventArgs e)
        {
            inp7.Clear();
            out7.Clear();
            pp.Clear();
            G.Clear();
            Y.Clear();
            X.Clear();
        }

        private void button56_Click(object sender, EventArgs e)
        {

            var list = new List<int>();
            list.Add(Convert.ToInt32(pp.Text));
            list.Add(Convert.ToInt32(G.Text));
            list.Add(Convert.ToInt32(Y.Text));
            list.Add(Convert.ToInt32(X.Text));

            SaveFileDialog saveFileDialog3 = new SaveFileDialog();

            saveFileDialog3.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog3.OpenFile(), System.Text.Encoding.Default))
                {
                    foreach (var item in list)
                        sw.Write(item.ToString() + " ");
                    sw.Close();
                }
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                while (reader.EndOfStream != true)
                {
                    string q = reader.ReadToEnd();

                    List<string> P = new List<string>(q.Split(' '));
                    var listOfInt = P.Select(int.Parse);
                    pp.Text = P[0].ToString();
                    G.Text = P[1].ToString();
                    Y.Text = P[1].ToString();
                    X.Text = P[1].ToString();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
 
