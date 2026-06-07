using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Assets.Scripts.Levels;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.UI.Activity;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.OrbSnatcher
{
	public class OrbSnatcherActivityScript : NetworkedActivityScript
	{
		private static class Profile
		{
			public static readonly ProfilerMarker ChangeOrbOwner = new ProfilerMarker("OrbSnatcherActivityScript.ChangeOrbOwner");

			public static readonly ProfilerMarker ChangeOrbOwnerClientRpc = new ProfilerMarker("OrbSnatcherActivityScript.ChangeOrbOwnerClientRpc");

			public static readonly ProfilerMarker ChangeOrbOwnerLocal = new ProfilerMarker("OrbSnatcherActivityScript.ChangeOrbOwnerLocal");

			public static readonly ProfilerMarker ChangeOrbOwnerServerRpc = new ProfilerMarker("OrbSnatcherActivityScript.ChangeOrbOwnerServerRpc");

			public static readonly ProfilerMarker DeactivateOrbClientRpc = new ProfilerMarker("OrbSnatcherActivityScript.DeactivateOrbClientRpc");

			public static readonly ProfilerMarker DeactivateOrbServerRpc = new ProfilerMarker("OrbSnatcherActivityScript.DeactivateOrbServerRpc");

			public static readonly ProfilerMarker OnPlayerScored = new ProfilerMarker("OrbSnatcherActivityScript.OnPlayerScored");

			public static readonly ProfilerMarker OnPostTickClient = new ProfilerMarker("OrbSnatcherActivityScript.OnPostTickClient");

			public static readonly ProfilerMarker ProcessOrbSyncDataClientRpc = new ProfilerMarker("OrbSnatcherActivityScript.ProcessOrbSyncDataClientRpc");

			public static readonly ProfilerMarker ProcessOrbSyncDataServerRpc = new ProfilerMarker("OrbSnatcherActivityScript.ProcessOrbSyncDataServerRpc");
		}

		private class OrbSyncData
		{
			public bool IsActive;

			public int OrbId;

			public int OwnerId;

			public int PlayerId;

			public Vector3 Position;

			public Vector3 Velocity;

			public OrbSyncData()
			{
				OrbId = -1;
				IsActive = true;
				PlayerId = -1;
				OwnerId = -1;
				Position = Vector3.zero;
				Velocity = Vector3.zero;
			}

			public OrbSyncData(int orbId, int ownerId, Vector3 position)
			{
				OrbId = orbId;
				IsActive = true;
				PlayerId = -1;
				OwnerId = ownerId;
				Position = position;
				Velocity = Vector3.zero;
			}

			public void DiscardTickData(Reader reader)
			{
				reader.ReadVector3();
				reader.ReadVector3();
			}

			public void ReadPayloadData(Reader reader)
			{
				OrbId = reader.ReadInt32();
				IsActive = reader.ReadBoolean();
				PlayerId = reader.ReadInt32();
				OwnerId = reader.ReadInt32();
				Position = reader.ReadVector3();
				Velocity = reader.ReadVector3();
			}

			public void ReadTickData(Reader reader)
			{
				Position = reader.ReadVector3();
				Velocity = reader.ReadVector3();
			}

			public void WritePayloadData(Writer writer)
			{
				writer.WriteInt32(OrbId);
				writer.WriteBoolean(IsActive);
				writer.WriteInt32(PlayerId);
				writer.WriteInt32(OwnerId);
				writer.WriteVector3(Position);
				writer.WriteVector3(Velocity);
			}

			public void WriteTickData(Writer writer)
			{
				writer.WriteVector3(Position);
				writer.WriteVector3(Velocity);
			}
		}

		private GameObject _activityRootObject;

		private float _lastPhysicsTime;

		[SerializeField]
		private OrbScript _orbPrefab;

		private List<OrbScript> _orbs = new List<OrbScript>();

		private OrbSyncData[] _orbSyncData;

		private Dictionary<(int PreviousPlayerId, int NewPlayerId), (int OrbCount, float ReportTime)> _pendingOrbTheftNotifications = new Dictionary<(int, int), (int, float)>();

		[SerializeField]
		private AudioSource _pickupSound;

		[SerializeField]
		private AudioSource _scoreSound;

		private Vector3 _spawnOffset = new Vector3(0f, 0f, 0f);

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EOrbSnatcher_002EOrbSnatcherActivityScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EOrbSnatcher_002EOrbSnatcherActivityScriptGame_002Edll_Excuted;

		public override NetworkedActivityTeamIds JoinableTeams => NetworkedActivityTeamIds.Team1;

		public void ChangeOrbOwner(OrbScript orb, NetworkedActivityPlayer player)
		{
			if (orb == null)
			{
				throw new ArgumentNullException("orb");
			}
			using (Profile.ChangeOrbOwner.Auto())
			{
				int playerId = player?.PlayerId ?? (-1);
				int ownerId = player?.Owner.ClientId ?? Game.Instance.NetworkGameManager.ServerPlayer.OwnerId;
				ChangeOrbOwnerLocal(orb.OrbId, playerId, ownerId);
				ChangeOrbOwnerServerRpc(orb.OrbId, playerId, ownerId, base.LocalConnection);
			}
		}

		public void OnPlayerScored(FlightScenePlayer player, OrbChainScript chain)
		{
			using (Profile.OnPlayerScored.Auto())
			{
				int num = chain?.Orbs.Count ?? 0;
				if (num == 0)
				{
					return;
				}
				player.NetworkedActivity.UpdatePlayerScore(player.NetworkPlayer.PlayerId, "Score", num);
				FlightSceneScript.Instance.FlightSceneNetwork.BroadcastMessageToAllClients(string.Format("{0} scored {1} point{2}", player.NetworkPlayer.Name, num, (num == 1) ? string.Empty : "s"));
				List<OrbScript> value;
				using (CollectionPool<List<OrbScript>, OrbScript>.Get(out value))
				{
					value.AddRange(chain.Orbs);
					chain.Orbs[0].DetachFromLocalPlayer(includeChainedOrbs: true);
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						OrbScript orbScript = value[num2];
						DeactivateOrbServerRpc(orbScript.OrbId);
					}
					if (player.IsPrimaryLocal)
					{
						_scoreSound.Play();
					}
				}
			}
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			if (!base.IsServerStarted)
			{
				LoadActivityPrefab();
			}
			SpawnOrbs();
		}

		public override void OnStartServer()
		{
			base.OnStartServer();
			LoadActivityPrefab();
			CreateOrbSyncData();
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			int num = reader.ReadInt32();
			_orbSyncData = new OrbSyncData[num];
			for (int i = 0; i < num; i++)
			{
				OrbSyncData orbSyncData = new OrbSyncData();
				orbSyncData.ReadPayloadData(reader);
				_orbSyncData[i] = orbSyncData;
			}
		}

		public void RegisterPendingOrbTheftNotification(int previousPlayerId, int newPlayerId)
		{
			(int, int) key = (previousPlayerId, newPlayerId);
			_pendingOrbTheftNotifications.TryGetValue(key, out (int, float) value);
			_pendingOrbTheftNotifications[key] = (value.Item1 + 1, 1f);
		}

		public override void UpdateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			scoreSummary.SetText("left", LevelBase.FormatTime(((float?)base.TimerValue) ?? 0f));
			int valueInt = base.LocalPlayer.GetScore().ValueInt;
			scoreSummary.SetText("right", $"{valueInt}");
		}

		public override void WritePayload(NetworkConnection connection, Writer writer)
		{
			base.WritePayload(connection, writer);
			writer.WriteInt32(_orbSyncData.Length);
			OrbSyncData[] orbSyncData = _orbSyncData;
			for (int i = 0; i < orbSyncData.Length; i++)
			{
				orbSyncData[i].WritePayloadData(writer);
			}
		}

		protected override NetworkedActivityTeamType GetTeamType(NetworkedActivityTeamIds teamId)
		{
			return NetworkedActivityTeamType.TeamPerPlayerHostile;
		}

		protected override void OnActivityStartedClient()
		{
			base.OnActivityStartedClient();
			if (base.IsActivityHost)
			{
				StartTimer(base.Data.XmlData.GetIntAttribute("timer"));
			}
		}

		protected override void OnLocalPlayerEnding(NetworkedActivityPlayer player)
		{
			base.OnLocalPlayerEnding(player);
			AircraftScript aircraftScript = player?.Player?.Aircraft;
			if (aircraftScript != null && aircraftScript.TryGetComponent<OrbChainScript>(out var component))
			{
				UnityEngine.Object.Destroy(component);
			}
		}

		protected override void OnPostTickClient()
		{
			base.OnPostTickClient();
			using (Profile.OnPostTickClient.Auto())
			{
				bool flag = false;
				int clientId = base.LocalConnection.ClientId;
				List<OrbSyncData> value;
				using (CollectionPool<List<OrbSyncData>, OrbSyncData>.Get(out value))
				{
					for (int i = 0; i < _orbSyncData.Length; i++)
					{
						OrbSyncData orbSyncData = _orbSyncData[i];
						if (!orbSyncData.IsActive)
						{
							continue;
						}
						OrbScript orbScript = _orbs[i];
						if (orbSyncData.OwnerId == clientId)
						{
							Vector3 localPosition = orbScript.Transform.localPosition;
							Vector3 linearVelocity = orbScript.Rigidbody.linearVelocity;
							bool flag2 = orbSyncData.Velocity != Vector3.zero && linearVelocity.sqrMagnitude < 0.0001f;
							flag = flag || flag2;
							bool flag3 = flag2 || (orbSyncData.Velocity - linearVelocity).sqrMagnitude > 0.0001f;
							if ((orbSyncData.Position - localPosition).sqrMagnitude > 0.0001f || flag3)
							{
								orbSyncData.Position = localPosition;
								orbSyncData.Velocity = (flag2 ? Vector3.zero : linearVelocity);
								value.Add(orbSyncData);
							}
						}
						else if (orbSyncData.Velocity == Vector3.zero)
						{
							Vector3 localPosition2 = orbScript.Transform.localPosition;
							if ((orbSyncData.Position - localPosition2).sqrMagnitude > 0.0001f)
							{
								orbScript.Transform.localPosition = orbSyncData.Position;
								orbScript.Rigidbody.linearVelocity = Vector3.zero;
							}
						}
					}
					if (value.Count == 0)
					{
						return;
					}
					using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = this.GetPooledWriter();
					PooledWriter writer = pooledWriterDisposableWrapper.Writer;
					FlightSceneNetworkScript flightSceneNetwork = FlightSceneScript.Instance.FlightSceneNetwork;
					writer.WriteSingleUnpacked(flightSceneNetwork.PhysicsTime);
					writer.WriteInt32(value.Count);
					for (int j = 0; j < value.Count; j++)
					{
						OrbSyncData orbSyncData2 = value[j];
						writer.WriteInt32(orbSyncData2.OrbId);
						orbSyncData2.WriteTickData(writer);
					}
					ProcessOrbSyncDataServerRpc(writer.GetArraySegment(), (!flag) ? Channel.Unreliable : Channel.Reliable, base.LocalConnection);
				}
			}
		}

		protected override void OnTimerChangedClient(int timerValue)
		{
			base.OnTimerChangedClient(timerValue);
			if (timerValue <= 0 && base.IsActivityHost)
			{
				StopTimer();
				EndActivity();
			}
		}

		protected override void OnUpdateParticipatingClient()
		{
			base.OnUpdateParticipatingClient();
			UpdatePendingOrbTheftNotifications(Time.deltaTime);
		}

		[ObserversRpc(RunLocally = true)]
		private void ChangeOrbOwnerClientRpc(int orbId, int playerId, int ownerId)
		{
			RpcWriter___Observers_ChangeOrbOwnerClientRpc___1805552400(orbId, playerId, ownerId);
			RpcLogic___ChangeOrbOwnerClientRpc___1805552400(orbId, playerId, ownerId);
		}

		private void ChangeOrbOwnerLocal(int orbId, int playerId, int ownerId)
		{
			using (Profile.ChangeOrbOwnerLocal.Auto())
			{
				if (orbId < 0 || orbId >= _orbSyncData.Length || orbId >= _orbs.Count)
				{
					Debug.LogError($"Invalid orb id {orbId} in ChangeOrbOwner.");
					return;
				}
				NetworkedActivityPlayer networkedActivityPlayer = null;
				if (playerId >= 0)
				{
					networkedActivityPlayer = GetPlayer(playerId);
					if (networkedActivityPlayer == null)
					{
						Debug.LogError($"Invalid player id {playerId} in ChangeOrbOwner.");
						return;
					}
				}
				OrbScript orbScript = _orbs[orbId];
				OrbSyncData orbSyncData = _orbSyncData[orbId];
				if (orbSyncData.IsActive && (orbSyncData.PlayerId != playerId || orbSyncData.OwnerId != ownerId))
				{
					orbSyncData.PlayerId = playerId;
					orbSyncData.OwnerId = ownerId;
					orbScript.OnOrbOwnerChanged(networkedActivityPlayer);
					if (playerId == base.LocalPlayer?.PlayerId)
					{
						_pickupSound.Play();
					}
				}
			}
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		private void ChangeOrbOwnerServerRpc(int orbId, int playerId, int ownerId, NetworkConnection client = null)
		{
			RpcWriter___Server_ChangeOrbOwnerServerRpc___3218483375(orbId, playerId, ownerId, client);
			RpcLogic___ChangeOrbOwnerServerRpc___3218483375(orbId, playerId, ownerId, client);
		}

		private void CreateOrbSyncData()
		{
			Transform transform = _activityRootObject.transform.Find("Orbs");
			if (transform == null)
			{
				throw new Exception("Could not find 'Orbs' game object in OrbSnatcher activity prefab.");
			}
			List<Vector3> value;
			using (CollectionPool<List<Vector3>, Vector3>.Get(out value))
			{
				GetSpawnPoints(transform, value);
				Vector3[] array = value.ToArray();
				base.transform.InverseTransformPoints(value.AsSpan(), array.AsSpan());
				_orbSyncData = new OrbSyncData[array.Length];
				int clientId = base.LocalConnection.ClientId;
				for (int i = 0; i < array.Length; i++)
				{
					OrbSyncData orbSyncData = new OrbSyncData(i, clientId, array[i]);
					_orbSyncData[i] = orbSyncData;
				}
				transform.gameObject.SetActive(value: false);
			}
		}

		[ObserversRpc(RunLocally = true)]
		private void DeactivateOrbClientRpc(int orbId, int ownerId)
		{
			RpcWriter___Observers_DeactivateOrbClientRpc___1692629761(orbId, ownerId);
			RpcLogic___DeactivateOrbClientRpc___1692629761(orbId, ownerId);
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		private void DeactivateOrbServerRpc(int orbId)
		{
			RpcWriter___Server_DeactivateOrbServerRpc___3316948804(orbId);
			RpcLogic___DeactivateOrbServerRpc___3316948804(orbId);
		}

		private void GetSpawnPoints(Transform spawnPointTransform, List<Vector3> points)
		{
			if (spawnPointTransform.childCount == 0)
			{
				points.Add(spawnPointTransform.position + _spawnOffset);
				return;
			}
			foreach (Transform item in spawnPointTransform)
			{
				GetSpawnPoints(item, points);
			}
		}

		private void LoadActivityPrefab()
		{
			string stringAttribute = base.Data.XmlData.Element("OrbSnatcher").GetStringAttribute("prefab");
			_activityRootObject = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/Activities/OrbSnatcher/" + stringAttribute);
			_activityRootObject.transform.SetParent(base.transform);
			_activityRootObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			_activityRootObject.GetComponentInChildren<OrbGoalScript>().Initialize(this);
		}

		[TargetRpc(RunLocally = true)]
		private void ProcessOrbSyncDataClientRpc(NetworkConnection client, ArraySegment<byte> data, int sourceClientId, Channel channel = Channel.Reliable)
		{
			RpcWriter___Target_ProcessOrbSyncDataClientRpc___3263673867(client, data, sourceClientId, channel);
			RpcLogic___ProcessOrbSyncDataClientRpc___3263673867(client, data, sourceClientId, channel);
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		private void ProcessOrbSyncDataServerRpc(ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection client = null)
		{
			RpcWriter___Server_ProcessOrbSyncDataServerRpc___1695994506(data, channel, client);
			RpcLogic___ProcessOrbSyncDataServerRpc___1695994506(data, channel, client);
		}

		private void ProcessOrbUpdate(OrbScript orb, float physicsTimeDelta, Vector3 position, Vector3 velocity)
		{
			orb.Transform.localPosition = position + physicsTimeDelta * base.transform.InverseTransformDirection(velocity);
			orb.Rigidbody.linearVelocity = velocity;
		}

		private void SpawnOrbs()
		{
			Transform transform = new GameObject("Orbs").transform;
			transform.SetParent(base.transform, worldPositionStays: false);
			InstantiateParameters parameters = new InstantiateParameters
			{
				parent = transform,
				worldSpace = false
			};
			float valueFloat = base.Data.Settings.GetValueFloat("OrbSize", 1f);
			for (int i = 0; i < _orbSyncData.Length; i++)
			{
				OrbSyncData orbSyncData = _orbSyncData[i];
				OrbScript orbScript = UnityEngine.Object.Instantiate(_orbPrefab, orbSyncData.Position, Quaternion.identity, parameters);
				orbScript.Initialize(this, i, valueFloat);
				_orbs.Add(orbScript);
			}
		}

		private void UpdatePendingOrbTheftNotifications(float deltaTime)
		{
			if (_pendingOrbTheftNotifications.Count == 0)
			{
				return;
			}
			CollectionPool<List<KeyValuePair<(int, int), (int, float)>>, KeyValuePair<(int, int), (int, float)>>.Get(out var value);
			value.AddRange(_pendingOrbTheftNotifications);
			foreach (KeyValuePair<(int, int), (int, float)> item in value)
			{
				(int, int) key = item.Key;
				(int, float) value2 = item.Value;
				value2.Item2 -= deltaTime;
				if (value2.Item2 <= 0f)
				{
					NetworkedActivityPlayer player = GetPlayer(key.Item1);
					NetworkedActivityPlayer player2 = GetPlayer(key.Item2);
					if (player != null && player2 != null)
					{
						string message = ((value2.Item1 == 1) ? (player2.Name + " stole an orb from " + player.Name + "!") : $"{player2.Name} stole {value2.Item1} orbs from {player.Name}!");
						FlightSceneScript.Instance.FlightUI.ShowMessage(message, 7f, highlighted: true);
					}
					_pendingOrbTheftNotifications.Remove(key);
				}
				else
				{
					_pendingOrbTheftNotifications[key] = value2;
				}
			}
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EOrbSnatcher_002EOrbSnatcherActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EOrbSnatcher_002EOrbSnatcherActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(42u, RpcReader___Observers_ChangeOrbOwnerClientRpc___1805552400);
				RegisterServerRpc(43u, RpcReader___Server_ChangeOrbOwnerServerRpc___3218483375);
				RegisterObserversRpc(44u, RpcReader___Observers_DeactivateOrbClientRpc___1692629761);
				RegisterServerRpc(45u, RpcReader___Server_DeactivateOrbServerRpc___3316948804);
				RegisterTargetRpc(46u, RpcReader___Target_ProcessOrbSyncDataClientRpc___3263673867);
				RegisterServerRpc(47u, RpcReader___Server_ProcessOrbSyncDataServerRpc___1695994506);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EOrbSnatcher_002EOrbSnatcherActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EOrbSnatcher_002EOrbSnatcherActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Observers_ChangeOrbOwnerClientRpc___1805552400(int orbId, int playerId, int ownerId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(orbId);
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteInt32(ownerId);
			SendObserversRpc(42u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeOrbOwnerClientRpc___1805552400(int P_0, int P_1, int P_2)
		{
			using (Profile.ChangeOrbOwnerClientRpc.Auto())
			{
				ChangeOrbOwnerLocal(P_0, P_1, P_2);
			}
		}

		private void RpcReader___Observers_ChangeOrbOwnerClientRpc___1805552400(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			int num3 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ChangeOrbOwnerClientRpc___1805552400(num, num2, num3);
			}
		}

		private void RpcWriter___Server_ChangeOrbOwnerServerRpc___3218483375(int orbId, int playerId, int ownerId, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(orbId);
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteInt32(ownerId);
			SendServerRpc(43u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeOrbOwnerServerRpc___3218483375(int P_0, int P_1, int P_2, NetworkConnection P_3)
		{
			using (Profile.ChangeOrbOwnerServerRpc.Auto())
			{
				if (base.IsServerStarted)
				{
					ChangeOrbOwnerClientRpc(P_0, P_1, P_2);
				}
			}
		}

		private void RpcReader___Server_ChangeOrbOwnerServerRpc___3218483375(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			int num3 = PooledReader0.ReadInt32();
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___ChangeOrbOwnerServerRpc___3218483375(num, num2, num3, conn);
			}
		}

		private void RpcWriter___Observers_DeactivateOrbClientRpc___1692629761(int orbId, int ownerId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(orbId);
			pooledWriter.WriteInt32(ownerId);
			SendObserversRpc(44u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___DeactivateOrbClientRpc___1692629761(int P_0, int P_1)
		{
			using (Profile.DeactivateOrbClientRpc.Auto())
			{
				if (P_0 < 0 || P_0 >= _orbSyncData.Length || P_0 >= _orbs.Count)
				{
					Debug.LogError($"Invalid orb id {P_0} in DeactivateOrbServerRpc.");
					return;
				}
				OrbScript orbScript = _orbs[P_0];
				OrbSyncData obj = _orbSyncData[P_0];
				obj.IsActive = false;
				obj.PlayerId = -1;
				obj.OwnerId = P_1;
				orbScript.OnOrbOwnerChanged(null);
				orbScript.gameObject.SetActive(value: false);
			}
		}

		private void RpcReader___Observers_DeactivateOrbClientRpc___1692629761(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___DeactivateOrbClientRpc___1692629761(num, num2);
			}
		}

		private void RpcWriter___Server_DeactivateOrbServerRpc___3316948804(int orbId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(orbId);
			SendServerRpc(45u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___DeactivateOrbServerRpc___3316948804(int P_0)
		{
			using (Profile.DeactivateOrbServerRpc.Auto())
			{
				if (base.IsServerStarted)
				{
					DeactivateOrbClientRpc(P_0, base.LocalConnection.ClientId);
				}
			}
		}

		private void RpcReader___Server_DeactivateOrbServerRpc___3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___DeactivateOrbServerRpc___3316948804(num);
			}
		}

		private void RpcWriter___Target_ProcessOrbSyncDataClientRpc___3263673867(NetworkConnection client, ArraySegment<byte> data, int sourceClientId, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			pooledWriter.WriteInt32(sourceClientId);
			SendTargetRpc(46u, pooledWriter, channel2, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ProcessOrbSyncDataClientRpc___3263673867(NetworkConnection P_0, ArraySegment<byte> P_1, int P_2, Channel P_3)
		{
			using (Profile.ProcessOrbSyncDataClientRpc.Auto())
			{
				if (P_0 != base.LocalConnection)
				{
					return;
				}
				using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(P_1);
				PooledReader reader = pooledReaderDisposableWrapper.Reader;
				float num = reader.ReadSingleUnpacked();
				bool flag = num > _lastPhysicsTime;
				float physicsTimeDelta = (flag ? (FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime - num) : 0f);
				_lastPhysicsTime = num;
				int num2 = reader.ReadInt32();
				for (int i = 0; i < num2; i++)
				{
					int num3 = reader.ReadInt32();
					OrbScript orb = _orbs[num3];
					OrbSyncData orbSyncData = _orbSyncData[num3];
					if (orbSyncData.OwnerId == P_2)
					{
						orbSyncData.ReadTickData(reader);
						if (flag)
						{
							ProcessOrbUpdate(orb, physicsTimeDelta, orbSyncData.Position, orbSyncData.Velocity);
						}
					}
					else
					{
						orbSyncData.DiscardTickData(reader);
					}
				}
			}
		}

		private void RpcReader___Target_ProcessOrbSyncDataClientRpc___3263673867(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ProcessOrbSyncDataClientRpc___3263673867(base.LocalConnection, arraySegment, num, channel);
			}
		}

		private void RpcWriter___Server_ProcessOrbSyncDataServerRpc___1695994506(ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(47u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ProcessOrbSyncDataServerRpc___1695994506(ArraySegment<byte> P_0, Channel P_1, NetworkConnection P_2)
		{
			using (Profile.ProcessOrbSyncDataServerRpc.Auto())
			{
				if (!base.IsServerStarted)
				{
					return;
				}
				foreach (NetworkConnection observer in base.Observers)
				{
					if (observer.ClientId != P_2.ClientId)
					{
						ProcessOrbSyncDataClientRpc(observer, P_0, P_2.ClientId, P_1);
					}
				}
			}
		}

		private void RpcReader___Server_ProcessOrbSyncDataServerRpc___1695994506(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___ProcessOrbSyncDataServerRpc___1695994506(arraySegment, channel, conn);
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
