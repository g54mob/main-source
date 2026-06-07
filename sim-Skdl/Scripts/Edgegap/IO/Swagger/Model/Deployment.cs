using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Deployment
	{
		[JsonProperty(PropertyName = "request_id")]
		[DataMember(Name = "request_id", EmitDefaultValue = false)]
		public string RequestId { get; set; }

		[JsonProperty(PropertyName = "public_ip")]
		[DataMember(Name = "public_ip", EmitDefaultValue = false)]
		public string PublicIp { get; set; }

		[JsonProperty(PropertyName = "status")]
		[DataMember(Name = "status", EmitDefaultValue = false)]
		public string Status { get; set; }

		[JsonProperty(PropertyName = "ready")]
		[DataMember(Name = "ready", EmitDefaultValue = false)]
		public bool? Ready { get; set; }

		[DataMember(Name = "whitelisting_active", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "whitelisting_active")]
		public bool? WhitelistingActive { get; set; }

		[JsonProperty(PropertyName = "fqdn")]
		[DataMember(Name = "fqdn", EmitDefaultValue = false)]
		public string Fqdn { get; set; }

		[DataMember(Name = "ports", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ports")]
		public Dictionary<string, PortMapping> Ports { get; set; }

		[DataMember(Name = "location", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "location")]
		public DeploymentLocation Location { get; set; }

		[DataMember(Name = "tags", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tags")]
		public List<string> Tags { get; set; }

		[DataMember(Name = "sockets", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sockets")]
		public int? Sockets { get; set; }

		[JsonProperty(PropertyName = "sockets_usage")]
		[DataMember(Name = "sockets_usage", EmitDefaultValue = false)]
		public int? SocketsUsage { get; set; }

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
