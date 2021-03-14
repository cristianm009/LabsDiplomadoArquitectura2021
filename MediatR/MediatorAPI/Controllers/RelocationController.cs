using AutoMapper;
using MediatorApi.Services.Mediators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MediatorAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class RelocationController : ControllerBase
    {
        private readonly IMapper _iMapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RelocationController> _logger;

        private readonly ILocationRequestMediatorService _locationMediatorService;
        private readonly IRelocationRequestMediatorService _relocationMediatorService;
        const string firebaseUrl = "-rtdb.firebaseio.com";

        public RelocationController(ILogger<RelocationController> logger,
                                    IMapper mapper,
                                    IConfiguration configuration,
                                    ILocationRequestMediatorService locationMediatorService,
                                    IRelocationRequestMediatorService relocationMediatorService)
        {
            _logger = logger;
            _iMapper = mapper;
            _configuration = configuration;
            _locationMediatorService = locationMediatorService;
            _relocationMediatorService = relocationMediatorService;
        }


        [Route("relocations")]
        [HttpPost]
        public async Task<ActionResult> Put([FromBody] Address adreess)
        {
            try
            {
                await _locationMediatorService.Run(Guid.NewGuid(), adreess.NewAddress, adreess.City, adreess.Name);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("relocations")]
        [HttpPut]
        public async Task<ActionResult> Post([FromBody] Address address)
        {
            try
            {
                await _relocationMediatorService.Run(address.ClientId, address.NewAddress, address.City, address.Name, address.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("relocations")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var url = $"https://{_configuration["fbproject"]}{firebaseUrl}";
                return GetDataFromFirebase($"{url}/addresses.json?print=pretty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("relocations/{addressId}")]
        [HttpGet]
        public async Task<ActionResult> Get(string addressId)
        {
            try
            {
                var url = $"https://{_configuration["fbproject"]}{firebaseUrl}";
                return GetDataFromFirebase($"{firebaseUrl}/addresses/{addressId}.json?print=pretty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private ActionResult GetDataFromFirebase(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            if (response.IsSuccessStatusCode)
                return Ok(response.Content.ReadAsStringAsync().Result);
            else
                return BadRequest(response);
        }
    }
}
