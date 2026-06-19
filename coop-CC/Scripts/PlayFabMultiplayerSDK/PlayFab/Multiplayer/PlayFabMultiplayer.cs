using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Internal;
using PlayFab.Multiplayer.InteropWrapper;
using UnityEngine;

namespace PlayFab.Multiplayer
{
	public class PlayFabMultiplayer
	{
		public delegate void OnErrorEventHandler(PlayFabMultiplayerErrorArgs args);

		public delegate void OnLobbyCreateAndJoinCompletedHandler(Lobby lobby, int result);

		public delegate void OnLobbyDisconnectedHandler(Lobby lobby);

		public delegate void OnLobbyMemberAddedHandler(Lobby lobby, PFEntityKey member);

		public delegate void OnLobbyMemberRemovedHandler(Lobby lobby, PFEntityKey member, LobbyMemberRemovedReason reason);

		public delegate void OnAddMemberCompletedHandler(Lobby lobby, PFEntityKey localUser, int result);

		public delegate void OnForceRemoveMemberCompletedHandler(Lobby lobby, PFEntityKey targetMember, int result);

		public delegate void OnLobbyJoinCompletedHandler(Lobby lobby, PFEntityKey newMember, int result);

		public delegate void OnLobbyLeaveCompletedHandler(Lobby lobby, PFEntityKey localUser);

		public delegate void OnLobbyPostUpdateCompletedHandler(Lobby lobby, PFEntityKey localUser, int result);

		public delegate void OnLobbyJoinArrangedLobbyCompletedHandler(Lobby lobby, PFEntityKey newMember, int result);

		public delegate void OnLobbyFindLobbiesCompletedHandler(IList<LobbySearchResult> searchResults, PFEntityKey searchingEntity, int result);

		public delegate void OnLobbyUpdatedHandler(Lobby lobby, bool ownerUpdated, bool maxMembersUpdated, bool accessPolicyUpdated, bool membershipLockUpdated, IList<string> updatedSearchPropertyKeys, IList<string> updatedLobbyPropertyKeys, IList<LobbyMemberUpdateSummary> memberUpdates);

		public delegate void OnLobbySendInviteCompletedHandler(Lobby lobby, PFEntityKey sender, PFEntityKey invitee, int result);

		public delegate void OnLobbyInviteReceivedHandler(PFEntityKey listeningEntity, PFEntityKey invitingEntity, string connectionString);

		public delegate void OnLobbyInviteListenerStatusChangedHandler(PFEntityKey listeningEntity, LobbyInviteListenerStatus newStatus);

		public delegate void OnMatchmakingTicketStatusChangedHandler(MatchmakingTicket ticket);

		public delegate void OnMatchmakingTicketCompletedHandler(MatchmakingTicket ticket, int result);

		internal enum PFMultiplayerInitStatus
		{
			Uninitialized = 0,
			Initialized = 1,
			CleanupStarted = 2
		}

		public class PlayFabMultiplayerServer
		{
			public delegate void OnServerLobbyCreateAndClaimCompletedHandler(Lobby lobby, int result);

			public delegate void OnServerLobbyClaimCompletedHandler(Lobby lobby, string lobbyId, int result);

			public delegate void OnServerLobbyPostUpdateCompletedHandler(Lobby lobby, int result);

			public delegate void OnServerLobbyDeleteCompletedHandler(Lobby lobby);

			public delegate void OnServerLobbyJoinAsServerCompletedHandler(Lobby lobby, int result);

			public delegate void OnServerLobbyPostUpdateAsServerCompletedHandler(Lobby lobby, int result);

			public delegate void OnServerLobbyLeaveAsServerCompletedHandler(Lobby lobby);

			public static event OnServerLobbyCreateAndClaimCompletedHandler OnServerLobbyCreateAndClaimCompleted;

			public static event OnServerLobbyClaimCompletedHandler OnServerLobbyClaimCompleted;

			public static event OnServerLobbyPostUpdateCompletedHandler OnServerLobbyPostUpdateCompleted;

			public static event OnServerLobbyDeleteCompletedHandler OnServerLobbyDeleteCompleted;

			public static event OnServerLobbyJoinAsServerCompletedHandler OnJoinLobbyAsServerCompleted;

			public static event OnServerLobbyPostUpdateAsServerCompletedHandler OnServerLobbyPostUpdateAsServerCompleted;

			public static event OnServerLobbyLeaveAsServerCompletedHandler OnServerLobbyLeaveAsServerCompleted;

			public static Lobby CreateAndClaimServerLobby(PlayFabAuthenticationContext server, LobbyCreateConfiguration createConfiguration)
			{
				SetEntityToken(server);
				return CreateAndClaimServerLobby(new PFEntityKey(server), createConfiguration);
			}

			public static Lobby CreateAndClaimServerLobby(PFEntityKey server, LobbyCreateConfiguration createConfiguration)
			{
				if (Succeeded(PFMultiplayerServer.PFMultiplayerCreateAndClaimServerLobby(multiplayerHandle, server.EntityKey, createConfiguration.Config, null, out var lobby)))
				{
					return Lobby.GetLobbyUsingCache(lobby);
				}
				return null;
			}

			public static Lobby ClaimServerLobby(PlayFabAuthenticationContext server, string lobbyId)
			{
				SetEntityToken(server);
				return ClaimServerLobby(new PFEntityKey(server), lobbyId);
			}

			public static Lobby ClaimServerLobby(PFEntityKey server, string lobbyId)
			{
				if (Succeeded(PFMultiplayerServer.PFMultiplayerClaimServerLobby(multiplayerHandle, server.EntityKey, lobbyId, null, out var lobby)))
				{
					return Lobby.GetLobbyUsingCache(lobby);
				}
				return null;
			}

			public static MatchmakingTicket CreateServerBackfillTicket(PFEntityKey server, string queueName, List<MatchUser> matchMembers, MultiplayerServerDetails serverDetails, uint timeoutInSeconds = 300u)
			{
				List<PFMatchmakingMatchMember> list = new List<PFMatchmakingMatchMember>(matchMembers.Count);
				for (int i = 0; i < matchMembers.Count; i++)
				{
					list.Add(new PFMatchmakingMatchMember());
					list[i].EntityKey = matchMembers[i].LocalUser.EntityKey;
					list[i].TeamId = matchMembers[i].TeamId;
					list[i].Attributes = matchMembers[i].LocalUserJsonAttributesJSON;
				}
				if (Succeeded(PFMultiplayerServer.PFMultiplayerCreateServerBackfillTicket(multiplayerHandle, server.EntityKey, new PFMatchmakingServerBackfillTicketConfiguration(timeoutInSeconds, queueName, list, serverDetails.PFMultiplayerServerDetails), null, out var handle)))
				{
					return MatchmakingTicket.GetMatchmakingTicketUsingCache(handle);
				}
				return null;
			}

			public static Lobby JoinLobbyAsServer(PlayFabAuthenticationContext server, string connectionString, LobbyServerJoinConfiguration configuration)
			{
				SetEntityToken(server);
				return JoinLobbyAsServer(new PFEntityKey(server), connectionString, configuration);
			}

			public static Lobby JoinLobbyAsServer(PFEntityKey server, string connectionString, LobbyServerJoinConfiguration configuration)
			{
				if (Succeeded(PFMultiplayerServer.PFMultiplayerJoinLobbyAsServer(multiplayerHandle, server.EntityKey, connectionString, configuration.Config, null, out var lobby)))
				{
					return Lobby.GetLobbyUsingCache(lobby);
				}
				return null;
			}

			internal static void ProcessServerLobbyStateChanges(PFLobbyStateChange stateChange)
			{
				switch (stateChange.StateChangeType)
				{
				case PFLobbyStateChangeType.CreateAndClaimServerLobbyCompleted:
				{
					PFLobbyCreateAndClaimServerLobbyCompletedStateChange pFLobbyCreateAndClaimServerLobbyCompletedStateChange = (PFLobbyCreateAndClaimServerLobbyCompletedStateChange)stateChange;
					Succeeded(pFLobbyCreateAndClaimServerLobbyCompletedStateChange.result);
					PlayFabMultiplayerServer.OnServerLobbyCreateAndClaimCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyCreateAndClaimServerLobbyCompletedStateChange.lobby), pFLobbyCreateAndClaimServerLobbyCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.ClaimServerLobbyCompleted:
				{
					PFLobbyClaimServerLobbyCompletedStateChange pFLobbyClaimServerLobbyCompletedStateChange = (PFLobbyClaimServerLobbyCompletedStateChange)stateChange;
					Succeeded(pFLobbyClaimServerLobbyCompletedStateChange.result);
					PlayFabMultiplayerServer.OnServerLobbyClaimCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyClaimServerLobbyCompletedStateChange.lobby), pFLobbyClaimServerLobbyCompletedStateChange.lobbyId, pFLobbyClaimServerLobbyCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.ServerPostUpdateCompleted:
				{
					PFLobbyServerPostUpdateCompletedStateChange pFLobbyServerPostUpdateCompletedStateChange = (PFLobbyServerPostUpdateCompletedStateChange)stateChange;
					Succeeded(pFLobbyServerPostUpdateCompletedStateChange.result);
					PlayFabMultiplayerServer.OnServerLobbyPostUpdateCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyServerPostUpdateCompletedStateChange.lobby), pFLobbyServerPostUpdateCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.ServerDeleteLobbyCompleted:
				{
					PFLobbyServerDeleteLobbyCompletedStateChange pFLobbyServerDeleteLobbyCompletedStateChange = (PFLobbyServerDeleteLobbyCompletedStateChange)stateChange;
					PlayFabMultiplayerServer.OnServerLobbyDeleteCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyServerDeleteLobbyCompletedStateChange.lobby));
					break;
				}
				case PFLobbyStateChangeType.JoinLobbyAsServerCompleted:
				{
					PFLobbyJoinLobbyAsServerCompletedStateChange pFLobbyJoinLobbyAsServerCompletedStateChange = (PFLobbyJoinLobbyAsServerCompletedStateChange)stateChange;
					PlayFabMultiplayerServer.OnJoinLobbyAsServerCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyJoinLobbyAsServerCompletedStateChange.lobby), pFLobbyJoinLobbyAsServerCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.ServerPostUpdateAsServerCompleted:
				{
					PFLobbyServerPostUpdateAsServerCompletedStateChange pFLobbyServerPostUpdateAsServerCompletedStateChange = (PFLobbyServerPostUpdateAsServerCompletedStateChange)stateChange;
					PlayFabMultiplayerServer.OnServerLobbyPostUpdateAsServerCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyServerPostUpdateAsServerCompletedStateChange.lobby), pFLobbyServerPostUpdateAsServerCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.ServerLeaveLobbyAsServerCompleted:
				{
					PFLobbyServerLeaveLobbyAsServerCompletedStateChange pFLobbyServerLeaveLobbyAsServerCompletedStateChange = (PFLobbyServerLeaveLobbyAsServerCompletedStateChange)stateChange;
					PlayFabMultiplayerServer.OnServerLobbyLeaveAsServerCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyServerLeaveLobbyAsServerCompletedStateChange.lobby));
					break;
				}
				}
			}
		}

		public const uint LobbyMaxMemberCountLowerLimit = 2u;

		public const uint LobbyMaxMemberCountUpperLimit = 128u;

		public const uint LobbyMaxSearchPropertyCount = 30u;

		public const uint LobbyMaxLobbyPropertyCount = 30u;

		public const uint LobbyMaxMemberPropertyCount = 30u;

		public const uint LobbyMaxServerPropertyCount = 30u;

		public const uint LobbyClientRequestedSearchResultCountUpperLimit = 50u;

		private static PFMultiplayerInitStatus initStatus;

		private static PFMultiplayerHandle multiplayerHandle;

		private static LogLevelType logLevel;

		private static LobbyStateChangeCollection lobbyStateChanges;

		private static MatchmakingStateChangeCollection matchmakingStateChanges;

		public static LogLevelType LogLevel
		{
			get
			{
				return logLevel;
			}
			set
			{
				logLevel = value;
			}
		}

		public static bool IsInitialized => initStatus != PFMultiplayerInitStatus.Uninitialized;

		public static event OnErrorEventHandler OnError;

		public static event OnLobbyCreateAndJoinCompletedHandler OnLobbyCreateAndJoinCompleted;

		public static event OnLobbyDisconnectedHandler OnLobbyDisconnected;

		public static event OnLobbyMemberAddedHandler OnLobbyMemberAdded;

		public static event OnLobbyMemberRemovedHandler OnLobbyMemberRemoved;

		public static event OnAddMemberCompletedHandler OnAddMemberCompleted;

		public static event OnForceRemoveMemberCompletedHandler OnForceRemoveMemberCompleted;

		public static event OnLobbyJoinCompletedHandler OnLobbyJoinCompleted;

		public static event OnLobbyUpdatedHandler OnLobbyUpdated;

		public static event OnLobbyPostUpdateCompletedHandler OnLobbyPostUpdateCompleted;

		public static event OnLobbyJoinArrangedLobbyCompletedHandler OnLobbyJoinArrangedLobbyCompleted;

		public static event OnLobbyFindLobbiesCompletedHandler OnLobbyFindLobbiesCompleted;

		public static event OnLobbySendInviteCompletedHandler OnLobbySendInviteCompleted;

		public static event OnLobbyInviteReceivedHandler OnLobbyInviteReceived;

		public static event OnLobbyLeaveCompletedHandler OnLobbyLeaveCompleted;

		public static event OnLobbyInviteListenerStatusChangedHandler OnLobbyInviteListenerStatusChanged;

		public static event OnMatchmakingTicketStatusChangedHandler OnMatchmakingTicketStatusChanged;

		public static event OnMatchmakingTicketCompletedHandler OnMatchmakingTicketCompleted;

		public static void SetEntityToken(PlayFabAuthenticationContext localMember)
		{
			Succeeded(PFMultiplayer.PFMultiplayerSetEntityToken(multiplayerHandle, new PFEntityKey(localMember).EntityKey, localMember.EntityToken));
		}

		public static void SetEntityToken(PFEntityKey localMember, string entityToken)
		{
			Succeeded(PFMultiplayer.PFMultiplayerSetEntityToken(multiplayerHandle, localMember.EntityKey, entityToken));
		}

		public static Lobby CreateAndJoinLobby(PlayFabAuthenticationContext creator, LobbyCreateConfiguration createConfiguration, LobbyJoinConfiguration joinConfiguration)
		{
			SetEntityToken(creator);
			return CreateAndJoinLobby(new PFEntityKey(creator), createConfiguration, joinConfiguration);
		}

		public static Lobby CreateAndJoinLobby(PFEntityKey creator, LobbyCreateConfiguration createConfiguration, LobbyJoinConfiguration joinConfiguration)
		{
			if (Succeeded(PFMultiplayer.PFMultiplayerCreateAndJoinLobby(multiplayerHandle, creator.EntityKey, createConfiguration.Config, joinConfiguration.Config, null, out var lobby)))
			{
				return Lobby.GetLobbyUsingCache(lobby);
			}
			return null;
		}

		public static Lobby JoinLobby(PlayFabAuthenticationContext newMember, string connectionString, IDictionary<string, string> memberKeyValuePairs)
		{
			SetEntityToken(newMember);
			return JoinLobby(new PFEntityKey(newMember), connectionString, memberKeyValuePairs);
		}

		public static Lobby JoinLobby(PFEntityKey newMember, string connectionString, IDictionary<string, string> memberKeyValuePairs)
		{
			PFLobbyJoinConfiguration pFLobbyJoinConfiguration = new PFLobbyJoinConfiguration();
			if (memberKeyValuePairs != null)
			{
				pFLobbyJoinConfiguration.MemberProperties = (Dictionary<string, string>)memberKeyValuePairs;
			}
			if (Succeeded(PFMultiplayer.PFMultiplayerJoinLobby(multiplayerHandle, newMember.EntityKey, connectionString, pFLobbyJoinConfiguration, null, out var lobby)))
			{
				return Lobby.GetLobbyUsingCache(lobby);
			}
			return null;
		}

		public static Lobby JoinArrangedLobby(PlayFabAuthenticationContext newMember, string arrangementString, LobbyArrangedJoinConfiguration config)
		{
			SetEntityToken(newMember);
			return JoinArrangedLobby(new PFEntityKey(newMember), arrangementString, config);
		}

		public static Lobby JoinArrangedLobby(PFEntityKey newMember, string arrangementString, LobbyArrangedJoinConfiguration config)
		{
			if (Succeeded(PFMultiplayer.PFMultiplayerJoinArrangedLobby(multiplayerHandle, newMember.EntityKey, arrangementString, config.Config, null, out var lobby)))
			{
				return Lobby.GetLobbyUsingCache(lobby);
			}
			return null;
		}

		public static void FindLobbies(PlayFabAuthenticationContext searchingEntity, LobbySearchConfiguration searchConfiguration)
		{
			SetEntityToken(searchingEntity);
			Succeeded(PFMultiplayer.PFMultiplayerFindLobbies(multiplayerHandle, new PFEntityKey(searchingEntity).EntityKey, searchConfiguration.SearchConfig, null));
		}

		public static void FindLobbies(PFEntityKey searchingEntity, LobbySearchConfiguration searchConfiguration)
		{
			Succeeded(PFMultiplayer.PFMultiplayerFindLobbies(multiplayerHandle, searchingEntity.EntityKey, searchConfiguration.SearchConfig, null));
		}

		public static MatchmakingTicket CreateMatchmakingTicket(MatchUser localUser, string queueName, uint timeoutInSeconds = 120u)
		{
			return CreateMatchmakingTicket(new List<MatchUser> { localUser }, queueName, new List<PFEntityKey>(), timeoutInSeconds);
		}

		public static MatchmakingTicket CreateMatchmakingTicket(IList<MatchUser> localUsers, string queueName, uint timeoutInSeconds = 120u)
		{
			return CreateMatchmakingTicket(localUsers, queueName, new List<PFEntityKey>(), timeoutInSeconds);
		}

		public static MatchmakingTicket CreateMatchmakingTicket(IList<MatchUser> localUsers, string queueName, List<PFEntityKey> membersToMatchWith, uint timeoutInSeconds = 120u)
		{
			List<PlayFab.Multiplayer.InteropWrapper.PFEntityKey> membersToMatchWith2 = membersToMatchWith.Select((PFEntityKey x) => x.EntityKey).ToList();
			List<PlayFab.Multiplayer.InteropWrapper.PFEntityKey> list = localUsers.Select((MatchUser x) => x.LocalUser.EntityKey).ToList();
			List<string> list2 = localUsers.Select((MatchUser x) => x.LocalUserJsonAttributesJSON).ToList();
			if (Succeeded(PFMultiplayer.PFMultiplayerCreateMatchmakingTicket(multiplayerHandle, list.ToArray(), list2.ToArray(), new PFMatchmakingTicketConfiguration(timeoutInSeconds, queueName, membersToMatchWith2), null, out var handle)))
			{
				return MatchmakingTicket.GetMatchmakingTicketUsingCache(handle);
			}
			return null;
		}

		public static MatchmakingTicket JoinMatchmakingTicketFromId(MatchUser localUser, string ticketId, string queueName, IList<PFEntityKey> membersToMatchWith)
		{
			return JoinMatchmakingTicketFromId(new List<MatchUser> { localUser }, ticketId, queueName, membersToMatchWith);
		}

		public static MatchmakingTicket JoinMatchmakingTicketFromId(IList<MatchUser> localUsers, string ticketId, string queueName, IList<PFEntityKey> membersToMatchWith)
		{
			membersToMatchWith.Select((PFEntityKey x) => x.EntityKey).ToList();
			List<PlayFab.Multiplayer.InteropWrapper.PFEntityKey> list = localUsers.Select((MatchUser x) => x.LocalUser.EntityKey).ToList();
			List<string> list2 = localUsers.Select((MatchUser x) => x.LocalUserJsonAttributesJSON).ToList();
			if (Succeeded(PFMultiplayer.PFMultiplayerJoinMatchmakingTicketFromId(multiplayerHandle, list.ToArray(), list2.ToArray(), ticketId, queueName, null, out var handle)))
			{
				return MatchmakingTicket.GetMatchmakingTicketUsingCache(handle);
			}
			return null;
		}

		public static void StartListeningForLobbyInvites(PlayFabAuthenticationContext listeningEntity)
		{
			SetEntityToken(listeningEntity);
			StartListeningForLobbyInvites(new PFEntityKey(listeningEntity));
		}

		public static void StopListeningForLobbyInvites(PlayFabAuthenticationContext listeningEntity)
		{
			StopListeningForLobbyInvites(new PFEntityKey(listeningEntity));
		}

		public static LobbyInviteListenerStatus GetLobbyInviteListenerStatus(PlayFabAuthenticationContext listeningEntity)
		{
			SetEntityToken(listeningEntity);
			return GetLobbyInviteListenerStatus(new PFEntityKey(listeningEntity));
		}

		public static void StartListeningForLobbyInvites(PFEntityKey listeningEntity)
		{
			Succeeded(PFMultiplayer.PFMultiplayerStartListeningForLobbyInvites(multiplayerHandle, listeningEntity.EntityKey));
		}

		public static void StopListeningForLobbyInvites(PFEntityKey listeningEntity)
		{
			Succeeded(PFMultiplayer.PFMultiplayerStopListeningForLobbyInvites(multiplayerHandle, listeningEntity.EntityKey));
		}

		public static LobbyInviteListenerStatus GetLobbyInviteListenerStatus(PFEntityKey listeningEntity)
		{
			Succeeded(PFMultiplayer.PFMultiplayerGetLobbyInviteListenerStatus(multiplayerHandle, listeningEntity.EntityKey, out var status));
			return (LobbyInviteListenerStatus)status;
		}

		public static void Initialize()
		{
			string titleId = PlayFabSettings.TitleId;
			if (string.IsNullOrEmpty(titleId))
			{
				throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "PlayFab.PlayFabSettings.TitleId must be set");
			}
			if (initStatus != PFMultiplayerInitStatus.Uninitialized)
			{
				LogInfo("PlayFabMultiplayer already initialized");
				return;
			}
			logLevel = LogLevelType.Minimal;
			int num = PFMultiplayer.PFMultiplayerInitialize(titleId, out multiplayerHandle);
			Succeeded(num);
			if (LobbyError.FAILED(num))
			{
				string text = PFMultiplayer.PFMultiplayerGetErrorMessage(num);
				throw new Exception("PlayFabMultiplayer.Initialize failed. " + text);
			}
			initStatus = PFMultiplayerInitStatus.Initialized;
			SingletonMonoBehaviour<PlayFabMultiplayerEventTracer>.instance.OnPlayFabMultiPlayerInitialize();
		}

		public static void Uninitialize()
		{
			if (initStatus != PFMultiplayerInitStatus.Initialized)
			{
				LogInfo("PlayFabMultiplayer not initialized");
				return;
			}
			LogInfo("PlayFabMultiplayer.Uninitialize");
			initStatus = PFMultiplayerInitStatus.CleanupStarted;
			Succeeded(PFMultiplayer.PFMultiplayerUninitialize(multiplayerHandle));
			multiplayerHandle = null;
			initStatus = PFMultiplayerInitStatus.Uninitialized;
		}

		public static void ProcessLobbyStateChanges()
		{
			if (multiplayerHandle == null || !Succeeded(PFMultiplayer.PFMultiplayerStartProcessingLobbyStateChanges(multiplayerHandle, out lobbyStateChanges)))
			{
				return;
			}
			foreach (PFLobbyStateChange stateChange in lobbyStateChanges.StateChanges)
			{
				LogInfo("Lobby State change: " + stateChange.StateChangeType);
				switch (stateChange.StateChangeType)
				{
				case PFLobbyStateChangeType.CreateAndJoinLobbyCompleted:
				{
					PFLobbyCreateAndJoinCompletedStateChange pFLobbyCreateAndJoinCompletedStateChange = (PFLobbyCreateAndJoinCompletedStateChange)stateChange;
					Succeeded(pFLobbyCreateAndJoinCompletedStateChange.result);
					PlayFabMultiplayer.OnLobbyCreateAndJoinCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyCreateAndJoinCompletedStateChange.lobby), pFLobbyCreateAndJoinCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.JoinLobbyCompleted:
				{
					PFLobbyJoinCompletedStateChange pFLobbyJoinCompletedStateChange = (PFLobbyJoinCompletedStateChange)stateChange;
					Succeeded(pFLobbyJoinCompletedStateChange.result);
					PlayFabMultiplayer.OnLobbyJoinCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyJoinCompletedStateChange.lobby), new PFEntityKey(pFLobbyJoinCompletedStateChange.newMember), pFLobbyJoinCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.MemberAdded:
				{
					PFLobbyMemberAddedStateChange pFLobbyMemberAddedStateChange = (PFLobbyMemberAddedStateChange)stateChange;
					PlayFabMultiplayer.OnLobbyMemberAdded?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyMemberAddedStateChange.lobby), new PFEntityKey(pFLobbyMemberAddedStateChange.member));
					break;
				}
				case PFLobbyStateChangeType.AddMemberCompleted:
				{
					PFLobbyAddMemberCompletedStateChange pFLobbyAddMemberCompletedStateChange = (PFLobbyAddMemberCompletedStateChange)stateChange;
					Succeeded(pFLobbyAddMemberCompletedStateChange.result);
					PlayFabMultiplayer.OnAddMemberCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyAddMemberCompletedStateChange.lobby), new PFEntityKey(pFLobbyAddMemberCompletedStateChange.localUser), pFLobbyAddMemberCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.MemberRemoved:
				{
					PFLobbyMemberRemovedStateChange pFLobbyMemberRemovedStateChange = (PFLobbyMemberRemovedStateChange)stateChange;
					PlayFabMultiplayer.OnLobbyMemberRemoved?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyMemberRemovedStateChange.lobby), new PFEntityKey(pFLobbyMemberRemovedStateChange.member), (LobbyMemberRemovedReason)pFLobbyMemberRemovedStateChange.reason);
					break;
				}
				case PFLobbyStateChangeType.ForceRemoveMemberCompleted:
				{
					PFLobbyForceRemoveMemberCompletedStateChange pFLobbyForceRemoveMemberCompletedStateChange = (PFLobbyForceRemoveMemberCompletedStateChange)stateChange;
					PlayFabMultiplayer.OnForceRemoveMemberCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyForceRemoveMemberCompletedStateChange.lobby), new PFEntityKey(pFLobbyForceRemoveMemberCompletedStateChange.targetMember), pFLobbyForceRemoveMemberCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.Updated:
				{
					PFLobbyUpdatedStateChange pFLobbyUpdatedStateChange = (PFLobbyUpdatedStateChange)stateChange;
					List<LobbyMemberUpdateSummary> list2 = new List<LobbyMemberUpdateSummary>();
					PFLobbyMemberUpdateSummary[] memberUpdates = pFLobbyUpdatedStateChange.memberUpdates;
					foreach (PFLobbyMemberUpdateSummary summary in memberUpdates)
					{
						list2.Add(new LobbyMemberUpdateSummary(summary));
					}
					PlayFabMultiplayer.OnLobbyUpdated?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyUpdatedStateChange.lobby), pFLobbyUpdatedStateChange.ownerUpdated, pFLobbyUpdatedStateChange.maxMembersUpdated, pFLobbyUpdatedStateChange.accessPolicyUpdated, pFLobbyUpdatedStateChange.membershipLockUpdated, pFLobbyUpdatedStateChange.updatedSearchPropertyKeys.ToList(), pFLobbyUpdatedStateChange.updatedLobbyPropertyKeys.ToList(), list2);
					break;
				}
				case PFLobbyStateChangeType.PostUpdateCompleted:
				{
					PFLobbyPostUpdateCompletedStateChange pFLobbyPostUpdateCompletedStateChange = (PFLobbyPostUpdateCompletedStateChange)stateChange;
					Succeeded(pFLobbyPostUpdateCompletedStateChange.result);
					PlayFabMultiplayer.OnLobbyPostUpdateCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyPostUpdateCompletedStateChange.lobby), new PFEntityKey(pFLobbyPostUpdateCompletedStateChange.localUser), pFLobbyPostUpdateCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.LeaveLobbyCompleted:
				{
					PFLobbyLeaveCompletedStateChange pFLobbyLeaveCompletedStateChange = (PFLobbyLeaveCompletedStateChange)stateChange;
					PlayFabMultiplayer.OnLobbyLeaveCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyLeaveCompletedStateChange.lobby), new PFEntityKey(pFLobbyLeaveCompletedStateChange.localUser));
					break;
				}
				case PFLobbyStateChangeType.Disconnecting:
				{
					PFLobbyDisconnectingStateChange pFLobbyDisconnectingStateChange = (PFLobbyDisconnectingStateChange)stateChange;
					LogInfo("LobbyDisconnecting due to " + pFLobbyDisconnectingStateChange.reason);
					break;
				}
				case PFLobbyStateChangeType.Disconnected:
				{
					PFLobbyDisconnectedStateChange pFLobbyDisconnectedStateChange = (PFLobbyDisconnectedStateChange)stateChange;
					PlayFabMultiplayer.OnLobbyDisconnected?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyDisconnectedStateChange.lobby));
					Lobby.ClearLobbyFromCache(pFLobbyDisconnectedStateChange.lobby);
					break;
				}
				case PFLobbyStateChangeType.JoinArrangedLobbyCompleted:
				{
					PFLobbyArrangedJoinCompletedStateChange pFLobbyArrangedJoinCompletedStateChange = (PFLobbyArrangedJoinCompletedStateChange)stateChange;
					Succeeded(pFLobbyArrangedJoinCompletedStateChange.result);
					PlayFabMultiplayer.OnLobbyJoinArrangedLobbyCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbyArrangedJoinCompletedStateChange.lobby), new PFEntityKey(pFLobbyArrangedJoinCompletedStateChange.newMember), pFLobbyArrangedJoinCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.FindLobbiesCompleted:
				{
					PFLobbyFindLobbiesCompletedStateChange pFLobbyFindLobbiesCompletedStateChange = (PFLobbyFindLobbiesCompletedStateChange)stateChange;
					Succeeded(pFLobbyFindLobbiesCompletedStateChange.result);
					List<LobbySearchResult> list = new List<LobbySearchResult>();
					foreach (PFLobbySearchResult searchResult in pFLobbyFindLobbiesCompletedStateChange.searchResults)
					{
						list.Add(new LobbySearchResult(searchResult));
					}
					PlayFabMultiplayer.OnLobbyFindLobbiesCompleted?.Invoke(list, new PFEntityKey(pFLobbyFindLobbiesCompletedStateChange.searchingEntity), pFLobbyFindLobbiesCompletedStateChange.result);
					break;
				}
				case PFLobbyStateChangeType.InviteReceived:
				{
					PFLobbyInviteReceivedStateChange pFLobbyInviteReceivedStateChange = (PFLobbyInviteReceivedStateChange)stateChange;
					PlayFabMultiplayer.OnLobbyInviteReceived?.Invoke(new PFEntityKey(pFLobbyInviteReceivedStateChange.listeningEntity), new PFEntityKey(pFLobbyInviteReceivedStateChange.invitingEntity), pFLobbyInviteReceivedStateChange.connectionString);
					break;
				}
				case PFLobbyStateChangeType.InviteListenerStatusChanged:
				{
					PFEntityKey listeningEntity = new PFEntityKey(((PFLobbyInviteListenerStatusChangedStateChange)stateChange).listeningEntity);
					LobbyInviteListenerStatus lobbyInviteListenerStatus = GetLobbyInviteListenerStatus(listeningEntity);
					PlayFabMultiplayer.OnLobbyInviteListenerStatusChanged?.Invoke(listeningEntity, lobbyInviteListenerStatus);
					break;
				}
				case PFLobbyStateChangeType.SendInviteCompleted:
				{
					PFLobbySendInviteCompletedStateChange pFLobbySendInviteCompletedStateChange = (PFLobbySendInviteCompletedStateChange)stateChange;
					Succeeded(pFLobbySendInviteCompletedStateChange.result);
					PlayFabMultiplayer.OnLobbySendInviteCompleted?.Invoke(Lobby.GetLobbyUsingCache(pFLobbySendInviteCompletedStateChange.lobby), new PFEntityKey(pFLobbySendInviteCompletedStateChange.sender), new PFEntityKey(pFLobbySendInviteCompletedStateChange.invitee), pFLobbySendInviteCompletedStateChange.result);
					break;
				}
				default:
					PlayFabMultiplayerServer.ProcessServerLobbyStateChanges(stateChange);
					break;
				}
			}
			Succeeded(PFMultiplayer.PFMultiplayerFinishProcessingLobbyStateChanges(multiplayerHandle, lobbyStateChanges));
		}

		public static void ProcessMatchmakingStateChanges()
		{
			if (multiplayerHandle == null || !Succeeded(PFMultiplayer.PFMultiplayerStartProcessingMatchmakingStateChanges(multiplayerHandle, out matchmakingStateChanges)))
			{
				return;
			}
			foreach (PFMatchmakingStateChange stateChange in matchmakingStateChanges.StateChanges)
			{
				LogInfo("Matchmaking State change: " + stateChange.StateChangeType);
				switch (stateChange.StateChangeType)
				{
				case PFMatchmakingStateChangeType.TicketStatusChanged:
				{
					MatchmakingTicket matchmakingTicketUsingCache = MatchmakingTicket.GetMatchmakingTicketUsingCache(((PFMatchmakingTicketStatusChangedStateChange)stateChange).Ticket);
					PlayFabMultiplayer.OnMatchmakingTicketStatusChanged?.Invoke(matchmakingTicketUsingCache);
					break;
				}
				case PFMatchmakingStateChangeType.TicketCompleted:
				{
					PFMatchmakingTicketCompletedStateChange pFMatchmakingTicketCompletedStateChange = (PFMatchmakingTicketCompletedStateChange)stateChange;
					if (LobbyError.FAILED(pFMatchmakingTicketCompletedStateChange.Result))
					{
						LogError(pFMatchmakingTicketCompletedStateChange.Result.ToString());
						Succeeded(pFMatchmakingTicketCompletedStateChange.Result);
					}
					PlayFabMultiplayer.OnMatchmakingTicketCompleted?.Invoke(MatchmakingTicket.GetMatchmakingTicketUsingCache(pFMatchmakingTicketCompletedStateChange.Ticket), pFMatchmakingTicketCompletedStateChange.Result);
					MatchmakingTicket.ClearMatchmakingTicketFromCache(pFMatchmakingTicketCompletedStateChange.Ticket);
					PFMultiplayer.PFMultiplayerDestroyMatchmakingTicket(multiplayerHandle, pFMatchmakingTicketCompletedStateChange.Ticket);
					break;
				}
				}
			}
			Succeeded(PFMultiplayer.PFMultiplayerFinishProcessingMatchmakingStateChanges(multiplayerHandle, matchmakingStateChanges));
		}

		internal static void LogError(string message)
		{
			if (initStatus != PFMultiplayerInitStatus.CleanupStarted && logLevel != LogLevelType.None)
			{
				Debug.LogError(message);
			}
		}

		internal static void LogError(int code)
		{
			string text = PFMultiplayer.PFMultiplayerGetErrorMessage(code);
			if (text == null)
			{
				text = "Unknown error";
			}
			text += $" 0x{(uint)code:X}";
			if (initStatus != PFMultiplayerInitStatus.CleanupStarted && PlayFabMultiplayer.OnError != null)
			{
				PlayFabMultiplayerErrorArgs args = new PlayFabMultiplayerErrorArgs(code, text);
				PlayFabMultiplayer.OnError(args);
			}
			LogError(text);
		}

		internal static void LogWarning(string warningMessage)
		{
			if (logLevel >= LogLevelType.Verbose)
			{
				Debug.LogWarning(warningMessage);
			}
		}

		internal static void LogInfo(string infoMessage)
		{
			if (logLevel >= LogLevelType.Verbose)
			{
				Debug.Log(infoMessage);
			}
		}

		internal static bool Succeeded(int errorCode)
		{
			bool result = false;
			if (LobbyError.FAILED(errorCode))
			{
				LogError(errorCode);
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
