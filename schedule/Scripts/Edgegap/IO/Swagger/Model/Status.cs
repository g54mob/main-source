using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class Status
	{
		[JsonProperty(PropertyName = "request_id")]
		[DataMember(Name = "request_id", EmitDefaultValue = false)]
		public string RequestId { get; set; }

		[DataMember(Name = "fqdn", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "fqdn")]
		public string Fqdn { get; set; }

		[DataMember(Name = "app_name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "app_name")]
		public string AppName { get; set; }

		[JsonProperty(PropertyName = "app_version")]
		[DataMember(Name = "app_version", EmitDefaultValue = false)]
		public string AppVersion { get; set; }

		[JsonProperty(PropertyName = "current_status")]
		[DataMember(Name = "current_status", EmitDefaultValue = false)]
		public string CurrentStatus { get; set; }

		[DataMember(Name = "running", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "running")]
		public bool? Running { get; set; }

		[DataMember(Name = "whitelisting_active", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "whitelisting_active")]
		public bool? WhitelistingActive { get; set; }

		[DataMember(Name = "start_time", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "start_time")]
		public string StartTime { get; set; }

		[DataMember(Name = "removal_time", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "removal_time")]
		public string RemovalTime { get; set; }

		[DataMember(Name = "elapsed_time", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "elapsed_time")]
		public int? ElapsedTime { get; set; }

		[DataMember(Name = "last_status", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "last_status")]
		public string LastStatus { get; set; }

		[DataMember(Name = "error", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "error")]
		public bool? Error { get; set; }

		[DataMember(Name = "error_detail", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "error_detail")]
		public string ErrorDetail { get; set; }

		[DataMember(Name = "ports", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ports")]
		public Dictionary<string, PortMapping> Ports { get; set; }

		[JsonProperty(PropertyName = "public_ip")]
		[DataMember(Name = "public_ip", EmitDefaultValue = false)]
		public string PublicIp { get; set; }

		[DataMember(Name = "sessions", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sessions")]
		public List<DeploymentSessionContext> Sessions { get; set; }

		[DataMember(Name = "location", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "location")]
		public DeploymentLocation Location { get; set; }

		[JsonProperty(PropertyName = "tags")]
		[DataMember(Name = "tags", EmitDefaultValue = false)]
		public List<string> Tags { get; set; }

		[DataMember(Name = "sockets", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sockets")]
		public int? Sockets { get; set; }

		[DataMember(Name = "sockets_usage", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "sockets_usage")]
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
