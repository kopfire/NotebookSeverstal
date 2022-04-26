using System.Windows;

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
