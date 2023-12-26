using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.KasenovAE.Sprint6.TaskReview.V14.Lib;

namespace Tyuiu.KasenovAE.Sprint6.TaskReview.V14
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            try
            {
                int n1 = Convert.ToInt32(textBoxn1.Text);
                int n2 = Convert.ToInt32(textBoxn2.Text);
                int M = Convert.ToInt32(textBoxM.Text);
                int N = Convert.ToInt32(textBoxN.Text);

                this.dataGridView.RowCount = M;
                this.dataGridView.ColumnCount = N;

                Random r = new Random();
                int[,] arr = new int[M, N];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = r.Next(n1, n2);
                        if (j % 2 == 0 && j != 0)
                            arr[i, j] = arr[i, j - 1] * arr[i, j - 2];
                        dataGridView.Columns[j].Width = 25;
                        dataGridView.Rows[i].Cells[j].Value = Convert.ToString(arr[i, j]);
                    }
                }

                DataService ds = new DataService();
                int K = Convert.ToInt32(textBoxK.Text);
                int L = Convert.ToInt32(textBoxL.Text);
                int C = Convert.ToInt32(textBoxC.Text);

                if (n1 >= n2 || K >= L || C >= N || C < 0 || K < 0 || L >= M)
                {
                    MessageBox.Show("Введены неправильные данные");
                }
                else
                {
                    for (int i = K; i <= L; i++)
                    {
                        if (i % 2 == 0)
                        {
                            dataGridView.Rows[i].Cells[C].Style.BackColor = System.Drawing.Color.Gray;
                        }
                    }
                    dataGridView.Columns[C].HeaderText = Convert.ToString(C);
                    textBoxResult.Text = Convert.ToString(ds.GetMatrix(arr, C, K, L));
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }
    }
}
