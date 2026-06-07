using System;
using Steamworks;
using SwissCode.Steam;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
	public static readonly SteamAchievementFacade Achievements = new SteamAchievementFacade();

	public static readonly SteamCloudFacade Cloud = new SteamCloudFacade();

	public static readonly SteamFriendsFacade Friends = new SteamFriendsFacade();

	public static readonly SteamOverlayFacade Overlay = new SteamOverlayFacade();

	public static readonly SteamStatsFacade Stats = new SteamStatsFacade();

	public static readonly SteamUserFacade User = new SteamUserFacade();

	public static readonly SteamInputFacade Input = new SteamInputFacade();

	public static bool Initialized { get; private set; }

	private void Awake()
	{
		if (!Packsize.Test())
		{
			throw new SteamException("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.");
		}
		if (!DllCheck.Test())
		{
			throw new SteamException("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.");
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary(new AppId_t(3907940u)))
			{
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException)
		{
			Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.", this);
			Application.Quit();
			return;
		}
		Initialized = SteamAPI.InitEx(out var OutSteamErrMsg) == ESteamAPIInitResult.k_ESteamAPIInitResult_OK;
		if (!Initialized)
		{
			throw new SteamException("[Steamworks.NET] SteamAPI_Init() failed: " + OutSteamErrMsg);
		}
		Achievements.Initialize();
		Cloud.Initialize();
		Friends.Initialize();
		Overlay.Initialize();
		Stats.Initialize();
		User.Initialize();
		Input.Initialize();
	}

	private void OnDestroy()
	{
		if (Initialized)
		{
			SteamAPI.Shutdown();
			Initialized = false;
		}
	}

	private void Update()
	{
		if (Initialized)
		{
			SteamAPI.RunCallbacks();
		}
	}
}
