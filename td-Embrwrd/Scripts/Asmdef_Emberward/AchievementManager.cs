using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Steamworks;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CStart_003Ed__21(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private AchievementSettingData achievementData;

	private bool isAchievementLoaded;

	public static AchievementManager Instance;

	[SerializeField]
	private List<PlayerAchievementStatus> list_PlayerAchievementStatus;

	private Callback<UserStatsReceived_t> _cbUserStatsReceived;

	private Callback<UserStatsStored_t> _cbUserStatsStored;

	private Callback<UserAchievementStored_t> _cbUserAchievementStored;

	private List<AAchievementDetector> list_AchievementDetectors;

	private bool isIngameInitialized;

	public AchievementSettingData AchievementData => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void StartIngameDetection()
	{
	}

	public void StopIngameDetection()
	{
	}

	private void LoadAllAchievementComponents()
	{
	}

	private void LoadAchievementComponent(Type type)
	{
	}

	public List<eAchievementType> CheckAchievementAtGameStart()
	{
		return null;
	}

	public void ClaimAchievementsAtGameStart()
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__21))]
	private IEnumerator Start()
	{
		return null;
	}

	private void OnRequestAchievementUnlock(eAchievementType type)
	{
	}

	private void OnRequestSetAchievementProgress(eAchievementType type, int value, int max)
	{
	}

	private void OnRequestShowAchievementProgress(eAchievementType type, int value, int max)
	{
	}

	private void ShowAchievementProgress(eAchievementType type, int value, int max)
	{
	}

	private void OnRequestSetStatProgress(string statName, int value)
	{
	}

	public void SetAchievementProgress(eAchievementType type, int value, int max)
	{
	}

	public int GetAchievementProgress(eAchievementType type)
	{
		return 0;
	}

	public int GetStatProgress(string typeName, int defaultValue = 0)
	{
		return 0;
	}

	public int GetAchievementProgress(string typeName, int defaultValue = 0)
	{
		return 0;
	}

	private void UnlockAchievement(eAchievementType type)
	{
	}

	public bool IsAchievementUnlocked(eAchievementType type)
	{
		return false;
	}

	public void RefreshFromSteam()
	{
	}

	public void ResetAchievementForTest(eAchievementType type)
	{
	}

	public void ResetAllAchievementsForTest()
	{
	}

	public void UnlockAllAchievementsForTest()
	{
	}

	private PlayerAchievementStatus GetOrCreateLocalStatus(eAchievementType type)
	{
		return null;
	}

	private static string GetSteamAchievementId(eAchievementType type)
	{
		return null;
	}

	private static string GetSteamStatName(eAchievementType type)
	{
		return null;
	}

	private int GetTargetValue(eAchievementType type)
	{
		return 0;
	}

	private void GetAchievementStatus_Steam()
	{
	}

	private void OnUserStatsReceived(UserStatsReceived_t p)
	{
	}

	private void OnUserStatsStored(UserStatsStored_t p)
	{
	}

	private void OnUserAchievementStored(UserAchievementStored_t p)
	{
	}

	private void UnlockAchievement_Steam(eAchievementType type)
	{
	}

	private void SetStatProgress_Steam(string statName, int value)
	{
	}

	private int GetStatProgress_Steam(string statName, int defaultValue = 0)
	{
		return 0;
	}

	private void SetAchievementProgress_Steam(eAchievementType type, int value, int max)
	{
	}

	private void ShowAchievementProgress_Steam(eAchievementType type, int value, int max)
	{
	}

	private void ResetAchievement_Steam(eAchievementType type)
	{
	}

	private void ResetAllAchievements_Steam()
	{
	}

	public bool RecoverSavefileFromAchievements()
	{
		return false;
	}
}
