using Newtonsoft.Json;

namespace Edgegap.Editor.Api.Models.Requests
{
	public class CreateAppVersionRequest
	{
		[JsonIgnore]
		public string AppName { get; set; }

		[JsonProperty("name")]
		public string VersionName { get; set; }

		[JsonProperty("docker_tag")]
		public string DockerTag { get; set; }

		[JsonProperty("docker_image")]
		public string DockerImage { get; set; }

		[JsonProperty("docker_repository")]
		public string DockerRepository { get; set; }

		[JsonProperty("req_cpu")]
		public int ReqCpu { get; set; }

		[JsonProperty("req_memory")]
		public int ReqMemory { get; set; }

		[JsonProperty("ports")]
		public AppPortsData[] Ports { get; set; }

		[JsonProperty("private_username")]
		public string PrivateUsername { get; set; }

		[JsonProperty("private_token")]
		public string PrivateToken { get; set; }

		public CreateAppVersionRequest()
		{
		}

		public CreateAppVersionRequest(string appName, string containerRegistryUsername, string containerRegistryPasswordToken, int portNum, ProtocolType protocolType)
		{
		}

		public static CreateAppVersionRequest FromUpdateRequest(UpdateAppVersionRequest updateRequest)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
