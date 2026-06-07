using System.Collections.Generic;

namespace Coherence.Cloud
{
	public class FindLobbyOptions
	{
		public List<LobbyFilter> LobbyFilters;

		public Dictionary<SortOptions, bool> Sort;

		public int Limit;

		public static FindLobbyOptions Default => null;
	}
}
