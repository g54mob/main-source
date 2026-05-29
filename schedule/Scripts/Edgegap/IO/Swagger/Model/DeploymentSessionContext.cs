using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class DeploymentSessionContext
	{
		[JsonProperty(PropertyName = "session_id")]
		[DataMember(Name = "session_id", EmitDefaultValue = false)]
		public string SessionId { get; set; }

		[JsonProperty(PropertyName = "status")]
		[DataMember(Name = "status", EmitDefaultValue = false)]
		public string Status { get; set; }

		[DataMember(Name = "ready", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ready")]
		public bool? Ready { get; set; }

		[DataMember(Name = "linked", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "linked")]
		public bool? Linked { get; set; }

		[DataMember(Name = "kind", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "kind")]
		public string Kind { get; set; }

		[DataMember(Name = "user_count", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "user_count")]
		public int? UserCount { get; set; }

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
