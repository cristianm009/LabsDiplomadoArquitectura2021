using System;
using System.Threading.Tasks;

namespace MediatorApi.Services.Mediators
{
    public interface ILocationRequestMediatorService
    {
        Task Run(Guid clientId, string address, string city, string name);
    }
}
