using Newtonsoft.Json;

namespace Edgegap.Editor.Api.Models.Requests
{
	public class CreateAppRequest
	{
		[JsonProperty("name")]
		public string AppName { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }

		[JsonProperty("image")]
		public string Image { get; set; }

		[JsonProperty("is_telemetry_agent_active")]
		public bool IsTelemetryAgentActive { get; set; }

		public CreateAppRequest()
		{
		}

		public CreateAppRequest(string appName, bool isActive, string image)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
