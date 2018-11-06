using AutoMapper;
using GitHubUserFinder.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubUserFinder.Api.Profiles
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Repository, GitHubRepository>();
            CreateMap<User, GitHubUser>();
            //CreateMap<List<Repository>, GitHubUser>().ForMember(dest => dest.Repositories, source => source.MapFrom(nested => nested));
        }
    }
}
