using CourseWork.Model;
using CourseWork.View;
using System.Windows;
using CourseWork.Utils;
using CourseWork.Model.Data.Service;

namespace CourseWork.ViewModel
{
    public class AuthVM : BaseVM
    {
        public AuthVM()
        {
            Lang = lang;
        }

        #region PROPERTIES
        public static string Nickname { get; set; }
        public string Password { get; set; }



        private static string lang = "ru-RU";
        public static string Lang
        {
            get => lang;
            set { lang = value; }
        }

        #endregion

        #region METHODS
        private void _OpenMainWnd()
        {
            MainWindow mainWindow = new();
            if (UserService.AuthUser(Nickname, Password))
                CommonUtil.OpenWindow(mainWindow);
            else MessageBox.Show("Неверные логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        #endregion

        #region COMMANDS

        private readonly RelayCommand openMainWnd;
        public RelayCommand OpenMainWnd { get => openMainWnd ?? new(o => _OpenMainWnd()); }



        #endregion
    }
}
