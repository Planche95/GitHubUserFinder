using Octokit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserFinder.Services.Abstract
{
    public interface IGitHubService
    {
        //IEnumerable<Repository> getMostStarredRepositories(int count);
        Task<User> getUserInfoAsync(string login);
    }
}
