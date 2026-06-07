using Steamworks;
using UnityEngine;

public class SteamScript : MonoBehaviour
{
	[HideInInspector]
	public bool CheevosLoaded;

	[HideInInspector]
	public bool StoreStats;

	private Callback<UserStatsReceived_t> statsReceived;

	protected Callback<UserStatsStored_t> m_UserStatsStored;

	private void OnEnable()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		if (!SteamManager.Initialized)
		{
			MonoBehaviour.print("Steamworks not initialized so achievements not loaded");
			return;
		}
		statsReceived = Callback<UserStatsReceived_t>.Create(OnStatsReceived);
		m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
		SteamUserStats.RequestCurrentStats();
	}

	private void Start()
	{
		if (SteamManager.Initialized)
		{
			string personaName = SteamFriends.GetPersonaName();
			Debug.Log("Signed into steam as " + personaName);
		}
	}

	private void Update()
	{
		if (CheevosLoaded)
		{
			SteamAPI.RunCallbacks();
		}
		if (StoreStats)
		{
			MonoBehaviour.print("attempting to store stats");
			SteamUserStats.StoreStats();
		}
	}

	private void OnStatsReceived(UserStatsReceived_t pCallback)
	{
		if (pCallback.m_nGameID != 1846170)
		{
			MonoBehaviour.print("Data is not for Iron Lung!  Game Id " + pCallback.m_nGameID);
		}
		else
		{
			CheevosLoaded = true;
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		StoreStats = false;
		MonoBehaviour.print("Stats successfully stored");
	}

	public void UnlockCheevo(string cheevo)
	{
		if (!SteamManager.Initialized)
		{
			MonoBehaviour.print("Steamworks not initialized so achievement " + cheevo + " not unlocked");
			return;
		}
		if (!CheevosLoaded)
		{
			MonoBehaviour.print("Achievements not loaded so achievement " + cheevo + " not unlocked");
			return;
		}
		bool pbAchieved = false;
		SteamUserStats.GetAchievement(cheevo, out pbAchieved);
		if (!pbAchieved)
		{
			SteamUserStats.SetAchievement(cheevo);
			StoreStats = true;
		}
	}
}
