using MediatorApi.Services.Messages;
using MediatR;
using System;
using System.Threading.Tasks;

namespace MediatorApi.Services.Mediators
{
    public class RelocationRequestMediatorService : IRelocationRequestMediatorService
    {
        private readonly IMediator _mediator;

        public RelocationRequestMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Run(Guid clientId, string address, string city, string name, string id)
        {
            //publish event of changing address
            await _mediator.Publish(new ChangeAddressMessage
            {
                ClientId = clientId,
                Address = address,
                City= city,
                Name= name,
                Id=id
            });
        }
    }
}
