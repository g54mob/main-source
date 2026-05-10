using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model
{
	[DataContract]
	public class AppVersion
	{
		[JsonProperty(PropertyName = "name")]
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "is_active")]
		[DataMember(Name = "is_active", EmitDefaultValue = false)]
		public bool? IsActive { get; set; }

		[JsonProperty(PropertyName = "docker_repository")]
		[DataMember(Name = "docker_repository", EmitDefaultValue = false)]
		public string DockerRepository { get; set; }

		[JsonProperty(PropertyName = "docker_image")]
		[DataMember(Name = "docker_image", EmitDefaultValue = false)]
		public string DockerImage { get; set; }

		[DataMember(Name = "docker_tag", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "docker_tag")]
		public string DockerTag { get; set; }

		[JsonProperty(PropertyName = "private_username")]
		[DataMember(Name = "private_username", EmitDefaultValue = false)]
		public string PrivateUsername { get; set; }

		[DataMember(Name = "private_token", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "private_token")]
		public string PrivateToken { get; set; }

		[DataMember(Name = "req_cpu", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "req_cpu")]
		public int? ReqCpu { get; set; }

		[JsonProperty(PropertyName = "req_memory")]
		[DataMember(Name = "req_memory", EmitDefaultValue = false)]
		public int? ReqMemory { get; set; }

		[DataMember(Name = "req_video", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "req_video")]
		public int? ReqVideo { get; set; }

		[JsonProperty(PropertyName = "max_duration")]
		[DataMember(Name = "max_duration", EmitDefaultValue = false)]
		public int? MaxDuration { get; set; }

		[DataMember(Name = "use_telemetry", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "use_telemetry")]
		public bool? UseTelemetry { get; set; }

		[DataMember(Name = "inject_context_env", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "inject_context_env")]
		public bool? InjectContextEnv { get; set; }

		[DataMember(Name = "whitelisting_active", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "whitelisting_active")]
		public bool? WhitelistingActive { get; set; }

		[DataMember(Name = "force_cache", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "force_cache")]
		public bool? ForceCache { get; set; }

		[JsonProperty(PropertyName = "cache_min_hour")]
		[DataMember(Name = "cache_min_hour", EmitDefaultValue = false)]
		public int? CacheMinHour { get; set; }

		[DataMember(Name = "cache_max_hour", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "cache_max_hour")]
		public int? CacheMaxHour { get; set; }

		[DataMember(Name = "time_to_deploy", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "time_to_deploy")]
		public int? TimeToDeploy { get; set; }

		[JsonProperty(PropertyName = "enable_all_locations")]
		[DataMember(Name = "enable_all_locations", EmitDefaultValue = false)]
		public bool? EnableAllLocations { get; set; }

		[JsonProperty(PropertyName = "session_config")]
		[DataMember(Name = "session_config", EmitDefaultValue = false)]
		public AppVersionCreateSessionConfig SessionConfig { get; set; }

		[DataMember(Name = "ports", EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "ports")]
		public List<AppVersionPort> Ports { get; set; }

		[JsonProperty(PropertyName = "probe")]
		[DataMember(Name = "probe", EmitDefaultValue = false)]
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
