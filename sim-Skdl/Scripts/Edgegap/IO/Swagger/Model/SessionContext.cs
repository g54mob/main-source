using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class SessionContext
	{
		[JsonProperty(PropertyName = "session_id")]
		[DataMember(Name = "session_id", EmitDefaultValue = false)]
		public string SessionId { get; set; }

		[JsonProperty(PropertyName = "custom_id")]
		[DataMember(Name = "custom_id", EmitDefaultValue = false)]
		public string CustomId { get; set; }

		[JsonProperty(PropertyName = "status")]
		[DataMember(Name = "status", EmitDefaultValue = false)]
		public string Status { get; set; }

		[JsonProperty(PropertyName = "ready")]
		[DataMember(Name = "ready", EmitDefaultValue = false)]
		public bool? Ready { get; set; }

		[JsonProperty(PropertyName = "linked")]
		[DataMember(Name = "linked", EmitDefaultValue = false)]
		public bool? Linked { get; set; }

		[DataMember(Name = "kind", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "kind")]
		public string Kind { get; set; }

		[JsonProperty(PropertyName = "user_count")]
		[DataMember(Name = "user_count", EmitDefaultValue = false)]
		public int? UserCount { get; set; }

		[DataMember(Name = "deployment_request_id", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "deployment_request_id")]
		public string DeploymentRequestId { get; set; }

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
