using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Lobby Settings", fileName = "LobbySettings")]
public class LobbySettings : ScriptableObject
{
	public CSteamID steamLobbyID;

	[Header("Lobby Settings")]
	public bool createLobbyOnStart = true;

	public bool inALobby;

	public int maxPlayers;

	public int currentPlayerCount;

	[Header("Player Database")]
	public List<PlayerInfo> players = new List<PlayerInfo>();

	[Header("Code Settings")]
	public int codeLength;

	public string lobbyCode;

	public static event Action<LobbySettings> SettingsChanged;

	public void NotifyChanged()
	{
		LobbySettings.SettingsChanged?.Invoke(this);
	}

	public void UpdatePlayers(List<PlayerInfo> newPlayers)
	{
		if (newPlayers != null)
		{
			foreach (PlayerInfo newPlayer in newPlayers)
			{
				PlayerInfo playerBySteamId = GetPlayerBySteamId(newPlayer.steamId);
				if (playerBySteamId != null && newPlayer.playerColor == Color.white)
				{
					newPlayer.playerColor = playerBySteamId.playerColor;
				}
			}
			players.Clear();
			players.AddRange(newPlayers);
			UIColorPalette colorPalette = Resources.Load<UIColorPalette>("ColorSettings");
			SyncColorsToPalette(colorPalette);
		}
		else
		{
			players.Clear();
		}
		currentPlayerCount = players.Count;
		NotifyChanged();
	}

	private void SyncColorsToPalette(UIColorPalette colorPalette)
	{
		if (!(colorPalette == null))
		{
			colorPalette.UpdateLocalPlayerColor(this);
		}
	}

	public void UpdatePlayerColor(ulong steamId, Color newColor)
	{
		PlayerInfo playerBySteamId = GetPlayerBySteamId(steamId);
		if (playerBySteamId == null)
		{
			return;
		}
		playerBySteamId.playerColor = newColor;
		ulong steamID = SteamUser.GetSteamID().m_SteamID;
		if (steamId == steamID)
		{
			UIColorPalette uIColorPalette = Resources.Load<UIColorPalette>("ColorSettings");
			if (uIColorPalette != null)
			{
				uIColorPalette.UpdateLocalPlayerColor(this);
			}
		}
		NotifyChanged();
	}

	public PlayerInfo GetPlayerBySteamId(ulong steamId)
	{
		return players.Find((PlayerInfo p) => p.steamId == steamId);
	}

	public void RemovePlayerBySteamId(ulong steamId)
	{
		PlayerInfo playerBySteamId = GetPlayerBySteamId(steamId);
		if (playerBySteamId == null)
		{
			return;
		}
		ulong steamID = SteamUser.GetSteamID().m_SteamID;
		if (steamId == steamID)
		{
			UIColorPalette uIColorPalette = Resources.Load<UIColorPalette>("ColorSettings");
			if (uIColorPalette != null)
			{
				uIColorPalette.playerColor = Color.blue;
				uIColorPalette.NotifyChanged();
			}
		}
		players.Remove(playerBySteamId);
		NotifyChanged();
	}
}
