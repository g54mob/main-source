using System;
using System.Threading.Tasks;

namespace VampireSurvivors.Framework
{
	public static class OnlinePlatformSupport
	{
		public static OnlinePlatformSupportBase OnlinePlatformSupportInstance;

		public const string CommunicatingPopupID = "OnlinePlatformSupportCommunicating";

		public const string HostStartingGamePopupID = "HostStartingGame";

		private static Task<bool> leaveLobbyTask;

		private static bool onlineChecksInProgress;

		public static bool WaitForServerResponseOnEnteringOnline => false;

		public static void Setup()
		{
		}

		public static void AutoJoinLobby(string lobbyID)
		{
		}

		public static void OnLobbyOpen(string lobbyID)
		{
		}

		public static void OnLobbyClosed(string lobbyID)
		{
		}

		public static void CheckAgeOk(Action<bool> callback)
		{
		}

		public static void CheckOnlineEntitlement(Action<bool> callback)
		{
		}

		public static void OnCreatedOnlineSession(string lobbyId, Action<bool> callback)
		{
		}

		public static void OnJoinedOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public static void OnRemotePlayerJoinedRoom(string lobbyID, Action<bool> callback)
		{
		}

		public static void OnPlayerLeftOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public static void OnEndOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public static void OnConnectionError()
		{
		}

		public static void CheckHasInternetConnection(Action<bool> callback)
		{
		}

		public static void OnUpdate()
		{
		}

		public static void ShowUsersProfile(string userId)
		{
		}

		public static void InvitePlayers(string lobbyID)
		{
		}

		public static bool TryJoinLobby(bool havePendingInvite, string pendingInviteLobbyID)
		{
			return false;
		}

		private static void ClearInvites()
		{
		}

		private static void CloseOnlineCommunicatingPopup()
		{
		}
	}
}
