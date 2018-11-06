using GitHubUserFinder.Services.Abstract;
using Octokit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserFinder.Services.Implementation
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;

        public GitHubService()
        {
            _client = new GitHubClient(new ProductHeaderValue("GitHubUserFinderApp"));
        }

        public async Task<User> getUserInfoAsync(string login)
        {
            return await _client.User.Get(login);
        }
    }
}
