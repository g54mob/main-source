using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbySearchConfiguration
	{
		public LobbySearchFriendsFilter FriendsFilter => new LobbySearchFriendsFilter(SearchConfig.FriendsFilter);

		public string FilterString
		{
			get
			{
				return SearchConfig.FilterString;
			}
			set
			{
				SearchConfig.FilterString = value;
			}
		}

		public string SortString
		{
			get
			{
				return SearchConfig.SortString;
			}
			set
			{
				SearchConfig.SortString = value;
			}
		}

		public uint? ClientSearchResultCount
		{
			get
			{
				return SearchConfig.ClientSearchResultCount;
			}
			set
			{
				SearchConfig.ClientSearchResultCount = value;
			}
		}

		internal PFLobbySearchConfiguration SearchConfig { get; set; }

		public LobbySearchConfiguration()
		{
			SearchConfig = new PFLobbySearchConfiguration();
		}
	}
}
