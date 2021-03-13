using MediatorApi.Services.Messages;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorApi.Services.Handlers
{
    public class ChangeAddressHandler : INotificationHandler<ChangeAddressMessage>
    {
        public Task Handle(ChangeAddressMessage notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Changing the address to : {notification.NewAddress} ");
            return Task.CompletedTask;
        }
    }
}
