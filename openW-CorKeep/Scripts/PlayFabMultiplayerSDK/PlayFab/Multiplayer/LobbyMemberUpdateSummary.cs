using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyMemberUpdateSummary
	{
		private PFLobbyMemberUpdateSummary summary;

		private List<string> updatedMemberPropertyKeyList;

		private PFEntityKey member;

		public PFEntityKey Member => member;

		public bool ConnectionStatusUpdated => summary.ConnectionStatusUpdated;

		public List<string> UpdatedMemberPropertyKeys => updatedMemberPropertyKeyList;

		internal LobbyMemberUpdateSummary(PFLobbyMemberUpdateSummary summary)
		{
			this.summary = summary;
			updatedMemberPropertyKeyList = new List<string>(summary.UpdatedMemberPropertyKeys);
			member = new PFEntityKey(summary.Member);
		}
	}
}
