using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LeaderBoard : MonoBehaviour
{
	private class ParsedLeaderboardExtraData_Endless
	{
		public eLeaderboardType LeaderboardType;

		public eCharacterType CharacterType;

		public eEmberType FireSource;

		public int DamageFromMonster;

		public int ZeroDamageCount;

		public int TotalTime;

		public int CoinGain;

		public int CoinSpent;

		public int MaxCoinGain;

		public int RoundsSpent;

		public int TotalKill;

		public int TotalOneShotKill;

		public int TalentCount;

		public int TotalExp;

		public int DateInt;

		public int VersionInt;

		public int Appid;

		public int Validator;

		public List<eItemType> TowerList;

		public List<eItemType> RelicList;

		public ParsedLeaderboardExtraData_Endless(List<int> extraParams)
		{
		}

		private void ParseParams_048(List<int> extraParams)
		{
		}

		private void ParseParams_047(List<int> extraParams)
		{
		}

		public (bool, string) IsValidData(int score)
		{
			return default((bool, string));
		}

		private (bool, string) CheckValid_EndlessModeData(int score)
		{
			return default((bool, string));
		}

		private (bool, string) CheckValid_EnigmaSanctumData(int score)
		{
			return default((bool, string));
		}

		private void PrintDebug(string msg)
		{
		}

		public string ToDebugInfo()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_LoadLeaderboard_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_LeaderBoard _003C_003E4__this;

		public string leaderBoardName;

		public string extraLeaderBoardName;

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
		public _003CCR_LoadLeaderboard_003Ed__30(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_LoadLeaderboard_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_LeaderBoard _003C_003E4__this;

		public string extraLeaderBoardName;

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
		public _003CCR_LoadLeaderboard_003Ed__32(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private int maxEntries;

	[SerializeField]
	private List<UI_Obj_RankingEntry> list_RankingEntries;

	[SerializeField]
	private Transform node_SeparateLine;

	[SerializeField]
	private Transform node_LeaderboardEntries;

	[SerializeField]
	private GameObject prefab_RankingEntry;

	[SerializeField]
	private TMP_Text text_LeaderboardError;

	[SerializeField]
	private TMP_Text text_LeaderboardLoading;

	[SerializeField]
	private TMP_Text text_LeaderboardCharacter;

	[SerializeField]
	private TMP_Text text_Debug_LeaderboardName;

	[SerializeField]
	private ScrollRect scrollView;

	private static List<int> list_PermaBanPlayerIDs;

	private List<eItemType> list_PlayerCurrentTowerLoadout;

	private eLeaderboardType leaderboardType;

	private bool isLoaded;

	private bool isLoadingLeaderboard;

	private string loadingTextCache;

	private string curLeaderboardName;

	private Action onLeaderLoadFinished;

	public bool IsLoaded => false;

	public bool IsLoadingLeaderboard => false;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void ShowLeaderboard(string leaderboardName, string extraLeaderBoardName, eCharacterType characterType, Action OnLeaderLoadFinished = null)
	{
	}

	public void ShowLeaderboard(eLeaderboardType type, string extraLeaderBoardName, eCharacterType characterType, Action OnLeaderLoadFinished = null)
	{
	}

	public void RegisterPlayerCurrentLoadout(List<eItemType> list_TowerType)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LoadLeaderboard_003Ed__30))]
	private IEnumerator CR_LoadLeaderboard(string leaderBoardName, string extraLeaderBoardName)
	{
		return null;
	}

	private void OnEntryScreenshotDownloaded(int entryIndex, Texture2D tex)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LoadLeaderboard_003Ed__32))]
	private IEnumerator CR_LoadLeaderboard(string extraLeaderBoardName)
	{
		return null;
	}

	private void OnPlayerAvatarDownloaded(int id, Texture2D texture)
	{
	}

	private void OnLeaderboardDownloaded(List<LeaderboardEntry_t> list_LeaderboardEntries)
	{
	}

	private void OnLeaderboardDownloadFail()
	{
	}

	private void ClearLeaderboardUI()
	{
	}

	private void UpdateLeaderboardUI()
	{
	}

	private LeaderboardData ProcessLeaderboardData(LeaderboardData data)
	{
		return null;
	}
}
