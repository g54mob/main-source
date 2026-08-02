using Steamworks;
using UnityEngine;

public class SteamInitializer : MonoBehaviour
{
	private static bool isInitialized;

	private void Start()
	{
		if (!isInitialized)
		{
			if (!SteamManager.Initialized)
			{
				Debug.LogError("Steam API could not be initialized!");
				return;
			}
			Debug.Log("Steam API initialized successfully.");
			Debug.Log("steam nick : " + SteamFriends.GetPersonaName());
			isInitialized = true;
			Object.DontDestroyOnLoad(base.gameObject);
			PlayerPrefs.SetString("PlayerName", SteamFriends.GetPersonaName());
		}
	}
}
