using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KorobovToDoList.classes
{
    public class MessageBoxInfo
    {
        public static void ShowSuccess(string message, string title = "Успех!")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void ShowError(string message, string title = "Ошибка!")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static MessageBoxResult ShowQuestion(string message, string title = "Внимание!")
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
