using KorobovToDoList.classes;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KorobovToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<classes.Task> _tasks = new ObservableCollection<classes.Task>();
        public MainWindow()
        {
            InitializeComponent();
            TasksList.ItemsSource = _tasks;
            DueDatePicker.SelectedDate = DateTime.Now;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewTaskTextBox.Text) || NewTaskTextBox.Text == "Введите задачу...")
            {
                MessageBoxInfo.ShowError("Введите вашу задачу!");
                return;
            }
            if(DueDatePicker.SelectedDate == null)
            {
                MessageBoxInfo.ShowError("Выберите дату!");
                return;
            }
            var newTask = new classes.Task
            {
                ID = _tasks.Count + 1,
                Title = NewTaskTextBox.Text,
                DueDate = DueDatePicker.SelectedDate.Value,
                IsCompleted = false,
            };

            _tasks.Add(newTask);
            NewTaskTextBox.Clear();
            NewTaskTextBox.Focus();

        }
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedItem == null)
            {
                MessageBoxInfo.ShowError("Сначала выберите задачу!");
                return;
            }
            var selectResult = MessageBoxInfo.ShowQuestion("Вы действительно хотите удалить задачу?");
            if (selectResult == MessageBoxResult.Yes)
            {
                var selectedTask = (classes.Task)TasksList.SelectedItem;
                _tasks.Remove(selectedTask);
                MessageBoxInfo.ShowSuccess("Задача удалена.");
            } else
            {
                return;
            }
        }
        private void CorButton_Click(Object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedItem == null)
            {
                MessageBoxInfo.ShowError("Сначала выберите задачу!");
                return;
            }
            var selectedTask = (classes.Task)TasksList.SelectedItem;

            var editWindow = new EditWindow(selectedTask);
            editWindow.Owner = this;

            bool? result = editWindow.ShowDialog();
            if(result == true)
            {
                TasksList.Items.Refresh();
                MessageBoxInfo.ShowSuccess("Задача изменена.");
            }
        }
        private void SecretButton_click(object sender, RoutedEventArgs e)
        {
            var SecretWindow = new SecretWindow();
            SecretWindow.Owner = this;
            SecretWindow.ShowDialog();
        }
    }

}