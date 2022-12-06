using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System.Text;
using System.Text.Json;

namespace BusCompanyAPI.Model
{
    [Serializable]
    public class BusDayDetail
    {
        public DateTime Date { get; set; }
        public int TotalPassangers { get; set; }
        public double KilometerDriven { get; set; }

        
    }

    public class BusDayDetailConverter : IPropertyConverter
    {
        public object FromEntry(DynamoDBEntry entry)
        {
            var primitive = entry as Primitive;
            if (primitive == null || !(primitive.Value is String) || string.IsNullOrEmpty((string)primitive.Value))
                throw new ArgumentOutOfRangeException();

            try
            {
                object ret = JsonSerializer.Deserialize<List<BusDayDetail>>(primitive.Value as string);
                return ret;
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public DynamoDBEntry ToEntry(object value)
        {
            var jsonString = JsonSerializer.Serialize(value);
            DynamoDBEntry ret = new Primitive(jsonString);
            return ret;

        }
    }

}
