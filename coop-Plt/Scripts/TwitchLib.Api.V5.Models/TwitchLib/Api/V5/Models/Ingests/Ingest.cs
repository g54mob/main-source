using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Ingests
{
	public class Ingest
	{
		[JsonProperty(PropertyName = "_id")]
		public int Id { get; protected set; }

		[JsonProperty(PropertyName = "availability")]
		public double Availability { get; protected set; }

		[JsonProperty(PropertyName = "default")]
		public bool Default { get; protected set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; protected set; }

		[JsonProperty(PropertyName = "url_template")]
		public string UrlTemplate { get; protected set; }
	}
}
