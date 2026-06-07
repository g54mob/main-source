using System;
using Steamworks;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
	public static SteamManager Singleton;

	private static uint gameAppID = 3370870u;

	private bool applicationHasQuit;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		try
		{
			SteamClient.Init(gameAppID);
			if (!SteamClient.IsValid)
			{
				Debug.Log("Steam Client not valid");
				throw new Exception();
			}
			Debug.Log("Steam Client Successfully Initialized!");
		}
		catch (Exception message)
		{
			Debug.Log("FAILED TO INITIALIZE STEAM CLIENT");
			Debug.Log(message);
		}
	}

	private void Start()
	{
		LoadPlayerNameFromSteam();
	}

	private void OnDestroy()
	{
	}

	private void Cleanup()
	{
		if (!applicationHasQuit)
		{
			applicationHasQuit = true;
			SteamClient.Shutdown();
		}
	}

	private void OnApplicationQuit()
	{
		Cleanup();
	}

	private void Update()
	{
	}

	public void LoadPlayerNameFromSteam()
	{
		_ = SteamClient.SteamId;
	}
}
