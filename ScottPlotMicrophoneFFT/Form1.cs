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
            scottPlotUC1.fig.labelTitle = "INPUTS(Aj)";
            scottPlotUC1.fig.labelY = "Inputs ";
            scottPlotUC1.fig.labelX = "index";
            scottPlotUC1.Redraw();

            scottPlotUC2.fig.labelTitle = "INPUTS(Bj gauss)";
            scottPlotUC2.fig.labelY = "Gauss POW";
            scottPlotUC2.fig.labelX = "Index";
            scottPlotUC2.Redraw();

            scottPlotUC3.fig.labelTitle = "INPUTS(Aj gauss)";
            scottPlotUC3.fig.labelY = "MSE";
            scottPlotUC3.fig.labelX = "Index";
            scottPlotUC3.Redraw();

            scottPlotUC4.fig.labelTitle = "INPUTS(Bj)";
            scottPlotUC4.fig.labelY = "Inputs ";
            scottPlotUC4.fig.labelX = "index";
            scottPlotUC4.Redraw();

            scottPlotUC5.fig.labelTitle = "Mean Square Error Normal";
            scottPlotUC5.fig.labelY = "MSE";
            scottPlotUC5.fig.labelX = "index";
            scottPlotUC5.Redraw();


            scottPlotUC6.fig.labelTitle = "Mean Square Error gauss";
            scottPlotUC6.fig.labelY = "Inputs ";
            scottPlotUC6.fig.labelX = "index";
            scottPlotUC6.Redraw();


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
            int M = 21;
            double[] mse_arr = new double[M];
            double[] mse_arr_gauss = new double[M];
            double[] aJ = new double[M + 1];
            double[] bJ_normal = new double[M];
            double[] bJ_gauss = new double[M];
            double[] mse_gauss = new double[M];
            double[] aJ_gauss = new double[M + 1];
            double[] gauss = new double[M + 1];
            double MSE_er = 0;
            int minValue = -20, maxValue = 20;
            Random rand = new Random();

            for (int i = 0; i < M + 1; i++)
            {
            retry:
                aJ[i] = rand.Next(minValue, maxValue);
                for (int k = 0; k < i; k++)
                {
                    if (aJ[i] == aJ[k])
                        goto retry;
                }
            }
            Array.Sort(aJ);
            double ss = standart_sapma(aJ);
            double mu = ortalama(aJ);
            for (int j = 0; j < aJ.Length; j++)
            {
                gauss[j] = gauss_dagilimi(aJ[j], mu, ss);
            }
            for (int j = 0; j < aJ.Length; j++)
            {
                aJ_gauss[j] += gauss[j];
            }
            
            for (int i = 0; i < M; i++)
            {
                bJ_normal[i] = (aJ[i + 1] + aJ[i]) / 2;
                MSE_er = MSE(aJ, bJ_normal);
                label1.Text = "MSE=" + MSE_er;
                mse_arr[mseindex] = MSE_er;
                mseindex++;
            }
            mseindex = 0;
            for (int i = 0; i < M; i++)
            {
                bJ_gauss[i] = (aJ_gauss[i + 1] + aJ_gauss[i]) / 2;
                MSE_er = MSE(aJ_gauss, bJ_gauss);
                label1.Text = "MSE=" + MSE_er;
                mse_arr_gauss[mseindex] = MSE_er;
                mseindex++;
            }
            scottPlotUC1.Clear();
            scottPlotUC1.PlotSignal(aJ, 1, Color.Blue);
            scottPlotUC2.Clear();
            scottPlotUC2.PlotSignal(bJ_gauss, 1, Color.Blue);
            scottPlotUC3.Clear();
            scottPlotUC3.PlotSignal(aJ_gauss, 1, Color.Blue);
            scottPlotUC4.Clear();
            scottPlotUC4.PlotSignal(bJ_normal, 1, Color.Red);
            scottPlotUC5.Clear();
            scottPlotUC5.PlotSignal(mse_arr, 1, Color.Blue);
            scottPlotUC6.Clear();
            scottPlotUC6.PlotSignal(mse_arr_gauss, 1, Color.Blue);
            if (needsAutoScaling)
            {
                scottPlotUC1.AxisAuto();
                scottPlotUC2.AxisAuto();
                scottPlotUC3.AxisAuto();
                scottPlotUC4.AxisAuto();
                scottPlotUC5.AxisAuto();
                scottPlotUC6.AxisAuto();
                needsAutoScaling = false;
            }
            Application.DoEvents();
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
            scottPlotUC4.AxisAuto();
            scottPlotUC5.AxisAuto();
            scottPlotUC6.AxisAuto();
        }
    }
}
