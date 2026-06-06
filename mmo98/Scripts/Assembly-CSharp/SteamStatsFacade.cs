using Steamworks;
using UnityEngine;

public class SteamStatsFacade : SteamFacade
{
	private CallResult<UserStatsReceived_t> _userStatsReceivedCallback;

	private CallResult<GlobalStatsReceived_t> _globalStatsReceivedCallback;

	public override void Initialize()
	{
		base.Initialize();
		_userStatsReceivedCallback = CallResult<UserStatsReceived_t>.Create(OnUserStatsReceived);
		_globalStatsReceivedCallback = CallResult<GlobalStatsReceived_t>.Create(OnGlobalStatsReceived);
	}

	public int GetStatInt(string name)
	{
		if (Initialized && !string.IsNullOrEmpty(name))
		{
			if (!SteamUserStats.GetStat(name, out int pData))
			{
				return 0;
			}
			return pData;
		}
		return 0;
	}

	public float GetStatFloat(string name)
	{
		if (Initialized && !string.IsNullOrEmpty(name))
		{
			if (!SteamUserStats.GetStat(name, out float pData))
			{
				return 0f;
			}
			return pData;
		}
		return 0f;
	}

	public void SetStatInt(string name, int value, bool store = true)
	{
		if (Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.SetStat(name, value) && store)
		{
			StoreStats();
		}
	}

	public void SetStatFloat(string name, float value, bool store = true)
	{
		if (Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.SetStat(name, value) && store)
		{
			StoreStats();
		}
	}

	public void IncreaseStatInt(string name, int value, bool store = true)
	{
		if (Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.SetStat(name, GetStatInt(name) + value) && store)
		{
			StoreStats();
		}
	}

	public void IncreaseStatFloat(string name, float value, bool store = true)
	{
		if (Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.SetStat(name, GetStatFloat(name) + value) && store)
		{
			StoreStats();
		}
	}

	public void StoreStats()
	{
		if (Initialized && !SteamUserStats.StoreStats())
		{
			Debug.LogWarning("Failed to persist stats to Steam");
		}
	}

	public bool ResetAllStats(bool achievementsIncluded = false)
	{
		if (Initialized)
		{
			return SteamUserStats.ResetAllStats(achievementsIncluded);
		}
		return false;
	}

	public void RequestUserStatsAsync(CSteamID steamId)
	{
		if (Initialized)
		{
			_userStatsReceivedCallback.Set(SteamUserStats.RequestUserStats(steamId));
		}
	}

	public int GetStatIntForUser(CSteamID steamId, string name)
	{
		if (Initialized)
		{
			if (!SteamUserStats.GetUserStat(steamId, name, out int pData))
			{
				return 0;
			}
			return pData;
		}
		return 0;
	}

	public float GetStatFloatForUser(CSteamID steamId, string name)
	{
		if (Initialized)
		{
			if (!SteamUserStats.GetUserStat(steamId, name, out float pData))
			{
				return 0f;
			}
			return pData;
		}
		return 0f;
	}

	public void RequestGlobalStatsAsync()
	{
		if (Initialized)
		{
			_globalStatsReceivedCallback.Set(SteamUserStats.RequestGlobalStats(0));
		}
	}

	public long GetStatLongGlobal(string name)
	{
		if (Initialized && !string.IsNullOrEmpty(name))
		{
			if (!SteamUserStats.GetGlobalStat(name, out long pData))
			{
				return 0L;
			}
			return pData;
		}
		return 0L;
	}

	public double GetStatDoubleGlobal(string name)
	{
		if (Initialized && !string.IsNullOrEmpty(name))
		{
			if (!SteamUserStats.GetGlobalStat(name, out double pData))
			{
				return 0.0;
			}
			return pData;
		}
		return 0.0;
	}

	private void OnUserStatsReceived(UserStatsReceived_t data, bool failure)
	{
		if (Initialized && (data.m_eResult != EResult.k_EResultOK || failure))
		{
			Debug.LogWarning($"There was an error receiving user {data.m_steamIDUser} stats with result {data.m_eResult}.");
		}
	}

	private void OnGlobalStatsReceived(GlobalStatsReceived_t data, bool failure)
	{
		if (Initialized && (data.m_eResult != EResult.k_EResultOK || failure))
		{
			Debug.LogWarning($"There was an error receiving global stats with result {data.m_eResult}.");
		}
	}
}
