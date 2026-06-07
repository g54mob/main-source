using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.UI.Activity;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.Races
{
	public class RaceActivityScript : NetworkedActivityScript
	{
		private class PlayerRaceStatus
		{
			public float CheckpointTime { get; set; }

			public int CurrentLap { get; set; } = 1;

			public float CurrentPenalty { get; set; }

			public float FinalTime { get; set; }

			public int NumCheckpointsSkipped { get; set; }

			public float RelativeCheckpointTime { get; set; }

			public int TotalCheckpointsPassed { get; set; }
		}

		private const string CheckpointScoreId = "Checkpoint";

		private const string FinalScoreId = "Final";

		private List<float> _bestCheckpointTimes = new List<float> { 0f };

		private float _checkpointSkipPenalty = 15f;

		private RaceCourseScript _course;

		private bool _createdEndTimeScoreColumn;

		private int _currentLap = 1;

		private float _endRaceTime;

		private bool _endRequested;

		private float _finalTime;

		private int _lastDisplayLaps;

		private Dictionary<int, int> _localPlayerCheckpoint = new Dictionary<int, int>();

		private float _maxTime;

		private float _maxTimeAfterFirstWinner;

		private Dictionary<int, PlayerRaceStatus> _playerStatuses = new Dictionary<int, PlayerRaceStatus>();

		private int _primaryPlayerCheckpointNumber;

		private float _serverMaxTime;

		private bool _showLaps;

		[SerializeField]
		private AudioSource _soundPassRing;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ERaces_002ERaceActivityScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ERaces_002ERaceActivityScriptGame_002Edll_Excuted;

		public override bool CraftsStartPaused => true;

		public override NetworkedActivityTeamIds JoinableTeams => NetworkedActivityTeamIds.Team1;

		public override string Subtitle => $"{NumLaps} lap(s)";

		protected override bool PlayerFinishedActivity => _finalTime > 0f;

		private int NumLaps => base.Data.Settings.GetValueInt("NumLaps", 1);

		public static string FormatTime(float time, int decimalPoints = 0)
		{
			time = Mathf.Max(time, 0f);
			int num = (int)time / 60;
			float num2 = time % 60f;
			if (decimalPoints == 0 || num > 0)
			{
				return num + ":" + num2.ToString("00." + new string('0', decimalPoints));
			}
			return num2.ToString($"n{decimalPoints}");
		}

		public override void CreateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			base.CreateScoreSummaryWidget(scoreSummary);
			if (NumLaps > 1)
			{
				_showLaps = true;
				scoreSummary.CreateScoreColumn("laps", "score-lap");
			}
		}

		public override string GetPlayerScoreString(NetworkedActivityPlayer player)
		{
			float? num = player?.GetScore("Final")?.ValueFloat;
			if (num.HasValue && num > 0f)
			{
				return FormatTime(num.Value, 2) ?? "";
			}
			if (base.Players.Count > 1)
			{
				return GetRelativeCheckpointTimeScore(player);
			}
			if (_course != null)
			{
				return $"{_primaryPlayerCheckpointNumber % _course.NumCheckpoints}/{_course.NumCheckpoints}";
			}
			return "GO!";
		}

		public bool PlayerPassedCheckpoint(NetworkPlayerScript player, int totalCheckpointsPassed)
		{
			if (!_localPlayerCheckpoint.ContainsKey(player.PlayerId))
			{
				_localPlayerCheckpoint[player.PlayerId] = 0;
			}
			int num = _localPlayerCheckpoint[player.PlayerId];
			if (totalCheckpointsPassed > num && totalCheckpointsPassed - num <= 3)
			{
				_localPlayerCheckpoint[player.PlayerId] = totalCheckpointsPassed;
				PlayerPassedCheckpointServer(player.PlayerId, totalCheckpointsPassed, base.LocalConnection);
				if (player.IsPrimaryLocal)
				{
					_primaryPlayerCheckpointNumber = totalCheckpointsPassed;
				}
				return true;
			}
			return false;
		}

		public override void UpdateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			float valueFloat = base.LocalPlayer.GetScore("Final").ValueFloat;
			string text;
			string text2;
			if (valueFloat > 0f)
			{
				text = FormatTime(valueFloat, 2);
				text2 = string.Empty;
			}
			else
			{
				text = FormatTime(((float?)base.TimerValue) ?? 0f);
				text2 = GetPlayerScoreString(base.LocalPlayer);
			}
			scoreSummary.SetText("left", text);
			scoreSummary.SetText("right", text2);
			if (_showLaps && _lastDisplayLaps != _currentLap)
			{
				_lastDisplayLaps = _currentLap;
				scoreSummary.SetText("laps", $"<size=80%>LAP\n<size=100%>{_currentLap}/{NumLaps}");
			}
			if (_endRaceTime > 0f)
			{
				if (!_createdEndTimeScoreColumn)
				{
					_createdEndTimeScoreColumn = true;
					scoreSummary.CreateScoreColumn("countdown", "score-countdown");
				}
				float time = Mathf.Max(0f, _endRaceTime - (float)base.TimerValue.GetValueOrDefault());
				scoreSummary.SetText("countdown", "ENDING\n" + FormatTime(time));
			}
		}

		protected override int CompareScores(NetworkedActivityPlayer x, NetworkedActivityPlayer y)
		{
			float valueFloat = x.GetScore("Final").ValueFloat;
			float valueFloat2 = y.GetScore("Final").ValueFloat;
			float valueFloat3 = x.GetScore("Checkpoint").ValueFloat;
			float valueFloat4 = y.GetScore("Checkpoint").ValueFloat;
			if ((valueFloat < valueFloat2 && valueFloat > 0f) || (valueFloat > 0f && valueFloat2 == 0f))
			{
				return 1;
			}
			if ((valueFloat2 < valueFloat && valueFloat2 > 0f) || (valueFloat2 > 0f && valueFloat == 0f))
			{
				return -1;
			}
			if (valueFloat3 < valueFloat4 || (valueFloat3 != 0f && valueFloat4 == 0f))
			{
				return 1;
			}
			if (valueFloat4 < valueFloat3 || (valueFloat4 != 0f && valueFloat3 == 0f))
			{
				return -1;
			}
			return 0;
		}

		protected override IEnumerable<NetworkedActivityScore> CreateScoresForPlayer(NetworkedActivityPlayer player)
		{
			yield return new NetworkedActivityScore("Final", "Final", NetworkedActivityScore.ScoreValueType.Float);
			yield return new NetworkedActivityScore("Checkpoint", "Checkpoint", NetworkedActivityScore.ScoreValueType.Float);
		}

		protected override void CreateTeamStartingLocationGameObjects()
		{
			base.CreateTeamStartingLocationGameObjects();
			CreateCourse();
			_course.gameObject.SetActive(value: false);
		}

		protected override StartLocationData GetPlayerSpawnLocation(NetworkedActivityPlayer player, bool initialSpawn, CraftLocalBounds? bounds)
		{
			if (_playerStatuses.TryGetValue(player.PlayerId, out var value))
			{
				RaceCheckpointScript raceCheckpointScript = _course?.GetCheckpoint(value.TotalCheckpointsPassed);
				if (raceCheckpointScript != null)
				{
					Transform restartPosition = raceCheckpointScript.RestartPosition;
					string text = $"{base.Data.DisplayName} - Checkpoint {value.TotalCheckpointsPassed}";
					return new StartLocationData(text, text, null, StartLocationType.Temp, Utility.ConvertFloatingOriginToAbsolutePosition(restartPosition.position), restartPosition.rotation.eulerAngles, restartPosition.forward * _course.CheckpointRestartSpeed, !(base.Data.Category == "Air Races"));
				}
			}
			return base.GetPlayerSpawnLocation(player, initialSpawn, bounds);
		}

		protected override NetworkedActivityTeamType GetTeamType(NetworkedActivityTeamIds teamId)
		{
			return NetworkedActivityTeamType.TeamPerPlayerNeutral;
		}

		protected override void OnActivityEndedClient()
		{
			base.OnActivityEndedClient();
			if (_course != null)
			{
				_course.gameObject.SetActive(value: false);
			}
		}

		protected override void OnActivityEndedServer()
		{
			base.OnActivityEndedServer();
		}

		protected override void OnActivityStartedClient()
		{
			base.OnActivityStartedClient();
			if (base.IsActivityHost)
			{
				_maxTime = base.Data.XmlData.GetIntAttribute("maxTime", int.MaxValue);
				_maxTimeAfterFirstWinner = base.Data.XmlData.GetFloatAttribute("maxTimeAfterFirstWinner", 0.1f);
				StartTimer(-3, ActivityTimerType.CountUp);
			}
		}

		protected override void OnLocalPlayerEnded(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerEnded(player);
			if (!player.IsAI && _course != null)
			{
				_course.gameObject.SetActive(value: false);
			}
		}

		protected override void OnLocalPlayerStarted(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerStarted(player);
			if (!player.IsAI)
			{
				_course.StartRace(NumLaps);
				_course.gameObject.SetActive(value: true);
			}
		}

		protected override void OnPlayerLeft(NetworkedActivityPlayer player)
		{
			base.OnPlayerLeft(player);
			if (base.IsServerStarted)
			{
				if (_playerStatuses.ContainsKey(player.PlayerId))
				{
					_playerStatuses.Remove(player.PlayerId);
				}
				if ((int)base.State >= 4)
				{
					UpdateRelativeCheckpointScores();
				}
			}
		}

		protected override void OnPlayerStarted(NetworkedActivityPlayer player)
		{
			base.OnPlayerStarted(player);
			_playerStatuses[player.PlayerId] = new PlayerRaceStatus();
		}

		protected override void OnStateChanged(NetworkedActivityState previousState, NetworkedActivityState newState)
		{
			base.OnStateChanged(previousState, newState);
			_ = 5;
		}

		protected override void OnTimerChangedClient(int timerValue)
		{
			base.OnTimerChangedClient(timerValue);
			if ((base.IsActivityHost && (float)timerValue >= _maxTime && _maxTime > 0f) || (base.IsServerStarted && (float)timerValue >= _serverMaxTime && _serverMaxTime > 0f))
			{
				StopTimer();
				if (!_endRequested)
				{
					StartCoroutine(EndActivityDelayed(0f));
				}
			}
		}

		protected override bool UseInitialSpawnLocationForPlayer(NetworkedActivityPlayer player)
		{
			if (!base.UseInitialSpawnLocationForPlayer(player))
			{
				return !base.StartCountdownComplete;
			}
			return true;
		}

		private void CreateCourse()
		{
			if (_course == null)
			{
				string stringAttribute = base.Data.XmlData.Element("Race").GetStringAttribute("prefab");
				GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/Activities/Races/" + stringAttribute);
				gameObject.transform.SetParent(base.transform);
				gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				_course = gameObject.GetComponent<RaceCourseScript>();
				if (_course != null)
				{
					_course.InitializeRace(this);
				}
				else
				{
					Debug.LogError("Could not find the RaceCourseScript on the top level game object in the '" + stringAttribute + "' prefab.");
				}
			}
		}

		private IEnumerator EndActivityDelayed(float wait)
		{
			yield return new WaitForSeconds(wait);
			if (!_endRequested)
			{
				_endRequested = true;
				EndActivity();
			}
		}

		private string GetRelativeCheckpointTimeScore(NetworkedActivityPlayer player)
		{
			float valueFloat = player.GetScore("Checkpoint").ValueFloat;
			if (valueFloat < 0f)
			{
				return FormatTime(Mathf.Abs(valueFloat), 2) + "s";
			}
			return "+" + FormatTime(valueFloat, 2) + "s";
		}

		[TargetRpc]
		private void PlayerPassedCheckpointCompleteClient(NetworkConnection client, float finalTime, float checkpointTime, int totalCheckpoints, float skippedCheckpointsPenalty, int currentLap)
		{
			RpcWriter___Target_PlayerPassedCheckpointCompleteClient___569430373(client, finalTime, checkpointTime, totalCheckpoints, skippedCheckpointsPenalty, currentLap);
		}

		[ServerRpc(RequireOwnership = false)]
		private void PlayerPassedCheckpointServer(int playerId, int totalCheckpointsPassed, NetworkConnection client = null, Channel channel = Channel.Reliable)
		{
			RpcWriter___Server_PlayerPassedCheckpointServer___3373083227(playerId, totalCheckpointsPassed, client, channel);
		}

		[ObserversRpc]
		private void StartEndRaceCountdownClient(float endTime)
		{
			RpcWriter___Observers_StartEndRaceCountdownClient___431000436(endTime);
		}

		private bool UpdateRelativeCheckpointScores()
		{
			bool flag = true;
			foreach (KeyValuePair<int, PlayerRaceStatus> playerStatus in _playerStatuses)
			{
				PlayerRaceStatus value = playerStatus.Value;
				if (value.FinalTime == 0f)
				{
					flag = false;
				}
				if (value.TotalCheckpointsPassed != 0)
				{
					float num = value.CheckpointTime - _bestCheckpointTimes[value.TotalCheckpointsPassed];
					if (num <= 0f)
					{
						num = 0f - value.CheckpointTime;
					}
					if (value.RelativeCheckpointTime != num)
					{
						value.RelativeCheckpointTime = num;
						UpdatePlayerScore(playerStatus.Key, "Checkpoint", value.RelativeCheckpointTime, UpdateScoreType.Set);
					}
				}
			}
			if (flag && base.Players.Count > 0)
			{
				StartCoroutine(EndActivityDelayed(1f));
			}
			return flag;
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ERaces_002ERaceActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ERaces_002ERaceActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterTargetRpc(42u, RpcReader___Target_PlayerPassedCheckpointCompleteClient___569430373);
				RegisterServerRpc(43u, RpcReader___Server_PlayerPassedCheckpointServer___3373083227);
				RegisterObserversRpc(44u, RpcReader___Observers_StartEndRaceCountdownClient___431000436);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ERaces_002ERaceActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ERaces_002ERaceActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Target_PlayerPassedCheckpointCompleteClient___569430373(NetworkConnection client, float finalTime, float checkpointTime, int totalCheckpoints, float skippedCheckpointsPenalty, int currentLap)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteSingle(finalTime);
			pooledWriter.WriteSingle(checkpointTime);
			pooledWriter.WriteInt32(totalCheckpoints);
			pooledWriter.WriteSingle(skippedCheckpointsPenalty);
			pooledWriter.WriteInt32(currentLap);
			SendTargetRpc(42u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___PlayerPassedCheckpointCompleteClient___569430373(NetworkConnection P_0, float P_1, float P_2, int P_3, float P_4, int P_5)
		{
			if (P_1 > 0f)
			{
				_finalTime = P_1;
			}
			_currentLap = Mathf.Min(NumLaps, P_5);
			_course.ShowCheckpointMessage(base.LocalPlayer, base.Players.Count > 1, P_1, P_2, P_3, P_4, P_5);
		}

		private void RpcReader___Target_PlayerPassedCheckpointCompleteClient___569430373(PooledReader PooledReader0, Channel channel)
		{
			float num = PooledReader0.ReadSingle();
			float num2 = PooledReader0.ReadSingle();
			int num3 = PooledReader0.ReadInt32();
			float num4 = PooledReader0.ReadSingle();
			int num5 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___PlayerPassedCheckpointCompleteClient___569430373(base.LocalConnection, num, num2, num3, num4, num5);
			}
		}

		private void RpcWriter___Server_PlayerPassedCheckpointServer___3373083227(int playerId, int totalCheckpointsPassed, NetworkConnection client = null, Channel channel = Channel.Reliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteInt32(totalCheckpointsPassed);
			pooledWriter.WriteNetworkConnection(client);
			SendServerRpc(43u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___PlayerPassedCheckpointServer___3373083227(int P_0, int P_1, NetworkConnection P_2, Channel P_3)
		{
			PlayerRaceStatus playerRaceStatus = _playerStatuses[P_0];
			if (P_1 <= playerRaceStatus.TotalCheckpointsPassed)
			{
				return;
			}
			int num = P_1 - playerRaceStatus.TotalCheckpointsPassed - 1;
			playerRaceStatus.NumCheckpointsSkipped += num;
			playerRaceStatus.CurrentPenalty = (float)playerRaceStatus.NumCheckpointsSkipped * _checkpointSkipPenalty;
			playerRaceStatus.CheckpointTime = base.TimerValueServer + playerRaceStatus.CurrentPenalty;
			playerRaceStatus.TotalCheckpointsPassed = P_1;
			playerRaceStatus.CurrentLap = P_1 / _course.NumCheckpoints + 1;
			while (_bestCheckpointTimes.Count <= P_1)
			{
				_bestCheckpointTimes.Add(float.MaxValue);
			}
			if (playerRaceStatus.CheckpointTime < _bestCheckpointTimes[P_1])
			{
				_bestCheckpointTimes[P_1] = playerRaceStatus.CheckpointTime;
			}
			bool flag = false;
			if (P_1 >= _course.NumCheckpoints * NumLaps)
			{
				playerRaceStatus.FinalTime = playerRaceStatus.CheckpointTime;
				UpdatePlayerScore(P_0, "Final", playerRaceStatus.CheckpointTime, UpdateScoreType.Set);
				if (_maxTimeAfterFirstWinner > 0f)
				{
					float num2 = Mathf.Max(30f, playerRaceStatus.CheckpointTime * _maxTimeAfterFirstWinner);
					if (_serverMaxTime == 0f || _serverMaxTime > playerRaceStatus.CheckpointTime + num2)
					{
						_serverMaxTime = playerRaceStatus.CheckpointTime + num2;
						flag = true;
					}
				}
			}
			bool flag2 = UpdateRelativeCheckpointScores();
			PlayerPassedCheckpointCompleteClient(P_2, playerRaceStatus.FinalTime, playerRaceStatus.RelativeCheckpointTime, playerRaceStatus.TotalCheckpointsPassed, playerRaceStatus.CurrentPenalty, playerRaceStatus.CurrentLap);
			if (flag && !flag2)
			{
				NetworkedActivityPlayer player = GetPlayer(P_0);
				float num3 = _serverMaxTime - base.TimerValueServer;
				ShowMessageToAllPlayers($"{player.Name} has finished first! Race will end in {num3:n0} seconds.", logMessage: true, highlighted: true);
				StartEndRaceCountdownClient(_serverMaxTime);
			}
		}

		private void RpcReader___Server_PlayerPassedCheckpointServer___3373083227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			if (base.IsServerInitialized)
			{
				RpcLogic___PlayerPassedCheckpointServer___3373083227(num, num2, networkConnection, channel);
			}
		}

		private void RpcWriter___Observers_StartEndRaceCountdownClient___431000436(float endTime)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteSingle(endTime);
			SendObserversRpc(44u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___StartEndRaceCountdownClient___431000436(float P_0)
		{
			_endRaceTime = P_0;
		}

		private void RpcReader___Observers_StartEndRaceCountdownClient___431000436(PooledReader PooledReader0, Channel channel)
		{
			float num = PooledReader0.ReadSingle();
			if (base.IsClientInitialized)
			{
				RpcLogic___StartEndRaceCountdownClient___431000436(num);
			}
		}

		public override void Awake()
		{
			NetworkInitialize___Early();
			base.Awake();
			NetworkInitialize___Late();
		}
	}
}
