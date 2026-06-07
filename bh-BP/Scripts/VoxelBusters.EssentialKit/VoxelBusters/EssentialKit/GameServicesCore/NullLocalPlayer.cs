using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal sealed class NullLocalPlayer : NullPlayer, ILocalPlayer, IPlayer
	{
		private static readonly NullLocalPlayer s_localPlayer;

		private static AuthChangeInternalCallback s_onAuthChange;

		public bool IsAuthenticated => false;

		public bool IsUnderAge => false;

		public static NullLocalPlayer GetLocalPlayer()
		{
			return null;
		}

		public static void Authenticate()
		{
		}

		public static void Signout()
		{
		}

		public static void SetAuthChangeCallback(AuthChangeInternalCallback callback)
		{
		}

		private static void LogNotSupported()
		{
		}

		public void LoadFriends(EventCallback<GameServicesLoadPlayerFriendsResult> callback)
		{
		}

		public void AddFriend(string playerId, EventCallback<bool> callback)
		{
		}
	}
}
