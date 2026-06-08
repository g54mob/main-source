using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Ingests
{
	public class Ingests
	{
		[JsonProperty(PropertyName = "ingests")]
		public Ingest[] IngestServers { get; protected set; }
	}
}
