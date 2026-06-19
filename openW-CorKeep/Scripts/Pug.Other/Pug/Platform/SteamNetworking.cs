using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using PugMod;
using Steamworks;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport;
using UnityEngine;

namespace Pug.Platform
{
	[DisallowPatching]
	public class SteamNetworking : NetworkingInterface, IConnectionManager, ISocketManager
	{
		private struct EndPoint
		{
			public Connection Connection;

			public ulong SteamId;
		}

		private struct SideChannelMessage
		{
			public byte[] Data;

			public int DataOffset;

			public int DataLen;

			public byte Channel;
		}

		private struct StartSessionResult
		{
			public bool Success;

			public ServerConnectionInfo Session;

			public Lobby Lobby;
		}

		public struct ConnectResult
		{
			public bool Success;

			public string FailReason;

			public ServerConnectionInfo Session;

			public NetworkEndpoint NetworkEndPoint;

			public Lobby Lobby;
		}

		private struct AuthenticationData
		{
			public string playerID;

			public uint connectionID;
		}

		private ServerConnectionInfo _session;

		private bool _isInitialized;

		private SteamId _clientConnectedTo;

		private bool _isConnectedToHost;

		private bool _serverInitialized;

		private int _maxNumberPlayers;

		private SocketManager _socketManager;

		private CancellationTokenSource _cancellationTokenSource;

		private Task<StartSessionResult> _startSessionTask;

		private Lobby _lobby;

		private Task<ConnectResult> _connectTask;

		private CancellationToken _connectTaskCancellationToken;

		private Action<NetworkEndpoint?> _connectCallback;

		private List<QueuedSendMessage> _receivedMessages = new List<QueuedSendMessage>(64);

		private List<EndPoint> _endpoints = new List<EndPoint>();

		private List<EndPoint> _disconnectedEndpoints = new List<EndPoint>();

		private List<float> _disconnectedEndpointTimers = new List<float>();

		private Dictionary<ulong, UnsafeList<UnsafeList<byte>>> _partialSideChannelPackets = new Dictionary<ulong, UnsafeList<UnsafeList<byte>>>();

		private Action<NetworkEndpoint> _disconnectCallback;

		private Action<NetworkEndpoint, int, byte[]> _sideChannelCallback;

		private Action<bool> _startSessionCallback;

		private List<ulong> _bannedPlayers = new List<ulong>();

		private readonly int[] _lanePriorities = new int[2];

		private readonly ushort[] _laneWeights = new ushort[2] { 2, 1 };

		private readonly byte[] _okAuthResponse = Encoding.UTF8.GetBytes("OK");

		private Dictionary<ulong, Queue<SideChannelMessage>> _pendingSideChannelMessages = new Dictionary<ulong, Queue<SideChannelMessage>>();

		private byte[] _zeroByte = new byte[1];

		private readonly object _lock = new object();

		private ConnectionManager _connectionManager;

		private NetworkSubsetBase _currentNetworkSubset;

		private NetworkSubsetBase _standaloneNetworkSubset;

		private NetworkSubsetBase _steamNetworkSubset;

		private SteamSessionWrapper _steamSessionWrapper;

		public bool isInitialized => _isInitialized;

		public bool ConnectedToDedicatedServer => _currentNetworkSubset.ConnectedToDedicatedServer(_session);

		public bool CanSendInvites => false;

		public global::Platform AllowedPlatforms { get; private set; }

		public int MaxPlayersCount => _maxNumberPlayers;

		public ServerConnectionInfo CurrentSession => _session;

		private unsafe ulong SteamIdFromEndPoint(NetworkEndpoint endpoint)
		{
			NativeArray<byte> rawAddressBytes = endpoint.GetRawAddressBytes();
			UnsafeUtility.CopyPtrToStructure<ulong>(rawAddressBytes.GetUnsafePtr(), out var output);
			rawAddressBytes.Dispose();
			return output;
		}

		private ulong ConnectionIdFromEndPoint(NetworkEndpoint endpoint)
		{
			return SteamIdFromEndPoint(endpoint);
		}

		private ulong GetPlayerIdentifier(Connection connection, NetIdentity identity)
		{
			return identity.SteamId.Value;
		}

		private void OnDebugOutput(NetDebugOutput output, string s)
		{
			Debug.Log($"SteamNet {output}: {s}");
		}

		private async void CancelTask(Task task)
		{
			_cancellationTokenSource.Cancel();
			await task;
			_cancellationTokenSource = new CancellationTokenSource();
		}

		private void UpdateSessionTask()
		{
			if (_startSessionTask != null && _startSessionTask.IsCompleted)
			{
				StartSessionResult result = _startSessionTask.Result;
				_startSessionTask.Dispose();
				_startSessionTask = null;
				if (result.Success)
				{
					_currentNetworkSubset.SetPasswordFromSession(result.Session);
					_session = result.Session;
					_lobby = result.Lobby;
					_steamSessionWrapper.CreateSession();
					Debug.Log("Started session with info: " + CurrentSession.ToString());
					_startSessionCallback?.Invoke(obj: true);
				}
				else
				{
					Debug.Log("Failed to start session");
					_startSessionCallback?.Invoke(obj: false);
				}
			}
		}

		private void UpdateConnectTask()
		{
			if (_connectTask == null || !_connectTask.IsCompleted)
			{
				return;
			}
			ConnectResult result = _connectTask.Result;
			_connectTask.Dispose();
			_connectTask = null;
			if (result.Success)
			{
				_clientConnectedTo = _endpoints[0].SteamId;
				_isConnectedToHost = true;
				_lobby = result.Lobby;
				_session = result.Session;
				_steamSessionWrapper.JoinSession(result.Session.IPPort);
				_currentNetworkSubset.SetPasswordFromSession(result.Session);
				_connectCallback?.Invoke(result.NetworkEndPoint);
			}
			else
			{
				Manager.networking.connectionFailedReason = result.FailReason;
				if (_isConnectedToHost)
				{
					_disconnectCallback?.Invoke(_currentNetworkSubset.EndPointFromSteamId(_clientConnectedTo));
					_clientConnectedTo = default(SteamId);
					_isConnectedToHost = false;
				}
				else
				{
					_connectCallback?.Invoke(null);
				}
				Disconnect();
			}
		}

		public bool Initialize(Action<NetworkEndpoint> disconnectCallback, Action<NetworkEndpoint, int, byte[]> sideChannelCallback, bool useDirectConnection, global::Platform currentPlatform)
		{
			if (!SteamClient.IsValid)
			{
				Debug.Log("Not initializing Steam network since no Steam API available");
				return false;
			}
			_steamSessionWrapper = new SteamSessionWrapper();
			AllowedPlatforms = currentPlatform;
			SteamNetworkingUtils.DebugLevel = (CommandLineArgs.Has("-extralog") ? NetDebugOutput.Everything : NetDebugOutput.Important);
			SteamNetworkingUtils.OnDebugOutput += OnDebugOutput;
			_cancellationTokenSource = new CancellationTokenSource();
			_disconnectCallback = disconnectCallback;
			_sideChannelCallback = sideChannelCallback;
			_steamNetworkSubset = new SteamNetworkSubset(_lock, IsUserBanned);
			_standaloneNetworkSubset = new StandaloneNetworkingSubset(_lock, IsUserBanned);
			SetCurrentSubset(useDirectConnection: false);
			SteamNetworkingUtils.InitRelayNetworkAccess();
			SteamNetworkingSockets.InitAuthentication();
			_isInitialized = true;
			UnityMainThreadDispatcher.Instance().Enqueue(UpdateNetworking());
			return true;
		}

		public void Deinitialize()
		{
			if (_isInitialized)
			{
				_steamSessionWrapper.Dispose();
				_steamSessionWrapper = null;
				StopListening();
				SteamNetworkingUtils.OnDebugOutput -= OnDebugOutput;
				if (_startSessionTask != null)
				{
					CancelTask(_startSessionTask);
					UpdateSessionTask();
				}
				if (_connectTask != null)
				{
					CancelTask(_connectTask);
					UpdateConnectTask();
				}
				_isInitialized = false;
			}
		}

		public NetworkEndpoint GetLocalEndpoint()
		{
			return _currentNetworkSubset.EndPointFromSteamId(_currentNetworkSubset.MySteamID.Value);
		}

		public bool IsValidConnectionAddress(ServerConnectionInfo connectionInfo)
		{
			if (string.IsNullOrEmpty(connectionInfo.GameID) || connectionInfo.GameID.Length < 14)
			{
				return connectionInfo.JoinedWithIP;
			}
			return true;
		}

		public bool StartListening()
		{
			if (!_isInitialized)
			{
				return false;
			}
			try
			{
				Debug.Log($"Listening on SteamID userid:{_steamNetworkSubset.MySteamID}");
				_socketManager = SteamNetworkingSockets.CreateRelaySocket(0, this);
				_serverInitialized = true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
			return true;
		}

		public void StopListening()
		{
			for (int i = 0; i < _endpoints.Count; i++)
			{
				_endpoints[i].Connection.Close();
			}
			if (_serverInitialized)
			{
				_socketManager.Close();
				_serverInitialized = false;
			}
			ResetAllSideChannelState();
			_socketManager = null;
			_pendingSideChannelMessages.Clear();
		}

		public bool StartSession(ServerConnectionInfo connectionInfo, int maxNumberPlayers, Action<bool> callback)
		{
			if (!_isInitialized)
			{
				return false;
			}
			_maxNumberPlayers = maxNumberPlayers;
			if (_startSessionTask != null)
			{
				StopSession();
			}
			SetCurrentSubset(connectionInfo.JoinedWithIP);
			if (connectionInfo.JoinedWithIP)
			{
				SteamNetworkingUtils.AllowWithoutAuth = 1;
			}
			try
			{
				_startSessionTask = StartSessionTask(_cancellationTokenSource.Token, connectionInfo, _currentNetworkSubset.MySteamID);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
			_startSessionCallback = callback;
			return true;
		}

		private async Task<StartSessionResult> StartSessionTask(CancellationToken cancellationToken, ServerConnectionInfo connectionInfo, SteamId mySteamId)
		{
			StartSessionResult result = default(StartSessionResult);
			await Task.Delay(1);
			Task<Lobby?> createLobbyTask = SteamMatchmaking.CreateLobbyAsync(LobbyType.Private, 250);
			await Task.WhenAny(createLobbyTask, Task.Delay(-1, cancellationToken));
			if (cancellationToken.IsCancellationRequested)
			{
				createLobbyTask.ContinueWith(delegate(Task<Lobby?> task)
				{
					task.Result?.Leave();
				});
				Debug.Log("create session canceled after create lobby");
				return result;
			}
			if (!createLobbyTask.Result.HasValue)
			{
				Debug.LogError("start session failed to create lobby");
				return result;
			}
			Lobby lobby = (result.Lobby = createLobbyTask.Result.Value);
			lobby.SetGameServer(mySteamId);
			result.Session = NetworkSubsetBase.CreateLobbyID(lobby.Id.AccountId);
			if (!lobby.SetJoinable(b: true))
			{
				Debug.LogError("Failed to set lobby joinable");
				lobby.Leave();
				return result;
			}
			result.Success = true;
			return result;
		}

		public void StopSession()
		{
			if (_isInitialized && _session.IsValid())
			{
				if (_startSessionTask != null)
				{
					CancelTask(_startSessionTask);
					UpdateSessionTask();
				}
				if ((ulong)_lobby.Id != 0L)
				{
					_lobby.Leave();
					_lobby = default(Lobby);
				}
				_steamSessionWrapper.StopSession();
				_session = default(ServerConnectionInfo);
			}
		}

		public void UpdateSession(string session)
		{
			_session.CopyData(ServerConnectionInfo.UnPackConnectionID(session));
			_currentNetworkSubset.SetPasswordFromSession(_session);
		}

		public void UpdateSession(string session, int maxPlayerCount)
		{
			UpdateSession(session);
			_steamSessionWrapper.UpdateSessionInfo(maxPlayerCount);
		}

		public void RecreateGameId(Action<bool> restartSessionCallback)
		{
			if (isInitialized && _session.IsValid())
			{
				ServerConnectionInfo session = _session;
				session.GameID = null;
				if (session.SupportsDirectConnection)
				{
					session.Password = null;
				}
				StopSession();
				if (!StartSession(session, Manager.prefs.serverMaxNumberPlayers, restartSessionCallback))
				{
					Debug.LogError("Failed to restart session");
				}
				_steamSessionWrapper.UpdateSessionInfo(_maxNumberPlayers);
			}
		}

		public void Connect(ServerConnectionInfo connectionInfo, Action<NetworkEndpoint?> callback)
		{
			if (!_isInitialized)
			{
				Manager.networking.connectionFailedReason = "Error/NoNetwork";
				Manager.networking.connectionFailed = true;
				callback?.Invoke(null);
				return;
			}
			if (_connectTask != null)
			{
				Disconnect();
			}
			_connectCallback = callback;
			SetCurrentSubset(connectionInfo.JoinedWithIP);
			_currentNetworkSubset.SetPasswordFromSession(connectionInfo);
			_connectTask = StartConnectTask(_cancellationTokenSource.Token, connectionInfo);
		}

		private async Task<ConnectResult> StartConnectTask(CancellationToken cancellationToken, ServerConnectionInfo session)
		{
			ConnectResult result = default(ConnectResult);
			await Task.Delay(1);
			Manager.networking.connectionFailedReason = null;
			if (_session.IsValid())
			{
				Debug.LogError("Trying to connect when session is already set");
				result.FailReason = "Error/Unknown";
				return result;
			}
			_currentNetworkSubset.AuthenticatePlayer();
			SteamNetworkingUtils.AllowWithoutAuth = 0;
			try
			{
				result = await _currentNetworkSubset.Connect(session, cancellationToken);
				if (!string.IsNullOrEmpty(result.FailReason))
				{
					return result;
				}
				int i = 0;
				while (i < 7)
				{
					lock (_lock)
					{
						if (_connectionManager != null)
						{
							_connectionManager.Close();
							_connectionManager = null;
						}
					}
					try
					{
						await Task.Delay(1000 * i, cancellationToken);
					}
					catch
					{
						break;
					}
					if (cancellationToken.IsCancellationRequested)
					{
						break;
					}
					ConnectionManager connectionManager = _currentNetworkSubset.TryConnect(this, ref result);
					if (!string.IsNullOrEmpty(result.FailReason))
					{
						return result;
					}
					lock (_lock)
					{
						_connectionManager = connectionManager;
					}
					while (IsConnecting() && !cancellationToken.IsCancellationRequested)
					{
						await Task.Delay(100);
					}
					if (cancellationToken.IsCancellationRequested)
					{
						break;
					}
					int num;
					if (!IsConnected())
					{
						Debug.Log("connection failed or canceled");
						result.FailReason = "Error/ConnectionClose";
					}
					else
					{
						int _ = 0;
						while (_ < 100 && !cancellationToken.IsCancellationRequested && IsConnected() && !IsAuthenticated())
						{
							await Task.Delay(100);
							num = _ + 1;
							_ = num;
						}
						if (IsAuthenticated())
						{
							result.Session = session;
							result.Success = true;
							break;
						}
						Debug.Log("Client didn't get authentication response");
						result.FailReason = "Error/AuthenticationFailed";
					}
					num = i + 1;
					i = num;
				}
				if (cancellationToken.IsCancellationRequested)
				{
					Debug.Log("connect canceled during connect");
					result.FailReason = "Error/ConnectionClose";
					return result;
				}
				return result;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return result;
			}
		}

		private bool IsConnecting()
		{
			lock (_lock)
			{
				return _connectionManager != null && _connectionManager.Connecting;
			}
		}

		private bool IsAuthenticated()
		{
			return _currentNetworkSubset.IsAuthenticated();
		}

		private void SetAuthenticated(bool setTrue)
		{
			_currentNetworkSubset.SetAuthenticated(setTrue);
		}

		private bool IsConnected()
		{
			lock (_lock)
			{
				return _connectionManager != null && _connectionManager.Connected;
			}
		}

		public void Disconnect()
		{
			Disconnect(resetSideChannel: true);
		}

		public void Disconnect(bool resetSideChannel)
		{
			if (!_isInitialized)
			{
				return;
			}
			if (_connectTask != null)
			{
				Debug.Log("aborting connect");
				CancelTask(_connectTask);
				UpdateConnectTask();
			}
			if ((ulong)_lobby.Id != 0L)
			{
				_lobby.Leave();
				_lobby = default(Lobby);
			}
			lock (_lock)
			{
				if (_connectionManager != null && _isConnectedToHost)
				{
					Debug.Log("closing current connection");
					_connectionManager.Close();
					_connectionManager = null;
				}
				SetAuthenticated(setTrue: false);
			}
			_steamSessionWrapper.StopSession();
			_clientConnectedTo = default(SteamId);
			_isConnectedToHost = false;
			_session = default(ServerConnectionInfo);
			if (resetSideChannel)
			{
				ResetAllSideChannelState();
				_pendingSideChannelMessages.Clear();
			}
		}

		private IEnumerator UpdateNetworking()
		{
			while (isInitialized)
			{
				UpdateSessionTask();
				UpdateConnectTask();
				for (int i = 0; i < _disconnectedEndpoints.Count; i++)
				{
					_disconnectedEndpointTimers[i] -= Time.deltaTime;
					if (_disconnectedEndpointTimers[i] <= 0f)
					{
						ulong steamId = _disconnectedEndpoints[i].SteamId;
						if (_pendingSideChannelMessages.ContainsKey(steamId))
						{
							_pendingSideChannelMessages.Remove(steamId);
						}
						_disconnectCallback?.Invoke(_currentNetworkSubset.EndPointFromSteamId(steamId));
						_disconnectedEndpoints.RemoveAt(i);
						_disconnectedEndpointTimers.RemoveAt(i);
						i--;
					}
				}
				try
				{
					if (_serverInitialized)
					{
						_socketManager.Receive();
					}
					lock (_lock)
					{
						if (_connectionManager != null)
						{
							_connectionManager.Receive();
						}
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				SendPendingSideChannelMessages();
				yield return null;
			}
			Debug.Log("SteamNetworking: exiting UpdateNetworking");
		}

		public void Update()
		{
			_steamSessionWrapper.Update();
		}

		public unsafe void SendMessages(NativeQueue<QueuedSendMessage> messages)
		{
			if (!isInitialized)
			{
				messages.Clear();
				return;
			}
			QueuedSendMessage item;
			while (messages.TryDequeue(out item))
			{
				ulong num = ConnectionIdFromEndPoint(item.Dest);
				foreach (EndPoint endpoint in _endpoints)
				{
					if (_clientConnectedTo.IsValid || endpoint.SteamId == num)
					{
						Connection connection = endpoint.Connection;
						connection.SendMessage((IntPtr)item.Data, item.DataLength, SendType.NoDelay, 0);
						break;
					}
				}
			}
			foreach (EndPoint endpoint2 in _endpoints)
			{
				endpoint2.Connection.Flush();
			}
		}

		public void ReceiveMessages(NativeQueue<QueuedSendMessage> messages)
		{
			if (isInitialized)
			{
				for (int i = 0; i < _receivedMessages.Count; i++)
				{
					messages.Enqueue(_receivedMessages[i]);
				}
				_receivedMessages.Clear();
			}
		}

		public void SendSideChannelMessage(NetworkEndpoint dest, int sideChannel, byte[] packet)
		{
			if (isInitialized)
			{
				int num = 0;
				int num2;
				for (num2 = packet.Length; num2 >= 1200; num2 -= 1200)
				{
					SendPartialSideChannelMessage(dest, (byte)sideChannel, packet, num, 1200);
					num += 1200;
				}
				if (num2 == 0)
				{
					SendPartialSideChannelMessage(dest, (byte)sideChannel, _zeroByte, 0, _zeroByte.Length);
				}
				else
				{
					SendPartialSideChannelMessage(dest, (byte)sideChannel, packet, num, num2);
				}
			}
		}

		private void SendPartialSideChannelMessage(NetworkEndpoint dest, byte channel, byte[] data, int offset, int len)
		{
			ulong key = ConnectionIdFromEndPoint(dest);
			if (!_pendingSideChannelMessages.ContainsKey(key))
			{
				_pendingSideChannelMessages.Add(key, new Queue<SideChannelMessage>());
			}
			_pendingSideChannelMessages[key].Enqueue(new SideChannelMessage
			{
				Channel = channel,
				Data = data,
				DataOffset = offset,
				DataLen = len
			});
		}

		private unsafe void SendPendingSideChannelMessages()
		{
			foreach (KeyValuePair<ulong, Queue<SideChannelMessage>> pendingSideChannelMessage in _pendingSideChannelMessages)
			{
				ulong key = pendingSideChannelMessage.Key;
				Queue<SideChannelMessage> value = pendingSideChannelMessage.Value;
				foreach (EndPoint endpoint in _endpoints)
				{
					if (!_clientConnectedTo.IsValid && endpoint.SteamId != key)
					{
						continue;
					}
					while (value.Count > 0)
					{
						SideChannelMessage sideChannelMessage = value.Peek();
						Result result;
						fixed (byte* data = sideChannelMessage.Data)
						{
							Connection connection = endpoint.Connection;
							result = connection.SendMessage((IntPtr)(data + sideChannelMessage.DataOffset), sideChannelMessage.DataLen, SendType.Reliable, sideChannelMessage.Channel);
						}
						switch (result)
						{
						default:
							Debug.LogError($"side channel got send error {result}");
							goto end_IL_00f7;
						case Result.OK:
							break;
						case Result.LimitExceeded:
						case Result.RateLimitExceeded:
							goto end_IL_00f7;
						}
						value.Dequeue();
						continue;
						end_IL_00f7:
						break;
					}
					break;
				}
			}
		}

		public string GetConnectionId(NetworkEndpoint endpoint)
		{
			return ConnectionIdFromEndPoint(endpoint).ToString();
		}

		public void SetAdmin(NetworkEndpoint endpoint, ref PlayerAdminEntry adminEntry)
		{
			ulong steamId = SteamIdFromEndPoint(endpoint);
			adminEntry.steamId = steamId;
		}

		public void InitializeBan(PlayerBanEntry playerBanEntry)
		{
			_bannedPlayers.Add(playerBanEntry.steamId);
		}

		public void BanPlayer(NetworkEndpoint endpoint, ref PlayerBanEntry playerBanEntry)
		{
			ulong num = SteamIdFromEndPoint(endpoint);
			_bannedPlayers.Add(num);
			playerBanEntry.steamId = num;
			ulong num2 = ConnectionIdFromEndPoint(endpoint);
			foreach (EndPoint endpoint2 in _endpoints)
			{
				if (endpoint2.SteamId == num2)
				{
					Connection connection = endpoint2.Connection;
					connection.Close(linger: false, 0, "Banned");
				}
			}
		}

		public void UnbanPlayer(PlayerBanEntry playerBanEntry)
		{
			if (!_bannedPlayers.Contains(playerBanEntry.steamId))
			{
				Debug.LogError($"Trying to remove steam id userid:{playerBanEntry.steamId} not in ban list");
			}
			else
			{
				_bannedPlayers.Remove(playerBanEntry.steamId);
			}
		}

		private bool IsUserBanned(ulong playerID)
		{
			foreach (ulong bannedPlayer in _bannedPlayers)
			{
				if (playerID == bannedPlayer)
				{
					return true;
				}
			}
			return false;
		}

		public bool EntryMatchesEndpoint(PlayerBanEntry entry, NetworkEndpoint endpoint)
		{
			return entry.steamId == SteamIdFromEndPoint(endpoint);
		}

		public bool EntryMatchesEndpoint(PlayerAdminEntry entry, NetworkEndpoint endpoint)
		{
			return entry.steamId == SteamIdFromEndPoint(endpoint);
		}

		public void StartSessionInvitationFlow()
		{
			_steamSessionWrapper.StartSessionInivitationFlow();
		}

		public void SendSessionInvitations(List<PlatformUserID> invitees, Action<bool> callback)
		{
		}

		public bool CheckSessionValidity(string sessionId)
		{
			return true;
		}

		public int GetPing()
		{
			lock (_lock)
			{
				if (_connectionManager == null || !_connectionManager.Connected)
				{
					return 0;
				}
				return _connectionManager.Connection.QuickStatus().Ping;
			}
		}

		public void OnConnecting(ConnectionInfo info)
		{
			Debug.Log("Client connecting to userid:" + info.Identity.SteamId.ToString());
		}

		public unsafe void OnConnected(ConnectionInfo info)
		{
			Debug.Log("Client connected to userid:" + info.Identity.SteamId.ToString());
			lock (_lock)
			{
				if (_connectionManager == null)
				{
					return;
				}
				_connectionManager.Connection.ConfigureConnectionLanes(_lanePriorities, _laneWeights);
				_endpoints.Add(new EndPoint
				{
					Connection = _connectionManager.Connection,
					SteamId = info.Identity.SteamId
				});
				if (!IsAuthenticated())
				{
					byte[] array = _currentNetworkSubset.AuthenticationMessage();
					fixed (byte* ptr = array)
					{
						Result result = _connectionManager.Connection.SendMessage((IntPtr)ptr, array.Length, SendType.NoNagle | SendType.NoDelay | SendType.Reliable, 0);
						Debug.Log($"Sending authentication message with result {result}");
						_connectionManager.Connection.Flush();
					}
				}
			}
		}

		public void OnDisconnected(ConnectionInfo info)
		{
			Debug.Log("Client got disconnect from userid:" + info.Identity.SteamId.ToString() + " with reason:" + info.EndReason);
			if (_endpoints.Count == 0)
			{
				return;
			}
			_endpoints[0].Connection.Close();
			if (_isConnectedToHost)
			{
				if (info.EndReason >= NetConnectionEnd.App_Min && info.EndReason <= NetConnectionEnd.App_Max)
				{
					Disconnect(resetSideChannel: true);
					_disconnectCallback?.Invoke(_currentNetworkSubset.EndPointFromSteamId(_endpoints[0].SteamId));
				}
				else
				{
					ServerConnectionInfo session = _session;
					Disconnect(resetSideChannel: false);
					Connect(session, null);
				}
			}
			else
			{
				_endpoints.Clear();
			}
		}

		public unsafe void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int lane)
		{
			if (_endpoints.Count == 0)
			{
				return;
			}
			if (!IsAuthenticated())
			{
				fixed (byte* okAuthResponse = _okAuthResponse)
				{
					if (size == _okAuthResponse.Length && UnsafeUtility.MemCmp((void*)data, okAuthResponse, _okAuthResponse.Length) == 0)
					{
						Debug.Log("Got OK authentication response");
						Manager.networking.connectionFailedReason = null;
						SetAuthenticated(setTrue: true);
					}
					else
					{
						Manager.networking.connectionFailedReason = "Error/Unknown";
						Debug.LogWarning("Got wrong authentication response");
					}
				}
			}
			else
			{
				OnMessage(_endpoints[0].Connection, (SteamId)_endpoints[0].SteamId, data, size, messageNum, recvTime, lane);
			}
		}

		public void OnConnecting(Connection connection, ConnectionInfo info)
		{
			if (_endpoints.Count >= _maxNumberPlayers)
			{
				Debug.Log($"Rejecting player with userid:{info.Identity.SteamId.Value} since player limit has been reached");
				connection.Close(linger: false, 0, "PlayerLimit");
				return;
			}
			if (IsUserBanned(info.Identity.SteamId.Value))
			{
				connection.Close(linger: false, 0, "Banned");
				return;
			}
			Task.Run(async delegate
			{
				await Task.Delay(1000);
				if ((ulong)_lobby.Id == 0L)
				{
					Debug.Log($"Rejecting player with userid:{info.Identity.SteamId.Value}: lobby not set");
					connection.Close(linger: false, 0, "NoLobby");
				}
				else
				{
					bool flag = false;
					foreach (Friend member in _lobby.Members)
					{
						if (member.Id.Value == info.Identity.SteamId.Value)
						{
							Debug.Log("Found connecting player in lobby, verifying authentication");
							string memberData = _lobby.GetMemberData(member, "hmac");
							if (!string.IsNullOrEmpty(memberData))
							{
								using (HMACSHA256 hMACSHA = new HMACSHA256(_currentNetworkSubset.PasswordBytes))
								{
									Encoding uTF = Encoding.UTF8;
									SteamId id = member.Id;
									byte[] array = hMACSHA.ComputeHash(uTF.GetBytes(id.ToString()));
									byte[] array2 = Convert.FromBase64String(memberData);
									if (array2.Length != array.Length)
									{
										Debug.Log($"Got wrong length hmac from connecting player {array2.Length} should be {array.Length}");
										continue;
									}
									int i;
									for (i = 0; i < array.Length && array2[i] == array[i]; i++)
									{
									}
									if (i != array.Length)
									{
										Debug.Log("Got bad hmac from connecting player");
										continue;
									}
									flag = true;
								}
								break;
							}
							Debug.Log("Connecting player has no hmac set");
						}
					}
					if (flag)
					{
						Result result = connection.Accept();
						Debug.Log("Accepted connection from userid:" + info.Identity.SteamId.Value + " with result " + result);
					}
					else
					{
						Debug.Log("Rejected connection from userid:" + info.Identity.SteamId.Value);
						connection.Close();
					}
				}
			});
		}

		public void OnConnected(Connection connection, ConnectionInfo info)
		{
			ulong playerIdentifier = GetPlayerIdentifier(connection, info.Identity);
			Debug.Log("Connected to userid:" + playerIdentifier);
			connection.ConfigureConnectionLanes(_lanePriorities, _laneWeights);
			int num;
			for (num = _disconnectedEndpoints.Count - 1; num >= 0; num--)
			{
				EndPoint item = _disconnectedEndpoints[num];
				if (item.SteamId == playerIdentifier)
				{
					item.Connection = connection;
					_endpoints.Add(item);
					_disconnectedEndpoints.RemoveAt(num);
					_disconnectedEndpointTimers.RemoveAt(num);
					break;
				}
			}
			if (num == -1)
			{
				_endpoints.Add(new EndPoint
				{
					Connection = connection,
					SteamId = playerIdentifier
				});
			}
		}

		public void OnDisconnected(Connection connection, ConnectionInfo info)
		{
			ulong playerIdentifier = GetPlayerIdentifier(connection, info.Identity);
			Debug.Log("Disconnected from userid:" + playerIdentifier + " with reason " + info.EndReason);
			if (info.EndReason < NetConnectionEnd.App_Min || info.EndReason > NetConnectionEnd.App_Max)
			{
				Debug.Log("Waiting for reconnection.");
				for (int i = 0; i < _endpoints.Count; i++)
				{
					if (_endpoints[i].SteamId == playerIdentifier)
					{
						_disconnectedEndpoints.Add(_endpoints[i]);
						_disconnectedEndpointTimers.Add(30f);
						_endpoints.RemoveAtSwapBack(i);
						break;
					}
				}
			}
			else
			{
				for (int j = 0; j < _endpoints.Count; j++)
				{
					if (_endpoints[j].SteamId == playerIdentifier)
					{
						Debug.Log("Removed endpoint.");
						_disconnectCallback?.Invoke(_currentNetworkSubset.EndPointFromSteamId(playerIdentifier));
						_endpoints.RemoveAtSwapBack(j);
						if (_pendingSideChannelMessages.ContainsKey(playerIdentifier))
						{
							_pendingSideChannelMessages.Remove(playerIdentifier);
						}
						ResetSideChannelState(playerIdentifier);
						break;
					}
					if (j == _endpoints.Count - 1)
					{
						Debug.LogError("Didn't find endpoint from list. Id: " + playerIdentifier);
					}
				}
			}
			connection.Close();
		}

		private void ResetAllSideChannelState()
		{
			foreach (KeyValuePair<ulong, UnsafeList<UnsafeList<byte>>> partialSideChannelPacket in _partialSideChannelPackets)
			{
				UnsafeList<UnsafeList<byte>> value = partialSideChannelPacket.Value;
				for (int i = 1; i < value.Length; i++)
				{
					value[i].Dispose();
				}
				value.Dispose();
			}
			_partialSideChannelPackets.Clear();
		}

		private void ResetSideChannelState(ulong steamId)
		{
			if (_partialSideChannelPackets.ContainsKey(steamId))
			{
				UnsafeList<UnsafeList<byte>> unsafeList = _partialSideChannelPackets[steamId];
				for (int i = 1; i < unsafeList.Length; i++)
				{
					unsafeList[i].Dispose();
				}
				unsafeList.Dispose();
				_partialSideChannelPackets.Remove(steamId);
			}
		}

		private unsafe void HandleSideChannelMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int lane)
		{
			ulong playerIdentifier = GetPlayerIdentifier(connection, identity);
			if (lane > 1)
			{
				Debug.LogError($"invalid side channel {lane}");
				return;
			}
			UnsafeList<UnsafeList<byte>> value;
			if (!_partialSideChannelPackets.ContainsKey(playerIdentifier))
			{
				value = new UnsafeList<UnsafeList<byte>>(2, Allocator.Persistent);
				value.AddNoResize(default(UnsafeList<byte>));
				for (int i = 1; i < value.Capacity; i++)
				{
					value.AddNoResize(new UnsafeList<byte>(1048576, Allocator.Persistent));
				}
				_partialSideChannelPackets.Add(playerIdentifier, value);
			}
			else
			{
				value = _partialSideChannelPackets[playerIdentifier];
			}
			UnsafeList<byte> value2 = value[lane];
			int length = value2.Length;
			value2.Resize(value2.Length + size);
			UnsafeUtility.MemCpy(value2.Ptr + length, (void*)data, size);
			if (size < 1200)
			{
				byte[] array = new byte[value2.Length];
				fixed (byte* destination = array)
				{
					UnsafeUtility.MemCpy(destination, value2.Ptr, value2.Length);
				}
				value2.Resize(0);
				_sideChannelCallback(_currentNetworkSubset.EndPointFromSteamId(playerIdentifier), lane, array);
			}
			value[lane] = value2;
		}

		public unsafe void OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int lane)
		{
			ulong playerIdentifier = GetPlayerIdentifier(connection, identity);
			if (lane > 0)
			{
				HandleSideChannelMessage(connection, identity, data, size, messageNum, recvTime, lane);
				return;
			}
			QueuedSendMessage item = new QueuedSendMessage
			{
				Source = _currentNetworkSubset.EndPointFromSteamId(playerIdentifier),
				DataLength = size
			};
			UnsafeUtility.MemCpy(item.Data, (void*)data, size);
			_receivedMessages.Add(item);
		}

		private void SetCurrentSubset(bool useDirectConnection)
		{
			_currentNetworkSubset = (useDirectConnection ? _standaloneNetworkSubset : _steamNetworkSubset);
		}
	}
}
