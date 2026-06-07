using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class SessionRequest
	{
		[DataMember(Name = "session_id", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "session_id")]
		public string SessionId { get; set; }

		[DataMember(Name = "custom_id", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "custom_id")]
		public string CustomId { get; set; }

		[JsonProperty(PropertyName = "app")]
		[DataMember(Name = "app", EmitDefaultValue = false)]
		public string App { get; set; }

		[DataMember(Name = "version", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "version")]
		public string Version { get; set; }

		[DataMember(Name = "deployment_request_id", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "deployment_request_id")]
		public string DeploymentRequestId { get; set; }

		[JsonProperty(PropertyName = "selectors")]
		[DataMember(Name = "selectors", EmitDefaultValue = false)]
		public List<SelectorModel> Selectors { get; set; }

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
