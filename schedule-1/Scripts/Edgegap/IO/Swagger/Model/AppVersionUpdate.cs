using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersionUpdate
	{
		[JsonProperty(PropertyName = "name")]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "is_active")]
		[DataMember(Name = "is_active", EmitDefaultValue = false)]
		public bool? IsActive { get; set; }

		[DataMember(Name = "docker_repository", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "docker_repository")]
		public string DockerRepository { get; set; }

		[DataMember(Name = "docker_image", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "docker_image")]
		public string DockerImage { get; set; }

		[JsonProperty(PropertyName = "docker_tag")]
		[DataMember(Name = "docker_tag", EmitDefaultValue = false)]
		public string DockerTag { get; set; }

		[DataMember(Name = "private_username", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "private_username")]
		public string PrivateUsername { get; set; }

		[DataMember(Name = "private_token", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "private_token")]
		public string PrivateToken { get; set; }

		[DataMember(Name = "req_cpu", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "req_cpu")]
		public int? ReqCpu { get; set; }

		[DataMember(Name = "req_memory", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "req_memory")]
		public int? ReqMemory { get; set; }

		[JsonProperty(PropertyName = "req_video")]
		[DataMember(Name = "req_video", EmitDefaultValue = false)]
		public int? ReqVideo { get; set; }

		[JsonProperty(PropertyName = "max_duration")]
		[DataMember(Name = "max_duration", EmitDefaultValue = false)]
		public int? MaxDuration { get; set; }

		[JsonProperty(PropertyName = "use_telemetry")]
		[DataMember(Name = "use_telemetry", EmitDefaultValue = false)]
		public bool? UseTelemetry { get; set; }

		[DataMember(Name = "inject_context_env", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "inject_context_env")]
		public bool? InjectContextEnv { get; set; }

		[DataMember(Name = "whitelisting_active", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "whitelisting_active")]
		public bool? WhitelistingActive { get; set; }

		[JsonProperty(PropertyName = "force_cache")]
		[DataMember(Name = "force_cache", EmitDefaultValue = false)]
		public bool? ForceCache { get; set; }

		[JsonProperty(PropertyName = "cache_min_hour")]
		[DataMember(Name = "cache_min_hour", EmitDefaultValue = false)]
		public int? CacheMinHour { get; set; }

		[JsonProperty(PropertyName = "cache_max_hour")]
		[DataMember(Name = "cache_max_hour", EmitDefaultValue = false)]
		public int? CacheMaxHour { get; set; }

		[JsonProperty(PropertyName = "time_to_deploy")]
		[DataMember(Name = "time_to_deploy", EmitDefaultValue = false)]
		public int? TimeToDeploy { get; set; }

		[DataMember(Name = "enable_all_locations", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "enable_all_locations")]
		public bool? EnableAllLocations { get; set; }

		[DataMember(Name = "session_config", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "session_config")]
		public AppVersionUpdateSessionConfig SessionConfig { get; set; }

		[DataMember(Name = "ports", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ports")]
		public List<AppVersionPort> Ports { get; set; }

		[DataMember(Name = "probe", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "probe")]
		public AppVersionProbe Probe { get; set; }

		[JsonProperty(PropertyName = "envs")]
		[DataMember(Name = "envs", EmitDefaultValue = false)]
		public List<AppVersionEnv> Envs { get; set; }

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
