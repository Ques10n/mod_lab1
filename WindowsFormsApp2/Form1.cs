using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public Form1()
        {
            InitializeComponent();
        }

        const double dt = 0.05;

        const double g = 9.81;
        const double c = 0.15;
        const double Rho = 1.29;
        double height, angle, speed, s, m;

        

        double t, x, y, cosa, sina, beta, k, vx, vy;

        private void btStart_Click(object sender, EventArgs e)
        {
            height = (double)edHeight.Value;
            angle = (double)edAngle.Value;
            speed = (double)edSpeed.Value;
            s = (double)edSize.Value;
            m = (double)edMass.Value;

            cosa = Math.Cos(angle * Math.PI / 180);
            sina = Math.Sin(angle * Math.PI / 180);
            beta = 0.5 * c * s * Rho;
            k = beta / m;


            t = 0;
            x = 0;
            y = height;
            vx = speed * cosa;
            vy = speed * sina;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(x, y);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double vx_old = vx;
            double vy_old = vy;
            double root = Math.Sqrt(vx*vx + vy*vy);

            t = t + dt;
            vx = vx_old - k * root * vx_old * dt;
            vy = vy_old - (g + k * vy_old * root) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            chart1.Series[0].Points.AddXY(x, y);

            if (y <= 0) timer1.Stop();
           
        }
    }

    }

