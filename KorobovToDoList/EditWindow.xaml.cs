using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace KorobovToDoList
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly classes.Task _task;
        public EditWindow(classes.Task taskToEdit)
        {
            InitializeComponent();
            _task = taskToEdit;
            EditTextBox.Text = _task.Title;
            EditDatePiker.SelectedDate = _task.DueDate;
        }

        private void EditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EditTextBox.Text))
            {
                classes.MessageBoxInfo.ShowError("Введите измененную задачу!");
                return;
            }
            _task.Title = EditTextBox.Text;
            _task.DueDate = EditDatePiker.SelectedDate ?? DateTime.Today;
            DialogResult = true;
        }
        private void EditCancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
