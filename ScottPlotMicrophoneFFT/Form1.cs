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
            double MSE_er=0;





            Random rand = new Random();
            aJ[0] = Convert.ToUInt32(rand.Next(0, 100));
            for (int k = 1; k < M+1; k++)
            {
                if (k == 0)
                    aJ[k] = Convert.ToUInt32(rand.Next(Convert.ToInt32(aJ[0]), 100));
                else
                    aJ[k] = Convert.ToUInt32(rand.Next(Convert.ToInt32(aJ[k - 1]), 100));
            
            for (int i = 0; i < k; i++)
            {

                bJ[i] = (aJ[i + 1] + aJ[i]) / 2;
               
                double ss = standart_sapma(aJ);
                double mu = ortalama(aJ);
                for (int j = 0; j < k; j++)
                {
                    gauss[j] = gauss_dagilimi(aJ[j], mu, ss);

                }
           
               
            }
                MSE_er = MSE(aJ, bJ);

                label1.Text = "MSE=" + MSE_er;
                mse_arr[mseindex] = MSE_er;
                if (mseindex >= 1)
                {
                    if (MSE_er*100/100 <= mse_arr[mseindex - 1] )
                        break;
                }
                mseindex++;
            }

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
