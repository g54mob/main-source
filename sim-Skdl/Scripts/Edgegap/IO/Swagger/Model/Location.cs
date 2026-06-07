using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Location
	{
		[DataMember(Name = "city", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[DataMember(Name = "continent", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "continent")]
		public string Continent { get; set; }

		[DataMember(Name = "country", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		[DataMember(Name = "timezone", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "timezone")]
		public string Timezone { get; set; }

		[DataMember(Name = "administrative_division", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "administrative_division")]
		public string AdministrativeDivision { get; set; }

		[DataMember(Name = "latitude", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "latitude")]
		public decimal? Latitude { get; set; }

		[JsonProperty(PropertyName = "longitude")]
		[DataMember(Name = "longitude", EmitDefaultValue = false)]
		public decimal? Longitude { get; set; }

		[DataMember(Name = "type", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

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
