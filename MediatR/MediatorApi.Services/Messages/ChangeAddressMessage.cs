using MediatR;
using System;

namespace MediatorApi.Services.Messages
{
    public class ChangeAddressMessage: INotification
    {
        public Guid ClientId { get; set; }
        public string NewAddress { get; set; }
    }
}
