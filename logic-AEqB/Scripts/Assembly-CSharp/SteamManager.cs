using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
	public static SteamManager Instance;

	private static uint gameAppId = 1720850u;

	private string playerSteamIdString;

	private bool connectedToSteam;

	private Friend lobbyPartner;

	public List<Lobby> activeUnrankedLobbies;

	public List<Lobby> activeRankedLobbies;

	public Lobby currentLobby;

	private Lobby hostedMultiplayerLobby;

	private bool applicationHasQuit;

	private bool daRealOne;

	private List<Achievement> achievements;

	private bool t = true;

	public string PlayerName { get; set; }

	public SteamId PlayerSteamId { get; set; }

	public string PlayerSteamIdString => playerSteamIdString;

	public Friend LobbyPartner
	{
		get
		{
			return lobbyPartner;
		}
		set
		{
			lobbyPartner = value;
		}
	}

	public SteamId OpponentSteamId { get; set; }

	public bool LobbyPartnerDisconnected { get; set; }

	public void SetUp()
	{
		if (Instance == null)
		{
			daRealOne = true;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Instance = this;
			PlayerName = "";
			try
			{
				SteamClient.Init(gameAppId);
				if (!SteamClient.IsValid)
				{
					Debug.Log("Steam client not valid");
					throw new Exception();
				}
				PlayerName = SteamClient.Name;
				PlayerSteamId = SteamClient.SteamId;
				playerSteamIdString = PlayerSteamId.ToString();
				activeUnrankedLobbies = new List<Lobby>();
				activeRankedLobbies = new List<Lobby>();
				connectedToSteam = true;
				Debug.Log("Steam initialized: " + PlayerName);
				achievements = SteamUserStats.Achievements.ToList();
				foreach (Achievement achievement in achievements)
				{
					_ = achievement;
				}
				return;
			}
			catch (Exception message)
			{
				connectedToSteam = false;
				playerSteamIdString = "NoSteamId";
				Debug.Log("Error connecting to Steam");
				Debug.Log(message);
				PlayerName = "LocalPlayer";
				playerSteamIdString = "localplayer";
				return;
			}
		}
		if (Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public bool ConnectedToSteam()
	{
		return connectedToSteam;
	}

	private void Start()
	{
	}

	private void Update()
	{
		SteamClient.RunCallbacks();
	}

	private void OnDisable()
	{
		if (daRealOne)
		{
			gameCleanup();
		}
	}

	private void OnDestroy()
	{
		if (daRealOne)
		{
			gameCleanup();
		}
	}

	private void OnApplicationQuit()
	{
		if (daRealOne)
		{
			gameCleanup();
		}
	}

	private void gameCleanup()
	{
		if (!applicationHasQuit)
		{
			applicationHasQuit = true;
			SteamClient.Shutdown();
		}
	}

	public void UnlockAchievements(string achievement)
	{
		if (!connectedToSteam)
		{
			return;
		}
		try
		{
			foreach (Achievement achievement2 in achievements)
			{
				if (achievement2.Identifier == achievement && achievement2.State)
				{
					Debug.Log(achievement);
					Debug.Log("already unlocked");
					break;
				}
				if (achievement2.Identifier == achievement && !achievement2.State)
				{
					achievement2.Trigger();
					Debug.Log("unlock");
				}
			}
		}
		catch
		{
			Debug.Log("Unable to set unlocked achievement status on Steam");
		}
	}
}
