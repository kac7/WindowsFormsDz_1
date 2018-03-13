using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDz_1_3
{
    //Представьте, что у вас на форме есть прямоугольник, границы которого на 10 пикселей отстоят от границ рабочей 
    //области формы. Необходимо создать следующие обработчики:
    //■■ Обработчик нажатия левой кнопки мыши, который выводит сообщение о том, где находится текущая точка: внутри
    //прямоугольника, снаружи, на границе прямоугольника. Если при нажатии левой кнопки мыши была нажата кнопка
    //Control (Ctrl), то приложение должно закрываться;
    //■■ Обработчик нажатия правой кнопки мыши, который выводит в заголовок окна информацию о размере клиентской
    //(рабочей) области окна в виде: Ширина = x, Высота = y, где x и y – соответствующие параметры вышего окна;
    //■■ Обработчик перемещения указателя мыши в пределах рабочей области, который должен выводить в заголовок окна
    //текущие координаты мыши x и y.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += MyMouseMove;
            this.MouseClick += MyMouseClick;
        }
        private void MyMouseClick(object sender, MouseEventArgs e)
        {
            string text = "";
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    Close();
                }

                if ((e.X < 10 || e.X > ClientSize.Width - 10) || (e.Y < 10 || e.Y > ClientSize.Height - 10))
                {
                    text = "Клик снаружи прямоугольника!";
                }
                else if ((e.X == 10 || e.X == ClientSize.Width - 10) || (e.Y == 10 || e.Y == ClientSize.Height - 10))
                {
                    text = "Клик на границе прямоугольника!";
                }
                else
                {
                    text = "Клик внутри прямоугольника!";
                }
                MessageBox.Show(text, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Размере клиентской области окна! Ширина = {ClientSize.Width}, Высота = {ClientSize.Height}";
                Thread.Sleep(2000);
            }
        }
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            Text = $"X {e.X} - Y {e.Y}";  
        }
    }
}
