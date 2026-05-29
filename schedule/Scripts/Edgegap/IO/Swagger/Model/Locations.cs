using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Locations
	{
		[JsonProperty(PropertyName = "locations")]
		[DataMember(Name = "locations", EmitDefaultValue = false)]
		public List<Location> _Locations { get; set; }

		[JsonProperty(PropertyName = "messages")]
		[DataMember(Name = "messages", EmitDefaultValue = false)]
		public List<string> Messages { get; set; }

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
