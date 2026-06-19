using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class MatchmakingTicketMatchMember
	{
		private PFMatchmakingMatchMember member;

		private PFEntityKey entityKey;

		public PFEntityKey EntityKey => entityKey;

		public string TeamId => member.TeamId;

		public string AttributesJSON => member.Attributes;

		internal MatchmakingTicketMatchMember(PFMatchmakingMatchMember member)
		{
			this.member = member;
			entityKey = new PFEntityKey(this.member.EntityKey);
		}
	}
}
