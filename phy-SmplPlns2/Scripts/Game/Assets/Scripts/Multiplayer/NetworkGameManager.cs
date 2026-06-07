using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Achievements;
using Assets.Scripts.Flight;
using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Lobbies;
using Assets.Scripts.Multiplayer.Lobbies.Events;
using Assets.Scripts.Scenes;
using FishNet.Managing;
using FishNet.Managing.Transporting;
using FishNet.Transporting;
using FishNet.Transporting.Multipass;
using FishNet.Transporting.Tugboat;
using FishNet.Transporting.Yak;
using FishySteamworks;
using Jundroo.Common.Platform;
using Jundroo.Common.Threading.Tasks;
using Jundroo.DevConsole;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Steam.Multiplayer;
using Jundroo.SocialPlatforms.Steam.Multiplayer.Events;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkGameManager : MonoBehaviour
	{
		private bool _connectingUnityEditorCloneAsClient;

		private bool _isApplicationQuitting;

		[SerializeField]
		private List<NetworkPlayerScript> _localPlayers;

		private bool _logConnectionStateChanges;

		[SerializeField]
		private List<NetworkPlayerScript> _players;

		private Transform _playersContainer;

		[SerializeField]
		private List<NetworkPlayerScript> _remotePlayers;

		private bool _shouldConnectAsClient;

		private Multipass _transportMultipass;

		public bool IsServer => NetworkManager.IsServerStarted;

		public NetworkPlayerScript LocalPlayer { get; private set; }

		public IReadOnlyList<NetworkPlayerScript> LocalPlayers => _localPlayers;

		public NetworkManager NetworkManager { get; private set; }

		public IReadOnlyList<NetworkPlayerScript> Players => _players;

		public IReadOnlyList<NetworkPlayerScript> RemotePlayers => _remotePlayers;

		public NetworkPlayerScript ServerPlayer { get; private set; }

		public SteamLobbyManager SteamLobbyManager { get; private set; }

		public TeamManager TeamManager { get; private set; }

		public event EventHandler<NetworkPlayerEventArgs> LocalPlayerJoined;

		public event EventHandler<NetworkPlayerEventArgs> LocalPlayerLeft;

		public event EventHandler<NetworkPlayerEventArgs> PlayerJoined;

		public event EventHandler<NetworkPlayerEventArgs> PlayerLeaving;

		public event EventHandler<NetworkPlayerEventArgs> PlayerLeft;

		public event EventHandler<NetworkPlayerChangedEventArgs> PrimaryLocalPlayerChanged;

		public event EventHandler<NetworkPlayerEventArgs> RemotePlayerJoined;

		public event EventHandler<NetworkPlayerEventArgs> RemotePlayerLeft;

		public static NetworkGameManager Create(GameObject parent)
		{
			NetworkGameManager networkGameManager = new GameObject("NetworkGameManager").AddComponent<NetworkGameManager>();
			networkGameManager.transform.SetParent(parent.transform);
			try
			{
				networkGameManager.Initialize();
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred initializing the network game manager");
				Debug.LogException(exception);
			}
			return networkGameManager;
		}

		public void Disconnect(bool applicationQuitting = false)
		{
			_isApplicationQuitting |= applicationQuitting;
			SteamLobbyManager?.LeaveLobby();
			if (NetworkManager.ServerManager.Started)
			{
				NetworkManager.ServerManager.StopConnection(sendDisconnectMessage: true);
			}
			else if (NetworkManager.ClientManager.Started)
			{
				NetworkManager.ClientManager.StopConnection();
			}
		}

		public NetworkPlayerScript GetPlayer(int playerId)
		{
			foreach (NetworkPlayerScript player in _players)
			{
				if (player.PlayerId == playerId)
				{
					return player;
				}
			}
			return null;
		}

		public void InitializeSteamIfNecessary()
		{
			if (Device.IsUnityEditor && !SocialExt.IsSteam && !Game.Instance.IsClonedEditor)
			{
				SocialExt.Initialize(AchievementManager.Instance.Achievements, forceInitializationInEditor: true);
				if (!SocialExt.IsSteam)
				{
					Debug.LogError("STEAM NOT INITIALIZED");
				}
				else
				{
					InitializeLobbyManagers();
				}
			}
		}

		public bool IsLocalPlayer(int playerId)
		{
			return _localPlayers.Any((NetworkPlayerScript p) => p.PlayerId == playerId);
		}

		public void OnPlayerClientStop(NetworkPlayerScript networkPlayer)
		{
			this.PlayerLeaving?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
		}

		public void OnPlayerJoin(NetworkPlayerScript networkPlayer)
		{
			_players.Add(networkPlayer);
			networkPlayer.transform.SetParent(_playersContainer);
			if (networkPlayer.IsServerPlayer)
			{
				if (ServerPlayer != null)
				{
					Debug.LogError($"Network player '{networkPlayer.Name}' (OwnerID: {networkPlayer.OwnerId}) just joined as a server player " + $"but the server player has already been assigned to network player '{ServerPlayer.Name}' (OwnerID: {ServerPlayer.OwnerId})");
				}
				ServerPlayer = networkPlayer;
			}
			bool isOwner = networkPlayer.IsOwner;
			if (isOwner)
			{
				_localPlayers.Add(networkPlayer);
				if (LocalPlayer == null)
				{
					if (_localPlayers.Count != 1)
					{
						Debug.LogError("A new local player has joined and become the primary local player but the list of local players != 1");
					}
					LocalPlayer = networkPlayer;
					networkPlayer.Initialize(this);
					this.PrimaryLocalPlayerChanged?.Invoke(this, new NetworkPlayerChangedEventArgs(null, networkPlayer));
				}
				else
				{
					networkPlayer.Initialize(this);
				}
				this.LocalPlayerJoined?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
			}
			else
			{
				_remotePlayers.Add(networkPlayer);
				networkPlayer.Initialize(this);
				this.RemotePlayerJoined?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
			}
			if (!isOwner || !Device.IsUnityEditor)
			{
				Debug.Log((isOwner ? "Local" : "Remote") + (networkPlayer.IsNPC ? " AI" : string.Empty) + " " + $"Player '{networkPlayer?.Name}' (ID: {networkPlayer.PlayerId}) joined the game on team {networkPlayer?.TeamId}.");
			}
			this.PlayerJoined?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
		}

		public void OnPlayerLeave(NetworkPlayerScript networkPlayer)
		{
			_players.Remove(networkPlayer);
			if (networkPlayer == ServerPlayer)
			{
				ServerPlayer = null;
			}
			bool isOwner = networkPlayer.IsOwner;
			if (isOwner)
			{
				_localPlayers.Remove(networkPlayer);
				if (LocalPlayer == networkPlayer)
				{
					NetworkPlayerScript newPlayer = (LocalPlayer = _localPlayers.Where((NetworkPlayerScript x) => !x.IsNPC).FirstOrDefault());
					this.PrimaryLocalPlayerChanged?.Invoke(this, new NetworkPlayerChangedEventArgs(networkPlayer, newPlayer));
				}
				this.LocalPlayerLeft?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
			}
			else
			{
				_remotePlayers.Remove(networkPlayer);
				this.RemotePlayerLeft?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
			}
			Debug.Log((isOwner ? "Local" : "Remote") + (networkPlayer.IsNPC ? " AI" : string.Empty) + " " + $"Player '{networkPlayer?.Name}' (ID: {networkPlayer.PlayerId}) left the game.");
			this.PlayerLeft?.Invoke(this, new NetworkPlayerEventArgs(networkPlayer));
		}

		public void OnPlayerServerStop(NetworkPlayerScript networkPlayer)
		{
		}

		public void StartLocalGame()
		{
			if (_shouldConnectAsClient)
			{
				NetworkManager.ClientManager.StartConnection();
				return;
			}
			_transportMultipass.SetClientTransport<Yak>();
			NetworkManager.ServerManager.StartConnection();
			NetworkManager.ClientManager.StartConnection();
		}

		public void StartSteamHost(string serverName)
		{
			Disconnect();
			InitializeSteamIfNecessary();
			SteamLobbyManager.CreateLobby(Assets.Scripts.Multiplayer.Lobbies.LobbyType.Public, 16, serverName, null);
		}

		protected virtual void OnDestroy()
		{
			if (SteamLobbyManager != null)
			{
				SteamLobbyManager.LobbyCreated -= OnSteamLobbyCreated;
				SteamLobbyManager.LobbyJoined -= OnSteamLobbyJoined;
				SteamLobbyManager.LobbyLeft -= OnSteamLobbyLeft;
				SteamLobbyManager.LobbyOwnerChanged -= OnSteamLobbyOwnerChanged;
				SteamLobbyManager.Dispose();
			}
			if (NetworkManager != null)
			{
				NetworkManager.ServerManager.OnServerConnectionState -= OnServerConnectionStateChanged;
				NetworkManager.ClientManager.OnClientConnectionState -= OnClientConnectionStateChanged;
			}
		}

		protected virtual void Update()
		{
			SteamLobbyManager?.Update();
			if (Device.IsUnityEditor && (DebugInput.GetKey(KeyCode.LeftAlt) || DebugInput.GetKey(KeyCode.RightAlt)))
			{
				int num = (DebugInput.GetKeyDown(KeyCode.PageUp) ? 1 : (DebugInput.GetKeyDown(KeyCode.PageDown) ? (-1) : 0));
				if (num != 0)
				{
					LatencySimulator latencySimulator = NetworkManager.TransportManager.LatencySimulator;
					long num2 = Math.Max(0L, latencySimulator.GetLatency() + 25 * num);
					latencySimulator.SetEnabled(num2 > 0);
					latencySimulator.SetLatency(num2);
					Debug.Log($"Simulating network latency: {num2}ms");
				}
			}
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
		{
			if (obj.ConnectionState == LocalConnectionState.Stopping && !_isApplicationQuitting && !_connectingUnityEditorCloneAsClient)
			{
				FlightSceneScript.Instance.ExitLevel();
			}
		}

		private void ConfigureSteamConnection(bool host, string hostSteamId)
		{
			if (NetworkManager.ServerManager.Started)
			{
				NetworkManager.ServerManager.StopConnection(sendDisconnectMessage: true);
			}
			if (NetworkManager.ClientManager.Started)
			{
				NetworkManager.ClientManager.StopConnection();
			}
			_shouldConnectAsClient = !host;
			_transportMultipass.SetClientTransport<global::FishySteamworks.FishySteamworks>();
			_transportMultipass.GetTransport<global::FishySteamworks.FishySteamworks>().SetClientAddress(host ? "localhost" : SteamLobbyManager.LobbyOwnerId.ToString());
		}

		private void ConnectUnityEditorCloneAsClient()
		{
			_transportMultipass.SetClientTransport<Tugboat>();
			NetworkManager.ClientManager.StartConnection();
			_connectingUnityEditorCloneAsClient = true;
		}

		private void Initialize()
		{
			NetworkManager = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkManager>("Multiplayer\\NetworkManager");
			NetworkManager.transform.SetParent(base.transform);
			if (!NetworkManager.IsServerStarted)
			{
				NetworkManager.ClientManager.OnClientConnectionState += ClientManager_OnClientConnectionState;
			}
			_transportMultipass = NetworkManager.TransportManager.Transport as Multipass;
			_playersContainer = new GameObject("NetworkPlayers").GetComponent<Transform>();
			_playersContainer.SetParent(base.transform, worldPositionStays: false);
			_players = new List<NetworkPlayerScript>();
			_localPlayers = new List<NetworkPlayerScript>();
			_remotePlayers = new List<NetworkPlayerScript>();
			TeamManager = new TeamManager(this);
			NetworkManager.ServerManager.OnServerConnectionState += OnServerConnectionStateChanged;
			NetworkManager.ClientManager.OnClientConnectionState += OnClientConnectionStateChanged;
			InitializeLobbyManagers();
			InitializeTemporaryStuffForDevelopmentPurposes();
		}

		private void InitializeLobbyManagers()
		{
			if (SocialExt.IsSteam && SteamLobbyManager == null)
			{
				SteamLobbyManager = new SteamLobbyManager();
				SteamLobbyManager.LobbyCreated += OnSteamLobbyCreated;
				SteamLobbyManager.LobbyJoined += OnSteamLobbyJoined;
				SteamLobbyManager.LobbyLeft += OnSteamLobbyLeft;
				SteamLobbyManager.LobbyOwnerChanged += OnSteamLobbyOwnerChanged;
			}
		}

		private void InitializeTemporaryStuffForDevelopmentPurposes()
		{
			_transportMultipass.SetClientTransport(1);
			DevConsoleApi.RegisterCommand("MP_Steam_Host", delegate(string serverName)
			{
				StartSteamHost(serverName);
			});
			DevConsoleApi.RegisterCommand("MP_Steam_Join", delegate(string serverName)
			{
				InitializeSteamIfNecessary();
				EventHandler<RequestLobbyListResultEventArgs> callback = null;
				callback = delegate(object sender, RequestLobbyListResultEventArgs e)
				{
					SocialExt.Steam.Multiplayer.RequestLobbyListResult -= callback;
					if (!e.Success)
					{
						Debug.LogError("Failed to request multiplayer lobbies from Steam");
					}
					else if (e.LobbyIds.Count == 0)
					{
						Debug.LogError("Unable to find the requested multiplayer lobby: " + serverName);
					}
					else if (e.LobbyIds.Count > 1)
					{
						Debug.LogError("More than one multiplayer lobby was found with name: " + serverName);
					}
					else
					{
						Disconnect();
						SteamLobbyManager.JoinLobby(e.LobbyIds[0], autoLoadScene: true, null);
					}
				};
				SocialExt.Steam.Multiplayer.RequestLobbyListResult += callback;
				LobbyFilters filters = new LobbyFilters
				{
					StringFilters = { ("ServerName", serverName, LobbyComparisonType.Equal) }
				};
				SocialExt.Steam.Multiplayer.RequestLobbyList(filters);
			});
			DevConsoleApi.RegisterCommand("MP_Steam_ServerBrowser", delegate
			{
				Game.Instance.UserInterface.CreateServerBrowserDialog();
			});
			DevConsoleApi.RegisterCommand("MP_Steam_Invite", delegate
			{
				if ((SteamLobbyManager?.LobbyId ?? 0) == 0L)
				{
					Debug.LogError("Unable to invite players to a lobby: no lobby is currently active");
				}
				else
				{
					SteamLobbyManager.OpenInviteFriendsDialog();
				}
			});
			DevConsoleApi.RegisterCommand("MP_Steam_GetLobbies", delegate
			{
				EventHandler<LobbyListEventArgs> callback = null;
				callback = delegate(object sender, LobbyListEventArgs e)
				{
					SteamLobbyManager.LobbyListReceived -= callback;
					foreach (LobbyData lobby in e.Lobbies)
					{
						Debug.Log("Lobby: " + lobby.Name + ", " + $"Players: ({lobby.Players}/{lobby.MaxPlayers}), " + $"Max Parts: {lobby.MaxCraftPartCount}, " + $"Ping: {lobby.Latency}ms, " + (Device.IsUnityEditor ? $"ReportCount: {lobby.ReportCount}, " : string.Empty) + $"LobbyId: {lobby.Id}");
					}
				};
				SteamLobbyManager.LobbyListReceived += callback;
				SteamLobbyManager.GetLobbyList(10, includeWorldwideLobbies: true, null);
			});
			DevConsoleApi.RegisterCommand("MP_Steam_GetLobbiesByName", delegate(string serverName)
			{
				EventHandler<LobbyListEventArgs> callback = null;
				callback = delegate(object sender, LobbyListEventArgs e)
				{
					SteamLobbyManager.LobbyListReceived -= callback;
					foreach (LobbyData lobby2 in e.Lobbies)
					{
						Debug.Log("Lobby: " + lobby2.Name + ", " + $"Players: ({lobby2.Players}/{lobby2.MaxPlayers}), " + $"Max Parts: {lobby2.MaxCraftPartCount}, " + $"Ping: {lobby2.Latency}ms, " + (Device.IsUnityEditor ? $"ReportCount: {lobby2.ReportCount}, " : string.Empty) + $"LobbyId: {lobby2.Id}");
					}
				};
				SteamLobbyManager.LobbyListReceived += callback;
				SteamLobbyManager.GetLobbyList(10, includeWorldwideLobbies: true, serverName);
			});
			DevConsoleApi.RegisterCommand("MP_Stats", delegate
			{
				if (NetworkManager.ClientManager.Started)
				{
					Transport clientTransport = _transportMultipass.ClientTransport;
					int mTU = clientTransport.GetMTU(0);
					int mTU2 = clientTransport.GetMTU(1);
					Debug.Log($"MTU: reliable = {mTU}, unreliable = {mTU2}");
					return "Connected via " + clientTransport.GetType().Name;
				}
				return "Not connected";
			});
			DevConsoleApi.RegisterCommand("MP_ClearCache", delegate
			{
				if (FlightSceneScript.Instance != null)
				{
					Debug.LogWarning("Cannot clear multiplayer cache in the flight scene");
				}
				else
				{
					Directory.Delete(NetworkAircraftLoader.CacheRootPath, recursive: true);
					Debug.Log("Deleted Path: " + NetworkAircraftLoader.CacheRootPath);
				}
			});
			DevConsoleApi.RegisterCommand("MP_ChangeName", delegate(string name)
			{
				LocalPlayer.ChangeName(name);
			});
		}

		private void OnClientConnectionStateChanged(ClientConnectionStateArgs args)
		{
			if (_logConnectionStateChanges)
			{
				Debug.Log($"Client connection state changed ({args.TransportIndex}): {args.ConnectionState}");
			}
			if (_connectingUnityEditorCloneAsClient)
			{
				if (args.ConnectionState == LocalConnectionState.Started)
				{
					Debug.Log("Unity editor clone successfully connected to the server as a client.");
					_connectingUnityEditorCloneAsClient = false;
				}
				else if (args.ConnectionState == LocalConnectionState.Stopped)
				{
					Debug.Log("Unity editor clone failed to connect to the server as a client. Retrying...");
					ConnectUnityEditorCloneAsClient();
				}
			}
		}

		private void OnServerConnectionStateChanged(ServerConnectionStateArgs args)
		{
			if (_logConnectionStateChanges)
			{
				Debug.Log($"Server connection state changed ({args.TransportIndex}): {args.ConnectionState}");
			}
		}

		private void OnSteamLobbyCreated(object sender, EventArgs e)
		{
			Game.Instance.SceneManager.LoadFlight();
			ConfigureSteamConnection(host: true, SocialExt.Steam.LocalUserId.ToString());
		}

		private async void OnSteamLobbyJoined(object sender, SteamLobbyJoinedEventArgs e)
		{
			if (!e.Success)
			{
				return;
			}
			if (e.AutoLoadScene)
			{
				SceneManager sceneManager = Game.Instance.SceneManager;
				if (sceneManager.SceneTransitionInProgress)
				{
					Debug.Log("Steam lobby join requested while a scene transition is in progress. Waiting for current scene transition to finish.");
					await UniTaskEx.WaitUntilWithTimeout(() => !sceneManager.SceneTransitionInProgress, 30000);
					Debug.Log("Scene transition finished. Continuing with Steam lobby join.");
				}
				Game.Instance.SceneManager.LoadFlight();
			}
			ConfigureSteamConnection(host: false, SteamLobbyManager.LobbyOwnerId.ToString());
		}

		private void OnSteamLobbyLeft(object sender, EventArgs e)
		{
			ConfigureSteamConnection(host: true, string.Empty);
		}

		private void OnSteamLobbyOwnerChanged(object sender, EventArgs e)
		{
			SteamLobbyManager.LeaveLobby();
		}
	}
}
