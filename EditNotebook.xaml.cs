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
using System.Windows.Shapes;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для EditNotebook.xaml
    /// </summary>
    public partial class EditNotebook : Window
    {

        int count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldText">Текст заметки</param>
        /// <param name="count">Id заметки в массиве</param>
        public EditNotebook(string oldText, int count)
        {
            this.count = count;
            InitializeComponent();
            textBox.Text = oldText;
            InitializeComponent(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database.database[count] = textBox.Text;
            Close();
        }
    }
}
