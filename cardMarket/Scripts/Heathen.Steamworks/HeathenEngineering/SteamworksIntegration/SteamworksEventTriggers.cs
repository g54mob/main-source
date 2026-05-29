using System.Collections.Generic;
using HeathenEngineering.Events;
using HeathenEngineering.SteamworksIntegration.API;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[DisallowMultipleComponent]
	public class SteamworksEventTriggers : MonoBehaviour
	{
		[SerializeField]
		private List<SteamEventTriggerType> m_Delegates;

		public UnityEvent initSuccess;

		public UnityStringEvent initFailed;

		public DlcInstalledEvent dlcInstalled;

		public UnityEvent newUrlLaunchParameters;

		public App.Client.UnityEventServersDisconnected serversDisconnected;

		public UnityEvent serversConnected;

		public App.Client.UnityEventServersConnectFailure serversConnectFailure;

		public UnityEvent gamepadTextInputShown;

		public UnityStringEvent gamepadTextInputDismissed;

		public GameConnectedClanChatMsgEvent chatMessageReceived;

		public GameConnectedChatJoinEvent gameConnectedChatJoin;

		public GameConnectedChatLeaveEvent gameConnectedChatLeave;

		public GameConnectedFriendChatMsgEvent gameConnectedFriendChatMsg;

		public FriendRichPresenceUpdateEvent friendRichPresenceUpdate;

		public PersonaStateChangeEvent personaStateChange;

		public ControllerDataEvent inputDataChanged;

		public SteamInventoryDefinitionUpdateEvent inventoryDefinitionUpdate;

		public SteamInventoryResultReadyEvent inventoryResultReady;

		public SteamMicroTransactionAuthorizationResponce microTransactionAuthorizationResponse;

		public FavoritesListChangedEvent serverFavoritesListChanged;

		public LobbyDataEvent lobbyAskedToLeave;

		public LobbyAuthenticationEvent lobbyAuthenticationRequest;

		public LobbyChatMsgEvent lobbyChatMsg;

		public LobbyChatUpdateEvent lobbyChatUpdate;

		public LobbyDataUpdateEvent lobbyChatDataUpdate;

		public LobbyEnterEvent lobbyEnterFailed;

		public LobbyEnterEvent lobbyEnterSuccess;

		public LobbyGameCreatedEvent lobbyGameCreated;

		public LobbyInviteEvent lobbyInvite;

		public LobbyDataEvent lobbyLeave;

		public GameLobbyJoinRequestedEvent gameLobbyJoinRequested;

		public GameOverlayActivatedEvent gameOverlayActivated;

		public GameRichPresenceJoinRequestedEvent gameRichPresenceJoinRequested;

		public GameServerChangeRequestedEvent gameServerChangeRequested;

		public ActiveBeaconsUpdatedEvent activeBeaconsUpdated;

		public AvailableBeaconLocationsUpdatedEvent availableBeaconLocationsUpdated;

		public ReservationNotificationCallbackEvent reservationNotificationCallback;

		public SteamRemotePlaySessionConnectedEvent remotePlaySessionConnected;

		public SteamRemotePlaySessionDisconnectedEvent remotePlaySessionDisconnected;

		public RemoteStorageLocalFileChangeEvent remoteStorageFileChange;

		public ScreenshotReadyEvent screenshotReady;

		public UnityEvent screenshotRequested;

		public UserAchievementStoredEvent achievementStored;

		public UserStatsReceivedEvent statsReceived;

		public UserStatsStoredEvent statsStored;

		public UserStatsUnloadedEvent statsUnloaded;

		public UnityEvent appResumeFromSuspend;

		public UnityEvent keyboardClosed;

		public UnityEvent keyboardShown;

		private void Start()
		{
			App.evtSteamInitialized.AddListener(initSuccess.Invoke);
			App.evtSteamInitializationError.AddListener(initFailed.Invoke);
			App.Client.EventDlcInstalled.AddListener(dlcInstalled.Invoke);
			App.Client.EventNewUrlLaunchParameters.AddListener(newUrlLaunchParameters.Invoke);
			App.Client.EventServersDisconnected.AddListener(serversDisconnected.Invoke);
			App.Client.EventServersConnected.AddListener(serversConnected.Invoke);
			App.Client.EventServersConnectFailure.AddListener(serversConnectFailure.Invoke);
			BigPicture.Client.EventGamepadTextInputShown.AddListener(gamepadTextInputShown.Invoke);
			BigPicture.Client.EventGamepadTextInputDismissed.AddListener(gamepadTextInputDismissed.Invoke);
			Clans.Client.EventGameConnectedChatLeave.AddListener(gameConnectedChatLeave.Invoke);
			Clans.Client.EventChatMessageReceived.AddListener(chatMessageReceived.Invoke);
			Clans.Client.EventGameConnectedChatJoin.AddListener(gameConnectedChatJoin.Invoke);
			Friends.Client.EventGameConnectedFriendChatMsg.AddListener(gameConnectedFriendChatMsg.Invoke);
			Friends.Client.EventFriendRichPresenceUpdate.AddListener(friendRichPresenceUpdate.Invoke);
			Friends.Client.EventPersonaStateChange.AddListener(personaStateChange.Invoke);
			Input.Client.EventInputDataChanged.AddListener(inputDataChanged.Invoke);
			Inventory.Client.EventSteamInventoryDefinitionUpdate.AddListener(inventoryDefinitionUpdate.Invoke);
			Inventory.Client.EventSteamInventoryResultReady.AddListener(inventoryResultReady.Invoke);
			Inventory.Client.EventSteamMicroTransactionAuthorizationResponse.AddListener(microTransactionAuthorizationResponse.Invoke);
			Matchmaking.Client.EventFavoritesListChanged.AddListener(serverFavoritesListChanged.Invoke);
			Matchmaking.Client.EventLobbyAskedToLeave.AddListener(lobbyAskedToLeave.Invoke);
			Matchmaking.Client.EventLobbyAuthenticationRequest.AddListener(lobbyAuthenticationRequest.Invoke);
			Matchmaking.Client.EventLobbyChatMsg.AddListener(lobbyChatMsg.Invoke);
			Matchmaking.Client.EventLobbyChatUpdate.AddListener(lobbyChatUpdate.Invoke);
			Matchmaking.Client.EventLobbyDataUpdate.AddListener(lobbyChatDataUpdate.Invoke);
			Matchmaking.Client.EventLobbyEnterFailed.AddListener(lobbyEnterFailed.Invoke);
			Matchmaking.Client.EventLobbyEnterSuccess.AddListener(lobbyEnterSuccess.Invoke);
			Matchmaking.Client.EventLobbyGameCreated.AddListener(lobbyGameCreated.Invoke);
			Matchmaking.Client.EventLobbyInvite.AddListener(lobbyInvite.Invoke);
			Matchmaking.Client.EventLobbyLeave.AddListener(lobbyLeave.Invoke);
			Overlay.Client.EventGameLobbyJoinRequested.AddListener(gameLobbyJoinRequested.Invoke);
			Overlay.Client.EventGameOverlayActivated.AddListener(gameOverlayActivated.Invoke);
			Overlay.Client.EventGameRichPresenceJoinRequested.AddListener(gameRichPresenceJoinRequested.Invoke);
			Overlay.Client.EventGameServerChangeRequested.AddListener(gameServerChangeRequested.Invoke);
			Parties.Client.EventActiveBeaconsUpdated.AddListener(activeBeaconsUpdated.Invoke);
			Parties.Client.EventAvailableBeaconLocationsUpdated.AddListener(availableBeaconLocationsUpdated.Invoke);
			Parties.Client.EventReservationNotificationCallback.AddListener(reservationNotificationCallback.Invoke);
			RemotePlay.Client.EventSessionConnected.AddListener(remotePlaySessionConnected.Invoke);
			RemotePlay.Client.EventSessionDisconnected.AddListener(remotePlaySessionDisconnected.Invoke);
			RemoteStorage.Client.EventLocalFileChange.AddListener(remoteStorageFileChange.Invoke);
			Screenshots.Client.EventScreenshotReady.AddListener(screenshotReady.Invoke);
			Screenshots.Client.EventScreenshotRequested.AddListener(screenshotRequested.Invoke);
			StatsAndAchievements.Client.EventUserAchievementStored.AddListener(achievementStored.Invoke);
			StatsAndAchievements.Client.EventUserStatsReceived.AddListener(statsReceived.Invoke);
			StatsAndAchievements.Client.EventUserStatsStored.AddListener(statsStored.Invoke);
			StatsAndAchievements.Client.EventUserStatsUnloaded.AddListener(statsUnloaded.Invoke);
			Utilities.Client.EventAppResumFromSuspend.AddListener(appResumeFromSuspend.Invoke);
			Utilities.Client.EventKeyboardClosed.AddListener(keyboardClosed.Invoke);
			Utilities.Client.EventKeyboardShown.AddListener(keyboardShown.Invoke);
		}

		private void OnDestroy()
		{
			App.Client.EventDlcInstalled.RemoveListener(dlcInstalled.Invoke);
		}
	}
}
