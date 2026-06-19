using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbySearchResult
	{
		private PFLobbySearchResult searchResult;

		private PFEntityKey owner;

		private List<PFEntityKey> friendsList;

		public string LobbyId => searchResult.LobbyId;

		public string ConnectionString => searchResult.ConnectionString;

		public PFEntityKey OwnerEntity => owner;

		public uint MaxMemberCount => searchResult.MaxMemberCount;

		public uint CurrentMemberCount => searchResult.CurrentMemberCount;

		public IDictionary<string, string> SearchProperties => searchResult.SearchProperties;

		public IList<PFEntityKey> Friends => friendsList;

		public LobbyMembershipLock MembershipLock => (LobbyMembershipLock)searchResult.MembershipLock;

		internal LobbySearchResult(PFLobbySearchResult searchResult)
		{
			this.searchResult = searchResult;
			owner = new PFEntityKey(searchResult.OwnerEntity);
			friendsList = new List<PFEntityKey>();
			foreach (PlayFab.Multiplayer.InteropWrapper.PFEntityKey friend in searchResult.Friends)
			{
				PFEntityKey item = new PFEntityKey(friend);
				Friends.Add(item);
			}
		}
	}
}
