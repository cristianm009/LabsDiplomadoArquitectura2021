using System;
using System.Threading.Tasks;

namespace MediatorApi.Services.Mediators
{
    public interface IRelocationRequestMediatorService
    {
        Task Run(Guid clientId, string address, string city, string name, string id);
    }
}
