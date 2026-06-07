using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.WorldObjects;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using Assets.Scripts.Multiplayer.ObserverConditions;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Observing;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(NetworkObserver))]
	public class NetworkFlightObject : NetworkBehaviour
	{
		[Flags]
		protected enum DebugLogFlags
		{
			None = 0,
			NetworkBehaviourCallbacks = 1,
			OwnerChanges = 2,
			Initialization = 4,
			Despawning = 8,
			All = 0xF
		}

		[Flags]
		protected enum SyncFlags : byte
		{
			None = 0,
			Position = 1,
			Rotation = 2,
			Scale = 4
		}

		private static class Profile
		{
			public static readonly ProfilerMarker OnPostTickOwner = new ProfilerMarker("NetworkFlightObject.OnPostTickOwner");

			public static readonly ProfilerMarker OnPostTickServer = new ProfilerMarker("NetworkFlightObject.OnPostTickServer");
		}

		private class ResettableObject : FlightSceneResettableObjectBase
		{
			private readonly string _dynamicStartLocationId;

			public ResettableObject(int uniqueId, string displayName, float? resetTime, string dynamicStartLocationId)
				: base(uniqueId, displayName, resetTime)
			{
				_dynamicStartLocationId = dynamicStartLocationId;
			}

			public override void ResetObject()
			{
				NetworkFlightObjectManager flightObjectsManager = FlightSceneScript.Instance.FlightSceneNetwork.FlightObjectsManager;
				NetworkFlightObject flightObjectByID = flightObjectsManager.GetFlightObjectByID(base.UniqueId);
				if (flightObjectByID != null)
				{
					flightObjectByID.DespawnObject();
				}
				flightObjectsManager.SetObjectSpawnEnabledState(base.UniqueId, enabled: true);
				if (_dynamicStartLocationId != null)
				{
					FlightSceneScript.Instance.StartLocationManager.SetDynamicLocationUnavailable(_dynamicStartLocationId, unavailable: false);
				}
			}
		}

		private List<SortedList<int, ArraySegment<byte>>> _bufferedObserverRpcs;

		private PooledWriter _bufferedRpcInitialize;

		private PooledWriter _bufferedRpcUpdateState;

		private List<NetworkFlightObjectComponent> _components;

		private bool _despawned;

		[SerializeField]
		private bool _handleFloatingOrigin;

		private bool _initialized;

		[SerializeField]
		private DebugLogFlags _logFlags;

		private NetworkFlightObjectManager _manager;

		private int _nonOwnerPostTickCount;

		private bool _serverChangeOwnerOrDespawnPending;

		private bool _serverIsDespawning;

		private ObserverCondition _serverObserverCondition;

		private int _serverOwnerChangedFrameCount;

		[SerializeField]
		private SyncFlags _syncConfig;

		private Transform _transform;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObjectGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObjectGame_002Edll_Excuted;

		public IReadOnlyList<NetworkFlightObjectComponent> Components => _components;

		public bool Initialized => _initialized;

		public IReadOnlyDictionary<string, string> SpawnData { get; private set; }

		public Transform Transform => _transform;

		public int UniqueID { get; private set; }

		protected string DebugLogObjectName => $"{Time.frameCount}: NetworkFlightObject '{base.name}' ({base.ObjectId})";

		protected DebugLogFlags LoggingFlags
		{
			get
			{
				return _logFlags;
			}
			set
			{
				_logFlags = value;
			}
		}

		protected SyncFlags SyncConfig => _syncConfig;

		public event EventHandler<NetworkFlightObjectEventArgs> LocalClientInitialized;

		public void DespawnObject()
		{
			if (base.IsServerStarted)
			{
				DespawnObjectAsServer();
			}
			else
			{
				DespawnObjectServerRpc();
			}
		}

		[ServerRpc(RequireOwnership = false)]
		public void DespawnObjectServerRpc()
		{
			RpcWriter___Server_DespawnObjectServerRpc___2166136261();
		}

		public T GetNetworkFlightObjectComponent<T>() where T : NetworkFlightObjectComponent
		{
			foreach (NetworkFlightObjectComponent component in _components)
			{
				if (component is T result)
				{
					return result;
				}
			}
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		public void GiveOwnershipToClient(NetworkConnection newOwner)
		{
			RpcWriter___Server_GiveOwnershipToClient___328543758(newOwner);
		}

		public override void OnOwnershipClient(NetworkConnection prevOwner)
		{
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnOwnershipClient: " + prevOwner.GetPlayerNameAndId() + " --> " + base.Owner.GetPlayerNameAndId());
			}
			if (prevOwner.IsLocalClient)
			{
				base.TimeManager.OnPostTick -= OnPostTickOwner;
			}
			if (base.IsOwner)
			{
				base.TimeManager.OnPostTick += OnPostTickOwner;
			}
			foreach (NetworkFlightObjectComponent component in _components)
			{
				component.OnOwnershipChanged(base.IsOwner);
			}
		}

		public override void OnOwnershipServer(NetworkConnection prevOwner)
		{
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnOwnershipServer: " + prevOwner.GetPlayerNameAndId() + " --> " + base.Owner.GetPlayerNameAndId());
			}
			_serverChangeOwnerOrDespawnPending = false;
			_serverOwnerChangedFrameCount = Time.frameCount;
			if (prevOwner.IsLocalClient)
			{
				base.TimeManager.OnPostTick -= OnPostTickOwner;
			}
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
			base.OnSpawnServer(connection);
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnSpawnServer: " + connection.GetPlayerNameAndId());
			}
			if (connection.IsLocalClient && _initialized)
			{
				return;
			}
			using (PooledWriterDisposableWrapper pooledWriterDisposableWrapper = this.GetPooledWriter())
			{
				ArraySegment<byte> spawnData = _bufferedRpcInitialize?.GetArraySegment() ?? ArraySegment<byte>.Empty;
				pooledWriterDisposableWrapper.Writer.WriteVector3(Utility.ConvertFloatingOriginToAbsolutePosition(_transform.position));
				pooledWriterDisposableWrapper.Writer.WriteQuaternion32(_transform.rotation);
				foreach (NetworkFlightObjectComponent component in _components)
				{
					component.WriteStateInitializationData(pooledWriterDisposableWrapper);
				}
				ArraySegment<byte> arraySegment = pooledWriterDisposableWrapper.Writer.GetArraySegment();
				RpcClientInitialize(connection, UniqueID, spawnData, arraySegment);
			}
			if (_bufferedRpcUpdateState != null && base.Owner != connection)
			{
				RpcNfoUpdateStateClient(connection, _bufferedRpcUpdateState.GetArraySegment(), Channel.Reliable);
			}
			List<SortedList<int, ArraySegment<byte>>> bufferedObserverRpcs = _bufferedObserverRpcs;
			if (bufferedObserverRpcs == null || bufferedObserverRpcs.Count <= 0 || !(base.Owner != connection))
			{
				return;
			}
			for (int i = 0; i < _bufferedObserverRpcs.Count; i++)
			{
				foreach (KeyValuePair<int, ArraySegment<byte>> item in _bufferedObserverRpcs[i])
				{
					ComponentRpcClient(connection, (byte)i, item.Value);
				}
			}
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnStartClient");
			}
			foreach (NetworkFlightObjectComponent component in _components)
			{
				component.OnStartClient();
			}
		}

		public override void OnStartServer()
		{
			base.OnStartServer();
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnStartServer");
			}
			base.TimeManager.OnPostTick += OnPostTickServer;
			base.ServerManager.Objects.OnPreDestroyClientObjects += OnPreDestroyClientObjects;
			base.NetworkObject.OnHostVisibilityUpdated += OnHostVisibilityUpdated;
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnStopClient");
			}
			if (base.IsOwner)
			{
				base.TimeManager.OnPostTick -= OnPostTickOwner;
			}
			if (!base.IsServerStarted)
			{
				OnDespawn();
			}
		}

		public override void OnStopServer()
		{
			base.OnStopServer();
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(DebugLogObjectName + ": OnStopServer");
			}
			if (base.IsOwner)
			{
				base.TimeManager.OnPostTick -= OnPostTickOwner;
			}
			base.TimeManager.OnPostTick -= OnPostTickServer;
			base.ServerManager.Objects.OnPreDestroyClientObjects -= OnPreDestroyClientObjects;
			base.NetworkObject.OnHostVisibilityUpdated -= OnHostVisibilityUpdated;
			OnDespawn();
		}

		[ServerRpc(RunLocally = true, RequireOwnership = false)]
		public void RegisterResettableObject(string displayName, float? resetTime, string dynamicStartLocationId)
		{
			RpcWriter___Server_RegisterResettableObject___4231399037(displayName, resetTime, dynamicStartLocationId);
			RpcLogic___RegisterResettableObject___4231399037(displayName, resetTime, dynamicStartLocationId);
		}

		public void SendComponentRpcObservers(NetworkFlightObjectComponent component, ArraySegment<byte> data, bool excludeOwner = false, bool runLocally = false, int? bufferedRpcId = null, Channel channel = Channel.Reliable)
		{
			SendComponentRpcClient(component, data, null, excludeOwner, runLocally, bufferedRpcId, channel);
		}

		public void SendComponentRpcOwner(NetworkFlightObjectComponent component, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			SendComponentRpcClient(component, data, base.Owner, excludeOwner: false, runLocally: false, null, channel);
		}

		public void SendComponentRpcServer(NetworkFlightObjectComponent component, ArraySegment<byte> data, bool runLocally = false, Channel channel = Channel.Reliable)
		{
			int num = _components.IndexOf(component);
			if (num == -1)
			{
				throw new Exception("Unable to send a server component RPC for a network flight object because the component could not be found." + System.Environment.NewLine + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Component: " + (component?.name ?? "null") + " (" + (component?.GetType().FullName ?? "null") + ")");
			}
			if (num > 255)
			{
				throw new Exception($"Unable to send a server component RPC for a network flight object because the component index is greater than {byte.MaxValue}.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Component: " + (component?.name ?? "null") + " (" + (component?.GetType().FullName ?? "null") + ")");
			}
			if (runLocally)
			{
				ComponentRpcServerAndLocal((byte)num, data, channel);
			}
			else
			{
				ComponentRpcServer((byte)num, data, channel);
			}
		}

		public void SendComponentRpcTarget(NetworkFlightObjectComponent component, ArraySegment<byte> data, NetworkConnection target, Channel channel = Channel.Reliable)
		{
			SendComponentRpcClient(component, data, target, excludeOwner: false, runLocally: false, null, channel);
		}

		public void ServerInitialize(ArraySegment<byte> data, IDictionary<string, string> keyValuePairData, int uniqueId)
		{
			if (!Game.Instance.NetworkGameManager.LocalPlayer.IsServerStarted)
			{
				Debug.LogError("ServerInitialize should only be called by the server");
				return;
			}
			UniqueID = uniqueId;
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = this.GetPooledWriter();
			if (keyValuePairData == null)
			{
				pooledWriterDisposableWrapper.Writer.WriteUInt8Unpacked(0);
			}
			else
			{
				pooledWriterDisposableWrapper.Writer.WriteUInt8Unpacked((byte)keyValuePairData.Count);
				foreach (KeyValuePair<string, string> keyValuePairDatum in keyValuePairData)
				{
					pooledWriterDisposableWrapper.Writer.WriteString(keyValuePairDatum.Key);
					pooledWriterDisposableWrapper.Writer.WriteString(keyValuePairDatum.Value);
				}
			}
			if (data != null && data.Count > 0)
			{
				pooledWriterDisposableWrapper.Writer.WriteArraySegment(data);
			}
			ArraySegment<byte> arraySegment = pooledWriterDisposableWrapper.Writer.GetArraySegment();
			_bufferedRpcInitialize = WriterPool.Retrieve(arraySegment.Count);
			_bufferedRpcInitialize.WriteArraySegment(arraySegment);
		}

		public void SetObjectSpawnEnabledState(bool enabled)
		{
			if (UniqueID != 0)
			{
				_manager.SetObjectSpawnEnabledState(UniqueID, enabled);
			}
			else
			{
				Debug.LogError(DebugLogObjectName + ": Unable to disable the spawner because the object's Unique ID is zero.");
			}
		}

		[ServerRpc(RunLocally = true, RequireOwnership = false)]
		public void UnregisterResettableObject()
		{
			RpcWriter___Server_UnregisterResettableObject___2166136261();
			RpcLogic___UnregisterResettableObject___2166136261();
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObject_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void OnDespawn()
		{
			if (!_despawned)
			{
				_despawned = true;
				if (_logFlags.HasFlag(DebugLogFlags.Despawning))
				{
					Debug.Log(DebugLogObjectName + ": OnDespawn");
				}
				if ((object)FloatingOriginScript.Instance != null)
				{
					FloatingOriginScript.Instance.Repositioned -= FloatingOriginChanged;
				}
				_manager.OnObjectDespawned(this);
				_bufferedRpcInitialize?.Store();
				_bufferedRpcInitialize = null;
				_bufferedRpcUpdateState?.Store();
				_bufferedRpcUpdateState = null;
			}
		}

		protected virtual void OnDestroy()
		{
			OnDespawn();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
		}

		private void BufferRpc(byte componentIndex, int bufferedRpcId, ArraySegment<byte> data)
		{
			if (_bufferedObserverRpcs == null)
			{
				_bufferedObserverRpcs = new List<SortedList<int, ArraySegment<byte>>>(_components.Count).Fill();
			}
			ArraySegment<byte> value = new ArraySegment<byte>(data.ToArray());
			_bufferedObserverRpcs[componentIndex][bufferedRpcId] = value;
		}

		[ContextMenu("Change Owner or Despawn")]
		private void ChangeOwnerOrDespawn()
		{
			if (!base.IsServerStarted)
			{
				Debug.LogError("ChangeOwnerOrDespawn should only be called by the server");
			}
			else
			{
				if (_serverChangeOwnerOrDespawnPending)
				{
					return;
				}
				_serverChangeOwnerOrDespawnPending = true;
				NetworkConnection owner = base.NetworkObject.Owner;
				NetworkConnection networkConnection = null;
				float num = float.MaxValue;
				Vector3 position = base.transform.position;
				foreach (NetworkConnection observer in base.Observers)
				{
					if (observer == owner || observer.Disconnecting)
					{
						continue;
					}
					if (observer.IsHost)
					{
						networkConnection = observer;
						break;
					}
					Vector3? vector = observer.GetPlayer()?.FlightScenePlayer?.FramePosition;
					if (vector.HasValue)
					{
						float num2 = Vector3.SqrMagnitude(vector.Value - position);
						if (num2 < num)
						{
							num = num2;
							networkConnection = observer;
						}
					}
				}
				if (networkConnection != null)
				{
					if (_logFlags.HasFlag(DebugLogFlags.OwnerChanges))
					{
						Debug.Log(DebugLogObjectName + ": Changing Ownership: " + owner.GetPlayerNameAndId() + " --> " + networkConnection.GetPlayerNameAndId());
					}
					GiveOwnership(networkConnection);
				}
				else
				{
					if (_logFlags.HasFlag(DebugLogFlags.Despawning))
					{
						Debug.Log(DebugLogObjectName + ": Despawning (no observers)");
					}
					_serverIsDespawning = true;
					Despawn(base.gameObject);
				}
			}
		}

		[TargetRpc]
		[ObserversRpc(ExcludeOwner = false)]
		private void ComponentRpcClient(NetworkConnection target, byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if ((object)target == null)
			{
				RpcWriter___Observers_ComponentRpcClient___3759040387(target, componentIndex, data, channel);
			}
			else
			{
				RpcWriter___Target_ComponentRpcClient___3759040387(target, componentIndex, data, channel);
			}
		}

		[TargetRpc(RunLocally = true)]
		[ObserversRpc(ExcludeOwner = false, RunLocally = true)]
		private void ComponentRpcClientAndLocal(NetworkConnection target, byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if ((object)target == null)
			{
				RpcWriter___Observers_ComponentRpcClientAndLocal___3759040387(target, componentIndex, data, channel);
				RpcLogic___ComponentRpcClientAndLocal___3759040387(target, componentIndex, data, channel);
			}
			else
			{
				RpcWriter___Target_ComponentRpcClientAndLocal___3759040387(target, componentIndex, data, channel);
				RpcLogic___ComponentRpcClientAndLocal___3759040387(target, componentIndex, data, channel);
			}
		}

		[ObserversRpc(ExcludeOwner = true, RunLocally = true)]
		private void ComponentRpcClientAndLocalExcludingOwner(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			RpcWriter___Observers_ComponentRpcClientAndLocalExcludingOwner___3854340310(componentIndex, data, channel);
			RpcLogic___ComponentRpcClientAndLocalExcludingOwner___3854340310(componentIndex, data, channel);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void ComponentRpcClientExcludingOwner(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			RpcWriter___Observers_ComponentRpcClientExcludingOwner___3854340310(componentIndex, data, channel);
		}

		[ServerRpc(RequireOwnership = false)]
		private void ComponentRpcServer(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			RpcWriter___Server_ComponentRpcServer___2558193021(componentIndex, data, channel, sender);
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		private void ComponentRpcServerAndLocal(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			RpcWriter___Server_ComponentRpcServerAndLocal___2558193021(componentIndex, data, channel, sender);
			RpcLogic___ComponentRpcServerAndLocal___2558193021(componentIndex, data, channel, sender);
		}

		[ServerRpc(RequireOwnership = false)]
		private void ComponentRpcServerRelay(NetworkConnection target, bool excludeOwner, byte componentIndex, ArraySegment<byte> data, int? bufferedRpcId = null, Channel channel = Channel.Reliable)
		{
			RpcWriter___Server_ComponentRpcServerRelay___3995766794(target, excludeOwner, componentIndex, data, bufferedRpcId, channel);
		}

		[ContextMenu("Log Observers")]
		private void DebugLogObservers()
		{
			Debug.Log(string.Format("{0} Observers ({1}):\n  {2}", DebugLogObjectName, base.Observers.Count, string.Join("\n  ", base.Observers.Select((NetworkConnection x) => x.GetPlayerNameAndId()))));
		}

		[ContextMenu("Log Owner")]
		private void DebugLogOwner()
		{
			Debug.Log(DebugLogObjectName + " Owner: " + base.Owner.GetPlayerNameAndId());
		}

		private void DespawnObjectAsServer()
		{
			if (!base.IsServerStarted)
			{
				Debug.LogError("DespawnObjectAsServer should only be called on the server");
			}
			else if (!_serverIsDespawning)
			{
				if (_logFlags.HasFlag(DebugLogFlags.Despawning))
				{
					Debug.Log(DebugLogObjectName + ": Despawning");
				}
				_serverIsDespawning = true;
				Despawn(base.gameObject);
			}
		}

		private void FloatingOriginChanged(object sender, FloatingOriginUpdatedEventArgs e)
		{
			_transform.position -= e.Delta;
		}

		private void InitializeLocalClient(int uniqueId, ArraySegment<byte> spawnData, ArraySegment<byte> stateData)
		{
			if (_initialized)
			{
				Debug.LogError(DebugLogObjectName + ": Attempted to initialized a network flight object that was already initialized.");
				return;
			}
			if (_logFlags.HasFlag(DebugLogFlags.Initialization))
			{
				Debug.Log(string.Format("{0}: {1}: Data Length = {2}, {3}", DebugLogObjectName, "InitializeLocalClient", spawnData.Count, stateData.Count));
			}
			UniqueID = uniqueId;
			using (PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(spawnData))
			{
				using PooledReaderDisposableWrapper pooledReaderDisposableWrapper2 = this.GetPooledReader(stateData);
				Vector3 position = Utility.ConvertAbsoluteToFloatingOriginPosition(pooledReaderDisposableWrapper2.Reader.ReadVector3());
				Quaternion rotation = pooledReaderDisposableWrapper2.Reader.ReadQuaternion32();
				_transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
				_transform.SetPositionAndRotation(position, rotation);
				Dictionary<string, string> dictionary = (Dictionary<string, string>)(SpawnData = new Dictionary<string, string>());
				int num = ((spawnData.Count > 0) ? pooledReaderDisposableWrapper.Reader.ReadUInt8Unpacked() : 0);
				for (int i = 0; i < num; i++)
				{
					string key = pooledReaderDisposableWrapper.Reader.ReadStringAllocated();
					string value = pooledReaderDisposableWrapper.Reader.ReadStringAllocated();
					dictionary.Add(key, value);
				}
				_manager.OnObjectSpawning(this);
				_initialized = true;
				foreach (NetworkFlightObjectComponent component in _components)
				{
					component.Initialize(pooledReaderDisposableWrapper, pooledReaderDisposableWrapper2);
				}
			}
			this.LocalClientInitialized?.Invoke(this, new NetworkFlightObjectEventArgs(this));
			_manager.OnObjectSpawned(this);
		}

		private void OnHostVisibilityUpdated(bool prevVisible, bool nextVisible)
		{
			if (_logFlags.HasFlag(DebugLogFlags.NetworkBehaviourCallbacks))
			{
				Debug.Log(string.Format("{0}: {1}({2}, {3})", DebugLogObjectName, "OnHostVisibilityUpdated", prevVisible, nextVisible));
			}
		}

		private void OnPostTickOwner()
		{
			using (Profile.OnPostTickOwner.Auto())
			{
				if (!_initialized || _serverIsDespawning)
				{
					return;
				}
				if (this == null)
				{
					Debug.LogError("OnPostTickOwner running on a destroyed network flight object");
					return;
				}
				if (!base.IsOwner)
				{
					_nonOwnerPostTickCount++;
					if (_nonOwnerPostTickCount == 2 || _nonOwnerPostTickCount % 100 == 0)
					{
						Debug.LogError("NetworkFlightObject.OnPostTickOwner is executing on object " + $"{base.name} ({base.ObjectId}) when the client ({base.LocalConnection.ClientId}) is not currently the owner ({base.OwnerId}).", base.gameObject);
					}
					return;
				}
				_nonOwnerPostTickCount = 0;
				using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = this.GetPooledWriter();
				PooledWriter writer = pooledWriterDisposableWrapper.Writer;
				writer.WriteUInt8Unpacked((byte)_syncConfig);
				if (_syncConfig.HasFlag(SyncFlags.Position))
				{
					writer.WriteVector3(Utility.ConvertFloatingOriginToAbsolutePosition(_transform.position));
				}
				if (_syncConfig.HasFlag(SyncFlags.Rotation))
				{
					writer.WriteVector3(_transform.eulerAngles);
				}
				if (_syncConfig.HasFlag(SyncFlags.Scale))
				{
					writer.WriteVector3(_transform.localScale);
				}
				foreach (NetworkFlightObjectComponent component in _components)
				{
					WriteComponentState(component, writer);
				}
				RpcNfoUpdateStateServer(writer.GetArraySegment());
			}
		}

		private void OnPostTickServer()
		{
			using (Profile.OnPostTickServer.Auto())
			{
				if (!_initialized || _serverChangeOwnerOrDespawnPending || _serverOwnerChangedFrameCount == Time.frameCount)
				{
					return;
				}
				if (this == null)
				{
					Debug.LogError("OnPostTickServer running on a destroyed network flight object");
					return;
				}
				if ((object)_serverObserverCondition == null)
				{
					_serverObserverCondition = base.NetworkObserver.GetObserverCondition<DistanceFromPlayerObserverCondition>();
				}
				if (_serverObserverCondition != null && !_serverObserverCondition.ConditionMet(base.Owner, currentlyAdded: true, out var _))
				{
					ChangeOwnerOrDespawn();
				}
			}
		}

		private void OnPreDestroyClientObjects(NetworkConnection connection)
		{
			if (base.LocalConnection.ClientId != -1 && base.Owner == connection)
			{
				ChangeOwnerOrDespawn();
			}
		}

		private void ProcessComponentRpcClient(byte componentIndex, ArraySegment<byte> data)
		{
			if (componentIndex > _components.Count)
			{
				Debug.LogError($"Received a client component RPC but was unable to process it because the component with index '{componentIndex}' could not be found.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine);
				return;
			}
			NetworkFlightObjectComponent networkFlightObjectComponent = _components[componentIndex];
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(data);
			networkFlightObjectComponent.ReceiveClientRpc(pooledReaderDisposableWrapper);
		}

		private void ReadComponentState(NetworkFlightObjectComponent component, PooledReader reader)
		{
			ushort num = reader.ReadUInt16Unpacked();
			int position = reader.Position;
			component.ReadState(reader);
			int num2 = reader.Position - position;
			if (num2 < num)
			{
				reader.Position = position + num;
			}
			else if (num2 > num)
			{
				Debug.LogError($"A component on a network flight object tried to read more state data bytes than were available to be read ({num2} read, {num} expected).{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Component: " + (component?.name ?? "null") + " (" + (component?.GetType().FullName ?? "null") + ")");
			}
		}

		[TargetRpc]
		private void RpcClientInitialize(NetworkConnection connection, int uniqueId, ArraySegment<byte> spawnData, ArraySegment<byte> stateData, Channel channel = Channel.Reliable)
		{
			RpcWriter___Target_RpcClientInitialize___1484083726(connection, uniqueId, spawnData, stateData, channel);
		}

		[TargetRpc]
		[ObserversRpc(ExcludeOwner = true, LatestOnly = true)]
		private void RpcNfoUpdateStateClient(NetworkConnection connection, ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			if ((object)connection == null)
			{
				RpcWriter___Observers_RpcNfoUpdateStateClient___748863190(connection, data, channel);
			}
			else
			{
				RpcWriter___Target_RpcNfoUpdateStateClient___748863190(connection, data, channel);
			}
		}

		[ServerRpc]
		private void RpcNfoUpdateStateServer(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			RpcWriter___Server_RpcNfoUpdateStateServer___2713644489(data, channel);
		}

		private void SendComponentRpcClient(NetworkFlightObjectComponent component, ArraySegment<byte> data, NetworkConnection target, bool excludeOwner, bool runLocally = false, int? bufferedRpcId = null, Channel channel = Channel.Reliable)
		{
			int num = _components.IndexOf(component);
			if (num == -1)
			{
				throw new Exception("Unable to send a client component RPC for a network flight object because the component could not be found." + System.Environment.NewLine + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Component: " + (component?.name ?? "null") + " (" + (component?.GetType().FullName ?? "null") + ")");
			}
			if (num > 255)
			{
				throw new Exception($"Unable to send a client component RPC for a network flight object because the component index is greater than {byte.MaxValue}.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Component: " + (component?.name ?? "null") + " (" + (component?.GetType().FullName ?? "null") + ")");
			}
			if (base.IsServerStarted)
			{
				if (bufferedRpcId.HasValue)
				{
					BufferRpc((byte)num, bufferedRpcId.Value, data);
				}
				if (runLocally)
				{
					if (excludeOwner)
					{
						ComponentRpcClientAndLocalExcludingOwner((byte)num, data, channel);
					}
					else
					{
						ComponentRpcClientAndLocal(target, (byte)num, data, channel);
					}
				}
				else if (excludeOwner)
				{
					ComponentRpcClientExcludingOwner((byte)num, data, channel);
				}
				else
				{
					ComponentRpcClient(target, (byte)num, data, channel);
				}
			}
			else
			{
				if (runLocally)
				{
					throw new NotSupportedException("Cannot send a client targeted RPC from another client with the 'runLocally' option.");
				}
				ComponentRpcServerRelay(target, excludeOwner, (byte)num, data, bufferedRpcId, channel);
			}
		}

		private void UpdateLocalState(ArraySegment<byte> data)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(data);
			PooledReader reader = pooledReaderDisposableWrapper.Reader;
			_syncConfig = (SyncFlags)reader.ReadUInt8Unpacked();
			if (_syncConfig.HasFlag(SyncFlags.Position))
			{
				_transform.position = Utility.ConvertAbsoluteToFloatingOriginPosition(reader.ReadVector3());
			}
			if (_syncConfig.HasFlag(SyncFlags.Rotation))
			{
				_transform.eulerAngles = reader.ReadVector3();
			}
			if (_syncConfig.HasFlag(SyncFlags.Scale))
			{
				_transform.localScale = reader.ReadVector3();
			}
			foreach (NetworkFlightObjectComponent component in _components)
			{
				ReadComponentState(component, reader);
			}
		}

		private void WriteComponentState(NetworkFlightObjectComponent component, PooledWriter writer)
		{
			int position = writer.Position;
			writer.WriteUInt16Unpacked(0);
			component.WriteState(writer);
			int position2 = writer.Position;
			int num = position2 - (position + 2);
			if (num > 65535)
			{
				Debug.LogError($"A component on a network flight object tried to write more state data than its limit of {ushort.MaxValue} bytes.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine + "Component: " + (component?.name ?? "null") + " (" + (component?.GetType().FullName ?? "null") + ")");
			}
			writer.Position = position;
			writer.WriteUInt16Unpacked((ushort)num);
			writer.Position = position2;
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObjectGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObjectGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterServerRpc(0u, RpcReader___Server_DespawnObjectServerRpc___2166136261);
				RegisterServerRpc(1u, RpcReader___Server_GiveOwnershipToClient___328543758);
				RegisterServerRpc(2u, RpcReader___Server_RegisterResettableObject___4231399037);
				RegisterServerRpc(3u, RpcReader___Server_UnregisterResettableObject___2166136261);
				RegisterTargetRpc(4u, RpcReader___Target_ComponentRpcClient___3759040387);
				RegisterObserversRpc(5u, RpcReader___Observers_ComponentRpcClient___3759040387);
				RegisterTargetRpc(6u, RpcReader___Target_ComponentRpcClientAndLocal___3759040387);
				RegisterObserversRpc(7u, RpcReader___Observers_ComponentRpcClientAndLocal___3759040387);
				RegisterObserversRpc(8u, RpcReader___Observers_ComponentRpcClientAndLocalExcludingOwner___3854340310);
				RegisterObserversRpc(9u, RpcReader___Observers_ComponentRpcClientExcludingOwner___3854340310);
				RegisterServerRpc(10u, RpcReader___Server_ComponentRpcServer___2558193021);
				RegisterServerRpc(11u, RpcReader___Server_ComponentRpcServerAndLocal___2558193021);
				RegisterServerRpc(12u, RpcReader___Server_ComponentRpcServerRelay___3995766794);
				RegisterTargetRpc(13u, RpcReader___Target_RpcClientInitialize___1484083726);
				RegisterTargetRpc(14u, RpcReader___Target_RpcNfoUpdateStateClient___748863190);
				RegisterObserversRpc(15u, RpcReader___Observers_RpcNfoUpdateStateClient___748863190);
				RegisterServerRpc(16u, RpcReader___Server_RpcNfoUpdateStateServer___2713644489);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObjectGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObjectGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_DespawnObjectServerRpc___2166136261()
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___DespawnObjectServerRpc___2166136261()
		{
			DespawnObjectAsServer();
		}

		private void RpcReader___Server_DespawnObjectServerRpc___2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___DespawnObjectServerRpc___2166136261();
			}
		}

		private void RpcWriter___Server_GiveOwnershipToClient___328543758(NetworkConnection newOwner)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(newOwner);
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___GiveOwnershipToClient___328543758(NetworkConnection P_0)
		{
			GiveOwnership(P_0);
		}

		private void RpcReader___Server_GiveOwnershipToClient___328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			if (base.IsServerInitialized)
			{
				RpcLogic___GiveOwnershipToClient___328543758(networkConnection);
			}
		}

		private void RpcWriter___Server_RegisterResettableObject___4231399037(string displayName, float? resetTime, string dynamicStartLocationId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(displayName);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002ESingle_003EFishNet_002ESerializing_002EGenerated(pooledWriter, resetTime);
			pooledWriter.WriteString(dynamicStartLocationId);
			SendServerRpc(2u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___RegisterResettableObject___4231399037(string P_0, float? P_1, string P_2)
		{
			if (!base.IsServerStarted)
			{
				return;
			}
			if (UniqueID == 0)
			{
				Debug.LogError(DebugLogObjectName + ": Unable to register as a resettable object because it does not have a UniqueID");
				return;
			}
			FlightSceneResettableObjectManager resettableObjectManager = FlightSceneScript.Instance.ResettableObjectManager;
			IFlightSceneResettableObject objectById = resettableObjectManager.GetObjectById(UniqueID);
			if (objectById == null)
			{
				objectById = new ResettableObject(UniqueID, P_0, P_1, P_2);
				resettableObjectManager.Register(objectById);
			}
			else if (P_1.HasValue && P_1.Value < objectById.ResetTimer)
			{
				objectById.ResetTimer = P_1.Value;
			}
		}

		private void RpcReader___Server_RegisterResettableObject___4231399037(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			float? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002ESingle_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			string text2 = PooledReader0.ReadStringAllocated();
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___RegisterResettableObject___4231399037(text, num, text2);
			}
		}

		private void RpcWriter___Server_UnregisterResettableObject___2166136261()
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(3u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___UnregisterResettableObject___2166136261()
		{
			if (base.IsServerStarted)
			{
				if (UniqueID == 0)
				{
					Debug.LogError(DebugLogObjectName + ": Unable to register as a resettable object because it does not have a UniqueID");
				}
				else
				{
					FlightSceneScript.Instance.ResettableObjectManager.Unregister(UniqueID);
				}
			}
		}

		private void RpcReader___Server_UnregisterResettableObject___2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___UnregisterResettableObject___2166136261();
			}
		}

		private void RpcWriter___Target_ComponentRpcClient___3759040387(NetworkConnection target, byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendTargetRpc(4u, pooledWriter, channel2, DataOrderType.Default, target, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcClient___3759040387(NetworkConnection P_0, byte P_1, ArraySegment<byte> P_2, Channel P_3)
		{
			ProcessComponentRpcClient(P_1, P_2);
		}

		private void RpcReader___Target_ComponentRpcClient___3759040387(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___ComponentRpcClient___3759040387(base.LocalConnection, b, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_ComponentRpcClient___3759040387(NetworkConnection target, byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(5u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcReader___Observers_ComponentRpcClient___3759040387(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___ComponentRpcClient___3759040387(null, b, arraySegment, channel);
			}
		}

		private void RpcWriter___Target_ComponentRpcClientAndLocal___3759040387(NetworkConnection target, byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendTargetRpc(6u, pooledWriter, channel2, DataOrderType.Default, target, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcClientAndLocal___3759040387(NetworkConnection P_0, byte P_1, ArraySegment<byte> P_2, Channel P_3)
		{
			ProcessComponentRpcClient(P_1, P_2);
		}

		private void RpcReader___Target_ComponentRpcClientAndLocal___3759040387(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ComponentRpcClientAndLocal___3759040387(base.LocalConnection, b, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_ComponentRpcClientAndLocal___3759040387(NetworkConnection target, byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(7u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcReader___Observers_ComponentRpcClientAndLocal___3759040387(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ComponentRpcClientAndLocal___3759040387(null, b, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_ComponentRpcClientAndLocalExcludingOwner___3854340310(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(8u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcClientAndLocalExcludingOwner___3854340310(byte P_0, ArraySegment<byte> P_1, Channel P_2)
		{
			ProcessComponentRpcClient(P_0, P_1);
		}

		private void RpcReader___Observers_ComponentRpcClientAndLocalExcludingOwner___3854340310(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ComponentRpcClientAndLocalExcludingOwner___3854340310(b, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_ComponentRpcClientExcludingOwner___3854340310(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(9u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcClientExcludingOwner___3854340310(byte P_0, ArraySegment<byte> P_1, Channel P_2)
		{
			ProcessComponentRpcClient(P_0, P_1);
		}

		private void RpcReader___Observers_ComponentRpcClientExcludingOwner___3854340310(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___ComponentRpcClientExcludingOwner___3854340310(b, arraySegment, channel);
			}
		}

		private void RpcWriter___Server_ComponentRpcServer___2558193021(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(10u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcServer___2558193021(byte P_0, ArraySegment<byte> P_1, Channel P_2, NetworkConnection P_3)
		{
			if (P_0 > _components.Count)
			{
				Debug.LogError($"Received a server component RPC but was unable to process it because the component with index '{P_0}' could not be found.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine);
				return;
			}
			NetworkFlightObjectComponent networkFlightObjectComponent = _components[P_0];
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(P_1);
			networkFlightObjectComponent.ReceiveServerRpc(pooledReaderDisposableWrapper, P_3);
		}

		private void RpcReader___Server_ComponentRpcServer___2558193021(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized)
			{
				RpcLogic___ComponentRpcServer___2558193021(b, arraySegment, channel, conn);
			}
		}

		private void RpcWriter___Server_ComponentRpcServerAndLocal___2558193021(byte componentIndex, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(11u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcServerAndLocal___2558193021(byte P_0, ArraySegment<byte> P_1, Channel P_2, NetworkConnection P_3)
		{
			if (P_0 > _components.Count)
			{
				Debug.LogError($"Received a server component RPC but was unable to process it because the component with index '{P_0}' could not be found.{System.Environment.NewLine}" + "Flight Object: " + base.name + " (" + GetType().FullName + ")" + System.Environment.NewLine);
				return;
			}
			NetworkFlightObjectComponent networkFlightObjectComponent = _components[P_0];
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(P_1);
			networkFlightObjectComponent.ReceiveServerRpc(pooledReaderDisposableWrapper, P_3);
		}

		private void RpcReader___Server_ComponentRpcServerAndLocal___2558193021(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___ComponentRpcServerAndLocal___2558193021(b, arraySegment, channel, conn);
			}
		}

		private void RpcWriter___Server_ComponentRpcServerRelay___3995766794(NetworkConnection target, bool excludeOwner, byte componentIndex, ArraySegment<byte> data, int? bufferedRpcId = null, Channel channel = Channel.Reliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(target);
			pooledWriter.WriteBoolean(excludeOwner);
			pooledWriter.WriteUInt8Unpacked(componentIndex);
			pooledWriter.WriteArraySegmentAndSize(data);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, bufferedRpcId);
			SendServerRpc(12u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ComponentRpcServerRelay___3995766794(NetworkConnection P_0, bool P_1, byte P_2, ArraySegment<byte> P_3, int? P_4, Channel P_5)
		{
			if (P_0 != null && !P_0.IsValid)
			{
				P_0 = null;
			}
			if (P_4.HasValue)
			{
				BufferRpc(P_2, P_4.Value, P_3);
			}
			if (P_1)
			{
				ComponentRpcClientExcludingOwner(P_2, P_3, P_5);
			}
			else
			{
				ComponentRpcClient(P_0, P_2, P_3, P_5);
			}
		}

		private void RpcReader___Server_ComponentRpcServerRelay___3995766794(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			bool flag = PooledReader0.ReadBoolean();
			byte b = PooledReader0.ReadUInt8Unpacked();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___ComponentRpcServerRelay___3995766794(networkConnection, flag, b, arraySegment, num, channel);
			}
		}

		private void RpcWriter___Target_RpcClientInitialize___1484083726(NetworkConnection connection, int uniqueId, ArraySegment<byte> spawnData, ArraySegment<byte> stateData, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(uniqueId);
			pooledWriter.WriteArraySegmentAndSize(spawnData);
			pooledWriter.WriteArraySegmentAndSize(stateData);
			SendTargetRpc(13u, pooledWriter, channel2, DataOrderType.Default, connection, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcClientInitialize___1484083726(NetworkConnection P_0, int P_1, ArraySegment<byte> P_2, ArraySegment<byte> P_3, Channel P_4)
		{
			InitializeLocalClient(P_1, P_2, P_3);
		}

		private void RpcReader___Target_RpcClientInitialize___1484083726(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			ArraySegment<byte> arraySegment2 = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcClientInitialize___1484083726(base.LocalConnection, num, arraySegment, arraySegment2, channel);
			}
		}

		private void RpcWriter___Target_RpcNfoUpdateStateClient___748863190(NetworkConnection connection, ArraySegment<byte> data, Channel channel = Channel.Unreliable)
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
			SendTargetRpc(14u, pooledWriter, channel2, DataOrderType.Default, connection, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcNfoUpdateStateClient___748863190(NetworkConnection P_0, ArraySegment<byte> P_1, Channel P_2)
		{
			UpdateLocalState(P_1);
		}

		private void RpcReader___Target_RpcNfoUpdateStateClient___748863190(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcNfoUpdateStateClient___748863190(base.LocalConnection, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcNfoUpdateStateClient___748863190(NetworkConnection connection, ArraySegment<byte> data, Channel channel = Channel.Unreliable)
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
			SendObserversRpc(15u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: true, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcReader___Observers_RpcNfoUpdateStateClient___748863190(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcNfoUpdateStateClient___748863190(null, arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcNfoUpdateStateServer___2713644489(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
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
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(16u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcNfoUpdateStateServer___2713644489(ArraySegment<byte> P_0, Channel P_1)
		{
			_bufferedRpcUpdateState?.Store();
			_bufferedRpcUpdateState = WriterPool.Retrieve(P_0.Count);
			_bufferedRpcUpdateState.WriteArraySegment(P_0);
			RpcNfoUpdateStateClient(null, P_0, P_1);
			bool flag = base.Observers.Contains(base.LocalConnection);
			if (base.gameObject.activeSelf != flag)
			{
				base.gameObject.SetActive(flag);
				foreach (NetworkFlightObjectComponent component in _components)
				{
					component.OnServerObservationStateChanged(flag);
				}
			}
			if (!flag)
			{
				UpdateLocalState(P_0);
			}
		}

		private void RpcReader___Server_RpcNfoUpdateStateServer___2713644489(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcNfoUpdateStateServer___2713644489(arraySegment, channel);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ENetworkFlightObject_Game_002Edll()
		{
			_transform = base.transform;
			if (_handleFloatingOrigin)
			{
				FloatingOriginScript.Instance.Repositioned += FloatingOriginChanged;
			}
			_manager = FlightSceneScript.Instance.FlightSceneNetwork.FlightObjectsManager;
			if (_manager == null)
			{
				Debug.LogError("Unable to find the flight scene network flight objects manager.");
				base.gameObject.SetActive(value: false);
				return;
			}
			_components = new List<NetworkFlightObjectComponent>();
			Utilities.GetComponentsInChildrenOrdered(base.gameObject, _components);
			foreach (NetworkFlightObjectComponent component in _components)
			{
				component.OnCreated(this);
			}
		}
	}
}
