using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitchLib.Api.V5.Models.Clips
{
	public class TopClipsResponse
	{
		[JsonProperty(PropertyName = "_cursor")]
		public string Cursor { get; protected set; }

		public List<Clip> Clips { get; protected set; } = new List<Clip>();

		public TopClipsResponse(JToken json)
		{
		}
	}
}
