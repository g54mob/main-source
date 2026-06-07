using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Leaderboards;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public class SteamStatsManager : BaseSingleton<SteamStatsManager>
	{
		private Dictionary<int, long> _globalSumoWins;

		private Dictionary<int, long> _globalSumoParts;

		private bool _storeStats;

		private bool _initialized;

		protected override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(this);
		}

		public void StoreStats()
		{
			_storeStats = true;
		}

		public void Update()
		{
			if (SteamManager.Connected && !_initialized)
			{
				SteamUserStats.RequestCurrentStats();
				_initialized = true;
			}
			if (_storeStats)
			{
				_storeStats = !SteamUserStats.StoreStats();
			}
		}

		private IEnumerator RequestUserStats()
		{
			SteamCallbackCoroutine<UserStatsReceived_t> steamCallbackCoroutine = new SteamCallbackCoroutine<UserStatsReceived_t>();
			SteamAPICall_t handle = SteamUserStats.RequestUserStats(SteamUser.GetSteamID());
			yield return steamCallbackCoroutine.Start(handle, 5f);
		}

		public IEnumerator UpdateGlobalStats(int days)
		{
			SteamCallbackCoroutine<GlobalStatsReceived_t> globalstats = new SteamCallbackCoroutine<GlobalStatsReceived_t>();
			SteamAPICall_t handle = SteamUserStats.RequestGlobalStats(days);
			yield return globalstats.Start(handle, 5f);
			if (!globalstats.HasResult)
			{
				yield break;
			}
			_globalSumoWins = new Dictionary<int, long>();
			for (int i = 0; i <= 10; i++)
			{
				long pData;
				if (SteamUserStats.GetGlobalStat("SumoWins" + i, out pData))
				{
					_globalSumoWins.Add(i, pData);
				}
			}
			_globalSumoParts = new Dictionary<int, long>();
			for (int j = 10; j <= 100; j += 10)
			{
				long pData2;
				if (SteamUserStats.GetGlobalStat("SumoUsedParts" + j, out pData2))
				{
					_globalSumoParts.Add(j, pData2);
				}
			}
		}
	}
}
