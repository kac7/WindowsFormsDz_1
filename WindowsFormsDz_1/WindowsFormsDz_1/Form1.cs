using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDz_1
{
//Вывести на экран свое(краткое!!!) резюме с помощью последовательности MessageBox’ов(числом не менее трех). Причем на заголовке
//последнего должно отобразиться среднее число символов на странице (общее количество символов в резюме / количество MessageBox’ов).
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += ShowMesBox;
        }

        private void ShowMesBox(object sender, EventArgs e)
        {
            string[] array = { "Студент: Акулов Константин", "Предмет: Windows Forms", "Группа: ПС/РПО/2016/2" };
            int numSymbol = 0;
            string caption;

            for (int i = 0; i < array.Length; i++)
            {
                numSymbol += array[i].Length;
                caption = (array.Length-1 == i)?$"MessageBox {i+1}. Среднее число символов - {numSymbol/array.Length}":$"MessageBox {i+1}";
                MessageBox.Show(array[i], caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
