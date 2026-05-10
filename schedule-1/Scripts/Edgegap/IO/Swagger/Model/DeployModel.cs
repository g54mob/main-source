using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class DeployModel
	{
		[JsonProperty(PropertyName = "app_name")]
		[DataMember(Name = "app_name", EmitDefaultValue = false)]
		public string AppName { get; set; }

		[DataMember(Name = "version_name", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "version_name")]
		public string VersionName { get; set; }

		[DataMember(Name = "is_public_app", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "is_public_app")]
		public bool? IsPublicApp { get; set; }

		[DataMember(Name = "ip_list", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ip_list")]
		public List<string> IpList { get; set; }

		[DataMember(Name = "geo_ip_list", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "geo_ip_list")]
		public List<GeoIpListModel> GeoIpList { get; set; }

		[JsonProperty(PropertyName = "env_vars")]
		[DataMember(Name = "env_vars", EmitDefaultValue = false)]
		public List<DeployEnvModel> EnvVars { get; set; }

		[JsonProperty(PropertyName = "skip_telemetry")]
		[DataMember(Name = "skip_telemetry", EmitDefaultValue = false)]
		public bool? SkipTelemetry { get; set; }

		[JsonProperty(PropertyName = "location")]
		[DataMember(Name = "location", EmitDefaultValue = false)]
		public LocationModel Location { get; set; }

		[JsonProperty(PropertyName = "city")]
		[DataMember(Name = "city", EmitDefaultValue = false)]
		public string City { get; set; }

		[JsonProperty(PropertyName = "country")]
		[DataMember(Name = "country", EmitDefaultValue = false)]
		public string Country { get; set; }

		[DataMember(Name = "continent", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "continent")]
		public string Continent { get; set; }

		[JsonProperty(PropertyName = "region")]
		[DataMember(Name = "region", EmitDefaultValue = false)]
		public string Region { get; set; }

		[JsonProperty(PropertyName = "administrative_division")]
		[DataMember(Name = "administrative_division", EmitDefaultValue = false)]
		public string AdministrativeDivision { get; set; }

		[DataMember(Name = "webhook_url", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "webhook_url")]
		public string WebhookUrl { get; set; }

		[DataMember(Name = "tags", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "tags")]
		public List<string> Tags { get; set; }

		[DataMember(Name = "container_log_storage", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "container_log_storage")]
		public ContainerLogStorageModel ContainerLogStorage { get; set; }

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
