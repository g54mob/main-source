using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using I2.Loc;
using PartyCSharpSDK;
using PimDeWitte.UnityMainThreadDispatcher;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Multiplayer;
using PlayFab.Party;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Networking.Transport;
using UnityEngine;

public class PlayFabPartyNetworking : NetworkingInterface
{
	private class SessionRecreationState
	{
		public bool WasExited;
	}

	private enum MessageType
	{
		Unknown = 0,
		MainChannel = 1,
		SideChannel = 2,
		Kick = 3,
		Accept = 4,
		SharePlatformSessionId = 5,
		Disconnect = 6
	}

	private struct MessageBuilder
	{
		private const int HEADER_SIZE = 4;

		private const int PAYLOAD_START = 4;

		private byte[] Buffer;

		private int Length;

		public MessageBuilder(int initialPayloadSize)
		{
			Buffer = new byte[initialPayloadSize + 4];
			Length = 0;
		}

		public readonly void GetMessageData(out byte[] data, out uint length)
		{
			data = Buffer;
			length = (uint)Length;
		}

		public void ConstructNewMessage(MessageType type, byte[] payload)
		{
			Length = 4 + payload.Length;
			EnsureFreeCapacity(Length);
			SetMessageType(type);
			SetPayload(payload);
		}

		public unsafe void ConstructNewMessage(MessageType type, byte* payloadPtr, int payloadSize)
		{
			Length = 4 + payloadSize;
			EnsureFreeCapacity(Length);
			SetMessageType(type);
			SetPayload(payloadPtr, payloadSize);
		}

		private void SetMessageType(MessageType type)
		{
			BitConverter.TryWriteBytes(Buffer, (int)type);
		}

		private void SetPayload(byte[] payload)
		{
			Array.Copy(payload, 0, Buffer, 4, payload.Length);
		}

		private unsafe void SetPayload(byte* payloadPtr, int payloadSize)
		{
			Marshal.Copy((IntPtr)payloadPtr, Buffer, 4, payloadSize);
		}

		private void EnsureFreeCapacity(int newSize)
		{
			if (newSize > Buffer.Length)
			{
				int newSize2 = math.ceilpow2(newSize);
				Array.Resize(ref Buffer, newSize2);
			}
		}
	}

	private static readonly HashSet<int> PLAYFAB_EXPECTED_ERRORS = new HashSet<int> { 6, 4379 };

	private static readonly Dictionary<int, string> PLAYFAB_RECONNECT_ERRORS = new Dictionary<int, string>
	{
		{ 1, "Error/Unknown" },
		{ 4, "Error/Unknown" },
		{ 11, "Error/Unknown" },
		{ 63, "Error/ConnectionLost" },
		{ 73, "Error/ConnectionLost" },
		{ 4102, "Consoles/SessionJoinFailed" },
		{ 4330, "Error/Unknown" },
		{ 4331, "Error/Unknown" },
		{ 4332, "Error/Unknown" },
		{ 4333, "Error/Unknown" }
	};

	private static readonly Dictionary<int, string> PLAYFAB_EXIT_ERRORS = new Dictionary<int, string>
	{
		{ 2, "Error/Unknown" },
		{ 4163, "Error/GameNotFound" },
		{ 4237, "Consoles/SessionFull" },
		{ 4250, "Error/GameNotFound" },
		{ 12324, "Error/Timeout" }
	};

	private const int RECONNECT_TIMEOUT_S = 15;

	private const int RECONNECT_TIMEOUT_REMOTE_PLAYER_S = 30;

	private Action<NetworkEndpoint> _disconnectCallback;

	private Action<NetworkEndpoint, int, byte[]> _sideChannelCallback;

	private Action<NetworkEndpoint?> _joinSessionCallback;

	private PlayFabMultiplayerManager _playfabPartyManager;

	private PlayFabPartySessionWrapper _playfabSession;

	private bool _registeredToPlayFabEvents;

	private bool _suspending;

	private List<QueuedSendMessage> _receivedMessages = new List<QueuedSendMessage>(64);

	private PlayFabPlayer[] _singleMessageDestination;

	private MessageBuilder _reusableMessageBuilder = new MessageBuilder(256);

	private PlayFabPlayer _serverPlayer;

	private List<PlayFabEndPoint> _endpoints = new List<PlayFabEndPoint>();

	private List<PlayFabEndPoint> _sideChannelEndPoints = new List<PlayFabEndPoint>();

	private Dictionary<NetworkEndpoint, ulong> _endpointToPlayFabPlayerIdCache = new Dictionary<NetworkEndpoint, ulong>();

	private List<PlayerBanEntry> _bannedPlayers = new List<PlayerBanEntry>();

	private List<string> _reconnectingPlayers = new List<string>();

	private List<float> _reconnectTimeouts = new List<float>();

	private PlayFabPlayer _reconnectingServerPlayer;

	private SessionRecreationState _sessionRecreationState;

	private bool _reconnectPopupActive;

	public ServerConnectionInfo CurrentSession => new ServerConnectionInfo
	{
		GameID = _playfabSession?.SessionUID
	};

	public bool isInitialized { get; private set; }

	public bool ConnectedToDedicatedServer => false;

	public bool CanSendInvites => false;

	public Platform AllowedPlatforms { get; private set; }

	public int MaxPlayersCount => (int)_playfabSession.MaxPlayerCount;

	public static bool Suspended { get; private set; } = false;

	public static void LogPlayFabError(PlayFabError error)
	{
		LogPlayFabError(string.Empty, error);
	}

	public static void LogPlayFabError(string prefix, PlayFabError error)
	{
		Debug.LogError(prefix + ((error == null) ? "Unknown playfab error" : error.GenerateErrorReport()) + ".");
	}

	public static bool ShouldIgnorePlayFabError(PlayFabMultiplayerManagerErrorArgs errorArgs)
	{
		return PLAYFAB_EXPECTED_ERRORS.Contains(errorArgs.Code);
	}

	public static bool ShouldExitGameAfterError(PlayFabMultiplayerManagerErrorArgs errorArgs)
	{
		return PLAYFAB_EXIT_ERRORS.ContainsKey(errorArgs.Code);
	}

	public static bool ShouldReconnectAfterError(PlayFabMultiplayerManagerErrorArgs errorArgs)
	{
		return PLAYFAB_RECONNECT_ERRORS.ContainsKey(errorArgs.Code);
	}

	public static string ConvertPlayFabError(PlayFabMultiplayerManagerErrorArgs errorArgs)
	{
		if (!PLAYFAB_EXIT_ERRORS.TryGetValue(errorArgs.Code, out var value) && !PLAYFAB_RECONNECT_ERRORS.TryGetValue(errorArgs.Code, out value))
		{
			Debug.LogWarning("PlayFabPartyNetworking.ConvertPlayFabError: Tried to convert PlayFab error that is not known.");
			return "Error/Unknown";
		}
		return value;
	}

	private void RaiseEvent_SharePlatformSession(PlayFabPlayer player)
	{
		Debug.Log(string.Format("{0}.{1}", this, "RaiseEvent_SharePlatformSession"));
		CrossPlatformSessionData crossPlatformSessionData = _playfabSession.CreateCrossPlatformSessionData();
		if (crossPlatformSessionData.platformSessionData == null)
		{
			Debug.Log(string.Format("{0}.{1}: platform session data creation failed, will not share the platform session data.", this, "RaiseEvent_SharePlatformSession"));
			return;
		}
		byte[] payload = CrossPlatformSessionData.Serialize(crossPlatformSessionData);
		PlayFabEndPoint endPoint = new PlayFabEndPoint(player);
		_reusableMessageBuilder.ConstructNewMessage(MessageType.SharePlatformSessionId, payload);
		SendMessageWithType(in _reusableMessageBuilder, endPoint, DeliveryOption.Guaranteed);
	}

	private void HandleEventReceived_SharePlatformSession(byte[] customData)
	{
		Debug.Log(string.Format("{0}.{1}", this, "HandleEventReceived_SharePlatformSession"));
		CrossPlatformSessionData crossPlatformData = CrossPlatformSessionData.Deserialize(customData);
		_playfabSession.ReceiveCrossPlatformSessionData(crossPlatformData, delegate
		{
			RaiseEvent_SharePlatformSession(_serverPlayer);
		});
	}

	public bool Initialize(Action<NetworkEndpoint> disconnectCallback, Action<NetworkEndpoint, int, byte[]> sideChannelCallback, bool useDirectConnection, Platform currentPlatform)
	{
		AllowedPlatforms = currentPlatform;
		GameObject gameObject = new GameObject("PlayFabMultiplayerManager");
		gameObject.AddComponent<PlayFabMultiplayerManager>();
		gameObject.AddComponent<PlayfabMultiplayerEventProcessor>();
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		_playfabPartyManager = PlayFabMultiplayerManager.Get();
		if (_playfabPartyManager == null)
		{
			Debug.LogError("NetworkingInterface initialization failed: no PlayFabMultiplayerManager found.");
			return false;
		}
		_playfabPartyManager.LogLevel = ((!CommandLineArgs.Has("-extralog")) ? PlayFabMultiplayerManager.LogLevelType.Minimal : PlayFabMultiplayerManager.LogLevelType.Verbose);
		_playfabSession = new PlayFabPartySessionWrapper(_playfabPartyManager);
		Manager.platform.ApplicationFocusChanged += ApplicationFocusChanged;
		Manager.platform.platformImpl.RegisterSuspendHandler(delegate
		{
			ApplicationFocusChanged(ApplicationFocusChange.Suspended);
		});
		_disconnectCallback = disconnectCallback;
		_sideChannelCallback = sideChannelCallback;
		_singleMessageDestination = new PlayFabPlayer[1];
		isInitialized = true;
		return true;
	}

	public void Deinitialize()
	{
		if (_playfabPartyManager == null)
		{
			Debug.LogWarning("PlayFabPartyNetworking.Deinitialize: aborting as the PlayFab Party manager doesn't exist.");
			return;
		}
		_playfabSession.Dispose();
		_playfabSession = null;
		UnregisterFromPlayFabEvents();
		Manager.platform.ApplicationFocusChanged -= ApplicationFocusChanged;
		UnityEngine.Object.Destroy(_playfabPartyManager.gameObject);
		_playfabPartyManager = null;
		isInitialized = false;
		_joinSessionCallback = null;
		_disconnectCallback = null;
		_sideChannelCallback = null;
		_receivedMessages.Clear();
		_endpoints.Clear();
		_sideChannelEndPoints.Clear();
		_bannedPlayers.Clear();
		_endpointToPlayFabPlayerIdCache.Clear();
		_serverPlayer = null;
		_reconnectingPlayers.Clear();
		_reconnectTimeouts.Clear();
		_reconnectingServerPlayer = null;
		for (int i = 0; i < _singleMessageDestination.Length; i++)
		{
			_singleMessageDestination[i] = null;
		}
	}

	public NetworkEndpoint GetLocalEndpoint()
	{
		return NetworkEndpoint.LoopbackIpv4.WithPort(7777);
	}

	public bool IsValidConnectionAddress(ServerConnectionInfo connectionInfo)
	{
		return true;
	}

	public bool StartListening()
	{
		return true;
	}

	public void StopListening()
	{
	}

	public bool StartSession(ServerConnectionInfo connectionInfo, int maxNumberPlayers, Action<bool> callback)
	{
		if (!isInitialized || !ReinitializePlayFabIfNeeded())
		{
			Debug.LogError("PlayFabPartyNetworking.StartSession: can't start session since the PlayFabMultiplayerManager could not be initialized.");
			return false;
		}
		if (_playfabSession.IsInSession)
		{
			Debug.LogError("PlayFabPartyNetworking.StartSession: already in session. Disconnecting existing session.");
			Disconnect();
		}
		RegisterToPlayFabEvents();
		_playfabSession.CreateSession(GetClampedMaxNumberPlayers(maxNumberPlayers), CreateSessionCompletion);
		return true;
		void CreateSessionCompletion(string error)
		{
			if (error != null)
			{
				UnityMainThreadDispatcher.Instance().Enqueue(delegate
				{
					Debug.Log("PlayFabPartyNetworking.CreateSessionCompletion: Failed to start session.");
					HandleExitGameError(error);
					callback?.Invoke(obj: false);
				});
			}
			else
			{
				Debug.Log("PlayFabPartyNetworking.CreateSessionCompletion: Successfully started session.");
				_sessionRecreationState = null;
				_serverPlayer = _playfabPartyManager.LocalPlayer;
				if (callback != null)
				{
					UnityMainThreadDispatcher.Instance().Enqueue(delegate
					{
						callback(obj: true);
					});
				}
			}
		}
	}

	public void StopSession()
	{
		Disconnect();
	}

	public void UpdateSession(string session)
	{
		if (!Manager.networking.OfflineSession)
		{
			_playfabSession.UpdateSessionID(session);
		}
	}

	public void RecreateGameId(Action<bool> restartSessionCallback)
	{
		_playfabSession.RecreateGameId();
	}

	public void Connect(ServerConnectionInfo connectionInfo, Action<NetworkEndpoint?> callback)
	{
		if (!isInitialized || !ReinitializePlayFabIfNeeded())
		{
			Debug.Log("PlayFabPartyNetworking.Connect: Failed to initialize PlayFab.");
			Manager.networking.connectionFailedReason = "Error/NoNetwork";
			callback?.Invoke(null);
		}
		else
		{
			RegisterToPlayFabEvents();
			Debug.Log("PlayFabPartyNetworking.Connect: connecting to session with id " + connectionInfo.GameID + ".");
			_playfabSession.JoinSession(connectionInfo.GameID, JoinSessionCompletion);
		}
		void JoinSessionCompletion(string error)
		{
			if (error != null)
			{
				UnityMainThreadDispatcher.Instance().Enqueue(delegate
				{
					Debug.Log("PlayFabPartyNetworking.JoinSessionCompletion: Failed to join session");
					Manager.networking.connectionFailedReason = error;
					callback?.Invoke(null);
				});
			}
			else
			{
				_sessionRecreationState = null;
				_joinSessionCallback = callback;
			}
		}
	}

	public void Disconnect()
	{
		if (isInitialized)
		{
			if (_playfabSession.IsInSession && !_playfabSession.IsDisconnecting && _serverPlayer != null)
			{
				SendGracefulDisconnectMessage(_playfabPartyManager.LocalPlayer);
			}
			_playfabSession.StopSession();
			_serverPlayer = null;
			_endpoints.Clear();
			_sideChannelEndPoints.Clear();
			_endpointToPlayFabPlayerIdCache.Clear();
			_reconnectingPlayers.Clear();
			_reconnectTimeouts.Clear();
			_reconnectingServerPlayer = null;
			_joinSessionCallback = null;
			UnregisterFromPlayFabEvents();
			_disconnectCallback?.Invoke(GetLocalEndpoint());
		}
	}

	public void Update()
	{
		UpdateReconnectingPlayers();
		UpdateReconnectPopup();
		_playfabSession.Update();
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
			foreach (PlayFabEndPoint endpoint in _endpoints)
			{
				if (endpoint == null)
				{
					Debug.LogWarning("SendMessages: null endpoint while iterating through endpoints list.");
					continue;
				}
				ulong num = PlayFabPlayerIdFromEndPoint(item.Dest);
				if (endpoint.Id != num)
				{
					continue;
				}
				_reusableMessageBuilder.ConstructNewMessage(MessageType.MainChannel, item.Data, item.DataLength);
				SendMessageWithType(in _reusableMessageBuilder, endpoint, DeliveryOption.BestEffortNonSequential);
				break;
			}
		}
	}

	private bool ReinitializePlayFabIfNeeded()
	{
		if (_playfabPartyManager == null)
		{
			return false;
		}
		if (_playfabPartyManager.State != PlayFabMultiplayerManagerState.NotInitialized)
		{
			return true;
		}
		Debug.Log("PlayFabPartyNetworking: PlayFab SDK not initialized, trying to force an init attempt again.");
		_playfabPartyManager.Resume();
		return _playfabPartyManager.State != PlayFabMultiplayerManagerState.NotInitialized;
	}

	private void SendGracefulDisconnectMessage(PlayFabPlayer disconnectedPlayer)
	{
		if (disconnectedPlayer == null || disconnectedPlayer.EntityKey?.Id == null)
		{
			Debug.LogError("PlayFabPartyNetworking.SendGracefulDisconnectMessage: Can't disconnect null player.");
			return;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(disconnectedPlayer.EntityKey.Id);
		if (_playfabSession.IsHost)
		{
			foreach (PlayFabEndPoint endpoint in _endpoints)
			{
				if (!(endpoint.Player.EntityKey.Id == disconnectedPlayer.EntityKey.Id))
				{
					_reusableMessageBuilder.ConstructNewMessage(MessageType.Disconnect, bytes);
					SendMessageWithType(in _reusableMessageBuilder, endpoint, DeliveryOption.Guaranteed);
				}
			}
			return;
		}
		if (_serverPlayer == null)
		{
			Debug.LogWarning("PlayFabPartyNetworking.SendGracefulDisconnectMessage: Can't send disconnect message to host, since we don't have a server player stored.");
			return;
		}
		_reusableMessageBuilder.ConstructNewMessage(MessageType.Disconnect, bytes);
		SendMessageWithType(in _reusableMessageBuilder, new PlayFabEndPoint(_serverPlayer), DeliveryOption.Guaranteed);
	}

	private void HandleGracefulDisconnect(PlayFabPlayer from, byte[] messageData)
	{
		string text = Encoding.UTF8.GetString(messageData);
		if (_playfabSession.IsHost)
		{
			if (from.EntityKey.Id != text)
			{
				Debug.LogError("PlayFabPartyNetworking.HandleGracefulDisconnect: Received disconnect message with player id that doesn't match sender player id.");
				return;
			}
		}
		else
		{
			if (_serverPlayer == null)
			{
				Debug.LogError("PlayFabPartyNetworking.HandleGracefulDisconnect: Tried to gracefully disconnect other player, but we don't even know about who is the host yet.");
				return;
			}
			if (from.EntityKey.Id != _serverPlayer.EntityKey.Id)
			{
				Debug.LogError("PlayFabPartyNetworking.HandleGracefulDisconnect: Tried to gracefully disconnect other player, but sender is not host.");
				return;
			}
		}
		int index = FindEndpointIndex(text);
		_endpoints.RemoveAtSwapBack(index);
		_sideChannelEndPoints.RemoveAtSwapBack(index);
		_disconnectCallback?.Invoke(EndPointFromPlayFabPlayer(text));
		Debug.Log("PlayFabPartyNetworking.HandleGracefulDisconnect: Gracefully disconnected player.");
	}

	private void UpdateReconnectingPlayers()
	{
		if (_reconnectTimeouts.Count <= 0)
		{
			return;
		}
		bool flag = false;
		lock (_reconnectTimeouts)
		{
			for (int num = _reconnectTimeouts.Count - 1; num >= 0; num--)
			{
				_reconnectTimeouts[num] -= Time.unscaledDeltaTime;
				if (_reconnectTimeouts[num] <= 0f)
				{
					_reconnectTimeouts.RemoveAt(num);
					string text = _reconnectingPlayers[num];
					_reconnectingPlayers.RemoveAt(num);
					_disconnectCallback?.Invoke(EndPointFromPlayFabPlayer(text));
					flag = true;
					if (_reconnectingServerPlayer != null && text == _reconnectingServerPlayer.EntityKey.Id)
					{
						Debug.LogWarning("PlayFabPartyNetworking.Update: Host reconnect timed out.");
						HandleExitGameError("Error/ConnectionClose");
						return;
					}
					Debug.LogWarning("PlayFabPartyNetworking.Update: player reconnect timed out.");
				}
			}
		}
		if (!flag)
		{
			return;
		}
		try
		{
			_playfabSession.UpdateSessionInfo();
		}
		catch (Exception exception)
		{
			Debug.LogError("PlayFabPartyNetworking.Update: session presence parameter update failed.");
			Debug.LogException(exception);
		}
	}

	private void UpdateReconnectPopup()
	{
		if (!_reconnectPopupActive || Manager.menu.GetTopMenu() != Manager.menu.popUpMenu)
		{
			return;
		}
		string[] formatFields = Manager.menu.centerPopUpText.pugText.formatFields;
		if (formatFields != null && formatFields.Length < 3)
		{
			return;
		}
		string text = GetReconnectStepCount().ToString();
		int num = _playfabSession.CurrentReconnectStep;
		string text2 = _playfabSession.CurrentReconnectStatus;
		if (text2 == null)
		{
			if (_playfabSession.IsConnecting)
			{
				text2 = "Error/RecreateSession";
				num = 6;
			}
			else
			{
				text2 = "Error/ReconnectServerPlayer";
				num = 7;
			}
		}
		text2 = LocalizationManager.GetTranslation(text2);
		string text3 = num.ToString();
		if (formatFields[0] != text3 || formatFields[1] != text || formatFields[2] != text2)
		{
			formatFields[0] = text3;
			formatFields[1] = text;
			formatFields[2] = text2;
			PugText pugText = Manager.menu.centerPopUpText.pugText;
			pugText.Render(rewindEffectAnims: false);
			pugText.SetTempColor(pugText.color.ColorWithNewAlpha(1f));
		}
	}

	private unsafe void SendMessageWithType(in MessageBuilder message, PlayFabEndPoint endPoint, DeliveryOption deliveryOption, bool isSideChannel = false)
	{
		_singleMessageDestination[0] = endPoint.Player;
		message.GetMessageData(out var data, out var length);
		fixed (byte* ptr = data)
		{
			_playfabPartyManager.SendDataMessage((IntPtr)ptr, length, _singleMessageDestination, deliveryOption, isSideChannel);
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

	public void SendSideChannelMessage(NetworkEndpoint dest, int channel, byte[] packet)
	{
		if (!isInitialized)
		{
			return;
		}
		foreach (PlayFabEndPoint sideChannelEndPoint in _sideChannelEndPoints)
		{
			if (sideChannelEndPoint == null)
			{
				Debug.LogWarning("SendSideChannelMessage: null endpoint while iterating through endpoints list.");
				continue;
			}
			ulong num = PlayFabPlayerIdFromEndPoint(dest);
			if (sideChannelEndPoint.Id != num)
			{
				continue;
			}
			_reusableMessageBuilder.ConstructNewMessage(MessageType.SideChannel, packet);
			SendMessageWithType(in _reusableMessageBuilder, sideChannelEndPoint, DeliveryOption.Guaranteed, isSideChannel: true);
			break;
		}
	}

	public string GetConnectionId(NetworkEndpoint endpoint)
	{
		return PlayFabPlayerIdFromEndPoint(endpoint).ToString();
	}

	public void SetAdmin(NetworkEndpoint endpoint, ref PlayerAdminEntry adminEntry)
	{
		if (endpoint == NetworkEndpoint.LoopbackIpv4.WithPort(7777))
		{
			adminEntry.steamId = Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId();
		}
		adminEntry.crossPlatformId = PlayFabPlayerIdFromEndPoint(endpoint);
	}

	public void InitializeBan(PlayerBanEntry playerBanEntry)
	{
		if (!_bannedPlayers.Contains(playerBanEntry))
		{
			_bannedPlayers.Add(playerBanEntry);
		}
	}

	public void BanPlayer(NetworkEndpoint endpoint, ref PlayerBanEntry playerBanEntry)
	{
		playerBanEntry.crossPlatformId = PlayFabPlayerIdFromEndPoint(endpoint);
		if (!_bannedPlayers.Contains(playerBanEntry))
		{
			_bannedPlayers.Add(playerBanEntry);
			Debug.Log("PlayFabPartyNetworking.BanPlayer: added ban entry.");
		}
		else
		{
			int index = _bannedPlayers.IndexOf(playerBanEntry);
			PlayerBanEntry value = _bannedPlayers[index];
			if (value.crossPlatformId == 0L)
			{
				value.crossPlatformId = playerBanEntry.crossPlatformId;
			}
			if (value.steamId == 0L)
			{
				value.steamId = playerBanEntry.steamId;
			}
			_bannedPlayers[index] = value;
		}
		KickPlayer(playerBanEntry.crossPlatformId);
	}

	public void UnbanPlayer(PlayerBanEntry playerBanEntry)
	{
		if (_bannedPlayers.Contains(playerBanEntry))
		{
			_bannedPlayers.Remove(playerBanEntry);
		}
	}

	public bool EntryMatchesEndpoint(PlayerBanEntry entry, NetworkEndpoint endpoint)
	{
		ulong num = PlayFabPlayerIdFromEndPoint(endpoint);
		if (entry.crossPlatformId != 0L)
		{
			return entry.crossPlatformId == num;
		}
		return false;
	}

	public bool EntryMatchesEndpoint(PlayerAdminEntry entry, NetworkEndpoint endpoint)
	{
		ulong num = PlayFabPlayerIdFromEndPoint(endpoint);
		if (entry.crossPlatformId != 0L)
		{
			return entry.crossPlatformId == num;
		}
		return false;
	}

	public void StartSessionInvitationFlow()
	{
		_playfabSession.StartSessionInivitationFlow();
	}

	public void SendSessionInvitations(List<PlatformUserID> invitees, Action<bool> callback)
	{
		_playfabSession.SendSessionInvitations(invitees, callback);
	}

	public bool CheckSessionValidity(string sessionId)
	{
		if (!string.IsNullOrEmpty(sessionId) && CurrentSession.IsValid())
		{
			return !CurrentSession.GameID.Equals(sessionId, StringComparison.InvariantCultureIgnoreCase);
		}
		return true;
	}

	public int GetPing()
	{
		if (_playfabPartyManager.LocalPlayer == null || _playfabPartyManager.LocalPlayer.EntityKey == null || _serverPlayer == null || _serverPlayer.EntityKey == null)
		{
			return -1;
		}
		if (_playfabSession.IsHost || _playfabPartyManager.LocalPlayer.EntityKey == _serverPlayer.EntityKey)
		{
			return 0;
		}
		return _playfabPartyManager.GetEndPointStatistics(_serverPlayer);
	}

	private void RegisterToPlayFabEvents()
	{
		if (_registeredToPlayFabEvents)
		{
			Debug.LogError("PlayFabPartyNetworking.RegisterToPlayFabEvents: already registered to PlayFab events!");
			return;
		}
		Debug.Log("PlayFabPartyNetworking.RegisterToPlayFabEvents");
		if (_playfabPartyManager != null)
		{
			_playfabPartyManager.OnError += OnPlayFabPartyError;
			_playfabPartyManager.OnNetworkDestroyed += OnPartyNetworkDestroyed;
			_playfabPartyManager.OnRemotePlayerJoined += OnRemotePlayerJoined;
			_playfabPartyManager.OnRemotePlayerLeft += OnRemotePlayerLeft;
			_playfabPartyManager.OnDataMessageNoCopyReceived += OnDataMessageNoCopyReceived;
		}
		_registeredToPlayFabEvents = true;
	}

	private void UnregisterFromPlayFabEvents()
	{
		Debug.Log("PlayFabPartyNetworking.UnregisterFromPlayFabEvents");
		if (_playfabPartyManager != null)
		{
			_playfabPartyManager.OnError -= OnPlayFabPartyError;
			_playfabPartyManager.OnNetworkDestroyed -= OnPartyNetworkDestroyed;
			_playfabPartyManager.OnRemotePlayerJoined -= OnRemotePlayerJoined;
			_playfabPartyManager.OnRemotePlayerLeft -= OnRemotePlayerLeft;
			_playfabPartyManager.OnDataMessageNoCopyReceived -= OnDataMessageNoCopyReceived;
		}
		_registeredToPlayFabEvents = false;
	}

	private unsafe NetworkEndpoint EndPointFromPlayFabPlayer(string playerEntityId)
	{
		NetworkEndpoint result = default(NetworkEndpoint);
		if (playerEntityId == null)
		{
			return result;
		}
		ulong input = Convert.ToUInt64(playerEntityId, 16);
		NativeArray<byte> nativeArray = new NativeArray<byte>(UnsafeUtility.SizeOf<ulong>(), Allocator.Temp);
		UnsafeUtility.CopyStructureToPtr(ref input, nativeArray.GetUnsafePtr());
		result.SetRawAddressBytes(nativeArray, NetworkFamily.Custom);
		nativeArray.Dispose();
		return result;
	}

	private unsafe ulong PlayFabPlayerIdFromEndPoint(NetworkEndpoint endpoint)
	{
		if (_endpointToPlayFabPlayerIdCache.ContainsKey(endpoint))
		{
			return _endpointToPlayFabPlayerIdCache[endpoint];
		}
		ulong output;
		using (NativeArray<byte> nativeArray = endpoint.GetRawAddressBytes())
		{
			UnsafeUtility.CopyPtrToStructure<ulong>(nativeArray.GetUnsafePtr(), out output);
		}
		_endpointToPlayFabPlayerIdCache.Add(endpoint, output);
		return output;
	}

	private ulong PlatformSpecificIdFromEndPoint(NetworkEndpoint endpoint)
	{
		ulong num = PlayFabPlayerIdFromEndPoint(endpoint);
		string text = num.ToString("X8");
		PlayFabPlayer playerByEntityId = GetPlayerByEntityId(text);
		if (playerByEntityId != null)
		{
			if (ulong.TryParse(playerByEntityId.PlatformSpecificUserId, out var result))
			{
				return result;
			}
			Debug.LogError(string.Format("{0}.{1}: parsing platform id to an ulong for {2} failed, hex {3}", this, "PlatformSpecificIdFromEndPoint", num, text));
			return 0uL;
		}
		Debug.LogError(string.Format("{0}.{1}: No player found for id {2}, hex {3}", this, "PlatformSpecificIdFromEndPoint", num, text));
		return 0uL;
	}

	private PlayFabPlayer GetPlayerByEntityId(string entityId)
	{
		if (_playfabPartyManager == null)
		{
			Debug.LogError(string.Format("{0}.{1}: Trying to get player when playfab party manager hasn't been initialized. Returning null", this, "GetPlayerByEntityId"));
			return null;
		}
		if (_playfabPartyManager.LocalPlayer != null && _playfabPartyManager.LocalPlayer.EntityKey.Id == entityId)
		{
			return _playfabPartyManager.LocalPlayer;
		}
		IList<PlayFabPlayer> remotePlayers = _playfabPartyManager.RemotePlayers;
		if (remotePlayers != null)
		{
			foreach (PlayFabPlayer item in remotePlayers)
			{
				if (item.EntityKey.Id == entityId)
				{
					return item;
				}
			}
		}
		return null;
	}

	private PlayFabPlayer GetPlayerByAccountId(ulong accountId)
	{
		if (_playfabPartyManager.LocalPlayer != null && ulong.Parse(_playfabPartyManager.LocalPlayer.PlatformSpecificUserId) == accountId)
		{
			return _playfabPartyManager.LocalPlayer;
		}
		IList<PlayFabPlayer> remotePlayers = _playfabPartyManager.RemotePlayers;
		if (remotePlayers != null)
		{
			foreach (PlayFabPlayer item in remotePlayers)
			{
				if (ulong.Parse(item.PlatformSpecificUserId) == accountId)
				{
					return item;
				}
			}
		}
		return null;
	}

	private unsafe void HandleSideChannelMessage(PlayFabPlayer identity, IntPtr data, int size, int channel)
	{
		if (channel > 1)
		{
			Debug.LogError($"invalid side channel {channel}");
			return;
		}
		byte[] array = new byte[size];
		fixed (byte* destination = array)
		{
			UnsafeUtility.MemCpy(destination, (void*)data, size);
		}
		_sideChannelCallback?.Invoke(EndPointFromPlayFabPlayer(identity?.EntityKey?.Id), channel, array);
	}

	private uint GetClampedMaxNumberPlayers(int original)
	{
		return (uint)Math.Clamp(original, 1, 32);
	}

	private void OnRemotePlayerJoined(object sender, PlayFabPlayer player)
	{
		Debug.Log("PlayFabPartyNetworking remote player joined.");
		PlayFabEndPoint endPoint = new PlayFabEndPoint(player);
		if (_playfabSession.IsHost)
		{
			if (_bannedPlayers.Exists((PlayerBanEntry x) => x.crossPlatformId == endPoint.Id))
			{
				KickPlayer(endPoint);
				return;
			}
			_reusableMessageBuilder.ConstructNewMessage(MessageType.Accept, Array.Empty<byte>());
			SendMessageWithType(in _reusableMessageBuilder, endPoint, DeliveryOption.Guaranteed);
			RaiseEvent_SharePlatformSession(player);
		}
		bool flag;
		lock (_reconnectingPlayers)
		{
			int num = _reconnectingPlayers.IndexOf(endPoint.Player.EntityKey.Id);
			flag = num >= 0;
			if (flag)
			{
				_reconnectingPlayers.RemoveAt(num);
				_reconnectTimeouts.RemoveAt(num);
			}
		}
		if (flag)
		{
			Debug.Log("PlayFabPartyNetworking remote player join was reconnect.");
		}
		PlayFabEndPoint sideChannelEndPoint = new PlayFabEndPoint(player);
		if (!_endpoints.Any((PlayFabEndPoint e) => e.Id == endPoint.Id))
		{
			_endpoints.Add(endPoint);
			_playfabSession.PrintPartyConnectionType(player);
		}
		else if (!_sideChannelEndPoints.Any((PlayFabEndPoint e) => e.Id == sideChannelEndPoint.Id))
		{
			_sideChannelEndPoints.Add(sideChannelEndPoint);
		}
		_playfabSession.UpdateSessionInfo();
	}

	private void OnRemotePlayerLeft(object sender, PlayFabPlayer player)
	{
		if (player == null)
		{
			Debug.LogWarning("PlayFabPartyNetworking.OnRemotePlayerLeft: null remote player left.");
			return;
		}
		if (player.EntityKey == null)
		{
			Debug.LogWarning("PlayFabPartyNetworking.OnRemotePlayerLeft: remote player left with null entity key.");
			return;
		}
		int num = FindEndpointIndex(player.EntityKey.Id);
		if (num < 0)
		{
			Debug.Log("Remote Player removed from PlayFab Network.");
			try
			{
				_playfabSession.UpdateSessionInfo();
				return;
			}
			catch (Exception exception)
			{
				Debug.LogError("PlayFabPartyNetworking.OnRemotePlayerLeft: session presence parameter update failed.");
				Debug.LogException(exception);
				return;
			}
		}
		Debug.Log("Remote Player lost PlayFab Network connection.");
		if (!_playfabSession.IsHost && !_playfabSession.IsDisconnecting && _serverPlayer != null && _serverPlayer.EntityKey.Id.Equals(player.EntityKey.Id))
		{
			Debug.Log("PlayFabPartyNetworking.OnRemotePlayerLeft: lost connection to the host.");
			_reconnectingServerPlayer = _serverPlayer;
			_serverPlayer = null;
			StartReconnecting("Consoles/ConnectionErrorGeneric");
		}
		lock (_reconnectingPlayers)
		{
			if (_reconnectingPlayers.Contains(_endpoints[num].Player.EntityKey.Id))
			{
				Debug.LogError("PlayFabPartyNetworking.OnRemotePlayerLeft: endpoint is already in timeout list.");
			}
			else
			{
				_reconnectingPlayers.Add(_endpoints[num].Player.EntityKey.Id);
				_reconnectTimeouts.Add(30f);
			}
		}
		_endpoints.RemoveAtSwapBack(num);
		_sideChannelEndPoints.RemoveAtSwapBack(num);
		Debug.Log("PlayFabPartyNetworking.OnRemotePlayerLeft: removed player from known endpoints.");
	}

	private int FindEndpointIndex(string playerEntityId)
	{
		return _endpoints.FindIndex(delegate(PlayFabEndPoint endpoint)
		{
			if (endpoint == null)
			{
				Debug.LogWarning("PlayFabPartyNetworking.OnRemotePlayerLeft: null endpoint encountered.");
				return false;
			}
			if (endpoint.Player == null)
			{
				Debug.LogWarning(string.Format("{0}.{1}: {2} PlayFab player is null.", "PlayFabPartyNetworking", "OnRemotePlayerLeft", endpoint.Id));
				return false;
			}
			if (endpoint.Player.EntityKey == null)
			{
				Debug.LogWarning(string.Format("{0}.{1}: {2} PlayFab entity key is null.", "PlayFabPartyNetworking", "OnRemotePlayerLeft", endpoint.Id));
				return false;
			}
			return endpoint.Player.EntityKey.Id.Equals(playerEntityId) ? true : false;
		});
	}

	private unsafe void OnDataMessageNoCopyReceived(object sender, PlayFabPlayer from, IntPtr buffer, uint bufferSize, PARTY_MESSAGE_RECEIVED_OPTIONS options)
	{
		if (bufferSize < 4)
		{
			Debug.LogError(string.Format("{0}.{1}: Received message which buffersize is less than 4. Returning", this, "OnDataMessageNoCopyReceived"));
			return;
		}
		int num = -1;
		num = new ReadOnlySpan<int>(buffer.ToPointer(), 4)[0];
		IntPtr buffer2 = IntPtr.Add(buffer, 4);
		HandleMessage((MessageType)num, from, buffer2, bufferSize - 4, options);
	}

	private unsafe void HandleMessage(MessageType messageType, PlayFabPlayer from, IntPtr buffer, uint bufferSize, PARTY_MESSAGE_RECEIVED_OPTIONS options)
	{
		switch (messageType)
		{
		case MessageType.MainChannel:
		{
			QueuedSendMessage item = new QueuedSendMessage
			{
				DataLength = (int)bufferSize,
				Source = EndPointFromPlayFabPlayer(from?.EntityKey?.Id)
			};
			UnsafeUtility.MemCpy(item.Data, (void*)buffer, bufferSize);
			_receivedMessages.Add(item);
			break;
		}
		case MessageType.SideChannel:
			Debug.Log("PlayFabPartyNetworking.HandleMessage: received a side channel (guaranteed) message.");
			HandleSideChannelMessage(from, buffer, (int)bufferSize, 1);
			break;
		case MessageType.Kick:
			Debug.Log("PlayFabPartyNetworking.HandleMessage: received kick command. Kicking ourselves out.");
			LocalPlayerKicked();
			break;
		case MessageType.Accept:
		{
			Debug.Log("PlayFabPartyNetworking.HandleMessage: Player was accepted. Continuing process");
			if (_serverPlayer == null)
			{
				_serverPlayer = from;
				OnReconnectedSuccessfully();
			}
			else
			{
				Debug.LogWarning("PlayFabPartyNetworking.HandleMessage: host player was not null when receiving 'accept' message from a session host. This should only happen when a second endpoint gets connected.");
			}
			NetworkEndpoint value = EndPointFromPlayFabPlayer(_serverPlayer?.EntityKey?.Id);
			_joinSessionCallback?.Invoke(value);
			_joinSessionCallback = null;
			break;
		}
		case MessageType.SharePlatformSessionId:
			HandleEventReceived_SharePlatformSession(ConvertMessageData(buffer, bufferSize));
			break;
		case MessageType.Disconnect:
			Debug.Log("PlayFabPartyNetworking.HandleMessage: Player disconnected gracefully.");
			HandleGracefulDisconnect(from, ConvertMessageData(buffer, bufferSize));
			break;
		default:
			Debug.LogError("PlayFabPartyNetworking.HandleMessage: Received unknown message type.");
			break;
		}
	}

	private unsafe byte[] ConvertMessageData(IntPtr buffer, uint bufferSize)
	{
		byte[] array = new byte[bufferSize];
		fixed (byte* destination = array)
		{
			UnsafeUtility.MemCpy(destination, (void*)buffer, bufferSize);
		}
		return array;
	}

	private void OnPartyNetworkDestroyed(string networkGuid)
	{
		if (!_playfabSession.IsDisconnecting && _playfabSession.IsInSession)
		{
			Debug.Log("PlayFabPartyNetworking.OnPartyNetworkDestroyed: Network was destroyed. Trying to reconnect.");
			StartReconnecting(_playfabSession.IsHost ? "Error/NoNetwork" : "Error/ConnectionClose");
		}
	}

	private void StartReconnecting(string causingError)
	{
		if (_sessionRecreationState != null)
		{
			Debug.Log("PlayFabPartyNetworking.StartReconnecting: Already tried reconnecting.");
			return;
		}
		Debug.Log("PlayFabPartyNetworking.StartReconnecting: Trying to reconnect session.");
		SessionRecreationState recreationState = null;
		if (_playfabSession.ReconnectSession(15, OnReconnectCompleted))
		{
			recreationState = new SessionRecreationState();
			_sessionRecreationState = recreationState;
			if (_playfabSession.IsHost)
			{
				Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.ReconnectAttempt);
				return;
			}
			_reconnectPopupActive = true;
			Manager.ecs.Pause();
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/Reconnecting", options: new List<string> { "cancelDialogue" }, formatFields: new string[3]
			{
				"1",
				GetReconnectStepCount().ToString(),
				LocalizationManager.GetTranslation(_playfabSession.CurrentReconnectStatus)
			}, menuInputCooldown: true, fadeTime: 0f, staticTime: 1.5f, useUnscaledTime: true, yPosition: 0f, textBackgroundAlpha: 1f, localize: true, fontFace: TextManager.FontFace.boldMedium, optionsCallback: OnCancelReconnectPressedOrClosed, minWidth: 2f, backgroundAlpha: 0f, priority: 0, textMaxWidth: 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
		}
		void OnCancelReconnectPressedOrClosed(PopupResponse response)
		{
			if (_reconnectPopupActive)
			{
				_playfabSession.CancelConnect();
				if (!_playfabSession.IsConnecting)
				{
					UnityMainThreadDispatcher.Instance().Enqueue(delegate
					{
						Debug.Log("PlayFabPartyNetworking.StartReconnecting: User cancelled reconnect.");
						HandleExitGameError(causingError);
					});
				}
			}
		}
		void OnReconnectCompleted(string error)
		{
			if (error == null)
			{
				OnReconnectedSuccessfully();
			}
			else if (error == "Error/Canceled")
			{
				Debug.Log("PlayFabPartyNetworking.StartReconnecting: Reconnect cancelled by user.");
				UnityMainThreadDispatcher.Instance().Enqueue(delegate
				{
					HandleExitGameError(causingError ?? error);
				});
			}
			else
			{
				if (error == "Error/Timeout")
				{
					Debug.Log("PlayFabPartyNetworking.StartReconnecting: Reconnect timed out.");
				}
				else
				{
					Debug.Log("PlayFabPartyNetworking.StartReconnecting: Reconnect failed.");
				}
				UnityMainThreadDispatcher.Instance().Enqueue(delegate
				{
					FullyRecreateSession(delegate(string text)
					{
						if (text == null)
						{
							OnReconnectedSuccessfully();
						}
						else if (recreationState != null && !recreationState.WasExited)
						{
							UnityMainThreadDispatcher.Instance().Enqueue(delegate
							{
								HandleExitGameError(causingError ?? text);
							});
						}
					});
				});
			}
		}
	}

	private int GetReconnectStepCount()
	{
		return 5 + (_playfabSession.IsHost ? 1 : 2);
	}

	private void OnReconnectedSuccessfully()
	{
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			if (_playfabSession.IsHost)
			{
				Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.ReconnectSuccess);
				_sessionRecreationState = null;
			}
			else if (_serverPlayer != null && _reconnectingServerPlayer != null)
			{
				_sessionRecreationState = null;
				_reconnectingServerPlayer = null;
				HideReconnectPopup();
			}
		});
	}

	private void HideReconnectPopup()
	{
		if (_reconnectPopupActive)
		{
			_reconnectPopupActive = false;
			if (Manager.menu.GetTopMenu() == Manager.menu.popUpMenu)
			{
				Manager.menu.PopMenu();
			}
			Manager.ecs.Resume();
		}
	}

	private void FullyRecreateSession(Action<string> callback)
	{
		if (_playfabSession.IsConnecting || _playfabSession.IsDisconnecting)
		{
			Debug.Log("PlayFabPartyNetworking.FullyRecreateSession: Tried to recreate session while already connecting or disconnecting.");
		}
		else if (!_playfabSession.IsInSession)
		{
			Debug.LogError("PlayFabPartyNetworking.FullyRecreateSession: Can't recreate session when not currently inside a session.");
		}
		else
		{
			CheckForInternetConnectivity(showUi: false, AfterNetworkCheck);
		}
		void AfterNetworkCheck(bool hasNetwork)
		{
			if (!hasNetwork)
			{
				Debug.Log("PlayFabPartyNetworking.FullyRecreateSession: Can't recreate session, no network connection.");
				callback?.Invoke("Error/NoNetwork");
			}
			else
			{
				string joinString = _playfabSession.JoinString;
				bool isHost = _playfabSession.IsHost;
				uint maxPlayerCount = _playfabSession.MaxPlayerCount;
				_playfabSession.StopSession();
				if (isHost)
				{
					Debug.Log("PlayFabPartyNetworking.FullyRecreateSession: Trying to recreate session as host.");
					_playfabSession.CreateSession(maxPlayerCount, callback);
				}
				else
				{
					Debug.Log("PlayFabPartyNetworking.FullyRecreateSession: Trying to fully reconnect to session as client.");
					_playfabSession.JoinSession(joinString, callback);
				}
			}
		}
	}

	private void OnPlayFabPartyError(object sender, PlayFabMultiplayerManagerErrorArgs args)
	{
		if (ShouldIgnorePlayFabError(args))
		{
			Debug.Log(string.Format("{0}: Received PlayFab Error that should be safe to ignore: {1} - {2} - {3}", "PlayFabPartyNetworking", args.Type, args.Code, args.Message));
		}
		else if (ShouldExitGameAfterError(args))
		{
			Debug.Log(string.Format("{0}: Received PlayFab Error that will prompt game exit: {1} - {2} - {3}", "PlayFabPartyNetworking", args.Type, args.Code, args.Message));
			HandleExitGameError(ConvertPlayFabError(args));
		}
		else if (ShouldReconnectAfterError(args))
		{
			Debug.Log(string.Format("{0}: Received PlayFab Error that will prompt reconnect: {1} - {2} - {3}", "PlayFabPartyNetworking", args.Type, args.Code, args.Message));
			StartReconnecting(ConvertPlayFabError(args));
		}
		else
		{
			Debug.LogError(string.Format("{0}: Received unhandeled PlayFab Error: {1} - {2} - {3}", "PlayFabPartyNetworking", args.Type, args.Code, args.Message));
		}
	}

	private void TemporaryCrossplayNotification(string reason)
	{
		switch (reason)
		{
		case "Error/BadInternet":
		case "Error/Unknown":
		case "Consoles/SessionCreateFailed":
			Manager.networking.connectionFailedWithCrossplayErrorClient = !_playfabSession.IsHost;
			Manager.networking.connectionFailedWithCrossplayErrorHost = _playfabSession.IsHost;
			break;
		}
	}

	public void Debug_TriggerError(int errorCode)
	{
		OnPlayFabPartyError(null, new PlayFabMultiplayerManagerErrorArgs(errorCode, "Debug Error", PlayFabMultiplayerManagerErrorType.Unknown));
	}

	private void HandleExitGameError(string reason)
	{
		TemporaryCrossplayNotification(reason);
		HideReconnectPopup();
		if (_sessionRecreationState == null)
		{
			_sessionRecreationState = new SessionRecreationState();
		}
		_sessionRecreationState.WasExited = true;
		if (_playfabSession.IsHost)
		{
			Debug.Log(string.Format("{0}.{1}: Handling by disabling multiplayer but keeping local session.", this, "HandleExitGameError"));
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/MultiplayerDisabledDueToError", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
			}, new List<string> { "ok" }, 2f, 0f, 0, 20f);
		}
		else
		{
			Debug.Log(string.Format("{0}.{1}: Handling by player failing. Exiting game.", this, "HandleExitGameError"));
			Manager.load.ExitGameOnNetworkError(reason);
		}
	}

	private void ApplicationFocusChanged(ApplicationFocusChange change)
	{
	}

	private async Task HasNetwork(Action<bool> callback)
	{
		bool hasNetwork = true;
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			callback?.Invoke(hasNetwork);
		});
	}

	private void KickPlayer(ulong playfabId)
	{
		foreach (PlayFabEndPoint endpoint in _endpoints)
		{
			if (endpoint == null)
			{
				Debug.LogWarning("KickPlayer: null endpoint while iterating through endpoints list.");
			}
			else if (endpoint.Id == playfabId)
			{
				KickPlayer(endpoint);
				break;
			}
		}
	}

	private void KickPlayer(PlayFabEndPoint endPoint)
	{
		_reusableMessageBuilder.ConstructNewMessage(MessageType.Kick, Array.Empty<byte>());
		SendMessageWithType(in _reusableMessageBuilder, endPoint, DeliveryOption.Guaranteed);
		Debug.Log(string.Format("{0}.{1}: Successfully sent kick command to client", this, "KickPlayer"));
	}

	private void LocalPlayerKicked()
	{
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			HandleExitGameError("Error/SessionJoinBanned");
		});
	}

	public static void CheckForInternetConnectivity(bool showUi, Action<bool> hasNetworkCallback)
	{
		Task.Run(async delegate
		{
			bool hasNetwork = await CheckForInternetConnectivity(showUi);
			UnityMainThreadDispatcher.Instance().Enqueue(delegate
			{
				hasNetworkCallback(hasNetwork);
			});
		});
	}

	public static async Task<bool> CheckForInternetConnectivity(bool showUi)
	{
		return await PlayFabHasNetworkCheck();
	}

	private static async Task<bool> PlayFabHasNetworkCheck()
	{
		GetTitleDataRequest request = new GetTitleDataRequest();
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			PlayFabClientAPI.GetTitleData(request, OnPlayFabConnected, OnPlayFabConnectionFailed);
		});
		bool finished = false;
		bool hasNetwork = false;
		while (!finished)
		{
			await Task.Delay(200);
		}
		return hasNetwork;
		void OnPlayFabConnected(GetTitleDataResult result)
		{
			Debug.Log("Successfull PlayFab network check.");
			finished = true;
			hasNetwork = true;
		}
		void OnPlayFabConnectionFailed(PlayFabError error)
		{
			Debug.LogError("Failed to connect to PlayFab: " + error.GenerateErrorReport());
			finished = true;
			hasNetwork = false;
		}
	}
}
