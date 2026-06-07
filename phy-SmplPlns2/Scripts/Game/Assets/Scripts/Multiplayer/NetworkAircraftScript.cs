using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Exceptions;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Exceptions;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Jundroo.Common.Pool;
using Jundroo.Common.Threading.Tasks;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkAircraftScript : NetworkBehaviour, INetworkAircraft
	{
		private static class Profile
		{
			public static readonly ProfilerMarker ActivateCraft = new ProfilerMarker("NetworkAircraftScript.ActivateCraft");

			public static readonly ProfilerMarker OnPostTick = new ProfilerMarker("NetworkAircraftScript.OnPostTick");

			public static readonly ProfilerMarker StartLoadingAircraft_LoadAircraftData = new ProfilerMarker("NetworkAircraftScript.StartLoadingAircraft - Load Aircraft Data");
		}

		private static ushort _nextNetworkSpawnId;

		public readonly SyncVar<string> _craftId = new SyncVar<string>();

		public readonly SyncVar<int> _playerId = new SyncVar<int>();

		private bool _aircraftInitialized;

		private bool _aircraftLoadCompletedEventRaised;

		private bool _aircraftLoadedEventRaised;

		private bool _aircraftLoadStartedEventRaised;

		private bool _aircraftUnloadedEventRaised;

		private BodyConfigurationState _bodyConfigurationState;

		private List<ArraySegment<byte>> _bufferedPartNetworkMessages = new List<ArraySegment<byte>>();

		private bool _bufferedPlayerEnterState = true;

		private CraftOwnerSpawnData _craftOwnerSpawnData;

		private byte _craftOwnerSpawnDataId;

		private bool _craftRepositioned;

		private int _currentState;

		private Vector3? _initialSpawnPosition;

		private Vector3? _initialSpawnRotation;

		private byte[] _initialStateUpdateBuffer;

		private ArraySegment<byte> _initialStateUpdateData;

		private NetworkAircraftLoader _loader;

		[SerializeField]
		private LoadingAircraftStatusScript _loadingStatus;

		private BodyConfigurationMessage _message;

		private string _receivedCraftXmlHash;

		private int _sendFrame;

		private byte[] _serverBytes;

		private string _serverHash;

		private bool _serverInitialized;

		private int _startLocationIdHashCode;

		private CraftStateSerializer _stateSerializer;

		private TargetAlertType? _tickAlert;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptGame_002Edll_Excuted;

		public AircraftScript AircraftScript { get; private set; }

		public XElement CraftXml => _loader.CraftXml;

		public bool IsCraftLoading { get; private set; }

		public bool IsInitialized => _aircraftInitialized;

		public bool IsUnloaded { get; private set; }

		public ushort NetworkSpawnId { get; private set; }

		public FlightScenePlayer Player { get; private set; }

		public int PlayerId => _playerId.Value;

		bool INetworkAircraft.IsOwner => base.IsOwner;

		int INetworkAircraft.OwnerId => base.OwnerId;

		public event EventHandler<NetworkAircraftScriptEventArgs> CraftLoaded;

		public event EventHandler<NetworkAircraftScriptEventArgs> CraftLoadFailed;

		public static void OnFlightSceneAwake()
		{
			_nextNetworkSpawnId = 0;
		}

		public void CreateDamageEffect(PartDamageEffects.DamageEffectType effectType, int partId, Vector3? localPosition, Vector3? localDirection)
		{
			RpcCreateDamageEffectServer(effectType, partId, localPosition, localDirection);
		}

		public void CreateTargetedExplosion(string explosionPrefabName, Vector3 position, float explosionScale, Vector3? blastDirection, AircraftScript aircraft, Rigidbody responsibleBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType)
		{
			Vector3 vector = AircraftScript.MainCockpit.transform.InverseTransformPoint(position);
			CreateExplosionInfo explosionInfo = new CreateExplosionInfo
			{
				ExplosionPrefabName = explosionPrefabName,
				AttackerPlayerId = aircraft?.NetworkAircraft?.PlayerId,
				GlobalPosition = vector,
				ExplosionScale = explosionScale,
				BlastDirection = blastDirection,
				ImpactDirection = impactDirection,
				ImpactType = impactType
			};
			RpcCreateTargetedExplosionServer(explosionInfo);
		}

		public void DamagePart(int? attackerPlayerId, PartScript part, float damage, Vector3 hitPosition, Vector3 hitNormal)
		{
			if (attackerPlayerId.HasValue)
			{
				FlightSceneScript instance = FlightSceneScript.Instance;
				FlightScenePlayer player = instance.GetPlayer(attackerPlayerId.Value);
				instance.TeamAggressionManager.SetAggressionLevel(AircraftScript.TeamId, player.TeamId, AggressionLevel.Hostile);
			}
			Vector3 localPosition = part.transform.InverseTransformPoint(hitPosition);
			Vector3 localNormal = part.transform.InverseTransformDirection(hitNormal);
			RpcDamageRemotePartServer(attackerPlayerId, part.Part.Id, damage, localPosition, localNormal);
		}

		public void NotifyTargetAlert(TargetAlertType alert)
		{
			if (base.IsOwner)
			{
				NotifyTargetAlertLocal(alert);
			}
			else if (!_tickAlert.HasValue || alert == TargetAlertType.Locked)
			{
				_tickAlert = alert;
			}
		}

		public void OnCraftRepositioned()
		{
			_craftRepositioned = true;
		}

		public void OnPlayerLeaving()
		{
			if (!IsUnloaded)
			{
				Unload();
			}
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			if (!IsUnloaded)
			{
				Unload();
			}
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			NetworkSpawnId = reader.ReadUInt16();
			_startLocationIdHashCode = reader.ReadInt32();
			if (base.Owner == base.LocalConnection)
			{
				byte id = reader.ReadUInt8Unpacked();
				_craftOwnerSpawnData = CraftOwnerSpawnData.Retrieve(id) ?? new CraftOwnerSpawnData(FlightSceneScript.Instance.StartLocationManager.Locations[0], startPaused: false);
			}
			if (reader.ReadBoolean())
			{
				_initialSpawnPosition = reader.ReadVector3();
				_initialSpawnRotation = reader.ReadVector3();
			}
		}

		public void RequestDespawn()
		{
			base.TimeManager.OnPostTick -= OnPostTick;
			RpcRequestDespawn();
			if (Player.NetworkPlayer.IsNPC)
			{
				Player.NetworkPlayer.RequestDespawn();
			}
		}

		[ServerRpc]
		public void RpcPlayerEnteredStateServer(bool entered)
		{
			RpcWriter___Server_RpcPlayerEnteredStateServer___1140765316(entered);
		}

		public void SendPartNetworkMessage(byte messageType, PartData part, Action<PooledWriter> createMessageAction, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(messageType);
			pooledWriter.WriteUInt16((ushort)part.Id);
			createMessageAction(pooledWriter);
			RpcPartNetworkMessageServer(pooledWriter.GetArraySegment(), channel);
			pooledWriter.Store();
		}

		public void ServerInitialize(string craftId, int startLocationIdHashCode, byte craftOwnerSpawnDataId, int playerId)
		{
			if (!_serverInitialized)
			{
				NetworkSpawnId = _nextNetworkSpawnId++;
				_serverInitialized = true;
				_craftId.Value = craftId;
				_startLocationIdHashCode = startLocationIdHashCode;
				_craftOwnerSpawnDataId = craftOwnerSpawnDataId;
				_playerId.Value = playerId;
			}
		}

		public void SetRemotePlayerEnteredState(bool entered)
		{
			RpcPlayerEnteredStateServer(entered);
		}

		public override void WritePayload(NetworkConnection connection, Writer writer)
		{
			base.WritePayload(connection, writer);
			writer.WriteUInt16(NetworkSpawnId);
			writer.WriteInt32(_startLocationIdHashCode);
			if (base.Owner == connection)
			{
				writer.WriteUInt8Unpacked(_craftOwnerSpawnDataId);
			}
			if (AircraftScript != null)
			{
				writer.WriteBoolean(value: true);
				writer.WriteVector3(AircraftScript.GlobalPosition);
				writer.WriteVector3(AircraftScript.Rotation);
			}
			else if (_initialSpawnPosition.HasValue && _initialSpawnRotation.HasValue)
			{
				writer.WriteBoolean(value: true);
				writer.WriteVector3(_initialSpawnPosition.Value);
				writer.WriteVector3(_initialSpawnRotation.Value);
			}
			else
			{
				writer.WriteBoolean(value: false);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void FixedUpdate()
		{
			if (base.IsOwner || !(AircraftScript != null))
			{
				return;
			}
			foreach (BodyScript body in AircraftScript.Bodies)
			{
				if (!body.IsDebris && body.SyncData.ParentBody == null)
				{
					body.RigidBody.velocity = body.SyncData.Velocity;
					body.RigidBody.angularVelocity = body.SyncData.AngularVelocity;
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (_loadingStatus != null)
			{
				_loadingStatus.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(_loadingStatus.gameObject);
				_loadingStatus = null;
			}
		}

		protected virtual void Update()
		{
			if (!_aircraftInitialized)
			{
				StartLoadingAircraft().Forget();
			}
		}

		private void ActivateCraft()
		{
			using (Profile.ActivateCraft.Auto())
			{
				if (AircraftScript.RemoteAircraft)
				{
					ActivateTextDecalsAsync().Forget();
				}
				AircraftScript.gameObject.SetActive(value: true);
				AircraftScript.RebuildAircraftStructure();
				AircraftScript.CraftUpdate.OnStart();
			}
		}

		private async UniTaskVoid ActivateTextDecalsAsync()
		{
			try
			{
				List<PartMeshDecalText> value;
				using (CollectionPool<List<PartMeshDecalText>, PartMeshDecalText>.Get(out value))
				{
					PartMeshDecalText[] componentsInChildren = GetComponentsInChildren<PartMeshDecalText>(includeInactive: true);
					foreach (PartMeshDecalText partMeshDecalText in componentsInChildren)
					{
						if (partMeshDecalText != null && partMeshDecalText.gameObject.activeSelf)
						{
							partMeshDecalText.gameObject.SetActive(value: false);
							value.Add(partMeshDecalText);
						}
					}
					foreach (PartMeshDecalText decal in value)
					{
						await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
						if (AircraftScript == null)
						{
							return;
						}
						if (!(decal == null))
						{
							decal.gameObject.SetActive(value: true);
						}
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Error activating decals for remote craft " + base.name);
			}
		}

		private void BufferInitialStateUpdate(ArraySegment<byte> data)
		{
			byte[] initialStateUpdateBuffer = _initialStateUpdateBuffer;
			if (((initialStateUpdateBuffer != null) ? initialStateUpdateBuffer.Length : 0) < data.Count)
			{
				_initialStateUpdateBuffer = new byte[(data.Count + 1023) / 1024 * 1024];
			}
			data.CopyTo(_initialStateUpdateBuffer);
			_initialStateUpdateData = new ArraySegment<byte>(_initialStateUpdateBuffer, 0, data.Count);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void CraftRepositionedClientRpc(Vector3 globalPosition, Vector3 rotation, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Observers_CraftRepositionedClientRpc___3148668142(globalPosition, rotation, channel);
		}

		[ServerRpc]
		private void CraftRepositionedServerRpc(Vector3 globalPosition, Vector3 rotation, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Server_CraftRepositionedServerRpc___3148668142(globalPosition, rotation, channel);
		}

		private async UniTask DownloadAircraft(string hash)
		{
			try
			{
				if (_loader.ContainsHash(hash))
				{
					await _loader.LoadAircraftFromCache(hash);
				}
				else
				{
					RpcCraftXmlDownloadRequest(base.ClientManager.Connection);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Debug.LogError($"Could not load craft for player {PlayerId}{System.Environment.NewLine}{ex.Message}");
				OnCraftLoadComplete(success: false);
			}
		}

		private bool IsBlockingSpawnPositioning(NetworkAircraftScript craft)
		{
			if (craft != null && !craft.IsUnloaded && (craft.IsCraftLoading || !craft._initialSpawnPosition.HasValue || !craft._initialSpawnRotation.HasValue) && craft._startLocationIdHashCode == _startLocationIdHashCode)
			{
				return craft.NetworkSpawnId < NetworkSpawnId;
			}
			return false;
		}

		private void NotifyTargetAlertLocal(TargetAlertType alert)
		{
			if (AircraftScript?.TargetingSystem != null)
			{
				switch (alert)
				{
				case TargetAlertType.Tracking:
					AircraftScript.TargetingSystem.Alert(locked: false);
					break;
				case TargetAlertType.Locked:
					AircraftScript.TargetingSystem.Alert(locked: true);
					break;
				}
			}
		}

		private void OnAircraftKilled(object sender, AircraftKilledEventArgs e)
		{
			OnAircraftKilledServer(e.KillerId);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void OnAircraftKilledClient()
		{
			RpcWriter___Observers_OnAircraftKilledClient___2166136261();
		}

		[ServerRpc]
		private void OnAircraftKilledServer(int? killerId)
		{
			RpcWriter___Server_OnAircraftKilledServer___1534428615(killerId);
		}

		private void OnCraftLoadComplete(bool success)
		{
			RaiseAircraftLoadCompletedEvent(success);
			if (!success)
			{
				return;
			}
			if (base.IsOwner && AircraftScript != null)
			{
				CraftOwnerSpawnData craftOwnerSpawnData = _craftOwnerSpawnData;
				if (craftOwnerSpawnData != null && craftOwnerSpawnData.StartPaused)
				{
					AircraftScript.CraftUpdate.SetCraftPausedState(paused: true);
				}
			}
			base.gameObject.AddComponent<CraftLodScript>();
		}

		private async UniTask OnCraftLoaded(AircraftScript aircraft, bool success, Exception exception)
		{
			string userFriendlyErrorMessage = null;
			if (!success)
			{
				userFriendlyErrorMessage = (exception as NetworkAircraftLoadException)?.Message ?? ("The craft failed to load." + System.Environment.NewLine + "See log for more info.");
			}
			try
			{
				if (aircraft != null)
				{
					SetAircraft(aircraft, base.IsOwner);
				}
				if (success)
				{
					base.name = string.Format("NetworkAircraft_{0}{1}_{2}", base.IsOwner ? "Local" : "Remote", Player.NetworkPlayer.IsNPC ? "AI" : "Player", Player.NetworkPlayer.PlayerId);
					StartLocationData startLocationData = null;
					StartLocation startLocation = null;
					if (base.IsOwner)
					{
						startLocationData = _craftOwnerSpawnData.StartLocation;
						(StartLocation, CreateStartLocationResultType) obj = await FlightSceneScript.Instance.StartLocationManager.CreateStartLocation(startLocationData);
						StartLocation startLocation2;
						(startLocation2, _) = obj;
						switch (obj.Item2)
						{
						case CreateStartLocationResultType.Success:
							startLocation = startLocation2;
							break;
						case CreateStartLocationResultType.Unavailable:
							PositionUtility.ShowPositionResultErrorDialog(PositionResult.Unavailable, startLocationData.DisplayName);
							break;
						default:
							PositionUtility.ShowPositionResultErrorDialog(PositionResult.NotFound, startLocationData.DisplayName);
							break;
						}
						if (startLocation == null)
						{
							startLocationData = FlightSceneScript.Instance.StartLocationManager.Locations.FirstOrDefault((StartLocationData x) => x.StartOnGround == true && !x.IsDynamicLocation);
							CreateStartLocationResultType createStartLocationResultType;
							(startLocation2, createStartLocationResultType) = await FlightSceneScript.Instance.StartLocationManager.CreateStartLocation(startLocationData);
							if (createStartLocationResultType == CreateStartLocationResultType.Success)
							{
								startLocation = startLocation2;
							}
							else
							{
								Debug.LogError("Failed to create fallback start location '" + startLocationData?.DisplayName + "' when the original start location '" + _craftOwnerSpawnData.StartLocation.DisplayName + "' could not be created.");
							}
						}
					}
					_stateSerializer = new CraftStateSerializer(aircraft, base.IsOwner);
					_bodyConfigurationState = new BodyConfigurationState(aircraft, GetComponentInChildren<RelativeVelocityZoneScript>(includeInactive: true));
					if (!base.IsOwner && await UniTaskEx.WaitUntilWithTimeout(() => _message != null, 15000, PlayerLoopTiming.LastPostLateUpdate, DelayType.UnscaledDeltaTime, PlayerLoopTiming.LastPostLateUpdate))
					{
						_bodyConfigurationState.UpdateAircraftFromMessage(this, _message);
						_currentState = _message.State;
						_message = null;
					}
					ActivateCraft();
					base.TimeManager.OnPostTick += OnPostTick;
					RaiseAircraftLoadedEvent();
					if (_bufferedPlayerEnterState)
					{
						Player.EnterAircraft(AircraftScript);
					}
					if (base.IsOwner)
					{
						await PositionAircraftAtStartLocation(aircraft, startLocation, startLocationData.DisplayName);
						_bodyConfigurationState.MarkAsChanged();
						RpcSetInitialSpawnPositionRotationServer(AircraftScript.GlobalPosition, AircraftScript.Rotation);
					}
					else if (_initialSpawnPosition.HasValue && _initialSpawnRotation.HasValue)
					{
						AircraftScript.GlobalPosition = _initialSpawnPosition.Value;
						AircraftScript.Rotation = _initialSpawnRotation.Value;
					}
					_aircraftInitialized = true;
					foreach (ArraySegment<byte> bufferedPartNetworkMessage in _bufferedPartNetworkMessages)
					{
						Debug.Log($"Processing buffered part message ({bufferedPartNetworkMessage.Count} bytes)");
						ProcessPartNetworkMessage(bufferedPartNetworkMessage);
					}
					_bufferedPartNetworkMessages.Clear();
					if (_initialStateUpdateData.Count > 0)
					{
						using (PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(_initialStateUpdateData))
						{
							_stateSerializer.SerializeRead((PooledReader)pooledReaderDisposableWrapper, _currentState);
						}
						_initialStateUpdateBuffer = null;
						_initialStateUpdateData = default(ArraySegment<byte>);
					}
				}
			}
			catch (NetworkAircraftLoadException ex)
			{
				userFriendlyErrorMessage = ex.Message;
				exception = ex;
				success = false;
			}
			catch (Exception ex2)
			{
				userFriendlyErrorMessage = "The craft failed to load." + System.Environment.NewLine + "See log for more info.";
				exception = ex2;
				success = false;
			}
			finally
			{
				if (_loadingStatus != null)
				{
					_loadingStatus.gameObject.SetActive(value: false);
				}
			}
			if (Player.NetworkPlayer.IsNPC)
			{
				try
				{
					FlightSceneScript.Instance.FlightSceneNetwork.OnAircraftForAIHasBeenNetworkInitialized(this);
				}
				catch (Exception ex3)
				{
					if (IsUnloaded)
					{
						Debug.Log("An exception was thrown running the AI craft loaded callback when the craft was flagged as unloaded. " + $"It was probably despawned during the asynchronous load process so the callback exception is expected. {System.Environment.NewLine}{ex3}");
					}
					else
					{
						Debug.LogException(ex3);
						Debug.LogError("Failed to run the AI craft loaded callback");
					}
				}
			}
			if (exception != null)
			{
				if (IsUnloaded)
				{
					if (exception is CraftLoadAbortedException)
					{
						Debug.Log($"The loading of a craft for player {PlayerId} was aborted, likely due to being despawned during its asynchronous load process.");
					}
					else
					{
						Debug.Log($"An exception occurred loading craft for player {PlayerId} when the craft was flagged as unloaded. " + $"It was probably despawned during the asynchronous load process so the exception is expected. {System.Environment.NewLine}{exception}");
					}
				}
				else
				{
					Debug.LogException(exception);
					Debug.LogError($"An error occurred loading craft for player {PlayerId}." + System.Environment.NewLine + (userFriendlyErrorMessage ?? exception.Message));
				}
			}
			bool flag = !IsUnloaded;
			if (IsUnloaded && !_aircraftLoadCompletedEventRaised)
			{
				flag = true;
				Debug.LogError("A craft appears to have been unloaded during its asynchronous load process but the aircraft load completed event appears to have not been raised when expected.");
			}
			if (flag)
			{
				OnCraftLoadComplete(success);
			}
			if (!success && base.Owner.IsLocalClient)
			{
				if (Player.IsPrimaryLocal && !string.IsNullOrEmpty(userFriendlyErrorMessage))
				{
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, userFriendlyErrorMessage);
				}
				RequestDespawn();
			}
		}

		private void OnMissileFired(object sender, MissileFiredEventArgs e)
		{
			RpcFireWeaponServer(e.Missile.PartScript.Part.Id);
		}

		private void OnPostTick()
		{
			using (Profile.OnPostTick.Auto())
			{
				if (base.IsOwner)
				{
					if (_craftRepositioned && AircraftScript != null)
					{
						_craftRepositioned = false;
						CraftRepositionedServerRpc(AircraftScript.GlobalPosition, AircraftScript.Rotation);
					}
					BodyConfigurationState bodyConfigurationState = _bodyConfigurationState;
					if (bodyConfigurationState != null && bodyConfigurationState.Changed)
					{
						PooledWriter pooledWriter = WriterPool.Retrieve();
						_bodyConfigurationState.GenerateMessage(this).SerializeWrite(pooledWriter);
						RpcConfigurationChangedServer(pooledWriter.GetArraySegment());
						pooledWriter.Store();
					}
					_sendFrame--;
					if (_sendFrame <= 0)
					{
						BodyConfigurationState bodyConfigurationState2 = _bodyConfigurationState;
						if (bodyConfigurationState2 != null && !bodyConfigurationState2.Changed)
						{
							PooledWriter pooledWriter2 = WriterPool.Retrieve();
							_stateSerializer.SerializeWrite(pooledWriter2, _bodyConfigurationState.State);
							RpcAircraftUpdateStateServer(pooledWriter2.GetArraySegment());
							_sendFrame = 1;
							pooledWriter2.Store();
						}
					}
				}
				else
				{
					_craftRepositioned = false;
					if (_aircraftInitialized && _message != null)
					{
						_bodyConfigurationState.UpdateAircraftFromMessage(this, _message);
						_currentState = _message.State;
						_message = null;
					}
					if (_tickAlert.HasValue)
					{
						RpcNotifyTargetAlertServer(_tickAlert.Value);
						_tickAlert = null;
					}
				}
			}
		}

		private void OnRocketFired(object sender, RocketFiredEventArgs e)
		{
			RpcFireWeaponServer(e.Rocket.SourcePart.Part.Id);
		}

		private async UniTask PositionAircraftAtStartLocation(AircraftScript aircraft, StartLocation startLocation, string locationName)
		{
			bool isPrimaryLocalPlayer = aircraft.Player?.IsPrimaryLocal ?? false;
			IRepositionable repositionable2;
			if (!isPrimaryLocalPlayer)
			{
				IRepositionable repositionable = aircraft;
				repositionable2 = repositionable;
			}
			else
			{
				IRepositionable repositionable = aircraft.Player;
				repositionable2 = repositionable;
			}
			IRepositionable repositionable3 = repositionable2;
			UniTask prerequisiteTask = UniTask.Create(async delegate
			{
				float maxWaitTime = 15f;
				float startWaitTime = Time.realtimeSinceStartup;
				NetworkAircraftScript[] array = UnityEngine.Object.FindObjectsByType<NetworkAircraftScript>(FindObjectsInactive.Include, FindObjectsSortMode.None);
				NetworkAircraftScript[] array2 = array;
				foreach (NetworkAircraftScript networkAircraft in array2)
				{
					if (!networkAircraft.IsOwner && !(networkAircraft == this))
					{
						float num = maxWaitTime - (Time.realtimeSinceStartup - startWaitTime);
						if (IsBlockingSpawnPositioning(networkAircraft) && num > 0f)
						{
							Debug.Log($"Waiting up to {num:F1} seconds for craft owned by player '{networkAircraft.Player.Name}' (Id: {networkAircraft.PlayerId}) " + "to finish loading before positioning at start location '" + locationName + "'.");
							await UniTaskEx.WaitUntilWithTimeout(() => !IsBlockingSpawnPositioning(networkAircraft), (int)(num * 1000f));
							await UniTask.Yield();
							await UniTask.Yield();
						}
					}
				}
				float num2 = Time.realtimeSinceStartup - startWaitTime;
				if (num2 > 0.1f)
				{
					Debug.Log($"Total wait time for other crafts to finish loading before positioning at start location '{locationName}': {num2:F1} seconds.");
				}
			});
			PositionResult positionResult = await PositionUtility.PositionAtLocation(startLocation, repositionable3, allowRepositioning: true, isPrimaryLocalPlayer, prerequisiteTask);
			if (positionResult == PositionResult.Occupied)
			{
				positionResult = await PositionUtility.PositionAtLocation(startLocation, aircraft.Player, allowRepositioning: false, floatOriginToLocation: true);
			}
			if (positionResult != PositionResult.Success)
			{
				if (isPrimaryLocalPlayer)
				{
					PositionUtility.ShowPositionResultErrorDialog(positionResult, locationName);
				}
				else
				{
					Debug.LogError($"Failed to reposition craft with result '{positionResult}' at start location '{locationName}'.");
				}
			}
		}

		private void ProcessPartNetworkMessage(ArraySegment<byte> data)
		{
			PooledReader pooledReader = ReaderPool.Retrieve(data, base.NetworkManager);
			byte messageType = pooledReader.ReadUInt8Unpacked();
			int partId = pooledReader.ReadUInt16();
			PartData partData = AircraftScript.Parts.Where((PartData x) => x.Id == partId).FirstOrDefault();
			if (partData != null)
			{
				partData.PartScript.OnReceiveNetworkMessage(messageType, pooledReader);
			}
			else
			{
				Debug.LogError($"Could not find part with ID {partId}");
			}
			pooledReader.Store();
		}

		private void RaiseAircraftLoadCompletedEvent(bool success)
		{
			if (_aircraftLoadCompletedEventRaised)
			{
				Debug.LogError("A NetworkAircraftScript raised the aircraft load completed event more than once in its lifetime.");
			}
			_aircraftLoadCompletedEventRaised = true;
			IsCraftLoading = false;
			if (base.IsOwner)
			{
				AircraftScript?.CraftUpdate.SetCraftPausedState(paused: false);
			}
			if (success)
			{
				this.CraftLoaded?.Invoke(this, new NetworkAircraftScriptEventArgs(this));
			}
			else
			{
				this.CraftLoadFailed?.Invoke(this, new NetworkAircraftScriptEventArgs(this));
			}
			Player.RaiseAircraftLoadCompletedEvent(AircraftScript, success);
		}

		private void RaiseAircraftLoadedEvent()
		{
			if (_aircraftLoadedEventRaised)
			{
				Debug.LogError("A NetworkAircraftScript raised the aircraft loaded event more than once in its lifetime.");
			}
			_aircraftLoadedEventRaised = true;
			if (base.IsOwner)
			{
				AircraftScript?.CraftUpdate.SetCraftPausedState(paused: true);
			}
			Player.RaiseAircraftLoadedEvent(AircraftScript);
		}

		private void RaiseAircraftLoadStartedEvent()
		{
			if (_aircraftLoadStartedEventRaised)
			{
				Debug.LogError("A NetworkAircraftScript raised the aircraft load started event more than once in its lifetime.");
			}
			_aircraftLoadStartedEventRaised = true;
			IsCraftLoading = true;
			Player.RaiseAircraftLoadStartedEvent();
		}

		private void RaiseAircraftUnloadedEvent()
		{
			if (_aircraftLoadedEventRaised)
			{
				if (_aircraftUnloadedEventRaised)
				{
					Debug.LogError("A NetworkAircraftScript raised the aircraft unloaded event more than once in its lifetime.");
				}
				_aircraftUnloadedEventRaised = true;
				Player.RaiseAircraftUnloadedEvent(AircraftScript);
			}
		}

		[ObserversRpc(ExcludeOwner = true, LatestOnly = true)]
		private void RpcAircraftUpdateStateClient(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Unreliable)
		{
			RpcWriter___Observers_RpcAircraftUpdateStateClient___2713644489(data, channel);
		}

		[ServerRpc]
		private void RpcAircraftUpdateStateServer(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Unreliable)
		{
			RpcWriter___Server_RpcAircraftUpdateStateServer___2713644489(data, channel);
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void RpcConfigurationChangedClient(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Observers_RpcConfigurationChangedClient___2713644489(data, channel);
		}

		[ServerRpc]
		private void RpcConfigurationChangedServer(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Server_RpcConfigurationChangedServer___2713644489(data, channel);
		}

		[TargetRpc]
		private void RpcCraftXmlDownloadComplete(NetworkConnection client, string hash, byte[] bytes, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Target_RpcCraftXmlDownloadComplete___1740503018(client, hash, bytes, channel);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcCraftXmlDownloadRequest(NetworkConnection client, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Server_RpcCraftXmlDownloadRequest___1041564119(client, channel);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void RpcCreateDamageEffectClient(PartDamageEffects.DamageEffectType effectType, int partId, Vector3? localPosition, Vector3? localDirection)
		{
			RpcWriter___Observers_RpcCreateDamageEffectClient___1066106034(effectType, partId, localPosition, localDirection);
		}

		[ServerRpc]
		private void RpcCreateDamageEffectServer(PartDamageEffects.DamageEffectType effectType, int partId, Vector3? localPosition, Vector3? localDirection)
		{
			RpcWriter___Server_RpcCreateDamageEffectServer___1066106034(effectType, partId, localPosition, localDirection);
		}

		[ObserversRpc]
		private void RpcCreateTargetedExplosionClient(NetworkConnection networkConnection, CreateExplosionInfo explosionInfo)
		{
			RpcWriter___Observers_RpcCreateTargetedExplosionClient___2173816318(networkConnection, explosionInfo);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcCreateTargetedExplosionServer(CreateExplosionInfo explosionInfo)
		{
			RpcWriter___Server_RpcCreateTargetedExplosionServer___2538701771(explosionInfo);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcDamageRemotePartServer(int? attackerPlayerId, int partId, float damage, Vector3 localPosition, Vector3 localNormal)
		{
			RpcWriter___Server_RpcDamageRemotePartServer___2803290691(attackerPlayerId, partId, damage, localPosition, localNormal);
		}

		[TargetRpc]
		private void RpcDamageRemotePartTarget(NetworkConnection client, int? attackerPlayerId, int partId, float damage, Vector3 localPosition, Vector3 localNormal)
		{
			RpcWriter___Target_RpcDamageRemotePartTarget___219172924(client, attackerPlayerId, partId, damage, localPosition, localNormal);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void RpcFireWeaponClient(int partID)
		{
			RpcWriter___Observers_RpcFireWeaponClient___3316948804(partID);
		}

		[ServerRpc]
		private void RpcFireWeaponServer(int partID)
		{
			RpcWriter___Server_RpcFireWeaponServer___3316948804(partID);
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void RpcLoadAircraftXmlClient(string hash, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Observers_RpcLoadAircraftXmlClient___389814254(hash, channel);
		}

		[ServerRpc]
		private void RpcLoadAircraftXmlServer(byte[] bytes, string hash, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Server_RpcLoadAircraftXmlServer___1384160719(bytes, hash, channel);
		}

		[TargetRpc]
		private void RpcNotifyTargetAlertClient(NetworkConnection connection, TargetAlertType alert)
		{
			RpcWriter___Target_RpcNotifyTargetAlertClient___2500984028(connection, alert);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcNotifyTargetAlertServer(TargetAlertType alert)
		{
			RpcWriter___Server_RpcNotifyTargetAlertServer___4032262667(alert);
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void RpcPartNetworkMessageClient(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Observers_RpcPartNetworkMessageClient___2713644489(data, channel);
		}

		[ServerRpc]
		private void RpcPartNetworkMessageServer(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			RpcWriter___Server_RpcPartNetworkMessageServer___2713644489(data, channel);
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void RpcPlayerEnteredStateClient(bool entered)
		{
			RpcWriter___Observers_RpcPlayerEnteredStateClient___1140765316(entered);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RpcRequestDespawn(NetworkConnection connection = null)
		{
			RpcWriter___Server_RpcRequestDespawn___328543758(connection);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void RpcSetInitialSpawnPositionRotationClient(Vector3 position, Vector3 rotation)
		{
			RpcWriter___Observers_RpcSetInitialSpawnPositionRotationClient___2936446947(position, rotation);
		}

		[ServerRpc]
		private void RpcSetInitialSpawnPositionRotationServer(Vector3 position, Vector3 rotation)
		{
			RpcWriter___Server_RpcSetInitialSpawnPositionRotationServer___2936446947(position, rotation);
		}

		private void SetAircraft(AircraftScript aircraft, bool owner)
		{
			if (AircraftScript != null)
			{
				SubscribeToAircraftEvents(owner, subscribe: false);
			}
			AircraftScript = aircraft;
			if (AircraftScript != null)
			{
				SubscribeToAircraftEvents(owner, subscribe: true);
			}
		}

		private async UniTaskVoid StartLoadingAircraft()
		{
			if (!base.OnStartClientCalled || Player != null)
			{
				return;
			}
			Player = FlightSceneScript.Instance.GetPlayer(_playerId.Value);
			if (Player == null)
			{
				return;
			}
			_loadingStatus.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			_loadingStatus.transform.position = Player.FramePosition + 1f * Vector3.up;
			_loadingStatus.gameObject.SetActive(value: true);
			RaiseAircraftLoadStartedEvent();
			_loader = new NetworkAircraftLoader(this, Player, OnCraftLoaded, _loadingStatus);
			if (base.Owner.IsLocalClient)
			{
				try
				{
					var (bytes, hash) = await UniTask.RunOnThreadPool(delegate
					{
						using (Profile.StartLoadingAircraft_LoadAircraftData.Auto())
						{
							if (!Game.Instance.CraftDatabase.TryGetCraft(_craftId.Value, out var craftFileInfo))
							{
								string text = "The craft with id '" + _craftId.Value + "' could not be found.";
								Game.Instance.UserInterface.CreateMessageDialog(text, "Craft Load Failed.");
								throw new Exception(text);
							}
							byte[] array = Utility.CompressCraftXml(craftFileInfo.LoadXml(showErrorDialogs: true) ?? throw new Exception("The craft with id '" + _craftId.Value + "' failed to load."));
							string item = NetworkAircraftLoader.ComputeHash(array);
							return (Bytes: array, Hash: item);
						}
					});
					try
					{
						await _loader.LoadAircraft(bytes, hash, FlightSceneScript.Instance.CurrentMaxPartCount, FlightSceneScript.Instance.CurrentMaxCraftSize);
						RpcLoadAircraftXmlServer(bytes, hash);
					}
					catch (NetworkAircraftLoadException ex)
					{
						Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, ex.Message);
						throw;
					}
					catch (Exception)
					{
						Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "The craft failed to load.");
						throw;
					}
					return;
				}
				catch (Exception ex3)
				{
					Debug.LogException(ex3);
					Debug.LogError($"Could not load craft for player {PlayerId}.{System.Environment.NewLine}{ex3.Message}");
					OnCraftLoadComplete(success: false);
					RequestDespawn();
					return;
				}
			}
			if (!string.IsNullOrEmpty(_receivedCraftXmlHash))
			{
				try
				{
					await DownloadAircraft(_receivedCraftXmlHash);
					_receivedCraftXmlHash = null;
				}
				catch (Exception ex4)
				{
					Debug.LogException(ex4);
					Debug.LogError($"Could not load craft for player {PlayerId}.{System.Environment.NewLine}{ex4.Message}");
					OnCraftLoadComplete(success: false);
				}
			}
		}

		private void SubscribeToAircraftEvents(bool owner, bool subscribe)
		{
			if (owner)
			{
				if (subscribe)
				{
					AircraftScript.AircraftKilled += OnAircraftKilled;
					AircraftScript.TargetingSystem.RocketFired += OnRocketFired;
					AircraftScript.TargetingSystem.MissileFired += OnMissileFired;
				}
				else
				{
					AircraftScript.AircraftKilled -= OnAircraftKilled;
					AircraftScript.TargetingSystem.RocketFired -= OnRocketFired;
					AircraftScript.TargetingSystem.MissileFired -= OnMissileFired;
				}
			}
		}

		private void Unload()
		{
			if (IsUnloaded)
			{
				Debug.LogError("Attempting to unload a NetworkAircraftScript after it has already been unloaded.");
				return;
			}
			IsUnloaded = true;
			base.gameObject.SetActive(value: false);
			if (IsCraftLoading)
			{
				OnCraftLoadComplete(success: false);
			}
			if (Player != null)
			{
				Player.ExitAircraft();
				Player.OnAircraftDespawning();
			}
			base.TimeManager.OnPostTick -= OnPostTick;
			RaiseAircraftUnloadedEvent();
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				_playerId.InitializeEarly(this, 1u, isSyncObject: false);
				_craftId.InitializeEarly(this, 0u, isSyncObject: false);
				RegisterServerRpc(0u, RpcReader___Server_RpcPlayerEnteredStateServer___1140765316);
				RegisterObserversRpc(1u, RpcReader___Observers_CraftRepositionedClientRpc___3148668142);
				RegisterServerRpc(2u, RpcReader___Server_CraftRepositionedServerRpc___3148668142);
				RegisterObserversRpc(3u, RpcReader___Observers_OnAircraftKilledClient___2166136261);
				RegisterServerRpc(4u, RpcReader___Server_OnAircraftKilledServer___1534428615);
				RegisterObserversRpc(5u, RpcReader___Observers_RpcAircraftUpdateStateClient___2713644489);
				RegisterServerRpc(6u, RpcReader___Server_RpcAircraftUpdateStateServer___2713644489);
				RegisterObserversRpc(7u, RpcReader___Observers_RpcConfigurationChangedClient___2713644489);
				RegisterServerRpc(8u, RpcReader___Server_RpcConfigurationChangedServer___2713644489);
				RegisterTargetRpc(9u, RpcReader___Target_RpcCraftXmlDownloadComplete___1740503018);
				RegisterServerRpc(10u, RpcReader___Server_RpcCraftXmlDownloadRequest___1041564119);
				RegisterObserversRpc(11u, RpcReader___Observers_RpcCreateDamageEffectClient___1066106034);
				RegisterServerRpc(12u, RpcReader___Server_RpcCreateDamageEffectServer___1066106034);
				RegisterObserversRpc(13u, RpcReader___Observers_RpcCreateTargetedExplosionClient___2173816318);
				RegisterServerRpc(14u, RpcReader___Server_RpcCreateTargetedExplosionServer___2538701771);
				RegisterServerRpc(15u, RpcReader___Server_RpcDamageRemotePartServer___2803290691);
				RegisterTargetRpc(16u, RpcReader___Target_RpcDamageRemotePartTarget___219172924);
				RegisterObserversRpc(17u, RpcReader___Observers_RpcFireWeaponClient___3316948804);
				RegisterServerRpc(18u, RpcReader___Server_RpcFireWeaponServer___3316948804);
				RegisterObserversRpc(19u, RpcReader___Observers_RpcLoadAircraftXmlClient___389814254);
				RegisterServerRpc(20u, RpcReader___Server_RpcLoadAircraftXmlServer___1384160719);
				RegisterTargetRpc(21u, RpcReader___Target_RpcNotifyTargetAlertClient___2500984028);
				RegisterServerRpc(22u, RpcReader___Server_RpcNotifyTargetAlertServer___4032262667);
				RegisterObserversRpc(23u, RpcReader___Observers_RpcPartNetworkMessageClient___2713644489);
				RegisterServerRpc(24u, RpcReader___Server_RpcPartNetworkMessageServer___2713644489);
				RegisterObserversRpc(25u, RpcReader___Observers_RpcPlayerEnteredStateClient___1140765316);
				RegisterServerRpc(26u, RpcReader___Server_RpcRequestDespawn___328543758);
				RegisterObserversRpc(27u, RpcReader___Observers_RpcSetInitialSpawnPositionRotationClient___2936446947);
				RegisterServerRpc(28u, RpcReader___Server_RpcSetInitialSpawnPositionRotationServer___2936446947);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
				_playerId.InitializeLate();
				_craftId.InitializeLate();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_RpcPlayerEnteredStateServer___1140765316(bool entered)
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
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteBoolean(entered);
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___RpcPlayerEnteredStateServer___1140765316(bool P_0)
		{
			RpcPlayerEnteredStateClient(P_0);
		}

		private void RpcReader___Server_RpcPlayerEnteredStateServer___1140765316(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcPlayerEnteredStateServer___1140765316(flag);
			}
		}

		private void RpcWriter___Observers_CraftRepositionedClientRpc___3148668142(Vector3 globalPosition, Vector3 rotation, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteVector3(globalPosition);
			pooledWriter.WriteVector3(rotation);
			SendObserversRpc(1u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___CraftRepositionedClientRpc___3148668142(Vector3 P_0, Vector3 P_1, FishNet.Transporting.Channel P_2)
		{
			AircraftScript aircraftScript = AircraftScript;
			if (aircraftScript != null)
			{
				if (!Utilities.CompareVector3s(P_0, aircraftScript.GlobalPosition, 0.1f))
				{
					aircraftScript.GlobalPosition = P_0;
				}
				if (!Utilities.CompareVector3s(P_1, aircraftScript.Rotation, 0.5f))
				{
					aircraftScript.Rotation = P_1;
				}
			}
		}

		private void RpcReader___Observers_CraftRepositionedClientRpc___3148668142(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsClientInitialized)
			{
				RpcLogic___CraftRepositionedClientRpc___3148668142(vector, vector2, channel);
			}
		}

		private void RpcWriter___Server_CraftRepositionedServerRpc___3148668142(Vector3 globalPosition, Vector3 rotation, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
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
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteVector3(globalPosition);
			pooledWriter.WriteVector3(rotation);
			SendServerRpc(2u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___CraftRepositionedServerRpc___3148668142(Vector3 P_0, Vector3 P_1, FishNet.Transporting.Channel P_2)
		{
			CraftRepositionedClientRpc(P_0, P_1, P_2);
		}

		private void RpcReader___Server_CraftRepositionedServerRpc___3148668142(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___CraftRepositionedServerRpc___3148668142(vector, vector2, channel);
			}
		}

		private void RpcWriter___Observers_OnAircraftKilledClient___2166136261()
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendObserversRpc(3u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___OnAircraftKilledClient___2166136261()
		{
			AircraftScript?.MarkAsCriticallyDamaged();
		}

		private void RpcReader___Observers_OnAircraftKilledClient___2166136261(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			if (base.IsClientInitialized)
			{
				RpcLogic___OnAircraftKilledClient___2166136261();
			}
		}

		private void RpcWriter___Server_OnAircraftKilledServer___1534428615(int? killerId)
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
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, killerId);
			SendServerRpc(4u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___OnAircraftKilledServer___1534428615(int? P_0)
		{
			OnAircraftKilledClient();
			FlightScenePlayer flightScenePlayer = (P_0.HasValue ? FlightSceneScript.Instance.GetPlayer(P_0.Value) : null);
			if (flightScenePlayer != null && flightScenePlayer != Player)
			{
				string[] array = new string[42]
				{
					"killed", "wasted", "obliterated", "smashed", "owned", "embarrassed", "made dead", "crushed", "demolished", "ended",
					"stomped", "annihilated", "erased", "obliviated", "terminated", "neutralized", "zapped", "dispatched", "wrecked", "vaporized",
					"pummeled", "flattened", "destroyed", "mopped up", "atomized", "smoked", "dusted", "wrecking balled", "shattered", "thrashed",
					"overpowered", "deleted", "dominated", "announced as deceased", "absolutely wrecked", "KO'd", "clobbered", "yeeted", "smothered", "terminated with extreme prejudice",
					"fragged", "served a loss"
				};
				string text = array[UnityEngine.Random.Range(0, array.Length - 1)];
				string message = Player.NetworkPlayer.Name + " was " + text + " by " + flightScenePlayer.NetworkPlayer.Name;
				FlightSceneScript.Instance.FlightSceneNetwork.BroadcastMessageToAllClients(message);
			}
			else
			{
				string[] array2 = new string[25]
				{
					"had a bad landing", "hit the eject button too late", "forgot how physics works", "became one with the ground", "met an unfortunate end", "ran out of skill points", "had a gravity check", "went out with a bang", "went splat", "bounced a little too hard",
					"forgot to brake", "crash-tested their vehicle", "landed, but not in one piece", "took an unintended shortcut", "performed an unplanned disassembly", "forgot where the ground was", "tried to defy gravity and lost", "experienced rapid unplanned deceleration", "gave the ground a high-five", "became a landmark",
					"took a dirt nap", "had an unscheduled meeting with terrain", "face-planted their ride", "achieved a perfect score in ground impact", "redecorated the scenery"
				};
				string text2 = array2[UnityEngine.Random.Range(0, array2.Length - 1)];
				string message2 = Player.NetworkPlayer.Name + " " + text2;
				FlightSceneScript.Instance.FlightSceneNetwork.BroadcastMessageToAllClients(message2);
			}
		}

		private void RpcReader___Server_OnAircraftKilledServer___1534428615(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___OnAircraftKilledServer___1534428615(num);
			}
		}

		private void RpcWriter___Observers_RpcAircraftUpdateStateClient___2713644489(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Unreliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(5u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: true, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcAircraftUpdateStateClient___2713644489(ArraySegment<byte> P_0, FishNet.Transporting.Channel P_1)
		{
			if (_stateSerializer == null)
			{
				BufferInitialStateUpdate(P_0);
				return;
			}
			PooledReader pooledReader = ReaderPool.Retrieve(P_0, base.NetworkManager);
			_stateSerializer.SerializeRead(pooledReader, _currentState);
			pooledReader.Store();
		}

		private void RpcReader___Observers_RpcAircraftUpdateStateClient___2713644489(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcAircraftUpdateStateClient___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcAircraftUpdateStateServer___2713644489(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Unreliable)
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
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(6u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcAircraftUpdateStateServer___2713644489(ArraySegment<byte> P_0, FishNet.Transporting.Channel P_1)
		{
			RpcAircraftUpdateStateClient(P_0, P_1);
		}

		private void RpcReader___Server_RpcAircraftUpdateStateServer___2713644489(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcAircraftUpdateStateServer___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcConfigurationChangedClient___2713644489(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(7u, pooledWriter, channel2, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcConfigurationChangedClient___2713644489(ArraySegment<byte> P_0, FishNet.Transporting.Channel P_1)
		{
			PooledReader pooledReader = ReaderPool.Retrieve(P_0, base.NetworkManager);
			BodyConfigurationMessage bodyConfigurationMessage = new BodyConfigurationMessage();
			bodyConfigurationMessage.SerializeRead(pooledReader);
			if (bodyConfigurationMessage.State > _currentState && (_message == null || bodyConfigurationMessage.State > _message.State))
			{
				_message = bodyConfigurationMessage;
			}
			pooledReader.Store();
		}

		private void RpcReader___Observers_RpcConfigurationChangedClient___2713644489(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcConfigurationChangedClient___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcConfigurationChangedServer___2713644489(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
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
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(8u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcConfigurationChangedServer___2713644489(ArraySegment<byte> P_0, FishNet.Transporting.Channel P_1)
		{
			RpcConfigurationChangedClient(P_0, P_1);
		}

		private void RpcReader___Server_RpcConfigurationChangedServer___2713644489(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcConfigurationChangedServer___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Target_RpcCraftXmlDownloadComplete___1740503018(NetworkConnection client, string hash, byte[] bytes, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(hash);
			GeneratedWriters___Internal.GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated(pooledWriter, bytes);
			SendTargetRpc(9u, pooledWriter, channel2, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcCraftXmlDownloadComplete___1740503018(NetworkConnection P_0, string P_1, byte[] P_2, FishNet.Transporting.Channel P_3)
		{
			UniTask.Void(async delegate
			{
				try
				{
					await _loader.LoadAircraft(P_2, P_1, 0, 0f);
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					Debug.LogError($"Could not load craft for player {PlayerId}{System.Environment.NewLine}{ex.Message}");
					OnCraftLoadComplete(success: false);
				}
			});
		}

		private void RpcReader___Target_RpcCraftXmlDownloadComplete___1740503018(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			byte[] array = PooledReader0.ReadUInt8ArrayAndSizeAllocated();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcCraftXmlDownloadComplete___1740503018(base.LocalConnection, text, array, channel);
			}
		}

		private void RpcWriter___Server_RpcCraftXmlDownloadRequest___1041564119(NetworkConnection client, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(client);
			SendServerRpc(10u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcCraftXmlDownloadRequest___1041564119(NetworkConnection P_0, FishNet.Transporting.Channel P_1)
		{
			RpcCraftXmlDownloadComplete(P_0, _serverHash, _serverBytes);
		}

		private void RpcReader___Server_RpcCraftXmlDownloadRequest___1041564119(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcCraftXmlDownloadRequest___1041564119(networkConnection, channel);
			}
		}

		private void RpcWriter___Observers_RpcCreateDamageEffectClient___1066106034(PartDamageEffects.DamageEffectType effectType, int partId, Vector3? localPosition, Vector3? localDirection)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerated(pooledWriter, effectType);
			pooledWriter.WriteInt32(partId);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(pooledWriter, localPosition);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(pooledWriter, localDirection);
			SendObserversRpc(11u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcCreateDamageEffectClient___1066106034(PartDamageEffects.DamageEffectType P_0, int P_1, Vector3? P_2, Vector3? P_3)
		{
			PartData partData = AircraftScript?.GetPartById(P_1);
			if (partData != null)
			{
				Vector3? position = (P_2.HasValue ? new Vector3?(partData.PartScript.transform.TransformPoint(P_2.Value)) : ((Vector3?)null));
				Vector3? direction = (P_3.HasValue ? new Vector3?(partData.PartScript.transform.TransformDirection(P_3.Value)) : ((Vector3?)null));
				AircraftScript.DamageEffects.CreateEffect(P_0, partData.PartScript, position, direction);
			}
		}

		private void RpcReader___Observers_RpcCreateDamageEffectClient___1066106034(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			PartDamageEffects.DamageEffectType damageEffectType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num = PooledReader0.ReadInt32();
			Vector3? vector = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			Vector3? vector2 = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcCreateDamageEffectClient___1066106034(damageEffectType, num, vector, vector2);
			}
		}

		private void RpcWriter___Server_RpcCreateDamageEffectServer___1066106034(PartDamageEffects.DamageEffectType effectType, int partId, Vector3? localPosition, Vector3? localDirection)
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
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerated(pooledWriter, effectType);
			pooledWriter.WriteInt32(partId);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(pooledWriter, localPosition);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(pooledWriter, localDirection);
			SendServerRpc(12u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcCreateDamageEffectServer___1066106034(PartDamageEffects.DamageEffectType P_0, int P_1, Vector3? P_2, Vector3? P_3)
		{
			RpcCreateDamageEffectClient(P_0, P_1, P_2, P_3);
		}

		private void RpcReader___Server_RpcCreateDamageEffectServer___1066106034(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			PartDamageEffects.DamageEffectType damageEffectType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num = PooledReader0.ReadInt32();
			Vector3? vector = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			Vector3? vector2 = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcCreateDamageEffectServer___1066106034(damageEffectType, num, vector, vector2);
			}
		}

		private void RpcWriter___Observers_RpcCreateTargetedExplosionClient___2173816318(NetworkConnection networkConnection, CreateExplosionInfo explosionInfo)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(networkConnection);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerated(pooledWriter, explosionInfo);
			SendObserversRpc(13u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcCreateTargetedExplosionClient___2173816318(NetworkConnection P_0, CreateExplosionInfo P_1)
		{
			Vector3 floatingOriginPosition = AircraftScript.MainCockpit.transform.TransformPoint(P_1.GlobalPosition.ToVector3());
			P_1.GlobalPosition = Utility.ConvertFloatingOriginToAbsolutePosition(floatingOriginPosition);
			FlightSceneScript.Instance.FlightSceneNetwork.CreateExplosionLocal(P_1);
		}

		private void RpcReader___Observers_RpcCreateTargetedExplosionClient___2173816318(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			CreateExplosionInfo createExplosionInfo = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcCreateTargetedExplosionClient___2173816318(networkConnection, createExplosionInfo);
			}
		}

		private void RpcWriter___Server_RpcCreateTargetedExplosionServer___2538701771(CreateExplosionInfo explosionInfo)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerated(pooledWriter, explosionInfo);
			SendServerRpc(14u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcCreateTargetedExplosionServer___2538701771(CreateExplosionInfo P_0)
		{
			RpcCreateTargetedExplosionClient(base.Owner, P_0);
		}

		private void RpcReader___Server_RpcCreateTargetedExplosionServer___2538701771(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			CreateExplosionInfo createExplosionInfo = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcCreateTargetedExplosionServer___2538701771(createExplosionInfo);
			}
		}

		private void RpcWriter___Server_RpcDamageRemotePartServer___2803290691(int? attackerPlayerId, int partId, float damage, Vector3 localPosition, Vector3 localNormal)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, attackerPlayerId);
			pooledWriter.WriteInt32(partId);
			pooledWriter.WriteSingle(damage);
			pooledWriter.WriteVector3(localPosition);
			pooledWriter.WriteVector3(localNormal);
			SendServerRpc(15u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcDamageRemotePartServer___2803290691(int? P_0, int P_1, float P_2, Vector3 P_3, Vector3 P_4)
		{
			if (!FlightSceneScript.IsPeacefulMode)
			{
				RpcDamageRemotePartTarget(base.Owner, P_0, P_1, P_2, P_3, P_4);
			}
		}

		private void RpcReader___Server_RpcDamageRemotePartServer___2803290691(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num2 = PooledReader0.ReadInt32();
			float num3 = PooledReader0.ReadSingle();
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcDamageRemotePartServer___2803290691(num, num2, num3, vector, vector2);
			}
		}

		private void RpcWriter___Target_RpcDamageRemotePartTarget___219172924(NetworkConnection client, int? attackerPlayerId, int partId, float damage, Vector3 localPosition, Vector3 localNormal)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, attackerPlayerId);
			pooledWriter.WriteInt32(partId);
			pooledWriter.WriteSingle(damage);
			pooledWriter.WriteVector3(localPosition);
			pooledWriter.WriteVector3(localNormal);
			SendTargetRpc(16u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcDamageRemotePartTarget___219172924(NetworkConnection P_0, int? P_1, int P_2, float P_3, Vector3 P_4, Vector3 P_5)
		{
			PartData partById = AircraftScript.GetPartById(P_2);
			if (partById != null)
			{
				Vector3 position = partById.PartScript.transform.TransformPoint(P_4);
				Vector3 direction = partById.PartScript.transform.TransformDirection(P_5);
				partById.PartScript.OnDamaged(P_1, P_3, position, direction);
			}
		}

		private void RpcReader___Target_RpcDamageRemotePartTarget___219172924(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num2 = PooledReader0.ReadInt32();
			float num3 = PooledReader0.ReadSingle();
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcDamageRemotePartTarget___219172924(base.LocalConnection, num, num2, num3, vector, vector2);
			}
		}

		private void RpcWriter___Observers_RpcFireWeaponClient___3316948804(int partID)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(partID);
			SendObserversRpc(17u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcFireWeaponClient___3316948804(int P_0)
		{
			(AircraftScript?.GetPartById(P_0))?.PartScript.GetModifierWithInterface<IWeapon>()?.Fire(null);
		}

		private void RpcReader___Observers_RpcFireWeaponClient___3316948804(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcFireWeaponClient___3316948804(num);
			}
		}

		private void RpcWriter___Server_RpcFireWeaponServer___3316948804(int partID)
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
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(partID);
			SendServerRpc(18u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcFireWeaponServer___3316948804(int P_0)
		{
			RpcFireWeaponClient(P_0);
		}

		private void RpcReader___Server_RpcFireWeaponServer___3316948804(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcFireWeaponServer___3316948804(num);
			}
		}

		private void RpcWriter___Observers_RpcLoadAircraftXmlClient___389814254(string hash, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteString(hash);
			SendObserversRpc(19u, pooledWriter, channel2, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcLoadAircraftXmlClient___389814254(string P_0, FishNet.Transporting.Channel P_1)
		{
			if (_loader != null)
			{
				DownloadAircraft(P_0).Forget();
			}
			else
			{
				_receivedCraftXmlHash = P_0;
			}
		}

		private void RpcReader___Observers_RpcLoadAircraftXmlClient___389814254(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			string text = PooledReader0.ReadStringAllocated();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcLoadAircraftXmlClient___389814254(text, channel);
			}
		}

		private void RpcWriter___Server_RpcLoadAircraftXmlServer___1384160719(byte[] bytes, string hash, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
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
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated(pooledWriter, bytes);
			pooledWriter.WriteString(hash);
			SendServerRpc(20u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcLoadAircraftXmlServer___1384160719(byte[] P_0, string P_1, FishNet.Transporting.Channel P_2)
		{
			_serverBytes = P_0;
			_serverHash = P_1;
			RpcLoadAircraftXmlClient(P_1);
		}

		private void RpcReader___Server_RpcLoadAircraftXmlServer___1384160719(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			byte[] array = PooledReader0.ReadUInt8ArrayAndSizeAllocated();
			string text = PooledReader0.ReadStringAllocated();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcLoadAircraftXmlServer___1384160719(array, text, channel);
			}
		}

		private void RpcWriter___Target_RpcNotifyTargetAlertClient___2500984028(NetworkConnection connection, TargetAlertType alert)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerated(pooledWriter, alert);
			SendTargetRpc(21u, pooledWriter, channel, DataOrderType.Default, connection, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcNotifyTargetAlertClient___2500984028(NetworkConnection P_0, TargetAlertType P_1)
		{
			NotifyTargetAlertLocal(P_1);
		}

		private void RpcReader___Target_RpcNotifyTargetAlertClient___2500984028(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			TargetAlertType targetAlertType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcNotifyTargetAlertClient___2500984028(base.LocalConnection, targetAlertType);
			}
		}

		private void RpcWriter___Server_RpcNotifyTargetAlertServer___4032262667(TargetAlertType alert)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerated(pooledWriter, alert);
			SendServerRpc(22u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcNotifyTargetAlertServer___4032262667(TargetAlertType P_0)
		{
			RpcNotifyTargetAlertClient(base.Owner, P_0);
		}

		private void RpcReader___Server_RpcNotifyTargetAlertServer___4032262667(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			TargetAlertType targetAlertType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcNotifyTargetAlertServer___4032262667(targetAlertType);
			}
		}

		private void RpcWriter___Observers_RpcPartNetworkMessageClient___2713644489(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(23u, pooledWriter, channel2, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcPartNetworkMessageClient___2713644489(ArraySegment<byte> P_0, FishNet.Transporting.Channel P_1)
		{
			if (_aircraftInitialized)
			{
				ProcessPartNetworkMessage(P_0);
			}
			else
			{
				_bufferedPartNetworkMessages.Add(P_0);
			}
		}

		private void RpcReader___Observers_RpcPartNetworkMessageClient___2713644489(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcPartNetworkMessageClient___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcPartNetworkMessageServer___2713644489(ArraySegment<byte> data, FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable)
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
			FishNet.Transporting.Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(24u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcPartNetworkMessageServer___2713644489(ArraySegment<byte> P_0, FishNet.Transporting.Channel P_1)
		{
			RpcPartNetworkMessageClient(P_0, P_1);
		}

		private void RpcReader___Server_RpcPartNetworkMessageServer___2713644489(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcPartNetworkMessageServer___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_RpcPlayerEnteredStateClient___1140765316(bool entered)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteBoolean(entered);
			SendObserversRpc(25u, pooledWriter, channel, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcPlayerEnteredStateClient___1140765316(bool P_0)
		{
			if (AircraftScript == null || !AircraftScript.IsInitialized)
			{
				_bufferedPlayerEnterState = P_0;
			}
			else if (P_0)
			{
				Player.EnterAircraft(AircraftScript);
			}
			else
			{
				Player.ExitAircraft();
			}
		}

		private void RpcReader___Observers_RpcPlayerEnteredStateClient___1140765316(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcPlayerEnteredStateClient___1140765316(flag);
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
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(26u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcRequestDespawn___328543758(NetworkConnection P_0)
		{
			if (!(P_0 == base.Owner) && !P_0.IsLocalClient)
			{
				FlightScenePlayer player = Player;
				if (player == null || !player.NetworkPlayer.IsNPC)
				{
					return;
				}
			}
			Despawn(DespawnType.Destroy);
		}

		private void RpcReader___Server_RpcRequestDespawn___328543758(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___RpcRequestDespawn___328543758(conn);
			}
		}

		private void RpcWriter___Observers_RpcSetInitialSpawnPositionRotationClient___2936446947(Vector3 position, Vector3 rotation)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteVector3(position);
			pooledWriter.WriteVector3(rotation);
			SendObserversRpc(27u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSetInitialSpawnPositionRotationClient___2936446947(Vector3 P_0, Vector3 P_1)
		{
			_initialSpawnPosition = P_0;
			_initialSpawnRotation = P_1;
			if (AircraftScript != null)
			{
				AircraftScript.GlobalPosition = P_0;
				AircraftScript.Rotation = P_1;
			}
		}

		private void RpcReader___Observers_RpcSetInitialSpawnPositionRotationClient___2936446947(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcSetInitialSpawnPositionRotationClient___2936446947(vector, vector2);
			}
		}

		private void RpcWriter___Server_RpcSetInitialSpawnPositionRotationServer___2936446947(Vector3 position, Vector3 rotation)
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
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteVector3(position);
			pooledWriter.WriteVector3(rotation);
			SendServerRpc(28u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcSetInitialSpawnPositionRotationServer___2936446947(Vector3 P_0, Vector3 P_1)
		{
			_initialSpawnPosition = P_0;
			_initialSpawnRotation = P_1;
			RpcSetInitialSpawnPositionRotationClient(P_0, P_1);
		}

		private void RpcReader___Server_RpcSetInitialSpawnPositionRotationServer___2936446947(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			Vector3 vector = PooledReader0.ReadVector3();
			Vector3 vector2 = PooledReader0.ReadVector3();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcSetInitialSpawnPositionRotationServer___2936446947(vector, vector2);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScript_Game_002Edll()
		{
			_loadingStatus.gameObject.SetActive(value: false);
		}
	}
}
