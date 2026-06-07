using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Analysis.Analytics;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Design;
using Assets.Scripts.Environment;
using Assets.Scripts.Environment.Roads;
using Assets.Scripts.Environment.Vegetation;
using Assets.Scripts.Environment.Water;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Flight.UI.Panels;
using Assets.Scripts.Flight.WorldObjects;
using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Scenes.Events;
using Jundroo.Common.Coroutines;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class FlightSceneScript : MonoBehaviour
	{
		private const double ResourceCollectionIntervalSeconds = 300.0;

		[SerializeField]
		private Transform _aircraftContainer;

		private List<FlightScenePlayer> _allPlayers = new List<FlightScenePlayer>();

		[SerializeField]
		private Transform _avatarContainer;

		[SerializeField]
		private CameraManagerScript _cameraManagerScript;

		[SerializeField]
		private CarSpawnerScript _carSpawner;

		private DragCalculatorScript _dragCalculator;

		[SerializeField]
		private FlightUIScript _flightUI;

		private int _frameLocalPlayerJoined;

		private YieldAction _initLoadLocalPlayers;

		private bool _isQuitting;

		private double _lastResourceCollectionTime;

		private List<FlightScenePlayer> _localPlayers = new List<FlightScenePlayer>();

		private NetworkGameManager _networkGameManager;

		[SerializeField]
		private NetworkStateRegistryScript _networkStateRegistry;

		private List<FlightScenePlayer> _remotePlayers = new List<FlightScenePlayer>();

		[SerializeField]
		private FlightSceneRenderingManagerScript _renderingManager;

		[SerializeField]
		private WaterQueryManager _waterQueryManager;

		[SerializeField]
		private WindManager _windManager;

		public static FlightSceneScript Instance { get; private set; }

		public static bool IsPeacefulMode { get; set; }

		public Transform AircraftContainer => _aircraftContainer;

		public IReadOnlyList<FlightScenePlayer> AllPlayers => _allPlayers;

		public Transform AvatarContainer => _avatarContainer;

		public CameraManagerScript CameraScript => _cameraManagerScript;

		public CarSpawnerScript CarSpawner => _carSpawner;

		public float CurrentMaxCraftSize
		{
			get
			{
				if (FlightUI.MultiplayerState != FlightUIScript.MultiplayerStateType.SinglePlayer)
				{
					return 5000f;
				}
				return 0f;
			}
		}

		public int CurrentMaxPartCount
		{
			get
			{
				if (FlightUI.MultiplayerState != FlightUIScript.MultiplayerStateType.SinglePlayer)
				{
					return FlightSceneNetwork.ServerMaxPartCount;
				}
				return 0;
			}
		}

		public InFlightDesignerScene Designer { get; private set; }

		public DragCalculatorScript DragCalculator => _dragCalculator;

		public IEnvironment Environment { get; private set; }

		public FlightGizmos FlightGizmos { get; private set; } = new FlightGizmos();

		public FlightSceneNetworkScript FlightSceneNetwork { get; private set; }

		public FlightUIScript FlightUI => _flightUI;

		public FlightScenePlayer LocalPlayer { get; private set; }

		public IReadOnlyList<FlightScenePlayer> LocalPlayers => _localPlayers;

		public INetworkStateRegistry NetworkStateRegistry => _networkStateRegistry;

		public FlightSceneRenderingManagerScript RenderingManager => _renderingManager;

		public FlightSceneResettableObjectManager ResettableObjectManager { get; private set; }

		public StartLocationManagerScript StartLocationManager { get; private set; }

		public TargetRegistry TargetRegistry { get; private set; }

		public TeamAggressionManager TeamAggressionManager { get; private set; }

		public TreeColliderManager TreeColliderManager { get; private set; }

		public WaterQueryManager WaterQueryManager => _waterQueryManager;

		public WindManager WindManager => _windManager;

		public event EventHandler<EventArgs> FlightSceneLoaded;

		public event EventHandler<EventArgs> FlightSceneLoading;

		public event EventHandler<EventArgs> FlightSceneUnloaded;

		public event EventHandler<EventArgs> FlightSceneUnloading;

		public event EventHandler<EventArgs> LocalPlayersLoaded;

		public event EventHandler<FlightScenePlayerAircraftLoadCompletedEventArgs> PlayerAircraftLoadCompleted;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> PlayerAircraftLoaded;

		public event EventHandler<FlightScenePlayerEventArgs> PlayerAircraftLoadStarted;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> PlayerAircraftUnloaded;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> PlayerEnteredAircraft;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> PlayerExitedAircraft;

		public event EventHandler<FlightScenePlayerEventArgs> PlayerLoaded;

		public event EventHandler<FlightScenePlayerEventArgs> PlayerUnloaded;

		public event EventHandler<FlightScenePlayerEventArgs> PrimaryLocalPlayerLoaded;

		public void CreateExplosion(string explosionPrefabName, Vector3 position, float explosionScale, Vector3? blastDirection, int? attackerPlayerId, Vector3? impactDirection, ExplosiveWeaponImpactType impactType)
		{
			CreateExplosionInfo creationExplosionInfo = new CreateExplosionInfo
			{
				ExplosionPrefabName = explosionPrefabName,
				AttackerPlayerId = attackerPlayerId,
				GlobalPosition = Utility.ConvertFloatingOriginToAbsolutePosition(position),
				ExplosionScale = explosionScale,
				BlastDirection = blastDirection,
				ImpactDirection = impactDirection,
				ImpactType = impactType
			};
			FlightSceneNetwork.CreateExplosion(creationExplosionInfo);
		}

		public void ExitLevel()
		{
			if (!_isQuitting)
			{
				_isQuitting = true;
				AudioManager.ClearTrackedSounds();
				PauseManager.Reset();
				if (Designer.Active)
				{
					Assets.Scripts.Design.Designer.Instance?.DesignerScript?.SaveDesignerCraft();
				}
				Action callback = delegate
				{
					UnityAnalytics.SceneExited(designer: false);
				};
				Game.Instance.NetworkGameManager.Disconnect();
				if (Game.Instance.SceneManager.EndLevelReturnScene != null)
				{
					Game.Instance.SceneManager.LoadScene(Game.Instance.SceneManager.EndLevelReturnScene, callback);
				}
				else
				{
					Game.Instance.SceneManager.LoadMenu(callback);
				}
			}
		}

		public FlightScenePlayer GetPlayer(int playerId)
		{
			return _allPlayers.Where((FlightScenePlayer x) => x.NetworkPlayer.PlayerId == playerId).FirstOrDefault();
		}

		public void LoadAircraftFromClipboardOrUrl(string url = null)
		{
			InFlightDesignerScene designer = Designer;
			if (designer != null && designer.Active)
			{
				Designer.DesignerScript.LoadAircraftFromClipboardOrUrl(url);
			}
			else
			{
				FlightUI.Flyouts.ChangeCraft.Widget.GetComponentInChildren<ChangeCraftScript>().LoadAircraftFromClipboardOrUrl(url);
			}
		}

		public void RaiseLocalPlayerLoaded(EventHandler<FlightScenePlayerEventArgs> eventHandler)
		{
			foreach (FlightScenePlayer localPlayer in _localPlayers)
			{
				eventHandler?.Invoke(this, new FlightScenePlayerEventArgs(localPlayer));
			}
		}

		public void RaisePlayerEnteredAircraft(EventHandler<FlightScenePlayerAircraftEventArgs> eventHandler)
		{
			foreach (FlightScenePlayer localPlayer in _localPlayers)
			{
				if ((object)localPlayer.Aircraft != null)
				{
					eventHandler?.Invoke(this, new FlightScenePlayerAircraftEventArgs(localPlayer, localPlayer.Aircraft));
				}
			}
		}

		public void UnloadUnusedAssets(bool force)
		{
			double realtimeSinceStartupAsDouble = Time.realtimeSinceStartupAsDouble;
			if (realtimeSinceStartupAsDouble >= _lastResourceCollectionTime + 300.0 || force)
			{
				_lastResourceCollectionTime = realtimeSinceStartupAsDouble;
				StartCoroutine(CleanupResourcesCoroutine());
			}
			static IEnumerator CleanupResourcesCoroutine()
			{
				yield return new WaitForEndOfFrame();
				Resources.UnloadUnusedAssets();
			}
		}

		protected virtual void Awake()
		{
			Instance = this;
			_networkGameManager = Game.Instance.NetworkGameManager;
			_initLoadLocalPlayers = new YieldAction((Action)InitializeLocalPlayers);
			NetworkAircraftScript.OnFlightSceneAwake();
			CraftOwnerSpawnData.Reinitialize();
			Designer = new InFlightDesignerScene(this);
			Environment = new VolumetricEnvironment();
			TreeColliderManager = TreeColliderManager.Create(this);
			ResettableObjectManager = new FlightSceneResettableObjectManager();
			_dragCalculator = new GameObject("DragCalculator").AddComponent<DragCalculatorScript>();
			_dragCalculator.transform.SetParent(base.transform, worldPositionStays: false);
			Game.Instance.SceneManager.SceneUnloading += OnSceneUnloading;
			Game.Instance.SceneManager.SceneUnloaded += OnSceneUnloaded;
			FlightSceneNetwork = GetComponentInChildren<FlightSceneNetworkScript>();
			TeamAggressionManager = TeamAggressionManager.Create(FlightSceneNetwork);
			TargetRegistry = new TargetRegistry();
			StartLocationManager = StartLocationManagerScript.Create(base.gameObject, FlightSceneNetwork);
			FlightSceneNetwork.ClientStarted += FlightSceneNetworkClientStarted;
		}

		protected virtual void OnApplicationQuit()
		{
			_isQuitting = true;
		}

		protected virtual void OnDestroy()
		{
			FlightGizmos.OnDestroy();
			FlightSceneNetwork.ClientStarted -= FlightSceneNetworkClientStarted;
			Environment.Dispose();
		}

		protected virtual IEnumerator Start()
		{
			this.FlightSceneLoading?.Invoke(this, EventArgs.Empty);
			yield return LoadInitialLocalPlayers();
			Environment.LengthOfDay = Game.Instance.Settings.Gameplay.Flight.LengthOfDay.Value;
			this.FlightSceneLoaded?.Invoke(this, EventArgs.Empty);
			if (!Device.IsUnityEditor)
			{
				Debug.Log($"{Time.frameCount}: Flight Scene Loading Complete");
			}
		}

		protected virtual void Update()
		{
			TargetRegistry.Update();
			ResettableObjectManager.Update(Time.deltaTime);
			foreach (FlightScenePlayer allPlayer in _allPlayers)
			{
				allPlayer.Update();
			}
			if (!Device.IsUnityEditor)
			{
				return;
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.D) && UnityEngine.Input.GetKey(KeyCode.LeftControl) && UnityEngine.Input.GetKey(KeyCode.LeftAlt))
			{
				if (Designer.Active)
				{
					Designer.Exit();
				}
				else
				{
					Designer.Enter();
				}
			}
			else
			{
				if (!DebugInput.GetKeyDown(KeyCode.T) || !DebugInput.GetKey(KeyCode.LeftShift))
				{
					return;
				}
				StartLocationData startLocationData = Instance.StartLocationManager.Locations.FirstOrDefault((StartLocationData x) => x.Id == "_SpawnTarget");
				if (startLocationData != null)
				{
					string aircraftId = "Wasp (Simple)";
					StartLocation location = Instance.StartLocationManager.CreateAvailableStartLocation(startLocationData);
					ushort teamId = 1;
					bool aggressive = DebugInput.GetKey(KeyCode.LeftControl);
					AiManagerScript.Instance.SpawnSandboxAi(aircraftId, autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, null, aggressive, teamId, delegate(AiControlledAircraftScript aiAircraft)
					{
						PositionUtility.RepositionAircraftOnGround(aiAircraft.AiAircraftScript, excludePartsDisconnectedFromMainCockpit: false, 10f);
						aiAircraft.CurrentControlSystem.ControlFunction.RecheckLandingGearPosition();
						FlightUI.ShowMessage("Spawned " + (aggressive ? "aggressive" : "non aggressive") + " '" + aiAircraft.AiAircraftScript.Aircraft.Name + "'");
					});
				}
				else
				{
					Debug.Log("Could not find _SpawnTarget start location");
				}
			}
		}

		private void FlightSceneNetworkClientStarted()
		{
			if (FlightSceneNetwork.IsServerStarted)
			{
				FlightSceneNetwork.SpawnGameObject("Flight/WorldObjects/Vehicles/Land/Trains/TrainManager", Vector3.zero, Vector3.zero);
			}
		}

		private void InitializeLocalPlayers()
		{
			_networkGameManager.LocalPlayerJoined += OnLocalPlayerJoined;
			_networkGameManager.LocalPlayerLeft += OnLocalPlayerLeft;
			_networkGameManager.RemotePlayerJoined += OnRemotePlayerJoined;
			_networkGameManager.RemotePlayerLeft += OnRemotePlayerLeft;
			if (_networkGameManager.LocalPlayers.Count == 0)
			{
				_networkGameManager.StartLocalGame();
				return;
			}
			foreach (NetworkPlayerScript localPlayer in _networkGameManager.LocalPlayers)
			{
				OnLocalPlayerJoined(localPlayer);
			}
		}

		private IEnumerator LoadInitialLocalPlayers()
		{
			PlayerLoaded += CheckLocalPlayersLoaded;
			yield return _initLoadLocalPlayers.Start();
			PlayerLoaded -= CheckLocalPlayersLoaded;
			void CheckLocalPlayersLoaded(object sender, FlightScenePlayerEventArgs e)
			{
				if (e.Player.IsLocal && !_initLoadLocalPlayers.IsComplete && _localPlayers.Count == _networkGameManager.LocalPlayers.Count)
				{
					this.LocalPlayersLoaded?.Invoke(this, EventArgs.Empty);
					_initLoadLocalPlayers.Complete();
				}
			}
		}

		private void OnLocalPlayerJoined(object sender, NetworkPlayerEventArgs e)
		{
			OnLocalPlayerJoined(e.Player);
			_frameLocalPlayerJoined = Time.frameCount;
		}

		private void OnLocalPlayerJoined(NetworkPlayerScript player)
		{
			FlightScenePlayer flightScenePlayer = new FlightScenePlayer(player);
			_allPlayers.Add(flightScenePlayer);
			_localPlayers.Add(flightScenePlayer);
			if (player.IsPrimaryLocal)
			{
				LocalPlayer = flightScenePlayer;
				this.PrimaryLocalPlayerLoaded?.Invoke(this, new FlightScenePlayerEventArgs(flightScenePlayer));
			}
			this.PlayerLoaded?.Invoke(this, new FlightScenePlayerEventArgs(flightScenePlayer));
			UpdatePlayerEventSubscriptions(flightScenePlayer, subscribe: true);
		}

		private void OnLocalPlayerLeft(object sender, NetworkPlayerEventArgs e)
		{
			foreach (FlightScenePlayer localPlayer in LocalPlayers)
			{
				if (localPlayer.NetworkPlayer == e.Player)
				{
					OnPlayerLeft(localPlayer);
					break;
				}
			}
		}

		private void OnPlayerAircraftEntered(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			this.PlayerEnteredAircraft?.Invoke(this, e);
		}

		private void OnPlayerAircraftExited(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			this.PlayerExitedAircraft?.Invoke(this, e);
		}

		private void OnPlayerAircraftLoadCompleted(object sender, FlightScenePlayerAircraftLoadCompletedEventArgs e)
		{
			this.PlayerAircraftLoadCompleted?.Invoke(this, e);
		}

		private void OnPlayerAircraftLoaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			this.PlayerAircraftLoaded?.Invoke(this, e);
		}

		private void OnPlayerAircraftLoadStarted(object sender, FlightScenePlayerEventArgs e)
		{
			this.PlayerAircraftLoadStarted?.Invoke(this, e);
		}

		private void OnPlayerAircraftUnloaded(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			this.PlayerAircraftUnloaded?.Invoke(this, e);
		}

		private void OnPlayerLeft(FlightScenePlayer player)
		{
			UpdatePlayerEventSubscriptions(player, subscribe: false);
			_allPlayers.Remove(player);
			if (player.IsLocal)
			{
				if (!_localPlayers.Remove(player))
				{
					Debug.LogError("The local player '" + player.NetworkPlayer.Name + "' has left the game but appears to have never been loaded in the flight scene.");
					return;
				}
			}
			else if (!_remotePlayers.Remove(player))
			{
				Debug.LogError("The remote player '" + player.NetworkPlayer.Name + "' has left the game but appears to have never been loaded in the flight scene.");
				return;
			}
			this.PlayerUnloaded?.Invoke(this, new FlightScenePlayerEventArgs(player));
			if (LocalPlayer != null && LocalPlayer == player)
			{
				LocalPlayer = null;
				if (this != null)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		private void OnRemotePlayerJoined(object sender, NetworkPlayerEventArgs e)
		{
			NetworkPlayerScript player = e.Player;
			FlightScenePlayer flightScenePlayer = new FlightScenePlayer(e.Player);
			_allPlayers.Add(flightScenePlayer);
			_remotePlayers.Add(flightScenePlayer);
			UpdatePlayerEventSubscriptions(flightScenePlayer, subscribe: true);
			this.PlayerLoaded?.Invoke(this, new FlightScenePlayerEventArgs(flightScenePlayer));
			if (_frameLocalPlayerJoined > 0 && Time.frameCount - _frameLocalPlayerJoined > 50 && !player.IsNPC)
			{
				FlightSceneNetwork.ChatMessages.RaiseMessageReceived(null, player.Name + " has joined the server");
			}
		}

		private void OnRemotePlayerLeft(object sender, NetworkPlayerEventArgs e)
		{
			foreach (FlightScenePlayer remotePlayer in _remotePlayers)
			{
				if (remotePlayer.NetworkPlayer == e.Player)
				{
					if (!remotePlayer.NetworkPlayer.IsNPC)
					{
						FlightSceneNetwork.ChatMessages.RaiseMessageReceived(null, remotePlayer.Name + " has left the server");
					}
					OnPlayerLeft(remotePlayer);
					break;
				}
			}
		}

		private void OnSceneUnloaded(object sender, SceneEventArgs e)
		{
			Instance = null;
			Game.Instance.SceneManager.SceneUnloading -= OnSceneUnloading;
			Game.Instance.SceneManager.SceneUnloaded -= OnSceneUnloaded;
		}

		private void OnSceneUnloading(object sender, SceneEventArgs e)
		{
			RaiseEvent(this.FlightSceneUnloading, EventArgs.Empty, ensureEverySubscriberLoggingExceptions: true);
			_networkGameManager.LocalPlayerJoined -= OnLocalPlayerJoined;
			_networkGameManager.LocalPlayerLeft -= OnLocalPlayerLeft;
			_networkGameManager.RemotePlayerJoined -= OnRemotePlayerJoined;
			_networkGameManager.RemotePlayerLeft -= OnRemotePlayerLeft;
			foreach (FlightScenePlayer localPlayer in _localPlayers)
			{
				localPlayer.Unload();
			}
			RaiseEvent(this.FlightSceneUnloaded, EventArgs.Empty, ensureEverySubscriberLoggingExceptions: true);
		}

		private void RaiseEvent<T>(EventHandler<T> eventHandler, T eventArgs, bool ensureEverySubscriberLoggingExceptions)
		{
			if (ensureEverySubscriberLoggingExceptions)
			{
				if (eventHandler == null)
				{
					return;
				}
				Delegate[] invocationList = eventHandler.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					EventHandler<T> eventHandler2 = (EventHandler<T>)invocationList[i];
					try
					{
						eventHandler2?.Invoke(this, eventArgs);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			else
			{
				eventHandler?.Invoke(this, eventArgs);
			}
		}

		private void UpdatePlayerEventSubscriptions(FlightScenePlayer player, bool subscribe)
		{
			if (subscribe)
			{
				player.AircraftLoaded += OnPlayerAircraftLoaded;
				player.AircraftUnloaded += OnPlayerAircraftUnloaded;
				player.AircraftLoadStarted += OnPlayerAircraftLoadStarted;
				player.AircraftLoadCompleted += OnPlayerAircraftLoadCompleted;
				player.AircraftEntered += OnPlayerAircraftEntered;
				player.AircraftExited += OnPlayerAircraftExited;
			}
			else
			{
				player.AircraftLoaded -= OnPlayerAircraftLoaded;
				player.AircraftUnloaded -= OnPlayerAircraftUnloaded;
				player.AircraftLoadStarted -= OnPlayerAircraftLoadStarted;
				player.AircraftLoadCompleted -= OnPlayerAircraftLoadCompleted;
				player.AircraftEntered -= OnPlayerAircraftEntered;
				player.AircraftExited -= OnPlayerAircraftExited;
			}
		}
	}
}
