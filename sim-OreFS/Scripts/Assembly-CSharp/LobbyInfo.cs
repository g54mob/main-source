using System;
using Heathen.SteamworksIntegration;
using I2.Loc;
using Steamworks;

[Serializable]
public struct LobbyInfo
{
	public LobbyData lobbyId;

	public string lobbyName;

	public string ownerName;

	public string lobbyCode;

	public string version;

	public ELobbyType lobbyType;

	public int playerCount;

	public int maxPlayers;

	public bool isPrivate;

	public string GetDisplayName()
	{
		if (!string.IsNullOrEmpty(lobbyName))
		{
			return lobbyName;
		}
		return ownerName + "'s Factory";
	}

	public string GetPlayerCountText()
	{
		return $"{playerCount}/{maxPlayers}";
	}

	public string GetLobbyTypeDisplayText()
	{
		if (!isPrivate)
		{
			return LocalizationManager.GetTranslation("Public");
		}
		return LocalizationManager.GetTranslation("Invite Only");
	}
}
