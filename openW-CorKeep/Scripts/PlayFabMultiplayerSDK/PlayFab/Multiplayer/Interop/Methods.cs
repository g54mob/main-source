using System;
using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.Interop
{
	public static class Methods
	{
		private const string ThunkDllName = "PlayFabMultiplayerWin.dll";

		public const uint PFLobbyMaxMemberCountLowerLimit = 2u;

		public const uint PFLobbyMaxMemberCountUpperLimit = 128u;

		public const uint PFLobbyMaxSearchPropertyCount = 30u;

		public const uint PFLobbyMaxLobbyPropertyCount = 30u;

		public const uint PFLobbyMaxMemberPropertyCount = 30u;

		public const uint PFLobbyMaxServerPropertyCount = 30u;

		public const uint PFLobbyClientRequestedSearchResultCountUpperLimit = 50u;

		public const ulong PFMultiplayerAnyProcessor = ulong.MaxValue;

		public static ReadOnlySpan<byte> PFLobbyMemberCountSearchKey => new byte[18]
		{
			108, 111, 98, 98, 121, 47, 109, 101, 109, 98,
			101, 114, 67, 111, 117, 110, 116, 0
		};

		public static ReadOnlySpan<byte> PFLobbyMemberCountRemainingSearchKey => new byte[27]
		{
			108, 111, 98, 98, 121, 47, 109, 101, 109, 98,
			101, 114, 67, 111, 117, 110, 116, 82, 101, 109,
			97, 105, 110, 105, 110, 103, 0
		};

		public static ReadOnlySpan<byte> PFLobbyAmMemberSearchKey => new byte[15]
		{
			108, 111, 98, 98, 121, 47, 97, 109, 77, 101,
			109, 98, 101, 114, 0
		};

		public static ReadOnlySpan<byte> PFLobbyAmOwnerSearchKey => new byte[14]
		{
			108, 111, 98, 98, 121, 47, 97, 109, 79, 119,
			110, 101, 114, 0
		};

		public static ReadOnlySpan<byte> PFLobbyMembershipLockSearchKey => new byte[21]
		{
			108, 111, 98, 98, 121, 47, 109, 101, 109, 98,
			101, 114, 115, 104, 105, 112, 76, 111, 99, 107,
			0
		};

		public static ReadOnlySpan<byte> PFLobbyAmServerSearchKey => new byte[15]
		{
			108, 111, 98, 98, 121, 47, 97, 109, 83, 101,
			114, 118, 101, 114, 0
		};

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetLobbyId(PFLobby* lobby, sbyte** id);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetMaxMemberCount(PFLobby* lobby, uint* maxMemberCount);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetOwner(PFLobby* lobby, PFEntityKey** owner);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetOwnerMigrationPolicy(PFLobby* lobby, PFLobbyOwnerMigrationPolicy* ownerMigrationPolicy);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetAccessPolicy(PFLobby* lobby, PFLobbyAccessPolicy* accessPolicy);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetMembershipLock(PFLobby* lobby, PFLobbyMembershipLock* lockState);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetConnectionString(PFLobby* lobby, sbyte** connectionString);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetMembers(PFLobby* lobby, uint* memberCount, PFEntityKey** members);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyAddMember(PFLobby* lobby, PFEntityKey* localUser, uint memberPropertyCount, sbyte** memberPropertyKeys, sbyte** memberPropertyValues, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyForceRemoveMember(PFLobby* lobby, PFEntityKey* targetMember, byte preventRejoin, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyLeave(PFLobby* lobby, PFEntityKey* localUser, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetSearchPropertyKeys(PFLobby* lobby, uint* propertyCount, sbyte*** keys);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetSearchProperty(PFLobby* lobby, sbyte* key, sbyte** value);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetLobbyPropertyKeys(PFLobby* lobby, uint* propertyCount, sbyte*** keys);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetLobbyProperty(PFLobby* lobby, sbyte* key, sbyte** value);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetMemberPropertyKeys(PFLobby* lobby, PFEntityKey* member, uint* propertyCount, sbyte*** keys);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetMemberProperty(PFLobby* lobby, PFEntityKey* member, sbyte* key, sbyte** value);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetMemberConnectionStatus(PFLobby* lobby, PFEntityKey* member, PFLobbyMemberConnectionStatus* connectionStatus);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetServer(PFLobby* lobby, PFEntityKey** server);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetServerPropertyKeys(PFLobby* lobby, uint* propertyCount, sbyte*** keys);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetServerProperty(PFLobby* lobby, sbyte* key, sbyte** value);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetServerConnectionStatus(PFLobby* lobby, PFLobbyServerConnectionStatus* connectionStatus);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyPostUpdate(PFLobby* lobby, PFEntityKey* localUser, PFLobbyDataUpdate* lobbyUpdate, PFLobbyMemberDataUpdate* memberUpdate, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbySendInvite(PFLobby* lobby, PFEntityKey* sender, PFEntityKey* invitee, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyGetCustomContext(PFLobby* lobby, void** customContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbySetCustomContext(PFLobby* lobby, void* customContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerStartProcessingLobbyStateChanges(PFMultiplayer* handle, uint* stateChangeCount, PFLobbyStateChange*** stateChanges);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerFinishProcessingLobbyStateChanges(PFMultiplayer* handle, uint stateChangeCount, PFLobbyStateChange** stateChanges);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerCreateAndJoinLobby(PFMultiplayer* handle, PFEntityKey* creator, PFLobbyCreateConfiguration* createConfiguration, PFLobbyJoinConfiguration* joinConfiguration, void* asyncContext, PFLobby** lobby);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerJoinLobby(PFMultiplayer* handle, PFEntityKey* newMember, sbyte* connectionString, PFLobbyJoinConfiguration* configuration, void* asyncContext, PFLobby** lobby);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerJoinArrangedLobby(PFMultiplayer* handle, PFEntityKey* newMember, sbyte* arrangementString, PFLobbyArrangedJoinConfiguration* configuration, void* asyncContext, PFLobby** lobby);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerFindLobbies(PFMultiplayer* handle, PFEntityKey* searchingEntity, PFLobbySearchConfiguration* searchConfiguration, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerStartListeningForLobbyInvites(PFMultiplayer* handle, PFEntityKey* listeningEntity);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerStopListeningForLobbyInvites(PFMultiplayer* handle, PFEntityKey* listeningEntity);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerGetLobbyInviteListenerStatus(PFMultiplayer* handle, PFEntityKey* listeningEntity, PFLobbyInviteListenerStatus* status);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerCreateAndClaimServerLobby(PFMultiplayer* handle, PFEntityKey* server, PFLobbyCreateConfiguration* createConfiguration, void* asyncContext, PFLobby** lobby);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerClaimServerLobby(PFMultiplayer* handle, PFEntityKey* server, sbyte* lobbyId, void* asyncContext, PFLobby** lobby);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerJoinLobbyAsServer(PFMultiplayer* handle, PFEntityKey* server, sbyte* connectionString, PFLobbyServerJoinConfiguration* configuration, void* asyncContext, PFLobby** lobby);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyServerPostUpdate(PFLobby* lobby, PFLobbyDataUpdate* lobbyUpdate, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyServerPostUpdateAsServer(PFLobby* lobby, PFLobbyServerDataUpdate* lobbyServerUpdate, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyServerLeaveAsServer(PFLobby* lobby, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFLobbyServerDeleteLobby(PFLobby* lobby, void* asyncContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerStartProcessingMatchmakingStateChanges(PFMultiplayer* handle, uint* stateChangeCount, PFMatchmakingStateChange*** stateChanges);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerFinishProcessingMatchmakingStateChanges(PFMultiplayer* handle, uint stateChangeCount, PFMatchmakingStateChange** stateChanges);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerCreateMatchmakingTicket(PFMultiplayer* handle, uint localUserCount, PFEntityKey* localUsers, sbyte** localUserAttributes, PFMatchmakingTicketConfiguration* configuration, void* asyncContext, PFMatchmakingTicket** ticket);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerJoinMatchmakingTicketFromId(PFMultiplayer* handle, uint localUserCount, PFEntityKey* localUsers, sbyte** localUserAttributes, sbyte* ticketId, sbyte* queueName, void* asyncContext, PFMatchmakingTicket** ticket);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerDestroyMatchmakingTicket(PFMultiplayer* handle, PFMatchmakingTicket* ticket);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMatchmakingTicketGetStatus(PFMatchmakingTicket* ticket, PFMatchmakingTicketStatus* status);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMatchmakingTicketCancel(PFMatchmakingTicket* ticket);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMatchmakingTicketGetTicketId(PFMatchmakingTicket* ticket, sbyte** id);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMatchmakingTicketGetMatch(PFMatchmakingTicket* ticket, PFMatchmakingMatchDetails** match);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMatchmakingTicketGetCustomContext(PFMatchmakingTicket* ticket, void** customContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMatchmakingTicketSetCustomContext(PFMatchmakingTicket* ticket, void* customContext);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerCreateServerBackfillTicket(PFMultiplayer* handle, PFEntityKey* server, PFMatchmakingServerBackfillTicketConfiguration* configuration, void* asyncContext, PFMatchmakingTicket** ticket);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern sbyte* PFMultiplayerGetErrorMessage(int error);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int PFMultiplayerSetMemoryCallbacks(IntPtr allocateMemoryCallback, IntPtr freeMemoryCallback);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int PFMultiplayerSetThreadAffinityMask(PFMultiplayerThreadId threadId, ulong threadAffinityMask);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerInitialize(sbyte* playFabTitleId, PFMultiplayer** handle);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerUninitialize(PFMultiplayer* handle);

		[DllImport("PlayFabMultiplayerWin.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int PFMultiplayerSetEntityToken(PFMultiplayer* handle, PFEntityKey* entity, sbyte* entityToken);
	}
}
