using KoerselslogApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace KoerselslogApp.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();


        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();

        }
    }
}
