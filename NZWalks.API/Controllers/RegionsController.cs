using Microsoft.AspNetCore.Mvc;
using NZWalks.API.BaseHelp;
using NZWalks.Repository.Models;
using NZWalks.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceModels.RegionModel>> GetAllRegions()
        {
            return JsonMap.Deserialize<IEnumerable<ServiceModels.RegionModel>>(await _regionRepository.GetAllRegionsAsync());
        }
    }
}
