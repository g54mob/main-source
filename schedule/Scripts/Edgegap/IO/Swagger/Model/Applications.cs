using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Applications
	{
		[DataMember(Name = "applications", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "applications")]
		public List<Application> _Applications { get; set; }

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
