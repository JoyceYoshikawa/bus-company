using BusCompanyAPI.Domain;

namespace BusCompanyAPI.Services.Interfaces
{
    public interface IBusService
    {
        Task<Result<string>> GetAll();        
    }
}
