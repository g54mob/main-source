using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.UI.Activity;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.Combat
{
	public class BomberInterceptActivityScript : NetworkedActivityScript
	{
		private enum ActivityState
		{
			InitialState = 0,
			EnemiesSpawned = 1,
			BombingStarted = 2,
			BombingComplete = 3
		}

		private enum BomberState
		{
			ApproachingTarget = 0,
			BombingStared = 1,
			BombingComplete = 2
		}

		private class AIBomber
		{
			public AiControlledAircraftScript AICraft { get; set; }

			public BomberState State { get; set; }

			public AIBomber(AiControlledAircraftScript aiCraft, BomberState state)
			{
				AICraft = aiCraft;
				State = state;
			}
		}

		private const string CraftIdBomber = "Required Craft\\__actBomberIntercept_Bomber__.xml";

		private const string CraftIdEscort = "Required Craft\\__actBomberIntercept_Escort__.xml";

		private const string DeathScoreId = "Deaths";

		private const string KillScoreId = "Score";

		private ActivityState _activityState;

		private List<AIBomber> _bombers;

		private bool _endActivitySubmitted;

		private float? _endTimer;

		private List<AircraftScript> _enemyCrafts = new List<AircraftScript>();

		[SerializeField]
		private Transform _enemyTargetLocation;

		private int _nextSpawnLocationIndexForAIEscort;

		private AsyncServerNetworkRequest<int, int> _spawnLocationRequestForAIEscort;

		[SerializeField]
		private Transform[] _spawnLocationsBomber;

		[SerializeField]
		private Transform[] _spawnLocationsEscort;

		private bool _winStateHost;

		private bool? _winStateRpc;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ECombat_002EBomberInterceptActivityScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ECombat_002EBomberInterceptActivityScriptGame_002Edll_Excuted;

		public override FinalScoreSummary GenerateFinalScoreSummary()
		{
			FinalScoreSummary finalScoreSummary = new FinalScoreSummary();
			if (_winStateRpc == true)
			{
				finalScoreSummary.Message = "You have won!";
				finalScoreSummary.ShowCelebrationStyle = true;
			}
			else if (_winStateRpc == false)
			{
				finalScoreSummary.Message = "You have failed!";
				finalScoreSummary.ShowCelebrationStyle = false;
			}
			else
			{
				finalScoreSummary.Message = "Game Over";
				finalScoreSummary.ShowCelebrationStyle = false;
			}
			return finalScoreSummary;
		}

		public override string GetPlayerScoreString(NetworkedActivityPlayer player)
		{
			int valueInt = player.GetScore("Score").ValueInt;
			int valueInt2 = player.GetScore("Deaths").ValueInt;
			return $"{valueInt}k-{valueInt2}d";
		}

		public override void UpdateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			NetworkedActivityScore score = base.LocalPlayer.Team.GetScore();
			if (score.ValueInt == 1)
			{
				scoreSummary.SetText("left", $"{score.ValueInt} hostile");
			}
			else
			{
				scoreSummary.SetText("left", $"{score.ValueInt} hostiles");
			}
			scoreSummary.SetText("right", string.Empty);
		}

		protected override int CompareScores(NetworkedActivityPlayer x, NetworkedActivityPlayer y)
		{
			int valueInt = x.GetScore("Score").ValueInt;
			int valueInt2 = y.GetScore("Score").ValueInt;
			int valueInt3 = x.GetScore("Deaths").ValueInt;
			int valueInt4 = y.GetScore("Deaths").ValueInt;
			if (valueInt > valueInt2)
			{
				return 1;
			}
			if (valueInt2 > valueInt)
			{
				return -1;
			}
			if (valueInt3 < valueInt4)
			{
				return 1;
			}
			if (valueInt3 > valueInt4)
			{
				return -1;
			}
			return 0;
		}

		protected override IEnumerable<NetworkedActivityScore> CreateScoresForPlayer(NetworkedActivityPlayer player)
		{
			yield return new NetworkedActivityScore("Score", "Score", NetworkedActivityScore.ScoreValueType.Int);
			yield return new NetworkedActivityScore("Deaths", "Deaths", NetworkedActivityScore.ScoreValueType.Int);
		}

		protected override async void OnActivityStartedClient()
		{
			base.OnActivityStartedClient();
			if (base.IsActivityHost)
			{
				int num = ((base.Players.Count < 4) ? 1 : 2);
				_bombers = new List<AIBomber>(num);
				for (int i = 0; i < _spawnLocationsBomber.Length; i++)
				{
					if (num <= 0)
					{
						break;
					}
					Transform transform = _spawnLocationsBomber[i];
					if (transform != null)
					{
						Vector3 position = Utility.ConvertFloatingOriginToAbsolutePosition(transform.position);
						SpawnAi<AiCsFollowCourse>("Required Craft\\__actBomberIntercept_Bomber__.xml", position, transform.rotation.eulerAngles, 100f, aggressive: false, base.Team2.PlayerTeamId);
						num--;
					}
				}
			}
			int timeout = 15000;
			_spawnLocationRequestForAIEscort = new AsyncServerNetworkRequest<int, int>(timeout, SpawnLocationRequestForAIEscortRpc, SpawnLocationForAIEscortResultRpc);
			int escortCount = (base.IsActivityHost ? 1 : (base.IsLocalClientParticipating ? 1 : 0));
			for (int j = 0; j < escortCount; j++)
			{
				AsyncNetworkRequest<int, int>.Result obj = await _spawnLocationRequestForAIEscort.SendRequest(j);
				int resultData = obj.ResultData;
				if (obj.TimedOut)
				{
					Debug.LogError("Failed to get spawn location for an AI escort from the server. The request timed out.");
				}
				else
				{
					if (resultData < 0)
					{
						continue;
					}
					if (resultData >= _spawnLocationsEscort.Length)
					{
						Debug.LogError($"Invalid spawn location index {resultData} for AI escort. The index is out of bounds.");
						continue;
					}
					Transform transform2 = _spawnLocationsEscort[resultData];
					if (transform2 == null)
					{
						Debug.LogError($"Spawn location for AI escort at index {resultData} is null.");
						continue;
					}
					Vector3 position2 = Utility.ConvertFloatingOriginToAbsolutePosition(transform2.position);
					SpawnAi<AiCsFlyToLocationAndEngage>("Required Craft\\__actBomberIntercept_Escort__.xml", position2, transform2.rotation.eulerAngles, 100f, aggressive: true, base.Team2.PlayerTeamId);
				}
			}
		}

		protected override void OnAICraftKilled(AircraftScript craft)
		{
			base.OnAICraftKilled(craft);
			RemoveEnemyCraft(craft);
		}

		protected override void OnAICraftLoaded(AircraftScript craft)
		{
			base.OnAICraftLoaded(craft);
			if (base.IsActivityHost)
			{
				_enemyCrafts.Add(craft);
				UpdateEnemyCount();
			}
		}

		protected override void OnAICraftLoadedAsOwner(AiControlledAircraftScript craft)
		{
			base.OnAICraftLoadedAsOwner(craft);
			if (craft.AiAircraftInfo.AircraftId == "Required Craft\\__actBomberIntercept_Bomber__.xml")
			{
				GroundTarget groundTarget = new GroundTarget("Airport", _enemyTargetLocation, base.Team1.PlayerTeamId);
				craft.AiAircraftScript.TargetingSystem.AddTarget(groundTarget);
				craft.AiAircraftScript.TargetingSystem.CurrentTarget = groundTarget;
				foreach (PartData part in craft.AiAircraftScript.Parts)
				{
					BombData modifier = part.GetModifier<BombData>();
					if (modifier != null)
					{
						modifier.FireDelay = 0.33f;
					}
				}
				Vector3 localPosition = _enemyTargetLocation.localPosition;
				List<Vector3> courseLocations = new List<Vector3>(3)
				{
					_enemyTargetLocation.TransformPoint(localPosition - new Vector3(0f, 0f, 5000f)),
					_enemyTargetLocation.TransformPoint(localPosition),
					_enemyTargetLocation.TransformPoint(localPosition + new Vector3(0f, 0f, 5000f))
				};
				(craft.CurrentControlSystem as AiCsFollowCourse).SetCourseLocations(courseLocations);
				_bombers.Add(new AIBomber(craft, BomberState.ApproachingTarget));
				if (_activityState == ActivityState.InitialState)
				{
					_activityState = ActivityState.EnemiesSpawned;
					ShowMessageToAllPlayers("Enemy threat detected. Defend the airport!", logMessage: false);
				}
			}
			else
			{
				craft.UseGroundAvoidance = true;
				craft.UseWaterAvoidance = true;
			}
			craft.AiAircraftScript.AircraftKilled += OnLocalAICraftKilled;
		}

		protected override void OnAICraftUnloaded(AircraftScript craft)
		{
			base.OnAICraftUnloaded(craft);
			RemoveEnemyCraft(craft);
		}

		protected override void OnLocalPlayerEnded(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerEnded(player);
			player.Player.AircraftKilled -= OnLocalPlayerKilled;
		}

		protected override void OnLocalPlayerStarted(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerStarted(player);
			player.Player.AircraftKilled += OnLocalPlayerKilled;
		}

		protected override void OnUpdateHost()
		{
			base.OnUpdateHost();
			if (_endTimer > 0f)
			{
				_endTimer -= Time.deltaTime;
				if (_endTimer <= 0f && !_endActivitySubmitted && base.State == NetworkedActivityState.Started)
				{
					_endActivitySubmitted = true;
					ActivityFinishedServerRpc(_winStateHost);
				}
			}
			for (int num = _enemyCrafts.Count - 1; num >= 0; num--)
			{
				AircraftScript aircraftScript = _enemyCrafts[num];
				float num2 = Vector3.Distance(aircraftScript.Position, base.transform.position);
				bool flag = false;
				if (num2 > 40000f)
				{
					Debug.Log($"Enemy flew too far away, distance: {num2:n0}m");
					flag = true;
				}
				else
				{
					PartScript mainCockpit = aircraftScript.MainCockpit;
					if ((object)mainCockpit != null && mainCockpit.EstimateOfUnderwaterPercent > 0f)
					{
						Debug.Log($"Enemy went underwater: {aircraftScript.MainCockpit?.EstimateOfUnderwaterPercent}");
						flag = true;
					}
				}
				if (flag)
				{
					RemoveEnemyCraft(aircraftScript);
					aircraftScript.NetworkAircraft.RequestDespawn();
				}
			}
			List<AIBomber> bombers = _bombers;
			if (bombers == null || bombers.Count == 0)
			{
				return;
			}
			foreach (AIBomber bomber in _bombers)
			{
				if (bomber.AICraft == null || bomber.AICraft.AiAircraftScript == null || bomber.State == BomberState.BombingComplete)
				{
					continue;
				}
				if (bomber.State == BomberState.ApproachingTarget)
				{
					Vector3 vector = bomber.AICraft.AiAircraftScript.Position - _enemyTargetLocation.position;
					bomber.AICraft.AiAircraftScript.TargetingSystem.Mode = TargetingSystem.TargetingSystemMode.AirToGround;
					vector.y = 0f;
					if (vector.magnitude < 3350f)
					{
						bomber.State = BomberState.BombingStared;
						if (_activityState == ActivityState.EnemiesSpawned)
						{
							_activityState = ActivityState.BombingStarted;
							ShowMessageToAllPlayers("Enemy bombs have been dropped!", logMessage: true);
							EndActivityDelayed(win: false, 60f);
						}
					}
				}
				if (bomber.State != BomberState.BombingStared)
				{
					continue;
				}
				if (bomber.AICraft.AiAircraftScript.TargetingSystem.CanFire)
				{
					WeaponPart weaponPart = bomber.AICraft.AiAircraftScript.TargetingSystem.SelectedWeaponSystem.Fire(null);
					if (weaponPart != null)
					{
						BombScript modifier = weaponPart.Part.GetModifier<BombScript>();
						if (modifier != null)
						{
							modifier.Exploded += OmBomberBombExploded;
						}
					}
				}
				if (bomber.AICraft.AiAircraftScript.TargetingSystem.SelectedWeaponSystem.Ammo == 0)
				{
					bomber.State = BomberState.BombingComplete;
					if (_activityState == ActivityState.BombingStarted)
					{
						_activityState = ActivityState.BombingComplete;
					}
				}
			}
		}

		[ObserversRpc]
		private void ActivityFinishedObserversRpc(bool win)
		{
			RpcWriter___Observers_ActivityFinishedObserversRpc___1140765316(win);
		}

		[ServerRpc]
		private void ActivityFinishedServerRpc(bool win)
		{
			RpcWriter___Server_ActivityFinishedServerRpc___1140765316(win);
		}

		private void EndActivityDelayed(bool win, float delay)
		{
			if (!_endTimer.HasValue)
			{
				_endTimer = delay;
				_winStateHost = win;
			}
		}

		private void OmBomberBombExploded(object sender, BombExplodedEventArgs e)
		{
			Vector3 vector = _enemyTargetLocation.position - e.Position;
			vector.y = 0f;
		}

		private void OnLocalAICraftKilled(object sender, AircraftKilledEventArgs e)
		{
			if (e.KillerId.HasValue)
			{
				NetworkedActivityPlayer player = GetPlayer(e.KillerId.Value);
				UpdatePlayerScore(player.PlayerId, "Score", 1);
			}
		}

		private void OnLocalPlayerKilled(object sender, AircraftKilledEventArgs e)
		{
			int? num = e.Aircraft?.NetworkAircraft?.PlayerId;
			if (num.HasValue)
			{
				UpdatePlayerScore(num.Value, "Deaths", 1);
			}
		}

		private void RemoveEnemyCraft(AircraftScript craft)
		{
			if (base.IsActivityHost)
			{
				_enemyCrafts.Remove(craft);
				UpdateEnemyCount();
				if (_enemyCrafts.Count == 0 && !_endTimer.HasValue)
				{
					ShowMessageToAllPlayers("All enemies destroyed!", logMessage: true);
					EndActivityDelayed(win: true, 1f);
				}
			}
		}

		[TargetRpc]
		private void SpawnLocationForAIEscortResultRpc(NetworkConnection client, int requestId, int spawnLocationIndex)
		{
			RpcWriter___Target_SpawnLocationForAIEscortResultRpc___3470796954(client, requestId, spawnLocationIndex);
		}

		[ServerRpc(RequireOwnership = false)]
		private void SpawnLocationRequestForAIEscortRpc(int requestId, int unusedParameter, NetworkConnection client = null)
		{
			RpcWriter___Server_SpawnLocationRequestForAIEscortRpc___4191121986(requestId, unusedParameter, client);
		}

		private void UpdateEnemyCount()
		{
			if (base.LocalPlayer?.Team != null)
			{
				UpdateTeamScore(base.LocalPlayer.Team.Id, null, "Score", _enemyCrafts.Count, UpdateScoreType.Set);
			}
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ECombat_002EBomberInterceptActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ECombat_002EBomberInterceptActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(42u, RpcReader___Observers_ActivityFinishedObserversRpc___1140765316);
				RegisterServerRpc(43u, RpcReader___Server_ActivityFinishedServerRpc___1140765316);
				RegisterTargetRpc(44u, RpcReader___Target_SpawnLocationForAIEscortResultRpc___3470796954);
				RegisterServerRpc(45u, RpcReader___Server_SpawnLocationRequestForAIEscortRpc___4191121986);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ECombat_002EBomberInterceptActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002ECombat_002EBomberInterceptActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Observers_ActivityFinishedObserversRpc___1140765316(bool win)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteBoolean(win);
			SendObserversRpc(42u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ActivityFinishedObserversRpc___1140765316(bool P_0)
		{
			if (base.IsActivityHost && !_winStateRpc.HasValue)
			{
				EndActivity();
			}
			_winStateRpc = P_0;
		}

		private void RpcReader___Observers_ActivityFinishedObserversRpc___1140765316(PooledReader PooledReader0, Channel channel)
		{
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsClientInitialized)
			{
				RpcLogic___ActivityFinishedObserversRpc___1140765316(flag);
			}
		}

		private void RpcWriter___Server_ActivityFinishedServerRpc___1140765316(bool win)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			if (!base.IsOwner)
			{
				NetworkManager networkManager2 = base.NetworkManager;
				networkManager2.LogWarning("Cannot complete action because you are not the owner of this object. .");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteBoolean(win);
			SendServerRpc(43u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ActivityFinishedServerRpc___1140765316(bool P_0)
		{
			ActivityFinishedObserversRpc(P_0);
		}

		private void RpcReader___Server_ActivityFinishedServerRpc___1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___ActivityFinishedServerRpc___1140765316(flag);
			}
		}

		private void RpcWriter___Target_SpawnLocationForAIEscortResultRpc___3470796954(NetworkConnection client, int requestId, int spawnLocationIndex)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			pooledWriter.WriteInt32(spawnLocationIndex);
			SendTargetRpc(44u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SpawnLocationForAIEscortResultRpc___3470796954(NetworkConnection P_0, int P_1, int P_2)
		{
			_spawnLocationRequestForAIEscort.ReceiveResult(P_1, P_2);
		}

		private void RpcReader___Target_SpawnLocationForAIEscortResultRpc___3470796954(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___SpawnLocationForAIEscortResultRpc___3470796954(base.LocalConnection, num, num2);
			}
		}

		private void RpcWriter___Server_SpawnLocationRequestForAIEscortRpc___4191121986(int requestId, int unusedParameter, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			pooledWriter.WriteInt32(unusedParameter);
			SendServerRpc(45u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SpawnLocationRequestForAIEscortRpc___4191121986(int P_0, int P_1, NetworkConnection P_2)
		{
			try
			{
				while (_nextSpawnLocationIndexForAIEscort < _spawnLocationsEscort.Length)
				{
					int num = _nextSpawnLocationIndexForAIEscort++;
					if (_spawnLocationsEscort[num] != null)
					{
						_spawnLocationRequestForAIEscort.SendResult(P_0, num, P_2);
						return;
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			_spawnLocationRequestForAIEscort.SendResult(P_0, -1, P_2);
		}

		private void RpcReader___Server_SpawnLocationRequestForAIEscortRpc___4191121986(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___SpawnLocationRequestForAIEscortRpc___4191121986(num, num2, conn);
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
