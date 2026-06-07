using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Coherence.Cloud;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Toolkit.ReplicationServer;
using PlayFab.Party;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class RoomSelectionPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass73_0
		{
			public long ready;

			internal void _003CUpdateReadyState_003Eb__0(RequestResponse<bool> response)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateLobby_003Ed__94 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomSelectionPage _003C_003E4__this;

			private TaskAwaiter<LobbyResult> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CFireUiSignalCoroutine_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RoomSelectionPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFireUiSignalCoroutine_003Ed__101(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CInitializeOnlineModules_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RoomSelectionPage _003C_003E4__this;

			private bool _003CprovidersInitialized_003E5__2;

			private float _003Ctime_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CInitializeOnlineModules_003Ed__67(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CJoinLobby_003Ed__61 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomSelectionPage _003C_003E4__this;

			public string lobbyTag;

			private TaskAwaiter<LobbyResult> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLeaveLobby_003Ed__111 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomSelectionPage _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendStartGameMessage_003Ed__91 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomSelectionPage _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStartGameBasedOnNetworkType_003Ed__60 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomSelectionPage _003C_003E4__this;

			public NetworkType networkType;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUpdateLobbyAttributes_003Ed__83 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomSelectionPage _003C_003E4__this;

			public List<CloudAttribute> attributes;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUpdateReadyState_003Ed__73 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public long ready;

			public RoomSelectionPage _003C_003E4__this;

			private _003C_003Ec__DisplayClass73_0 _003C_003E8__1;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private GameObject _roomSelection;

		[SerializeField]
		private LabeledInputUI _lobbyIdInput;

		[SerializeField]
		private Button _joinButton;

		[SerializeField]
		private Button _createRoomButton;

		[SerializeField]
		private Button _startButton;

		[SerializeField]
		private Button _leaveButton;

		[SerializeField]
		private Button _adventuresButton;

		[SerializeField]
		private Button _collectionsButton;

		[SerializeField]
		private Button _powerUpsButton;

		[SerializeField]
		private CoherenceSyncConfig _onlineStageManagerPrefab;

		[SerializeField]
		private CoherenceSyncConfig _hostPlayerOptions;

		[SerializeField]
		private CoherenceSyncConfig _lobbyCharacterData;

		[SerializeField]
		private TextMeshProUGUI _infoText;

		[SerializeField]
		private GameObject _initContainer;

		[SerializeField]
		private PlayFabMultiplayerManager _playFabPrefab;

		[SerializeField]
		private GameObject _preCharacterSelectionLobby;

		[SerializeField]
		private TextMeshProUGUI _lobbyIdText;

		[SerializeField]
		private List<TextMeshProUGUI> _lobbyPlayerNames;

		[SerializeField]
		private OnlineDLCSection _OnlineDLCSection;

		private List<DlcType> _AvailableDLCs;

		private Coherence.Log.Logger _logger;

		private INetworkProvider _activeProvider;

		private INetworkProvider _p2pProvider;

		private CloudNetworkProvider _cloudProvider;

		private DiContainer _diContainer;

		private LobbiesManager _lobbiesManager;

		private Coroutine _fireUiSignalRoutine;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private SignalBus _signalBus;

		private IReplicationServer _replicationServer;

		private bool _isStartingGame;

		private static Dictionary<SystemPlatformTypes, NetworkProviders> _platformToProvider;

		private const int ClientHostingDisconnectTimeout = 2147483647;

		private const float OnlineInitTimeout = 15f;

		private static bool hasOnEnablerunOnce;

		public LobbiesManager LobbiesManager => null;

		public DiContainer DiContainer => null;

		public IReplicationServer ReplicationServer => null;

		public static RoomSelectionPage Instance { get; private set; }

		public bool IsInLobby => false;

		public INetworkProvider ActiveProvider => null;

		[Inject]
		private void Construct(SignalBus signalBus, DiContainer diContainer, MultiplayerManager multiplayerManager, LobbiesManager lobbiesManager, PlayerOptions playerOptions, AdventureManager adventureManager)
		{
		}

		public void LeaveGame()
		{
		}

		public void StartGame()
		{
		}

		public void CreateRoom()
		{
		}

		private void OnLoggedInWithCoherenceAfterCreate(bool result)
		{
		}

		public void JoinRoom(string _lobbyID)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		public void JoinRoom()
		{
		}

		private static void ShowConnectionLostPopup()
		{
		}

		private void OnLoggedInWithCoherenceAfterJoin(string lobbyTag, bool result)
		{
		}

		public static EndpointData GetLocalEndpoint()
		{
			return default(EndpointData);
		}

		[AsyncStateMachine(typeof(_003CStartGameBasedOnNetworkType_003Ed__60))]
		private void StartGameBasedOnNetworkType(NetworkType networkType)
		{
		}

		[AsyncStateMachine(typeof(_003CJoinLobby_003Ed__61))]
		private void JoinLobby(string lobbyTag)
		{
		}

		protected override void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void RemoveConnectionListeners()
		{
		}

		[IteratorStateMachine(typeof(_003CInitializeOnlineModules_003Ed__67))]
		private IEnumerator InitializeOnlineModules()
		{
			return null;
		}

		private void UpdateLobbyState()
		{
		}

		private void OnJoinError()
		{
		}

		private void ChangeUiState(bool activate, string infoText)
		{
		}

		private void SwitchLobbyState(bool activate)
		{
		}

		private void OnJoinedLobby()
		{
		}

		[AsyncStateMachine(typeof(_003CUpdateReadyState_003Ed__73))]
		private void UpdateReadyState(long ready)
		{
		}

		private void ChangeButtonsState(bool active)
		{
		}

		private void UpdateStartButtonState(bool active)
		{
		}

		private void OnStartGameMessageReceived(LobbySession lobby, MessagesReceived messages)
		{
		}

		private void OnP2PSessionError(string errorMessage)
		{
		}

		private void OnLobbyOwnerChanged(LobbySession lobby, LobbyPlayer player)
		{
		}

		private void UpdatePlayerNames()
		{
		}

		private void UpdateAvailableDLC()
		{
		}

		private List<DlcType> GetDLCStringAsTypes(string dlcString)
		{
			return null;
		}

		private void OnGameReady(bool result, string errorMessage, Dictionary<string, string> networkAttributes)
		{
		}

		[AsyncStateMachine(typeof(_003CUpdateLobbyAttributes_003Ed__83))]
		private void UpdateLobbyAttributes(List<CloudAttribute> attributes)
		{
		}

		private void OnAttributesAdded(RequestResponse<bool> req)
		{
		}

		private List<LobbyPlayer> GetMessageRecipients()
		{
			return null;
		}

		private void OnP2PFailedMessageReceived(LobbySession lobby, MessagesReceived messages)
		{
		}

		private void FallbackToCoherenceCloud()
		{
		}

		private void OnP2PSessionReady()
		{
		}

		private void StartHostingCoherenceGame()
		{
		}

		private void OnStartedHosting(CoherenceBridge _)
		{
		}

		[AsyncStateMachine(typeof(_003CSendStartGameMessage_003Ed__91))]
		private void SendStartGameMessage()
		{
		}

		private void OnStartGameMessageSent(RequestResponse<bool> req)
		{
		}

		private NetworkType GetNetworkType()
		{
			return default(NetworkType);
		}

		[AsyncStateMachine(typeof(_003CCreateLobby_003Ed__94))]
		private void CreateLobby()
		{
		}

		private void OnCreatedLobby()
		{
		}

		private void OnConnectionLostWithCoherence()
		{
		}

		private void OnPlayerLeft(LobbySession lobby, LobbyPlayer player, string reason)
		{
		}

		private void OnPlayerJoined(LobbySession lobby, LobbyPlayer player)
		{
		}

		private void InstantiateLobbyEntities(CoherenceClientConnectionManager _)
		{
		}

		private void ShowOnlineLobby(CoherenceClientConnectionManager _)
		{
		}

		[IteratorStateMachine(typeof(_003CFireUiSignalCoroutine_003Ed__101))]
		private IEnumerator FireUiSignalCoroutine()
		{
			return null;
		}

		private void OnClientDisconnected(CoherenceClientConnection clientConn)
		{
		}

		private void FireUiSignal()
		{
		}

		private void StartReplicationServerIfP2P()
		{
		}

		private ReplicationServerConfig GetConfig()
		{
			return default(ReplicationServerConfig);
		}

		private void OnConnectionError(CoherenceBridge _, ConnectionException e)
		{
		}

		private void OnDestroy()
		{
		}

		public void UpdateActiveProvider()
		{
		}

		protected override void Update()
		{
		}

		private void ShutDown()
		{
		}

		[AsyncStateMachine(typeof(_003CLeaveLobby_003Ed__111))]
		private void LeaveLobby()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void StopReplicationServer()
		{
		}

		private void ReplicationServer_OnLog(string log)
		{
		}

		private void ReplicationServer_OnExit(int code)
		{
		}

		public void GoBackOnline()
		{
		}

		public void ShowBestiary()
		{
		}

		public void ShowOptions()
		{
		}

		public void ShowPowerUps()
		{
		}

		public void ShowAchievements()
		{
		}

		public void ShowCollections()
		{
		}

		public void ShowAdventuresView()
		{
		}

		private void ChangeLobbyOpenState(bool open)
		{
		}
	}
}
