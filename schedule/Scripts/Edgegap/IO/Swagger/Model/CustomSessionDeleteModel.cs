using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class CustomSessionDeleteModel
	{
		[DataMember(Name = "sessions", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sessions")]
		public List<string> Sessions { get; set; }

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
