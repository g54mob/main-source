using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class DisplayTrainingDrones : MonoBehaviour
	{
		public TrainingDroneDisplay Prefab;

		public List<TrainingDroneDisplay> DroneDisplays;

		public GameObject LoadingDisplay;

		public static ETrainingDifficulty ActiveDifficulty;

		private static List<TrainingDrone> _trainingDrones;

		private static ETournamentType _lastTournamentMode;

		public void FillUpItems(List<TrainingDrone> leaderBoardList)
		{
			DroneDisplays.ForEach(delegate(TrainingDroneDisplay dp)
			{
				dp.gameObject.SetActive(false);
			});
			int num = Mathf.Min(DroneDisplays.Count, leaderBoardList.Count);
			for (int num2 = 0; num2 < num; num2++)
			{
				TrainingDrone drone = leaderBoardList[num2];
				TrainingDroneDisplay trainingDroneDisplay = DroneDisplays[num2];
				trainingDroneDisplay.gameObject.SetActive(true);
				trainingDroneDisplay.Init(drone);
			}
			LoadingDisplay.gameObject.SetActive(false);
		}

		public void OnEnable()
		{
			DroneDisplays.ForEach(delegate(TrainingDroneDisplay dp)
			{
				dp.gameObject.SetActive(false);
			});
			if (_trainingDrones != null && _lastTournamentMode == GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.TournamentType)
			{
				FillUpItems(_trainingDrones);
			}
			else
			{
				UpdateDrones();
			}
		}

		public void UpdateDrones()
		{
			LoadingDisplay.gameObject.SetActive(true);
			StartCoroutine(FetchDrones());
		}

		public IEnumerator FetchDrones()
		{
			System.Random rnd = new System.Random();
			List<TrainingDrone> resultList = new List<TrainingDrone>();
			if (SteamManager.Connected && SteamManager.Initialized)
			{
				SteamLeaderboard leaderboard = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.LeaderBoard);
				if (leaderboard != null)
				{
					yield return leaderboard.Initialize();
					int maxEntryCount = leaderboard.GetMaxEntryCount();
					if (maxEntryCount > 0)
					{
						int num = 1;
						int val = maxEntryCount;
						bool flag = false;
						switch (ActiveDifficulty)
						{
						case ETrainingDifficulty.Hard:
							num = rnd.Next((int)((float)maxEntryCount * 0.2f));
							val = num + DroneDisplays.Count + 3;
							break;
						case ETrainingDifficulty.Medium:
							num = rnd.Next((int)((float)maxEntryCount * 0.2f), (int)((float)maxEntryCount * 0.4f));
							val = num + DroneDisplays.Count + 3;
							break;
						case ETrainingDifficulty.Easy:
							num = rnd.Next((int)((float)maxEntryCount * 0.4f), maxEntryCount);
							val = num + DroneDisplays.Count + 3;
							break;
						case ETrainingDifficulty.Friends:
							num = rnd.Next(maxEntryCount);
							val = num + DroneDisplays.Count + 3;
							flag = true;
							break;
						}
						num = Math.Max(1, num);
						val = Math.Min(maxEntryCount, val);
						if (!flag)
						{
							yield return leaderboard.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, num, val, true);
						}
						else
						{
							yield return leaderboard.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, num, val, true);
						}
						List<LeaderBoardEntry> list = leaderboard.LeaderboardEntries.ToList();
						list.Shuffle(rnd);
						int num2 = 0;
						foreach (LeaderBoardEntry item in list)
						{
							try
							{
								int score = item.Score;
								DroneData opponentDrone = DroneData.LoadFromBytes(item.Attachement);
								SteamFriends.RequestUserInformation(new CSteamID(item.UserId), false);
								if (opponentDrone.IsCompatible() && SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions().TrueForAll((DronePrecondition p) => p.Check(opponentDrone)))
								{
									resultList.Add(new TrainingDrone(opponentDrone, score));
									num2++;
								}
								if (num2 >= DroneDisplays.Count)
								{
									break;
								}
							}
							catch (Exception exception)
							{
								Debug.LogException(exception);
							}
						}
					}
				}
			}
			List<DefaultDrone> defaultDrones = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetDefaultDrones(GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.DefaultDroneType, ActiveDifficulty);
			defaultDrones.Shuffle(rnd);
			if (defaultDrones.Count > 0)
			{
				while (resultList.Count < DroneDisplays.Count)
				{
					foreach (DefaultDrone item2 in defaultDrones)
					{
						if (resultList.Count < DroneDisplays.Count)
						{
							DroneData drone = DroneData.LoadFromBytes(item2.DroneBytes);
							resultList.Add(new TrainingDrone(drone, 0));
							continue;
						}
						break;
					}
				}
			}
			_trainingDrones = resultList;
			_lastTournamentMode = GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.Settings.TournamentType;
			FillUpItems(resultList);
		}
	}
}
