using Steamworks;
using UnityEngine;

namespace TH20
{
	public class OnlinePlayerInfo
	{
		public OnlinePlayerID PlayerID { get; }

		public ulong AccountID { get; set; }

		public GameID PlayingGameID { get; set; }

		public bool IsLocalPlayer { get; set; }

		public string DisplayName { get; set; }

		public string OnlineName { get; set; }

		public Sprite DisplayIcon { get; set; }

		public int FriendRelationship { get; set; }

		public bool FlaggedForIconDownload { get; set; }

		public bool CommunicationBlocked { get; set; }

		public bool InvitesBlocked { get; set; }

		public OnlinePlayerInfo(OnlinePlayerID playerID, bool isLocal)
		{
			PlayerID = playerID;
			IsLocalPlayer = isLocal;
			CommunicationBlocked = false;
			InvitesBlocked = false;
			SteamSetup();
		}

		public bool IsPlayingGame()
		{
			if (IsLocalPlayer)
			{
				return true;
			}
			SteamFriends.GetFriendGamePlayed(PlayerID, out var pFriendGameInfo);
			return pFriendGameInfo.m_gameID == (CGameID)OSManager.AppID;
		}

		private void SteamSetup()
		{
			AccountID = (uint)SteamUser.GetSteamID().GetAccountID();
			if (PlayerID == (OnlinePlayerID)SteamUser.GetSteamID())
			{
				PlayingGameID = OSManager.AppID;
				IsLocalPlayer = true;
				DisplayName = SteamFriends.GetFriendPersonaName(PlayerID);
				OnlineName = DisplayName;
				DisplayIcon = SteamManager.GetAvatar((CSteamID)PlayerID);
				FriendRelationship = 0;
				return;
			}
			if (SteamFriends.GetFriendGamePlayed(PlayerID, out var pFriendGameInfo))
			{
				PlayingGameID = pFriendGameInfo.m_gameID;
			}
			IsLocalPlayer = false;
			DisplayName = SteamFriends.GetFriendPersonaName(PlayerID);
			DisplayIcon = SteamManager.GetAvatar((CSteamID)PlayerID);
			FriendRelationship = (int)SteamFriends.GetFriendRelationship(PlayerID);
			OnlineName = DisplayName;
		}
	}
}
