using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekPlan
{
    internal class Commands
    {
        string path = AppDomain.CurrentDomain.BaseDirectory+@"weekplan.csv";
        public void saveFile(ComboBox cb1, DateTimePicker dtp, TextBox tb2)
        {
            Form1 frm = new Form1();
            StringBuilder sb = new StringBuilder();

            if (!File.Exists(path))
            {
                sb.Append("Tarih "); sb.Append(";");
                sb.Append("İş Veren".ToString()); sb.Append(";");
                sb.AppendLine("Açıklama".ToString());
            }


            if (cb1.Text == string.Empty)
            {
                MessageBox.Show("Alanlar boş bırakılamaz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sb.Append(dtp.Value.ToShortDateString()); sb.Append(";");
                sb.Append(cb1.Text); sb.Append(";");
                sb.AppendLine(tb2.Text);
                File.AppendAllText(path, sb.ToString(), Encoding.UTF8);
                if (cb1.Text != "Süleyman Bey" && cb1.Text != "Ali Bey" && cb1.Text != "Tarık Bey")
                {
                    cb1.Items.Add(cb1.Text);
                }
                tb2.Clear();
                cb1.ResetText();
                MessageBox.Show("Başarılı bir şekilde eklendi...", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
        public void fileOpen(ComboBox cb1, DateTimePicker dtp, TextBox tb2)
        {
            StringBuilder sb = new StringBuilder();
            if (!File.Exists(path))
            {

                sb.Append("Tarih "); sb.Append(";");
                sb.Append("İş Veren".ToString()); sb.Append(";");
                sb.AppendLine("Açıklama".ToString());
                File.AppendAllText(path, sb.ToString(), Encoding.UTF8);
                MessageBox.Show(path + " dosyası bulunamadı." + " Boş bir tane oluşturuldu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            System.Diagnostics.Process.Start(path);

        }

        public DataTable DataCSV()
        {
            DataTable dt = new DataTable();

            string[] lines = File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                string firtsLine = lines[0];
                string[] headLabels = firtsLine.Split(';');

                foreach (string headerWord in headLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(';');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    for (int j = 0; j < dataWords.Length; j++)
                    {
                        dr[j] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;



        }



    }

}
