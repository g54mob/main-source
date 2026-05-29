using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class DeploymentLocation
	{
		[JsonProperty(PropertyName = "city")]
		[DataMember(Name = "city", EmitDefaultValue = false)]
		public string City { get; set; }

		[DataMember(Name = "country", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		[DataMember(Name = "continent", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "continent")]
		public string Continent { get; set; }

		[DataMember(Name = "administrative_division", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "administrative_division")]
		public string AdministrativeDivision { get; set; }

		[JsonProperty(PropertyName = "timezone")]
		[DataMember(Name = "timezone", EmitDefaultValue = false)]
		public string Timezone { get; set; }

		[JsonProperty(PropertyName = "latitude")]
		[DataMember(Name = "latitude", EmitDefaultValue = false)]
		public decimal? Latitude { get; set; }

		[DataMember(Name = "longitude", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "longitude")]
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
