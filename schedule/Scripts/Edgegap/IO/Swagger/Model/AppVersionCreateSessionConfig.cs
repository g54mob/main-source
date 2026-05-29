using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionCreateSessionConfig
	{
		[JsonProperty(PropertyName = "kind")]
		[DataMember(Name = "kind", EmitDefaultValue = false)]
		public string Kind { get; set; }

		[DataMember(Name = "sockets", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sockets")]
		public int? Sockets { get; set; }

		[DataMember(Name = "autodeploy", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "autodeploy")]
		public bool? Autodeploy { get; set; }

		[DataMember(Name = "empty_ttl", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "empty_ttl")]
		public int? EmptyTtl { get; set; }

		[JsonProperty(PropertyName = "session_max_duration")]
		[DataMember(Name = "session_max_duration", EmitDefaultValue = false)]
		public int? SessionMaxDuration { get; set; }

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
