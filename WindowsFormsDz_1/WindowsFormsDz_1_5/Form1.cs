using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDz_1_5
{

    //Разработать приложение «убегающий статик»:) Суть приложения: на форме расположен статический элемент 
    //управления(«статик»). Пользователь пытается подвести курсор мыши к «статику», и, если курсор находиться 
    //близко со статиком, элемент управления «убегает». Предусмотреть перемещение «статика» только в пределах формы.
    public partial class Form1 : Form
    {
        Label label;
        public Form1()
        {
            InitializeComponent();
            Text = "Приложение «убегающий статик»";
            label = new Label();
            this.Load += FormLoad;
            this.MouseMove += FormMouseMove;
        }
        private void FormLoad(object sender, EventArgs e)
        {
            label.BorderStyle = BorderStyle.Fixed3D;
            label.Size = new Size(80, 40);
            label.Text = $"Я «статик»";
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;
            label.ForeColor = Color.White;
            label.BackColor = Color.Red;
            Controls.Add(label);
            LableCenter(label);
        }
        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X > label.Location.X - 20 && e.X < label.Location.X + label.Width + 20) && (e.Y > label.Location.Y - 20 && e.Y < label.Location.Y + label.Height + 20))
            {
                if (e.X > label.Location.X - 20 && e.X < label.Location.X)//движение курсора с лева по оси Х
                {
                    label.Left += 10;
                }
                else if (e.X < label.Location.X + label.Width + 20 && e.X > label.Location.X + label.Width)//движение курсора с права по оси Х
                {
                    label.Left -= 10;
                }
                else if (e.Y > label.Location.Y - 20 && e.Y < label.Location.Y)//движение курсора с верху по оси У
                {
                    label.Top += 10;
                }
                else if (e.Y < label.Location.Y + label.Height + 20 && e.Y > label.Location.Y + label.Height)//движение курсора с низу по оси У
                {
                    label.Top -= 10;
                }
                //Проверка границ окна и возврат «статика» в центр
                if ((label.Location.X < 0 || label.Location.X > ClientSize.Width - label.Width) || (label.Location.Y < 0 || label.Location.Y > ClientSize.Height - label.Height))
                {
                    LableCenter(label);
                }
            }
        }
        void LableCenter(Label lable) //центрирование «статика»
        {
            label.Left = (ClientSize.Width - label.Size.Width) / 2;
            label.Top = (ClientSize.Height - label.Size.Height) / 2;
        }
    }
}
