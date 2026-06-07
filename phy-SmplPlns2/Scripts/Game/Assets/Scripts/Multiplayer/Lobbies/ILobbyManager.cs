using System;
using Assets.Scripts.Multiplayer.Lobbies.Events;

namespace Assets.Scripts.Multiplayer.Lobbies
{
	public interface ILobbyManager
	{
		event EventHandler<LobbyListEventArgs> LobbyListReceived;

		void CreateLobby(LobbyType type, int maxMembers, string serverName, string password);

		void GetLobbyList(int maxResults, bool includeWorldwideLobbies, string lobbyNameFilter);

		void JoinLobby(ulong lobbyId, bool autoLoadScene, string password);

		void LeaveLobby();

		void OnLobbySettingsChanged();

		void OpenInviteFriendsDialog();
	}
}
