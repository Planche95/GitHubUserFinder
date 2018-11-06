using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubUserFinder.Models.Api
{
    class GitHubUser
    {
        public string login;
        public string avatar_url;
        public string location;
        //IEnumerable<Repository> ... ???
        public string repos_url;
    }
}
