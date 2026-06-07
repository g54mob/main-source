using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.ObserverConditions;
using Assets.Scripts.UI.Activity;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.MechInvasion
{
	public class MechInvasionScript : NetworkedActivityScript
	{
		private struct MechLaunchInfo
		{
			public Vector3 LandLocation { get; set; }

			public float LandTime { get; set; }

			public Vector3 LaunchLocation { get; set; }

			public float LaunchTime { get; set; }

			public string MechName { get; set; }

			public string PathName { get; set; }

			public MechLaunchInfo(string mechName, string pathName, float launchTime, float landTime, Vector3 launchLocation, Vector3 landLocation)
			{
				MechName = mechName;
				PathName = pathName;
				LaunchTime = launchTime;
				LandTime = landTime;
				LaunchLocation = launchLocation;
				LandLocation = landLocation;
			}

			public MechLaunchInfo(Reader reader)
			{
				MechName = reader.ReadStringAllocated();
				PathName = reader.ReadStringAllocated();
				LaunchTime = reader.ReadSingleUnpacked();
				LandTime = reader.ReadSingleUnpacked();
				LaunchLocation = reader.ReadVector3();
				LandLocation = reader.ReadVector3();
			}

			public void WriteData(Writer writer)
			{
				writer.WriteString(MechName);
				writer.WriteString(PathName);
				writer.WriteSingleUnpacked(LaunchTime);
				writer.WriteSingleUnpacked(LandTime);
				writer.WriteVector3(LaunchLocation);
				writer.WriteVector3(LandLocation);
			}
		}

		private class MechLaunch
		{
			public MechLaunchInfo Info { get; set; }

			public bool Landed { get; set; }

			public MechLaunchEffectsScript LaunchEffects { get; set; }

			public MechLaunch(MechLaunchInfo info)
			{
				Info = info;
				LaunchEffects = null;
				Landed = false;
			}
		}

		private static string[] _mechNames = new string[22]
		{
			"Apex", "Titan", "Colossus", "Typhoon", "Wraith", "Hellforge", "Revenant", "Centurion", "Tempest", "Nova",
			"Tyrant", "Basilisk", "Leviathan", "Fenrir", "Bastille", "Goliath", "Juggernaut", "Valkyrie", "Marauder", "Behemoth",
			"Warbringer", "Dreadnought"
		};

		private bool _endActivitySubmitted;

		private int _localDamageReceived;

		private List<MechLaunch> _mechLaunches;

		[SerializeField]
		private MechLaunchEffectsScript _mechLaunchPrefab;

		[SerializeField]
		private GameObject _mechPrefab;

		private List<MechScript> _mechs = new List<MechScript>();

		[SerializeField]
		private Transform _mechStartPosition;

		private float? _scoreSyncTimer = 1f;

		private bool? _winStateRpc;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechInvasionScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechInvasionScriptGame_002Edll_Excuted;

		public bool AllMechsLanded { get; private set; }

		public override NetworkedActivityTeamIds JoinableTeams => NetworkedActivityTeamIds.Team1;

		public float TimeAtObjectiveUntilFailure { get; private set; } = 20f;

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
			return $"{player.GetScore().ValueFloat / 1000f:n1}k";
		}

		public void OnMechReachedObjective(MechScript mech)
		{
			int num = 0;
			for (int i = 0; i < _mechs.Count; i++)
			{
				if (_mechs[i].HasReachedObjective && !_mechs[i].IsDestroyed)
				{
					num++;
				}
			}
			if (num == 1)
			{
				ShowMessageToAllPlayers("The mechs reached Driftwood!", logMessage: true);
			}
		}

		public override void OnStopServer()
		{
			base.OnStopServer();
			foreach (MechScript mech in _mechs)
			{
				mech.Despawn(DespawnType.Destroy);
			}
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			AllMechsLanded = reader.ReadBoolean();
			if (AllMechsLanded)
			{
				return;
			}
			int num = reader.ReadInt32();
			if (num > 0)
			{
				_mechLaunches = new List<MechLaunch>(num);
				for (int i = 0; i < num; i++)
				{
					MechLaunchInfo info = new MechLaunchInfo(reader);
					_mechLaunches.Add(new MechLaunch(info));
				}
			}
		}

		public void RegisterDamageFromLocalPlayer(short damageReceived)
		{
			_localDamageReceived += damageReceived;
			if (!_scoreSyncTimer.HasValue)
			{
				_scoreSyncTimer = 1f;
			}
		}

		public void RegisterMech(MechScript mech)
		{
			_mechs.Add(mech);
		}

		public override void UpdateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			int num = 0;
			foreach (MechScript mech in _mechs)
			{
				if (!mech.IsDestroyed)
				{
					num++;
				}
			}
			scoreSummary.SetText("left", string.Format("{0} Mech{1} Remaining", num, (num > 1) ? "s" : string.Empty));
			int valueInt = base.LocalPlayer.GetScore().ValueInt;
			scoreSummary.SetText("right", $"{(float)valueInt / 1000f:n1}k damage");
		}

		public override void WritePayload(NetworkConnection connection, Writer writer)
		{
			base.WritePayload(connection, writer);
			writer.WriteBoolean(AllMechsLanded);
			if (AllMechsLanded)
			{
				return;
			}
			int num = _mechLaunches?.Count ?? 0;
			writer.WriteInt32(num);
			if (num <= 0)
			{
				return;
			}
			foreach (MechLaunch mechLaunch in _mechLaunches)
			{
				mechLaunch.Info.WriteData(writer);
			}
		}

		protected override void OnActivityStartedServer()
		{
			base.OnActivityStartedServer();
			List<string> value;
			using (CollectionPool<List<string>, string>.Get(out value))
			{
				value.AddRange(_mechNames);
				List<MechPathScript> value2;
				using (CollectionPool<List<MechPathScript>, MechPathScript>.Get(out value2))
				{
					GetComponentsInChildren(includeInactive: false, value2);
					int max = Mathf.Min(value.Count, value2.Count);
					int num = Mathf.Clamp(base.Players.Count + 1, 2, max);
					if (Device.IsUnityEditor)
					{
						ValidateMechPaths(value2);
					}
					float physicsTime = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime;
					float num2 = 5f;
					Vector3 vector = Quaternion.Euler(0f, UnityEngine.Random.Range(-180f, 180f), UnityEngine.Random.Range(20f, 35f)) * Vector3.up;
					float num3 = 5000f;
					List<MechLaunchInfo> list = new List<MechLaunchInfo>();
					while (num > 0 && value.Count > 0 && value2.Count > 0)
					{
						num--;
						int index = UnityEngine.Random.Range(0, value.Count);
						string mechName = value[index];
						value.RemoveAt(index);
						MechPathScript mechPathScript = value2.FirstOrDefault((MechPathScript x) => x.name.Contains("Test"));
						int index2 = ((mechPathScript != null) ? value2.IndexOf(mechPathScript) : UnityEngine.Random.Range(0, value2.Count));
						MechPathScript mechPathScript2 = value2[index2];
						value2.RemoveAt(index2);
						MechPathWaypointScript mechPathWaypointScript = mechPathScript2.Waypoints[0];
						Vector3 vector2 = Utility.ConvertFloatingOriginToAbsolutePosition(Vector3.Lerp(b: mechPathScript2.Waypoints[1].Position, a: mechPathWaypointScript.Position, t: UnityEngine.Random.Range(0f, 0.9f)));
						Vector3 launchLocation = vector2 + vector * num3;
						float num4 = physicsTime + UnityEngine.Random.Range(0f, 3f);
						float landTime = num4 + num2;
						MechLaunchInfo item = new MechLaunchInfo(mechName, mechPathScript2.name, num4, landTime, launchLocation, vector2);
						list.Add(item);
					}
					using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = this.GetPooledWriter();
					PooledWriter writer = pooledWriterDisposableWrapper.Writer;
					writer.WriteInt32(list.Count);
					foreach (MechLaunchInfo item2 in list)
					{
						item2.WriteData(writer);
					}
					LaunchMechs(writer.GetArraySegment());
				}
			}
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (!AllMechsLanded && (_mechLaunches?.Count ?? 0) > 0)
			{
				UpdateMechLaunches(base.IsServerStarted);
			}
		}

		protected override void OnUpdateParticipatingClient()
		{
			base.OnUpdateParticipatingClient();
			if (_scoreSyncTimer > 0f)
			{
				_scoreSyncTimer -= Time.deltaTime;
			}
			else if (_localDamageReceived > 0)
			{
				_scoreSyncTimer = null;
				UpdatePlayerScore(base.LocalPlayer.PlayerId, "Score", _localDamageReceived);
				_localDamageReceived = 0;
			}
		}

		protected override void OnUpdateServer()
		{
			base.OnUpdateServer();
			if (!AllMechsLanded)
			{
				return;
			}
			bool flag = false;
			bool flag2 = _mechs.Count > 0;
			foreach (MechScript mech in _mechs)
			{
				if (mech != null)
				{
					mech.OnUpdateServer();
					flag |= mech.HasReachedObjective && !mech.IsDestroyed && mech.TimeAtObjective > TimeAtObjectiveUntilFailure;
					flag2 &= mech.IsDestroyed;
				}
			}
			if (!_endActivitySubmitted)
			{
				if (flag)
				{
					ShowMessageToAllPlayers("The mechs have destroyed Driftwood!", logMessage: true);
					SubmitEndActivityRequest(win: false);
				}
				else if (flag2)
				{
					ShowMessageToAllPlayers("All enemies destroyed!", logMessage: true);
					SubmitEndActivityRequest(win: true);
				}
			}
		}

		[ObserversRpc]
		private void ActivityFinishedObserversRpc(bool win)
		{
			RpcWriter___Observers_ActivityFinishedObserversRpc___1140765316(win);
		}

		[ServerRpc(RequireOwnership = false)]
		private void ActivityFinishedServerRpc(bool win)
		{
			RpcWriter___Server_ActivityFinishedServerRpc___1140765316(win);
		}

		[ObserversRpc(RunLocally = true)]
		private void LaunchMechs(ArraySegment<byte> data)
		{
			RpcWriter___Observers_LaunchMechs___415360332(data);
			RpcLogic___LaunchMechs___415360332(data);
		}

		private void SpawnMech(MechPathScript path, int randomSeed, string mechName, Vector3 position)
		{
			if (!base.IsServerStarted)
			{
				Debug.LogError("Spawning mechs can only be done on the server.");
				return;
			}
			MechPathWaypointScript mechPathWaypointScript = ((path.Waypoints.Count > 0) ? path.Waypoints[0] : null);
			if (mechPathWaypointScript == null)
			{
				Debug.LogError("Cannot spawn mech '" + mechName + "' on path '" + path.name + "' because its first waypoint could not be found.");
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(_mechPrefab);
			gameObject.transform.SetPositionAndRotation(position, mechPathWaypointScript.Rotation);
			MechScript component = gameObject.GetComponent<MechScript>();
			component.ServerInitialize(this, path, 1, (ushort)randomSeed, mechName, base.Team2.PlayerTeamId);
			InstanceFinder.ServerManager.Spawn(gameObject, base.LocalConnection);
			DistanceFromPlayerObserverCondition distanceFromPlayerObserverCondition = component.NetworkObject.NetworkObserver.GetObserverCondition<DistanceFromPlayerObserverCondition>() as DistanceFromPlayerObserverCondition;
			if (distanceFromPlayerObserverCondition != null)
			{
				distanceFromPlayerObserverCondition.ObserveDistance = 30000f;
				distanceFromPlayerObserverCondition.HideDistance = 50000f;
			}
		}

		private void SubmitEndActivityRequest(bool win)
		{
			if (!_endActivitySubmitted && base.State == NetworkedActivityState.Started)
			{
				_endActivitySubmitted = true;
				ActivityFinishedServerRpc(win);
			}
		}

		private void UpdateMechLaunches(bool asServer)
		{
			float physicsTime = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime;
			bool flag = _mechLaunches.Count > 0;
			foreach (MechLaunch mechLaunch in _mechLaunches)
			{
				MechLaunchInfo info = mechLaunch.Info;
				bool flag2 = info.LandTime < physicsTime;
				bool flag3 = !mechLaunch.Landed && flag2;
				mechLaunch.Landed = flag2;
				flag = flag && flag2;
				bool flag4 = mechLaunch.LaunchEffects == null && !flag2;
				if (flag4)
				{
					mechLaunch.LaunchEffects = UnityEngine.Object.Instantiate(_mechLaunchPrefab, new InstantiateParameters
					{
						parent = base.transform,
						worldSpace = true
					});
				}
				Transform transform = mechLaunch.LaunchEffects.transform;
				if (!flag2 || flag3)
				{
					bool num = physicsTime >= info.LandTime;
					float a = (num ? (info.LandTime - 0.5f) : info.LaunchTime);
					float b = (num ? info.LandTime : (info.LandTime - 0.5f));
					float num2 = Mathf.InverseLerp(a, b, physicsTime);
					Vector3 absolutePosition = (num ? Vector3.Lerp(info.LandLocation, info.LandLocation + new Vector3(0f, -500f, 0f), num2) : Vector3.Lerp(info.LaunchLocation, info.LandLocation, num2));
					transform.position = Utility.ConvertAbsoluteToFloatingOriginPosition(absolutePosition);
					float launchProgress = (num ? 1f : num2);
					if (flag4)
					{
						mechLaunch.LaunchEffects.OnMechLaunched(launchProgress);
					}
					mechLaunch.LaunchEffects.OnLaunchUpdate(launchProgress);
				}
				if (!flag3)
				{
					continue;
				}
				mechLaunch.LaunchEffects.OnMechSpawned();
				if (!asServer)
				{
					continue;
				}
				List<MechPathScript> value;
				using (CollectionPool<List<MechPathScript>, MechPathScript>.Get(out value))
				{
					GetComponentsInChildren(includeInactive: false, value);
					MechPathScript mechPathScript = value.FirstOrDefault((MechPathScript x) => x.name == info.PathName);
					if (mechPathScript == null)
					{
						Debug.LogError("Cannot find mech path '" + info.PathName + "' to spawn mech '" + info.MechName + "'.");
					}
					else
					{
						Vector3 position = Utility.ConvertAbsoluteToFloatingOriginPosition(info.LandLocation);
						SpawnMech(mechPathScript, UnityEngine.Random.Range(1, 1024), info.MechName, position);
					}
				}
			}
			AllMechsLanded = flag;
			if (AllMechsLanded && asServer)
			{
				ShowMessageToAllPlayers($"{_mechLaunches.Count} mechs are approaching! Stop them at all costs!", logMessage: true);
			}
		}

		private void ValidateMechPaths(List<MechPathScript> paths)
		{
			HashSet<string> value;
			using (CollectionPool<HashSet<string>, string>.Get(out value))
			{
				foreach (MechPathScript path in paths)
				{
					if (!value.Add(path.name))
					{
						Debug.LogError("Duplicate mech path name '" + path.name + "' found. Please ensure all mech paths have unique names.");
					}
					if (path.Objective == null)
					{
						Debug.LogError("Mech path '" + path.name + "' does not have an objective transform assigned. Please ensure all mech paths have an objective transform assigned.");
					}
					IReadOnlyList<MechPathWaypointScript> waypoints = path.Waypoints;
					if (waypoints.Count <= 1)
					{
						Debug.LogError($"Mech path '{path.name}' has {waypoints.Count} waypoint(s). Please ensure all mech paths have at least 2 waypoints.");
					}
					for (int i = 1; i < waypoints.Count; i++)
					{
						if (waypoints[i] == null)
						{
							Debug.LogError($"Mech path '{path.name}' has a null waypoint at index {i}. Please ensure all mech paths have valid waypoints assigned.");
						}
					}
				}
			}
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechInvasionScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechInvasionScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(42u, RpcReader___Observers_ActivityFinishedObserversRpc___1140765316);
				RegisterServerRpc(43u, RpcReader___Server_ActivityFinishedServerRpc___1140765316);
				RegisterObserversRpc(44u, RpcReader___Observers_LaunchMechs___415360332);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechInvasionScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechInvasionScriptGame_002Edll_Excuted = true;
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
			if (base.IsServerStarted && !_winStateRpc.HasValue)
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
			if (base.IsServerInitialized)
			{
				RpcLogic___ActivityFinishedServerRpc___1140765316(flag);
			}
		}

		private void RpcWriter___Observers_LaunchMechs___415360332(ArraySegment<byte> data)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(44u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___LaunchMechs___415360332(ArraySegment<byte> P_0)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(P_0);
			PooledReader reader = pooledReaderDisposableWrapper.Reader;
			int num = reader.ReadInt32();
			_mechLaunches = new List<MechLaunch>(num);
			for (int i = 0; i < num; i++)
			{
				MechLaunchInfo info = new MechLaunchInfo(reader);
				_mechLaunches.Add(new MechLaunch(info));
			}
		}

		private void RpcReader___Observers_LaunchMechs___415360332(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___LaunchMechs___415360332(arraySegment);
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
