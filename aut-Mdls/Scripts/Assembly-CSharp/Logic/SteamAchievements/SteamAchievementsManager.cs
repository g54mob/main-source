#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections;
using Data.Variables;
using Events.Generic;
using Events.SteamAchievements;
using NaughtyAttributes;
using Steamworks;
using UnityEngine;
using Utils;

namespace Logic.SteamAchievements
{
	public class SteamAchievementsManager : MonoBehaviour
	{
		[SerializeField]
		private SteamAchievementsController steamAchievementsController;

		[SerializeField]
		private SteamStatsController steamStatsController;

		[SerializeField]
		private UnlockAchievementEvent _unlockAchievementEvent;

		[SerializeField]
		private IncrementSteamStatEvent _incrementSteamStatEvent;

		[SerializeField]
		private ZenModeVariableSO _zenModeVariableSO;

		[SerializeField]
		private float _updateStatDuration = 15f;

		[SerializeField]
		private float _updateAchievementDuration = 3f;

		[SerializeField]
		private BoolEvent _levelFinishedLoadingZenModeEvent;

		private Coroutine _achievementCoroutine;

		private Coroutine _statCoroutine;

		private void Start()
		{
			if (!SteamManager.Initialized)
			{
				this.LogError("Couldn't request stats because steam manager isn't initialized!", "Start", 33);
				return;
			}
			if (_zenModeVariableSO.Value)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			_levelFinishedLoadingZenModeEvent.Register(HandleZenModeLevelLoaded);
			_unlockAchievementEvent.Register(HandleUnlockAchievementEvent);
			_incrementSteamStatEvent.Register(HandleIncrementStatEvent);
			steamAchievementsController.Init();
			int pData;
			bool stat = SteamUserStats.GetStat(SteamAchievementConstants.SteamStatNames.TOTAL_CUBES_PRODUCED.ToString(), out pData);
			int pData2;
			bool stat2 = SteamUserStats.GetStat(SteamAchievementConstants.SteamStatNames.TOTAL_RESOURCES_SCRAPPED.ToString(), out pData2);
			if (stat && stat2)
			{
				steamStatsController.Init(pData, pData2);
			}
			_achievementCoroutine = StartCoroutine(UpdateAchievementProgress());
			_statCoroutine = StartCoroutine(UpdateStatProgress());
		}

		private void HandleZenModeLevelLoaded(bool isZenMode)
		{
			if (isZenMode || _zenModeVariableSO.Value)
			{
				this.Log("Removed achievement controller for creativemode!", "HandleZenModeLevelLoaded", 65);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void OnDestroy()
		{
			_levelFinishedLoadingZenModeEvent.UnRegister(HandleZenModeLevelLoaded);
			steamAchievementsController.UnInit();
			steamStatsController.UnInit();
			_unlockAchievementEvent.UnRegister(HandleUnlockAchievementEvent);
			_incrementSteamStatEvent.UnRegister(HandleIncrementStatEvent);
			if (_achievementCoroutine != null)
			{
				StopCoroutine(_achievementCoroutine);
			}
			if (_statCoroutine != null)
			{
				StopCoroutine(_statCoroutine);
			}
		}

		private IEnumerator UpdateAchievementProgress()
		{
			while (true)
			{
				yield return new WaitForSeconds(_updateAchievementDuration);
				steamAchievementsController.Update();
			}
		}

		private IEnumerator UpdateStatProgress()
		{
			while (true)
			{
				yield return new WaitForSeconds(_updateStatDuration);
				steamStatsController.Update();
			}
		}

		private void HandleUnlockAchievementEvent(string achievementName)
		{
			SetAchievement(achievementName);
		}

		private void HandleIncrementStatEvent((string statName, int statIncrement) statData)
		{
			SetStat(statData.statName, statData.statIncrement);
		}

		private void SetAchievement(string achievementName)
		{
			if (!_zenModeVariableSO.Value)
			{
				SteamUserStats.SetAchievement(achievementName);
				SteamUserStats.StoreStats();
			}
		}

		public void SetStat(string achievementName, int amount)
		{
			if (!_zenModeVariableSO.Value)
			{
				SteamUserStats.SetStat(achievementName, amount);
				SteamUserStats.StoreStats();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestClearStatsAndAchievements()
		{
			SteamUserStats.ResetAllStats(bAchievementsToo: true);
			SteamUserStats.StoreStats();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestPrintAllStats()
		{
			SteamAchievementConstants.SteamStatNames[] array = (SteamAchievementConstants.SteamStatNames[])Enum.GetValues(typeof(SteamAchievementConstants.SteamStatNames));
			for (int i = 0; i < array.Length; i++)
			{
				SteamAchievementConstants.SteamStatNames steamStatNames = array[i];
				if (SteamUserStats.GetStat(steamStatNames.ToString(), out int pData))
				{
					this.Log($"Stat {steamStatNames}: {pData}", "TestPrintAllStats", 149);
				}
				else
				{
					this.Log($"Could not get stat {steamStatNames}", "TestPrintAllStats", 153);
				}
			}
		}
	}
}
