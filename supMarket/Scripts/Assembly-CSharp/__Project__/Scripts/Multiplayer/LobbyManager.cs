using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.Localization;

namespace __Project__.Scripts.Multiplayer
{
	public class LobbyManager : NoktaSingletonPunCallbacks<LobbyManager>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CConnect_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LobbyManager _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CConnectToRegionOnChange_003Ed__65 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LobbyManager _003C_003E4__this;

			public string regionCode;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

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
		private struct _003CGetSteamAuthTicket_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public AuthTicket ticket;

			public LobbyManager _003C_003E4__this;

			private TaskAwaiter<AuthTicket> _003C_003Eu__1;

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
		private sealed class _003CLoadingScreenRoutine_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyManager _003C_003E4__this;

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
			public _003CLoadingScreenRoutine_003Ed__51(int _003C_003E1__state)
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
		private struct _003CWaitUntil_003Ed__64 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public int checkIntervalMs;

			public Func<bool> predicate;

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

		[SerializeField]
		private bool m_ShowQuickRoomPanel;

		[SerializeField]
		private TMP_Text m_PlayerNameText;

		[SerializeField]
		private TMP_Text m_StateText;

		[SerializeField]
		private TMP_Text m_MsCounter;

		private const string PrefKey = "SelectedPhotonRegion";

		[SerializeField]
		private TMP_Dropdown m_RegionDropdown;

		[SerializeField]
		private Color m_SelectedColor;

		[SerializeField]
		private float m_MaxWaitTimeForMasterConnection;

		[Header("Create Room")]
		[SerializeField]
		private Button createShowHideButton;

		[SerializeField]
		private GameObject m_CreateRoomPanel;

		[SerializeField]
		private string m_RoomCode;

		[SerializeField]
		private TMP_InputField m_RoomIDField;

		[SerializeField]
		private TMP_Text m_CreateRoomResponseText;

		[SerializeField]
		private Button m_CreateRoomPanelButton;

		[SerializeField]
		private Button m_GenerateCodeButton;

		[Space(10f)]
		[Header("Join Room")]
		[SerializeField]
		private GameObject m_JoinRoomPanel;

		[SerializeField]
		private TMP_InputField m_JoinRoomIDField;

		[SerializeField]
		private TMP_Text m_JoinRoomResponseText;

		[SerializeField]
		private Button m_JoinRoomPanelButton;

		[Space(10f)]
		[SerializeField]
		private GameObject m_PanelCanvas;

		[SerializeField]
		private Button m_CreateButton;

		[SerializeField]
		private Button m_JoinButton;

		[Header("Editor Quick Room")]
		[SerializeField]
		private TMP_Dropdown m_Dropdown;

		[SerializeField]
		private GameObject m_QuickRoomParent;

		private readonly byte m_MaxPlayersPerRoom;

		private string m_GameVersion;

		private List<RoomInfo> m_RoomList;

		private string m_SteamName;

		private string m_PlatformName;

		public readonly RegionInfo[] Regions;

		public ServerSettings serverSettings;

		[SerializeField]
		private GameObject m_WarningPopup;

		[SerializeField]
		private TMP_Text m_WarningText;

		[SerializeField]
		private LocalizeStringEvent m_WarningLocalizeStringEvent;

		[SerializeField]
		private GamePadUIPanel m_gamepadUIPanel;

		[SerializeField]
		private VirtualKeyboard m_VirtualKeyboard;

		[SerializeField]
		private int steamAppId;

		private AuthTicket hAuthTicket;

		public Coroutine m_LoadingScreenCoroutine;

		private static List<ConnectionWarningEntry> m_PhotonConnectionWarnings;

		public string RegionedRoomCode => null;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void CancelAuthTicket(AuthTicket ticket)
		{
		}

		[AsyncStateMachine(typeof(_003CGetSteamAuthTicket_003Ed__44))]
		private Task<string> GetSteamAuthTicket(AuthTicket ticket)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CConnect_003Ed__45))]
		public void Connect()
		{
		}

		public void ExternalConnect()
		{
		}

		private void SetCursor(bool isGamepad)
		{
		}

		public void CloseMultiplayerPanel()
		{
		}

		public void ConnectToServer()
		{
		}

		[IteratorStateMachine(typeof(_003CLoadingScreenRoutine_003Ed__51))]
		public IEnumerator LoadingScreenRoutine()
		{
			return null;
		}

		private void CloseLoadingScreen()
		{
		}

		public void CreateRoom()
		{
		}

		public void JoinTargetRoom()
		{
		}

		public void ExternalJoinTargetRoom(string roomCode)
		{
		}

		public void GenerateRoomCode()
		{
		}

		public void ChangeVisibilityRoomCodeField()
		{
		}

		private string GetPhotonStatus()
		{
			return null;
		}

		private string GetCurrentState()
		{
			return null;
		}

		public void CopyRoomCodeToClipboard()
		{
		}

		public void PasteRoomCodeToJoinIDInput()
		{
		}

		private void OnDropdownValueChanged(int index)
		{
		}

		public void ConnectToRegion(string regionCode)
		{
		}

		[AsyncStateMachine(typeof(_003CWaitUntil_003Ed__64))]
		public static Task WaitUntil(Func<bool> predicate, int checkIntervalMs = 20)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CConnectToRegionOnChange_003Ed__65))]
		public void ConnectToRegionOnChange(string regionCode)
		{
		}

		public override void OnConnectedToMaster()
		{
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public override void OnCustomAuthenticationFailed(string debugMessage)
		{
		}

		private void SwitchWarningPanelGamepadParent(bool isLobby)
		{
		}

		public override void OnJoinedLobby()
		{
		}

		public override void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public override void OnCreatedRoom()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public override void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public void OnQuickRoomSelected()
		{
		}

		public void CloseWarningPopup()
		{
		}

		public void OpenWarningPopup(string message, short returnCode = -2025)
		{
		}

		public void LocalizedWarningName(short code, out bool isEmpty)
		{
			isEmpty = default(bool);
		}

		public void OpenJoinRoomPanel()
		{
		}

		public void OpenCreateRoomPanel()
		{
		}

		public void CloseKeyboard()
		{
		}

		public void OpenKeyboard()
		{
		}

		public void OnDropdownSelect()
		{
		}
	}
}
