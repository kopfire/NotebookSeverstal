using System.Windows;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для CreateNotebook.xaml
    /// </summary>
    public partial class CreateNotebook : Window
    {

        public CreateNotebook()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database.database.Add(textBox.Text);
            Close();
        }
    }
}
