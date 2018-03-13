using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDz_1_2
{
    //Написать функцию, которая «угадывает» задуманное пользователем число от 1 до 2000. 
    //Для запроса к пользователю использовать MessageBox.После того, как число отгадано, 
    //необходимо вывести количество запросов, потребовавшихся для этого, и предоставить
    //пользователю возможность сыграть еще раз, не выходя из программы 
    //(MessageBox’ы оформляются кнопками и значками соответственно ситуации).
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += StartGame;
        }

        private void StartGame(object sender, EventArgs e)
        {
            DialogResult result;
            int numDialog = 1;
            while (true)
            {
                result = MessageBox.Show($"{new Random().Next(1, 2000)}", "Вы загадали число", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"Количество запросов {numDialog}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numDialog = 0;
                    result = MessageBox.Show($"Хотите продолжить?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) this.Close();
                }
                numDialog++;
            }
        }
    }
}
