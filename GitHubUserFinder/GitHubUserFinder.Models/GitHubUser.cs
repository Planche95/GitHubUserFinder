using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubUserFinder.Models
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string AvatarUrl { get; set; }
        public string Location { get; set; }
        public IEnumerable<GitHubRepository> Repositories { get; set; }
    }
}
