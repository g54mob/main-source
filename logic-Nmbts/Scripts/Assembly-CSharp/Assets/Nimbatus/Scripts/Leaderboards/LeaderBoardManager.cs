using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class LeaderBoardManager : SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>
	{
		private Dictionary<ELeaderboard, SteamLeaderboard> _leaderBoards;

		private bool _leaderBoardsCreated;

		public static bool Initialized;

		internal override string Filename
		{
			get
			{
				return "Leaderboards.xml";
			}
		}

		public SteamLeaderboard GetLeaderboard(ELeaderboard lType)
		{
			if (_leaderBoards.ContainsKey(lType))
			{
				return _leaderBoards[lType];
			}
			return null;
		}

		protected void Start()
		{
			_leaderBoards = new Dictionary<ELeaderboard, SteamLeaderboard>();
			_leaderBoardsCreated = false;
		}

		protected void Update()
		{
			if (!_leaderBoardsCreated && SteamManager.Initialized)
			{
				StartCoroutine(CreateLeaderboards());
				_leaderBoardsCreated = true;
			}
		}

		private IEnumerator CreateLeaderboards()
		{
			yield return CreateLeaderBoard(ELeaderboard.SumoArenaTournament, "Sumo Tournament 0.5.0", ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			yield return CreateLeaderBoard(ELeaderboard.RaceArenaTournament, "Catch Tournament", ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrackTournament, "Racing Tournament", ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			yield return CreateLeaderBoard(ELeaderboard.CombatArenaTournament, "Combat Arena Tournament", ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrack1, "Cygnus Manual", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrack2, "Hydrus Manual", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrack3, "Phoenix Manual", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrack1Autonomous, "Cygnus Autonomous", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrack2Autonomous, "Hydrus Autonomous", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.RaceTrack3Autonomous, "Phoenix Autonomous", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.SagittariusRaceTrackManual, "Sagittarius Manual", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.SagittariusRaceTrackAutonomous, "Sagittarius Autonomous", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.PiscesRaceTrackManual, "Pisces Manual", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			yield return CreateLeaderBoard(ELeaderboard.PiscesRaceTrackAutonomous, "Pisces Autonomous", ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeTimeMilliSeconds);
			Initialized = true;
		}

		private IEnumerator CreateLeaderBoard(ELeaderboard lType, string leaderBoardName, ELeaderboardSortMethod sorting, ELeaderboardDisplayType displayType)
		{
			GameObject obj = new GameObject();
			obj.transform.parent = base.transform;
			SteamLeaderboard steamLeaderboard = obj.AddComponent<SteamLeaderboard>();
			steamLeaderboard.DisplayType = displayType;
			steamLeaderboard.SortMethod = sorting;
			steamLeaderboard.LeaderBoardName = leaderBoardName;
			steamLeaderboard.LeaderboardType = lType;
			_leaderBoards.Add(lType, steamLeaderboard);
			yield return steamLeaderboard.Initialize();
		}

		protected override void LoadFromFile(LeaderBoardData data)
		{
		}

		protected override LeaderBoardData SaveToFile()
		{
			return new LeaderBoardData();
		}
	}
}
