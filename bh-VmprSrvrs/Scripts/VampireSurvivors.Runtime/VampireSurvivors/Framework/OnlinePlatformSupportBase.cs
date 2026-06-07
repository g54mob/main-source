using System;

namespace VampireSurvivors.Framework
{
	public class OnlinePlatformSupportBase
	{
		public virtual bool WaitForServerResponseOnEnteringOnline => false;

		public virtual void Initialise()
		{
		}

		public virtual void OnLobbyOpen(string lobbyID)
		{
		}

		public virtual void OnLobbyClosed(string lobbyID)
		{
		}

		public virtual void CheckInternetConnectionState(Action<bool> callback)
		{
		}

		public virtual void OnConnectionError()
		{
		}

		public virtual void CheckAgeOk(Action<bool> callback)
		{
		}

		public virtual void CheckOnlineEntitlement(Action<bool> callback)
		{
		}

		public virtual void OnCreatedOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public virtual void OnJoinedOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public virtual void OnRemotePlayerJoinedRoom(string lobbyID, Action<bool> callback)
		{
		}

		public virtual void OnPlayerLeftOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public virtual void OnEndOnlineSession(string lobbyID, Action<bool> callback)
		{
		}

		public virtual void ShowUsersProfile(string userId)
		{
		}

		public virtual void InvitePlayers(string lobbyId)
		{
		}

		public virtual void OnUpdate()
		{
		}
	}
}
