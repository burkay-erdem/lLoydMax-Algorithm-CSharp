using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ScottPlotMicrophoneFFT
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            SetupGraphLabels();
            // timerReplot.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void SetupGraphLabels()
        {
            scottPlotUC1.fig.labelTitle = "INPUTS";
            scottPlotUC1.fig.labelY = "Inputs ";
            scottPlotUC1.fig.labelX = "index";
            scottPlotUC1.Redraw();

            scottPlotUC2.fig.labelTitle = "GAUSS Distribution";
            scottPlotUC2.fig.labelY = "Gauss POW";
            scottPlotUC2.fig.labelX = "Index";
            scottPlotUC2.Redraw();

            scottPlotUC3.fig.labelTitle = "Mean Square Error";
            scottPlotUC3.fig.labelY = "MSE";
            scottPlotUC3.fig.labelX = "Index";
            scottPlotUC3.Redraw();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // turn off the timer, take as long as we need to plot, then turn the timer back on
            timerReplot.Enabled = false;
            PlotLatestData();
            timerReplot.Enabled = true;
        }

        public int numberOfDraws = 0;
        public bool needsAutoScaling = true;
        public void PlotLatestData()
        {
            int mseindex = 0;
            int M = 20;
            double[] mse_arr = new double[M];
            double[] aJ = new double[M + 1];
            double[] bJ = new double[M];
            double[] gauss = new double[M + 1];
            double MSE_er = 0;
            int minValue = -20, maxValue = 20;

            Random rand = new Random();

            for (int i = 0; i < M + 1; i++)
            {
                aJ[i] = rand.Next(minValue, maxValue);
            }


            Array.Sort(aJ);


            for (int i = 0; i < M; i++)
            {

                bJ[i] = (aJ[i + 1] + aJ[i]) / 2;

                double ss = standart_sapma(aJ);
                double mu = ortalama(aJ);
                for (int j = 0; j < M; j++)
                {
                    gauss[j] = gauss_dagilimi(aJ[j], mu, ss);

                }
                MSE_er = MSE(aJ, bJ);

                label1.Text = "MSE=" + MSE_er;
                mse_arr[mseindex] = MSE_er;
                mseindex++;

            }

            //if (mseindex >= 1)
            //{
            //    if (MSE_er*100/100 <= mse_arr[mseindex - 1] )
            //        break;
            //}
           


            scottPlotUC1.Clear();
            scottPlotUC1.PlotSignal(aJ, 1, Color.Blue);
            scottPlotUC2.Clear();
            scottPlotUC2.PlotSignal(gauss, 1, Color.Blue);
            scottPlotUC3.Clear();
            scottPlotUC3.PlotSignal(mse_arr, 1, Color.Blue);

            if (needsAutoScaling)
            {
                scottPlotUC1.AxisAuto();
                scottPlotUC2.AxisAuto();
                scottPlotUC3.AxisAuto();
                needsAutoScaling = false;
            }

            Application.DoEvents();
        }

        private void autoScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsAutoScaling = true;
        }

        private void infoMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg += "left-click-drag to pan\n";
            msg += "right-click-drag to zoom\n";
            msg += "middle-click to auto-axis\n";
            msg += "double-click for graphing stats\n";
            MessageBox.Show(msg);
        }

        public void itteration()
        {
            for (int q = 0; q < 6; q++)
            {

                int bit = q;
                int q_levels = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(bit)));
                int[] sk = new int[q_levels];
                int[] lu = new int[q_levels];
                int[] neww = new int[q_levels];
                int[] m = new int[q_levels + 1];
                int[] X = new int[q_levels];
                int[] Y = new int[q_levels];
                int minv = -10;
                int maxv = 10;
                int len = (-1 * minv + maxv) / q_levels;
                int[] a = new int[X.Length];
                int[] b = new int[X.Length];
                double[] msı = new double[X.Length];
                for (int i = 0; i < q_levels + 1; i++)
                {
                    m[i] = minv + (i - 1) * len;
                }


                var dat = from data in m
                          orderby m ascending
                          select data;
                int f = 0;
                int[] sig = new int[m.Length];
                foreach (var item in dat)
                {
                    sig[f++] = item;
                }
                for (int i = 1; i < q_levels; i++)
                {
                    for (int k = 1; k < q_levels; k++)
                    {
                        sk[k] = cent(m[k], m[k + 1], sig[0], k, q_levels);
                        lu[k] = cent(m[k], m[k + 1], sig[0], k, q_levels);
                        neww[k] = sk[k] / lu[k];
                    }
                    for (int k = 2; k < q_levels; k++)
                    {

                        m[k] = (neww[k - 1] + neww[k]) / 2;
                    }
                    for (int h = 1; h < q_levels; h++)
                    {
                        for (int t = 1; t < 10000; t++)
                        {
                            if (X[t] < m[h + 1] && X[t] >= m[h])
                            {
                                Y[t] = neww[h];
                            }
                        }
                    }
                    for (int ş = 0; ş < X.Length; ş++)
                    {
                        a[ş] = X[ş] - Y[ş];
                        b[ş] = Convert.ToInt32(Math.Pow(Convert.ToDouble(a[ş]), 2));
                    }
                    int sum = 0;
                    for (int ii = 0; ii < b.Length; ii++)
                    {
                        sum += b[ii];
                    }
                    msı[i] = sum / 10000;
                }

                scottPlotUC1.Clear();
                scottPlotUC1.PlotSignal(msı, 1, Color.Blue);

            }
        }

        public int cent(int m, int m1, int sig, int k, int q_levels)
        {
            int cent = 0;
            return cent;
        }

        public double gauss_dagilimi(double x, double mu, double ss)
        {

            double çarpan;
            çarpan = Convert.ToDouble(1 / Math.Sqrt(2 * Math.PI * ss * ss));
            return çarpan * Math.Pow(Math.E, (-1 * (x - mu) * (x - mu) / (2 * ss * ss)));
        }

        public double MSE(double[] aj1, double[] bj1)
        {

            double sum_sq = 0;
            double mse;

            for (int i = 0; i < aj1.Length - 1; ++i)
            {


                double p1 = aj1[i];
                double p2 = bj1[i];
                double err = p2 - p1;
                sum_sq += (err * err);

            }
            mse = (double)sum_sq / (bj1.Length);
            return mse;
        }
        double ortalama(double[] liste)
        {
            int liste_sayisi = 0;
            double liste_toplami = 0;
            double ortalama = 0;

            int i = 0;

            while (liste_sayisi < liste.Length)
            {
                liste_toplami += liste[liste_sayisi];
                liste_sayisi += 1;
            }
            ortalama = liste_toplami / liste_sayisi;
            return ortalama;
        }
        double standart_sapma(double[] liste)
        {
            int liste_sayisi = 0;
            double liste_toplami = 0;
            double ortalama = 0;
            double fark_karesi = 0;
            double genel_toplam = 0;
            int i = 0;

            while (liste_sayisi < liste.Length)
            {
                liste_toplami += liste[liste_sayisi];
                liste_sayisi += 1;
            }
            ortalama = liste_toplami / liste_sayisi;


            while (i < liste_sayisi)
            {
                fark_karesi = liste[i] - ortalama;
                fark_karesi = fark_karesi * fark_karesi;
                fark_karesi = fark_karesi / (liste_sayisi - 1);
                genel_toplam += fark_karesi;

                i = i + 1;
            }

            genel_toplam = Math.Sqrt(genel_toplam);


            return genel_toplam;
        }
        private void button1_Click(object sender, EventArgs e)
        {


            PlotLatestData();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control)
                this.AutoScroll = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control)
                this.HScroll = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            scottPlotUC1.AxisAuto();
            scottPlotUC2.AxisAuto();
            scottPlotUC3.AxisAuto();
        }
    }
}
