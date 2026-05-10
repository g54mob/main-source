using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class GeoIpListModel
	{
		[DataMember(Name = "ip", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ip")]
		public string Ip { get; set; }

		[JsonProperty(PropertyName = "latitude")]
		[DataMember(Name = "latitude", EmitDefaultValue = false)]
		public decimal? Latitude { get; set; }

		[JsonProperty(PropertyName = "longitude")]
		[DataMember(Name = "longitude", EmitDefaultValue = false)]
		public decimal? Longitude { get; set; }

		public override string ToString()
		{
			return null;
		}

		public string ToJson()
		{
			return null;
		}
	}
}
