using Newtonsoft.Json;

namespace Edgegap.Editor.Api.Models.Requests
{
	public class UpdateAppVersionRequest
	{
		public class SessionConfigData
		{
			[JsonProperty("kind")]
			public string Kind { get; set; }

			[JsonProperty("sockets")]
			public int Sockets { get; set; }

			[JsonProperty("autodeploy")]
			public bool Autodeploy { get; set; }

			[JsonProperty("empty_ttl")]
			public int EmptyTtl { get; set; }

			[JsonProperty("session_max_duration")]
			public int SessionMaxDuration { get; set; }
		}

		public class ProbeData
		{
			[JsonProperty("optimal_ping")]
			public int OptimalPing { get; set; }

			[JsonProperty("rejected_ping")]
			public int RejectedPing { get; set; }
		}

		public class EnvsData
		{
			[JsonProperty("key")]
			public string Key { get; set; }

			[JsonProperty("value")]
			public string Value { get; set; }

			[JsonProperty("is_secret")]
			public bool IsSecret { get; set; }
		}

		[JsonIgnore]
		public string AppName { get; set; }

		[JsonIgnore]
		public string VersionName { get; set; }

		[JsonProperty("ports")]
		public AppPortsData[] Ports { get; set; }

		[JsonProperty("docker_repository")]
		public string DockerRepository { get; set; }

		[JsonProperty("docker_image")]
		public string DockerImage { get; set; }

		[JsonProperty("docker_tag")]
		public string DockerTag { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }

		[JsonProperty("private_username")]
		public string PrivateUsername { get; set; }

		[JsonProperty("private_token")]
		public string PrivateToken { get; set; }

		[JsonProperty("max_duration")]
		public int MaxDuration { get; set; }

		[JsonProperty("use_telemetry")]
		public bool UseTelemetry { get; set; }

		[JsonProperty("inject_context_env")]
		public bool InjectContextEnv { get; set; }

		[JsonProperty("whitelisting_active")]
		public bool WhitelistingActive { get; set; }

		[JsonProperty("force_cache")]
		public bool ForceCache { get; set; }

		[JsonProperty("cache_min_hour")]
		public int CacheMinHour { get; set; }

		[JsonProperty("cache_max_hour")]
		public int CacheMaxHour { get; set; }

		[JsonProperty("time_to_deploy")]
		public int TimeToDeploy { get; set; }

		[JsonProperty("enable_all_locations")]
		public bool EnableAllLocations { get; set; }

		[JsonProperty("termination_grace_period_seconds")]
		public int TerminationGracePeriodSeconds { get; set; }

		[JsonProperty("command")]
		public string Command { get; set; }

		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("probe")]
		public ProbeData Probe { get; set; }

		[JsonProperty("envs")]
		public EnvsData[] Envs { get; set; }

		public UpdateAppVersionRequest()
		{
		}

		public UpdateAppVersionRequest(string appName)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
