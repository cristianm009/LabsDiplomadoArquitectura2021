using System;

namespace MediatorAPI.Controllers
{
    public class Address
    {
        public string Id { get; set; }
        public Guid ClientId { get; set; }
        public string NewAddress { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}