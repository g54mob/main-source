using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class StaticSites
	{
		[JsonProperty(PropertyName = "url")]
		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string Url { get; set; }

		[DataMember(Name = "public_ip", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "public_ip")]
		public string PublicIp { get; set; }

		[DataMember(Name = "port", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "port")]
		public decimal? Port { get; set; }

		[DataMember(Name = "latitude", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "latitude")]
		public decimal? Latitude { get; set; }

		[JsonProperty(PropertyName = "longitude")]
		[DataMember(Name = "longitude", EmitDefaultValue = false)]
		public decimal? Longitude { get; set; }

		[JsonProperty(PropertyName = "city")]
		[DataMember(Name = "city", EmitDefaultValue = false)]
		public string City { get; set; }

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
