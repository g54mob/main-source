using System.Collections;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class DisplayLeaderBoard : SerializedMonoBehaviour
	{
		public int NumberOfEntries;

		public ELeaderBoardMode Filter;

		public GameObject NotConnectedObject;

		private SteamLeaderboard _leaderboard;

		public GameObject LoadingGameObject;

		public LeaderBoardEntryUi EntryPrefab;

		public UIGrid Grid;

		public UIScrollView ScrollView;

		public bool AutonomousLeaderBoard;

		private SteamLeaderboard _autonomousLeaderBoard;

		private bool _isUpdating;

		public bool IsUpdating
		{
			get
			{
				return _isUpdating;
			}
		}

		public void Start()
		{
			_isUpdating = false;
		}

		public void Init(ELeaderboard trackLeaderboard, ELeaderboard autonomousLeaderboard)
		{
			_leaderboard = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(trackLeaderboard);
			_autonomousLeaderBoard = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(autonomousLeaderboard);
			AutonomousLeaderBoard = BaseSingleton<RaceTrackManager>.Instance.Autonomous;
			if (!SteamManager.Connected)
			{
				NotConnectedObject.gameObject.SetActive(true);
			}
			else
			{
				NotConnectedObject.gameObject.SetActive(false);
			}
			StartCoroutine(FirstInit());
		}

		private IEnumerator FirstInit()
		{
			while (_isUpdating)
			{
				yield return true;
			}
			_isUpdating = true;
			SteamLeaderboard lb = (AutonomousLeaderBoard ? _autonomousLeaderBoard : _leaderboard);
			if (lb != null)
			{
				yield return lb.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, 0, 0, false);
				if (lb.LeaderboardEntries.Any())
				{
					Filter = ELeaderBoardMode.User;
				}
				else
				{
					Filter = ELeaderBoardMode.Global;
				}
				_isUpdating = false;
				StartCoroutine(UpdateLeaderBoard());
			}
		}

		public void Update()
		{
			if (SteamManager.Connected)
			{
				NotConnectedObject.gameObject.SetActive(false);
				LoadingGameObject.SetActive(_isUpdating);
			}
			else
			{
				LoadingGameObject.SetActive(false);
				NotConnectedObject.gameObject.SetActive(true);
			}
		}

		public void ToggleFilterMode()
		{
			Filter = ++Filter;
			if (Filter > ELeaderBoardMode.Friends)
			{
				Filter = ELeaderBoardMode.Global;
			}
			StartCoroutine(UpdateLeaderBoard());
		}

		public void ToggleAutonomousMode(bool autonomous)
		{
			AutonomousLeaderBoard = autonomous;
			StartCoroutine(FirstInit());
		}

		public IEnumerator UpdateLeaderBoard()
		{
			while (_isUpdating)
			{
				yield return true;
			}
			if (_isUpdating)
			{
				yield break;
			}
			_isUpdating = true;
			SteamLeaderboard lb = (AutonomousLeaderBoard ? _autonomousLeaderBoard : _leaderboard);
			if (lb != null)
			{
				switch (Filter)
				{
				case ELeaderBoardMode.Global:
					yield return lb.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 1, NumberOfEntries, false);
					break;
				case ELeaderBoardMode.User:
					yield return lb.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, -NumberOfEntries / 2, NumberOfEntries / 2, false);
					break;
				case ELeaderBoardMode.Friends:
					yield return lb.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 1, NumberOfEntries, false);
					break;
				}
				ShowLeaderboardEntries(lb);
			}
			else
			{
				(from Transform child in Grid.transform
					select child.gameObject).ToList().ForEach(Object.DestroyImmediate);
			}
			_isUpdating = false;
		}

		private void ShowLeaderboardEntries(SteamLeaderboard leaderBoard)
		{
			(from Transform child in Grid.transform
				select child.gameObject).ToList().ForEach(Object.DestroyImmediate);
			foreach (LeaderBoardEntry item in leaderBoard.LeaderboardEntries.ToList())
			{
				LeaderBoardEntryUi leaderBoardEntryUi = Object.Instantiate(EntryPrefab);
				leaderBoardEntryUi.transform.position = Grid.transform.position;
				leaderBoardEntryUi.transform.parent = Grid.transform;
				leaderBoardEntryUi.transform.localScale = EntryPrefab.transform.localScale;
				leaderBoardEntryUi.Init(item, leaderBoard);
			}
			Grid.Reposition();
			ScrollView.ResetPosition();
		}
	}
}
