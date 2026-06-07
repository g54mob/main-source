using System;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.Craft;
using Assets.Scripts.Environment;
using Assets.Scripts.Environment.Roads;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using Assets.Scripts.Multiplayer.Messages;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Server;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class FlightSceneNetworkScript : NetworkBehaviour
	{
		public readonly SyncVar<Vector3> _cloudAnimation1 = new SyncVar<Vector3>(Vector3.zero, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<Vector3> _cloudAnimation2 = new SyncVar<Vector3>(Vector3.zero, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<bool> _isPeacefulMode = new SyncVar<bool>(initialValue: false, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<float> _lengthOfDay = new SyncVar<float>(1f, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<int> _maxCars = new SyncVar<int>(CarSpawnerScript.MaxCars, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<ushort> _serverMaxPartCount = new SyncVar<ushort>(new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<float> _serverPhysicsTime = new SyncVar<float>(new SyncTypeSettings(0.25f, Channel.Unreliable));

		public readonly SyncVar<ushort> _serverTickRate = new SyncVar<ushort>(new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<float> _timeOfDay = new SyncVar<float>(-1f, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<WeatherPreset> _weatherType = new SyncVar<WeatherPreset>(WeatherPreset.Clear, new SyncTypeSettings(1f, Channel.Unreliable));

		public readonly SyncVar<Vector3> _windVelocity = new SyncVar<Vector3>(new SyncTypeSettings(0.25f, Channel.Unreliable));

		private Dictionary<int, Action<AircraftScript>> _aiCraftsBeingNetworkLoaded = new Dictionary<int, Action<AircraftScript>>();

		[SerializeField]
		private float _deltaTarget;

		private ExplosionBatcher _explosionBatcher;

		[SerializeField]
		private int _maxExplosionsPerTick = 25;

		private NpcPlayerIdManager _npcPlayerIdManager;

		[SerializeField]
		private float _physicsTime;

		private FloatAverage _rtt = new FloatAverage(10);

		private float _targetPhysicsTime;

		private float _timer;

		private ReceiveFlightSceneClientRpcDelegate[] _clientRpcSubscribers = new ReceiveFlightSceneClientRpcDelegate[255];

		private ReceiveFlightSceneServerRpcDelegate[] _serverRpcSubscribers = new ReceiveFlightSceneServerRpcDelegate[255];

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScriptGame_002Edll_Excuted;

		public ChatMessages ChatMessages { get; private set; } = new ChatMessages();

		public ClientPingScript ClientPing { get; private set; }

		[field: SerializeField]
		public NetworkFlightObjectManager FlightObjectsManager { get; private set; }

		public float PhysicsTime => _physicsTime;

		public float RoundTripTime => _rtt.Value;

		public ushort ServerMaxPartCount
		{
			get
			{
				return _serverMaxPartCount.Value;
			}
			set
			{
				if (!base.IsServerStarted)
				{
					throw new NotSupportedException();
				}
				_serverMaxPartCount.Value = value;
				Game.Instance.NetworkGameManager?.SteamLobbyManager?.OnLobbySettingsChanged();
			}
		}

		public ushort ServerTickRate
		{
			get
			{
				return _serverTickRate.Value;
			}
			set
			{
				if (!base.IsServerStarted)
				{
					throw new NotSupportedException();
				}
				_serverTickRate.Value = value;
			}
		}

		public Vector3 WindVelocity
		{
			get
			{
				return _windVelocity.Value;
			}
			set
			{
				_windVelocity.Value = value;
			}
		}

		public event Action ClientStarted;

		public event Action ClientStopped;

		public event EventHandler<NetworkConnectionEventArgs> SpawnServer;

		[ServerRpc(RequireOwnership = false)]
		public void BroadcastMessageToAllClients(string message)
		{
			RpcWriter___Server_BroadcastMessageToAllClients___3615296227(message);
		}

		public void CreateExplosion(CreateExplosionInfo creationExplosionInfo)
		{
			_explosionBatcher.AddExplosion(creationExplosionInfo);
		}

		public void CreateExplosionLocal(CreateExplosionInfo info)
		{
			GameObject obj = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/Explosions/" + info.ExplosionPrefabName);
			obj.transform.SetParent(base.transform.parent);
			obj.transform.position = Utility.ConvertAbsoluteToFloatingOriginPosition(info.GlobalPosition.ToVector3());
			obj.transform.localScale = Vector3.one;
			obj.transform.rotation = Quaternion.identity;
			IExplosionScript component = obj.GetComponent<IExplosionScript>();
			AircraftScript owner = null;
			if (info.AttackerPlayerId.HasValue)
			{
				FlightScenePlayer player = FlightSceneScript.Instance.GetPlayer(info.AttackerPlayerId.Value);
				if (player != null)
				{
					owner = player.Aircraft;
				}
			}
			component.Explode(info.ExplosionScale, info.BlastDirection, owner, null, info.ImpactDirection, info.ImpactType);
		}

		public void OnAircraftForAIHasBeenNetworkInitialized(NetworkAircraftScript networkAircraft)
		{
			int playerId = networkAircraft.Player.NetworkPlayer.PlayerId;
			_aiCraftsBeingNetworkLoaded.TryGetValue(playerId, out var value);
			if (value != null)
			{
				_aiCraftsBeingNetworkLoaded.Remove(playerId);
				value(networkAircraft.AircraftScript);
			}
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
			base.OnSpawnServer(connection);
			InitializeFromServer(connection, _physicsTime);
			this.SpawnServer?.Invoke(this, new NetworkConnectionEventArgs(connection));
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			_serverTickRate.SetInitialValues(base.TimeManager.TickRate);
			ClientPing = GetComponent<ClientPingScript>();
			FlightSceneScript.Instance.Environment.OnStartClient(base.IsServerStarted);
			if (!base.IsServerStarted)
			{
				base.TimeManager.OnRoundTripTimeUpdated += TimeManager_OnRoundTripTimeUpdated;
			}
			_explosionBatcher = new ExplosionBatcher();
			base.TimeManager.OnPostTick += OnPostTick;
			this.ClientStarted?.Invoke();
			Game.Instance.NetworkGameManager.PlayerLeaving += OnPlayerLeaving;
			Game.Instance.NetworkGameManager.PrimaryLocalPlayerChanged += OnPrimaryLocalPlayerChanged;
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			if (!base.IsServerStarted)
			{
				base.TimeManager.OnRoundTripTimeUpdated -= TimeManager_OnRoundTripTimeUpdated;
			}
			base.TimeManager.OnPostTick -= OnPostTick;
			this.ClientStopped?.Invoke();
			Game.Instance.NetworkGameManager.PlayerLeaving -= OnPlayerLeaving;
			Game.Instance.NetworkGameManager.PrimaryLocalPlayerChanged -= OnPrimaryLocalPlayerChanged;
		}

		public void RegisterFlightObjectSpawner(string spawnerId, NetworkFlightObjectSpawnerType type, ArraySegment<byte> spawnerData)
		{
			int uniqueId = FlightObjectsManager.GetUniqueId(spawnerId);
			RpcRegisterFlightObjectSpawner(uniqueId, type, spawnerData);
		}

		public void SendChatMessageToAllClients(int ownerId, string message)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			SendChatMessageToAllClientsRpc(ownerId, bytes);
		}

		public void ShowMessageToAllPlayers(string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			ShowMessageServerRpc(null, messageText, logMessage, highlighted, time);
		}

		public void ShowMessageToLocalPlayer(string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			if (logMessage)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage(messageText, time, highlighted);
			}
			else
			{
				FlightSceneScript.Instance.FlightUI.ShowLogMessage(messageText, time, highlighted);
			}
		}

		public void ShowMessageToTargetPlayer(NetworkConnection player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			ShowMessageServerRpc(player, messageText, logMessage, highlighted, time);
		}

		public void ShowMessageToTargetPlayer(NetworkPlayerScript player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			ShowMessageServerRpc(player.Owner, messageText, logMessage, highlighted, time);
		}

		public void ShowMessageToTargetPlayer(FlightScenePlayer player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			ShowMessageServerRpc(player.NetworkPlayer.Owner, messageText, logMessage, highlighted, time);
		}

		public void SpawnAIAircraft(AiAircraftInfo aircraftInfo, Vector3 position, Vector3 rotation, float speed, bool autoDespawn, ushort teamId, Action<AircraftScript> onDone = null)
		{
			StartLocationData startLocationData = new StartLocationData("AI Spawn", "AI Spawn", null, StartLocationType.Temp, position, rotation, speed * (Quaternion.Euler(rotation) * Vector3.forward), null);
			int nextAvailableNpcPlayerId = GetNextAvailableNpcPlayerId();
			byte craftOwnerSpawnDataId = CraftOwnerSpawnData.CreateAndStore(startLocationData, startPaused: false);
			int spawnLocationHashCode = startLocationData.GetSpawnLocationHashCode();
			RpcSpawnAIAircraft(aircraftInfo.AircraftId, nextAvailableNpcPlayerId, teamId, spawnLocationHashCode, craftOwnerSpawnDataId, base.LocalConnection);
			_aiCraftsBeingNetworkLoaded.Add(nextAvailableNpcPlayerId, onDone);
		}

		public void SpawnFlightObject(string prefab, Vector3 absolutePosition, Vector3 rotation, ArraySegment<byte> initData, int uniqueID = 0)
		{
			RpcSpawnFlightObject(prefab, absolutePosition, rotation, initData, uniqueID);
		}

		public void SpawnGameObject(string prefab, Vector3 absolutePosition, Vector3 rotation)
		{
			RpcSpawnGameObject(prefab, absolutePosition, rotation);
		}

		public void UnregisterFlightObjectSpawner(string spawnerId)
		{
			int uniqueId = FlightObjectsManager.GetUniqueId(spawnerId);
			RpcUnregisterFlightObjectSpawner(uniqueId);
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void FixedUpdate()
		{
			if (base.IsServerStarted)
			{
				_serverPhysicsTime.Value += Time.fixedDeltaTime;
				_physicsTime = _serverPhysicsTime.Value;
			}
			else
			{
				_physicsTime += Time.fixedDeltaTime;
				_targetPhysicsTime += Time.fixedDeltaTime;
				_deltaTarget = _targetPhysicsTime - _physicsTime;
			}
		}

		protected virtual void Update()
		{
			if (base.IsServerStarted)
			{
				_maxCars.Value = CarSpawnerScript.MaxCars;
				_timeOfDay.Value = FlightSceneScript.Instance.Environment.TimeOfDay;
				_lengthOfDay.Value = FlightSceneScript.Instance.Environment.LengthOfDay;
				_weatherType.Value = FlightSceneScript.Instance.Environment.WeatherType;
				_cloudAnimation1.Value = FlightSceneScript.Instance.Environment.CloudAnimation1;
				_cloudAnimation2.Value = FlightSceneScript.Instance.Environment.CloudAnimation2;
				_isPeacefulMode.Value = FlightSceneScript.IsPeacefulMode;
			}
			else if (_timeOfDay.Value >= 0f)
			{
				if (Mathf.Abs(FlightSceneScript.Instance.Environment.TimeOfDay - _timeOfDay.Value) > 0.5f)
				{
					FlightSceneScript.Instance.Environment.TimeOfDay = _timeOfDay.Value;
					FlightSceneScript.Instance.Environment.LengthOfDay = _lengthOfDay.Value;
				}
				if (FlightSceneScript.Instance.Environment.WeatherType != _weatherType.Value)
				{
					FlightSceneScript.Instance.Environment.UpdateWeather(_weatherType.Value, 1f, ignorePause: true);
				}
				float t = Time.unscaledDeltaTime * 1f;
				FlightSceneScript.Instance.Environment.CloudAnimation1 = Vector3.Lerp(FlightSceneScript.Instance.Environment.CloudAnimation1, _cloudAnimation1.Value, t);
				FlightSceneScript.Instance.Environment.CloudAnimation2 = Vector3.Lerp(FlightSceneScript.Instance.Environment.CloudAnimation2, _cloudAnimation2.Value, t);
				if (FlightSceneScript.IsPeacefulMode != _isPeacefulMode.Value)
				{
					FlightSceneScript.IsPeacefulMode = _isPeacefulMode.Value;
					FlightSceneScript.Instance.FlightUI.ShowMessage("Peaceful mode " + (FlightSceneScript.IsPeacefulMode ? "enabled" : "disabled"));
				}
				CarSpawnerScript.MaxCars = _maxCars.Value;
			}
		}

		[ObserversRpc]
		private void BroadcastMessageToAllClientsObservers(string message)
		{
			RpcWriter___Observers_BroadcastMessageToAllClientsObservers___3615296227(message);
		}

		[ObserversRpc]
		private void CreateExplosionRelay(CreateExplosionsMessage message, int skipOwnerId)
		{
			RpcWriter___Observers_CreateExplosionRelay___3888812982(message, skipOwnerId);
		}

		[ServerRpc(RequireOwnership = false)]
		private void CreateExplosionServer(CreateExplosionsMessage message, int skipOwnerId)
		{
			RpcWriter___Server_CreateExplosionServer___3888812982(message, skipOwnerId);
		}

		private int GetNextAvailableNpcPlayerId()
		{
			return _npcPlayerIdManager.GetNextNpcPlayerId(reserve: true);
		}

		[TargetRpc(ExcludeServer = true)]
		private void InitializeFromServer(NetworkConnection connection, float physicsTime)
		{
			RpcWriter___Target_InitializeFromServer___530160725(connection, physicsTime);
		}

		private void OnPlayerLeaving(object sender, NetworkPlayerEventArgs e)
		{
			if (e.Player.IsOwner && e.Player.IsNPC)
			{
				ReleaseNpcPlayerID(e.Player);
			}
		}

		private void OnPostTick()
		{
			List<CreateExplosionInfo> value;
			using (CollectionPool<List<CreateExplosionInfo>, CreateExplosionInfo>.Get(out value))
			{
				_explosionBatcher.GetNextExplosions(_maxExplosionsPerTick, value);
				if (value.Count <= 0)
				{
					return;
				}
				CreateExplosionsMessage createExplosionsMessage = new CreateExplosionsMessage();
				createExplosionsMessage.Explosions.AddRange(value);
				CreateExplosionServer(createExplosionsMessage, base.ClientManager.Connection.ClientId);
				foreach (CreateExplosionInfo item in value)
				{
					CreateExplosionLocal(item);
				}
			}
		}

		private void OnPrimaryLocalPlayerChanged(object sender, NetworkPlayerChangedEventArgs e)
		{
			if (_npcPlayerIdManager == null)
			{
				_npcPlayerIdManager = new NpcPlayerIdManager(e.NewPlayer.PlayerId);
			}
			else if (e.NewPlayer != null && e.NewPlayer.PlayerId != _npcPlayerIdManager.LocalPlayerId)
			{
				Debug.LogError("The primary Local Player changed, but the NpcPlayerIdManager has already been initialized, and doesn't currently support changing primary local players since NPCs are tied to the local player's id.");
			}
		}

		private void OnServerPhysicsFrameChanged(float prev, float next, bool asServer)
		{
			if (base.IsServerStarted)
			{
				return;
			}
			_targetPhysicsTime = _serverPhysicsTime.Value + _rtt.Value / 2f;
			if (Mathf.Abs(_targetPhysicsTime - _physicsTime) > 0.05f)
			{
				_timer += 1f;
				if (_timer > 10f)
				{
					_physicsTime = _targetPhysicsTime;
				}
			}
			else
			{
				_timer = 0f;
			}
		}

		private void OnServerTickRateChanged(ushort prev, ushort next, bool asServer)
		{
			Game.Instance.NetworkGameManager.NetworkManager.TimeManager.SetTickRate(next);
		}

		private void ReleaseNpcPlayerID(NetworkPlayerScript networkPlayer)
		{
			if (networkPlayer.IsNPC)
			{
				if (_npcPlayerIdManager.IsInRange(networkPlayer.PlayerId))
				{
					_npcPlayerIdManager.ReleaseNpcPlayerId(networkPlayer.PlayerId);
				}
			}
			else
			{
				Debug.LogError("Attempting to release NPC playerId for a non-NPC player.");
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcRegisterFlightObjectSpawner(int spawnerUniqueId, NetworkFlightObjectSpawnerType type, ArraySegment<byte> spawnerData, NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcRegisterFlightObjectSpawner___3789885279(spawnerUniqueId, type, spawnerData, clientConnection);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcSpawnAIAircraft(string craftId, int playerId, ushort teamId, int startLocationIdHashCode, byte craftOwnerSpawnDataId, NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcSpawnAIAircraft___222092229(craftId, playerId, teamId, startLocationIdHashCode, craftOwnerSpawnDataId, clientConnection);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcSpawnFlightObject(string prefab, Vector3 absolutePosition, Vector3 rotation, ArraySegment<byte> initData, int uniqueID, NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcSpawnFlightObject___3076756246(prefab, absolutePosition, rotation, initData, uniqueID, clientConnection);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcSpawnGameObject(string prefab, Vector3 absolutePosition, Vector3 rotation, NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcSpawnGameObject___563120266(prefab, absolutePosition, rotation, clientConnection);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcUnregisterFlightObjectSpawner(int spawnerUniqueId, NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcUnregisterFlightObjectSpawner___3266232555(spawnerUniqueId, clientConnection);
		}

		[ServerRpc(RequireOwnership = false)]
		private void SendChatMessageToAllClientsRpc(int ownerId, byte[] messageBytes, NetworkConnection sender = null)
		{
			RpcWriter___Server_SendChatMessageToAllClientsRpc___2959024886(ownerId, messageBytes, sender);
		}

		[ObserversRpc]
		private void SendChatMessageToAllObservers(int ownerId, byte[] messageBytes)
		{
			RpcWriter___Observers_SendChatMessageToAllObservers___2109915117(ownerId, messageBytes);
		}

		[TargetRpc]
		private void SendChatMessageToTarget(NetworkConnection target, int ownerId, byte[] messageBytes)
		{
			RpcWriter___Target_SendChatMessageToTarget___1878726436(target, ownerId, messageBytes);
		}

		[TargetRpc]
		[ObserversRpc]
		private void ShowMessageClientRpc(NetworkConnection targetPlayer, string messageText, bool logMessage, bool highlighted, float time)
		{
			if ((object)targetPlayer == null)
			{
				RpcWriter___Observers_ShowMessageClientRpc___783169041(targetPlayer, messageText, logMessage, highlighted, time);
			}
			else
			{
				RpcWriter___Target_ShowMessageClientRpc___783169041(targetPlayer, messageText, logMessage, highlighted, time);
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void ShowMessageServerRpc(NetworkConnection targetPlayer, string messageText, bool logMessage, bool highlighted, float time, NetworkConnection connection = null)
		{
			RpcWriter___Server_ShowMessageServerRpc___77971122(targetPlayer, messageText, logMessage, highlighted, time, connection);
		}

		private void TimeManager_OnRoundTripTimeUpdated(long obj)
		{
			_rtt.Add((float)((double)obj / 1000.0));
		}

		public void SendObserversRpc(FlightSceneClientRpcType type, ArraySegment<byte> data, bool excludeOwner, bool runLocally = false, Channel channel = Channel.Reliable)
		{
			if (base.IsServerStarted)
			{
				if (runLocally)
				{
					if (excludeOwner)
					{
						RpcClientAndLocalExcludingOwner(type, data, channel);
					}
					else
					{
						RpcClientAndLocal(null, type, data, channel);
					}
				}
				else if (excludeOwner)
				{
					RpcClientExcludingOwner(type, data, channel);
				}
				else
				{
					RpcClient(null, type, data, channel);
				}
			}
			else
			{
				if (runLocally)
				{
					throw new NotSupportedException("Cannot send a client targeted RPC from another client with the 'runLocally' option.");
				}
				RpcServerRelay(null, excludeOwner, type, data, channel);
			}
		}

		public void SendServerRpc(FlightSceneServerRpcType type, ArraySegment<byte> data, bool runLocally = false, Channel channel = Channel.Reliable)
		{
			if (runLocally)
			{
				RpcServerAndLocal(type, data, channel);
			}
			else
			{
				RpcServer(type, data, channel);
			}
		}

		public void SendTargetRpc(FlightSceneClientRpcType type, ArraySegment<byte> data, NetworkConnection target, Channel channel = Channel.Reliable)
		{
			if (base.IsServerStarted)
			{
				RpcClient(target, type, data, channel);
			}
			else
			{
				RpcServerRelay(target, excludeOwner: false, type, data, channel);
			}
		}

		public void SubscribeToClientRpc(FlightSceneClientRpcType type, ReceiveFlightSceneClientRpcDelegate subscriber, bool allowMultipleSubscribers = false)
		{
			byte b = (byte)type;
			if (allowMultipleSubscribers)
			{
				ref ReceiveFlightSceneClientRpcDelegate reference = ref _clientRpcSubscribers[b];
				reference = (ReceiveFlightSceneClientRpcDelegate)Delegate.Combine(reference, subscriber);
				return;
			}
			if (_clientRpcSubscribers[b] != null)
			{
				Debug.LogError($"An existing flight scene client RPC subscription was overwritten by a new subscription. RPC: {type}");
			}
			_clientRpcSubscribers[b] = subscriber;
		}

		public void SubscribeToServerRpc(FlightSceneServerRpcType type, ReceiveFlightSceneServerRpcDelegate subscriber, bool allowMultipleSubscribers = false)
		{
			byte b = (byte)type;
			if (allowMultipleSubscribers)
			{
				ref ReceiveFlightSceneServerRpcDelegate reference = ref _serverRpcSubscribers[b];
				reference = (ReceiveFlightSceneServerRpcDelegate)Delegate.Combine(reference, subscriber);
				return;
			}
			if (_serverRpcSubscribers[b] != null)
			{
				Debug.LogError($"An existing flight scene server RPC subscription was overwritten by a new subscription. RPC: {type}");
			}
			_serverRpcSubscribers[b] = subscriber;
		}

		public void UnsubscribeFromClientRpc(FlightSceneClientRpcType type)
		{
			_clientRpcSubscribers[(uint)type] = null;
		}

		public void UnsubscribeFromClientRpc(FlightSceneClientRpcType type, ReceiveFlightSceneClientRpcDelegate subscriber)
		{
			ref ReceiveFlightSceneClientRpcDelegate reference = ref _clientRpcSubscribers[(uint)type];
			reference = (ReceiveFlightSceneClientRpcDelegate)Delegate.Remove(reference, subscriber);
		}

		public void UnsubscribeFromServerRpc(FlightSceneServerRpcType type)
		{
			_serverRpcSubscribers[(uint)type] = null;
		}

		public void UnsubscribeFromServerRpc(FlightSceneServerRpcType type, ReceiveFlightSceneServerRpcDelegate subscriber)
		{
			ref ReceiveFlightSceneServerRpcDelegate reference = ref _serverRpcSubscribers[(uint)type];
			reference = (ReceiveFlightSceneServerRpcDelegate)Delegate.Remove(reference, subscriber);
		}

		[TargetRpc]
		[ObserversRpc(ExcludeOwner = false)]
		private void RpcClient(NetworkConnection target, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if ((object)target == null)
			{
				RpcWriter___Observers_RpcClient___2549324077(target, type, data, channel);
			}
			else
			{
				RpcWriter___Target_RpcClient___2549324077(target, type, data, channel);
			}
		}

		[TargetRpc(RunLocally = true)]
		[ObserversRpc(ExcludeOwner = false, RunLocally = true)]
		private void RpcClientAndLocal(NetworkConnection target, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if ((object)target == null)
			{
				RpcWriter___Observers_RpcClientAndLocal___2549324077(target, type, data, channel);
				RpcLogic___RpcClientAndLocal___2549324077(target, type, data, channel);
			}
			else
			{
				RpcWriter___Target_RpcClientAndLocal___2549324077(target, type, data, channel);
				RpcLogic___RpcClientAndLocal___2549324077(target, type, data, channel);
			}
		}

		[ObserversRpc(ExcludeOwner = true, RunLocally = true)]
		private void RpcClientAndLocalExcludingOwner(FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			RpcWriter___Observers_RpcClientAndLocalExcludingOwner___2354497016(type, data, channel);
			RpcLogic___RpcClientAndLocalExcludingOwner___2354497016(type, data, channel);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void RpcClientExcludingOwner(FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			RpcWriter___Observers_RpcClientExcludingOwner___2354497016(type, data, channel);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcServer(FlightSceneServerRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			RpcWriter___Server_RpcServer___29944227(type, data, channel, sender);
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		private void RpcServerAndLocal(FlightSceneServerRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			RpcWriter___Server_RpcServerAndLocal___29944227(type, data, channel, sender);
			RpcLogic___RpcServerAndLocal___29944227(type, data, channel, sender);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcServerRelay(NetworkConnection target, bool excludeOwner, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			RpcWriter___Server_RpcServerRelay___3622131982(target, excludeOwner, type, data, channel);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				_windVelocity.InitializeEarly(this, 10u, isSyncObject: false);
				_weatherType.InitializeEarly(this, 9u, isSyncObject: false);
				_timeOfDay.InitializeEarly(this, 8u, isSyncObject: false);
				_serverTickRate.InitializeEarly(this, 7u, isSyncObject: false);
				_serverPhysicsTime.InitializeEarly(this, 6u, isSyncObject: false);
				_serverMaxPartCount.InitializeEarly(this, 5u, isSyncObject: false);
				_maxCars.InitializeEarly(this, 4u, isSyncObject: false);
				_lengthOfDay.InitializeEarly(this, 3u, isSyncObject: false);
				_isPeacefulMode.InitializeEarly(this, 2u, isSyncObject: false);
				_cloudAnimation2.InitializeEarly(this, 1u, isSyncObject: false);
				_cloudAnimation1.InitializeEarly(this, 0u, isSyncObject: false);
				RegisterServerRpc(0u, RpcReader___Server_BroadcastMessageToAllClients___3615296227);
				RegisterObserversRpc(1u, RpcReader___Observers_BroadcastMessageToAllClientsObservers___3615296227);
				RegisterObserversRpc(2u, RpcReader___Observers_CreateExplosionRelay___3888812982);
				RegisterServerRpc(3u, RpcReader___Server_CreateExplosionServer___3888812982);
				RegisterTargetRpc(4u, RpcReader___Target_InitializeFromServer___530160725);
				RegisterServerRpc(5u, RpcReader___Server_RpcRegisterFlightObjectSpawner___3789885279);
				RegisterServerRpc(6u, RpcReader___Server_RpcSpawnAIAircraft___222092229);
				RegisterServerRpc(7u, RpcReader___Server_RpcSpawnFlightObject___3076756246);
				RegisterServerRpc(8u, RpcReader___Server_RpcSpawnGameObject___563120266);
				RegisterServerRpc(9u, RpcReader___Server_RpcUnregisterFlightObjectSpawner___3266232555);
				RegisterServerRpc(10u, RpcReader___Server_SendChatMessageToAllClientsRpc___2959024886);
				RegisterObserversRpc(11u, RpcReader___Observers_SendChatMessageToAllObservers___2109915117);
				RegisterTargetRpc(12u, RpcReader___Target_SendChatMessageToTarget___1878726436);
				RegisterTargetRpc(13u, RpcReader___Target_ShowMessageClientRpc___783169041);
				RegisterObserversRpc(14u, RpcReader___Observers_ShowMessageClientRpc___783169041);
				RegisterServerRpc(15u, RpcReader___Server_ShowMessageServerRpc___77971122);
				RegisterTargetRpc(16u, RpcReader___Target_RpcClient___2549324077);
				RegisterObserversRpc(17u, RpcReader___Observers_RpcClient___2549324077);
				RegisterTargetRpc(18u, RpcReader___Target_RpcClientAndLocal___2549324077);
				RegisterObserversRpc(19u, RpcReader___Observers_RpcClientAndLocal___2549324077);
				RegisterObserversRpc(20u, RpcReader___Observers_RpcClientAndLocalExcludingOwner___2354497016);
				RegisterObserversRpc(21u, RpcReader___Observers_RpcClientExcludingOwner___2354497016);
				RegisterServerRpc(22u, RpcReader___Server_RpcServer___29944227);
				RegisterServerRpc(23u, RpcReader___Server_RpcServerAndLocal___29944227);
				RegisterServerRpc(24u, RpcReader___Server_RpcServerRelay___3622131982);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
				_windVelocity.InitializeLate();
				_weatherType.InitializeLate();
				_timeOfDay.InitializeLate();
				_serverTickRate.InitializeLate();
				_serverPhysicsTime.InitializeLate();
				_serverMaxPartCount.InitializeLate();
				_maxCars.InitializeLate();
				_lengthOfDay.InitializeLate();
				_isPeacefulMode.InitializeLate();
				_cloudAnimation2.InitializeLate();
				_cloudAnimation1.InitializeLate();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_BroadcastMessageToAllClients___3615296227(string message)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(message);
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___BroadcastMessageToAllClients___3615296227(string P_0)
		{
			BroadcastMessageToAllClientsObservers(P_0);
		}

		private void RpcReader___Server_BroadcastMessageToAllClients___3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			if (base.IsServerInitialized)
			{
				RpcLogic___BroadcastMessageToAllClients___3615296227(text);
			}
		}

		private void RpcWriter___Observers_BroadcastMessageToAllClientsObservers___3615296227(string message)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(message);
			SendObserversRpc(1u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___BroadcastMessageToAllClientsObservers___3615296227(string P_0)
		{
			FlightSceneScript.Instance.FlightUI.ShowLogMessage(P_0, 7f, highlighted: true);
		}

		private void RpcReader___Observers_BroadcastMessageToAllClientsObservers___3615296227(PooledReader PooledReader0, Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			if (base.IsClientInitialized)
			{
				RpcLogic___BroadcastMessageToAllClientsObservers___3615296227(text);
			}
		}

		private void RpcWriter___Observers_CreateExplosionRelay___3888812982(CreateExplosionsMessage message, int skipOwnerId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerated(pooledWriter, message);
			pooledWriter.WriteInt32(skipOwnerId);
			SendObserversRpc(2u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___CreateExplosionRelay___3888812982(CreateExplosionsMessage P_0, int P_1)
		{
			if (P_1 == base.ClientManager.Connection.ClientId)
			{
				return;
			}
			foreach (CreateExplosionInfo explosion in P_0.Explosions)
			{
				CreateExplosionLocal(explosion);
			}
		}

		private void RpcReader___Observers_CreateExplosionRelay___3888812982(PooledReader PooledReader0, Channel channel)
		{
			CreateExplosionsMessage createExplosionsMessage = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___CreateExplosionRelay___3888812982(createExplosionsMessage, num);
			}
		}

		private void RpcWriter___Server_CreateExplosionServer___3888812982(CreateExplosionsMessage message, int skipOwnerId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerated(pooledWriter, message);
			pooledWriter.WriteInt32(skipOwnerId);
			SendServerRpc(3u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___CreateExplosionServer___3888812982(CreateExplosionsMessage P_0, int P_1)
		{
			CreateExplosionRelay(P_0, P_1);
		}

		private void RpcReader___Server_CreateExplosionServer___3888812982(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			CreateExplosionsMessage createExplosionsMessage = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___CreateExplosionServer___3888812982(createExplosionsMessage, num);
			}
		}

		private void RpcWriter___Target_InitializeFromServer___530160725(NetworkConnection connection, float physicsTime)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteSingle(physicsTime);
			SendTargetRpc(4u, pooledWriter, channel, DataOrderType.Default, connection, excludeServer: true);
			pooledWriter.Store();
		}

		private void RpcLogic___InitializeFromServer___530160725(NetworkConnection P_0, float P_1)
		{
			_physicsTime = P_1 + _rtt.Value / 2f;
		}

		private void RpcReader___Target_InitializeFromServer___530160725(PooledReader PooledReader0, Channel channel)
		{
			float num = PooledReader0.ReadSingle();
			if (base.IsClientInitialized)
			{
				RpcLogic___InitializeFromServer___530160725(base.LocalConnection, num);
			}
		}

		private void RpcWriter___Server_RpcRegisterFlightObjectSpawner___3789885279(int spawnerUniqueId, NetworkFlightObjectSpawnerType type, ArraySegment<byte> spawnerData, NetworkConnection clientConnection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(spawnerUniqueId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ESpawners_002ENetworkFlightObjectSpawnerTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(spawnerData);
			SendServerRpc(5u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcRegisterFlightObjectSpawner___3789885279(int P_0, NetworkFlightObjectSpawnerType P_1, ArraySegment<byte> P_2, NetworkConnection P_3)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(P_2);
			FlightObjectsManager.Server.RegisterSpawner(P_0, P_1, pooledReaderDisposableWrapper.Reader, P_3);
		}

		private void RpcReader___Server_RpcRegisterFlightObjectSpawner___3789885279(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			NetworkFlightObjectSpawnerType networkFlightObjectSpawnerType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ESpawners_002ENetworkFlightObjectSpawnerTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcRegisterFlightObjectSpawner___3789885279(num, networkFlightObjectSpawnerType, arraySegment, conn);
			}
		}

		private void RpcWriter___Server_RpcSpawnAIAircraft___222092229(string craftId, int playerId, ushort teamId, int startLocationIdHashCode, byte craftOwnerSpawnDataId, NetworkConnection clientConnection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(craftId);
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteUInt16(teamId);
			pooledWriter.WriteInt32(startLocationIdHashCode);
			pooledWriter.WriteUInt8Unpacked(craftOwnerSpawnDataId);
			SendServerRpc(6u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSpawnAIAircraft___222092229(string P_0, int P_1, ushort P_2, int P_3, byte P_4, NetworkConnection P_5)
		{
			NetworkPlayerScript networkPlayerScript = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkPlayerScript>("Multiplayer/NetworkPlayer");
			networkPlayerScript.InitializeAi(P_1, P_2);
			Game.Instance.NetworkGameManager.NetworkManager.ServerManager.Spawn(networkPlayerScript.gameObject, P_5);
			NetworkAircraftScript networkAircraftScript = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkAircraftScript>("Multiplayer/NetworkAircraft");
			networkAircraftScript.ServerInitialize(P_0, P_3, P_4, P_1);
			Game.Instance.NetworkGameManager.NetworkManager.ServerManager.Spawn(networkAircraftScript.gameObject, P_5);
		}

		private void RpcReader___Server_RpcSpawnAIAircraft___222092229(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			int num = PooledReader0.ReadInt32();
			ushort num2 = PooledReader0.ReadUInt16();
			int num3 = PooledReader0.ReadInt32();
			byte b = PooledReader0.ReadUInt8Unpacked();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcSpawnAIAircraft___222092229(text, num, num2, num3, b, conn);
			}
		}

		private void RpcWriter___Server_RpcSpawnFlightObject___3076756246(string prefab, Vector3 absolutePosition, Vector3 rotation, ArraySegment<byte> initData, int uniqueID, NetworkConnection clientConnection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(prefab);
			pooledWriter.WriteVector3(absolutePosition);
			pooledWriter.WriteVector3(rotation);
			pooledWriter.WriteArraySegmentAndSize(initData);
			pooledWriter.WriteInt32(uniqueID);
			SendServerRpc(7u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSpawnFlightObject___3076756246(string P_0, Vector3 P_1, Vector3 P_2, ArraySegment<byte> P_3, int P_4, NetworkConnection P_5)
		{
			if (P_4 == 0 || FlightObjectsManager.GetFlightObjectByID(P_4) == null)
			{
				ServerManager serverManager = Game.Instance.NetworkGameManager.NetworkManager.ServerManager;
				Vector3 position = Utility.ConvertAbsoluteToFloatingOriginPosition(P_1);
				NetworkFlightObject networkFlightObject = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkFlightObject>(P_0);
				networkFlightObject.transform.SetPositionAndRotation(position, Quaternion.Euler(P_2));
				networkFlightObject.ServerInitialize(P_3, null, P_4);
				serverManager.Spawn(networkFlightObject.gameObject, P_5);
			}
			else
			{
				Debug.Log($"Did not spawn {P_0} with unique ID {P_4} because it's already been spawned");
			}
		}

		private void RpcReader___Server_RpcSpawnFlightObject___3076756246(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcSpawnFlightObject___3076756246(text, vector, vector2, arraySegment, num, conn);
			}
		}

		private void RpcWriter___Server_RpcSpawnGameObject___563120266(string prefab, Vector3 absolutePosition, Vector3 rotation, NetworkConnection clientConnection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(prefab);
			pooledWriter.WriteVector3(absolutePosition);
			pooledWriter.WriteVector3(rotation);
			SendServerRpc(8u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSpawnGameObject___563120266(string P_0, Vector3 P_1, Vector3 P_2, NetworkConnection P_3)
		{
			ServerManager serverManager = Game.Instance.NetworkGameManager.NetworkManager.ServerManager;
			Vector3 position = Utility.ConvertAbsoluteToFloatingOriginPosition(P_1);
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab(P_0);
			gameObject.transform.SetPositionAndRotation(position, Quaternion.Euler(P_2));
			serverManager.Spawn(gameObject, P_3);
		}

		private void RpcReader___Server_RpcSpawnGameObject___563120266(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcSpawnGameObject___563120266(text, vector, vector2, conn);
			}
		}

		private void RpcWriter___Server_RpcUnregisterFlightObjectSpawner___3266232555(int spawnerUniqueId, NetworkConnection clientConnection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(spawnerUniqueId);
			SendServerRpc(9u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcUnregisterFlightObjectSpawner___3266232555(int P_0, NetworkConnection P_1)
		{
			FlightObjectsManager.Server.UnregisterSpawner(P_0, P_1);
		}

		private void RpcReader___Server_RpcUnregisterFlightObjectSpawner___3266232555(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcUnregisterFlightObjectSpawner___3266232555(num, conn);
			}
		}

		private void RpcWriter___Server_SendChatMessageToAllClientsRpc___2959024886(int ownerId, byte[] messageBytes, NetworkConnection sender = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(ownerId);
			GeneratedWriters___Internal.GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated(pooledWriter, messageBytes);
			SendServerRpc(10u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SendChatMessageToAllClientsRpc___2959024886(int P_0, byte[] P_1, NetworkConnection P_2)
		{
			if (BadWordDetector.IsTextClean(Encoding.UTF8.GetString(P_1)))
			{
				SendChatMessageToAllObservers(P_0, P_1);
			}
			else
			{
				SendChatMessageToTarget(P_2, P_0, P_1);
			}
		}

		private void RpcReader___Server_SendChatMessageToAllClientsRpc___2959024886(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			byte[] array = PooledReader0.ReadUInt8ArrayAndSizeAllocated();
			if (base.IsServerInitialized)
			{
				RpcLogic___SendChatMessageToAllClientsRpc___2959024886(num, array, conn);
			}
		}

		private void RpcWriter___Observers_SendChatMessageToAllObservers___2109915117(int ownerId, byte[] messageBytes)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(ownerId);
			GeneratedWriters___Internal.GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated(pooledWriter, messageBytes);
			SendObserversRpc(11u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SendChatMessageToAllObservers___2109915117(int P_0, byte[] P_1)
		{
			string messageText = Encoding.UTF8.GetString(P_1);
			ChatMessages.RaiseMessageReceived(P_0, messageText);
		}

		private void RpcReader___Observers_SendChatMessageToAllObservers___2109915117(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			byte[] array = PooledReader0.ReadUInt8ArrayAndSizeAllocated();
			if (base.IsClientInitialized)
			{
				RpcLogic___SendChatMessageToAllObservers___2109915117(num, array);
			}
		}

		private void RpcWriter___Target_SendChatMessageToTarget___1878726436(NetworkConnection target, int ownerId, byte[] messageBytes)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(ownerId);
			GeneratedWriters___Internal.GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated(pooledWriter, messageBytes);
			SendTargetRpc(12u, pooledWriter, channel, DataOrderType.Default, target, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SendChatMessageToTarget___1878726436(NetworkConnection P_0, int P_1, byte[] P_2)
		{
			string messageText = Encoding.UTF8.GetString(P_2);
			ChatMessages.RaiseMessageReceived(P_1, messageText);
		}

		private void RpcReader___Target_SendChatMessageToTarget___1878726436(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			byte[] array = PooledReader0.ReadUInt8ArrayAndSizeAllocated();
			if (base.IsClientInitialized)
			{
				RpcLogic___SendChatMessageToTarget___1878726436(base.LocalConnection, num, array);
			}
		}

		private void RpcWriter___Target_ShowMessageClientRpc___783169041(NetworkConnection targetPlayer, string messageText, bool logMessage, bool highlighted, float time)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(messageText);
			pooledWriter.WriteBoolean(logMessage);
			pooledWriter.WriteBoolean(highlighted);
			pooledWriter.WriteSingle(time);
			SendTargetRpc(13u, pooledWriter, channel, DataOrderType.Default, targetPlayer, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ShowMessageClientRpc___783169041(NetworkConnection P_0, string P_1, bool P_2, bool P_3, float P_4)
		{
			ShowMessageToLocalPlayer(P_1, P_2, P_3, P_4);
		}

		private void RpcReader___Target_ShowMessageClientRpc___783169041(PooledReader PooledReader0, Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			bool flag = PooledReader0.ReadBoolean();
			bool flag2 = PooledReader0.ReadBoolean();
			float num = PooledReader0.ReadSingle();
			if (base.IsClientInitialized)
			{
				RpcLogic___ShowMessageClientRpc___783169041(base.LocalConnection, text, flag, flag2, num);
			}
		}

		private void RpcWriter___Observers_ShowMessageClientRpc___783169041(NetworkConnection targetPlayer, string messageText, bool logMessage, bool highlighted, float time)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(messageText);
			pooledWriter.WriteBoolean(logMessage);
			pooledWriter.WriteBoolean(highlighted);
			pooledWriter.WriteSingle(time);
			SendObserversRpc(14u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcReader___Observers_ShowMessageClientRpc___783169041(PooledReader PooledReader0, Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			bool flag = PooledReader0.ReadBoolean();
			bool flag2 = PooledReader0.ReadBoolean();
			float num = PooledReader0.ReadSingle();
			if (base.IsClientInitialized)
			{
				RpcLogic___ShowMessageClientRpc___783169041(null, text, flag, flag2, num);
			}
		}

		private void RpcWriter___Server_ShowMessageServerRpc___77971122(NetworkConnection targetPlayer, string messageText, bool logMessage, bool highlighted, float time, NetworkConnection connection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(targetPlayer);
			pooledWriter.WriteString(messageText);
			pooledWriter.WriteBoolean(logMessage);
			pooledWriter.WriteBoolean(highlighted);
			pooledWriter.WriteSingle(time);
			SendServerRpc(15u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ShowMessageServerRpc___77971122(NetworkConnection P_0, string P_1, bool P_2, bool P_3, float P_4, NetworkConnection P_5)
		{
			if ((object)P_0 != null && P_0.IsValid)
			{
				ShowMessageClientRpc(P_0, P_1, P_2, P_3, P_4);
			}
			else
			{
				ShowMessageClientRpc(null, P_1, P_2, P_3, P_4);
			}
		}

		private void RpcReader___Server_ShowMessageServerRpc___77971122(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			string text = PooledReader0.ReadStringAllocated();
			bool flag = PooledReader0.ReadBoolean();
			bool flag2 = PooledReader0.ReadBoolean();
			float num = PooledReader0.ReadSingle();
			if (base.IsServerInitialized)
			{
				RpcLogic___ShowMessageServerRpc___77971122(networkConnection, text, flag, flag2, num, conn);
			}
		}

		private void RpcWriter___Target_RpcClient___2549324077(NetworkConnection target, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendTargetRpc(16u, pooledWriter, channel2, DataOrderType.Default, target, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcClient___2549324077(NetworkConnection P_0, FlightSceneClientRpcType P_1, ArraySegment<byte> P_2, Channel P_3)
		{
			_clientRpcSubscribers[(uint)P_1]?.Invoke(P_2);
		}

		private void RpcReader___Target_RpcClient___2549324077(PooledReader PooledReader0, Channel channel)
		{
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcClient___2549324077(base.LocalConnection, flightSceneClientRpcType, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcClient___2549324077(NetworkConnection target, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(17u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcReader___Observers_RpcClient___2549324077(PooledReader PooledReader0, Channel channel)
		{
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcClient___2549324077(null, flightSceneClientRpcType, arraySegment, channel);
			}
		}

		private void RpcWriter___Target_RpcClientAndLocal___2549324077(NetworkConnection target, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendTargetRpc(18u, pooledWriter, channel2, DataOrderType.Default, target, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcClientAndLocal___2549324077(NetworkConnection P_0, FlightSceneClientRpcType P_1, ArraySegment<byte> P_2, Channel P_3)
		{
			_clientRpcSubscribers[(uint)P_1]?.Invoke(P_2);
		}

		private void RpcReader___Target_RpcClientAndLocal___2549324077(PooledReader PooledReader0, Channel channel)
		{
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___RpcClientAndLocal___2549324077(base.LocalConnection, flightSceneClientRpcType, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcClientAndLocal___2549324077(NetworkConnection target, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(19u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcReader___Observers_RpcClientAndLocal___2549324077(PooledReader PooledReader0, Channel channel)
		{
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___RpcClientAndLocal___2549324077(null, flightSceneClientRpcType, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcClientAndLocalExcludingOwner___2354497016(FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(20u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcClientAndLocalExcludingOwner___2354497016(FlightSceneClientRpcType P_0, ArraySegment<byte> P_1, Channel P_2)
		{
			_clientRpcSubscribers[(uint)P_0]?.Invoke(P_1);
		}

		private void RpcReader___Observers_RpcClientAndLocalExcludingOwner___2354497016(PooledReader PooledReader0, Channel channel)
		{
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___RpcClientAndLocalExcludingOwner___2354497016(flightSceneClientRpcType, arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcClientExcludingOwner___2354497016(FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(21u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcClientExcludingOwner___2354497016(FlightSceneClientRpcType P_0, ArraySegment<byte> P_1, Channel P_2)
		{
			_clientRpcSubscribers[(uint)P_0]?.Invoke(P_1);
		}

		private void RpcReader___Observers_RpcClientExcludingOwner___2354497016(PooledReader PooledReader0, Channel channel)
		{
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcClientExcludingOwner___2354497016(flightSceneClientRpcType, arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcServer___29944227(FlightSceneServerRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(22u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcServer___29944227(FlightSceneServerRpcType P_0, ArraySegment<byte> P_1, Channel P_2, NetworkConnection P_3)
		{
			_serverRpcSubscribers[(uint)P_0]?.Invoke(P_1, P_3);
		}

		private void RpcReader___Server_RpcServer___29944227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			FlightSceneServerRpcType flightSceneServerRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcServer___29944227(flightSceneServerRpcType, arraySegment, channel, conn);
			}
		}

		private void RpcWriter___Server_RpcServerAndLocal___29944227(FlightSceneServerRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable, NetworkConnection sender = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(23u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcServerAndLocal___29944227(FlightSceneServerRpcType P_0, ArraySegment<byte> P_1, Channel P_2, NetworkConnection P_3)
		{
			_serverRpcSubscribers[(uint)P_0]?.Invoke(P_1, P_3);
		}

		private void RpcReader___Server_RpcServerAndLocal___29944227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			FlightSceneServerRpcType flightSceneServerRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___RpcServerAndLocal___29944227(flightSceneServerRpcType, arraySegment, channel, conn);
			}
		}

		private void RpcWriter___Server_RpcServerRelay___3622131982(NetworkConnection target, bool excludeOwner, FlightSceneClientRpcType type, ArraySegment<byte> data, Channel channel = Channel.Reliable)
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
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(pooledWriter, type);
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(24u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcServerRelay___3622131982(NetworkConnection P_0, bool P_1, FlightSceneClientRpcType P_2, ArraySegment<byte> P_3, Channel P_4)
		{
			if (P_0 != null && !P_0.IsValid)
			{
				P_0 = null;
			}
			if (P_1)
			{
				RpcClientExcludingOwner(P_2, P_3, P_4);
			}
			else
			{
				RpcClient(P_0, P_2, P_3, P_4);
			}
		}

		private void RpcReader___Server_RpcServerRelay___3622131982(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			bool flag = PooledReader0.ReadBoolean();
			FlightSceneClientRpcType flightSceneClientRpcType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcServerRelay___3622131982(networkConnection, flag, flightSceneClientRpcType, arraySegment, channel);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002EFlightSceneNetworkScript_Game_002Edll()
		{
			_serverTickRate.OnChange += OnServerTickRateChanged;
			_serverPhysicsTime.OnChange += OnServerPhysicsFrameChanged;
			_serverMaxPartCount.SetInitialValues(500);
			Game.Instance.NetworkGameManager?.SteamLobbyManager?.OnLobbySettingsChanged();
			FlightObjectsManager = NetworkFlightObjectManager.Create(this);
		}
	}
}
