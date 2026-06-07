using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments
{
	[Serializable]
	public class Tournament
	{
		private DroneData _currentDrone;

		private float _lastUploadTime;

		private BackgroundWorker _scoreUploadWorker;

		private static byte[] _droneDataToUpload;

		private static int _scoreToUpload;

		private SteamLeaderboard _leaderboard;

		private SteamLeaderboard _masterLeaderboard;

		private DroneSettings _droneSettings;

		private DroneSettings _trainingSettings;

		private bool _uploadScore;

		public List<ulong> PreviousOpponents { get; set; }

		public int CurrentScore { get; set; }

		public int LossAmount { get; set; }

		public bool TournamentRunning { get; set; }

		public ulong CurrentEnemyId { get; set; }

		public TournamentStatistics LastTournamentStatistics { get; set; }

		public byte[] CurrentDroneData { get; set; }

		public TournamentSetting Settings { get; set; }

		public DroneSettings GetDroneSettings()
		{
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				return _trainingSettings;
			}
			return _droneSettings;
		}

		public void Init(TournamentSettingObject settings)
		{
			Settings = settings.Settings;
			_droneSettings = settings.DroneSettings.Settings;
			_trainingSettings = settings.TrainingDroneSettings.Settings;
			LastTournamentStatistics = new TournamentStatistics();
			_scoreUploadWorker = new BackgroundWorker();
			_scoreUploadWorker.DoWork += UploadScore;
		}

		public void PostLoad()
		{
			if (CurrentDroneData != null)
			{
				try
				{
					_currentDrone = DroneData.LoadFromBytes(CurrentDroneData);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					_currentDrone = null;
					TournamentRunning = false;
				}
			}
		}

		public void LoadFrom(Tournament savedTournament)
		{
			PreviousOpponents = savedTournament.PreviousOpponents;
			CurrentDroneData = savedTournament.CurrentDroneData;
			CurrentScore = savedTournament.CurrentScore;
			LossAmount = savedTournament.LossAmount;
			TournamentRunning = savedTournament.TournamentRunning;
			CurrentEnemyId = savedTournament.CurrentEnemyId;
			LastTournamentStatistics = savedTournament.LastTournamentStatistics;
		}

		public IEnumerator StartTournament(DroneData drone)
		{
			TournamentRunning = true;
			_leaderboard = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(Settings.LeaderBoard);
			CurrentDroneData = drone.SaveToBytes();
			_currentDrone = DroneData.LoadFromBytes(CurrentDroneData);
			CurrentScore = 0;
			LossAmount = 0;
			CurrentEnemyId = 0uL;
			LastTournamentStatistics.Reset();
			LastTournamentStatistics.InitDrone(drone);
			PreviousOpponents = new List<ulong>();
			yield return FindOpponentAndStart();
		}

		public IEnumerator StopTournament(bool uploadScore = true)
		{
			try
			{
				_droneDataToUpload = CurrentDroneData;
				_scoreToUpload = CurrentScore;
				_uploadScore = uploadScore;
				if (_lastUploadTime + 60f < Time.time && !SteamManager.ModsActive)
				{
					_lastUploadTime = Time.time;
					_scoreUploadWorker.RunWorkerAsync();
				}
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
			finally
			{
				_currentDrone = null;
				TournamentRunning = false;
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ResetActiveDrone(0);
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ResetActiveDrone(1);
			}
			yield return true;
		}

		public bool HasFinished()
		{
			if (LossAmount < Settings.NumberOfLosses)
			{
				return CurrentScore >= Settings.NumberOfWins;
			}
			return true;
		}

		public bool IsTournamentRunning()
		{
			return TournamentRunning;
		}

		public DroneData GetCurrentDrone()
		{
			return _currentDrone;
		}

		public void IncreaseScore()
		{
			CurrentScore++;
			PreviousOpponents.Add(CurrentEnemyId);
			if (CurrentScore >= Settings.NumberOfWins)
			{
				switch (Settings.TournamentType)
				{
				case ETournamentType.SumoTournament:
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.SumoTournamentWon);
					break;
				case ETournamentType.CombatTournament:
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.BrawlTournamentWon);
					break;
				case ETournamentType.RaceArenaTournament:
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.CatchPro);
					break;
				case ETournamentType.RaceTrackTournament:
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.SpeedDemon);
					break;
				}
			}
		}

		public void IncreaseLoss()
		{
			LossAmount++;
			PreviousOpponents.Add(CurrentEnemyId);
		}

		public int GetCurrentScore()
		{
			return CurrentScore;
		}

		public int GetLossAmount()
		{
			return LossAmount;
		}

		private void UploadScore(object sender, DoWorkEventArgs doWorkEventArgs)
		{
			_leaderboard = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(Settings.LeaderBoard);
			if (!Settings.DisableUpload && _leaderboard != null)
			{
				WaitFor(_leaderboard.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, 0, 0, false));
				if (_scoreToUpload > 0 && _uploadScore)
				{
					WaitFor(_leaderboard.AddScoreWithAttachement(_scoreToUpload, _droneDataToUpload, "SumoDrone", true));
				}
			}
		}

		public IEnumerator FindOpponentAndStart()
		{
			_leaderboard = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(Settings.LeaderBoard);
			_currentDrone = DroneData.LoadFromBytes(CurrentDroneData);
			ETrainingDifficulty difficulty = ETrainingDifficulty.Medium;
			if (CurrentScore < 3)
			{
				difficulty = ETrainingDifficulty.Easy;
			}
			else if (CurrentScore < 6)
			{
				difficulty = ETrainingDifficulty.Medium;
			}
			else
			{
				difficulty = ETrainingDifficulty.Hard;
			}
			List<int> source = (from drone in SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DefaultDrones
				where drone.DroneType == Settings.DefaultDroneType && drone.Difficulty == difficulty
				select SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DefaultDrones.IndexOf(drone)).ToList();
			List<int> list = (from drone in SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DefaultDrones
				where drone.DroneType == Settings.DefaultDroneType
				select SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DefaultDrones.IndexOf(drone)).ToList();
			List<int> list2 = source.Where((int i) => !PreviousOpponents.Contains((ulong)i)).ToList();
			if (list2.Any())
			{
				CurrentEnemyId = (ulong)list2.RandomItem();
			}
			else
			{
				CurrentEnemyId = (ulong)list.RandomItem();
			}
			DroneData opponentDrone = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.LoadDefaultDrone((int)CurrentEnemyId);
			if (_leaderboard != null && SteamManager.Connected)
			{
				yield return _leaderboard.Initialize();
				int percentStart = CurrentScore * 10;
				int percentEnd = (CurrentScore + 1) * 10;
				if (_leaderboard.GetMaxEntryCount() > 200)
				{
					percentStart = 50 + CurrentScore * 5;
					percentEnd = 50 + (CurrentScore + 1) * 5;
				}
				yield return _leaderboard.UpdateEntriesFromPercentRange(percentStart, percentEnd, true);
				List<LeaderBoardEntry> list3 = _leaderboard.LeaderboardEntries.Where((LeaderBoardEntry e) => e.UserId != SteamUser.GetSteamID().m_SteamID && !PreviousOpponents.Contains(e.UserId)).ToList();
				list3.Shuffle(new System.Random());
				bool flag = false;
				foreach (LeaderBoardEntry item in list3)
				{
					try
					{
						opponentDrone = DroneData.LoadFromBytes(item.Attachement);
						if (opponentDrone.IsCompatible() && SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions().TrueForAll((DronePrecondition p) => p.Check(opponentDrone)))
						{
							CurrentEnemyId = item.UserId;
							SteamFriends.RequestUserInformation(new CSteamID(CurrentEnemyId), false);
							flag = true;
							break;
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				if (!flag)
				{
					opponentDrone = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.LoadDefaultDrone((int)CurrentEnemyId);
				}
			}
			opponentDrone.IsOpponentDrone = true;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(_currentDrone, 0);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(opponentDrone, 1);
		}

		private void WaitFor(IEnumerator enumerator)
		{
			while (enumerator.MoveNext())
			{
				Thread.Sleep(1);
			}
		}
	}
}
