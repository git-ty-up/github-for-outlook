﻿using System.Windows.Input;
using GithubForOutlook.Logic.Models;
using NGitHub;
using NGitHub.Authentication;
using VSTOContrib.Core.Wpf;

namespace GithubForOutlook.Logic.Modules.Settings
{
    public class SettingsViewModel : OfficeViewModelBase
    {
        private readonly IGitHubOAuthAuthorizer authorizer;

        public SettingsViewModel(IGitHubOAuthAuthorizer authorizer)
        {
            this.authorizer = authorizer;
        }

        private bool trackIssues;
        public bool TrackIssues
        {
            get { return trackIssues; }
            set
            {
                trackIssues = value;
                RaisePropertyChanged(() => TrackIssues);
            }
        }

        private bool trackPullRequests;
        public bool TrackPullRequests
        {
            get { return trackPullRequests; }
            set
            {
                trackPullRequests = value;
                RaisePropertyChanged(() => TrackPullRequests);
            }
        }

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public ICommand SignInCommand { get { return new DelegateCommand(SignIn); } }

        public void SignIn()
        {
            authorizer.GetAccessTokenAsync("clientId", "clientSecret", "", OnCompleted, OnError);
             
            // TODO: actually implement this logic
            // TODO: settings provider
            User = new User
                       {
                           Name = "shiftkey",
                           Icon = "https://secure.gravatar.com/avatar/bcd3cc17a673e125b5c8bd7000829326?s=140"
                       };
        }

        private void OnError(GitHubException obj)
        {
            
        }

        private void OnCompleted(string obj)
        {
            
        }

        public ICommand ClearCommand { get { return new DelegateCommand(Clear); } }

        public void Clear()
        {
            User = null;
        }
    }
}