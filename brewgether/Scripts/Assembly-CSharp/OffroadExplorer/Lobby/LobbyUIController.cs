using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BrewGame.SaveSystem.Core;
using Brewery.UI;
using Steamworks;
using UnityEngine;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	[RequireComponent(typeof(UIDocument))]
	public class LobbyUIController : MonoBehaviour
	{
		private enum Screen
		{
			MainMenu = 0,
			Profile = 1,
			Settings = 2,
			HostSettings = 3,
			JoinLobby = 4,
			LobbyRoom = 5,
			SaveSelection = 6
		}

		[CompilerGenerated]
		private sealed class _003CCheckPendingSteamJoinDelayed_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyUIController _003C_003E4__this;

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
			public _003CCheckPendingSteamJoinDelayed_003Ed__83(int _003C_003E1__state)
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
		private sealed class _003CLateJoinConnectionSafetyTimeout_003Ed__132 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyUIController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

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
			public _003CLateJoinConnectionSafetyTimeout_003Ed__132(int _003C_003E1__state)
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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003COnConfirmDeleteClicked_003Ed__153 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LobbyUIController _003C_003E4__this;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CRefreshSaveSlots_003Ed__144 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LobbyUIController _003C_003E4__this;

			private TaskAwaiter<SaveSlotMetadata[]> _003C_003Eu__1;

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
		private sealed class _003CStartMultiplayerGameCoroutine_003Ed__121 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyUIController _003C_003E4__this;

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
			public _003CStartMultiplayerGameCoroutine_003Ed__121(int _003C_003E1__state)
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
		private sealed class _003CStartSoloGameCoroutine_003Ed__109 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyUIController _003C_003E4__this;

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
			public _003CStartSoloGameCoroutine_003Ed__109(int _003C_003E1__state)
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

		[Header("UI References")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Manager References")]
		[SerializeField]
		private NotificationManager notificationManager;

		[SerializeField]
		private ProfileManager profileManager;

		private VisualElement root;

		private Button backButton;

		private VisualElement mainMenuScreen;

		private VisualElement profileScreen;

		private VisualElement settingsScreen;

		private VisualElement hostSettingsScreen;

		private VisualElement joinLobbyScreen;

		private VisualElement lobbyRoomScreen;

		private LobbySettingsUI _settingsUI;

		private VisualElement notificationContainer;

		private VisualElement welcomeAvatar;

		private Label welcomeGreeting;

		private Label welcomePlayerName;

		private Label versionLabel;

		private Button btnStartSolo;

		private Button btnHostLobby;

		private Button btnJoinFriends;

		private Button btnSettings;

		private Button btnQuit;

		private Button btnCopyDiscord;

		private VisualElement profileAvatarLarge;

		private Label profilePlayerName;

		private Label profileSteamId;

		private Label profileLevel;

		private VisualElement xpBarFill;

		private Label profileXP;

		private TextField hostLobbyNameInput;

		private Button btnCreateLobby;

		private Button btnCancelHost;

		private Button btnQuickJoin;

		private TextField joinCodeInput;

		private Button btnPasteCode;

		private Button btnJoinByCode;

		private Button btnRefreshBrowser;

		private ScrollView serverBrowserList;

		private Button btnCancelJoin;

		private Label lobbyNameDisplay;

		private VisualElement[] playerCards;

		private Button btnReady;

		private Button btnStartGame;

		private Label startHintLabel;

		private Button btnInviteFriends;

		private Button btnLeaveLobby;

		private VisualElement saveSelectionScreen;

		private VisualElement[] saveSlotCards;

		private Label[] slotStatusLabels;

		private Label[] slotLastPlayedLabels;

		private Label[] slotCloudSyncLabels;

		private Button[] btnSelectSlots;

		private Button[] btnDeleteSlots;

		private Button btnBackFromSaves;

		private Label[] slotPlaytimeValueLabels;

		private Label[] slotStandSalesLabels;

		private Label[] slotBarSalesLabels;

		private Label[] slotPropertiesLabels;

		private VisualElement[] slotStatsPrimaryContainers;

		private VisualElement modalDeleteConfirm;

		private Label deleteConfirmMessage;

		private Button btnConfirmDelete;

		private Button btnCancelDelete;

		private int pendingDeleteSlotIndex;

		private VisualElement overlayWaitingForHost;

		private Screen currentScreen;

		private bool isInLobby;

		private bool isHost;

		private bool isSoloMode;

		private bool isNavigatingToSaveSelection;

		private bool _isUILocked;

		private Screen previousScreen;

		private bool isFirstNavigation;

		private SaveSlotMetadata[] _cachedSlotMetadata;

		public static LobbyUIController Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetupUI()
		{
		}

		private void OnPanelAttached(AttachToPanelEvent evt)
		{
		}

		private void PerformUISetup()
		{
		}

		private void CheckPendingSteamJoin()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckPendingSteamJoinDelayed_003Ed__83))]
		private IEnumerator CheckPendingSteamJoinDelayed()
		{
			return null;
		}

		private void SetupMainMenu()
		{
		}

		private void UpdateWelcomeSection()
		{
		}

		private void SetupProfile()
		{
		}

		private void SetupHostSettings()
		{
		}

		private void SetupJoinLobby()
		{
		}

		private void SetupLobbyRoom()
		{
		}

		private void SetupSaveSelection()
		{
		}

		private void InitializeManagers()
		{
		}

		private void RegisterEventHandlers()
		{
		}

		private void UnregisterEventHandlers()
		{
		}

		private void SubscribeToEvents()
		{
		}

		private void UnsubscribeFromEvents()
		{
		}

		private void NavigateToScreen(Screen screen)
		{
		}

		private VisualElement GetScreenElement(Screen screen)
		{
			return null;
		}

		private void PrepareScreenData(Screen screen)
		{
		}

		private void HideAllScreensImmediate()
		{
		}

		private void ForceHideAllScreensExcept(VisualElement activeScreen)
		{
		}

		private void AnimateBackButton(bool show)
		{
		}

		private void MoveCameraToScreen(Screen screen)
		{
		}

		private void OnBackButtonClicked()
		{
		}

		private void UpdateProfileDisplay()
		{
		}

		private void OnStartSoloClicked()
		{
		}

		private void OnHostLobbyClicked()
		{
		}

		[IteratorStateMachine(typeof(_003CStartSoloGameCoroutine_003Ed__109))]
		private IEnumerator StartSoloGameCoroutine()
		{
			return null;
		}

		private void OnQuitClicked()
		{
		}

		private void OnCopyDiscordClicked()
		{
		}

		private void OnCreateLobbyClicked()
		{
		}

		private void OnJoinFriendsClicked()
		{
		}

		private void OnQuickJoinClicked()
		{
		}

		private void OnPasteCodeClicked()
		{
		}

		private void OnJoinByCodeClicked()
		{
		}

		private void OnRefreshBrowserClicked()
		{
		}

		private void OnReadyClicked()
		{
		}

		private void TryToggleReadyWithRetry(int retryCount)
		{
		}

		private void OnStartGameClicked()
		{
		}

		[IteratorStateMachine(typeof(_003CStartMultiplayerGameCoroutine_003Ed__121))]
		private IEnumerator StartMultiplayerGameCoroutine()
		{
			return null;
		}

		private void OnInviteFriendsClicked()
		{
		}

		private void OnLeaveLobbyClicked()
		{
		}

		private void OnLobbyCreated(bool success, string codeOrError)
		{
		}

		private void OnLobbyJoined(bool success, string error)
		{
		}

		private void OnLobbyLeft()
		{
		}

		private void OnPlayerJoinedLobby(string playerName)
		{
		}

		private void OnPlayerLeftLobby(string playerName)
		{
		}

		private void OnLobbyListUpdated(List<LobbyListEntry> lobbies)
		{
		}

		private void OnSteamJoinRequested(CSteamID lobbyId)
		{
		}

		private void HandleSteamJoin(CSteamID lobbyId)
		{
		}

		[IteratorStateMachine(typeof(_003CLateJoinConnectionSafetyTimeout_003Ed__132))]
		private IEnumerator LateJoinConnectionSafetyTimeout()
		{
			return null;
		}

		private void UpdateLobbyRoomDisplay()
		{
		}

		public void RefreshPlayerList()
		{
		}

		public void RefreshProfileDisplay()
		{
		}

		private void RefreshPlayerListWithRetry(int retryCount)
		{
		}

		private void UpdatePlayerCard(int index, LobbyPlayerData playerData)
		{
		}

		private void ClearPlayerCard(int index)
		{
		}

		private void UpdateStartButton()
		{
		}

		private void UpdateReadyButton(bool isReady)
		{
		}

		private void PopulateServerBrowser(List<LobbyListEntry> lobbies)
		{
		}

		private VisualElement CreateLobbyListItem(LobbyListEntry lobby)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRefreshSaveSlots_003Ed__144))]
		private void RefreshSaveSlots()
		{
		}

		private void UpdateSlotDisplay(int index, SaveSlotMetadata metadata)
		{
		}

		private void UpdateCloudSyncLabel(int index, SaveSlotMetadata metadata)
		{
		}

		private string FormatPlaytimeShort(float totalSeconds)
		{
			return null;
		}

		private string FormatMoney(float amount)
		{
			return null;
		}

		private void OnSaveSlotSelected(int slotIndex)
		{
		}

		private void LockSaveSelectionUI()
		{
		}

		private void OnDeleteSlotClicked(int slotIndex)
		{
		}

		private void OnBackFromSavesClicked()
		{
		}

		[AsyncStateMachine(typeof(_003COnConfirmDeleteClicked_003Ed__153))]
		private void OnConfirmDeleteClicked()
		{
		}

		private void OnCancelDeleteClicked()
		{
		}
	}
}
