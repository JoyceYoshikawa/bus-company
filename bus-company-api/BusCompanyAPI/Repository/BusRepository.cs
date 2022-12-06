using BusCompanyAPI.Repository.Interfaces;
using Amazon.DynamoDBv2.DataModel;

namespace BusCompanyAPI.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly IDynamoDBContext dbContext;
        public BusRepository(IDynamoDBContext context) {
            dbContext = context;
        }
    }
}
