using System;
using Assets.Scripts.Character;
using Assets.Scripts.Character.Suit;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Exceptions;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Server;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkPlayerScript : NetworkBehaviour
	{
		public readonly SyncVar<bool> _allowCopyCraftXml = new SyncVar<bool>(new SyncTypeSettings(WritePermission.ClientUnsynchronized, ReadPermission.ExcludeOwner));

		public readonly SyncVar<bool> _inDesigner = new SyncVar<bool>(new SyncTypeSettings(WritePermission.ClientUnsynchronized, ReadPermission.ExcludeOwner, 1f, Channel.Reliable));

		private FlightScenePlayer _flightScenePlayer;

		private string _name;

		private NetworkGameManager _networkGameManager;

		[SerializeField]
		private ushort _teamId;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkPlayerScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkPlayerScriptGame_002Edll_Excuted;

		public bool AllowCopyCraftXml
		{
			get
			{
				return _allowCopyCraftXml.Value;
			}
			set
			{
				if (base.IsOwner)
				{
					SetAllowCopyCraftXml(value);
					return;
				}
				throw new NotSupportedException();
			}
		}

		public string CraftId { get; set; } = "__editor__.xml";

		public FlightScenePlayer FlightScenePlayer
		{
			get
			{
				return _flightScenePlayer;
			}
			set
			{
				if (_flightScenePlayer != null && IsPrimaryLocal)
				{
					_flightScenePlayer.EnteredInFlightDesigner -= OnEnteredInFlightDesigner;
					_flightScenePlayer.ExitedInFlightDesigner -= OnExitedInFlightDesigner;
				}
				_flightScenePlayer = value;
				if (_flightScenePlayer != null && IsPrimaryLocal)
				{
					_flightScenePlayer.EnteredInFlightDesigner += OnEnteredInFlightDesigner;
					_flightScenePlayer.ExitedInFlightDesigner += OnExitedInFlightDesigner;
				}
			}
		}

		public bool InDesigner => _inDesigner.Value;

		public bool Initialized { get; private set; }

		public bool IsLocal { get; private set; }

		public bool IsNPC { get; private set; }

		public bool IsPrimaryLocal { get; private set; }

		public bool IsServerPlayer { get; private set; }

		public string Name
		{
			get
			{
				return _name;
			}
			private set
			{
				string text = ValidateName(value);
				if (string.IsNullOrWhiteSpace(text))
				{
					if (!(_name == value))
					{
						string text2 = _name;
						_name = value;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							Debug.Log("Player '" + text2 + "' changed their name to '" + value + "'.");
							this.NameChanged?.Invoke(this, new NetworkPlayerNameChangedEventArgs(this, text2, value));
						}
					}
				}
				else
				{
					Debug.Log("Invalid player name: " + value + System.Environment.NewLine + text);
					if (string.IsNullOrWhiteSpace(_name))
					{
						string text3 = $"Player {PlayerId}";
						Debug.Log("Player's name will be changed to " + text3);
						_name = text3;
					}
				}
			}
		}

		public int PlayerId { get; private set; }

		public ulong SteamId { get; set; }

		public ushort TeamId => _teamId;

		public event EventHandler<NetworkPlayerNameChangedEventArgs> NameChanged;

		public event EventHandler<TeamChangedEventArgs> TeamChanged;

		public void ChangeName(string name)
		{
			if (!base.IsOwner)
			{
				throw new InvalidOperationException("Unable to change the name of another player.");
			}
			string text = ValidateName(name);
			if (!string.IsNullOrWhiteSpace(text))
			{
				throw new InvalidPlayerNameException(text);
			}
			ChangeNameServerRpc(name);
		}

		public void ChangeTeam(ushort? teamId)
		{
			if (!base.IsServerStarted && base.Owner != base.LocalConnection)
			{
				Debug.LogError("Only the server or the network player's owner can change a player's team.");
			}
			else
			{
				ChangeTeamServerRpc(teamId);
			}
		}

		public void Initialize(NetworkGameManager networkGameManager)
		{
			if (Initialized)
			{
				Debug.LogError($"Unable to initialize network player '{base.ObjectId}' because the player has already been initialized.");
				return;
			}
			_networkGameManager = networkGameManager;
			IsLocal = base.IsOwner;
			if (IsLocal)
			{
				IsPrimaryLocal = this == networkGameManager.LocalPlayer;
				networkGameManager.PrimaryLocalPlayerChanged += OnPrimaryLocalPlayerChanged;
			}
			Initialized = true;
		}

		public void InitializeAi(int playerId, ushort teamId)
		{
			IsNPC = true;
			PlayerId = playerId;
			_teamId = teamId;
			Name = NameGeneratorUtility.Callsign(addFlair: false);
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			if (base.IsOwner)
			{
				AllowCopyCraftXml = Game.Instance.Settings.Gameplay.Flight.AllowCopyCraftXml.Value;
			}
			if (!IsNPC)
			{
				if (base.Owner.CustomData != null)
				{
					Debug.LogError("NetworkPlayerScript is overwriting existing data for 'Owner.CustomData'.");
				}
				base.Owner.CustomData = this;
			}
			Game.Instance.NetworkGameManager.OnPlayerJoin(this);
			if (IsPrimaryLocal)
			{
				RpcSpawnCharacter();
			}
		}

		public override void OnStartServer()
		{
			base.OnStartServer();
			if (!IsNPC)
			{
				IsServerPlayer = base.Owner == base.LocalConnection;
				if (base.Owner.CustomData is NetworkConnectionAuthenticator.ClientConnectionData clientConnectionData)
				{
					Name = clientConnectionData.UserName;
					SteamId = clientConnectionData.SteamId;
					base.Owner.CustomData = null;
				}
				else
				{
					Debug.Log("ClientConnectionData not found.");
				}
				_teamId = Game.Instance.NetworkGameManager.TeamManager.GetNextTeamId(this);
				PlayerId = base.OwnerId;
			}
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			Game.Instance.NetworkGameManager.OnPlayerClientStop(this);
			FlightScenePlayer?.OnPlayerLeaving();
			Game.Instance.NetworkGameManager.OnPlayerLeave(this);
			if ((object)_networkGameManager != null)
			{
				_networkGameManager.PrimaryLocalPlayerChanged -= OnPrimaryLocalPlayerChanged;
			}
		}

		public override void OnStopServer()
		{
			base.OnStopServer();
			if (IsNPC)
			{
				NetworkAircraftScript networkAircraftScript = FlightScenePlayer?.GetNetworkAircraft() as NetworkAircraftScript;
				if (networkAircraftScript != null && networkAircraftScript.IsSpawned)
				{
					networkAircraftScript.Despawn(DespawnType.Destroy);
				}
			}
			Game.Instance.NetworkGameManager.OnPlayerServerStop(this);
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			IsServerPlayer = reader.ReadBoolean();
			IsNPC = reader.ReadBoolean();
			PlayerId = reader.ReadInt32();
			Name = reader.ReadStringAllocated();
			SteamId = reader.ReadUInt64();
			_teamId = reader.ReadUInt16();
		}

		public void RequestDespawn()
		{
			RpcRequestDespawn();
		}

		[ServerRpc(RunLocally = true)]
		public void RpcOnBeginReposition(Vector3 approximateGlobalPosition)
		{
			RpcWriter___Server_RpcOnBeginReposition___4276783012(approximateGlobalPosition);
			RpcLogic___RpcOnBeginReposition___4276783012(approximateGlobalPosition);
		}

		[ServerRpc(RunLocally = true)]
		public void RpcOnEndReposition(Vector3 finalGlobalPosition, Vector3 finalRotation, float physicsTime)
		{
			RpcWriter___Server_RpcOnEndReposition___2690242654(finalGlobalPosition, finalRotation, physicsTime);
			RpcLogic___RpcOnEndReposition___2690242654(finalGlobalPosition, finalRotation, physicsTime);
		}

		public void SendSuitData(string characterID, string suitID, CharacterSuitData suitData)
		{
			SendSuitDataServerRpc(characterID, suitID, suitData);
		}

		public void SpawnPlayerAircraft(StartLocationData location, bool startPaused)
		{
			if (base.IsOwner)
			{
				byte craftOwnerSpawnDataId = CraftOwnerSpawnData.CreateAndStore(location, startPaused);
				int spawnLocationHashCode = location.GetSpawnLocationHashCode();
				RpcSpawnPlayerAircraft(CraftId, spawnLocationHashCode, craftOwnerSpawnDataId);
			}
		}

		public string ValidateName(string name)
		{
			return null;
		}

		public override void WritePayload(NetworkConnection connection, Writer writer)
		{
			base.WritePayload(connection, writer);
			writer.WriteBoolean(IsServerPlayer);
			writer.WriteBoolean(IsNPC);
			writer.WriteInt32(PlayerId);
			writer.WriteString(Name);
			writer.WriteUInt64(SteamId);
			writer.WriteUInt16(_teamId);
		}

		[ObserversRpc]
		private void ChangeNameClientRpc(string name)
		{
			RpcWriter___Observers_ChangeNameClientRpc___3615296227(name);
		}

		[ServerRpc]
		private void ChangeNameServerRpc(string name)
		{
			RpcWriter___Server_ChangeNameServerRpc___3615296227(name);
		}

		[ObserversRpc(RunLocally = true)]
		private void ChangeTeamClientRpc(ushort teamId)
		{
			RpcWriter___Observers_ChangeTeamClientRpc___1455938981(teamId);
			RpcLogic___ChangeTeamClientRpc___1455938981(teamId);
		}

		[ServerRpc(RunLocally = true, RequireOwnership = false)]
		private void ChangeTeamServerRpc(ushort? teamId)
		{
			RpcWriter___Server_ChangeTeamServerRpc___3490729858(teamId);
			RpcLogic___ChangeTeamServerRpc___3490729858(teamId);
		}

		private void OnEnteredInFlightDesigner(object sender, FlightScenePlayerEventArgs e)
		{
			SetInDesigner(inDesigner: true);
		}

		private void OnExitedInFlightDesigner(object sender, FlightScenePlayerEventArgs e)
		{
			SetInDesigner(inDesigner: false);
		}

		private void OnPrimaryLocalPlayerChanged(object sender, NetworkPlayerChangedEventArgs e)
		{
			IsPrimaryLocal = e.NewPlayer == this;
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcRequestDespawn(NetworkConnection connection = null)
		{
			RpcWriter___Server_RpcRequestDespawn___328543758(connection);
		}

		[ServerRpc]
		private void RpcSpawnCharacter(NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcSpawnCharacter___328543758(clientConnection);
		}

		[ServerRpc]
		private void RpcSpawnPlayerAircraft(string craftId, int startLocationIdHashCode, byte craftOwnerSpawnDataId, NetworkConnection clientConnection = null)
		{
			RpcWriter___Server_RpcSpawnPlayerAircraft___456348060(craftId, startLocationIdHashCode, craftOwnerSpawnDataId, clientConnection);
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void SendSuitDataClientRpc(string characterID, string suitID, CharacterSuitData suitData)
		{
			RpcWriter___Observers_SendSuitDataClientRpc___2978881192(characterID, suitID, suitData);
		}

		[ServerRpc]
		private void SendSuitDataServerRpc(string characterID, string suitID, CharacterSuitData suitData)
		{
			RpcWriter___Server_SendSuitDataServerRpc___2978881192(characterID, suitID, suitData);
		}

		[ServerRpc(RunLocally = true)]
		private void SetAllowCopyCraftXml(bool value)
		{
			RpcWriter___Server_SetAllowCopyCraftXml___1140765316(value);
			RpcLogic___SetAllowCopyCraftXml___1140765316(value);
		}

		[ServerRpc(RunLocally = true)]
		private void SetInDesigner(bool inDesigner)
		{
			RpcWriter___Server_SetInDesigner___1140765316(inDesigner);
			RpcLogic___SetInDesigner___1140765316(inDesigner);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkPlayerScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkPlayerScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				_inDesigner.InitializeEarly(this, 1u, isSyncObject: false);
				_allowCopyCraftXml.InitializeEarly(this, 0u, isSyncObject: false);
				RegisterServerRpc(0u, RpcReader___Server_RpcOnBeginReposition___4276783012);
				RegisterServerRpc(1u, RpcReader___Server_RpcOnEndReposition___2690242654);
				RegisterObserversRpc(2u, RpcReader___Observers_ChangeNameClientRpc___3615296227);
				RegisterServerRpc(3u, RpcReader___Server_ChangeNameServerRpc___3615296227);
				RegisterObserversRpc(4u, RpcReader___Observers_ChangeTeamClientRpc___1455938981);
				RegisterServerRpc(5u, RpcReader___Server_ChangeTeamServerRpc___3490729858);
				RegisterServerRpc(6u, RpcReader___Server_RpcRequestDespawn___328543758);
				RegisterServerRpc(7u, RpcReader___Server_RpcSpawnCharacter___328543758);
				RegisterServerRpc(8u, RpcReader___Server_RpcSpawnPlayerAircraft___456348060);
				RegisterObserversRpc(9u, RpcReader___Observers_SendSuitDataClientRpc___2978881192);
				RegisterServerRpc(10u, RpcReader___Server_SendSuitDataServerRpc___2978881192);
				RegisterServerRpc(11u, RpcReader___Server_SetAllowCopyCraftXml___1140765316);
				RegisterServerRpc(12u, RpcReader___Server_SetInDesigner___1140765316);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkPlayerScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkPlayerScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
				_inDesigner.InitializeLate();
				_allowCopyCraftXml.InitializeLate();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_RpcOnBeginReposition___4276783012(Vector3 approximateGlobalPosition)
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
			pooledWriter.WriteVector3(approximateGlobalPosition);
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___RpcOnBeginReposition___4276783012(Vector3 P_0)
		{
			FlightScenePlayer.OnBeginRepositionServerAndClient(P_0);
		}

		private void RpcReader___Server_RpcOnBeginReposition___4276783012(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			Vector3 vector = PooledReader0.ReadVector3();
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___RpcOnBeginReposition___4276783012(vector);
			}
		}

		private void RpcWriter___Server_RpcOnEndReposition___2690242654(Vector3 finalGlobalPosition, Vector3 finalRotation, float physicsTime)
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
			pooledWriter.WriteVector3(finalGlobalPosition);
			pooledWriter.WriteVector3(finalRotation);
			pooledWriter.WriteSingle(physicsTime);
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___RpcOnEndReposition___2690242654(Vector3 P_0, Vector3 P_1, float P_2)
		{
			FlightScenePlayer.OnEndRepositionServerAndClient(P_0, P_1, P_2);
		}

		private void RpcReader___Server_RpcOnEndReposition___2690242654(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			float num = PooledReader0.ReadSingle();
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___RpcOnEndReposition___2690242654(vector, vector2, num);
			}
		}

		private void RpcWriter___Observers_ChangeNameClientRpc___3615296227(string name)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(name);
			SendObserversRpc(2u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeNameClientRpc___3615296227(string P_0)
		{
			Name = P_0;
		}

		private void RpcReader___Observers_ChangeNameClientRpc___3615296227(PooledReader PooledReader0, Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			if (base.IsClientInitialized)
			{
				RpcLogic___ChangeNameClientRpc___3615296227(text);
			}
		}

		private void RpcWriter___Server_ChangeNameServerRpc___3615296227(string name)
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
			pooledWriter.WriteString(name);
			SendServerRpc(3u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeNameServerRpc___3615296227(string P_0)
		{
			ChangeNameClientRpc(P_0);
		}

		private void RpcReader___Server_ChangeNameServerRpc___3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___ChangeNameServerRpc___3615296227(text);
			}
		}

		private void RpcWriter___Observers_ChangeTeamClientRpc___1455938981(ushort teamId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt16(teamId);
			SendObserversRpc(4u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeTeamClientRpc___1455938981(ushort P_0)
		{
			if (_teamId != P_0)
			{
				ushort teamId = _teamId;
				_teamId = P_0;
				this.TeamChanged?.Invoke(this, new TeamChangedEventArgs(teamId, P_0));
			}
		}

		private void RpcReader___Observers_ChangeTeamClientRpc___1455938981(PooledReader PooledReader0, Channel channel)
		{
			ushort num = PooledReader0.ReadUInt16();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ChangeTeamClientRpc___1455938981(num);
			}
		}

		private void RpcWriter___Server_ChangeTeamServerRpc___3490729858(ushort? teamId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EUInt16_003EFishNet_002ESerializing_002EGenerated(pooledWriter, teamId);
			SendServerRpc(5u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeTeamServerRpc___3490729858(ushort? P_0)
		{
			if (base.IsServerStarted)
			{
				ushort teamId = _teamId;
				if (!P_0.HasValue)
				{
					P_0 = Game.Instance.NetworkGameManager.TeamManager.GetNextTeamId(this);
				}
				ChangeTeamClientRpc(P_0.Value);
				FlightSceneScript.Instance?.TeamAggressionManager.ResetAggressionLevelsIfTeamContainsNoPlayers(teamId);
			}
		}

		private void RpcReader___Server_ChangeTeamServerRpc___3490729858(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			ushort? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EUInt16_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized && !conn.IsLocalClient)
			{
				RpcLogic___ChangeTeamServerRpc___3490729858(num);
			}
		}

		private void RpcWriter___Server_RpcRequestDespawn___328543758(NetworkConnection connection = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(6u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcRequestDespawn___328543758(NetworkConnection P_0)
		{
			if (P_0 == base.Owner || P_0.IsLocalClient || IsNPC)
			{
				Despawn(DespawnType.Destroy);
			}
		}

		private void RpcReader___Server_RpcRequestDespawn___328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcRequestDespawn___328543758(conn);
			}
		}

		private void RpcWriter___Server_RpcSpawnCharacter___328543758(NetworkConnection clientConnection = null)
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
			SendServerRpc(7u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSpawnCharacter___328543758(NetworkConnection P_0)
		{
			ServerManager serverManager = Game.Instance.NetworkGameManager.NetworkManager.ServerManager;
			NetworkCharacterScript networkCharacterScript = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkCharacterScript>("Characters/Flight/Chad");
			serverManager.Spawn(networkCharacterScript.gameObject, P_0);
		}

		private void RpcReader___Server_RpcSpawnCharacter___328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcSpawnCharacter___328543758(conn);
			}
		}

		private void RpcWriter___Server_RpcSpawnPlayerAircraft___456348060(string craftId, int startLocationIdHashCode, byte craftOwnerSpawnDataId, NetworkConnection clientConnection = null)
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
			pooledWriter.WriteString(craftId);
			pooledWriter.WriteInt32(startLocationIdHashCode);
			pooledWriter.WriteUInt8Unpacked(craftOwnerSpawnDataId);
			SendServerRpc(8u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSpawnPlayerAircraft___456348060(string P_0, int P_1, byte P_2, NetworkConnection P_3)
		{
			if (FlightScenePlayer?.NetworkedActivity == null)
			{
				FlightSceneScript.Instance.TeamAggressionManager.ResetAggressionLevelsWithPlayerTeams(TeamId);
			}
			NetworkAircraftScript networkAircraftScript = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkAircraftScript>("Multiplayer/NetworkAircraft");
			networkAircraftScript.ServerInitialize(P_0, P_1, P_2, PlayerId);
			Game.Instance.NetworkGameManager.NetworkManager.ServerManager.Spawn(networkAircraftScript.gameObject, P_3);
		}

		private void RpcReader___Server_RpcSpawnPlayerAircraft___456348060(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			int num = PooledReader0.ReadInt32();
			byte b = PooledReader0.ReadUInt8Unpacked();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcSpawnPlayerAircraft___456348060(text, num, b, conn);
			}
		}

		private void RpcWriter___Observers_SendSuitDataClientRpc___2978881192(string characterID, string suitID, CharacterSuitData suitData)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(characterID);
			pooledWriter.WriteString(suitID);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerated(pooledWriter, suitData);
			SendObserversRpc(9u, pooledWriter, channel, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SendSuitDataClientRpc___2978881192(string P_0, string P_1, CharacterSuitData P_2)
		{
			if (FlightScenePlayer?.CharacterSuit != null)
			{
				FlightScenePlayer.SetCharacterSuit(CharacterManager.Instance.SwapCharacterSuit(FlightScenePlayer.CharacterSuit, P_0, P_1, P_2));
				FlightScenePlayer.CharacterSuit.ApplyData(P_2);
			}
			else
			{
				Debug.LogError($"Could not load character suit for {Name}({PlayerId}) because default hasn't loaded or wasn't correctly initialized.");
			}
		}

		private void RpcReader___Observers_SendSuitDataClientRpc___2978881192(PooledReader PooledReader0, Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			string text2 = PooledReader0.ReadStringAllocated();
			CharacterSuitData characterSuitData = GeneratedReaders___Internal.GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___SendSuitDataClientRpc___2978881192(text, text2, characterSuitData);
			}
		}

		private void RpcWriter___Server_SendSuitDataServerRpc___2978881192(string characterID, string suitID, CharacterSuitData suitData)
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
			pooledWriter.WriteString(characterID);
			pooledWriter.WriteString(suitID);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerated(pooledWriter, suitData);
			SendServerRpc(10u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SendSuitDataServerRpc___2978881192(string P_0, string P_1, CharacterSuitData P_2)
		{
			SendSuitDataClientRpc(P_0, P_1, P_2);
		}

		private void RpcReader___Server_SendSuitDataServerRpc___2978881192(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			string text = PooledReader0.ReadStringAllocated();
			string text2 = PooledReader0.ReadStringAllocated();
			CharacterSuitData characterSuitData = GeneratedReaders___Internal.GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___SendSuitDataServerRpc___2978881192(text, text2, characterSuitData);
			}
		}

		private void RpcWriter___Server_SetAllowCopyCraftXml___1140765316(bool value)
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
			pooledWriter.WriteBoolean(value);
			SendServerRpc(11u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SetAllowCopyCraftXml___1140765316(bool P_0)
		{
			_allowCopyCraftXml.Value = P_0;
		}

		private void RpcReader___Server_SetAllowCopyCraftXml___1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___SetAllowCopyCraftXml___1140765316(flag);
			}
		}

		private void RpcWriter___Server_SetInDesigner___1140765316(bool inDesigner)
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
			pooledWriter.WriteBoolean(inDesigner);
			SendServerRpc(12u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SetInDesigner___1140765316(bool P_0)
		{
			_inDesigner.Value = P_0;
		}

		private void RpcReader___Server_SetInDesigner___1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___SetInDesigner___1140765316(flag);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}
	}
}
