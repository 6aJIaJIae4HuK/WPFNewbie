using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = null;
        int Count = 0;
        int HighScore = 0;
        public MainWindow()
        {
            InitializeComponent();
            int rT = RenderCapability.Tier >> 16;
            Console.WriteLine(rT);
        }

        private void timerStart()
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            String s = "Your score is " + Convert.ToString(Count);
            if (Count>HighScore)
            {
                HighScore = Count;
                s += "\nCongratulations! This is new high-score!!!";
                lbl.Content = "High Score: " + Convert.ToString(HighScore);
            }
            MessageBox.Show(s);
            Count = 0;
        }

        void OnClick1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void OnClick2(object sender, RoutedEventArgs e)
        {
            if (Count == 0)
            {
                timerStart();    
            }
            Count++;
        }
    }
}
