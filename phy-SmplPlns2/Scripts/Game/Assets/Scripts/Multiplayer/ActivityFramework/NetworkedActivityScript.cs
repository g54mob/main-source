using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.UI.Activity;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Timing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Jundroo.Common.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public abstract class NetworkedActivityScript : NetworkBehaviour
	{
		public delegate void StartTextHideDelegate(Action onCompletedAction = null, bool force = false, bool skipAnimation = false);

		public delegate void StartTextShowDelegate(bool force = false, bool skipAnimation = false);

		public enum ActivityTimerType
		{
			CountDown = 0,
			CountUp = 1
		}

		public struct AsyncResult
		{
			public enum ResultType
			{
				Failure = 0,
				Success = 1
			}

			public bool IsSuccess => Type == ResultType.Success;

			public string Message { get; set; }

			public ResultType Type { get; set; }

			public AsyncResult(ResultType type, string message)
			{
				Type = type;
				Message = message;
			}

			public static AsyncResult Failure(string message)
			{
				return new AsyncResult(ResultType.Failure, message);
			}

			public static AsyncResult Success()
			{
				return new AsyncResult(ResultType.Success, null);
			}

			public static AsyncResult UnexpectedError(int errorCode)
			{
				return new AsyncResult(ResultType.Failure, $"An unexpected error occurred processing the request. Error Code {errorCode}");
			}
		}

		public struct CraftBoundsAsyncResult
		{
			public CraftLocalBounds? Data { get; set; }

			public bool IsSuccess => Data.HasValue;

			public string Message { get; set; }

			public CraftBoundsAsyncResult(string failureMessage)
			{
				Message = failureMessage;
				Data = null;
			}

			public CraftBoundsAsyncResult(CraftLocalBounds resultData)
			{
				Message = null;
				Data = resultData;
			}
		}

		private struct ChangePlayerStateRequest
		{
			public bool ExcludeOwner { get; set; }

			public int PlayerId { get; set; }

			public NetworkedActivityPlayerState State { get; set; }

			public ChangePlayerStateRequest(int playerId, NetworkedActivityPlayerState state, bool excludeOwner = false)
			{
				PlayerId = playerId;
				State = state;
				ExcludeOwner = excludeOwner;
			}
		}

		private struct EndActivityForPlayerRequest
		{
			public int PlayerId { get; set; }

			public EndActivityForPlayerRequest(int playerId)
			{
				PlayerId = playerId;
			}
		}

		private struct JoinActivityRequest
		{
			public int PlayerId { get; set; }

			public JoinActivityRequest(int playerId)
			{
				PlayerId = playerId;
			}
		}

		private struct JoinTeamRequest
		{
			public int PlayerId { get; set; }

			public NetworkedActivityTeamIds? TeamId { get; set; }

			public JoinTeamRequest(int playerId, NetworkedActivityTeamIds? teamId)
			{
				PlayerId = playerId;
				TeamId = teamId;
			}
		}

		private struct PlayerCraftBoundsRequest
		{
			public bool InitialBounds { get; set; }

			public int PlayerId { get; set; }

			public PlayerCraftBoundsRequest(int playerId, bool initialBounds)
			{
				PlayerId = playerId;
				InitialBounds = initialBounds;
			}
		}

		private struct SpawnLocationAsyncResult
		{
			public StartLocationData Data { get; set; }

			public bool IsSuccess => string.IsNullOrEmpty(Message);

			public string Message { get; set; }

			public SpawnLocationAsyncResult(string failureMessage)
			{
				Message = failureMessage;
				Data = null;
			}

			public SpawnLocationAsyncResult(StartLocationData resultData)
			{
				Message = null;
				Data = resultData;
			}
		}

		private struct SpawnLocationRequest
		{
			public CraftLocalBounds? Bounds { get; set; }

			public bool InitialSpawn { get; set; }

			public int PlayerId { get; set; }

			public SpawnLocationRequest(int playerId, bool initialSpawn, CraftLocalBounds? bounds)
			{
				PlayerId = playerId;
				InitialSpawn = initialSpawn;
				Bounds = bounds;
			}
		}

		private struct StartActivityForPlayerRequest
		{
			public int PlayerId { get; set; }

			public StartActivityForPlayerRequest(int playerId)
			{
				PlayerId = playerId;
			}
		}

		private struct WaitForAllPlayersEndedRequest
		{
			public int[] PlayerIds { get; set; }

			public WaitForAllPlayersEndedRequest(int[] playerIds)
			{
				PlayerIds = playerIds;
			}
		}

		private struct WaitForAllPlayersStartedRequest
		{
			public int[] PlayerIds { get; set; }

			public WaitForAllPlayersStartedRequest(int[] playerIds)
			{
				PlayerIds = playerIds;
			}
		}

		private class InitialStartLocation
		{
			private class PlayerStartLocation
			{
				public CraftLocalBounds Bounds { get; set; }

				public int PlayerId { get; set; }

				public float PositionX { get; set; }

				public PlayerStartLocation(NetworkedActivityPlayer player, CraftLocalBounds bounds)
				{
					PlayerId = player.PlayerId;
					Bounds = bounds;
					PositionX = 0f;
				}
			}

			private class Row
			{
				public float CenterX { get; set; }

				public List<PlayerStartLocation> Players { get; }

				public Vector2 Size { get; set; }

				public Row()
				{
					Players = new List<PlayerStartLocation>();
				}

				public Row(PlayerStartLocation playerStartLocation)
				{
					Players = new List<PlayerStartLocation> { playerStartLocation };
					Vector3 size = playerStartLocation.Bounds.Size;
					Size = new Vector2(size.x, size.z);
				}
			}

			private List<Row> _rows;

			public StartLocationData DefaultStartLocation { get; }

			public IEnumerable<int> PlayerIds
			{
				get
				{
					foreach (Row row in _rows)
					{
						foreach (PlayerStartLocation player in row.Players)
						{
							yield return player.PlayerId;
						}
					}
				}
			}

			public NetworkedActivityTeamIds TeamId { get; }

			public InitialStartLocation(NetworkedActivityTeamIds teamId, StartLocationData defaultStartLocation)
			{
				TeamId = teamId;
				DefaultStartLocation = defaultStartLocation;
				_rows = new List<Row>();
			}

			public void AddPlayer(NetworkedActivityPlayer player, CraftLocalBounds bounds, bool activityStarted)
			{
				foreach (Row row3 in _rows)
				{
					foreach (PlayerStartLocation player2 in row3.Players)
					{
						if (player2.PlayerId == player.PlayerId)
						{
							player2.PlayerId = -1;
						}
					}
				}
				bounds.Size += new Vector3(2.5f, 0f, 2.5f);
				float x = bounds.Size.x;
				float num = x / 2f;
				float maxDistributionAmount = DefaultStartLocation.MaxDistributionAmount;
				float num2 = maxDistributionAmount * 2f;
				PlayerStartLocation playerStartLocation = new PlayerStartLocation(player, bounds);
				if (activityStarted)
				{
					Row row = _rows.LastOrDefault();
					if (row != null)
					{
						float num3 = row.CenterX - row.Size.x / 2f;
						float num4 = row.CenterX + row.Size.x / 2f;
						float? num5 = null;
						if (Mathf.Abs(row.CenterX) >= 0f)
						{
							if (num3 - x > 0f - maxDistributionAmount)
							{
								num5 = num3 - num;
								num3 -= x;
							}
							else if (num4 + x < maxDistributionAmount)
							{
								num5 = num4 + num;
								num4 += x;
							}
						}
						else if (num4 + x < maxDistributionAmount)
						{
							num5 = num4 + num;
							num4 += x;
						}
						else if (num3 - x > 0f - maxDistributionAmount)
						{
							num5 = num3 - num;
							num3 -= x;
						}
						if (num5.HasValue)
						{
							playerStartLocation.PositionX = num5.Value;
							row.Players.Add(playerStartLocation);
							row.Size = new Vector2(num4 - num3, Mathf.Max(row.Size.y, bounds.Size.z));
							row.CenterX = num3 + row.Size.x / 2f;
						}
						else
						{
							row = null;
						}
					}
					if (row == null)
					{
						row = new Row(playerStartLocation);
						_rows.Add(row);
					}
					return;
				}
				bool flag = false;
				for (int i = 0; i < _rows.Count; i++)
				{
					Row row2 = _rows[i];
					if (row2.Size.x + bounds.Size.x <= num2)
					{
						row2.Players.Insert((row2.Players.Count % 2 != 0) ? row2.Players.Count : 0, playerStartLocation);
						row2.Size = new Vector2(row2.Size.x + bounds.Size.x, Mathf.Max(row2.Size.y, bounds.Size.z));
						row2.CenterX = 0f;
						float num6 = 0f - row2.Size.x / 2f;
						for (int j = 0; j < row2.Players.Count; j++)
						{
							PlayerStartLocation playerStartLocation2 = row2.Players[j];
							playerStartLocation2.PositionX = num6 + playerStartLocation2.Bounds.Size.x / 2f;
							num6 += playerStartLocation2.Bounds.Size.x;
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Row item = new Row(playerStartLocation);
					_rows.Add(item);
				}
			}

			public StartLocationData CreateStartLocation(NetworkedActivityPlayer player)
			{
				Vector2 zero = Vector2.zero;
				for (int i = 0; i < _rows.Count; i++)
				{
					Row row = _rows[i];
					for (int j = 0; j < row.Players.Count; j++)
					{
						PlayerStartLocation playerStartLocation = row.Players[j];
						if (playerStartLocation.PlayerId == player.PlayerId)
						{
							zero.x = playerStartLocation.PositionX + playerStartLocation.Bounds.Offset.x;
							zero.y = zero.y - playerStartLocation.Bounds.Size.z / 2f + playerStartLocation.Bounds.Offset.z;
							StartLocationData defaultStartLocation = DefaultStartLocation;
							Quaternion quaternion = Quaternion.Euler(defaultStartLocation.Rotation);
							Vector3 position = defaultStartLocation.Position + quaternion * new Vector3(zero.x, 0f, zero.y);
							StartLocationData startLocationData = defaultStartLocation.Clone();
							startLocationData.LocationType = StartLocationType.Temp;
							startLocationData.Position = position;
							return startLocationData;
						}
					}
					zero.y -= row.Size.y;
				}
				return null;
			}

			public CraftLocalBounds? GetPlayerCraftBounds(int playerId)
			{
				foreach (Row row in _rows)
				{
					foreach (PlayerStartLocation player in row.Players)
					{
						if (player.PlayerId == playerId)
						{
							return player.Bounds;
						}
					}
				}
				return null;
			}
		}

		private class InitialTeamSpawnData
		{
			public List<(string Id, ArraySegment<byte> Value)> Scores { get; }

			public NetworkedActivityTeamIds TeamId { get; }

			public InitialTeamSpawnData(NetworkedActivityTeamIds teamId, List<(string Id, ArraySegment<byte> Value)> scores)
			{
				TeamId = teamId;
				Scores = scores;
			}
		}

		private class PendingPlayerJoin
		{
			public NetworkedActivityPlayer Player { get; }

			public List<(string Id, ArraySegment<byte> Value)> Scores { get; }

			public NetworkedActivityPlayerState State { get; }

			public NetworkedActivityTeamIds Team { get; }

			public PendingPlayerJoin(NetworkedActivityPlayer player, NetworkedActivityTeamIds team, NetworkedActivityPlayerState state, List<(string Id, ArraySegment<byte> Value)> scores)
			{
				Player = player;
				Team = team;
				State = state;
				Scores = scores;
			}
		}

		private class SettingsSynchronization
		{
			private NetworkedActivityScript _activity;

			private List<NetworkedActivitySetting> _pendingFullSync;

			private List<NetworkedActivitySetting> _pendingValueSync;

			private Action<ArraySegment<byte>> _settingSyncRpc;

			public SettingsSynchronization(NetworkedActivityScript activity, Action<ArraySegment<byte>> settingSyncRpc)
			{
				_activity = activity;
				_settingSyncRpc = settingSyncRpc;
				_pendingFullSync = new List<NetworkedActivitySetting>();
				_pendingValueSync = new List<NetworkedActivitySetting>();
				_activity.Data.Settings.SettingAdded += OnSettingAdded;
				_activity.Data.Settings.SettingValueChanged += OnSettingValueChanged;
			}

			public void OnSyncDataReceived(ArraySegment<byte> data)
			{
				using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = _activity.GetPooledReader(data);
				_activity.Data.Settings.SerializeRead((PooledReader)pooledReaderDisposableWrapper, valuesOnly: false);
				_activity.Data.Settings.SerializeRead((PooledReader)pooledReaderDisposableWrapper, valuesOnly: true);
			}

			public void Sync()
			{
				if (_pendingFullSync.Count == 0 && _pendingValueSync.Count == 0)
				{
					return;
				}
				if (!_activity.IsActivityHost)
				{
					Debug.LogError("Attempted to sync activity settings while not being the host of the activity.");
					return;
				}
				using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _activity.GetPooledWriter();
				_activity.Data.Settings.SerializeWrite((PooledWriter)pooledWriterDisposableWrapper, valuesOnly: false, _pendingFullSync);
				_activity.Data.Settings.SerializeWrite((PooledWriter)pooledWriterDisposableWrapper, valuesOnly: true, _pendingValueSync);
				_pendingFullSync.Clear();
				_pendingValueSync.Clear();
				_settingSyncRpc(pooledWriterDisposableWrapper.GetData());
			}

			private void OnSettingAdded(object sender, NetworkedActivitySettingEventArgs e)
			{
				if (_activity.IsActivityHost)
				{
					_pendingFullSync.Add(e.Setting);
				}
				if (_activity._manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.SettingChanged))
				{
					Debug.Log("Activity '" + _activity.Data.DisplayName + "' setting '" + e.Setting.Id + "' added: " + e.Setting.ValueString);
				}
			}

			private void OnSettingValueChanged(object sender, NetworkedActivitySettingValueChangedEventArgs<object> e)
			{
				if (_activity.IsActivityHost)
				{
					_pendingValueSync.Add(e.Setting);
				}
				if (_activity._manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.SettingChanged))
				{
					Debug.Log("Activity '" + _activity.Data.DisplayName + "' setting '" + e.Setting.Id + "' changed: " + e.Setting.ValueString);
				}
			}
		}

		public enum UpdateScoreType : byte
		{
			Add = 0,
			Set = 1
		}

		public class FinalScoreSummary
		{
			public string Message { get; set; }

			public bool ShowCelebrationStyle { get; set; }

			public string SubMessage { get; set; }
		}

		private AiManagerScript _aiCraftManager;

		private List<AircraftScript> _aiCrafts;

		private List<AiControlledAircraftScript> _aiCraftsOwned;

		private Dictionary<NetworkedActivityTeamIds, ushort> _activityTeamIdToPlayerTeamIdMap;

		private AsyncServerNetworkRequest<ChangePlayerStateRequest, AsyncResult> _changePlayerStateRequest;

		private bool _despawned;

		private AsyncClientNetworkRequest<EndActivityForPlayerRequest, AsyncResult> _endActivityForPlayerRequest;

		private bool _initializedOnClient;

		private bool _initializedOnServer;

		private Dictionary<int, StartLocationData> _initialPlayerStartLocations;

		private EnumDictionary<NetworkedActivityTeamIds, List<InitialStartLocation>> _initialStartLocations;

		private NetworkedActivityState _initialStateFromServer;

		private List<InitialTeamSpawnData> _initialTeamSpawnData;

		private AsyncServerNetworkRequest<JoinActivityRequest, AsyncResult> _joinActivityRequest;

		private AsyncServerNetworkRequest<JoinTeamRequest, AsyncResult> _joinTeamRequest;

		private NetworkedActivityManager _manager;

		private List<PendingPlayerJoin> _pendingPlayerJoins;

		private string _pendingStartText;

		private AsyncClientNetworkRequest<PlayerCraftBoundsRequest, CraftBoundsAsyncResult> _playerCraftBoundsRequest;

		private List<NetworkedActivityPlayer> _players;

		private List<NetworkedActivityPlayer> _playersPendingStart;

		private SettingsSynchronization _settingsSync;

		private AsyncServerNetworkRequest<SpawnLocationRequest, SpawnLocationAsyncResult> _spawnLocationRequest;

		private AsyncClientNetworkRequest<StartActivityForPlayerRequest, AsyncResult> _startActivityForPlayerRequest;

		private bool _startCountdownComplete;

		private EnumDictionary<NetworkedActivityTeamIds, int> _startLocationsNextIndex;

		private bool _timerEnabledClient;

		private bool _timerEnabledServer;

		private ActivityTimerType _timerType;

		private int _timerValueClient;

		private float _timerValueServer;

		private AsyncClientNetworkRequest<WaitForAllPlayersEndedRequest, AsyncResult> _waitForAllPlayersEndedRequest;

		private AsyncClientNetworkRequest<WaitForAllPlayersStartedRequest, AsyncResult> _waitForAllPlayersStartedRequest;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScriptGame_002Edll_Excuted;

		public IReadOnlyList<AircraftScript> AICrafts => _aiCrafts;

		public IReadOnlyList<AiControlledAircraftScript> AICraftsOwned => _aiCraftsOwned;

		public NetworkedActivityPlayer ActivityHost { get; private set; }

		public virtual bool CraftsStartPaused => false;

		public NetworkedActivityData Data { get; private set; }

		public Guid InstanceId { get; private set; }

		public bool IsActivityHost { get; private set; }

		public bool IsLocalClientParticipating { get; private set; }

		public virtual NetworkedActivityTeamIds JoinableTeams => NetworkedActivityTeamIds.Team1;

		public NetworkedActivityPlayer LocalPlayer { get; private set; }

		public IReadOnlyList<NetworkedActivityPlayer> Players => _players;

		public bool StartCountdownComplete => _startCountdownComplete;

		public NetworkedActivityState State { get; private set; }

		public virtual string Subtitle => string.Empty;

		public NetworkedActivityTeam Team1 { get; private set; }

		public NetworkedActivityTeam Team2 { get; private set; }

		public NetworkedActivityTeam TeamSpectator { get; private set; }

		public int? TimerValue
		{
			get
			{
				if (!_timerEnabledClient)
				{
					return null;
				}
				return _timerValueClient;
			}
		}

		protected bool IsDespawned => _despawned;

		protected virtual bool PlayerFinishedActivity => true;

		protected float TimerValueServer => _timerValueServer;

		public event EventHandler<NetworkedActivityEventArgs> ActivityEnded;

		public event EventHandler<NetworkedActivityEventArgs> ActivityEnding;

		public event EventHandler<NetworkedActivityEventArgs> ActivityStarted;

		public event EventHandler<NetworkedActivityEventArgs> ActivityStarting;

		public event EventHandler<NetworkedActivityEventArgs> Despawned;

		public event EventHandler<NetworkedActivityEventArgs> Despawning;

		public event EventHandler<NetworkedActivityPlayerAircraftEventArgs> PlayerAircraftLoadCompleted;

		public event EventHandler<NetworkedActivityPlayerAircraftEventArgs> PlayerEnteredAircraft;

		public event EventHandler<NetworkedActivityPlayerAircraftEventArgs> PlayerExitedAircraft;

		public event EventHandler<NetworkedActivityPlayerEventArgs> PlayerJoined;

		public event EventHandler<NetworkedActivityPlayerEventArgs> PlayerLeft;

		public event EventHandler<NetworkedActivityPlayerStateChangedEventArgs> PlayerStateChanged;

		public event EventHandler<NetworkedActivityStateChangedEventArgs> StateChanged;

		public event EventHandler<NetworkedActivityPlayerTeamEventArgs> TeamJoined;

		public event EventHandler<NetworkedActivityPlayerTeamEventArgs> TeamLeft;

		public event EventHandler<NetworkedActivityPlayerScoreEventArgs> PlayerScoreChanged;

		public event EventHandler<NetworkedActivityTeamScoreEventArgs> TeamScoreChanged;

		public void SpawnAi<T>(string craftId, Vector3 position, Vector3 rotation, float speed, bool aggressive, ushort teamId) where T : AiControlSystem, new()
		{
			_aiCraftManager.SpawnAi<T>(new AiAircraftInfo(craftId), position, rotation, speed, autoDespawn: false, multipleFrames: true, teamId, delegate(AiControlledAircraftScript craft)
			{
				AICraftLoadedServerRpc(craft.NetworkAircraft);
				if (aggressive && craft.CurrentControlSystem is AiCsFlyToLocationAndEngage aiCsFlyToLocationAndEngage)
				{
					aiCsFlyToLocationAndEngage.DestroyAllEnemies();
				}
			});
		}

		protected virtual void OnAICraftKilled(AircraftScript craft)
		{
			Debug.Log("AI craft killed: " + craft.name + " (Player: " + craft.Player?.Name + ")");
		}

		protected virtual void OnAICraftLoaded(AircraftScript craft)
		{
			Debug.Log("AI craft loaded: " + craft.name + " (Player: " + craft.Player?.Name + ")");
		}

		protected virtual void OnAICraftLoadedAsOwner(AiControlledAircraftScript craft)
		{
			Debug.Log("AI craft loaded (as owner): " + craft.name + " (Player: " + craft.NetworkAircraft?.Player?.Name + ")");
		}

		protected virtual void OnAICraftUnloaded(AircraftScript craft)
		{
			Debug.Log("AI craft unloaded: " + craft.name + " (Player: " + craft.Player?.Name + ")");
		}

		[ObserversRpc(RunLocally = true)]
		private void AICraftLoadedClientRpc(NetworkAircraftScript craft)
		{
			RpcWriter___Observers_AICraftLoadedClientRpc___215635273(craft);
			RpcLogic___AICraftLoadedClientRpc___215635273(craft);
		}

		[ServerRpc(RequireOwnership = false)]
		private void AICraftLoadedServerRpc(NetworkAircraftScript craft)
		{
			RpcWriter___Server_AICraftLoadedServerRpc___215635273(craft);
		}

		private void DespawnLocallyOwnedAICraft()
		{
			for (int num = _aiCraftsOwned.Count - 1; num >= 0; num--)
			{
				AiControlledAircraftScript aiControlledAircraftScript = _aiCraftsOwned[num];
				if (aiControlledAircraftScript != null)
				{
					_aiCraftManager.DespawnAircraft(aiControlledAircraftScript, 0f);
				}
				_aiCraftsOwned.RemoveAt(num);
			}
		}

		private void OnAICraftKilled(object sender, AircraftKilledEventArgs e)
		{
			AircraftScript aircraft = e.Aircraft;
			if (aircraft.NetworkAircraft.IsOwner && !aircraft.TryGetComponent<AiControlledAircraftScript>(out var _))
			{
				Debug.LogError("AI craft killed: " + aircraft.name + " (Player: " + aircraft.Player.Name + ") but the AiControlledAircraftScript could not be found.");
			}
			OnAICraftKilled(aircraft);
		}

		private void OnAICraftLoadCompleted(object sender, NetworkAircraftScriptEventArgs e)
		{
			e.Craft.CraftLoaded -= OnAICraftLoadCompleted;
			e.Craft.CraftLoadFailed -= OnAICraftLoadCompleted;
			OnAICraftLoadCompleted(e.Craft);
		}

		private void OnAICraftLoadCompleted(NetworkAircraftScript craft)
		{
			if (craft.IsOwner)
			{
				if (!craft.TryGetComponent<AiControlledAircraftScript>(out var component))
				{
					Debug.LogError("AI craft loaded: " + craft.name + " (Player: " + craft.Player.Name + ") but the AiControlledAircraftScript could not be found.");
					return;
				}
				_aiCraftsOwned.Add(component);
				OnAICraftLoadedAsOwner(component);
			}
			_aiCrafts.Add(craft.AircraftScript);
			craft.AircraftScript.Unloaded += OnAICraftUnloaded;
			craft.AircraftScript.AircraftKilled += OnAICraftKilled;
			OnAICraftLoaded(craft.AircraftScript);
		}

		private void OnAICraftUnloaded(object sender, AircraftScriptEventArgs e)
		{
			AircraftScript craft = e.Craft;
			craft.Unloaded -= OnAICraftUnloaded;
			craft.AircraftKilled -= OnAICraftKilled;
			if (craft.NetworkAircraft.IsOwner)
			{
				if (!craft.TryGetComponent<AiControlledAircraftScript>(out var component))
				{
					Debug.LogError("AI craft unloaded: " + craft.name + " (Player: " + craft.Player?.Name + ") but the AiControlledAircraftScript could not be found.");
				}
				else if (!_aiCraftsOwned.Remove(component))
				{
					Debug.LogError("AI craft unloaded: " + craft.name + " (Player: " + craft.Player?.Name + ") but the craft was not found in the list of the activity's AI craft owned by the local player.");
				}
			}
			if (!_aiCrafts.Remove(craft))
			{
				Debug.LogError("AI craft unloaded: " + craft.name + " (Player: " + craft.Player?.Name + ") but the craft was not found in the list of the activity's AI craft.");
			}
			OnAICraftUnloaded(craft);
		}

		public async UniTask<AsyncResult> ChangePlayerState(NetworkedActivityPlayer player, NetworkedActivityPlayerState state, bool excludeOwner = false)
		{
			if (!player.Player.NetworkPlayer.IsOwner && !base.IsServerStarted)
			{
				return AsyncResult.Failure("Only the player's owner or the server may change the player's state.");
			}
			AsyncNetworkRequest<ChangePlayerStateRequest, AsyncResult>.Result result = await _changePlayerStateRequest.SendRequest(new ChangePlayerStateRequest(player.PlayerId, state, excludeOwner));
			if (result.TimedOut)
			{
				return AsyncResult.Failure("The attempt to change the player's state timed out.");
			}
			return result.ResultData;
		}

		public void EndActivity()
		{
			if (!base.IsServerStarted && !IsActivityHost)
			{
				Debug.LogError("Only the activity host or server may end the activity.");
			}
			else
			{
				EndActivityServerRpc();
			}
		}

		public NetworkedActivityPlayer GetPlayer(NetworkPlayerScript player)
		{
			return GetPlayer(player.PlayerId);
		}

		public NetworkedActivityPlayer GetPlayer(FlightScenePlayer player)
		{
			return GetPlayer(player.NetworkPlayer.PlayerId);
		}

		public NetworkedActivityPlayer GetPlayer(int playerId)
		{
			foreach (NetworkedActivityPlayer player in _players)
			{
				if (player.PlayerId == playerId)
				{
					return player;
				}
			}
			return null;
		}

		public NetworkedActivityTeam GetTeam(NetworkedActivityTeamIds teamId)
		{
			return teamId switch
			{
				NetworkedActivityTeamIds.Team1 => Team1, 
				NetworkedActivityTeamIds.Team2 => Team2, 
				NetworkedActivityTeamIds.Spectator => TeamSpectator, 
				_ => null, 
			};
		}

		public virtual string GetTeamName(NetworkedActivityTeamIds teamId)
		{
			return teamId switch
			{
				NetworkedActivityTeamIds.Team1 => (JoinableTeams == NetworkedActivityTeamIds.Team1) ? string.Empty : "Red", 
				NetworkedActivityTeamIds.Team2 => (JoinableTeams == NetworkedActivityTeamIds.Team2) ? string.Empty : "Blue", 
				NetworkedActivityTeamIds.Spectator => "Spectator", 
				_ => "Unknown", 
			};
		}

		public async UniTask<AsyncResult> JoinActivity(FlightScenePlayer player)
		{
			if (!player.NetworkPlayer.IsOwner && !base.IsServerStarted)
			{
				return AsyncResult.Failure("Only the player's owner or the server may initiate a join activity request");
			}
			AsyncNetworkRequest<JoinActivityRequest, AsyncResult>.Result result = await _joinActivityRequest.SendRequest(new JoinActivityRequest(player.NetworkPlayer.PlayerId));
			if (result.TimedOut)
			{
				return AsyncResult.Failure("The attempt to join the activity timed out");
			}
			return result.ResultData;
		}

		public async UniTask<AsyncResult> JoinTeam(FlightScenePlayer player, NetworkedActivityTeamIds? teamId)
		{
			if (!player.NetworkPlayer.IsOwner && !base.IsServerStarted)
			{
				return AsyncResult.Failure("Only the player's owner or the server may initiate a join team request");
			}
			if (GetPlayer(player.NetworkPlayer.PlayerId) == null)
			{
				AsyncResult asyncResult = await JoinActivity(player);
				if (!asyncResult.IsSuccess)
				{
					return AsyncResult.Failure(asyncResult.Message);
				}
			}
			AsyncNetworkRequest<JoinTeamRequest, AsyncResult>.Result result = await _joinTeamRequest.SendRequest(new JoinTeamRequest(player.NetworkPlayer.PlayerId, teamId));
			if (result.TimedOut)
			{
				return AsyncResult.Failure("The attempt to join the team timed out");
			}
			return result.ResultData;
		}

		public void LeaveActivity(FlightScenePlayer player)
		{
			if (player.NetworkPlayer.IsOwner || base.IsServerStarted)
			{
				if (IsActivityHost && (int)State < 5 && Players.Count > 1)
				{
					ShowMessageToAllPlayers("The host, " + LocalPlayer.Name + ", has ended the '" + Data.DisplayName + "' activity.", logMessage: true, highlighted: true);
				}
				LeaveActivityServerRpc(player.NetworkPlayer.PlayerId);
			}
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			ClientInitialize();
		}

		public override void OnStartServer()
		{
			base.OnStartServer();
			base.TimeManager.OnPostTick += OnPostTickServer;
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			if (!base.IsServerStarted)
			{
				OnDespawn();
			}
		}

		public override void OnStopServer()
		{
			base.OnStopServer();
			if (_activityTeamIdToPlayerTeamIdMap != null)
			{
				TeamManager teamManager = Game.Instance.NetworkGameManager.TeamManager;
				foreach (ushort value in _activityTeamIdToPlayerTeamIdMap.Values)
				{
					if (value != 0)
					{
						teamManager.ReleaseActivityTeamId(value);
					}
				}
				_activityTeamIdToPlayerTeamIdMap = null;
			}
			OnDespawn();
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			InstanceId = reader.ReadGuid();
			Vector3 absolutePosition = reader.ReadVector3Unpacked();
			Quaternion rotation = reader.ReadQuaternionUnpacked();
			Data = NetworkedActivityData.LoadFromNetwork(reader);
			_initialStateFromServer = reader.ReadEnum<NetworkedActivityState>();
			base.transform.name = "NetworkedActivity: " + Data.Id;
			base.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			base.transform.SetPositionAndRotation(Utility.ConvertAbsoluteToFloatingOriginPosition(absolutePosition), rotation);
			if (_activityTeamIdToPlayerTeamIdMap == null)
			{
				_activityTeamIdToPlayerTeamIdMap = new Dictionary<NetworkedActivityTeamIds, ushort>();
			}
			int num = reader.ReadUInt8Unpacked();
			for (int i = 0; i < num; i++)
			{
				NetworkedActivityTeamIds key = reader.ReadEnum<NetworkedActivityTeamIds>();
				ushort value = reader.ReadUInt16();
				_activityTeamIdToPlayerTeamIdMap[key] = value;
			}
			int num2 = reader.ReadUInt8Unpacked();
			for (int j = 0; j < num2; j++)
			{
				NetworkedActivityTeamIds teamId = reader.ReadEnum<NetworkedActivityTeamIds>();
				int num3 = reader.ReadInt32();
				List<(string, ArraySegment<byte>)> list = new List<(string, ArraySegment<byte>)>(num3);
				for (int k = 0; k < num3; k++)
				{
					string item = reader.ReadStringAllocated();
					ArraySegment<byte> item2 = NetworkedActivityScore.ReadValueAsByteArray(reader);
					list.Add((item, item2));
				}
				_initialTeamSpawnData.Add(new InitialTeamSpawnData(teamId, list));
			}
			int num4 = reader.ReadInt32();
			for (int l = 0; l < num4; l++)
			{
				NetworkedActivityPlayer networkedActivityPlayer = new NetworkedActivityPlayer(reader.ReadInt32());
				networkedActivityPlayer.SerializeRead(reader, skipId: true);
				NetworkedActivityTeamIds team = reader.ReadEnum<NetworkedActivityTeamIds>();
				NetworkedActivityPlayerState state = reader.ReadEnum<NetworkedActivityPlayerState>();
				int num5 = reader.ReadInt32();
				List<(string, ArraySegment<byte>)> list2 = new List<(string, ArraySegment<byte>)>(num5);
				for (int m = 0; m < num5; m++)
				{
					string item3 = reader.ReadStringAllocated();
					ArraySegment<byte> item4 = NetworkedActivityScore.ReadValueAsByteArray(reader);
					list2.Add((item3, item4));
				}
				_pendingPlayerJoins.Add(new PendingPlayerJoin(networkedActivityPlayer, team, state, list2));
			}
		}

		public async UniTask<StartLocationData> RequestSpawnLocation(FlightScenePlayer flightScenePlayer)
		{
			NetworkedActivityPlayer player = GetPlayer(flightScenePlayer);
			if (player == null)
			{
				return null;
			}
			CraftLocalBounds? craftBounds = GetCraftBounds(player, initialBounds: true);
			bool initialSpawn = UseInitialSpawnLocationForPlayer(player);
			AsyncNetworkRequest<SpawnLocationRequest, SpawnLocationAsyncResult>.Result result = await _spawnLocationRequest.SendRequest(new SpawnLocationRequest(player.PlayerId, initialSpawn, craftBounds));
			SpawnLocationAsyncResult spawnLocationAsyncResult = (result.TimedOut ? new SpawnLocationAsyncResult("The request timed out") : result.ResultData);
			if (!spawnLocationAsyncResult.IsSuccess)
			{
				Debug.LogError("Failed to get a spawn location from the server. Error: " + spawnLocationAsyncResult.Message);
				return null;
			}
			return spawnLocationAsyncResult.Data;
		}

		public void ServerInitialize(Guid instanceId, NetworkedActivityData activityData)
		{
			if (!Game.Instance.NetworkGameManager.IsServer)
			{
				Debug.LogError("The ServerInitialize method of NetworkedActivityScript may only run on the server.");
				return;
			}
			if (_initializedOnServer)
			{
				Debug.LogError("The ServerInitialize method of NetworkedActivityScript has already executed and may not be initialized again.");
				return;
			}
			_initializedOnServer = true;
			InstanceId = instanceId;
			Data = activityData;
			SetActivityState(NetworkedActivityState.Created);
			TeamManager teamManager = Game.Instance.NetworkGameManager.TeamManager;
			ushort num = (ushort)((GetTeamType(NetworkedActivityTeamIds.Team1) == NetworkedActivityTeamType.Default) ? teamManager.RequestActivityTeamId(this, NetworkedActivityTeamIds.Team1) : 0);
			ushort num2 = (ushort)((GetTeamType(NetworkedActivityTeamIds.Team2) == NetworkedActivityTeamType.Default) ? teamManager.RequestActivityTeamId(this, NetworkedActivityTeamIds.Team2) : 0);
			_activityTeamIdToPlayerTeamIdMap = new Dictionary<NetworkedActivityTeamIds, ushort>();
			_activityTeamIdToPlayerTeamIdMap[NetworkedActivityTeamIds.Team1] = num;
			_activityTeamIdToPlayerTeamIdMap[NetworkedActivityTeamIds.Team2] = num2;
			_activityTeamIdToPlayerTeamIdMap[NetworkedActivityTeamIds.Spectator] = teamManager.RequestActivityTeamId(this, NetworkedActivityTeamIds.Spectator);
			if (num != 0 && num2 != 0)
			{
				FlightSceneScript.Instance.TeamAggressionManager.SetAggressionLevel(num, num2, AggressionLevel.Hostile);
			}
		}

		public void ShowMessageToAllPlayers(string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			foreach (NetworkedActivityPlayer player in Players)
			{
				ShowMessageToTargetPlayer(player, messageText, logMessage, highlighted, time);
			}
		}

		public void ShowMessageToLocalPlayer(string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			if (LocalPlayer != null)
			{
				FlightSceneScript.Instance.FlightSceneNetwork.ShowMessageToLocalPlayer(messageText, logMessage, highlighted, time);
			}
		}

		public void ShowMessageToTargetPlayer(NetworkConnection player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			NetworkPlayerScript networkPlayerScript = player?.GetPlayer();
			NetworkedActivityPlayer networkedActivityPlayer = ((networkPlayerScript == null) ? null : GetPlayer(networkPlayerScript));
			if (networkedActivityPlayer != null)
			{
				ShowMessageToTargetPlayer(networkedActivityPlayer, messageText, logMessage, highlighted, time);
			}
		}

		public void ShowMessageToTargetPlayer(NetworkPlayerScript player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			NetworkedActivityPlayer networkedActivityPlayer = ((player == null) ? null : GetPlayer(player));
			if (networkedActivityPlayer != null)
			{
				ShowMessageToTargetPlayer(networkedActivityPlayer, messageText, logMessage, highlighted, time);
			}
		}

		public void ShowMessageToTargetPlayer(FlightScenePlayer player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			NetworkedActivityPlayer networkedActivityPlayer = ((player == null) ? null : GetPlayer(player));
			if (networkedActivityPlayer != null)
			{
				ShowMessageToTargetPlayer(networkedActivityPlayer, messageText, logMessage, highlighted, time);
			}
		}

		public void ShowMessageToTargetPlayer(NetworkedActivityPlayer player, string messageText, bool logMessage, bool highlighted = false, float time = 7f)
		{
			if (player != null && Players.Contains(player))
			{
				FlightSceneScript.Instance.FlightSceneNetwork.ShowMessageToTargetPlayer(player.Player, messageText, logMessage, highlighted, time);
			}
		}

		public void StartActivity()
		{
			if (!IsActivityHost)
			{
				Debug.LogError("Only the activity host may start the activity.");
			}
			else
			{
				StartActivityServerRpc();
			}
		}

		public void StartTimer(int initialTimerValue, ActivityTimerType timerType = ActivityTimerType.CountDown)
		{
			StartTimerServerRpc(initialTimerValue, timerType);
		}

		public void StopTimer()
		{
			StopTimerServerRpc();
		}

		public virtual async UniTask UpdateStartText(Action<string> setText, StartTextShowDelegate show, StartTextHideDelegate hide)
		{
			if (CraftsStartPaused)
			{
				while (!TimerValue.HasValue)
				{
					await UniTask.Yield();
					if (_startCountdownComplete)
					{
						return;
					}
				}
				while (true)
				{
					if (_pendingStartText != null)
					{
						string newText = _pendingStartText;
						hide(delegate
						{
							setText(newText);
							show(force: true);
						}, force: true);
						_pendingStartText = null;
					}
					if (_startCountdownComplete)
					{
						break;
					}
					await UniTask.Yield();
				}
				await UniTask.WaitForSeconds(3f, ignoreTimeScale: true);
				hide();
			}
			else
			{
				setText("GO!");
				show();
				await UniTask.WaitForSeconds(3f);
				hide();
			}
		}

		public override void WritePayload(NetworkConnection connection, Writer writer)
		{
			base.WritePayload(connection, writer);
			writer.WriteGuidAllocated(InstanceId);
			writer.WriteVector3Unpacked(Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position));
			writer.WriteQuaternionUnpacked(base.transform.rotation);
			Data.SerializeWrite(writer, includeDescription: false);
			writer.WriteEnum(State);
			writer.WriteUInt8Unpacked((byte)_activityTeamIdToPlayerTeamIdMap.Count);
			foreach (KeyValuePair<NetworkedActivityTeamIds, ushort> item in _activityTeamIdToPlayerTeamIdMap)
			{
				writer.WriteEnum(item.Key);
				writer.WriteUInt16(item.Value);
			}
			List<NetworkedActivityTeam> value;
			using (CollectionPool<List<NetworkedActivityTeam>, NetworkedActivityTeam>.Get(out value))
			{
				foreach (NetworkedActivityTeamIds value2 in EnumUtility<NetworkedActivityTeamIds>.Values)
				{
					NetworkedActivityTeam team = GetTeam(value2);
					if (team != null && team.Players.Count > 0)
					{
						value.Add(team);
					}
				}
				writer.WriteUInt8Unpacked((byte)value.Count);
				foreach (NetworkedActivityTeam item2 in value)
				{
					writer.WriteEnum(item2.Id);
					writer.WriteInt32(item2.Scores.Count);
					foreach (NetworkedActivityScore score in item2.Scores)
					{
						writer.Write(score.Id);
						score.WriteValue(writer);
					}
				}
				writer.Write(_players.Count);
				foreach (NetworkedActivityPlayer player in _players)
				{
					writer.Write(player.PlayerId);
					player.SerializeWrite(writer, skipId: true);
					writer.WriteEnum(player.Team?.Id ?? NetworkedActivityTeamIds.None);
					writer.WriteEnum(player.State);
					writer.WriteInt32(player.Scores.Count);
					foreach (NetworkedActivityScore score2 in player.Scores)
					{
						writer.Write(score2.Id);
						score2.WriteValue(writer);
					}
				}
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual bool CanJoinActivity(FlightScenePlayer player, out string joinDeniedReason)
		{
			joinDeniedReason = null;
			if ((int)State >= 5)
			{
				joinDeniedReason = "The activity has already ended.";
				return false;
			}
			return true;
		}

		protected virtual bool CanJoinTeam(NetworkedActivityPlayer player, NetworkedActivityTeam team, out string joinDeniedReason)
		{
			joinDeniedReason = null;
			return true;
		}

		protected virtual void CreateTeamStartingLocationGameObjects()
		{
		}

		protected void EnsureClientInitialized()
		{
			if (!_initializedOnClient)
			{
				try
				{
					ClientInitialize();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("Failed to perform client initialization of the activity.");
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (base.IsServerStarted)
			{
				OnFixedUpdateServer();
			}
			if (IsActivityHost)
			{
				OnFixedUpdateHost();
			}
			if (IsLocalClientParticipating)
			{
				OnFixedUpdateParticipatingClient();
			}
			OnFixedUpdate();
		}

		protected virtual NetworkedActivityTeamIds GetAutoJoinTeam(NetworkedActivityPlayer player)
		{
			List<NetworkedActivityTeam> value;
			using (CollectionPool<List<NetworkedActivityTeam>, NetworkedActivityTeam>.Get(out value))
			{
				foreach (NetworkedActivityTeamIds value2 in EnumUtility<NetworkedActivityTeamIds>.Values)
				{
					NetworkedActivityTeam team = GetTeam(value2);
					if (team != null && team.IsPlayerJoinable)
					{
						value.Add(team);
					}
				}
				if (value.Count == 0)
				{
					Debug.LogError("No joinable teams found.");
					return NetworkedActivityTeamIds.Spectator;
				}
				NetworkedActivityTeam networkedActivityTeam = value[0];
				for (int i = 1; i < value.Count; i++)
				{
					if (networkedActivityTeam.Players.Count > value[i].Players.Count)
					{
						networkedActivityTeam = value[i];
					}
				}
				return networkedActivityTeam.Id;
			}
		}

		protected virtual IEnumerable<StartLocationData> GetDefaultStartLocations(NetworkedActivityTeamIds teamId)
		{
			IEnumerable<StartLocationData> enumerable = from x in (from x in Data.XmlData.Elements("StartLocations")
					where x.GetEnumAttribute("teamId", NetworkedActivityTeamIds.None) == teamId
					select x).Elements()
				select new StartLocationData(x, StartLocationType.Temp);
			if (enumerable.Any())
			{
				return enumerable;
			}
			return from x in GetComponentsInChildren<StartingLocationScript>(includeInactive: true)
				where x.TeamID == teamId
				select x.CreateStartLocationData();
		}

		protected virtual StartLocationData GetPlayerSpawnLocation(NetworkedActivityPlayer player, bool initialSpawn, CraftLocalBounds? bounds)
		{
			StartLocationData value = null;
			if ((int)State < 3)
			{
				return null;
			}
			NetworkedActivityTeamIds id = player.Team.Id;
			IReadOnlyList<StartLocationData> startLocations = player.Team.StartLocations;
			if (!initialSpawn && startLocations.Count > 0)
			{
				int num = _startLocationsNextIndex[id] % startLocations.Count;
				_startLocationsNextIndex[id] = (num + 1) % startLocations.Count;
				value = startLocations[num];
			}
			if (value == null && !_initialPlayerStartLocations.TryGetValue(player.PlayerId, out value))
			{
				value = ((startLocations.Count > 0) ? startLocations[0] : null);
			}
			return value;
		}

		protected virtual NetworkedActivityTeamType GetTeamType(NetworkedActivityTeamIds teamId)
		{
			return NetworkedActivityTeamType.Default;
		}

		protected virtual void LateUpdate()
		{
			if (base.IsServerStarted)
			{
				OnLateUpdateServer();
			}
			if (IsActivityHost)
			{
				OnLateUpdateHost();
			}
			if (IsLocalClientParticipating)
			{
				OnLateUpdateParticipatingClient();
			}
			OnLateUpdate();
		}

		protected virtual void OnActivityEndedClient()
		{
		}

		protected virtual void OnActivityEndedServer()
		{
		}

		protected virtual void OnActivityEndingClient()
		{
		}

		protected virtual void OnActivityEndingServer()
		{
		}

		protected virtual void OnActivityStartedClient()
		{
		}

		protected virtual void OnActivityStartedServer()
		{
		}

		protected virtual void OnActivityStartingClient()
		{
		}

		protected virtual void OnActivityStartingServer()
		{
		}

		protected virtual void OnClientInitialized()
		{
		}

		protected virtual void OnDespawned()
		{
		}

		protected virtual void OnDespawning()
		{
		}

		protected virtual void OnDestroy()
		{
			OnDespawn();
			OnDestroyed();
		}

		protected virtual void OnDestroyed()
		{
		}

		protected virtual void OnDrawGizmosSelected()
		{
			OnDrawGizmosStartLocations();
		}

		protected virtual void OnFixedUpdate()
		{
		}

		protected virtual void OnFixedUpdateHost()
		{
		}

		protected virtual void OnFixedUpdateParticipatingClient()
		{
		}

		protected virtual void OnFixedUpdateServer()
		{
		}

		protected virtual void OnLateUpdate()
		{
		}

		protected virtual void OnLateUpdateHost()
		{
		}

		protected virtual void OnLateUpdateParticipatingClient()
		{
		}

		protected virtual void OnLateUpdateServer()
		{
		}

		protected virtual void OnLocalPlayerEnded(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnLocalPlayerEnding(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnLocalPlayerStarted(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnLocalPlayerStarting(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerAircraftLoadCompleted(NetworkedActivityPlayer player, AircraftScript aircraft)
		{
		}

		protected virtual void OnPlayerEnded(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerEnding(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerEnteredAircraft(NetworkedActivityPlayer player, AircraftScript aircraft)
		{
		}

		protected virtual void OnPlayerExitedAircraft(NetworkedActivityPlayer player, AircraftScript aircraft)
		{
		}

		protected virtual void OnPlayerJoined(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerLeft(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerStarted(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerStarting(NetworkedActivityPlayer player)
		{
		}

		protected virtual void OnPlayerStateChanged(NetworkedActivityPlayer player, NetworkedActivityPlayerState previousState, NetworkedActivityPlayerState newState)
		{
		}

		protected virtual void OnPostTickClient()
		{
		}

		protected virtual void OnPostTickHost()
		{
			_settingsSync.Sync();
		}

		protected virtual void OnPostTickServer()
		{
		}

		protected virtual void OnSettingChanged(NetworkedActivitySetting setting)
		{
		}

		protected virtual void OnStateChanged(NetworkedActivityState previousState, NetworkedActivityState newState)
		{
		}

		protected virtual void OnTeamJoined(NetworkedActivityPlayer player, NetworkedActivityTeam team)
		{
		}

		protected virtual void OnTeamLeft(NetworkedActivityPlayer player, NetworkedActivityTeam team)
		{
		}

		protected virtual void OnTimerChangedClient(int timerValue)
		{
			if (_startCountdownComplete)
			{
				return;
			}
			if (timerValue < 0)
			{
				_pendingStartText = Mathf.Abs(timerValue).ToString();
				return;
			}
			_startCountdownComplete = true;
			_pendingStartText = "GO!";
			foreach (NetworkedActivityPlayer player in Players)
			{
				if (player.Owner == base.LocalConnection)
				{
					player.Player?.CurrentOrPreviousAircraft?.CraftUpdate.SetCraftPausedState(paused: false);
				}
			}
		}

		protected virtual void OnTimerStartedClient()
		{
		}

		protected virtual void OnTimerStoppedClient()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnUpdateHost()
		{
		}

		protected virtual void OnUpdateParticipatingClient()
		{
		}

		protected virtual void OnUpdateServer()
		{
			UpdateTimerServer(Time.deltaTime);
		}

		protected virtual UniTask PerformLocalPlayerStartingActivityTasks(NetworkedActivityPlayer player)
		{
			return UniTask.CompletedTask;
		}

		protected virtual void Update()
		{
			if (base.IsServerStarted)
			{
				if (State == NetworkedActivityState.Started)
				{
					ProcessLatePlayerJoins();
				}
				OnUpdateServer();
			}
			if (IsActivityHost)
			{
				OnUpdateHost();
			}
			if (IsLocalClientParticipating)
			{
				OnUpdateParticipatingClient();
			}
			OnUpdate();
		}

		protected virtual bool UseInitialSpawnLocationForPlayer(NetworkedActivityPlayer player)
		{
			return (int)State < 4;
		}

		private void AddPlayerToActivity(NetworkedActivityPlayer activityPlayer)
		{
			int playerId = activityPlayer.PlayerId;
			FlightScenePlayer flightScenePlayer = activityPlayer.Player ?? FlightSceneScript.Instance.GetPlayer(playerId);
			if (flightScenePlayer == null)
			{
				Debug.LogError($"Unable to add player '{playerId}' to activity '{Data.DisplayName}' because a player with that id could not be found.");
				return;
			}
			if (flightScenePlayer.NetworkedActivity != null)
			{
				if (flightScenePlayer.NetworkedActivity == this)
				{
					Debug.LogError($"Player '{playerId}' failed to join activity '{Data.DisplayName}' because they are already participating in the activity.");
				}
				else
				{
					Debug.LogError($"Player '{playerId}' failed to join activity '{Data.DisplayName}' because they are currently participating in activity '{flightScenePlayer.NetworkedActivity.Data.DisplayName}'.");
				}
				return;
			}
			if (GetPlayer(playerId) != null)
			{
				Debug.LogError($"Player '{playerId}' failed to join activity '{Data.DisplayName}' because a player with that id is already participating in the activity.");
				return;
			}
			if (activityPlayer.Player == null)
			{
				activityPlayer.OnPlayerLoaded(flightScenePlayer);
			}
			_players.Add(activityPlayer);
			if (!flightScenePlayer.NetworkPlayer.IsNPC && flightScenePlayer.NetworkPlayer.Owner == base.Owner)
			{
				ActivityHost = activityPlayer;
			}
			IsLocalClientParticipating |= flightScenePlayer.NetworkPlayer.Owner == base.LocalConnection;
			if (flightScenePlayer.IsPrimaryLocal)
			{
				LocalPlayer = activityPlayer;
			}
			flightScenePlayer.AircraftEntered += OnPlayerEnteredAircraft;
			flightScenePlayer.AircraftExited += OnPlayerExitedAircraft;
			flightScenePlayer.AircraftLoadCompleted += OnPlayerAircraftLoadCompleted;
			foreach (NetworkedActivityScore item in CreateScoresForPlayer(activityPlayer))
			{
				activityPlayer.RegisterScore(item);
			}
			try
			{
				activityPlayer.OnActivityJoined(this);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				OnPlayerJoined(activityPlayer);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			try
			{
				this.PlayerJoined?.Invoke(this, new NetworkedActivityPlayerEventArgs(this, activityPlayer));
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
			}
			if (_manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.PlayersChanged))
			{
				Debug.Log($"Player '{flightScenePlayer.Name}' (id: {playerId}) joined networked activity '{Data.DisplayName}'.");
			}
		}

		private void AddPlayerToTeam(NetworkedActivityPlayer player, NetworkedActivityTeam team)
		{
			if (player.Team == team)
			{
				Debug.LogError($"Player '{player.PlayerId}' tried to join team '{team.Id}' of activity '{Data.DisplayName}' but the player was already a member of that team.");
				return;
			}
			RemovePlayerFromTeam(player);
			try
			{
				team.AddPlayer(player);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				OnTeamJoined(player, team);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			try
			{
				this.TeamJoined?.Invoke(this, new NetworkedActivityPlayerTeamEventArgs(this, player, team));
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
			}
			if (_manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.PlayerTeamChanged))
			{
				Debug.Log($"Player '{player.Name}' (id: {player.PlayerId}) joined team '{team.Name}' (id: {team.Id}) of networked activity '{Data.DisplayName}'.");
			}
		}

		private StartLocationData BuildInitialStartLocationForPlayer(NetworkedActivityPlayer player, InitialStartLocation initialStartLocation)
		{
			StartLocationData startLocationData = initialStartLocation.CreateStartLocation(player);
			if (startLocationData == null)
			{
				Debug.LogError("Creating initial start location for player '" + player.Name + "' failed.");
				startLocationData = initialStartLocation.DefaultStartLocation.Clone();
				startLocationData.LocationType = StartLocationType.Temp;
			}
			return startLocationData;
		}

		[ObserversRpc(RunLocally = true)]
		private void ChangeActivityStateClientRpc(NetworkedActivityState state)
		{
			RpcWriter___Observers_ChangeActivityStateClientRpc___2895260176(state);
			RpcLogic___ChangeActivityStateClientRpc___2895260176(state);
		}

		[ObserversRpc]
		private void ChangePlayerStateClientRpc(int playerId, NetworkedActivityPlayerState state, bool excludeOwner)
		{
			RpcWriter___Observers_ChangePlayerStateClientRpc___938339791(playerId, state, excludeOwner);
		}

		[ServerRpc(RequireOwnership = false)]
		private void ChangePlayerStateRequestRpc(int requestId, ChangePlayerStateRequest request, NetworkConnection client = null)
		{
			RpcWriter___Server_ChangePlayerStateRequestRpc___1472219066(requestId, request, client);
		}

		[TargetRpc]
		private void ChangePlayerStateResultRpc(NetworkConnection client, int requestId, AsyncResult result)
		{
			RpcWriter___Target_ChangePlayerStateResultRpc___1617942072(client, requestId, result);
		}

		private void ClientInitialize()
		{
			if (!_initializedOnClient)
			{
				_initializedOnClient = true;
				if (base.IsOwner)
				{
					IsActivityHost = true;
					base.TimeManager.OnPostTick += OnPostTickHost;
				}
				base.TimeManager.OnPostTick += OnPostTickClient;
				_settingsSync = new SettingsSynchronization(this, SyncSettingsServerRpc);
				Data.Settings.SettingAdded += OnSettingChanged;
				Data.Settings.SettingValueChanged += OnSettingChanged;
				CreateTeamStartingLocationGameObjects();
				Team1 = CreateTeam(NetworkedActivityTeamIds.Team1);
				Team2 = CreateTeam(NetworkedActivityTeamIds.Team2);
				TeamSpectator = CreateTeam(NetworkedActivityTeamIds.Spectator);
				int timeout = 15000;
				_joinActivityRequest = new AsyncServerNetworkRequest<JoinActivityRequest, AsyncResult>(timeout, JoinActivityRequestRpc, JoinActivityResultRpc);
				_joinTeamRequest = new AsyncServerNetworkRequest<JoinTeamRequest, AsyncResult>(timeout, JoinTeamRequestRpc, JoinTeamResultRpc);
				_changePlayerStateRequest = new AsyncServerNetworkRequest<ChangePlayerStateRequest, AsyncResult>(timeout, ChangePlayerStateRequestRpc, ChangePlayerStateResultRpc);
				_playerCraftBoundsRequest = new AsyncClientNetworkRequest<PlayerCraftBoundsRequest, CraftBoundsAsyncResult>(timeout, PlayerCraftBoundsRequestRpc, PlayerCraftBoundsResultRpc);
				_startActivityForPlayerRequest = new AsyncClientNetworkRequest<StartActivityForPlayerRequest, AsyncResult>(timeout, StartActivityForPlayerClientRpc, StartActivityForPlayerResultRpc);
				_waitForAllPlayersStartedRequest = new AsyncClientNetworkRequest<WaitForAllPlayersStartedRequest, AsyncResult>(timeout, WaitForAllPlayersStartedClientRpc, WaitForAllPlayersStartedResultRpc);
				_endActivityForPlayerRequest = new AsyncClientNetworkRequest<EndActivityForPlayerRequest, AsyncResult>(timeout, EndActivityForPlayerClientRpc, EndActivityForPlayerResultRpc);
				_waitForAllPlayersEndedRequest = new AsyncClientNetworkRequest<WaitForAllPlayersEndedRequest, AsyncResult>(timeout, WaitForAllPlayersEndedClientRpc, WaitForAllPlayersEndedResultRpc);
				_spawnLocationRequest = new AsyncServerNetworkRequest<SpawnLocationRequest, SpawnLocationAsyncResult>(timeout, SpawnLocationRequestRpc, SpawnLocationResultRpc);
				NetworkedActivityState networkedActivityState = (((int)_initialStateFromServer < 2) ? NetworkedActivityState.Initialized : _initialStateFromServer);
				for (int i = (int)(State + 1); i <= (int)networkedActivityState; i++)
				{
					SetActivityState((NetworkedActivityState)i);
				}
				ProcessPendingPlayerJoins();
				FlightSceneScript instance = FlightSceneScript.Instance;
				instance.PlayerLoaded += OnFlightScenePlayerLoaded;
				instance.PlayerUnloaded += OnFlightScenePlayerUnloaded;
				OnClientInitialized();
			}
		}

		private void CreateInitialPlayerStartLocation(NetworkedActivityPlayer player, CraftLocalBounds bounds)
		{
			InitialStartLocation initialStartLocation = RegisterPlayerWithInitialStartLocation(player, bounds);
			if (initialStartLocation != null)
			{
				StartLocationData value = BuildInitialStartLocationForPlayer(player, initialStartLocation);
				_initialPlayerStartLocations[player.PlayerId] = value;
			}
		}

		private void CreateInitialPlayerStartLocations(List<(NetworkedActivityPlayer Player, CraftLocalBounds Bounds)> players)
		{
			players.Shuffle();
			InitialStartLocation[] array = new InitialStartLocation[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = RegisterPlayerWithInitialStartLocation(players[i].Player, players[i].Bounds);
			}
			for (int j = 0; j < players.Count; j++)
			{
				if (array[j] != null)
				{
					StartLocationData value = BuildInitialStartLocationForPlayer(players[j].Player, array[j]);
					_initialPlayerStartLocations[players[j].Player.PlayerId] = value;
				}
			}
		}

		private NetworkedActivityTeam CreateTeam(NetworkedActivityTeamIds teamId)
		{
			IEnumerable<StartLocationData> defaultStartLocations = GetDefaultStartLocations(teamId);
			foreach (StartLocationData item in defaultStartLocations)
			{
				item.Id = "Temp";
				StartLocationData startLocationData = item;
				if (startLocationData.DisplayName == null)
				{
					string text = (startLocationData.DisplayName = string.Empty);
				}
				_initialStartLocations[teamId].Add(new InitialStartLocation(teamId, item));
			}
			ushort playerTeamId = _activityTeamIdToPlayerTeamIdMap[teamId];
			NetworkedActivityTeam networkedActivityTeam = new NetworkedActivityTeam(this, teamId, GetTeamType(teamId), playerTeamId, GetTeamName(teamId), JoinableTeams.HasFlag(teamId), defaultStartLocations);
			foreach (NetworkedActivityScore item2 in CreateScoresForTeam(networkedActivityTeam))
			{
				networkedActivityTeam.RegisterScore(item2);
			}
			foreach (InitialTeamSpawnData initialTeamSpawnDatum in _initialTeamSpawnData)
			{
				if (initialTeamSpawnDatum.TeamId != teamId)
				{
					continue;
				}
				foreach (var score2 in initialTeamSpawnDatum.Scores)
				{
					NetworkedActivityScore score = networkedActivityTeam.GetScore(score2.Id);
					if (score == null)
					{
						Debug.LogError($"Unable to find score '{score.Id}' on team '{teamId}' when creating the team.");
						continue;
					}
					using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(score2.Value);
					score.ReadValue((PooledReader)pooledReaderDisposableWrapper);
				}
				break;
			}
			return networkedActivityTeam;
		}

		[ContextMenu("Debug Initial Start Locations")]
		private void DebugInitialStartLocations()
		{
			foreach (NetworkedActivityTeamIds key in _initialStartLocations.Keys)
			{
				List<InitialStartLocation> list = _initialStartLocations[key];
				if (list.Count != 0)
				{
					GameObject gameObject = CreateGameObject(key.ToString(), base.transform, base.transform.position, base.transform.rotation, addStartLocationScript: false);
					for (int i = 0; i < list.Count; i++)
					{
						StartLocationData defaultStartLocation = list[i].DefaultStartLocation;
						CreateGameObject($"StartLocation {i}", gameObject.transform, defaultStartLocation.Position, Quaternion.Euler(defaultStartLocation.Rotation));
					}
				}
			}
			static GameObject CreateGameObject(string name, Transform parent, Vector3 position, Quaternion rotation, bool addStartLocationScript = true)
			{
				GameObject gameObject2 = new GameObject(name);
				gameObject2.transform.SetParent(parent, worldPositionStays: false);
				gameObject2.transform.SetPositionAndRotation(Utility.ConvertAbsoluteToFloatingOriginPosition(position), rotation);
				if (addStartLocationScript)
				{
					gameObject2.AddComponent<StartingLocationScript>();
				}
				return gameObject2;
			}
		}

		private void DespawnActivity()
		{
			if (!_despawned)
			{
				Despawn();
			}
		}

		private async UniTaskVoid EndActivityAsync()
		{
			_ = 1;
			try
			{
				if ((int)State < 4)
				{
					Debug.LogError("Unable to end activity '" + Data.DisplayName + "' because it has not yet been started.");
				}
				else if ((int)State >= 5)
				{
					Debug.LogError("Unable to end activity '" + Data.DisplayName + "' because it has already ended.");
				}
				ChangeActivityStateClientRpc(NetworkedActivityState.Ending);
				List<NetworkedActivityPlayer> players = _players.Where((NetworkedActivityPlayer x) => x.State == NetworkedActivityPlayerState.Playing).ToList();
				await EndActivityForEachPlayer(players);
				await EndActivityWaitForPlayers(players);
				ChangeActivityStateClientRpc(NetworkedActivityState.Ended);
				if (ActivityHost == null || _players.Count == 0)
				{
					DespawnActivity();
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("An exception occurred trying to end networked activity '" + Data?.DisplayName + "'.");
				Debug.LogException(exception);
			}
		}

		private async UniTask EndActivityForEachPlayer(List<NetworkedActivityPlayer> players)
		{
			UniTask<AsyncNetworkRequest<EndActivityForPlayerRequest, AsyncResult>.Result>[] array = _endActivityForPlayerRequest.CreateResultArray(players.Count);
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = _endActivityForPlayerRequest.SendRequest(new EndActivityForPlayerRequest(players[i].PlayerId), players[i].Owner);
			}
			AsyncNetworkRequest<EndActivityForPlayerRequest, AsyncResult>.Result[] array2 = await UniTask.WhenAll(array);
			List<NetworkedActivityPlayer> list = new List<NetworkedActivityPlayer>(0);
			for (int j = 0; j < array2.Length; j++)
			{
				AsyncResult asyncResult = (array2[j].TimedOut ? AsyncResult.Failure("Request timed out") : array2[j].ResultData);
				if (!asyncResult.IsSuccess)
				{
					if (j >= players.Count)
					{
						Debug.LogError("Received more player activity end results than the number of requested players.");
						continue;
					}
					NetworkedActivityPlayer networkedActivityPlayer = players[j];
					Debug.LogError($"Ending activity for player '{networkedActivityPlayer.Name}' (id: {networkedActivityPlayer.PlayerId}) failed with error: {asyncResult.Message}");
					list.Add(networkedActivityPlayer);
				}
			}
			foreach (NetworkedActivityPlayer item in list)
			{
				players.Remove(item);
			}
		}

		private async UniTaskVoid EndActivityForLocalPlayerAsync(int requestId, EndActivityForPlayerRequest request)
		{
			NetworkedActivityPlayer player = GetPlayer(request.PlayerId);
			if (player == null)
			{
				string message = $"Unable to end networked activity '{Data.DisplayName}' for player '{request.PlayerId}' because a player with that id could not be found.";
				Debug.LogError(message);
				_endActivityForPlayerRequest.SendResult(requestId, AsyncResult.Failure(message));
				return;
			}
			try
			{
				AsyncResult resultData = await EndActivityForLocalPlayerAsync(player);
				_endActivityForPlayerRequest.SendResult(requestId, resultData);
			}
			catch (Exception exception)
			{
				string message2 = $"An exception occurred trying to end networked activity '{Data?.DisplayName}' for player '{player.Name}' (id: {player.PlayerId}).";
				Debug.LogError(message2);
				Debug.LogException(exception);
				_endActivityForPlayerRequest.SendResult(requestId, AsyncResult.Failure(message2));
			}
		}

		private async UniTask<AsyncResult> EndActivityForLocalPlayerAsync(NetworkedActivityPlayer player)
		{
			SetPlayerState(player, NetworkedActivityPlayerState.Ending);
			AsyncResult asyncResult = await ChangePlayerState(player, NetworkedActivityPlayerState.Ending, excludeOwner: true);
			if (!asyncResult.IsSuccess)
			{
				Debug.LogError("An error occurred changing state for player '" + player.Name + "'. Error: " + asyncResult.Message);
			}
			SetPlayerState(player, NetworkedActivityPlayerState.Ended);
			asyncResult = await ChangePlayerState(player, NetworkedActivityPlayerState.Ended, excludeOwner: true);
			if (!asyncResult.IsSuccess)
			{
				Debug.LogError("An error occurred changing state for player '" + player.Name + "'. Error: " + asyncResult.Message);
			}
			return AsyncResult.Success();
		}

		[TargetRpc]
		private void EndActivityForPlayerClientRpc(NetworkConnection client, int requestId, EndActivityForPlayerRequest request)
		{
			RpcWriter___Target_EndActivityForPlayerClientRpc___3489439314(client, requestId, request);
		}

		[ServerRpc(RequireOwnership = false)]
		private void EndActivityForPlayerResultRpc(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			RpcWriter___Server_EndActivityForPlayerResultRpc___2038029376(requestId, result, client);
		}

		[ServerRpc(RequireOwnership = false)]
		private void EndActivityServerRpc()
		{
			RpcWriter___Server_EndActivityServerRpc___2166136261();
		}

		private async UniTask EndActivityWaitForPlayers(List<NetworkedActivityPlayer> players)
		{
			List<NetworkConnection> clients = new List<NetworkConnection>(players.Count);
			int[] array = new int[players.Count];
			for (int i = 0; i < players.Count; i++)
			{
				NetworkedActivityPlayer networkedActivityPlayer = players[i];
				array[i] = networkedActivityPlayer.PlayerId;
				if (!clients.Contains(networkedActivityPlayer.Owner))
				{
					clients.Add(networkedActivityPlayer.Owner);
				}
			}
			WaitForAllPlayersEndedRequest data = new WaitForAllPlayersEndedRequest(array);
			UniTask<AsyncNetworkRequest<WaitForAllPlayersEndedRequest, AsyncResult>.Result>[] array2 = _waitForAllPlayersEndedRequest.CreateResultArray(clients.Count);
			for (int j = 0; j < clients.Count; j++)
			{
				array2[j] = _waitForAllPlayersEndedRequest.SendRequest(data, clients[j]);
			}
			AsyncNetworkRequest<WaitForAllPlayersEndedRequest, AsyncResult>.Result[] array3 = await UniTask.WhenAll(array2);
			for (int k = 0; k < array3.Length; k++)
			{
				AsyncResult asyncResult = (array3[k].TimedOut ? AsyncResult.Failure("Request timed out") : array3[k].ResultData);
				if (!asyncResult.IsSuccess)
				{
					if (k >= clients.Count)
					{
						Debug.LogError("Received more player wait results than the number of clients.");
						continue;
					}
					NetworkConnection networkConnection = clients[k];
					Debug.LogError($"Waiting for players to end activity on client '{networkConnection.ClientId}' failed with error: {asyncResult.Message}");
				}
			}
		}

		private CraftLocalBounds? GetCraftBounds(NetworkedActivityPlayer player, bool initialBounds)
		{
			AircraftScript aircraftScript = player.Player?.Aircraft ?? player.Player?.PreviousAircraft;
			if (aircraftScript == null)
			{
				return null;
			}
			if (initialBounds)
			{
				return new CraftLocalBounds(aircraftScript.Aircraft.Size, aircraftScript.Aircraft.BoundsOffset);
			}
			Bounds bounds = aircraftScript.CalculateBounds(includeDisconnectedParts: false);
			Vector3 offset = aircraftScript.Position - bounds.center;
			return new CraftLocalBounds(bounds.size, offset);
		}

		private void InitializeAICraftManager()
		{
			_aiCraftManager = AiManagerScript.Instance;
			_aiCrafts = new List<AircraftScript>();
			_aiCraftsOwned = new List<AiControlledAircraftScript>();
			ActivityEnding += delegate
			{
				DespawnLocallyOwnedAICraft();
			};
			PlayerLeft += delegate(object s, NetworkedActivityPlayerEventArgs e)
			{
				if (e.Player.Player.IsPrimaryLocal)
				{
					DespawnLocallyOwnedAICraft();
				}
			};
		}

		[ObserversRpc(RunLocally = true)]
		private void JoinActivityClientRpc(int playerId)
		{
			RpcWriter___Observers_JoinActivityClientRpc___3316948804(playerId);
			RpcLogic___JoinActivityClientRpc___3316948804(playerId);
		}

		[ServerRpc(RequireOwnership = false)]
		private void JoinActivityRequestRpc(int requestId, JoinActivityRequest request, NetworkConnection client = null)
		{
			RpcWriter___Server_JoinActivityRequestRpc___1737904189(requestId, request, client);
		}

		[TargetRpc]
		private void JoinActivityResultRpc(NetworkConnection client, int requestId, AsyncResult result)
		{
			RpcWriter___Target_JoinActivityResultRpc___1617942072(client, requestId, result);
		}

		[ObserversRpc(RunLocally = true)]
		private void JoinTeamClientRpc(int playerId, NetworkedActivityTeamIds teamId)
		{
			RpcWriter___Observers_JoinTeamClientRpc___839618763(playerId, teamId);
			RpcLogic___JoinTeamClientRpc___839618763(playerId, teamId);
		}

		[ServerRpc(RequireOwnership = false)]
		private void JoinTeamRequestRpc(int requestId, JoinTeamRequest request, NetworkConnection client = null)
		{
			RpcWriter___Server_JoinTeamRequestRpc___3842842145(requestId, request, client);
		}

		[TargetRpc]
		private void JoinTeamResultRpc(NetworkConnection client, int requestId, AsyncResult result)
		{
			RpcWriter___Target_JoinTeamResultRpc___1617942072(client, requestId, result);
		}

		[ObserversRpc]
		private void LeaveActivityClientRpc(int playerId)
		{
			RpcWriter___Observers_LeaveActivityClientRpc___3316948804(playerId);
		}

		[ServerRpc(RequireOwnership = false)]
		private void LeaveActivityServerRpc(int playerId)
		{
			RpcWriter___Server_LeaveActivityServerRpc___3316948804(playerId);
		}

		private void OnDespawn()
		{
			if (!_despawned)
			{
				_despawned = true;
				OnDespawning();
				RaiseActivityEvent(this.Despawning);
				for (int num = _players.Count - 1; num >= 0; num--)
				{
					RemovePlayerFromActivity(_players[num]);
				}
				SetActivityState(NetworkedActivityState.Destroyed);
				UnsubcribeFromPostTicks();
				FlightSceneScript instance = FlightSceneScript.Instance;
				if ((object)instance != null)
				{
					instance.PlayerLoaded -= OnFlightScenePlayerLoaded;
					instance.PlayerUnloaded -= OnFlightScenePlayerUnloaded;
				}
				NetworkedActivitySettings settings = Data.Settings;
				if (settings != null)
				{
					settings.SettingAdded -= OnSettingChanged;
					settings.SettingValueChanged -= OnSettingChanged;
				}
				OnDespawned();
				RaiseActivityEvent(this.Despawned);
			}
		}

		private void OnDrawGizmosStartLocations()
		{
			if (_initialStartLocations == null)
			{
				return;
			}
			List<Color> value;
			using (CollectionPool<List<Color>, Color>.Get(out value))
			{
				value.Add(Color.blue);
				value.Add(Color.cyan);
				value.Add(Color.green);
				value.Add(Color.yellow);
				value.Add(Color.red);
				value.Add(Color.magenta);
				int num = 0;
				foreach (KeyValuePair<NetworkedActivityTeamIds, List<InitialStartLocation>> initialStartLocation in _initialStartLocations)
				{
					if (initialStartLocation.Value == null)
					{
						continue;
					}
					foreach (InitialStartLocation item in initialStartLocation.Value)
					{
						if (item.PlayerIds.Any())
						{
							StartLocationData defaultStartLocation = item.DefaultStartLocation;
							Vector3 pos = Utility.ConvertAbsoluteToFloatingOriginPosition(defaultStartLocation.Position);
							Quaternion q = Quaternion.Euler(defaultStartLocation.Rotation);
							Gizmos.color = Color.white;
							Gizmos.matrix = Matrix4x4.TRS(pos, q, Vector3.one);
							Gizmos.DrawSphere(Vector3.zero, 1f);
						}
						foreach (int playerId in item.PlayerIds)
						{
							if (playerId >= 0 && _initialPlayerStartLocations.TryGetValue(playerId, out var value2))
							{
								CraftLocalBounds? playerCraftBounds = item.GetPlayerCraftBounds(playerId);
								if (!playerCraftBounds.HasValue)
								{
									Debug.Log($"Initial start location craft bounds for player '{playerId}' could not be found.");
									continue;
								}
								Vector3 pos2 = Utility.ConvertAbsoluteToFloatingOriginPosition(value2.Position);
								Quaternion q2 = Quaternion.Euler(value2.Rotation);
								Gizmos.color = value[num];
								num = (num + 1) % value.Count;
								Gizmos.matrix = Matrix4x4.TRS(pos2, q2, Vector3.one);
								Gizmos.DrawWireCube(-playerCraftBounds.Value.Offset, playerCraftBounds.Value.Size);
							}
						}
					}
				}
			}
		}

		private void OnFlightScenePlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			ProcessPendingPlayerJoins();
		}

		private void OnFlightScenePlayerUnloaded(object sender, FlightScenePlayerEventArgs e)
		{
			int? playerId = e.Player?.NetworkPlayer?.PlayerId;
			if (playerId.HasValue)
			{
				_pendingPlayerJoins.RemoveAll((PendingPlayerJoin x) => x.Player.PlayerId == playerId.Value);
			}
			NetworkedActivityPlayer networkedActivityPlayer = _players.FirstOrDefault((NetworkedActivityPlayer x) => x.Player == e.Player);
			if (networkedActivityPlayer != null)
			{
				RemovePlayerFromActivity(networkedActivityPlayer);
			}
		}

		private void OnPlayerAircraftLoadCompleted(object sender, FlightScenePlayerAircraftLoadCompletedEventArgs e)
		{
			NetworkedActivityPlayer player = GetPlayer(e.Player);
			if (player == null)
			{
				Debug.LogError("Activity '" + Data.DisplayName + "' received a 'AircraftLoadCompleted' event for a player that is not currently part of the activity");
				return;
			}
			if (e.Player.IsLocal && CraftsStartPaused && (State == NetworkedActivityState.Starting || State == NetworkedActivityState.Started))
			{
				e.Player.CurrentOrPreviousAircraft?.CraftUpdate.SetCraftPausedState(!StartCountdownComplete);
			}
			OnPlayerAircraftLoadCompleted(player, e.Aircraft);
			this.PlayerAircraftLoadCompleted?.Invoke(this, new NetworkedActivityPlayerAircraftEventArgs(this, player, e.Aircraft));
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			NetworkedActivityPlayer player = GetPlayer(e.Player);
			if (player == null)
			{
				Debug.LogError("Activity '" + Data.DisplayName + "' received a 'PlayerEnteredAircraft' event for a player that is not currently part of the activity");
				return;
			}
			OnPlayerEnteredAircraft(player, e.Aircraft);
			this.PlayerExitedAircraft?.Invoke(this, new NetworkedActivityPlayerAircraftEventArgs(this, player, e.Aircraft));
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			NetworkedActivityPlayer player = GetPlayer(e.Player);
			if (player == null)
			{
				Debug.LogError("Activity '" + Data.DisplayName + "' received a 'PlayerExitedAircraft' event for a player that is not currently part of the activity");
				return;
			}
			OnPlayerExitedAircraft(player, e.Aircraft);
			this.PlayerEnteredAircraft?.Invoke(this, new NetworkedActivityPlayerAircraftEventArgs(this, player, e.Aircraft));
		}

		private void OnSettingChanged(object sender, NetworkedActivitySettingEventArgs e)
		{
			OnSettingChanged(e.Setting);
		}

		[ObserversRpc]
		private void OnTimerChangedClientRpc(int timerValue)
		{
			RpcWriter___Observers_OnTimerChangedClientRpc___3316948804(timerValue);
		}

		private async UniTaskVoid PlayerCraftBoundsRequestAsync(int requestId, PlayerCraftBoundsRequest request)
		{
			NetworkedActivityPlayer player = GetPlayer(request.PlayerId);
			if (player == null)
			{
				string text = $"Unable to request craft bounds for player '{request.PlayerId}' in networked activity '{Data.DisplayName}' because a player with that id could not be found.";
				Debug.LogError(text);
				_playerCraftBoundsRequest.SendResult(requestId, new CraftBoundsAsyncResult(text));
				return;
			}
			try
			{
				if (player.Player.IsLoadingCraft && !(await UniTaskEx.WaitUntilWithTimeout(() => !player.Player.IsLoadingCraft, 10000)))
				{
					_playerCraftBoundsRequest.SendResult(requestId, new CraftBoundsAsyncResult("Unable to determine the craft bounds because the craft load has not completed yet."));
					return;
				}
				CraftLocalBounds? craftBounds = GetCraftBounds(player, request.InitialBounds);
				if (!craftBounds.HasValue)
				{
					_playerCraftBoundsRequest.SendResult(requestId, new CraftBoundsAsyncResult("Unable to determine the craft bounds because the craft is not loaded."));
				}
				else
				{
					_playerCraftBoundsRequest.SendResult(requestId, new CraftBoundsAsyncResult(craftBounds.Value));
				}
			}
			catch (Exception exception)
			{
				string text2 = $"An exception occurred trying to get the craft bounds for player '{player.Name}' (id: {player.PlayerId}) in networked activity '{Data?.DisplayName}'.";
				Debug.LogError(text2);
				Debug.LogException(exception);
				_playerCraftBoundsRequest.SendResult(requestId, new CraftBoundsAsyncResult(text2));
			}
		}

		[TargetRpc]
		private void PlayerCraftBoundsRequestRpc(NetworkConnection client, int requestId, PlayerCraftBoundsRequest request)
		{
			RpcWriter___Target_PlayerCraftBoundsRequestRpc___2910544794(client, requestId, request);
		}

		[ServerRpc(RequireOwnership = false)]
		private void PlayerCraftBoundsResultRpc(int requestId, CraftBoundsAsyncResult result, NetworkConnection client)
		{
			RpcWriter___Server_PlayerCraftBoundsResultRpc___1346278651(requestId, result, client);
		}

		private void ProcessLatePlayerJoins()
		{
			List<NetworkedActivityPlayer> list = null;
			foreach (NetworkedActivityPlayer player in _players)
			{
				if (player.State == NetworkedActivityPlayerState.Ready && !_playersPendingStart.Contains(player))
				{
					if (list == null)
					{
						list = new List<NetworkedActivityPlayer>();
					}
					list.Add(player);
					_playersPendingStart.Add(player);
				}
			}
			if (list != null && list.Count > 0)
			{
				StartActivityForLateJoinPlayersAsync(list).Forget();
			}
		}

		private void ProcessPendingPlayerJoins()
		{
			for (int num = _pendingPlayerJoins.Count - 1; num >= 0; num--)
			{
				PendingPlayerJoin pendingPlayerJoin = _pendingPlayerJoins[num];
				FlightScenePlayer player = FlightSceneScript.Instance.GetPlayer(pendingPlayerJoin.Player.PlayerId);
				if (player != null)
				{
					pendingPlayerJoin.Player.OnPlayerLoaded(player);
					_pendingPlayerJoins.RemoveAt(num);
					AddPlayerToActivity(pendingPlayerJoin.Player);
					foreach (var score2 in pendingPlayerJoin.Scores)
					{
						NetworkedActivityScore score = pendingPlayerJoin.Player.GetScore(score2.Id);
						if (score == null)
						{
							Debug.LogError("Unable to find score '" + score.Id + "' on player '" + player.Name + "' when processing a pending player join.");
						}
						else
						{
							using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = this.GetPooledReader(score2.Value);
							score.ReadValue((PooledReader)pooledReaderDisposableWrapper);
						}
					}
					if (pendingPlayerJoin.Team != NetworkedActivityTeamIds.None)
					{
						NetworkedActivityTeam team = GetTeam(pendingPlayerJoin.Team);
						if (team != null)
						{
							AddPlayerToTeam(pendingPlayerJoin.Player, team);
						}
					}
					SetPlayerState(pendingPlayerJoin.Player, pendingPlayerJoin.State);
				}
			}
		}

		private void RaiseActivityEvent(EventHandler<NetworkedActivityEventArgs> eventHandler)
		{
			try
			{
				eventHandler?.Invoke(this, new NetworkedActivityEventArgs(this));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private InitialStartLocation RegisterPlayerWithInitialStartLocation(NetworkedActivityPlayer player, CraftLocalBounds bounds)
		{
			NetworkedActivityTeamIds id = player.Team.Id;
			int count = _initialStartLocations[id].Count;
			if (count > 0)
			{
				int index = _startLocationsNextIndex[id];
				_startLocationsNextIndex[id] = (_startLocationsNextIndex[id] + 1) % count;
				InitialStartLocation initialStartLocation = _initialStartLocations[id][index];
				initialStartLocation.AddPlayer(player, bounds, (int)State >= 4);
				return initialStartLocation;
			}
			return null;
		}

		private void RemovePlayerFromActivity(NetworkedActivityPlayer player)
		{
			if (player.State == NetworkedActivityPlayerState.Playing)
			{
				SetPlayerState(player, NetworkedActivityPlayerState.Ending);
				SetPlayerState(player, NetworkedActivityPlayerState.Ended);
			}
			if (!_players.Remove(player))
			{
				Debug.LogError($"The player '{player.PlayerId}' was not found in the activity's list of players when removing the player from the activity '{Data.DisplayName}'.");
			}
			RemovePlayerFromTeam(player);
			bool flag = ActivityHost == player;
			if (flag)
			{
				ActivityHost = null;
			}
			if (player.Owner == base.LocalConnection)
			{
				player.Player?.CurrentOrPreviousAircraft?.CraftUpdate.SetCraftPausedState(paused: false);
			}
			IsLocalClientParticipating = _players.Any((NetworkedActivityPlayer x) => x.Owner == base.LocalConnection);
			if (LocalPlayer == player)
			{
				LocalPlayer = null;
			}
			player.Player.AircraftEntered -= OnPlayerEnteredAircraft;
			player.Player.AircraftExited -= OnPlayerExitedAircraft;
			player.Player.AircraftLoadCompleted -= OnPlayerAircraftLoadCompleted;
			try
			{
				OnPlayerLeft(player);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				player.OnActivityLeft();
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			try
			{
				this.PlayerLeft?.Invoke(this, new NetworkedActivityPlayerEventArgs(this, player));
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
			}
			if (_manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.PlayersChanged))
			{
				Debug.Log($"Player '{player.Name}' (id: {player.PlayerId}) left networked activity '{Data.DisplayName}'.");
			}
			if (!base.IsServerStarted)
			{
				return;
			}
			if (flag)
			{
				if (State == NetworkedActivityState.Started)
				{
					EndActivity();
				}
				else
				{
					DespawnActivity();
				}
			}
			else if (_players.Count == 0)
			{
				DespawnActivity();
			}
		}

		private void RemovePlayerFromTeam(NetworkedActivityPlayer player)
		{
			NetworkedActivityTeam team = player.Team;
			if (team != null && team.Id != NetworkedActivityTeamIds.None)
			{
				try
				{
					team.RemovePlayer(player);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				try
				{
					OnTeamLeft(player, team);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
				try
				{
					this.TeamLeft?.Invoke(this, new NetworkedActivityPlayerTeamEventArgs(this, player, team));
				}
				catch (Exception exception3)
				{
					Debug.LogException(exception3);
				}
				if (_manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.PlayerTeamChanged))
				{
					Debug.Log($"Player '{player.Name}' (id: {player.PlayerId}) left team '{team.Name}' (id: {team.Id}) of networked activity '{Data.DisplayName}'.");
				}
			}
		}

		private void SetActivityState(NetworkedActivityState state)
		{
			NetworkedActivityState state2 = State;
			if (state2 == state)
			{
				return;
			}
			State = state;
			try
			{
				OnStateChanged(state2, state);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				this.StateChanged?.Invoke(this, new NetworkedActivityStateChangedEventArgs(this, state));
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			try
			{
				_manager.OnActivityStateChanged(this, state);
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
			}
			if (_manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.StateChanged))
			{
				Debug.Log($"Networked Activity State Change: {Data?.DisplayName ?? GetType().FullName}: {state}");
			}
			try
			{
				switch (state)
				{
				case NetworkedActivityState.Starting:
					if (base.IsServerStarted)
					{
						OnActivityStartingServer();
						if (!Data.AllowPeacefulMode && FlightSceneScript.IsPeacefulMode)
						{
							FlightSceneScript.IsPeacefulMode = false;
							FlightSceneScript.Instance.FlightUI.ShowMessage("Peaceful mode been disabled");
						}
					}
					OnActivityStartingClient();
					RaiseActivityEvent(this.ActivityStarting);
					break;
				case NetworkedActivityState.Started:
					if (base.IsServerStarted)
					{
						OnActivityStartedServer();
					}
					OnActivityStartedClient();
					RaiseActivityEvent(this.ActivityStarted);
					break;
				case NetworkedActivityState.Ending:
					if (base.IsServerStarted)
					{
						OnActivityEndingServer();
					}
					OnActivityEndingClient();
					RaiseActivityEvent(this.ActivityEnding);
					break;
				case NetworkedActivityState.Ended:
					if (base.IsServerStarted)
					{
						OnActivityEndedServer();
					}
					OnActivityEndedClient();
					RaiseActivityEvent(this.ActivityEnded);
					break;
				}
			}
			catch (Exception exception4)
			{
				Debug.LogException(exception4);
			}
		}

		private void SetPlayerState(NetworkedActivityPlayer player, NetworkedActivityPlayerState state)
		{
			NetworkedActivityPlayerState state2 = player.State;
			if (state2 == state)
			{
				return;
			}
			try
			{
				player.OnStateChanged(state);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				OnPlayerStateChanged(player, state2, state);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			try
			{
				this.PlayerStateChanged?.Invoke(this, new NetworkedActivityPlayerStateChangedEventArgs(this, player, state2, state));
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
			}
			if (_manager.DebugLogFlags.HasFlag(NetworkedActivityDebugLogFlags.PlayerStateChanged))
			{
				Debug.Log($"Player '{player.Name}' (id: {player.PlayerId}) state changed '{state2}' -> '{state}' in networked activity '{Data.DisplayName}'.");
			}
			try
			{
				switch (state)
				{
				case NetworkedActivityPlayerState.Starting:
					OnPlayerStarting(player);
					if (player.Owner.IsLocalClient)
					{
						OnLocalPlayerStarting(player);
					}
					break;
				case NetworkedActivityPlayerState.Playing:
					OnPlayerStarted(player);
					if (player.Owner.IsLocalClient)
					{
						OnLocalPlayerStarted(player);
					}
					break;
				case NetworkedActivityPlayerState.Ending:
					OnPlayerEnding(player);
					if (player.Owner.IsLocalClient)
					{
						OnLocalPlayerEnding(player);
					}
					break;
				case NetworkedActivityPlayerState.Ended:
					OnPlayerEnded(player);
					if (player.Owner.IsLocalClient)
					{
						OnLocalPlayerEnded(player);
					}
					break;
				}
			}
			catch (Exception exception4)
			{
				Debug.LogException(exception4);
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void SpawnLocationRequestRpc(int requestId, SpawnLocationRequest request, NetworkConnection client = null)
		{
			RpcWriter___Server_SpawnLocationRequestRpc___140730828(requestId, request, client);
		}

		[TargetRpc]
		private void SpawnLocationResultRpc(NetworkConnection client, int requestId, SpawnLocationAsyncResult result)
		{
			RpcWriter___Target_SpawnLocationResultRpc___3383668902(client, requestId, result);
		}

		private async UniTaskVoid StartActivityAsync()
		{
			_ = 2;
			try
			{
				if ((int)State >= 3)
				{
					Debug.LogError("Unable to start activity '" + Data.DisplayName + "' because it has already been started.");
				}
				ChangeActivityStateClientRpc(NetworkedActivityState.Starting);
				List<NetworkedActivityPlayer> initialPlayers = _players.Where((NetworkedActivityPlayer x) => x.State == NetworkedActivityPlayerState.Ready).ToList();
				CreateInitialPlayerStartLocations(await StartActivityGetCraftBounds(initialPlayers));
				await StartActivityForEachPlayer(initialPlayers);
				await StartActivityWaitForPlayers(initialPlayers);
				ChangeActivityStateClientRpc(NetworkedActivityState.Started);
			}
			catch (Exception exception)
			{
				Debug.LogError("An exception occurred trying to start networked activity '" + Data?.DisplayName + "'.");
				Debug.LogException(exception);
			}
		}

		private async UniTask StartActivityForEachPlayer(List<NetworkedActivityPlayer> players)
		{
			UniTask<AsyncNetworkRequest<StartActivityForPlayerRequest, AsyncResult>.Result>[] array = _startActivityForPlayerRequest.CreateResultArray(players.Count);
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = _startActivityForPlayerRequest.SendRequest(new StartActivityForPlayerRequest(players[i].PlayerId), players[i].Owner);
			}
			AsyncNetworkRequest<StartActivityForPlayerRequest, AsyncResult>.Result[] array2 = await UniTask.WhenAll(array);
			List<NetworkedActivityPlayer> list = new List<NetworkedActivityPlayer>(0);
			for (int j = 0; j < array2.Length; j++)
			{
				AsyncResult asyncResult = (array2[j].TimedOut ? AsyncResult.Failure("Request timed out") : array2[j].ResultData);
				if (!asyncResult.IsSuccess)
				{
					if (j >= players.Count)
					{
						Debug.LogError("Received more player activity start results than the number of requested players.");
						continue;
					}
					NetworkedActivityPlayer networkedActivityPlayer = players[j];
					Debug.LogError($"Starting activity for player '{networkedActivityPlayer.Name}' (id: {networkedActivityPlayer.PlayerId}) failed with error: {asyncResult.Message}");
					list.Add(networkedActivityPlayer);
				}
			}
			foreach (NetworkedActivityPlayer item in list)
			{
				players.Remove(item);
			}
		}

		private async UniTaskVoid StartActivityForLateJoinPlayersAsync(List<NetworkedActivityPlayer> players)
		{
			List<NetworkedActivityPlayer> playersNotStarted;
			using (CollectionPool<List<NetworkedActivityPlayer>, NetworkedActivityPlayer>.Get(out playersNotStarted))
			{
				playersNotStarted.AddRange(players);
				CreateInitialPlayerStartLocations(await StartActivityGetCraftBounds(players));
				await StartActivityForEachPlayer(players);
				foreach (NetworkedActivityPlayer player in players)
				{
					_playersPendingStart.Remove(player);
					playersNotStarted.Remove(player);
				}
				if (playersNotStarted.Count == 0)
				{
					return;
				}
				await UniTask.Delay(1000);
				foreach (NetworkedActivityPlayer item in playersNotStarted)
				{
					_playersPendingStart.Remove(item);
				}
			}
		}

		private async UniTaskVoid StartActivityForLocalPlayerAsync(int requestId, StartActivityForPlayerRequest request)
		{
			NetworkedActivityPlayer player = GetPlayer(request.PlayerId);
			if (player == null)
			{
				string message = $"Unable to start networked activity '{Data.DisplayName}' for player '{request.PlayerId}' because a player with that id could not be found.";
				Debug.LogError(message);
				_startActivityForPlayerRequest.SendResult(requestId, AsyncResult.Failure(message));
				return;
			}
			try
			{
				AsyncResult resultData = await StartActivityForLocalPlayerAsync(player);
				_startActivityForPlayerRequest.SendResult(requestId, resultData);
			}
			catch (Exception exception)
			{
				string message2 = $"An exception occurred trying to start networked activity '{Data?.DisplayName}' for player '{player.Name}' (id: {player.PlayerId}).";
				Debug.LogError(message2);
				Debug.LogException(exception);
				_startActivityForPlayerRequest.SendResult(requestId, AsyncResult.Failure(message2));
			}
		}

		private async UniTask<AsyncResult> StartActivityForLocalPlayerAsync(NetworkedActivityPlayer player)
		{
			SetPlayerState(player, NetworkedActivityPlayerState.Starting);
			AsyncResult asyncResult = await ChangePlayerState(player, NetworkedActivityPlayerState.Starting, excludeOwner: true);
			if (!asyncResult.IsSuccess)
			{
				Debug.LogError("An error occurred changing state for player '" + player.Name + "'. Error: " + asyncResult.Message);
			}
			CraftLocalBounds? craftBounds = GetCraftBounds(player, initialBounds: true);
			AsyncNetworkRequest<SpawnLocationRequest, SpawnLocationAsyncResult>.Result result = await _spawnLocationRequest.SendRequest(new SpawnLocationRequest(player.PlayerId, initialSpawn: true, craftBounds));
			SpawnLocationAsyncResult spawnLocationAsyncResult = (result.TimedOut ? new SpawnLocationAsyncResult("The request timed out") : result.ResultData);
			if (!spawnLocationAsyncResult.IsSuccess)
			{
				Debug.LogError("Failed to get a spawn location from the server. Error: " + spawnLocationAsyncResult.Message);
			}
			if (spawnLocationAsyncResult.Data != null)
			{
				if (player.Player.Aircraft == null)
				{
					player.Player.EnterPreviousAircraft();
				}
				StartLocationData data = spawnLocationAsyncResult.Data;
				if (player.Player.Aircraft != null && string.IsNullOrEmpty(data.DynamicLocationId))
				{
					AircraftScript aircraft = player.Player.Aircraft;
					PositionUtility.TeleportPlayer(new StartLocation(data));
					aircraft.CraftUpdate.SetCraftPausedState(CraftsStartPaused && !StartCountdownComplete);
				}
				else
				{
					player.Player.StartLocation = spawnLocationAsyncResult.Data;
					player.Player.SpawnAircraft(CraftsStartPaused && !StartCountdownComplete);
					await UniTaskEx.WaitUntilWithTimeout(() => !player.Player.IsLoadingCraft, 15000);
					if (CraftsStartPaused && StartCountdownComplete)
					{
						player.Player?.CurrentOrPreviousAircraft?.CraftUpdate.SetCraftPausedState(paused: false);
					}
				}
			}
			await PerformLocalPlayerStartingActivityTasks(player);
			PauseManager.RequestPauseChange(paused: false, userInitiated: false);
			SetPlayerState(player, NetworkedActivityPlayerState.Playing);
			asyncResult = await ChangePlayerState(player, NetworkedActivityPlayerState.Playing, excludeOwner: true);
			if (!asyncResult.IsSuccess)
			{
				Debug.LogError("An error occurred changing state for player '" + player.Name + "'. Error: " + asyncResult.Message);
			}
			return AsyncResult.Success();
		}

		[TargetRpc]
		private void StartActivityForPlayerClientRpc(NetworkConnection client, int requestId, StartActivityForPlayerRequest request)
		{
			RpcWriter___Target_StartActivityForPlayerClientRpc___2476147485(client, requestId, request);
		}

		[ServerRpc(RequireOwnership = false)]
		private void StartActivityForPlayerResultRpc(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			RpcWriter___Server_StartActivityForPlayerResultRpc___2038029376(requestId, result, client);
		}

		private async UniTask<List<(NetworkedActivityPlayer Player, CraftLocalBounds Bounds)>> StartActivityGetCraftBounds(List<NetworkedActivityPlayer> players)
		{
			UniTask<AsyncNetworkRequest<PlayerCraftBoundsRequest, CraftBoundsAsyncResult>.Result>[] array = _playerCraftBoundsRequest.CreateResultArray(players.Count);
			for (int i = 0; i < players.Count; i++)
			{
				array[i] = _playerCraftBoundsRequest.SendRequest(new PlayerCraftBoundsRequest(players[i].PlayerId, initialBounds: true), players[i].Owner);
			}
			AsyncNetworkRequest<PlayerCraftBoundsRequest, CraftBoundsAsyncResult>.Result[] array2 = await UniTask.WhenAll(array);
			List<(NetworkedActivityPlayer, CraftLocalBounds)> list = new List<(NetworkedActivityPlayer, CraftLocalBounds)>(players.Count);
			List<NetworkedActivityPlayer> list2 = new List<NetworkedActivityPlayer>(0);
			for (int j = 0; j < array2.Length; j++)
			{
				CraftBoundsAsyncResult craftBoundsAsyncResult = (array2[j].TimedOut ? new CraftBoundsAsyncResult("Request timed out") : array2[j].ResultData);
				if (!craftBoundsAsyncResult.IsSuccess)
				{
					if (j >= players.Count)
					{
						Debug.LogError("Received more player activity start results than the number of requested players.");
						continue;
					}
					NetworkedActivityPlayer networkedActivityPlayer = players[j];
					Debug.LogError($"Starting activity for player '{networkedActivityPlayer.Name}' (id: {networkedActivityPlayer.PlayerId}) failed with error: {craftBoundsAsyncResult.Message}");
					list2.Add(networkedActivityPlayer);
				}
				else
				{
					list.Add((players[j], craftBoundsAsyncResult.Data.Value));
				}
			}
			foreach (NetworkedActivityPlayer item in list2)
			{
				players.Remove(item);
			}
			return list;
		}

		[ServerRpc(RequireOwnership = false)]
		private void StartActivityServerRpc()
		{
			RpcWriter___Server_StartActivityServerRpc___2166136261();
		}

		private async UniTask StartActivityWaitForPlayers(List<NetworkedActivityPlayer> initialPlayers)
		{
			List<NetworkConnection> clients = new List<NetworkConnection>(initialPlayers.Count);
			int[] array = new int[initialPlayers.Count];
			for (int i = 0; i < initialPlayers.Count; i++)
			{
				NetworkedActivityPlayer networkedActivityPlayer = initialPlayers[i];
				array[i] = networkedActivityPlayer.PlayerId;
				if (!clients.Contains(networkedActivityPlayer.Owner))
				{
					clients.Add(networkedActivityPlayer.Owner);
				}
			}
			WaitForAllPlayersStartedRequest data = new WaitForAllPlayersStartedRequest(array);
			UniTask<AsyncNetworkRequest<WaitForAllPlayersStartedRequest, AsyncResult>.Result>[] array2 = _waitForAllPlayersStartedRequest.CreateResultArray(clients.Count);
			for (int j = 0; j < clients.Count; j++)
			{
				array2[j] = _waitForAllPlayersStartedRequest.SendRequest(data, clients[j]);
			}
			AsyncNetworkRequest<WaitForAllPlayersStartedRequest, AsyncResult>.Result[] array3 = await UniTask.WhenAll(array2);
			for (int k = 0; k < array3.Length; k++)
			{
				AsyncResult asyncResult = (array3[k].TimedOut ? AsyncResult.Failure("Request timed out") : array3[k].ResultData);
				if (!asyncResult.IsSuccess)
				{
					if (k >= clients.Count)
					{
						Debug.LogError("Received more player wait results than the number of clients.");
						continue;
					}
					NetworkConnection networkConnection = clients[k];
					Debug.LogError($"Waiting for players to start activity on client '{networkConnection.ClientId}' failed with error: {asyncResult.Message}");
				}
			}
		}

		[ServerRpc]
		private void StartTimerServerRpc(int initialTimerValue, ActivityTimerType timerType)
		{
			RpcWriter___Server_StartTimerServerRpc___584859910(initialTimerValue, timerType);
		}

		[ObserversRpc]
		private void StopTimerClientRpc()
		{
			RpcWriter___Observers_StopTimerClientRpc___2166136261();
		}

		[ServerRpc(RequireOwnership = false)]
		private void StopTimerServerRpc()
		{
			RpcWriter___Server_StopTimerServerRpc___2166136261();
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void SyncSettingsClientRpc(ArraySegment<byte> data)
		{
			RpcWriter___Observers_SyncSettingsClientRpc___415360332(data);
		}

		[ServerRpc]
		private void SyncSettingsServerRpc(ArraySegment<byte> data)
		{
			RpcWriter___Server_SyncSettingsServerRpc___415360332(data);
		}

		private void UnsubcribeFromPostTicks()
		{
			TimeManager timeManager = base.TimeManager;
			if (base.IsServerStarted && timeManager != null)
			{
				timeManager.OnPostTick -= OnPostTickServer;
			}
			if (IsActivityHost && timeManager != null)
			{
				timeManager.OnPostTick -= OnPostTickHost;
			}
			if (timeManager != null)
			{
				timeManager.OnPostTick -= OnPostTickClient;
			}
		}

		private void UpdateTimerServer(float deltaTime)
		{
			if (_timerEnabledServer)
			{
				_timerValueServer += ((_timerType == ActivityTimerType.CountUp) ? deltaTime : (0f - deltaTime));
				int num = ((_timerValueServer < 0f) ? Mathf.FloorToInt(_timerValueServer) : ((int)_timerValueServer));
				if (_timerValueClient != num)
				{
					_timerValueClient = num;
					OnTimerChangedClientRpc(num);
				}
			}
		}

		private async UniTaskVoid WaitForAllPlayersEndedAsync(int requestId, WaitForAllPlayersEndedRequest request)
		{
			try
			{
				UniTask<bool>[] array = new UniTask<bool>[request.PlayerIds.Length];
				for (int i = 0; i < request.PlayerIds.Length; i++)
				{
					NetworkedActivityPlayer player = GetPlayer(request.PlayerIds[i]);
					if (player == null)
					{
						Debug.LogError($"Unable to wait for player '{request.PlayerIds[i]}' of networked activity '{Data.DisplayName}' " + "to end the activity because a player with that id could not be found.");
						array[i] = UniTask.FromResult(value: false);
					}
					else
					{
						array[i] = UniTaskEx.WaitUntilWithTimeout(() => player.State == NetworkedActivityPlayerState.Ended, 10000);
					}
				}
				AsyncResult resultData = ((await UniTask.WhenAll(array)).All((bool x) => x) ? AsyncResult.Success() : AsyncResult.Failure($"Not all players have ended activity on client '{base.LocalConnection.ClientId}'"));
				_waitForAllPlayersEndedRequest.SendResult(requestId, resultData);
			}
			catch (Exception exception)
			{
				string message = "An exception occurred trying to wait for all players to end networked activity '" + Data?.DisplayName + "'.";
				Debug.LogError(message);
				Debug.LogException(exception);
				_waitForAllPlayersEndedRequest.SendResult(requestId, AsyncResult.Failure(message));
			}
		}

		[TargetRpc]
		private void WaitForAllPlayersEndedClientRpc(NetworkConnection client, int requestId, WaitForAllPlayersEndedRequest request)
		{
			RpcWriter___Target_WaitForAllPlayersEndedClientRpc___3093775645(client, requestId, request);
		}

		[ServerRpc(RequireOwnership = false)]
		private void WaitForAllPlayersEndedResultRpc(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			RpcWriter___Server_WaitForAllPlayersEndedResultRpc___2038029376(requestId, result, client);
		}

		private async UniTaskVoid WaitForAllPlayersStartedAsync(int requestId, WaitForAllPlayersStartedRequest request)
		{
			try
			{
				UniTask<bool>[] array = new UniTask<bool>[request.PlayerIds.Length];
				for (int i = 0; i < request.PlayerIds.Length; i++)
				{
					NetworkedActivityPlayer player = GetPlayer(request.PlayerIds[i]);
					if (player == null)
					{
						Debug.LogError($"Unable to wait for player '{request.PlayerIds[i]}' of networked activity '{Data.DisplayName}' " + "to start the activity because a player with that id could not be found.");
						array[i] = UniTask.FromResult(value: false);
					}
					else
					{
						array[i] = UniTaskEx.WaitUntilWithTimeout(() => player.State == NetworkedActivityPlayerState.Playing && !player.Player.IsLoadingCraft, 10000);
					}
				}
				AsyncResult resultData = ((await UniTask.WhenAll(array)).All((bool x) => x) ? AsyncResult.Success() : AsyncResult.Failure($"Not all players have started activity on client '{base.LocalConnection.ClientId}'"));
				_waitForAllPlayersStartedRequest.SendResult(requestId, resultData);
			}
			catch (Exception exception)
			{
				string message = "An exception occurred trying to wait for all players to start networked activity '" + Data?.DisplayName + "'.";
				Debug.LogError(message);
				Debug.LogException(exception);
				_waitForAllPlayersStartedRequest.SendResult(requestId, AsyncResult.Failure(message));
			}
		}

		[TargetRpc]
		private void WaitForAllPlayersStartedClientRpc(NetworkConnection client, int requestId, WaitForAllPlayersStartedRequest request)
		{
			RpcWriter___Target_WaitForAllPlayersStartedClientRpc___3850372160(client, requestId, request);
		}

		[ServerRpc(RequireOwnership = false)]
		private void WaitForAllPlayersStartedResultRpc(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			RpcWriter___Server_WaitForAllPlayersStartedResultRpc___2038029376(requestId, result, client);
		}

		public virtual void CreateScoreSummaryWidget(ScoreSummaryScript scoreSummary)
		{
			scoreSummary.CreateScoreColumn("left", "score-left");
			scoreSummary.CreateScoreColumn("right", "score-right");
		}

		public virtual FinalScoreSummary GenerateFinalScoreSummary()
		{
			FinalScoreSummary finalScoreSummary = new FinalScoreSummary();
			bool flag = false;
			if (PlayerFinishedActivity && Data.Settings.IsDefault)
			{
				float valueFloat = LocalPlayer.GetScore().ValueFloat;
				float? activityScore = Game.Instance.Settings.Cloud.Activities.GetActivityScore(Data.Id);
				if (valueFloat > 0f && (!activityScore.HasValue || Data.ScoreTiers.CompareScores(valueFloat, activityScore.Value) > 0))
				{
					Game.Instance.Settings.Cloud.Activities.SetActivityScore(Data.Id, valueFloat);
					Game.Instance.Settings.Cloud.Save();
					flag = true;
				}
			}
			string playerScoreString = GetPlayerScoreString(LocalPlayer);
			List<NetworkedActivityPlayer> list = SortPlayerListByScore(Players).ToList();
			if (list.Count >= 2)
			{
				finalScoreSummary.ShowCelebrationStyle = list.FirstOrDefault() == LocalPlayer;
				finalScoreSummary.Message = (finalScoreSummary.ShowCelebrationStyle ? "YOU WIN!" : "THAT'S ALL FOLKS");
				if (CompareScores(list[0], list[1]) == 0 && PlayerFinishedActivity)
				{
					finalScoreSummary.ShowCelebrationStyle = false;
					finalScoreSummary.Message = "IT'S A TIE!";
				}
				else if (finalScoreSummary.ShowCelebrationStyle && PlayerFinishedActivity)
				{
					finalScoreSummary.Message = "YOU WIN!";
				}
				else
				{
					NetworkedActivityPlayer networkedActivityPlayer = list[0];
					finalScoreSummary.Message = networkedActivityPlayer.Name + " WINS!";
				}
				if (PlayerFinishedActivity)
				{
					finalScoreSummary.SubMessage = (flag ? "New Personal Best!\n" : "Your Score: ") + playerScoreString;
				}
			}
			else if (PlayerFinishedActivity)
			{
				finalScoreSummary.ShowCelebrationStyle = flag;
				finalScoreSummary.Message = (flag ? "New Personal Best!\n" : "Final Score: ") + playerScoreString;
			}
			return finalScoreSummary;
		}

		public virtual string GetPlayerScoreString(NetworkedActivityPlayer player)
		{
			return player.GetScore().ValueInt.ToString();
		}

		public List<NetworkedActivityPlayer> SortPlayerListByScore(IReadOnlyList<NetworkedActivityPlayer> players)
		{
			List<NetworkedActivityPlayer> list = players.ToList();
			list.Sort(CompareScoresReversed);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].LeaderboardPlaceNumber = i + 1;
			}
			return list;
		}

		public void UpdatePlayerScore(int playerId, string scoreId, int score, UpdateScoreType updateType = UpdateScoreType.Add)
		{
			UpdatePlayerScoreServerRpc(playerId, scoreId, score, updateType);
		}

		public void UpdatePlayerScore(int playerId, string scoreId, float score, UpdateScoreType updateType = UpdateScoreType.Add)
		{
			UpdatePlayerScoreServerRpc(playerId, scoreId, score, updateType);
		}

		public abstract void UpdateScoreSummaryWidget(ScoreSummaryScript scoreSummary);

		public void UpdateTeamScore(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, int score, UpdateScoreType updateType = UpdateScoreType.Add)
		{
			UpdateTeamScoreServerRpc(teamId, playerId, scoreId, score, updateType);
		}

		public void UpdateTeamScore(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, float score, UpdateScoreType updateType = UpdateScoreType.Add)
		{
			UpdateTeamScoreServerRpc(teamId, playerId, scoreId, score, updateType);
		}

		protected virtual int CompareScores(NetworkedActivityPlayer x, NetworkedActivityPlayer y)
		{
			int valueInt = x.GetScore().ValueInt;
			int valueInt2 = y.GetScore().ValueInt;
			if (valueInt != valueInt2)
			{
				if (valueInt <= valueInt2)
				{
					return -1;
				}
				return 1;
			}
			return 0;
		}

		protected int CompareScoresReversed(NetworkedActivityPlayer x, NetworkedActivityPlayer y)
		{
			return -CompareScores(x, y);
		}

		protected virtual IEnumerable<NetworkedActivityScore> CreateScoresForPlayer(NetworkedActivityPlayer player)
		{
			yield return new NetworkedActivityScore("Score", "Score", NetworkedActivityScore.ScoreValueType.Int);
		}

		protected virtual IEnumerable<NetworkedActivityScore> CreateScoresForTeam(NetworkedActivityTeam team)
		{
			yield return new NetworkedActivityScore("Score", "Score", NetworkedActivityScore.ScoreValueType.Int);
		}

		protected virtual void OnPlayerScoreChanged(NetworkedActivityPlayer player, NetworkedActivityScore score)
		{
		}

		protected virtual void OnTeamScoreChanged(NetworkedActivityTeam team, NetworkedActivityPlayer player, NetworkedActivityScore score)
		{
		}

		private bool GetPlayerScoreForUpdate(int playerId, string scoreId, out NetworkedActivityPlayer player, out NetworkedActivityScore score)
		{
			score = null;
			player = GetPlayer(playerId);
			if (player == null)
			{
				Debug.LogError($"Unable to find player '{playerId}' when attempting to update score '{scoreId}'");
				return false;
			}
			score = player.GetScore(scoreId);
			if (score == null)
			{
				Debug.LogError($"Unable to find score '{scoreId}' for player '{playerId}' when attempting to update score");
				return false;
			}
			return true;
		}

		private bool GetTeamScoreForUpdate(NetworkedActivityTeamIds teamId, string scoreId, out NetworkedActivityTeam team, out NetworkedActivityScore score)
		{
			score = null;
			team = GetTeam(teamId);
			if (team == null)
			{
				Debug.LogError($"Unable to find team '{teamId}' when attempting to update score '{scoreId}'");
				return false;
			}
			score = team.GetScore(scoreId);
			if (score == null)
			{
				Debug.LogError($"Unable to find score '{scoreId}' for team '{teamId}' when attempting to update score");
				return false;
			}
			return true;
		}

		[ContextMenu("Log Scores")]
		private void LogScores()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Activity Scores: " + Data.DisplayName);
			LogScores(Team1, stringBuilder);
			LogScores(Team2, stringBuilder);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			Debug.Log(stringBuilder);
			static void LogScores(NetworkedActivityTeam team, StringBuilder sb)
			{
				bool flag = team.Scores.Count > 0;
				bool flag2 = team.Players.Any((NetworkedActivityPlayer p) => p.Scores.Count > 0);
				if (flag || flag2)
				{
					sb.AppendLine("Team: " + team.Name);
					if (flag)
					{
						sb.AppendLine("  Team Scores:");
						foreach (NetworkedActivityScore score in team.Scores)
						{
							sb.AppendLine($"    Id: {score.Id}, Name: {score.DisplayName}, Value: {score.Value}");
						}
					}
					if (flag2)
					{
						sb.AppendLine("  Player Scores:");
						foreach (NetworkedActivityPlayer player in team.Players)
						{
							sb.AppendLine("    Player: " + player.Name);
							if (player.Scores.Count == 0)
							{
								sb.AppendLine("      (No Scores)");
							}
							else
							{
								foreach (NetworkedActivityScore score2 in player.Scores)
								{
									sb.AppendLine($"      Id: {score2.Id}, Name: {score2.DisplayName}, Value: {score2.Value}");
								}
							}
						}
					}
				}
			}
		}

		[ObserversRpc(RunLocally = true)]
		private void SetPlayerScoreClientRpc(int playerId, string scoreId, int scoreValue)
		{
			RpcWriter___Observers_SetPlayerScoreClientRpc___987676289(playerId, scoreId, scoreValue);
			RpcLogic___SetPlayerScoreClientRpc___987676289(playerId, scoreId, scoreValue);
		}

		[ObserversRpc(RunLocally = true)]
		private void SetPlayerScoreClientRpc(int playerId, string scoreId, float scoreValue)
		{
			RpcWriter___Observers_SetPlayerScoreClientRpc___2812360343(playerId, scoreId, scoreValue);
			RpcLogic___SetPlayerScoreClientRpc___2812360343(playerId, scoreId, scoreValue);
		}

		[ObserversRpc(RunLocally = true)]
		private void SetTeamScoreClientRpc(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, int scoreValue)
		{
			RpcWriter___Observers_SetTeamScoreClientRpc___1890589669(teamId, playerId, scoreId, scoreValue);
			RpcLogic___SetTeamScoreClientRpc___1890589669(teamId, playerId, scoreId, scoreValue);
		}

		[ObserversRpc(RunLocally = true)]
		private void SetTeamScoreClientRpc(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, float scoreValue)
		{
			RpcWriter___Observers_SetTeamScoreClientRpc___1446739795(teamId, playerId, scoreId, scoreValue);
			RpcLogic___SetTeamScoreClientRpc___1446739795(teamId, playerId, scoreId, scoreValue);
		}

		private void UpdatePlayerScore<T>(int playerId, string scoreId, T scoreValue, Func<NetworkedActivityScore, T> getScoreValue, Action<NetworkedActivityScore, T> setScoreValue) where T : IEquatable<T>
		{
			if (GetPlayerScoreForUpdate(playerId, scoreId, out var player, out var score) && !getScoreValue(score).Equals(scoreValue))
			{
				setScoreValue(score, scoreValue);
				OnPlayerScoreChanged(player, score);
				this.PlayerScoreChanged?.Invoke(this, new NetworkedActivityPlayerScoreEventArgs(this, player, score));
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void UpdatePlayerScoreServerRpc(int playerId, string scoreId, int scoreValue, UpdateScoreType updateType)
		{
			RpcWriter___Server_UpdatePlayerScoreServerRpc___3842514558(playerId, scoreId, scoreValue, updateType);
		}

		[ServerRpc(RequireOwnership = false)]
		private void UpdatePlayerScoreServerRpc(int playerId, string scoreId, float scoreValue, UpdateScoreType updateType)
		{
			RpcWriter___Server_UpdatePlayerScoreServerRpc___3140289600(playerId, scoreId, scoreValue, updateType);
		}

		private void UpdateTeamScore<T>(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, T scoreValue, Func<NetworkedActivityScore, T> getScoreValue, Action<NetworkedActivityScore, T> setScoreValue) where T : IEquatable<T>
		{
			if (GetTeamScoreForUpdate(teamId, scoreId, out var team, out var score) && !getScoreValue(score).Equals(scoreValue))
			{
				setScoreValue(score, scoreValue);
				NetworkedActivityPlayer player = ((!playerId.HasValue) ? null : GetPlayer(playerId.Value));
				OnTeamScoreChanged(team, player, score);
				this.TeamScoreChanged?.Invoke(this, new NetworkedActivityTeamScoreEventArgs(this, team, player, score));
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void UpdateTeamScoreServerRpc(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, int scoreValue, UpdateScoreType updateType)
		{
			RpcWriter___Server_UpdateTeamScoreServerRpc___1792888938(teamId, playerId, scoreId, scoreValue, updateType);
		}

		[ServerRpc(RequireOwnership = false)]
		private void UpdateTeamScoreServerRpc(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, float scoreValue, UpdateScoreType updateType)
		{
			RpcWriter___Server_UpdateTeamScoreServerRpc___1397896004(teamId, playerId, scoreId, scoreValue, updateType);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(0u, RpcReader___Observers_AICraftLoadedClientRpc___215635273);
				RegisterServerRpc(1u, RpcReader___Server_AICraftLoadedServerRpc___215635273);
				RegisterObserversRpc(2u, RpcReader___Observers_ChangeActivityStateClientRpc___2895260176);
				RegisterObserversRpc(3u, RpcReader___Observers_ChangePlayerStateClientRpc___938339791);
				RegisterServerRpc(4u, RpcReader___Server_ChangePlayerStateRequestRpc___1472219066);
				RegisterTargetRpc(5u, RpcReader___Target_ChangePlayerStateResultRpc___1617942072);
				RegisterTargetRpc(6u, RpcReader___Target_EndActivityForPlayerClientRpc___3489439314);
				RegisterServerRpc(7u, RpcReader___Server_EndActivityForPlayerResultRpc___2038029376);
				RegisterServerRpc(8u, RpcReader___Server_EndActivityServerRpc___2166136261);
				RegisterObserversRpc(9u, RpcReader___Observers_JoinActivityClientRpc___3316948804);
				RegisterServerRpc(10u, RpcReader___Server_JoinActivityRequestRpc___1737904189);
				RegisterTargetRpc(11u, RpcReader___Target_JoinActivityResultRpc___1617942072);
				RegisterObserversRpc(12u, RpcReader___Observers_JoinTeamClientRpc___839618763);
				RegisterServerRpc(13u, RpcReader___Server_JoinTeamRequestRpc___3842842145);
				RegisterTargetRpc(14u, RpcReader___Target_JoinTeamResultRpc___1617942072);
				RegisterObserversRpc(15u, RpcReader___Observers_LeaveActivityClientRpc___3316948804);
				RegisterServerRpc(16u, RpcReader___Server_LeaveActivityServerRpc___3316948804);
				RegisterObserversRpc(17u, RpcReader___Observers_OnTimerChangedClientRpc___3316948804);
				RegisterTargetRpc(18u, RpcReader___Target_PlayerCraftBoundsRequestRpc___2910544794);
				RegisterServerRpc(19u, RpcReader___Server_PlayerCraftBoundsResultRpc___1346278651);
				RegisterServerRpc(20u, RpcReader___Server_SpawnLocationRequestRpc___140730828);
				RegisterTargetRpc(21u, RpcReader___Target_SpawnLocationResultRpc___3383668902);
				RegisterTargetRpc(22u, RpcReader___Target_StartActivityForPlayerClientRpc___2476147485);
				RegisterServerRpc(23u, RpcReader___Server_StartActivityForPlayerResultRpc___2038029376);
				RegisterServerRpc(24u, RpcReader___Server_StartActivityServerRpc___2166136261);
				RegisterServerRpc(25u, RpcReader___Server_StartTimerServerRpc___584859910);
				RegisterObserversRpc(26u, RpcReader___Observers_StopTimerClientRpc___2166136261);
				RegisterServerRpc(27u, RpcReader___Server_StopTimerServerRpc___2166136261);
				RegisterObserversRpc(28u, RpcReader___Observers_SyncSettingsClientRpc___415360332);
				RegisterServerRpc(29u, RpcReader___Server_SyncSettingsServerRpc___415360332);
				RegisterTargetRpc(30u, RpcReader___Target_WaitForAllPlayersEndedClientRpc___3093775645);
				RegisterServerRpc(31u, RpcReader___Server_WaitForAllPlayersEndedResultRpc___2038029376);
				RegisterTargetRpc(32u, RpcReader___Target_WaitForAllPlayersStartedClientRpc___3850372160);
				RegisterServerRpc(33u, RpcReader___Server_WaitForAllPlayersStartedResultRpc___2038029376);
				RegisterObserversRpc(34u, RpcReader___Observers_SetPlayerScoreClientRpc___987676289);
				RegisterObserversRpc(35u, RpcReader___Observers_SetPlayerScoreClientRpc___2812360343);
				RegisterObserversRpc(36u, RpcReader___Observers_SetTeamScoreClientRpc___1890589669);
				RegisterObserversRpc(37u, RpcReader___Observers_SetTeamScoreClientRpc___1446739795);
				RegisterServerRpc(38u, RpcReader___Server_UpdatePlayerScoreServerRpc___3842514558);
				RegisterServerRpc(39u, RpcReader___Server_UpdatePlayerScoreServerRpc___3140289600);
				RegisterServerRpc(40u, RpcReader___Server_UpdateTeamScoreServerRpc___1792888938);
				RegisterServerRpc(41u, RpcReader___Server_UpdateTeamScoreServerRpc___1397896004);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Observers_AICraftLoadedClientRpc___215635273(NetworkAircraftScript craft)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerated(pooledWriter, craft);
			SendObserversRpc(0u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___AICraftLoadedClientRpc___215635273(NetworkAircraftScript P_0)
		{
			if (P_0 == null)
			{
				Debug.LogError("Received an AI craft loaded event but the craft was null");
			}
			else if (P_0.AircraftScript == null)
			{
				P_0.CraftLoaded += OnAICraftLoadCompleted;
				P_0.CraftLoadFailed += OnAICraftLoadCompleted;
			}
			else
			{
				OnAICraftLoadCompleted(P_0);
			}
		}

		private void RpcReader___Observers_AICraftLoadedClientRpc___215635273(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			NetworkAircraftScript networkAircraftScript = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___AICraftLoadedClientRpc___215635273(networkAircraftScript);
			}
		}

		private void RpcWriter___Server_AICraftLoadedServerRpc___215635273(NetworkAircraftScript craft)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerated(pooledWriter, craft);
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___AICraftLoadedServerRpc___215635273(NetworkAircraftScript P_0)
		{
			if (P_0 == null)
			{
				Debug.LogError("The server received an AI craft loaded event but the craft was null");
			}
			else
			{
				AICraftLoadedClientRpc(P_0);
			}
		}

		private void RpcReader___Server_AICraftLoadedServerRpc___215635273(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			NetworkAircraftScript networkAircraftScript = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___AICraftLoadedServerRpc___215635273(networkAircraftScript);
			}
		}

		private void RpcWriter___Observers_ChangeActivityStateClientRpc___2895260176(NetworkedActivityState state)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityStateFishNet_002ESerializing_002EGenerated(pooledWriter, state);
			SendObserversRpc(2u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangeActivityStateClientRpc___2895260176(NetworkedActivityState P_0)
		{
			SetActivityState(P_0);
		}

		private void RpcReader___Observers_ChangeActivityStateClientRpc___2895260176(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			NetworkedActivityState networkedActivityState = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityStateFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___ChangeActivityStateClientRpc___2895260176(networkedActivityState);
			}
		}

		private void RpcWriter___Observers_ChangePlayerStateClientRpc___938339791(int playerId, NetworkedActivityPlayerState state, bool excludeOwner)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerated(pooledWriter, state);
			pooledWriter.WriteBoolean(excludeOwner);
			SendObserversRpc(3u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangePlayerStateClientRpc___938339791(int P_0, NetworkedActivityPlayerState P_1, bool P_2)
		{
			NetworkedActivityPlayer player = GetPlayer(P_0);
			if (player == null)
			{
				Debug.LogError($"Unable to change the state of player '{P_0}' to state '{P_1}' in activity '{Data.DisplayName}' because a player with that id could not be found.");
			}
			else if (!P_2 || !player.Owner.IsLocalClient)
			{
				SetPlayerState(player, P_1);
			}
		}

		private void RpcReader___Observers_ChangePlayerStateClientRpc___938339791(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			NetworkedActivityPlayerState networkedActivityPlayerState = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerateds(PooledReader0);
			bool flag = PooledReader0.ReadBoolean();
			if (base.IsClientInitialized)
			{
				RpcLogic___ChangePlayerStateClientRpc___938339791(num, networkedActivityPlayerState, flag);
			}
		}

		private void RpcWriter___Server_ChangePlayerStateRequestRpc___1472219066(int requestId, ChangePlayerStateRequest request, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FChangePlayerStateRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendServerRpc(4u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangePlayerStateRequestRpc___1472219066(int P_0, ChangePlayerStateRequest P_1, NetworkConnection P_2)
		{
			EnsureClientInitialized();
			try
			{
				ChangePlayerStateClientRpc(P_1.PlayerId, P_1.State, P_1.ExcludeOwner);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_changePlayerStateRequest.SendResult(P_0, AsyncResult.UnexpectedError(1), P_2);
				return;
			}
			_changePlayerStateRequest.SendResult(P_0, AsyncResult.Success(), P_2);
		}

		private void RpcReader___Server_ChangePlayerStateRequestRpc___1472219066(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			ChangePlayerStateRequest changePlayerStateRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FChangePlayerStateRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___ChangePlayerStateRequestRpc___1472219066(num, changePlayerStateRequest, conn);
			}
		}

		private void RpcWriter___Target_ChangePlayerStateResultRpc___1617942072(NetworkConnection client, int requestId, AsyncResult result)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendTargetRpc(5u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ChangePlayerStateResultRpc___1617942072(NetworkConnection P_0, int P_1, AsyncResult P_2)
		{
			_changePlayerStateRequest.ReceiveResult(P_1, P_2);
		}

		private void RpcReader___Target_ChangePlayerStateResultRpc___1617942072(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___ChangePlayerStateResultRpc___1617942072(base.LocalConnection, num, asyncResult);
			}
		}

		private void RpcWriter___Target_EndActivityForPlayerClientRpc___3489439314(NetworkConnection client, int requestId, EndActivityForPlayerRequest request)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FEndActivityForPlayerRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendTargetRpc(6u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___EndActivityForPlayerClientRpc___3489439314(NetworkConnection P_0, int P_1, EndActivityForPlayerRequest P_2)
		{
			EndActivityForLocalPlayerAsync(P_1, P_2).Forget();
		}

		private void RpcReader___Target_EndActivityForPlayerClientRpc___3489439314(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			EndActivityForPlayerRequest endActivityForPlayerRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FEndActivityForPlayerRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___EndActivityForPlayerClientRpc___3489439314(base.LocalConnection, num, endActivityForPlayerRequest);
			}
		}

		private void RpcWriter___Server_EndActivityForPlayerResultRpc___2038029376(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendServerRpc(7u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___EndActivityForPlayerResultRpc___2038029376(int P_0, AsyncResult P_1, NetworkConnection P_2)
		{
			_endActivityForPlayerRequest.ReceiveResult(P_0, P_1);
		}

		private void RpcReader___Server_EndActivityForPlayerResultRpc___2038029376(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___EndActivityForPlayerResultRpc___2038029376(num, asyncResult, conn);
			}
		}

		private void RpcWriter___Server_EndActivityServerRpc___2166136261()
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(8u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___EndActivityServerRpc___2166136261()
		{
			EnsureClientInitialized();
			EndActivityAsync().Forget();
		}

		private void RpcReader___Server_EndActivityServerRpc___2166136261(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___EndActivityServerRpc___2166136261();
			}
		}

		private void RpcWriter___Observers_JoinActivityClientRpc___3316948804(int playerId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			SendObserversRpc(9u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___JoinActivityClientRpc___3316948804(int P_0)
		{
			NetworkedActivityPlayer activityPlayer = new NetworkedActivityPlayer(P_0);
			AddPlayerToActivity(activityPlayer);
		}

		private void RpcReader___Observers_JoinActivityClientRpc___3316948804(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___JoinActivityClientRpc___3316948804(num);
			}
		}

		private void RpcWriter___Server_JoinActivityRequestRpc___1737904189(int requestId, JoinActivityRequest request, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinActivityRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendServerRpc(10u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___JoinActivityRequestRpc___1737904189(int P_0, JoinActivityRequest P_1, NetworkConnection P_2)
		{
			EnsureClientInitialized();
			try
			{
				int playerId = P_1.PlayerId;
				FlightScenePlayer player = FlightSceneScript.Instance.GetPlayer(playerId);
				if (player == null)
				{
					Debug.LogError($"Unable to join activity '{Data.DisplayName}' with player '{playerId}' because a player with that id could not be found.");
					_joinActivityRequest.SendResult(P_0, AsyncResult.UnexpectedError(1), P_2);
					return;
				}
				if (!CanJoinActivity(player, out var joinDeniedReason))
				{
					_joinActivityRequest.SendResult(P_0, AsyncResult.Failure(joinDeniedReason), P_2);
					return;
				}
				if (player.NetworkedActivity != null)
				{
					if (player.NetworkedActivity == this)
					{
						Debug.LogError($"Player '{playerId}' attempted to join activity '{Data.DisplayName}' while already participating in the activity.");
						_joinActivityRequest.SendResult(P_0, AsyncResult.UnexpectedError(2), P_2);
						return;
					}
					player.NetworkedActivity.LeaveActivityClientRpc(playerId);
				}
				JoinActivityClientRpc(playerId);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_joinActivityRequest.SendResult(P_0, AsyncResult.UnexpectedError(3), P_2);
				return;
			}
			_joinActivityRequest.SendResult(P_0, AsyncResult.Success(), P_2);
		}

		private void RpcReader___Server_JoinActivityRequestRpc___1737904189(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			JoinActivityRequest joinActivityRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinActivityRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___JoinActivityRequestRpc___1737904189(num, joinActivityRequest, conn);
			}
		}

		private void RpcWriter___Target_JoinActivityResultRpc___1617942072(NetworkConnection client, int requestId, AsyncResult result)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendTargetRpc(11u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___JoinActivityResultRpc___1617942072(NetworkConnection P_0, int P_1, AsyncResult P_2)
		{
			_joinActivityRequest.ReceiveResult(P_1, P_2);
		}

		private void RpcReader___Target_JoinActivityResultRpc___1617942072(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___JoinActivityResultRpc___1617942072(base.LocalConnection, num, asyncResult);
			}
		}

		private void RpcWriter___Observers_JoinTeamClientRpc___839618763(int playerId, NetworkedActivityTeamIds teamId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(pooledWriter, teamId);
			SendObserversRpc(12u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___JoinTeamClientRpc___839618763(int P_0, NetworkedActivityTeamIds P_1)
		{
			NetworkedActivityPlayer player = GetPlayer(P_0);
			if (player == null)
			{
				Debug.LogError($"Unable to add player '{P_0}' to team '{P_1}' of activity '{Data.DisplayName}' because a player with that id could not be found.");
				return;
			}
			NetworkedActivityTeam team = GetTeam(P_1);
			if (team == null)
			{
				Debug.LogError($"Unable to add player '{P_0}' to team '{P_1}' of activity '{Data.DisplayName}' because a team with that id could not be found.");
			}
			else
			{
				AddPlayerToTeam(player, team);
			}
		}

		private void RpcReader___Observers_JoinTeamClientRpc___839618763(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			NetworkedActivityTeamIds networkedActivityTeamIds = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___JoinTeamClientRpc___839618763(num, networkedActivityTeamIds);
			}
		}

		private void RpcWriter___Server_JoinTeamRequestRpc___3842842145(int requestId, JoinTeamRequest request, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinTeamRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendServerRpc(13u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___JoinTeamRequestRpc___3842842145(int P_0, JoinTeamRequest P_1, NetworkConnection P_2)
		{
			EnsureClientInitialized();
			try
			{
				int playerId = P_1.PlayerId;
				NetworkedActivityPlayer player = GetPlayer(playerId);
				if (player == null)
				{
					Debug.LogError($"Unable to join team '{P_1.TeamId.GetValueOrDefault()}' of activity '{Data.DisplayName}' with player '{playerId}' because a player with that id could not be found.");
					_joinTeamRequest.SendResult(P_0, AsyncResult.UnexpectedError(1), P_2);
					return;
				}
				NetworkedActivityTeamIds networkedActivityTeamIds = P_1.TeamId ?? GetAutoJoinTeam(player);
				NetworkedActivityTeam team = GetTeam(networkedActivityTeamIds);
				if (team == null)
				{
					Debug.LogError($"Unable to join team '{networkedActivityTeamIds}' of activity '{Data.DisplayName}' with player '{playerId}' because the team with that id could not be found.");
					_joinTeamRequest.SendResult(P_0, AsyncResult.UnexpectedError(2), P_2);
					return;
				}
				if (!CanJoinTeam(player, team, out var joinDeniedReason))
				{
					_joinTeamRequest.SendResult(P_0, AsyncResult.Failure(joinDeniedReason), P_2);
					return;
				}
				JoinTeamClientRpc(playerId, networkedActivityTeamIds);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_joinTeamRequest.SendResult(P_0, AsyncResult.UnexpectedError(3), P_2);
				return;
			}
			_joinTeamRequest.SendResult(P_0, AsyncResult.Success(), P_2);
		}

		private void RpcReader___Server_JoinTeamRequestRpc___3842842145(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			JoinTeamRequest joinTeamRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinTeamRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___JoinTeamRequestRpc___3842842145(num, joinTeamRequest, conn);
			}
		}

		private void RpcWriter___Target_JoinTeamResultRpc___1617942072(NetworkConnection client, int requestId, AsyncResult result)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendTargetRpc(14u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___JoinTeamResultRpc___1617942072(NetworkConnection P_0, int P_1, AsyncResult P_2)
		{
			_joinTeamRequest.ReceiveResult(P_1, P_2);
		}

		private void RpcReader___Target_JoinTeamResultRpc___1617942072(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___JoinTeamResultRpc___1617942072(base.LocalConnection, num, asyncResult);
			}
		}

		private void RpcWriter___Observers_LeaveActivityClientRpc___3316948804(int playerId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			SendObserversRpc(15u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___LeaveActivityClientRpc___3316948804(int P_0)
		{
			FlightScenePlayer player = FlightSceneScript.Instance.GetPlayer(P_0);
			if (player == null)
			{
				Debug.LogError($"Unable to leave activity '{Data.DisplayName}' with player '{P_0}' because a player with that id could not be found.");
				return;
			}
			NetworkedActivityPlayer player2 = GetPlayer(P_0);
			if (player2 == null || player.NetworkedActivity != this)
			{
				Debug.LogError($"Unable to leave activity '{Data.DisplayName}' with player '{P_0}' because the player is not currently participating in that activity.");
			}
			else
			{
				RemovePlayerFromActivity(player2);
			}
		}

		private void RpcReader___Observers_LeaveActivityClientRpc___3316948804(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___LeaveActivityClientRpc___3316948804(num);
			}
		}

		private void RpcWriter___Server_LeaveActivityServerRpc___3316948804(int playerId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			SendServerRpc(16u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___LeaveActivityServerRpc___3316948804(int P_0)
		{
			EnsureClientInitialized();
			LeaveActivityClientRpc(P_0);
		}

		private void RpcReader___Server_LeaveActivityServerRpc___3316948804(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___LeaveActivityServerRpc___3316948804(num);
			}
		}

		private void RpcWriter___Observers_OnTimerChangedClientRpc___3316948804(int timerValue)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(timerValue);
			SendObserversRpc(17u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___OnTimerChangedClientRpc___3316948804(int P_0)
		{
			_timerValueClient = P_0;
			if (!_timerEnabledClient)
			{
				_timerEnabledClient = true;
				OnTimerStartedClient();
			}
			OnTimerChangedClient(P_0);
		}

		private void RpcReader___Observers_OnTimerChangedClientRpc___3316948804(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___OnTimerChangedClientRpc___3316948804(num);
			}
		}

		private void RpcWriter___Target_PlayerCraftBoundsRequestRpc___2910544794(NetworkConnection client, int requestId, PlayerCraftBoundsRequest request)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FPlayerCraftBoundsRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendTargetRpc(18u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___PlayerCraftBoundsRequestRpc___2910544794(NetworkConnection P_0, int P_1, PlayerCraftBoundsRequest P_2)
		{
			PlayerCraftBoundsRequestAsync(P_1, P_2).Forget();
		}

		private void RpcReader___Target_PlayerCraftBoundsRequestRpc___2910544794(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			PlayerCraftBoundsRequest playerCraftBoundsRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FPlayerCraftBoundsRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___PlayerCraftBoundsRequestRpc___2910544794(base.LocalConnection, num, playerCraftBoundsRequest);
			}
		}

		private void RpcWriter___Server_PlayerCraftBoundsResultRpc___1346278651(int requestId, CraftBoundsAsyncResult result, NetworkConnection client)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FCraftBoundsAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			pooledWriter.WriteNetworkConnection(client);
			SendServerRpc(19u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___PlayerCraftBoundsResultRpc___1346278651(int P_0, CraftBoundsAsyncResult P_1, NetworkConnection P_2)
		{
			_playerCraftBoundsRequest.ReceiveResult(P_0, P_1);
		}

		private void RpcReader___Server_PlayerCraftBoundsResultRpc___1346278651(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			CraftBoundsAsyncResult craftBoundsAsyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FCraftBoundsAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			if (base.IsServerInitialized)
			{
				RpcLogic___PlayerCraftBoundsResultRpc___1346278651(num, craftBoundsAsyncResult, networkConnection);
			}
		}

		private void RpcWriter___Server_SpawnLocationRequestRpc___140730828(int requestId, SpawnLocationRequest request, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendServerRpc(20u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SpawnLocationRequestRpc___140730828(int P_0, SpawnLocationRequest P_1, NetworkConnection P_2)
		{
			try
			{
				NetworkedActivityPlayer player = GetPlayer(P_1.PlayerId);
				if (player == null)
				{
					string text = $"Unable to request a spawn location for player '{P_1.PlayerId}' in networked activity '{Data.DisplayName}' because a player with that id could not be found.";
					Debug.LogError(text);
					_spawnLocationRequest.SendResult(P_0, new SpawnLocationAsyncResult(text), P_2);
				}
				else
				{
					StartLocationData playerSpawnLocation = GetPlayerSpawnLocation(player, P_1.InitialSpawn, P_1.Bounds);
					_spawnLocationRequest.SendResult(P_0, new SpawnLocationAsyncResult(playerSpawnLocation), P_2);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_spawnLocationRequest.SendResult(P_0, new SpawnLocationAsyncResult("An unexpected error occurred processing the request. Error Code 1"), P_2);
			}
		}

		private void RpcReader___Server_SpawnLocationRequestRpc___140730828(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			SpawnLocationRequest spawnLocationRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___SpawnLocationRequestRpc___140730828(num, spawnLocationRequest, conn);
			}
		}

		private void RpcWriter___Target_SpawnLocationResultRpc___3383668902(NetworkConnection client, int requestId, SpawnLocationAsyncResult result)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendTargetRpc(21u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SpawnLocationResultRpc___3383668902(NetworkConnection P_0, int P_1, SpawnLocationAsyncResult P_2)
		{
			_spawnLocationRequest.ReceiveResult(P_1, P_2);
		}

		private void RpcReader___Target_SpawnLocationResultRpc___3383668902(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			SpawnLocationAsyncResult spawnLocationAsyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___SpawnLocationResultRpc___3383668902(base.LocalConnection, num, spawnLocationAsyncResult);
			}
		}

		private void RpcWriter___Target_StartActivityForPlayerClientRpc___2476147485(NetworkConnection client, int requestId, StartActivityForPlayerRequest request)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FStartActivityForPlayerRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendTargetRpc(22u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___StartActivityForPlayerClientRpc___2476147485(NetworkConnection P_0, int P_1, StartActivityForPlayerRequest P_2)
		{
			StartActivityForLocalPlayerAsync(P_1, P_2).Forget();
		}

		private void RpcReader___Target_StartActivityForPlayerClientRpc___2476147485(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			StartActivityForPlayerRequest startActivityForPlayerRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FStartActivityForPlayerRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___StartActivityForPlayerClientRpc___2476147485(base.LocalConnection, num, startActivityForPlayerRequest);
			}
		}

		private void RpcWriter___Server_StartActivityForPlayerResultRpc___2038029376(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendServerRpc(23u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___StartActivityForPlayerResultRpc___2038029376(int P_0, AsyncResult P_1, NetworkConnection P_2)
		{
			EnsureClientInitialized();
			_startActivityForPlayerRequest.ReceiveResult(P_0, P_1);
		}

		private void RpcReader___Server_StartActivityForPlayerResultRpc___2038029376(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___StartActivityForPlayerResultRpc___2038029376(num, asyncResult, conn);
			}
		}

		private void RpcWriter___Server_StartActivityServerRpc___2166136261()
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(24u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___StartActivityServerRpc___2166136261()
		{
			EnsureClientInitialized();
			StartActivityAsync().Forget();
		}

		private void RpcReader___Server_StartActivityServerRpc___2166136261(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___StartActivityServerRpc___2166136261();
			}
		}

		private void RpcWriter___Server_StartTimerServerRpc___584859910(int initialTimerValue, ActivityTimerType timerType)
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
			pooledWriter.WriteInt32(initialTimerValue);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FActivityTimerTypeFishNet_002ESerializing_002EGenerated(pooledWriter, timerType);
			SendServerRpc(25u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___StartTimerServerRpc___584859910(int P_0, ActivityTimerType P_1)
		{
			EnsureClientInitialized();
			_timerType = P_1;
			_timerEnabledServer = true;
			_timerValueServer = P_0;
		}

		private void RpcReader___Server_StartTimerServerRpc___584859910(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			ActivityTimerType activityTimerType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FActivityTimerTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___StartTimerServerRpc___584859910(num, activityTimerType);
			}
		}

		private void RpcWriter___Observers_StopTimerClientRpc___2166136261()
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendObserversRpc(26u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___StopTimerClientRpc___2166136261()
		{
			_timerEnabledClient = false;
			_timerValueClient = 0;
			OnTimerStoppedClient();
		}

		private void RpcReader___Observers_StopTimerClientRpc___2166136261(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			if (base.IsClientInitialized)
			{
				RpcLogic___StopTimerClientRpc___2166136261();
			}
		}

		private void RpcWriter___Server_StopTimerServerRpc___2166136261()
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(27u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___StopTimerServerRpc___2166136261()
		{
			EnsureClientInitialized();
			_timerEnabledServer = false;
			_timerValueServer = 0f;
			StopTimerClientRpc();
		}

		private void RpcReader___Server_StopTimerServerRpc___2166136261(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___StopTimerServerRpc___2166136261();
			}
		}

		private void RpcWriter___Observers_SyncSettingsClientRpc___415360332(ArraySegment<byte> data)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(28u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SyncSettingsClientRpc___415360332(ArraySegment<byte> P_0)
		{
			_settingsSync.OnSyncDataReceived(P_0);
		}

		private void RpcReader___Observers_SyncSettingsClientRpc___415360332(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___SyncSettingsClientRpc___415360332(arraySegment);
			}
		}

		private void RpcWriter___Server_SyncSettingsServerRpc___415360332(ArraySegment<byte> data)
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
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(29u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SyncSettingsServerRpc___415360332(ArraySegment<byte> P_0)
		{
			EnsureClientInitialized();
			SyncSettingsClientRpc(P_0);
		}

		private void RpcReader___Server_SyncSettingsServerRpc___415360332(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___SyncSettingsServerRpc___415360332(arraySegment);
			}
		}

		private void RpcWriter___Target_WaitForAllPlayersEndedClientRpc___3093775645(NetworkConnection client, int requestId, WaitForAllPlayersEndedRequest request)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersEndedRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendTargetRpc(30u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___WaitForAllPlayersEndedClientRpc___3093775645(NetworkConnection P_0, int P_1, WaitForAllPlayersEndedRequest P_2)
		{
			WaitForAllPlayersEndedAsync(P_1, P_2).Forget();
		}

		private void RpcReader___Target_WaitForAllPlayersEndedClientRpc___3093775645(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			WaitForAllPlayersEndedRequest waitForAllPlayersEndedRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersEndedRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___WaitForAllPlayersEndedClientRpc___3093775645(base.LocalConnection, num, waitForAllPlayersEndedRequest);
			}
		}

		private void RpcWriter___Server_WaitForAllPlayersEndedResultRpc___2038029376(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendServerRpc(31u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___WaitForAllPlayersEndedResultRpc___2038029376(int P_0, AsyncResult P_1, NetworkConnection P_2)
		{
			_waitForAllPlayersEndedRequest.ReceiveResult(P_0, P_1);
		}

		private void RpcReader___Server_WaitForAllPlayersEndedResultRpc___2038029376(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___WaitForAllPlayersEndedResultRpc___2038029376(num, asyncResult, conn);
			}
		}

		private void RpcWriter___Target_WaitForAllPlayersStartedClientRpc___3850372160(NetworkConnection client, int requestId, WaitForAllPlayersStartedRequest request)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersStartedRequestFishNet_002ESerializing_002EGenerated(pooledWriter, request);
			SendTargetRpc(32u, pooledWriter, channel, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___WaitForAllPlayersStartedClientRpc___3850372160(NetworkConnection P_0, int P_1, WaitForAllPlayersStartedRequest P_2)
		{
			WaitForAllPlayersStartedAsync(P_1, P_2).Forget();
		}

		private void RpcReader___Target_WaitForAllPlayersStartedClientRpc___3850372160(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			WaitForAllPlayersStartedRequest waitForAllPlayersStartedRequest = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersStartedRequestFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsClientInitialized)
			{
				RpcLogic___WaitForAllPlayersStartedClientRpc___3850372160(base.LocalConnection, num, waitForAllPlayersStartedRequest);
			}
		}

		private void RpcWriter___Server_WaitForAllPlayersStartedResultRpc___2038029376(int requestId, AsyncResult result, NetworkConnection client = null)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(requestId);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(pooledWriter, result);
			SendServerRpc(33u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___WaitForAllPlayersStartedResultRpc___2038029376(int P_0, AsyncResult P_1, NetworkConnection P_2)
		{
			_waitForAllPlayersStartedRequest.ReceiveResult(P_0, P_1);
		}

		private void RpcReader___Server_WaitForAllPlayersStartedResultRpc___2038029376(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			AsyncResult asyncResult = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___WaitForAllPlayersStartedResultRpc___2038029376(num, asyncResult, conn);
			}
		}

		private void RpcWriter___Observers_SetPlayerScoreClientRpc___987676289(int playerId, string scoreId, int scoreValue)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteInt32(scoreValue);
			SendObserversRpc(34u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___SetPlayerScoreClientRpc___987676289(int P_0, string P_1, int P_2)
		{
			UpdatePlayerScore(P_0, P_1, P_2, (NetworkedActivityScore score) => score.ValueInt, delegate(NetworkedActivityScore score, int value)
			{
				score.ValueInt = value;
			});
		}

		private void RpcReader___Observers_SetPlayerScoreClientRpc___987676289(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			string text = PooledReader0.ReadStringAllocated();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___SetPlayerScoreClientRpc___987676289(num, text, num2);
			}
		}

		private void RpcWriter___Observers_SetPlayerScoreClientRpc___2812360343(int playerId, string scoreId, float scoreValue)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteSingle(scoreValue);
			SendObserversRpc(35u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___SetPlayerScoreClientRpc___2812360343(int P_0, string P_1, float P_2)
		{
			UpdatePlayerScore(P_0, P_1, P_2, (NetworkedActivityScore score) => score.ValueFloat, delegate(NetworkedActivityScore score, float value)
			{
				score.ValueFloat = value;
			});
		}

		private void RpcReader___Observers_SetPlayerScoreClientRpc___2812360343(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			string text = PooledReader0.ReadStringAllocated();
			float num2 = PooledReader0.ReadSingle();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___SetPlayerScoreClientRpc___2812360343(num, text, num2);
			}
		}

		private void RpcWriter___Observers_SetTeamScoreClientRpc___1890589669(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, int scoreValue)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(pooledWriter, teamId);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteInt32(scoreValue);
			SendObserversRpc(36u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___SetTeamScoreClientRpc___1890589669(NetworkedActivityTeamIds P_0, int? P_1, string P_2, int P_3)
		{
			UpdateTeamScore(P_0, P_1, P_2, P_3, (NetworkedActivityScore score) => score.ValueInt, delegate(NetworkedActivityScore score, int value)
			{
				score.ValueInt = value;
			});
		}

		private void RpcReader___Observers_SetTeamScoreClientRpc___1890589669(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			NetworkedActivityTeamIds networkedActivityTeamIds = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			string text = PooledReader0.ReadStringAllocated();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___SetTeamScoreClientRpc___1890589669(networkedActivityTeamIds, num, text, num2);
			}
		}

		private void RpcWriter___Observers_SetTeamScoreClientRpc___1446739795(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, float scoreValue)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(pooledWriter, teamId);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteSingle(scoreValue);
			SendObserversRpc(37u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___SetTeamScoreClientRpc___1446739795(NetworkedActivityTeamIds P_0, int? P_1, string P_2, float P_3)
		{
			UpdateTeamScore(P_0, P_1, P_2, P_3, (NetworkedActivityScore score) => score.ValueFloat, delegate(NetworkedActivityScore score, float value)
			{
				score.ValueFloat = value;
			});
		}

		private void RpcReader___Observers_SetTeamScoreClientRpc___1446739795(PooledReader PooledReader0, FishNet.Transporting.Channel channel)
		{
			NetworkedActivityTeamIds networkedActivityTeamIds = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			string text = PooledReader0.ReadStringAllocated();
			float num2 = PooledReader0.ReadSingle();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___SetTeamScoreClientRpc___1446739795(networkedActivityTeamIds, num, text, num2);
			}
		}

		private void RpcWriter___Server_UpdatePlayerScoreServerRpc___3842514558(int playerId, string scoreId, int scoreValue, UpdateScoreType updateType)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteInt32(scoreValue);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerated(pooledWriter, updateType);
			SendServerRpc(38u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___UpdatePlayerScoreServerRpc___3842514558(int P_0, string P_1, int P_2, UpdateScoreType P_3)
		{
			EnsureClientInitialized();
			switch (P_3)
			{
			case UpdateScoreType.Add:
			{
				if (GetPlayerScoreForUpdate(P_0, P_1, out var _, out var score))
				{
					SetPlayerScoreClientRpc(P_0, P_1, score.ValueInt + P_2);
				}
				break;
			}
			case UpdateScoreType.Set:
				SetPlayerScoreClientRpc(P_0, P_1, P_2);
				break;
			default:
				Debug.LogError($"Unsupported score update type: {P_3}");
				break;
			}
		}

		private void RpcReader___Server_UpdatePlayerScoreServerRpc___3842514558(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			string text = PooledReader0.ReadStringAllocated();
			int num2 = PooledReader0.ReadInt32();
			UpdateScoreType updateScoreType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___UpdatePlayerScoreServerRpc___3842514558(num, text, num2, updateScoreType);
			}
		}

		private void RpcWriter___Server_UpdatePlayerScoreServerRpc___3140289600(int playerId, string scoreId, float scoreValue, UpdateScoreType updateType)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteSingle(scoreValue);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerated(pooledWriter, updateType);
			SendServerRpc(39u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___UpdatePlayerScoreServerRpc___3140289600(int P_0, string P_1, float P_2, UpdateScoreType P_3)
		{
			EnsureClientInitialized();
			switch (P_3)
			{
			case UpdateScoreType.Add:
			{
				if (GetPlayerScoreForUpdate(P_0, P_1, out var _, out var score))
				{
					SetPlayerScoreClientRpc(P_0, P_1, score.ValueFloat + P_2);
				}
				break;
			}
			case UpdateScoreType.Set:
				SetPlayerScoreClientRpc(P_0, P_1, P_2);
				break;
			default:
				Debug.LogError($"Unsupported score update type: {P_3}");
				break;
			}
		}

		private void RpcReader___Server_UpdatePlayerScoreServerRpc___3140289600(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			string text = PooledReader0.ReadStringAllocated();
			float num2 = PooledReader0.ReadSingle();
			UpdateScoreType updateScoreType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___UpdatePlayerScoreServerRpc___3140289600(num, text, num2, updateScoreType);
			}
		}

		private void RpcWriter___Server_UpdateTeamScoreServerRpc___1792888938(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, int scoreValue, UpdateScoreType updateType)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(pooledWriter, teamId);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteInt32(scoreValue);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerated(pooledWriter, updateType);
			SendServerRpc(40u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___UpdateTeamScoreServerRpc___1792888938(NetworkedActivityTeamIds P_0, int? P_1, string P_2, int P_3, UpdateScoreType P_4)
		{
			EnsureClientInitialized();
			switch (P_4)
			{
			case UpdateScoreType.Add:
			{
				if (GetTeamScoreForUpdate(P_0, P_2, out var _, out var score))
				{
					SetTeamScoreClientRpc(P_0, P_1, P_2, score.ValueInt + P_3);
				}
				break;
			}
			case UpdateScoreType.Set:
				SetTeamScoreClientRpc(P_0, P_1, P_2, P_3);
				break;
			default:
				Debug.LogError($"Unsupported score update type: {P_4}");
				break;
			}
		}

		private void RpcReader___Server_UpdateTeamScoreServerRpc___1792888938(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			NetworkedActivityTeamIds networkedActivityTeamIds = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			string text = PooledReader0.ReadStringAllocated();
			int num2 = PooledReader0.ReadInt32();
			UpdateScoreType updateScoreType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___UpdateTeamScoreServerRpc___1792888938(networkedActivityTeamIds, num, text, num2, updateScoreType);
			}
		}

		private void RpcWriter___Server_UpdateTeamScoreServerRpc___1397896004(NetworkedActivityTeamIds teamId, int? playerId, string scoreId, float scoreValue, UpdateScoreType updateType)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			FishNet.Transporting.Channel channel = FishNet.Transporting.Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(pooledWriter, teamId);
			GeneratedWriters___Internal.GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(pooledWriter, playerId);
			pooledWriter.WriteString(scoreId);
			pooledWriter.WriteSingle(scoreValue);
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerated(pooledWriter, updateType);
			SendServerRpc(41u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___UpdateTeamScoreServerRpc___1397896004(NetworkedActivityTeamIds P_0, int? P_1, string P_2, float P_3, UpdateScoreType P_4)
		{
			EnsureClientInitialized();
			switch (P_4)
			{
			case UpdateScoreType.Add:
			{
				if (GetTeamScoreForUpdate(P_0, P_2, out var _, out var score))
				{
					SetTeamScoreClientRpc(P_0, P_1, P_2, score.ValueFloat + P_3);
				}
				break;
			}
			case UpdateScoreType.Set:
				SetTeamScoreClientRpc(P_0, P_1, P_2, P_3);
				break;
			default:
				Debug.LogError($"Unsupported score update type: {P_4}");
				break;
			}
		}

		private void RpcReader___Server_UpdateTeamScoreServerRpc___1397896004(PooledReader PooledReader0, FishNet.Transporting.Channel channel, NetworkConnection conn)
		{
			NetworkedActivityTeamIds networkedActivityTeamIds = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int? num = GeneratedReaders___Internal.GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(PooledReader0);
			string text = PooledReader0.ReadStringAllocated();
			float num2 = PooledReader0.ReadSingle();
			UpdateScoreType updateScoreType = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___UpdateTeamScoreServerRpc___1397896004(networkedActivityTeamIds, num, text, num2, updateScoreType);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_Game_002Edll()
		{
			_manager = Game.Instance.NetworkedActivityManager;
			_players = new List<NetworkedActivityPlayer>();
			_initialPlayerStartLocations = new Dictionary<int, StartLocationData>();
			_initialStartLocations = new EnumDictionary<NetworkedActivityTeamIds, List<InitialStartLocation>>((NetworkedActivityTeamIds x) => new List<InitialStartLocation>());
			_startLocationsNextIndex = new EnumDictionary<NetworkedActivityTeamIds, int>((NetworkedActivityTeamIds x) => 0);
			_playersPendingStart = new List<NetworkedActivityPlayer>();
			_initialTeamSpawnData = new List<InitialTeamSpawnData>();
			_pendingPlayerJoins = new List<PendingPlayerJoin>();
			InitializeAICraftManager();
		}
	}
}
