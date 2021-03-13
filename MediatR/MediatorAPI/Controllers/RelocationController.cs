using AutoMapper;
using MediatorApi.Services.Mediators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelocationController : ControllerBase
    {
        private readonly IMapper _iMapper;
        private readonly ILogger<RelocationController> _logger; 
        private readonly IRelocationRequestMediatorService _mediatorService;

        public RelocationController(ILogger<RelocationController> logger,
                                    IMapper mapper,
                                    IRelocationRequestMediatorService mediator)
        {
            _logger = logger;
            _iMapper = mapper;
            _mediatorService = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            try
            {
                await _mediatorService.Run(Guid.NewGuid(), "Wall Stret");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
