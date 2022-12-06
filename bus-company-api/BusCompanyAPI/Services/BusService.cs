using BusCompanyAPI.Domain;
using BusCompanyAPI.Repository.Interfaces;
using BusCompanyAPI.Services.Interfaces;

namespace BusCompanyAPI.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _repository;
        public BusService(IBusRepository busRepository)
        { 
            _repository = busRepository;
        }
        public Task<Result<string>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
