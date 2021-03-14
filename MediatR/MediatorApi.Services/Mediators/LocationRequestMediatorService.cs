using MediatorApi.Services.Messages;
using MediatR;
using System;
using System.Threading.Tasks;

namespace MediatorApi.Services.Mediators
{
    public class LocationRequestMediatorService : ILocationRequestMediatorService
    {
        private readonly IMediator _mediator;

        public LocationRequestMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Run(Guid clientId, string address, string city, string name)
        {
            //publish event of changing address
            await _mediator.Publish(new AddAddressMessage
            {
                ClientId = clientId,
                Address = address,
                City= city,
                Name= name
            });
        }
    }
}
