using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerComponentEnvListResponse
	{
		[JsonProperty(PropertyName = "count")]
		[DataMember(Name = "count", EmitDefaultValue = false)]
		public int? Count { get; set; }

		[JsonProperty(PropertyName = "data")]
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public MatchmakerComponentEnvsResponse Data { get; set; }

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
