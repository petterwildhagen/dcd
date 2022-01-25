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
    public class FacilityController : ControllerBase
    {
        private readonly FacilityService _facilityService;
        private readonly ILogger<ProjectController> _logger;

        public FacilityController(ILogger<ProjectController> logger, FacilityService facilityService)
        {
            _logger = logger;
            _facilityService = facilityService;
        }

        [HttpGet("project/surf/{surfId}", Name = "GetSurf")]
        public Surf GetSurf(Guid surfId)
        {
            return _facilityService.GetSurf(surfId);
        }

        [HttpGet("surf/{projectId}", Name = "GetSurfsForProject")]
        public IEnumerable<Surf>? GetSurfsForProject(Guid projectId)
        {
            return _facilityService.GetSurfsForProject(projectId);
        }

        [HttpGet("project/substructure/{substructureId}", Name = "GetSubstructure")]
        public Substructure GetSubstructure(Guid substructureId)
        {
            return _facilityService.GetSubstructure(substructureId);
        }

        [HttpGet("substructure/{projectId}", Name = "GetSubstructuresForProject")]
        public IEnumerable<Substructure>? GetSubstructuresForProject(Guid projectId)
        {
            return _facilityService.GetSubstructuresForProject(projectId);
        }

        [HttpGet("project/topside/{topsideId}", Name = "GetTopside")]
        public Topside GetTopside(Guid topsideId)
        {
            return _facilityService.GetTopside(topsideId);
        }

        [HttpGet("topside/{projectId}", Name = "GetTopsidesForProject")]
        public IEnumerable<Topside>? GetTopsidesForProject(Guid projectId)
        {
            return _facilityService.GetTopsidesForProject(projectId);
        }

        [HttpGet("project/transport/{transportId}", Name = "GetTransport")]
        public Transport GetTransport(Guid transportId)
        {
            return _facilityService.GetTransport(transportId);
        }

        [HttpGet("transport/{projectId}", Name = "GetTransportsForProject")]
        public IEnumerable<Transport>? GetTransportsForProject(Guid projectId)
        {
            return _facilityService.GetTransportsForProject(projectId);
        }
    }
}
