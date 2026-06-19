using System.Collections.Generic;
using Steamworks;
using UnityEngine;

namespace TH20
{
	public class SteamLocalPlayer
	{
		public readonly CSteamID SteamID;

		public readonly string DisplayName;

		public readonly Sprite DisplayIcon;

		public SteamLocalPlayer(List<string> remoteFiles)
		{
			SteamID = OnlineManager.GetLocalPlayerID();
			DisplayName = SteamFriends.GetFriendPersonaName(SteamID);
			DisplayIcon = SteamManager.GetAvatar(SteamID);
		}
	}
}
