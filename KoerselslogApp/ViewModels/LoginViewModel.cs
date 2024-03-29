﻿using GalaSoft.MvvmLight.Command;
using KoerselslogApp.Models;
using KoerselslogApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KoerselslogApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string? _username;
        private SecureString? _password;
        private string? _errorMessage;

        private IAdminRepository adminRepository;
        private IUserRepository userRepository;

        public RelayCommand<IClosable> CloseWindowCommand { get; set; }

        public string? Username
        { 
            get 
            { 
                return _username;
            }  
            
            set 
            { 
                _username = value; 
                OnPropertyChanged(nameof(Username)); 
            }
        }

        public SecureString? Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string? ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(_errorMessage));
            }
        }


        // -> Commands
        public ICommand LoginCommand { get;  }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

   



        // Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            adminRepository = new AdminRepository();
            LoginCommand = new ViewModelCommands(ExecuteLoginCommand, CanExecuteLoginCommand);
            this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
        }

        private void CloseWindow(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username == null || Password == null)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
               
        }
        public event EventHandler OnRequestClose;
        private void ExecuteLoginCommand(object obj)
        {
  
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            var isValidAdmin = adminRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                

            }

            
            else if (isValidAdmin)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                

            }

            else
            {
                ErrorMessage = "Forkert Username eller Password.";
                MessageBox.Show("Ugyldigt login");
            }

        }        

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
