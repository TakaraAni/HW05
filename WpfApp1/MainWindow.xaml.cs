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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] studen_score = { 80, 70, 60, 50, 30, 75, 65, 81, 92, 66 };
            int a = 0, i = 0;

            /****************************平均值*************************************/
            for (i = 0; i < studen_score.Length ; i++)
            {
                a = a + studen_score[i];
            }
            double get_label1_anser = a;
            get_label1_anser = get_label1_anser / 10;
            label1_anser.Content = get_label1_anser;     //Get AnserOne Score
            /******************************標準差**************************************/
            double get_label2_anser = 0;
            for (i = 0; i < studen_score.Length ; i++)
            {
                get_label2_anser = get_label2_anser + Math.Pow(studen_score[i] - get_label1_anser, 2);
            }
            get_label2_anser = get_label2_anser / 10;
            get_label2_anser = Math.Sqrt(get_label2_anser);
            label2_anser.Content = get_label2_anser;    //Get AnserTwo Score
            /******************************偏差加分**************************************/
            double checknum = 0;
            double anser3 = 0;
            for (i = 0; i < studen_score.Length ; i++)
            {
                anser3 = studen_score[i];

                checknum = (anser3 - get_label1_anser) / studen_score.Length-1;
                checknum = Math.Sqrt(checknum);         //Get AnserThree Anser Key,but it's not std score
                
                if (checknum < get_label2_anser) 
                {
                    MessageBox.Show("同學[" + i + "] 分數高於標準差，分數為:" + anser3 );
                }
                else
                {
                    anser3 += 2;
                    MessageBox.Show("同學[" + i + "]分數低於標準差，加分後分數為:" + anser3);
                }
            }
        }
    }
}
