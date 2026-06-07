using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct SetAttributesRequest
	{
		[JsonProperty("attributes")]
		public List<CloudAttribute> Attributes;

		public static string GetRequestBody(List<CloudAttribute> attr)
		{
			return null;
		}
	}
}
