using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.Races
{
	public class RaceCourseScript : MonoBehaviour
	{
		[SerializeField]
		private GameObject _checkpointPrefab;

		[SerializeField]
		private float _checkpointRestartSpeed;

		private List<RaceCheckpointScript> _checkpoints = new List<RaceCheckpointScript>();

		private Dictionary<int, int> _localPlayerLap = new Dictionary<int, int>();

		private int _numLaps;

		[SerializeField]
		private Transform _pointsParent;

		public float CheckpointRestartSpeed => _checkpointRestartSpeed;

		public int NumCheckpoints => _checkpoints.Count;

		public RaceActivityScript RaceActivity { get; private set; }

		public RaceCheckpointScript GetCheckpoint(int checkpointNumber)
		{
			if (checkpointNumber < 1)
			{
				return null;
			}
			checkpointNumber = (checkpointNumber - 1) % NumCheckpoints;
			if (checkpointNumber >= _checkpoints.Count)
			{
				return null;
			}
			return _checkpoints[checkpointNumber];
		}

		public void InitializeRace(RaceActivityScript raceActivity)
		{
			RaceActivity = raceActivity;
			CreateCheckpoints();
			if (_checkpoints.Count > 0)
			{
				_checkpoints[0].State = RaceCheckpointScript.CheckpointState.Next;
				_checkpoints[1].State = RaceCheckpointScript.CheckpointState.SecondNext;
			}
		}

		public void OnCheckpointHitByLocalPlayer(AircraftScript craft, RaceCheckpointScript checkpoint)
		{
			RaceActivityScript raceActivity = RaceActivity;
			if ((object)raceActivity == null || raceActivity.State != NetworkedActivityState.Started)
			{
				return;
			}
			NetworkPlayerScript networkPlayer = craft.NetworkAircraft.Player.NetworkPlayer;
			if (!_localPlayerLap.ContainsKey(networkPlayer.PlayerId))
			{
				_localPlayerLap[networkPlayer.PlayerId] = 1;
			}
			int num = _localPlayerLap[networkPlayer.PlayerId];
			if (num > _numLaps)
			{
				return;
			}
			int totalCheckpointsPassed = (num - 1) * NumCheckpoints + checkpoint.CheckpointNumber;
			if (!RaceActivity.PlayerPassedCheckpoint(networkPlayer, totalCheckpointsPassed))
			{
				return;
			}
			bool flag = checkpoint.CheckpointNumber == NumCheckpoints;
			if (flag && num < _numLaps)
			{
				_localPlayerLap[networkPlayer.PlayerId]++;
			}
			if (!craft.IsPrimaryLocalPlayer)
			{
				return;
			}
			checkpoint.State = RaceCheckpointScript.CheckpointState.Passed;
			RaceCheckpointScript raceCheckpointScript = FindPreviousCheckpoint(checkpoint);
			if (raceCheckpointScript != null)
			{
				raceCheckpointScript.State = RaceCheckpointScript.CheckpointState.Inactive;
			}
			if (flag && num < _numLaps)
			{
				ResetCheckpointsForNewLap();
				RaceCheckpointScript raceCheckpointScript2 = _checkpoints[0];
				raceCheckpointScript2.State = RaceCheckpointScript.CheckpointState.Next;
				RaceCheckpointScript raceCheckpointScript3 = FindNextCheckpoint(raceCheckpointScript2);
				if (raceCheckpointScript3 != null)
				{
					raceCheckpointScript3.State = RaceCheckpointScript.CheckpointState.SecondNext;
				}
			}
			else
			{
				if (flag && num >= _numLaps)
				{
					return;
				}
				RaceCheckpointScript raceCheckpointScript4 = FindNextCheckpoint(checkpoint);
				if (raceCheckpointScript4 != null)
				{
					raceCheckpointScript4.State = RaceCheckpointScript.CheckpointState.Next;
					RaceCheckpointScript raceCheckpointScript5 = FindNextCheckpoint(raceCheckpointScript4);
					if (raceCheckpointScript5 != null)
					{
						raceCheckpointScript5.State = RaceCheckpointScript.CheckpointState.SecondNext;
					}
				}
			}
		}

		public void ShowCheckpointMessage(NetworkedActivityPlayer player, bool multiplayer, float finalTime, float checkpointTime, int totalCheckpoints, float skippedCheckpointsPenalty, int currentLap)
		{
			Game.Instance.UserInterface.Sound.PlaySound(UISound.RingPassed);
			int num = totalCheckpoints % NumCheckpoints;
			string empty = string.Empty;
			string text = "#{Place}";
			if (finalTime > 0f)
			{
				empty = "Final Time: {FinalTime}";
				if (skippedCheckpointsPenalty > 0f)
				{
					empty += "      Skipped Checkpoints Penalty: +{SkippedCheckpointsPenalty}s";
				}
			}
			else if (num == 0 && currentLap > 1)
			{
				empty = "Lap {Lap}/{NumLaps}";
			}
			else if (checkpointTime > 0f)
			{
				empty = "Checkpoint {Checkpoint}/{NumCheckpoints}";
				text = "#{Place}+{CheckpointTime}";
			}
			else
			{
				empty = "Checkpoint {Checkpoint}/{NumCheckpoints}";
			}
			if (multiplayer)
			{
				empty = text + "      " + empty;
			}
			string message = empty.Replace("{FinalTime}", RaceActivityScript.FormatTime(finalTime, 2)).Replace("{CheckpointTime}", RaceActivityScript.FormatTime(checkpointTime, 2)).Replace("{Lap}", currentLap.ToString())
				.Replace("{NumLaps}", _numLaps.ToString())
				.Replace("{Checkpoint}", num.ToString())
				.Replace("{NumCheckpoints}", NumCheckpoints.ToString())
				.Replace("{SkippedCheckpointsPenalty}", ((int)skippedCheckpointsPenalty).ToString())
				.Replace("{Place}", RaceActivity.LocalPlayer.LeaderboardPlaceNumber.ToString());
			FlightSceneScript.Instance.FlightUI.ShowMessage(message);
		}

		public void StartRace(int numLaps)
		{
			_numLaps = numLaps;
		}

		private void CreateCheckpoints()
		{
			int num = 1;
			foreach (Transform item in _pointsParent)
			{
				GameObject obj = Object.Instantiate(_checkpointPrefab);
				obj.transform.SetParent(item, worldPositionStays: false);
				obj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				RaceCheckpointScript componentInChildren = obj.GetComponentInChildren<RaceCheckpointScript>();
				_checkpoints.Add(componentInChildren);
				RaceCheckpointDataScript component;
				RaceCheckpointDataScript checkPointData = (item.TryGetComponent<RaceCheckpointDataScript>(out component) ? component : null);
				componentInChildren.InitializeRace(this, checkPointData, num++);
			}
		}

		private RaceCheckpointScript FindNextCheckpoint(RaceCheckpointScript checkpoint)
		{
			if (checkpoint == null)
			{
				return _checkpoints[0];
			}
			int checkpointNumber = checkpoint.CheckpointNumber;
			if (checkpointNumber < _checkpoints.Count)
			{
				return _checkpoints[checkpointNumber];
			}
			return null;
		}

		private RaceCheckpointScript FindPreviousCheckpoint(RaceCheckpointScript checkpoint)
		{
			if (checkpoint == null)
			{
				return null;
			}
			int num = checkpoint.CheckpointNumber - 2;
			if (num >= 0)
			{
				return _checkpoints[num];
			}
			return null;
		}

		private void ResetCheckpointsForNewLap()
		{
			foreach (RaceCheckpointScript checkpoint in _checkpoints)
			{
				checkpoint.State = RaceCheckpointScript.CheckpointState.Inactive;
			}
		}
	}
}
