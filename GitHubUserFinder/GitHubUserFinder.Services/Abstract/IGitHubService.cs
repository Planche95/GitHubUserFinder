using Octokit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserFinder.Services.Abstract
{
    public interface IGitHubService
    {
        Task<User> getUserInfoAsync(string login);
        Task<List<Repository>> getUserMostStarredRepositoriesAsync(string login, int limit);
    }
}
