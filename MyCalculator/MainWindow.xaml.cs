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

namespace MyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool opFlag = false; //true이면 연산자 버튼을 클릭한 직 후
        private double saved = 0;   //연산자 버튼이 클릭 될 때 txtResult의 값
        private string op = String.Empty;
        private double memory = 0;

        public MainWindow()
        {
            InitializeComponent();
            btnMR.IsEnabled = false;
            btnMC.IsEnabled = false;
        }

        //숫자 버튼을 처리한다
        private void btnClick(object send, RoutedEventArgs e)
        {
            Button btn = send as Button;

            if (txtResult.Text == "0" || opFlag)
            {
                txtResult.Text = btn.Content.ToString();
                opFlag = false;
            }
            else
            {
                txtResult.Text += btn.Content.ToString();
            }
        }

        //소수점 처리
        private void btnDotClick(object send, RoutedEventArgs e)
        {
            if (txtResult.Text.Contains("."))
            {
                return;
            }
            else
            {
                txtResult.Text += ".";
            }
        }

        //플러스 마이너스 변환 처리
        private void btnPlusMinusClick(object send, RoutedEventArgs e)
        {
            double v = double.Parse(txtResult.Text);
            v = -v;
            txtResult.Text = v.ToString();
        }

        //사칙연산 처리
        private void btnOpClick(object send, RoutedEventArgs e)
        {
            opFlag = true; //숫자를 새로 써주기 위해
            saved = double.Parse(txtResult.Text);

            Button btn = send as Button;
            op = btn.Content.ToString(); //연산자 저장

            txtExp.Text += txtResult.Text + " " + op;
        }

        //equal버튼이 클릭 되었을 때 처리
        private void btnEqualClick(object send, RoutedEventArgs e)
        {
            //TODO 나중에 사칙연산자를 2개 이상 사용가능 하게 수정
            double v = double.Parse(txtResult.Text);
            switch (op)
            {
                case "+":
                    txtResult.Text = (saved + v).ToString();
                    break;
                case "-":
                    txtResult.Text = (saved - v).ToString();
                    break;
                case "×":
                    txtResult.Text = (saved * v).ToString();
                    break;
                case "÷":
                    txtResult.Text = (saved / v).ToString();
                    break;
            }

            txtExp.Text = saved + " " + op + " " + v + "=";
        }

        //제곱, 제곱근, 역수 기능 처리
        private void btnSqrtClick(object send, RoutedEventArgs e)
        {
            txtExp.Text = "√(" + txtResult.Text + ")";
            txtResult.Text = (Math.Sqrt(double.Parse(txtResult.Text))).ToString();
        }
        private void btnSqrClick(object send, RoutedEventArgs e)
        {
            txtExp.Text = "sqr(" + txtResult.Text + ")";
            txtResult.Text = (double.Parse(txtResult.Text) * double.Parse(txtResult.Text)).ToString();
        }
        private void btnRecipClick(object send, RoutedEventArgs e)
        {
            txtExp.Text = "1 / (" + txtResult.Text + ")";
            txtResult.Text = (1 / double.Parse(txtResult.Text)).ToString();
        }

        //삭제 버튼 처리
        private void btnCEClick(object send, RoutedEventArgs e)
        {
            txtResult.Text = "0";
        }
        private void btnCClick(object send, RoutedEventArgs e)
        {
            txtResult.Text = "0";
            txtExp.Text = "";
            saved = 0;
            op = "";
            opFlag = false;
        }
        private void btnDeleteClick(object send, RoutedEventArgs e)
        {
            //값을 대 지우면 0이 됨게끔 처리
            if((txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1)) == "")
            {
                txtResult.Text = "0";
            }
        }

        //메모리 관련 버튼 처리
        private void btnMCClick(object sender, RoutedEventArgs e)
        {
            memory = 0;
            btnMC.IsEnabled = false;
            btnMR.IsEnabled = false;
        }

        private void btnMRClick(object sender, RoutedEventArgs e)
        {
            txtResult.Text = memory.ToString();
        }

        private void btnMPlusClick(object sender, RoutedEventArgs e)
        {
            memory += double.Parse(txtResult.Text);
        }

        private void btnMMinusClick(object sender, RoutedEventArgs e)
        {
            memory -= double.Parse(txtResult.Text);
        }

        private void btnMSaveClick(object sender, RoutedEventArgs e)
        {
            memory = double.Parse(txtResult.Text);
            btnMC.IsEnabled = true;
            btnMR.IsEnabled = true;
        }

        //끝내기 처리
        private void MenuCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
