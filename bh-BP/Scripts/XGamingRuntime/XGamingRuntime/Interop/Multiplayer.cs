using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class Multiplayer
	{
		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference* sessionReference, XblMultiplayerSessionReferenceUri* sessionReferenceUri);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionDuplicateHandle(IntPtr handle, IntPtr* duplicatedHandle);

		[PreserveSig]
		public static extern long XblMultiplayerSessionTimeOfSession(IntPtr handle);

		[PreserveSig]
		public unsafe static extern XblMultiplayerSessionInitializationInfo* XblMultiplayerSessionGetInitializationInfo(IntPtr handle);

		[PreserveSig]
		public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(IntPtr handle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionHostCandidates(IntPtr handle, XblDeviceToken** deviceTokens, SizeT* deviceTokensCount);

		[PreserveSig]
		public unsafe static extern XblMultiplayerSessionReference* XblMultiplayerSessionSessionReference(IntPtr handle);

		[PreserveSig]
		public unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerSessionSessionConstants(IntPtr handle);

		[PreserveSig]
		public static extern void XblMultiplayerSessionConstantsSetMaxMembersInSession(IntPtr handle, uint maxMembersInSession);

		[PreserveSig]
		public static extern void XblMultiplayerSessionConstantsSetVisibility(IntPtr handle, XblMultiplayerSessionVisibility visibility);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetTimeouts(IntPtr handle, ulong memberReservedTimeout, ulong memberInactiveTimeout, ulong memberReadyTimeout, ulong sessionEmptyTimeout);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetArbitrationTimeouts(IntPtr handle, ulong arbitrationTimeout, ulong forfeitTimeout);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(IntPtr handle, byte enableLatencyMetric, byte enableBandwidthDownMetric, byte enableBandwidthUpMetric, byte enableCustomMetric);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetMemberInitialization(IntPtr handle, XblMultiplayerMemberInitialization memberInitialization);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(IntPtr handle, XblMultiplayerPeerToPeerRequirements requirements);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetPeerToHostRequirements(IntPtr handle, XblMultiplayerPeerToHostRequirements requirements);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(IntPtr handle, sbyte* measurementServerAddressesJson);

		[PreserveSig]
		public static extern int XblMultiplayerSessionConstantsSetCapabilities(IntPtr handle, XblMultiplayerSessionCapabilities capabilities);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionConstantsSetCloudComputePackageJson(IntPtr handle, sbyte* sessionCloudComputePackageConstantsJson);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionPropertiesSetKeywords(IntPtr handle, sbyte** keywords, SizeT keywordsCount);

		[PreserveSig]
		public static extern void XblMultiplayerSessionPropertiesSetJoinRestriction(IntPtr handle, XblMultiplayerSessionRestriction joinRestriction);

		[PreserveSig]
		public static extern void XblMultiplayerSessionPropertiesSetReadRestriction(IntPtr handle, XblMultiplayerSessionRestriction readRestriction);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionPropertiesSetTurnCollection(IntPtr handle, uint* turnCollectionMemberIds, SizeT turnCollectionMemberIdsCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionRoleTypes(IntPtr handle, XblMultiplayerRoleType** roleTypes, SizeT* roleTypesCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionGetRoleByName(IntPtr handle, sbyte* roleTypeName, sbyte* roleName, XblMultiplayerRole** role);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionSetMutableRoleSettings(IntPtr handle, sbyte* roleTypeName, sbyte* roleName, uint* maxMemberCount, uint* targetMemberCount);

		[PreserveSig]
		public unsafe static extern XblMultiplayerSessionMember* XblMultiplayerSessionGetMember(IntPtr handle, uint memberId);

		[PreserveSig]
		public unsafe static extern XblMultiplayerMatchmakingServer* XblMultiplayerSessionMatchmakingServer(IntPtr handle);

		[PreserveSig]
		public static extern uint XblMultiplayerSessionMembersAccepted(IntPtr handle);

		[PreserveSig]
		public unsafe static extern sbyte* XblMultiplayerSessionRawServersJson(IntPtr handle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionSetRawServersJson(IntPtr handle, sbyte* rawServersJson);

		[PreserveSig]
		public unsafe static extern sbyte* XblMultiplayerSessionEtag(IntPtr handle);

		[PreserveSig]
		public unsafe static extern XblMultiplayerSessionInfo* XblMultiplayerSessionGetInfo(IntPtr handle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionAddMemberReservation(IntPtr handle, ulong xuid, sbyte* memberCustomConstantsJson, byte initializeRequested);

		[PreserveSig]
		public static extern void XblMultiplayerSessionSetInitializationSucceeded(IntPtr handle, byte initializationSucceeded);

		[PreserveSig]
		public unsafe static extern void XblMultiplayerSessionSetMatchmakingServerConnectionPath(IntPtr handle, sbyte* serverConnectionPath);

		[PreserveSig]
		public static extern void XblMultiplayerSessionSetLocked(IntPtr handle, byte locked);

		[PreserveSig]
		public static extern void XblMultiplayerSessionSetAllocateCloudCompute(IntPtr handle, byte allocateCloudCompute);

		[PreserveSig]
		public static extern void XblMultiplayerSessionSetMatchmakingResubmit(IntPtr handle, byte matchResubmit);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionSetServerConnectionStringCandidates(IntPtr handle, sbyte** serverConnectionStringCandidates, SizeT serverConnectionStringCandidatesCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserSetRoles(IntPtr handle, XblMultiplayerSessionMemberRole* roles, SizeT rolesCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserSetMembersInGroup(IntPtr session, uint* memberIds, SizeT memberIdsCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserSetGroups(IntPtr handle, sbyte** groups, SizeT groupsCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserSetEncounters(IntPtr handle, sbyte** encounters, SizeT encountersCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserSetQosMeasurements(IntPtr handle, sbyte* measurements);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(IntPtr handle, sbyte* name, sbyte* valueJson);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(IntPtr handle, sbyte* name);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionSetMatchmakingTargetSessionConstantsJson(IntPtr handle, sbyte* matchmakingTargetSessionConstantsJson);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionSetCustomPropertyJson(IntPtr handle, sbyte* name, sbyte* valueJson);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSessionDeleteCustomPropertyJson(IntPtr handle, sbyte* name);

		[PreserveSig]
		public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(IntPtr currentSessionHandle, IntPtr oldSessionHandle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerWriteSessionByHandleAsync(IntPtr xblContext, IntPtr multiplayerSession, XblMultiplayerSessionWriteMode writeMode, sbyte* handleId, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerWriteSessionByHandleResult(XAsyncBlockPtr async, IntPtr* handle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerGetSessionAsync(IntPtr xblContext, XblMultiplayerSessionReference* sessionReference, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerGetSessionResult(XAsyncBlockPtr async, IntPtr* handle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerGetSessionByHandleAsync(IntPtr xblContext, sbyte* handleId, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerGetSessionByHandleResult(XAsyncBlockPtr async, IntPtr* handle);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerQuerySessionsAsync(IntPtr xblContext, XblMultiplayerSessionQuery* sessionQuery, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerQuerySessionsResultCount(XAsyncBlockPtr async, SizeT* sessionCount);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerQuerySessionsResult(XAsyncBlockPtr async, SizeT sessionCount, XblMultiplayerSessionQueryResult* sessions);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSetActivityAsync(IntPtr xblContext, XblMultiplayerSessionReference* sessionReference, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerClearActivityAsync(IntPtr xblContext, sbyte* scid, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSendInvitesAsync(IntPtr xblContext, XblMultiplayerSessionReference* sessionReference, ulong* xuids, SizeT xuidsCount, uint titleId, sbyte* contextStringId, sbyte* customActivationContext, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSendInvitesResult(XAsyncBlockPtr async, SizeT handlesCount, XblMultiplayerInviteHandle* handles);

		[PreserveSig]
		public static extern int XblMultiplayerSetTransferHandleAsync(IntPtr xblContext, XblMultiplayerSessionReference targetSessionReference, XblMultiplayerSessionReference originSessionReference, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblMultiplayerSetTransferHandleResult(XAsyncBlockPtr async, XblMultiplayerSessionHandleId* handleId);
	}
}
