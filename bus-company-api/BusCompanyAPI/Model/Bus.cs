using Amazon.DynamoDBv2.DataModel;

namespace BusCompanyAPI.Model
{
    [DynamoDBTable("Buses")]
    public class Bus
    { 

        [DynamoDBProperty("LicensePlate")]
        public string LicensePlate { get; set; }

        [DynamoDBProperty("MaxPassengers")]
        public int? MaxPassengers { get; set; }

        [DynamoDBProperty("Colour")]
        public string? Colour { get; set; }                

        [DynamoDBProperty(typeof(BusDayDetailConverter))]
        public List<BusDayDetail>? DayHistory { get; set; }
    }
}
