using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class BulkSessionDelete
	{
		[DataMember(Name = "sessions", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sessions")]
		public List<SessionDelete> Sessions { get; set; }

		[DataMember(Name = "errors", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "errors")]
		public List<string> Errors { get; set; }

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
