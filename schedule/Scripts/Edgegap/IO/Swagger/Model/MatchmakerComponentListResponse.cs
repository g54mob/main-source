using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class MatchmakerComponentListResponse
	{
		[DataMember(Name = "count", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "count")]
		public int? Count { get; set; }

		[DataMember(Name = "data", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "data")]
		public MatchmakerComponentResponse Data { get; set; }

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
