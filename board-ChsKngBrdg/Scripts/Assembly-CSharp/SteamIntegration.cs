using System;
using Steamworks;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
	public static SteamIntegration instance;

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (!SteamClient.IsValid)
		{
			try
			{
				SteamClient.Init(2523120u);
				SteamUserStats.RequestCurrentStats();
				PrintYourName();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	private void PrintYourName()
	{
		Debug.Log(SteamClient.Name);
	}

	private void Update()
	{
		SteamClient.RunCallbacks();
	}

	private void OnApplicationQuit()
	{
		SteamClient.Shutdown();
	}
}
