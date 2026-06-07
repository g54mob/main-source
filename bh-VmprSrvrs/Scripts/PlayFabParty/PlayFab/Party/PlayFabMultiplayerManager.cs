using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PartyCSharpSDK;
using PartyXBLCSharpSDK;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using PlayFab.Party._Internal;
using UnityEngine;

namespace PlayFab.Party
{
	public class PlayFabMultiplayerManager : MonoBehaviour
	{
		public delegate void OnNetworkJoinedHandler(object sender, string networkId);

		public delegate void OnNetworkLeftHandler(object sender, string networkId);

		public delegate void OnRemotePlayerJoinedHandler(object sender, PlayFabPlayer player);

		public delegate void OnRemotePlayerLeftHandler(object sender, PlayFabPlayer player);

		public delegate void OnNetworkChangedHandler(object sender, string newNetworkId);

		public delegate void OnChatMessageReceivedHandler(object sender, PlayFabPlayer from, string message, ChatMessageType type);

		public delegate void OnDataMessageReceivedHandler(object sender, PlayFabPlayer from, byte[] buffer);

		public delegate void OnDataMessageReceivedNoCopyHandler(object sender, PlayFabPlayer from, IntPtr buffer, uint bufferSize);

		public delegate void OnErrorEventHandler(object sender, PlayFabMultiplayerManagerErrorArgs args);

		private abstract class WorkTask
		{
			public abstract bool Begin();

			public abstract bool Run();

			public abstract void End();
		}

		private class LeaveNetworkTask : WorkTask
		{
			public override bool Begin()
			{
				return false;
			}

			public override bool Run()
			{
				return false;
			}

			public override void End()
			{
			}
		}

		private class CleanPartyTask : WorkTask
		{
			public override bool Begin()
			{
				return false;
			}

			public override bool Run()
			{
				return false;
			}

			public override void End()
			{
			}
		}

		private class InitPartyTask : WorkTask
		{
			public override bool Begin()
			{
				return false;
			}

			public override bool Run()
			{
				return false;
			}

			public override void End()
			{
			}
		}

		private class JoinPartyTask : WorkTask
		{
			private string _networkId;

			public JoinPartyTask(string networkId)
			{
			}

			public override bool Begin()
			{
				return false;
			}

			public override bool Run()
			{
				return false;
			}

			public override void End()
			{
			}
		}

		internal enum _InternalPlayFabMultiplayerManagerState
		{
			NotInitialized = 0,
			PendingInitialization = 1,
			Initialized = 2,
			LoginRequestIssued = 3,
			LocalUserCreated = 4,
			LocalUserAuthenticated = 5,
			ConnectedToNetwork = 6
		}

		private struct QueuedStartCreateAndJoinNetworkOp
		{
			public bool queued;

			public PlayFabNetworkConfiguration networkConfiguration;
		}

		private struct QueuedCreateAndJoinAfterLeaveNetworkOp
		{
			public bool queued;

			public PlayFabNetworkConfiguration networkConfiguration;
		}

		private struct QueuedJoinNetworkOp
		{
			public bool queued;

			public string networkId;
		}

		private struct QueuedCompleteJoinAfterLeaveNetworkOp
		{
			public bool queued;

			public string networkId;
		}

		public enum LogLevelType
		{
			None = 0,
			Minimal = 1,
			Verbose = 2
		}

		private enum PlayFabMultiplayerManagerMessageType : sbyte
		{
			Unset = 0,
			Game = 1,
			PolicyManager = 2
		}

		private static PlayFabMultiplayerManager _multiplayerManager;

		private static LogLevelType _logLevel;

		private static bool _logLevelSetByUser;

		private IPlayFabChatPlatformPolicyProvider _platformPolicyProvider;

		private PlayFabLocalPlayer _localPlayer;

		private string _preferredLocalPlayerLanguageCode;

		private string _networkId;

		private string _generatedInvitationId;

		private List<PlayFabPlayer> _remotePlayers;

		private bool _translateChat;

		private AccessibilityMode _textToSpeechMode;

		private AccessibilityMode _speechToTextMode;

		private PARTY_HANDLE _partyHandle;

		private PARTY_NETWORK_HANDLE _networkHandle;

		private PARTY_LOCAL_USER_HANDLE _localUserHandle;

		private PARTY_DEVICE_HANDLE _localDeviceHandle;

		private PARTY_ENDPOINT_HANDLE _localEndPointHandle;

		private PARTY_NETWORK_DESCRIPTOR _networkDescriptor;

		private PARTY_SEND_MESSAGE_OPTIONS _defaultSendOptions;

		private PARTY_SEND_MESSAGE_QUEUING_CONFIGURATION _defaultQueuingConfiguration;

		private _InternalPlayFabMultiplayerManagerState _playFabMultiplayerManagerState;

		private bool _isLeaveNetworkInProgress;

		private bool _isJoinNetworkInProgress;

		private List<PARTY_ENDPOINT_HANDLE[]> _cachedSendMessageEndpointHandles;

		private List<PARTY_CHAT_CONTROL_HANDLE[]> _cachedSendMessageChatControlHandles;

		private PARTY_CHAT_CONTROL_HANDLE[] _cachedAllChatHandlesList;

		private List<PARTY_STATE_CHANGE> _partyStateChanges;

		private static PARTY_ENDPOINT_HANDLE[] _emptyEndpointHandlesArray;

		private static PARTY_CHAT_CONTROL_HANDLE[] _emptyChatControlHandlesArray;

		private QueuedStartCreateAndJoinNetworkOp _queuedStartCreateAndJoinNetworkCreateLocalUserOp;

		private QueuedCreateAndJoinAfterLeaveNetworkOp _queuedCreateAndJoinAfterLeaveNetworkOp;

		private QueuedJoinNetworkOp _queuedJoinNetworkCreateLocalUserOp;

		private QueuedCompleteJoinAfterLeaveNetworkOp _queuedCompleteJoinAfterLeaveNetworkOp;

		private const int _DEVICES_PER_USER_COUNT = 1;

		private const int _ENDPOINTS_PER_DEVICE_COUNT = 1;

		private const int _USERS_PER_DEVICE = 1;

		private const string _NETWORK_ID_INVITE_AND_DESCRIPTOR_SEPERATOR = "|";

		private const uint _INTERNAL_EXCHANGE_MESSAGE_BUFFER_SIZE = 128u;

		private const string _INTERNAL_EXCHANGE_REQUEST_MESSAGE_PREFIX = "PFP-";

		private const PARTY_CHAT_PERMISSION_OPTIONS _CHAT_PERMISSIONS_ALL = (PARTY_CHAT_PERMISSION_OPTIONS)31u;

		private const PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS _PLATFORM_DEFAULT_CHAT_TRANSCRIPTION_OPTIONS = PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS.PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS_TRANSCRIBE_OTHER_CHAT_CONTROLS_WITH_MATCHING_LANGUAGES;

		private const string _ENTITY_TYPE_TITLE_PLAYER_ACCOUNT = "title_player_account";

		private const string _ErrorMessageNoUserLoggedIn = "No users logged in. You need to log in a user to PlayFab using the PlayFabClientAPI.LoginWithCustomID or similar API.";

		private const string _ErrorMessageMissingNetworkId = "networkId cannot be empty.";

		private const string _ErrorMessageMissingNetworkConfiguration = "networkConfiguration cannot be null.";

		private const string _ErrorMessageMissingPlayFabTitleId = "Missing Title ID. Please set your Title ID using PlayFab settings class or in the PlayFab Editor Extension.";

		private const string _ErrorMessagePartyAlreadyInitialized = "The Party DLL could not be unloaded. Please restart Unity to unload it.";

		private const string _ErrorMessagePlayerNotFound = "Player not found.";

		private const string _ErrorMessageEmptyDataMessagePayload = "Data message cannot be empty.";

		private const string _ErrorMessageTooManyRecipients = "Too many recipients.";

		private const string _ErrorMessageCannotCallAPINotConnectedToNetwork = "You need to connect to a network before you can call this method.";

		private const string _ErrorMessageMissingMultiplayerManagerPrefab = "PlayFabMultiplayerManager Prefab not found. You need to add the PlayFabMultiplayerManager prefab to your scene.";

		private const uint _c_ErrorFailedToFindResourceSpecified = 6u;

		private const uint _c_ErrorAlreadyInitialized = 4101u;

		private const uint _c_ErrorObjectIsBeingDestroyed = 4104u;

		private List<WorkTask> _tasks;

		private WorkTask _runningTask;

		private bool gameObjectPersisted;

		public LogLevelType LogLevel
		{
			get
			{
				return default(LogLevelType);
			}
			set
			{
			}
		}

		public PlayFabLocalPlayer LocalPlayer => null;

		public string NetworkId => null;

		public PlayFabMultiplayerManagerState State => default(PlayFabMultiplayerManagerState);

		public IList<PlayFabPlayer> RemotePlayers => null;

		public event OnNetworkJoinedHandler OnNetworkJoined
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnNetworkLeftHandler OnNetworkLeft
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnRemotePlayerJoinedHandler OnRemotePlayerJoined
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnRemotePlayerLeftHandler OnRemotePlayerLeft
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnNetworkChangedHandler OnNetworkChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnChatMessageReceivedHandler OnChatMessageReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnDataMessageReceivedHandler OnDataMessageReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnDataMessageReceivedNoCopyHandler OnDataMessageNoCopyReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnErrorEventHandler OnError
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public static PlayFabMultiplayerManager Get()
		{
			return null;
		}

		public void Resume()
		{
		}

		public void Suspend()
		{
		}

		public void CreateAndJoinNetwork()
		{
		}

		public void CreateAndJoinNetwork(PlayFabNetworkConfiguration networkConfiguration)
		{
		}

		public void JoinNetwork(string networkId)
		{
		}

		public void LeaveNetwork()
		{
		}

		public string GetNetworkRegion()
		{
			return null;
		}

		public PARTY_REGION[] GetAvailableRegions()
		{
			return null;
		}

		public PARTY_DEVICE_CONNECTION_TYPE[] GetDeviceConnectionType()
		{
			return null;
		}

		public ulong GetAverageLatencyToRelayServer()
		{
			return 0uL;
		}

		public void SendDataMessageToAllPlayers(byte[] buffer)
		{
		}

		public bool SendDataMessage(byte[] buffer, IEnumerable<PlayFabPlayer> recipients, DeliveryOption deliveryOption)
		{
			return false;
		}

		public void SendDataMessage(IntPtr buffer, uint bufferSize, IEnumerable<PlayFabPlayer> recipients, DeliveryOption deliveryOption)
		{
		}

		public void SendChatMessageToAllPlayers(string message)
		{
		}

		public void SendChatMessage(string message, IEnumerable<PlayFabPlayer> recipients)
		{
		}

		public void UpdateEntityToken(string entityToken)
		{
		}

		internal static void _LogError(string message)
		{
		}

		internal static void _LogError(uint code)
		{
		}

		internal static void _LogError(uint code, PlayFabMultiplayerManagerErrorType type)
		{
		}

		internal static void _LogError(uint code, string message, PlayFabMultiplayerManagerErrorArgs args)
		{
		}

		internal static void _LogWarning(string warningMessage)
		{
		}

		internal static void _LogInfo(string infoMessage)
		{
		}

		internal bool _StartsWithSequence(byte[] buffer, byte[] sequence)
		{
			return false;
		}

		private bool IsInternalMessage(IntPtr messageBuffer, uint messageSize)
		{
			return false;
		}

		private PlayFabPlayer GetPlayerByEntityId(string entityId)
		{
			return null;
		}

		private PARTY_ENDPOINT_HANDLE[] EndPointHandlesFromPlayFabPlayerListNoGC(IEnumerable<PlayFabPlayer> playerList)
		{
			return null;
		}

		private PARTY_CHAT_CONTROL_HANDLE[] ChatControlHandlesFromPlayFabPlayerListNoGC(IEnumerable<PlayFabPlayer> playerList)
		{
			return null;
		}

		private void _Initialize()
		{
		}

		private void _CleanUp()
		{
		}

		private void InitializeImpl()
		{
		}

		private void CleanUpImpl()
		{
		}

		private PARTY_NETWORK_DESCRIPTOR GetNetworkDescriptorFromNetworkId(string networkId)
		{
			return null;
		}

		private void ProcessQueuedOperations()
		{
		}

		private void GetEntityTokenCompleted(GetEntityTokenResponse response)
		{
		}

		internal void _CreateLocalUser(PlayFab.ClientModels.EntityKey entityKey, string entityToken)
		{
		}

		internal void DropCurrentQueuedOps()
		{
		}

		private void GetEntityTokenFailed(PlayFabError error)
		{
		}

		private void CreateAndJoinNetworkImplStart(PlayFabNetworkConfiguration networkConfiguration)
		{
		}

		private void CreateAndJoinNetworkImplComplete(PlayFabNetworkConfiguration networkConfiguration)
		{
		}

		private void JoinNetworkImplStart(string networkId)
		{
		}

		private void JoinNetworkImplComplete(string networkId)
		{
		}

		private void LeaveNetworkImpl(bool wasCallInitiatedByDeveloper)
		{
		}

		private void UpdateNetworkId(string invitationId, PARTY_NETWORK_DESCRIPTOR networkDescriptor)
		{
		}

		private void ResetNetworkManagerStateAfterFailureToConnect()
		{
		}

		private void AuthenticateLocalUserStart()
		{
		}

		private void AuthenticateLocalUserComplete()
		{
		}

		private void SetUserSettings()
		{
		}

		internal void _SendDataMessageToAllPlayers(byte[] buffer)
		{
		}

		internal bool _SendDataMessage(byte[] buffer, IEnumerable<PlayFabPlayer> recipients, DeliveryOption deliveryOption)
		{
			return false;
		}

		internal void _SendDataMessage(IntPtr buffer, uint bufferSize, IEnumerable<PlayFabPlayer> recipients, DeliveryOption deliveryOption)
		{
		}

		internal void _SendChatMessageToAllPlayers(string message)
		{
		}

		internal void _SendChatMessage(string message, IEnumerable<PlayFabPlayer> recipients)
		{
		}

		private void _SendChatMessageImpl(string message, PARTY_CHAT_CONTROL_HANDLE[] targetChatControlHandles)
		{
		}

		private PARTY_SEND_MESSAGE_OPTIONS SendOptionsFromDeliveryOption(DeliveryOption deliveryOption)
		{
			return default(PARTY_SEND_MESSAGE_OPTIONS);
		}

		private void UpdateCachedChatControlsList()
		{
		}

		internal void _RaiseDataMessageReceivedEvent(PlayFabPlayer fromPlayer, IntPtr buffer, uint bufferSize)
		{
		}

		internal void _RaiseChatMessageReceivedEvent(PlayFabPlayer fromPlayer, string message, ChatMessageType chatMessageType)
		{
		}

		internal bool _IsOnDataMessageSubscribedTo()
		{
			return false;
		}

		internal string _GetPlatformSpecificUserId(PlayFab.ClientModels.EntityKey entityKey)
		{
			return null;
		}

		internal void _SetPlayFabMultiplayerManagerInternalState(_InternalPlayFabMultiplayerManagerState state)
		{
		}

		private void SetRemotePlayerChatControlHandle(string entityId, PARTY_CHAT_CONTROL_HANDLE remoteChatControlHandle)
		{
		}

		internal bool PartySucceeded(uint errorCode)
		{
			return false;
		}

		internal bool PartySucceeded(uint errorCode, PlayFabMultiplayerManagerErrorType errorType)
		{
			return false;
		}

		internal bool InternalCheckStateChangeSucceededOrLogErrorIfFailed(PARTY_STATE_CHANGE_RESULT result, uint errorCode)
		{
			return false;
		}

		internal bool InternalCheckStateChangeSucceededOrLogErrorIfFailed(PARTY_XBL_STATE_CHANGE_RESULT result, uint errorCode)
		{
			return false;
		}

		private void InternalCheckStateChangeSucceededOrLogErrorIfFailedImpl(string stateChangeString, uint errorCode)
		{
		}

		private bool RaiseErrorIfStateChangedFailed(PARTY_STATE_CHANGE_RESULT result, uint errorCode)
		{
			return false;
		}

		private void ProcessStateChanges()
		{
		}

		public void ResetParty()
		{
		}

		private void AddTask(WorkTask task)
		{
		}

		private bool IsNotInitializedState()
		{
			return false;
		}

		private bool IsPendingInitializationState()
		{
			return false;
		}

		private bool IsInitializedState()
		{
			return false;
		}

		private bool IsConnectedToNetworkState()
		{
			return false;
		}

		private void ProcessTask()
		{
		}

		private bool HasTasks()
		{
			return false;
		}
	}
}
