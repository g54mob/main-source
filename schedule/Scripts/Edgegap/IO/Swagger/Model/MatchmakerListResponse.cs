using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerListResponse
	{
		[JsonProperty(PropertyName = "count")]
		[DataMember(Name = "count", EmitDefaultValue = false)]
		public int? Count { get; set; }

		[DataMember(Name = "data", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "data")]
		public MatchmakerResponse Data { get; set; }

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
