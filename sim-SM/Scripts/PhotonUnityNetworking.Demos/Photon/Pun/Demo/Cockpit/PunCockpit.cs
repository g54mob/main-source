using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class PunCockpit : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003COnDropdownConnectAs_CB_003Ed__99 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PunCockpit _003C_003E4__this;

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
			public _003COnDropdownConnectAs_CB_003Ed__99(int _003C_003E1__state)
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

		public static PunCockpit Instance;

		public static bool Embedded;

		public static string EmbeddedGameTitle;

		public bool debug;

		public Text Title;

		public Text StateText;

		public Text UserIdText;

		[Header("Demo Integration")]
		public CanvasGroup MinimalCanvasGroup;

		public CanvasGroup MaximalCanvasGroup;

		public GameObject MinimizeButton;

		public GameObject MinimalUIEmbeddHelp;

		[Header("Connection UI")]
		public GameObject ConnectingLabel;

		public GameObject ConnectionPanel;

		public GameObject AdvancedConnectionPanel;

		public Dropdown ConnectAsDropDown;

		[Header("Common UI")]
		public GameObject InfosPanel;

		public GameObject MinimalUiInfosPanel;

		[Header("Lobby UI")]
		public GameObject LobbyPanel;

		public Selectable JoinLobbyButton;

		public RoomListView RoomListManager;

		public FriendListView FriendListManager;

		public GameObject RoomListMatchMakingForm;

		[Header("Game UI")]
		public GameObject GamePanel;

		public PlayerListView PlayerListManager;

		public PlayerDetailsController PlayerDetailsManager;

		public InputField RoomCustomPropertyInputfield;

		[Header("Photon Settings")]
		public string GameVersionOverride;

		public bool ResetBestRegionCodeInPreferences;

		[Header("Room Options")]
		public int MaxPlayers;

		public int PlayerTtl;

		public int EmptyRoomTtl;

		public string Plugins;

		public bool PublishUserId;

		public bool IsVisible;

		public bool IsOpen;

		public bool CleanupCacheOnLeave;

		public bool DeleteNullProperties;

		[Header("Room Options UI")]
		public IntInputField PlayerTtlField;

		public IntInputField EmptyRoomTtlField;

		public IntInputField MaxPlayersField;

		public StringInputField PluginsField;

		public BoolInputField PublishUserIdField;

		public BoolInputField IsVisibleField;

		public BoolInputField IsOpenField;

		public BoolInputField CleanupCacheOnLeaveField;

		public BoolInputField DeleteNullPropertiesField;

		[Header("Friends Options")]
		public FriendListView.FriendDetail[] FriendsList;

		[Header("Modal window")]
		public CanvasGroup ModalWindow;

		public RegionListView RegionListView;

		public Text RegionListLoadingFeedback;

		private LoadBalancingClient _lbc;

		private bool _regionPingProcessActive;

		private List<Region> RegionsList;

		private string roomNameToEnter;

		public string UserId { get; set; }

		public void Start()
		{
		}

		public void SwitchtoMinimalPanel()
		{
		}

		public void SwitchtoMaximalPanel()
		{
		}

		public void SwitchToAdvancedConnection()
		{
		}

		public void SwitchToSimpleConnection()
		{
		}

		public void ToggleInfosInMinimalPanel()
		{
		}

		public void RequestInfosPanel(GameObject Parent)
		{
		}

		public void OnUserIdSubmited(string userId)
		{
		}

		public void SetPlayerTtlRoomOption(int value)
		{
		}

		public void SetEmptyRoomTtlRoomOption(int value)
		{
		}

		public void SetMaxPlayersRoomOption(int value)
		{
		}

		public void SetPluginsRoomOption(string value)
		{
		}

		public void SetPublishUserId(bool value)
		{
		}

		public void SetIsVisible(bool value)
		{
		}

		public void SetIsOpen(bool value)
		{
		}

		public void SetResetBestRegionCodeInPreferences(bool value)
		{
		}

		public void SetCleanupCacheOnLeave(bool value)
		{
		}

		public void SetDeleteNullProperties(bool value)
		{
		}

		public void PingRegions()
		{
		}

		private void Update()
		{
		}

		private void OnStateChanged(ClientState previousState, ClientState state)
		{
		}

		public override void OnRegionListReceived(RegionHandler regionHandler)
		{
		}

		private void OnRegionsPinged(RegionHandler regionHandler)
		{
		}

		public void CloseRegionListView()
		{
		}

		public void LoadLevel(string level)
		{
		}

		public void SetRoomCustomProperty(string value)
		{
		}

		public void JoinRoom(string roomName)
		{
		}

		public void CreateRoom()
		{
		}

		public void CreateRoom(string roomName, string lobbyName = "MyLobby", LobbyType lobbyType = LobbyType.SqlLobby, string[] expectedUsers = null)
		{
		}

		public void JoinRandomRoom()
		{
		}

		public void LeaveRoom()
		{
		}

		public void Connect()
		{
		}

		public void ReConnect()
		{
		}

		public void ReconnectAndRejoin()
		{
		}

		public void ConnectToBestCloudServer()
		{
		}

		public void ConnectToRegion(string region)
		{
		}

		public void ConnectOffline()
		{
		}

		public void JoinLobby()
		{
		}

		public void Disconnect()
		{
		}

		public void OpenDashboard()
		{
		}

		public void OnDropdownConnectAs(int dropdownIndex)
		{
		}

		[IteratorStateMachine(typeof(_003COnDropdownConnectAs_CB_003Ed__99))]
		private IEnumerator OnDropdownConnectAs_CB()
		{
			return null;
		}

		public void OnLobbyToolsViewTabChanged(string tabId)
		{
		}

		public void OnSelectPlayer()
		{
		}

		public override void OnConnected()
		{
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
		}

		public override void OnConnectedToMaster()
		{
		}

		public override void OnJoinedLobby()
		{
		}

		private void SetUpLobbyGenericUI()
		{
		}

		public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
		{
		}

		public override void OnLeftLobby()
		{
		}

		public override void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public override void OnLeftRoom()
		{
		}

		private RoomOptions GetRoomOptions()
		{
			return null;
		}
	}
}
