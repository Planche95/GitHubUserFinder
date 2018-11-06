using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubUserFinder.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GitHubUserFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> getUserAsync(string id)
        {
            return new JsonResult(await _gitHubService.getUserInfoAsync("Planche95"));
        }
    }
}
