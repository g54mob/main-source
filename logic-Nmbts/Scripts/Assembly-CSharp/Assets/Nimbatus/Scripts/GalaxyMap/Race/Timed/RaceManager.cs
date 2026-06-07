using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.MiniMap;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using I2.Loc;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Timed
{
	public class RaceManager : BaseRaceManager
	{
		[Header("Race Manager")]
		public NimbatusDrone PlayerDrone;

		public UILabel WinImprovementDisplay;

		public UILabel HighscoreDisplay;

		public TimeSlider TimeSlider;

		private RaceTrack _trackInstance;

		private List<RaceCheckpoint> _checkpoints = new List<RaceCheckpoint>();

		private int _checkpointIndex;

		private RaceCheckpoint _nextCheckpoint;

		public void Start()
		{
			if (BaseSingleton<RaceTrackManager>.Instance.SelectedTrack != null)
			{
				_trackInstance = Object.Instantiate(BaseSingleton<RaceTrackManager>.Instance.SelectedTrack, BaseSingleton<RaceTrackManager>.Instance.SelectedTrack.transform.position, BaseSingleton<RaceTrackManager>.Instance.SelectedTrack.transform.rotation);
				if (_trackInstance.OverrideMusic)
				{
					MusicLoop = _trackInstance.MusicLoop;
				}
				_checkpoints = _trackInstance.Checkpoints;
				WorldController.TerrainSettings.AirResistance = _trackInstance.AirResistance;
				WorldController.TerrainSettings.Gravity = _trackInstance.Gravity;
				PlayerDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0));
				PlayerDrone.RootDronePart.ValidateDroneRecursive();
				if (RuntimeGlobals.Camera != null)
				{
					RuntimeGlobals.Camera.FocusTarget = true;
					RuntimeGlobals.Camera.AddPlayer(PlayerDrone.RootDronePart.transform, true, false, true);
				}
				BaseSingleton<RaceMinimap>.Instance.Init(PlayerDrone);
				if (!SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions().OfType<RaceTrackRequirements>().Any())
				{
					PlayerDrone.TrackerManager.Init(PlayerDrone, _trackInstance.MainSpline);
				}
				TimeSlider.gameObject.SetActive(BaseSingleton<RaceTrackManager>.Instance.Autonomous);
				StartCoroutine(InitRace());
			}
			else
			{
				Debug.LogError("No RaceTrack assigned");
			}
		}

		public override void WakeUp()
		{
			PlayerDrone.ActivatePhysics();
		}

		private IEnumerator InitRace()
		{
			if (_checkpoints.Count > 0)
			{
				_checkpoints.ForEach(delegate(RaceCheckpoint c)
				{
					c.Init(this);
				});
				_nextCheckpoint = _checkpoints[_checkpointIndex];
			}
			while (!PlayerDrone.RootDronePart.HealthPool.IsDead)
			{
				yield return null;
			}
			FinishRace(PlayerDrone, false, true);
		}

		public void ClearCheckpoint(RaceCheckpoint check, Collider other)
		{
			if (_nextCheckpoint != null && check == _nextCheckpoint && other.gameObject == PlayerDrone.RootDronePart.gameObject)
			{
				check.Cross();
				if (_checkpointIndex + 1 < _checkpoints.Count)
				{
					_checkpointIndex++;
					_nextCheckpoint = _checkpoints[_checkpointIndex];
				}
				else
				{
					FinishRace(PlayerDrone, true, true);
				}
			}
		}

		public override void OnRaceEnded(NimbatusDrone drone, bool success)
		{
			if (success && drone == PlayerDrone && SteamManager.Connected)
			{
				StartCoroutine(UploadHighscore());
			}
		}

		private IEnumerator UploadHighscore()
		{
			int newScore = (int)(CurrentTime * 1000f);
			SteamLeaderboard lb = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(BaseSingleton<RaceTrackManager>.Instance.SelectedTrack.Leaderboard);
			if (BaseSingleton<RaceTrackManager>.Instance.Autonomous)
			{
				lb = SerializableMonobehaviour<LeaderBoardManager, LeaderBoardData>.Instance.GetLeaderboard(BaseSingleton<RaceTrackManager>.Instance.SelectedTrack.AutonomousLeaderboard);
			}
			yield return lb.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 0, 0, false);
			LeaderBoardEntry leaderBoardEntry = lb.LeaderboardEntries.FirstOrDefault();
			if (leaderBoardEntry != null)
			{
				float myFloat = (float)Mathf.Abs(leaderBoardEntry.Score - newScore) / 1000f;
				if (leaderBoardEntry.Score > newScore)
				{
					WinImprovementDisplay.text = LocalizationManager.GetTermTranslation("Racing/NewBest:") + " " + LabelHelper.Green + "-" + myFloat.ToTimeString();
					HighscoreDisplay.text = LocalizationManager.GetTermTranslation("Racing/UploadingScore");
					yield return lb.AddScore(newScore);
					yield return lb.UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 0, 0, false);
					LeaderBoardEntry leaderBoardEntry2 = lb.LeaderboardEntries.FirstOrDefault();
					if (leaderBoardEntry2 != null)
					{
						HighscoreDisplay.text = LocalizationManager.GetTermTranslation("Racing/NewRank") + " " + LabelHelper.Orange + leaderBoardEntry2.Rank;
					}
				}
				else
				{
					WinImprovementDisplay.text = LocalizationManager.GetTermTranslation("Racing/Slower") + " " + LabelHelper.Red + " + " + myFloat.ToTimeString();
				}
			}
			else
			{
				WinImprovementDisplay.text = LabelHelper.Green + LocalizationManager.GetTermTranslation("Racing/NewBest!");
				yield return lb.AddScore(newScore);
			}
		}
	}
}
