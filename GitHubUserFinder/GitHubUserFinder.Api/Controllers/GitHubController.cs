using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitHubUserFinder.Models;
using GitHubUserFinder.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace GitHubUserFinder.Api.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMapper _mapper;

        public GitHubController(IGitHubService gitHubService, IMapper mapper)
        {
            _gitHubService = gitHubService;
            _mapper = mapper;
        }

        [HttpGet("{login}")]
        public async Task<JsonResult> UserInfo(string login)
        {
            User fullUserInfo = await _gitHubService.getUserInfoAsync(login);
            List<Repository> userRepositories = await _gitHubService.getUserMostStarredRepositoriesAsync(login, 5);

            //Q: Lepiej zostawić to w takiej formie, czy wykorzystać też mappera jak niżej do przypisania Listy Repozytoriów?
            //GitHubUser reducedUserInfo = _mapper.Map(userRepositories, _mapper.Map<GitHubUser>(fullUserInfo));
            GitHubUser reducedUserInfo =_mapper.Map<GitHubUser>(fullUserInfo);
            reducedUserInfo.Repositories =_mapper.Map<List<Repository>, List<GitHubRepository>>(userRepositories);

            return new JsonResult(reducedUserInfo);
        }
    }
}
