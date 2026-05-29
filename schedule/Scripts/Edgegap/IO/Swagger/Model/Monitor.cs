using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Monitor
	{
		[JsonProperty(PropertyName = "name")]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; set; }

		[DataMember(Name = "version", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "version")]
		public string Version { get; set; }

		[DataMember(Name = "host", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "host")]
		public string Host { get; set; }

		[DataMember(Name = "host_url", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "host_url")]
		public string HostUrl { get; set; }

		[DataMember(Name = "spec_url", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "spec_url")]
		public string SpecUrl { get; set; }

		[DataMember(Name = "messages", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "messages")]
		public List<string> Messages { get; set; }

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
