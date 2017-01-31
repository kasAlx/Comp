using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Timers;
using System.Windows.Threading;



namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer;
        static public int valueUP = 5;
        static public int timersec = 2;
        public int Salary = 100;
        public int money = 100;


        class UserINF
        {

            public string name;
        }

        class infoINprogram
        {
            static void inf(string[] args)
            {
                UserINF myinfo = new UserINF();
                myinfo.name = "Alexey";
            }

        }

        private void moneyup(object sender, object e)
        {
            //money = 10;
            
        }


        public MainWindow()
        {
            this.InitializeComponent();
            moneyTEXT.Text = Convert.ToString(money);
            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();
            Health.Value = 100;
            Mood.Value = 100;
            Satiety.Value = 100;
        }

        



        private void Timer_Tick(object sender, object e)
        {
           
             Health.Value--;
             money = money + Salary;
             moneyTEXT.Text = Convert.ToString(money);
            if (money < 400)
            {
                SatietyUP5.IsEnabled = false;
                MoodUP5.IsEnabled = false;
                HealthUP5.IsEnabled = false;
            }
            else
            {
                SatietyUP5.IsEnabled = true;
                MoodUP5.IsEnabled = true;
                HealthUP5.IsEnabled = true;
            }

             Satiety.Value = Satiety.Value - timersec;
             Mood.Value = Mood.Value - timersec;
            if (Health.Value <= 30)
            {
                Health.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 176, 6, 6));
            }
            if (Health.Value == 0 || Satiety.Value == 0 || Mood.Value == 0)
            {
                timer.Stop();
                MessageBox.Show("Game Over", "Вы проиграли",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }

               

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        





        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void SatietyUP5_Click(object sender, RoutedEventArgs e)
        {
            Satiety.Value = Satiety.Value + valueUP;
            if (money >= 100) 
                {
                money = money - 100;
                moneyTEXT.Text = Convert.ToString(money);
            }
            else
            {
                MessageBox.Show("Нет денег", "Вам не хватает денег",
                               MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MoodUP5_Click(object sender, RoutedEventArgs e)
        {
           Mood.Value = Mood.Value + valueUP;
        }

        private void HealthUP5_Click(object sender, RoutedEventArgs e)
        {
            Health.Value = Health.Value + valueUP;
        }
    }
}
