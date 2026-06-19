using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyConstants
	{
		public const uint LobbyMaxMemberCountLowerLimit = 2u;

		public const uint LobbyMaxMemberCountUpperLimit = 128u;

		public const uint LobbyMaxSearchPropertyCount = 30u;

		public const uint LobbyMaxLobbyPropertyCount = 30u;

		public const uint LobbyMaxMemberPropertyCount = 30u;

		public const uint LobbyClientRequestedSearchResultCountUpperLimit = 50u;

		public static readonly string LobbyMemberCountSearchKey = PFLobbyConsts.LobbyMemberCountSearchKey;

		public static readonly string LobbyMemberCountRemainingSearchKey = PFLobbyConsts.LobbyMemberCountRemainingSearchKey;

		public static readonly string LobbyAmMemberSearchKey = PFLobbyConsts.LobbyAmMemberSearchKey;

		public static readonly string LobbyAmOwnerSearchKey = PFLobbyConsts.LobbyAmOwnerSearchKey;

		private static readonly string LobbyMembershipLockSearchKey = PFLobbyConsts.LobbyMembershipLockSearchKey;

		private static readonly string LobbyAmServerSearchKey = PFLobbyConsts.LobbyAmServerSearchKey;
	}
}
