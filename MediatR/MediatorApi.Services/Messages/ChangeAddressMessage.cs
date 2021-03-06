using MediatR;
using System;

namespace MediatorApi.Services.Messages
{
    public class ChangeAddressMessage: INotification
    {
        public string Id { get; set; }
        public Guid ClientId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
