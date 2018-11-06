using GitHubUserFinder.Services.Abstract;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //Octokit doesnt seems to return forked repositories ...
        public async Task<List<Repository>> getUserMostStarredRepositoriesAsync(string login, int limit)
        {
            var request = new SearchRepositoriesRequest()
            {
                Fork = ForkQualifier.IncludeForks,
                User = login
            };

            SearchRepositoryResult searchResult = await _client.Search.SearchRepo(request);

            return searchResult.Items.OrderByDescending(r => r.StargazersCount).Take(limit).ToList();
        }
    }
}
