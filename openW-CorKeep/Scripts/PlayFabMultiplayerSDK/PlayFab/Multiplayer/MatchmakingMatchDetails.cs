using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class MatchmakingMatchDetails
	{
		private PFMatchmakingMatchDetails details;

		private IList<MatchmakingTicketMatchMember> members;

		private IList<string> regionPreferences;

		private MultiplayerServerDetails serverDetails;

		public string MatchId => details.MatchId;

		public IList<MatchmakingTicketMatchMember> Members => members;

		public IList<string> RegionPreferences => regionPreferences;

		public string LobbyArrangementString => details.LobbyArrangementString;

		public MultiplayerServerDetails ServerDetails => serverDetails;

		internal MatchmakingMatchDetails(PFMatchmakingMatchDetails details)
		{
			this.details = details;
			members = this.details.Members.Select((PFMatchmakingMatchMember x) => new MatchmakingTicketMatchMember(x)).ToList();
			regionPreferences = details.RegionPreferences.ToList();
			if (details.ServerDetails != null)
			{
				serverDetails = new MultiplayerServerDetails(details.ServerDetails);
			}
		}
	}
}
