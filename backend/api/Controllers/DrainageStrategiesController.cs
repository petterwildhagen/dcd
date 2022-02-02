using api.Adapters;
using api.Dtos;
using api.Models;
using api.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class DrainageStrategiesController : ControllerBase
    {
        private DrainageStrategyService _drainageStrategyService;
        private readonly ILogger<DrainageStrategiesController> _logger;
        private readonly DrainageStrategyAdapter _drainageStrategyAdapter;

        public DrainageStrategiesController(ILogger<DrainageStrategiesController> logger, DrainageStrategyService drainageStrategyService)
        {
            _logger = logger;
            _drainageStrategyService = drainageStrategyService;
            _drainageStrategyAdapter = new DrainageStrategyAdapter();
        }

        [HttpPost(Name = "CreateDrainageStrategy")]
        public DrainageStrategy CreateDrainageStrategy([FromBody] DrainageStrategyDto drainageStrategyDto)
        {
            var drainageStrategy = _drainageStrategyAdapter.Convert(drainageStrategyDto);
            return _drainageStrategyService.CreateDrainageStrategy(drainageStrategy);
        }
    }
}