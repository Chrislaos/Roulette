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
using System.Threading;

namespace Roulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        rollBall rollingBall1 = new rollBall();
        Thread T;
        delegate void del();
        del updateDelegate;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //T = new Thread(process);
                //T.Start();
                process();
            }
            catch(Exception b)
            {
                statusBlock.Text = b.ToString();
            }
        }
        public void process()
        {
            rollingBall1.randomNumber();
            numberDisplay.Text = rollingBall1.rollPresent.ToString();

            updateDelegate = () => switchVisibleColor(rollingBall1.ellipseColorDecider());
            this.Dispatcher.Invoke(updateDelegate, new object[] { });

            winningOrLosingDisplay(rollingBall1.checkIfWon(radioRed, radioBlack));
            checkIfChoosen(rollingBall1.checkIfChecked(radioRed, radioBlack));
        }
        public void switchVisibleColor(Color tempColor)
        {
            ellipseColor.Fill = new SolidColorBrush(tempColor);
        }
        public void winningOrLosingDisplay(bool won)
        {
            if (won)
                statusBlock.Text = "YOU WON";
            else
                statusBlock.Text = "YOU LOSE";
        }
        public void checkIfChoosen(bool checker)
        {
            if (checker) { }
                
            else { statusBlock.Text += ", You need to pick a side!"; }
        }
    }
}
