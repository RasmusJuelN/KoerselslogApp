
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using KoerselslogApp.Models;
using KoerselslogApp.Repositories;

namespace KoerselslogApp.ViewModels
{
    internal class UserViewModel : ViewModelBase
    {

        // Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount 
        { 
            get
            {
                return _currentUserAccount;
            } 
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        
        // Commands
        public ICommand AddNewDriverLogCommand { get; }

        // Constructor
        public UserViewModel()
        {
            userRepository = new UserRepository();
            LoadCurrentUserData();

        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"Velkommen {user.FirstName} {user.LastName}"
                };
            }
            
            else
            {
                MessageBox.Show("Bruger findes ikke.");
            }
            
        }
    }
}
