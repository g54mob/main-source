using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct FetchLobbiesRequest
	{
		[JsonProperty("filters")]
		public List<LobbyFilter> LobbyFilters;

		[JsonProperty("limit")]
		public int Limit;

		[JsonProperty("public_only")]
		public bool PublicOnly;

		[JsonProperty("sort")]
		public List<LobbySortOption> Sort;

		public static string GetRequestBody(FindLobbyOptions options)
		{
			return null;
		}
	}
}
