using Newtonsoft.Json;

namespace Edgegap.Editor.Api.Models.Requests
{
	public class CreateDeploymentRequest
	{
		[JsonProperty("app_name")]
		public string AppName { get; set; }

		[JsonProperty("version_name")]
		public string VersionName { get; set; }

		[JsonProperty("ip_list")]
		public string[] IpList { get; set; }

		[JsonProperty("geo_ip_list")]
		public string[] GeoIpList { get; set; }

		public CreateDeploymentRequest()
		{
		}

		public CreateDeploymentRequest(string appName, string versionName, string externalIp)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
