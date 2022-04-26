using System.ComponentModel;
using System.Windows;

namespace Notebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly Database database = new();
        static int count = 0;

        public MainWindow()
        {
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
            database.Read();
            InitializeComponent();
            string data = Database.database[count];
            if (data.Equals(""))
                textBlock.Text = "На данный момент заметок нет";
            else
                textBlock.Text = data;
            InitializeComponent(); 
            //почти уверен, что есть более адекватный способ обновить состояние, который я не смог найти..)
        }

        /// <summary>
        /// Переход к предыдущей заметке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Left(object sender, RoutedEventArgs e)
        {
            count--;
            if (count < 0)
            {
                count++;
                MessageBox.Show("Это первая запись");
                return;
            }
            textBlock.Text = Database.database[count];
            InitializeComponent();
        }

        /// <summary>
        /// Переход к следующей заметке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Right(object sender, RoutedEventArgs e)
        {
            count++;
            if (count >= Database.database.Count)
            {
                count--;
                MessageBox.Show("Это последняя запись");
                return;
            }
            textBlock.Text = Database.database[count];
            InitializeComponent();
        }

        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Create(object sender, RoutedEventArgs e)
        {
            CreateNotebook taskWindow = new();
            taskWindow.Show();
        }

        /// <summary>
        /// Изменение заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            EditNotebook taskWindow = new(Database.database[count], count);
            taskWindow.Show();
        }


        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Database.database.RemoveAt(count);
            if (count == 0)
                if (count < Database.database.Count)
                    textBlock.Text = Database.database[++count];
                else
                    textBlock.Text = "На данный момент заметок нет";
            else
                textBlock.Text = Database.database[--count];
            InitializeComponent();
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            database.Write();
        }
    }
}
