using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;

namespace Roulette
{
    class rollBall
    {
        public enum states{ RED, BLACK, NONE };
        public enum winLose{ WIN, LOSE };
        public int[] redNumbers = new int[] {1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        public int[] blackNumbers = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        bool checkColor = false;
        public int rollPresent;

        public states selectedState;

        public void randomNumber()
        {
            Random rngNm = new Random();
            rollPresent = rngNm.Next(1, 37);
        }
        public bool checkForColor(int tempInt, int[] tempIntArray)
        {
            checkColor = false;
            foreach (int n in tempIntArray)
            {
                if (n == tempInt)
                    checkColor = true;
                else { }
                    
            }
            return checkColor;
        }
        public Color ellipseColorDecider()
        {
            if (checkForColor(rollPresent, redNumbers)){
                selectedState = states.RED;
                return Colors.Red;
            }
            else if (checkForColor(rollPresent, blackNumbers)){
                selectedState = states.BLACK;
                return Colors.Black;
            }
            else{
                selectedState = states.NONE;
                return Colors.Transparent;
            }
        }
        public bool checkIfWon(RadioButton r, RadioButton b)
        {
            if (r.IsChecked == true && selectedState == states.RED)
                return true;
            else if (b.IsChecked == true && selectedState == states.BLACK)
                return true;
            else
                return false;
        }
        public bool checkIfChecked(RadioButton r, RadioButton b)
        {
            if (r.IsChecked == false && b.IsChecked == false)
                return false;
            else
                return true;
        }
            
        
    }
}
