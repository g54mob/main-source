using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal static class XblInterop
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblMultiplayerSessionChangedHandler(IntPtr context, XblMultiplayerSessionChangeEventArgs args);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblMultiplayerSessionSubscriptionLostHandler(IntPtr context);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblMultiplayerConnectionIdChangedHandler(IntPtr context);

		internal const int XBL_COLOR_CHAR_SIZE = 21;

		internal const int XBL_DISPLAY_NAME_CHAR_SIZE = 90;

		internal const int XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE = 675;

		internal const int XBL_GAMERSCORE_CHAR_SIZE = 48;

		internal const int XBL_GAMERTAG_CHAR_SIZE = 48;

		internal const int XBL_MODERN_GAMERTAG_CHAR_SIZE = 97;

		internal const int XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE = 15;

		internal const int XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE = 101;

		internal const int XBL_NUM_PRESENCE_RECORDS = 6;

		internal const int XBL_REAL_NAME_CHAR_SIZE = 765;

		internal const int XBL_RICH_PRESENCE_CHAR_SIZE = 300;

		internal const int XBL_TITLE_NAME_CHAR_SIZE = 300;

		internal const int XBL_XBOX_USER_ID_CHAR_SIZE = 63;

		internal const int XBL_GUID_LENGTH = 40;

		internal const int XBL_SCID_LENGTH = 40;

		internal const int XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT = 10;

		private const string ThunkDllName = "Microsoft.Xbox.Services.GDK.C.Thunks";

		[PreserveSig]
		internal static extern int XblAchievementsResultGetAchievements(XblAchievementsResultHandle resultHandle, out IntPtr achievements, out SizeT achievementsCount);

		[PreserveSig]
		internal static extern int XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext);

		[PreserveSig]
		internal static extern int XblAchievementsResultGetNextAsync(XblAchievementsResultHandle resultHandle, uint maxItems, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblAchievementsResultGetNextResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle resultHandle);

		[PreserveSig]
		internal static extern int XblAchievementsGetAchievementsForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblAchievementsGetAchievementsForTitleIdResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle result);

		[PreserveSig]
		internal static extern int XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, byte[] achievementId, uint percentComplete, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblAchievementsUpdateAchievementForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, byte[] serviceConfigurationId, byte[] achievementId, uint percentComplete, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblAchievementsGetAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, byte[] serviceConfigurationId, byte[] achievementId, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblAchievementsGetAchievementResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle result);

		[PreserveSig]
		internal static extern int XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle);

		[PreserveSig]
		internal static extern void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle);

		[PreserveSig]
		internal static extern int XblHttpCallRequestSetRequestBodyBytes(XblHttpCallHandle call, byte[] requestBodyBytes, uint requestBodySize);

		[PreserveSig]
		internal static extern int XblHttpCallGetNetworkErrorCode(XblHttpCallHandle call, out int networkErrorCode, out uint platformNetworkErrorCode);

		[PreserveSig]
		internal static extern int XblHttpCallRequestSetLongHttpCall(XblHttpCallHandle call, NativeBool longHttpCall);

		[PreserveSig]
		internal static extern int XblHttpCallPerformAsync(XblHttpCallHandle call, XblHttpCallResponseBodyType type, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblHttpCallSetTracing(XblHttpCallHandle call, NativeBool traceCall);

		[PreserveSig]
		internal static extern int XblHttpCallCreate(XblContextHandle xblContext, byte[] method, byte[] url, out XblHttpCallHandle call);

		[PreserveSig]
		internal static extern void XblHttpCallCloseHandle(XblHttpCallHandle call);

		[PreserveSig]
		internal static extern int XblHttpCallRequestSetRequestBodyString(XblHttpCallHandle call, byte[] requestBodyString);

		[PreserveSig]
		internal static extern int XblHttpCallGetResponseString(XblHttpCallHandle call, out UTF8StringPtr responseString);

		[PreserveSig]
		internal static extern int XblHttpCallGetHeaderAtIndex(XblHttpCallHandle call, uint headerIndex, out UTF8StringPtr headerName, out UTF8StringPtr headerValue);

		[PreserveSig]
		internal static extern int XblHttpCallGetResponseBodyBytesSize(XblHttpCallHandle call, out SizeT bufferSize);

		[PreserveSig]
		internal static extern int XblHttpCallGetPlatformNetworkErrorMessage(XblHttpCallHandle call, out UTF8StringPtr platformNetworkErrorMessage);

		[PreserveSig]
		internal static extern int XblHttpCallGetResponseBodyBytes(XblHttpCallHandle call, SizeT bufferSize, [Out] byte[] buffer, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblHttpCallRequestSetRetryAllowed(XblHttpCallHandle call, NativeBool retryAllowed);

		[PreserveSig]
		internal static extern int XblHttpCallRequestSetHeader(XblHttpCallHandle call, byte[] headerName, byte[] headerValue, NativeBool allowTracing);

		[PreserveSig]
		internal static extern int XblHttpCallDuplicateHandle(XblHttpCallHandle call, out XblHttpCallHandle duplicateHandle);

		[PreserveSig]
		internal static extern int XblHttpCallGetNumHeaders(XblHttpCallHandle call, out uint numHeaders);

		[PreserveSig]
		internal static extern int XblHttpCallGetStatusCode(XblHttpCallHandle call, out uint statusCode);

		[PreserveSig]
		internal static extern int XblHttpCallGetHeader(XblHttpCallHandle call, byte[] headerName, out UTF8StringPtr headerValue);

		[PreserveSig]
		internal static extern int XblHttpCallGetRequestUrl(XblHttpCallHandle call, out UTF8StringPtr url);

		[PreserveSig]
		internal static extern int XblHttpCallRequestSetRetryCacheId(XblHttpCallHandle call, uint retryAfterCacheId);

		[PreserveSig]
		internal static extern int XblLeaderboardGetLeaderboardAsync(XblContextHandle xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblLeaderboardGetLeaderboardResultSize(XAsyncBlockPtr asyncBlockPtr, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblLeaderboardGetLeaderboardResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblLeaderboardResultGetNextAsync(XblContextHandle xboxLiveContext, [In] ref XblLeaderboardResult leaderboardResult, uint maxItems, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblLeaderboardResultGetNextResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblLeaderboardResultGetNextResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesForSocialGroupResultCount(XAsyncBlockPtr async, out SizeT activityCount);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(XblContextHandle xblContext, byte[] scid, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesForSocialGroupResult(XAsyncBlockPtr async, SizeT activityCount, [Out] XblMultiplayerActivityDetails[] activities);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesForUsersAsync(XblContextHandle xblContext, byte[] scid, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesForUsersResult(XAsyncBlockPtr async, SizeT activityCount, [Out] XblMultiplayerActivityDetails[] activities);

		[PreserveSig]
		internal unsafe static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out XblMultiplayerActivityDetails* ptrToBuffer, out SizeT ptrToBufferCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesForSocialGroupAsync(XblContextHandle xboxLiveContext, byte[] scid, ulong socialGroupOwnerXuid, byte[] socialGroup, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal unsafe static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out XblMultiplayerActivityDetails* ptrToBuffer, out SizeT ptrToBufferCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(XblContextHandle xblContext, byte[] scid, ulong socialGroupOwnerXuid, byte[] socialGroup, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerGetActivitiesForUsersResultCount(XAsyncBlockPtr async, out SizeT activityCount);

		[PreserveSig]
		internal static extern XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(byte[] scid, byte[] sessionTemplateName, byte[] sessionName);

		[PreserveSig]
		internal static extern int XblMultiplayerSessionReferenceParseFromUriPath(byte[] path, out XblMultiplayerSessionReference sessionReference);

		[PreserveSig]
		public static extern XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, [In] ref XblMultiplayerSessionReference sessionRef, [In] ref XblMultiplayerSessionInitArgs initArgs);

		[PreserveSig]
		public static extern void XblMultiplayerSessionCloseHandle(XblMultiplayerSessionHandle handle);

		[PreserveSig]
		internal unsafe static extern XblMultiplayerSessionProperties* XblMultiplayerSessionSessionProperties(XblMultiplayerSessionHandle handle);

		[PreserveSig]
		internal static extern int XblMultiplayerSessionMembers(XblMultiplayerSessionHandle handle, out IntPtr members, out SizeT membersCount);

		[PreserveSig]
		internal unsafe static extern XblMultiplayerSessionMember* XblMultiplayerSessionCurrentUser(XblMultiplayerSessionHandle handle);

		[PreserveSig]
		public static extern XblWriteSessionStatus XblMultiplayerSessionWriteStatus(XblMultiplayerSessionHandle handle);

		[PreserveSig]
		public static extern int XblMultiplayerSessionJoin(XblMultiplayerSessionHandle handle, byte[] memberCustomConstantsJson, bool initializeRequested, bool joinWithActiveStatus);

		[PreserveSig]
		public static extern void XblMultiplayerSessionSetHostDeviceToken(XblMultiplayerSessionHandle handle, XblDeviceToken hostDeviceToken);

		[PreserveSig]
		public static extern void XblMultiplayerSessionSetClosed(XblMultiplayerSessionHandle handle, bool closed);

		[PreserveSig]
		public static extern int XblMultiplayerSessionSetSessionChangeSubscription(XblMultiplayerSessionHandle handle, XblMultiplayerSessionChangeTypes changeTypes);

		[PreserveSig]
		public static extern int XblMultiplayerSessionLeave(XblMultiplayerSessionHandle handle);

		[PreserveSig]
		public static extern int XblMultiplayerSessionCurrentUserSetStatus(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberStatus status);

		[PreserveSig]
		public static extern int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(XblMultiplayerSessionHandle handle, byte[] value);

		[PreserveSig]
		public static extern int XblFormatSecureDeviceAddress(byte[] deviceId, out XblFormattedSecureDeviceAddress address);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleDuplicateHandle([In] XblMultiplayerSearchHandle handle, out XblMultiplayerSearchHandle duplicatedHandle);

		[PreserveSig]
		public static extern void XblMultiplayerSearchHandleCloseHandle([In] XblMultiplayerSearchHandle handle);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetSessionReference([In] XblMultiplayerSearchHandle handle, out XblMultiplayerSessionReference sessionRef);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetId([In] XblMultiplayerSearchHandle handle, out UTF8StringPtr id);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetSessionOwnerXuids([In] XblMultiplayerSearchHandle handle, out IntPtr xuids, out SizeT xuidsCount);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetTags([In] XblMultiplayerSearchHandle handle, out IntPtr tags, out SizeT tagsCount);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetStringAttributes([In] XblMultiplayerSearchHandle handle, out IntPtr attributes, out SizeT attributesCount);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetNumberAttributes([In] XblMultiplayerSearchHandle handle, out IntPtr attributes, out SizeT attributesCount);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetVisibility([In] XblMultiplayerSearchHandle handle, out XblMultiplayerSessionVisibility visibility);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetJoinRestriction([In] XblMultiplayerSearchHandle handle, out XblMultiplayerSessionRestriction joinRestriction);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetSessionClosed([In] XblMultiplayerSearchHandle handle, out bool closed);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetMemberCounts([In] XblMultiplayerSearchHandle handle, out SizeT maxMembers, out SizeT currentMembers);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetCreationTime([In] XblMultiplayerSearchHandle handle, out TimeT creationTime);

		[PreserveSig]
		public static extern int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson([In] XblMultiplayerSearchHandle handle, out UTF8StringPtr customPropertiesJson);

		[PreserveSig]
		internal static extern int XblMultiplayerWriteSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerWriteSessionResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

		[PreserveSig]
		internal static extern int XblMultiplayerCreateSearchHandleAsync(XblContextHandle xblContext, [In] ref XblMultiplayerSessionReference sessionRef, [Optional] XblMultiplayerSessionTag[] tags, SizeT tagsCount, [Optional] XblMultiplayerSessionNumberAttribute[] numberAttributes, SizeT numberAttributesCount, [Optional] XblMultiplayerSessionStringAttribute[] stringAttributes, SizeT stringAttributesCount, XAsyncBlockPtr async);

		[PreserveSig]
		public static extern int XblMultiplayerCreateSearchHandleResult(XAsyncBlockPtr async, out XblMultiplayerSearchHandle handle);

		[PreserveSig]
		public static extern int XblMultiplayerDeleteSearchHandleAsync(XblContextHandle xblContext, byte[] handleId, XAsyncBlockPtr async);

		[PreserveSig]
		public static extern int XblMultiplayerGetSearchHandlesAsync(XblContextHandle xblContext, byte[] scid, byte[] sessionTemplateName, [Optional] byte[] orderByAttribute, bool orderAscending, [Optional] byte[] searchFilter, [Optional] byte[] socialGroup, XAsyncBlockPtr async);

		[PreserveSig]
		public static extern int XblMultiplayerGetSearchHandlesResultCount(XAsyncBlockPtr async, out SizeT searchHandleCount);

		[PreserveSig]
		public static extern int XblMultiplayerGetSearchHandlesResult(XAsyncBlockPtr async, [Out] XblMultiplayerSearchHandle[] searchHandles, SizeT searchHandleCount);

		[PreserveSig]
		public static extern int XblMultiplayerSetSubscriptionsEnabled(XblContextHandle xblContext, bool subscriptionsEnabled);

		[PreserveSig]
		public static extern bool XblMultiplayerSubscriptionsEnabled(XblContextHandle xblHandle);

		[PreserveSig]
		internal static extern XblFunctionContext XblMultiplayerAddSessionChangedHandler(XblContextHandle xblContext, XblMultiplayerSessionChangedHandler handler, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerRemoveSessionChangedHandler(XblContextHandle xblContext, XblFunctionContext token);

		[PreserveSig]
		internal static extern XblFunctionContext XblMultiplayerAddSubscriptionLostHandler(XblContextHandle xblContext, XblMultiplayerSessionSubscriptionLostHandler handler, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerRemoveSubscriptionLostHandler(XblContextHandle xblContext, XblFunctionContext token);

		[PreserveSig]
		internal static extern XblFunctionContext XblMultiplayerAddConnectionIdChangedHandler(XblContextHandle xblContext, XblMultiplayerConnectionIdChangedHandler handler, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerRemoveConnectionIdChangedHandler(XblContextHandle xblContext, XblFunctionContext token);

		[PreserveSig]
		internal static extern int XblMultiplayerActivityGetActivityAsync(XblContextHandle xblContext, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerActivityFlushRecentPlayersAsync(XblContextHandle xblContext, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerActivitySendInvitesAsync(XblContextHandle xblContext, [In] ulong[] xuids, SizeT xuidsCount, NativeBool allowCrossPlatformJoin, byte[] connectionString, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerActivityDeleteActivityAsync(XblContextHandle xblContext, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblMultiplayerActivitySetActivityAsync(XblContextHandle xblContext, XblMultiplayerActivityInfo activityInfo, NativeBool allowCrossPlatformJoin, XAsyncBlockPtr async);

		[PreserveSig]
		internal unsafe static extern int XblMultiplayerActivityGetActivityResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out XblMultiplayerActivityInfo* ptrToBufferResults, out SizeT resultCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblMultiplayerActivityGetActivityResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblMultiplayerActivityUpdateRecentPlayers(XblContextHandle xblContext, [In] XblMultiplayerActivityRecentPlayerUpdate[] recentPlayerUpdates, SizeT recentPlayerUpdatesCount);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember);

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsTournamentRegistrationStateChanged(XblMultiplayerEventArgsHandle argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason);

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsFindMatchCompleted(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionInviteUsers(XUserHandle user, [In] ulong[] xuids, SizeT xuidsCount, byte[] contextStringId, byte[] customActivationContext);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionInviteUsers(IntPtr user, [In] ulong[] xuids, SizeT xuidsCount, byte[] contextStringId, byte[] customActivationContext);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerJoinLobby(byte[] handleId, XUserHandle user);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerJoinLobby(byte[] handleId, IntPtr user);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionInviteFriends(XUserHandle requestingUser, byte[] contextStringId, byte[] customActivationContext);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionInviteFriends(IntPtr requestingUser, byte[] contextStringId, byte[] customActivationContext);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerSetQosMeasurements(byte[] measurementsJson);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionAddLocalUser(XUserHandle user);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionAddLocalUser(IntPtr user);

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsMembersCount(XblMultiplayerEventArgsHandle argsHandle, out SizeT memberCount);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerJoinGameFromLobby(byte[] sessionTemplateName);

		[PreserveSig]
		internal static extern NativeBool XblMultiplayerManagerGameSessionIsHost(ulong xuid);

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsPropertiesJson(XblMultiplayerEventArgsHandle argsHandle, out UTF8StringPtr properties);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetProperties(byte[] name, byte[] valueJson, IntPtr context);

		[PreserveSig]
		internal static extern void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(NativeBool autoFillMembers);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(XUserHandle user, byte[] name, byte[] valueJson, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(IntPtr user, byte[] name, byte[] valueJson, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(byte[] name, byte[] valueJson, IntPtr context);

		[PreserveSig]
		internal unsafe static extern XblMultiplayerSessionReference* XblMultiplayerManagerGameSessionSessionReference();

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsXuid(XblMultiplayerEventArgsHandle argsHandle, out ulong xuid);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerGameSessionSetProperties(byte[] name, byte[] valueJson, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionMembers(SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

		[PreserveSig]
		internal static extern XblMultiplayerJoinability XblMultiplayerManagerJoinability();

		[PreserveSig]
		internal static extern UTF8StringPtr XblMultiplayerManagerLobbySessionPropertiesJson();

		[PreserveSig]
		internal static extern void XblMultiplayerManagerCancelMatch();

		[PreserveSig]
		internal static extern uint XblMultiplayerManagerEstimatedMatchWaitTime();

		[PreserveSig]
		internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerLobbySessionConstants();

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsTournamentGameSessionReady(XblMultiplayerEventArgsHandle argsHandle, out TimeT startTime);

		[PreserveSig]
		internal static extern SizeT XblMultiplayerManagerLobbySessionLocalMembersCount();

		[PreserveSig]
		internal static extern NativeBool XblMultiplayerManagerGameSessionActive();

		[PreserveSig]
		internal static extern int XblMultiplayerManagerInitialize(byte[] lobbySessionTemplateName, XTaskQueueHandle asyncQueue);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionRemoveLocalUser(XUserHandle user);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionRemoveLocalUser(IntPtr user);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(XUserHandle user, byte[] name, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(IntPtr user, byte[] name, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsMember(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember member);

		[PreserveSig]
		internal static extern NativeBool XblMultiplayerManagerMemberAreMembersOnSameDevice([In] ref XblMultiplayerManagerMember first, [In] ref XblMultiplayerManagerMember second);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerGameSessionSetSynchronizedHost(byte[] deviceToken, IntPtr context);

		[PreserveSig]
		internal unsafe static extern XblTournamentTeamResult* XblMultiplayerManagerLobbySessionLastTournamentTeamResult();

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLeaveGame();

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsMembers(XblMultiplayerEventArgsHandle argsHandle, SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

		[PreserveSig]
		internal static extern NativeBool XblMultiplayerManagerLobbySessionIsHost(ulong xuid);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerGameSessionSetSynchronizedProperties(byte[] name, byte[] valueJson, IntPtr context);

		[PreserveSig]
		internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionCorrelationId();

		[PreserveSig]
		internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerGameSessionConstants();

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionLocalMembers(SizeT localMembersCount, [Out] XblMultiplayerManagerMember[] localMembers);

		[PreserveSig]
		internal static extern XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus();

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetSynchronizedHost(byte[] deviceToken, IntPtr context);

		[PreserveSig]
		internal static extern NativeBool XblMultiplayerManagerAutoFillMembersDuringMatchmaking();

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId);

		[PreserveSig]
		internal static extern SizeT XblMultiplayerManagerLobbySessionMembersCount();

		[PreserveSig]
		internal static extern int XblMultiplayerManagerFindMatch(byte[] hopperName, byte[] attributesJson, uint timeoutInSeconds);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerDoWork(out IntPtr multiplayerEvents, out SizeT multiplayerEventsCount);

		[PreserveSig]
		internal static extern NativeBool XblMultiplayerSessionReferenceIsValid([In] ref XblMultiplayerSessionReference sessionReference);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerGameSessionMembers(SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(XUserHandle user, byte[] connectionAddress, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(IntPtr user, byte[] connectionAddress, IntPtr context);

		[PreserveSig]
		internal static extern int XblMultiplayerManagerJoinGame(byte[] sessionName, byte[] sessionTemplateName, [In] ulong[] xuids, SizeT xuidsCount);

		[PreserveSig]
		internal static extern SizeT XblMultiplayerManagerGameSessionMembersCount();

		[PreserveSig]
		internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionPropertiesJson();

		[PreserveSig]
		internal static extern int XblMultiplayerEventArgsPerformQoSMeasurements(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs);

		[PreserveSig]
		internal static extern int XblPresenceRecordGetXuid(XblPresenceRecordHandle handle, out ulong xuid);

		[PreserveSig]
		internal static extern int XblPresenceRecordGetUserState(XblPresenceRecordHandle handle, out XblPresenceUserState userState);

		[PreserveSig]
		internal static extern int XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle handle, out IntPtr deviceRecords, out SizeT deviceRecordsCount);

		[PreserveSig]
		internal static extern int XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle handle, out XblPresenceRecordHandle duplicatedHandle);

		[PreserveSig]
		internal static extern void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle);

		[PreserveSig]
		internal static extern int XblPresenceSetPresenceAsync(XblContextHandle xblContextHandle, bool isUserActiveInTitle, [Optional] XblPresenceRichPresenceIdsRef richPresenceIds, XAsyncBlockPtr asyncBlockPtr);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceAsync(XblContextHandle xblContextHandle, ulong xuid, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceResult(XAsyncBlockPtr asyncBlock, out XblPresenceRecordHandle presenceRecordHandle);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceForMultipleUsersAsync(XblContextHandle xblContextHandle, ulong[] xuids, SizeT xuidsCount, [Optional] XblPresenceQueryFiltersRef filters, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceForMultipleUsersResultCount(XAsyncBlockPtr asyncBlock, out SizeT resultCount);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceForMultipleUsersResult(XAsyncBlockPtr asyncBlock, [Out] XblPresenceRecordHandle[] presenceRecordHandles, SizeT presenceRecordHandlesCount);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceForSocialGroupAsync(XblContextHandle xblContextHandle, byte[] socialGroupName, [Optional] UInt64Ref socialGroupOwnerXuid, [Optional] XblPresenceQueryFiltersRef filters, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceForSocialGroupResultCount(XAsyncBlockPtr asyncBlock, out SizeT resultCount);

		[PreserveSig]
		internal static extern int XblPresenceGetPresenceForSocialGroupResult(XAsyncBlockPtr asyncBlock, [Out] XblPresenceRecordHandle[] presenceRecordHandles, SizeT presenceRecordHandlesCount);

		[PreserveSig]
		internal static extern int XblPresenceSubscribeToDevicePresenceChange(XblContextHandle xblContextHandle, ulong xuid, out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		[PreserveSig]
		internal static extern int XblPresenceUnsubscribeFromDevicePresenceChange(XblContextHandle xblContextHandle, XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		[PreserveSig]
		internal static extern int XblPresenceSubscribeToTitlePresenceChange(XblContextHandle xblContextHandle, ulong xuid, uint titleId, out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		[PreserveSig]
		internal static extern int XblPresenceUnsubscribeFromTitlePresenceChange(XblContextHandle xblContext, XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		[PreserveSig]
		internal static extern XblFunctionContext XblPresenceAddDevicePresenceChangedHandler(XblContextHandle xblContextHandle, XblPresenceDevicePresenceChangedHandler handler, IntPtr context);

		[PreserveSig]
		internal static extern int XblPresenceRemoveDevicePresenceChangedHandler(XblContextHandle xblContextHandle, XblFunctionContext token);

		[PreserveSig]
		internal static extern XblFunctionContext XblPresenceAddTitlePresenceChangedHandler(XblContextHandle xblContextHandle, XblPresenceTitlePresenceChangedHandler handler, IntPtr context);

		[PreserveSig]
		internal static extern int XblPresenceRemoveTitlePresenceChangedHandler(XblContextHandle xblContextHandle, XblFunctionContext token);

		[PreserveSig]
		internal static extern int XblPrivacyGetAvoidListAsync(XblContextHandle xblContextHandle, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblPrivacyGetAvoidListResultCount(XAsyncBlockPtr async, out SizeT xuidCount);

		[PreserveSig]
		internal static extern int XblPrivacyGetAvoidListResult(XAsyncBlockPtr async, SizeT xuidCount, [Out] ulong[] xuids);

		[PreserveSig]
		internal static extern int XblPrivacyGetMuteListAsync(XblContextHandle xblContextHandle, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblPrivacyGetMuteListResultCount(XAsyncBlockPtr async, out SizeT xuidCount);

		[PreserveSig]
		internal static extern int XblPrivacyGetMuteListResult(XAsyncBlockPtr async, SizeT xuidCount, [Out] ulong[] xuids);

		[PreserveSig]
		internal static extern int XblPrivacyCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblPrivacyCheckPermissionResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblPrivacyCheckPermissionResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr result, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblPrivacyBatchCheckPermissionAsync(XblContextHandle xblContextHandle, [In] XblPermission[] permissionsToCheck, SizeT permissionsCount, [In] ulong[] targetXuids, SizeT xuidsCount, [In] XblAnonymousUserType[] targetAnonymousUserTypes, SizeT targetAnonymousUserTypesCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblPrivacyBatchCheckPermissionResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblPrivacyBatchCheckPermissionResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr results, out SizeT resultsCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfileAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfileResult(XAsyncBlockPtr async, out XblUserProfile profile);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfilesAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfilesResultCount(XAsyncBlockPtr async, out SizeT profileCount);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfilesResult(XAsyncBlockPtr async, SizeT profilesCount, [Out] XblUserProfile[] profiles);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfilesForSocialGroupAsync(XblContextHandle xblContextHandle, byte[] socialGroup, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfilesForSocialGroupResultCount(XAsyncBlockPtr async, out SizeT profileCount);

		[PreserveSig]
		internal static extern int XblProfileGetUserProfilesForSocialGroupResult(XAsyncBlockPtr async, SizeT profilesCount, [Out] XblUserProfile[] profiles);

		[PreserveSig]
		internal static extern bool XblSocialManagerPresenceRecordIsUserPlayingTitle([In] ref XblSocialManagerPresenceRecord presenceRecord, uint titleId);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetUsers(XblSocialManagerUserGroupHandle group, out IntPtr xboxSocialUsers, out SizeT usersCount);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetUsersFromXboxUserIds(XblSocialManagerUserGroupHandle group, ulong[] xboxUserIds, uint xboxUserIdsCount, [Out] XblSocialManagerUser[] xboxSocialUsers, out uint xboxSocialUsersCount);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetUsersTrackedByGroup(XblSocialManagerUserGroupHandle group, out IntPtr trackedUsers, out SizeT trackedUsersCount);

		[PreserveSig]
		internal static extern int XblSocialManagerAddLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail, XTaskQueueHandle queue);

		[PreserveSig]
		internal static extern int XblSocialManagerAddLocalUser(IntPtr user, XblSocialManagerExtraDetailLevel extraLevelDetail, XTaskQueueHandle queue);

		[PreserveSig]
		internal static extern int XblSocialManagerRemoveLocalUser(XUserHandle user);

		[PreserveSig]
		internal static extern int XblSocialManagerRemoveLocalUser(IntPtr user);

		[PreserveSig]
		internal static extern int XblSocialManagerDoWork(out IntPtr socialEvents, out SizeT socialEventsCount);

		[PreserveSig]
		internal static extern int XblSocialManagerCreateSocialUserGroupFromFilters(XUserHandle user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group);

		[PreserveSig]
		internal static extern int XblSocialManagerCreateSocialUserGroupFromFilters(IntPtr user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group);

		[PreserveSig]
		internal static extern int XblSocialManagerCreateSocialUserGroupFromList(XUserHandle user, ulong[] xboxUserIdList, SizeT xboxUserIdListCount, out XblSocialManagerUserGroupHandle group);

		[PreserveSig]
		internal static extern int XblSocialManagerCreateSocialUserGroupFromList(IntPtr user, ulong[] xboxUserIdList, SizeT xboxUserIdListCount, out XblSocialManagerUserGroupHandle group);

		[PreserveSig]
		internal static extern int XblSocialManagerDestroySocialUserGroup(XblSocialManagerUserGroupHandle group);

		[PreserveSig]
		internal static extern SizeT XblSocialManagerGetLocalUserCount();

		[PreserveSig]
		internal static extern int XblSocialManagerGetLocalUsers(SizeT usersCount, [Out] XUserHandle[] users);

		[PreserveSig]
		internal static extern int XblSocialManagerGetLocalUsers(SizeT usersCount, [Out] IntPtr[] users);

		[PreserveSig]
		internal static extern int XblSocialManagerUpdateSocialUserGroup(XblSocialManagerUserGroupHandle group, ulong[] users, SizeT usersCount);

		[PreserveSig]
		internal static extern int XblSocialManagerSetRichPresencePollingStatus(XUserHandle user, bool shouldEnablePolling);

		[PreserveSig]
		internal static extern int XblSocialManagerSetRichPresencePollingStatus(IntPtr user, bool shouldEnablePolling);

		[PreserveSig]
		internal static extern void XblSocialManagerSetBackgroundWorkAsyncQueue(XTaskQueueHandle queue);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetType(XblSocialManagerUserGroupHandle group, out XblSocialUserGroupType type);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out XUserHandle localUser);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out IntPtr localUser);

		[PreserveSig]
		internal static extern int XblSocialManagerUserGroupGetFilters(XblSocialManagerUserGroupHandle group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter);

		[PreserveSig]
		internal static extern int XblStringVerifyStringAsync(XblContextHandle xblContextHandle, byte[] stringToVerify, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblStringVerifyStringResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblStringVerifyStringResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblStringVerifyStringsAsync(XblContextHandle xblContextHandle, IntPtr stringsToVerify, ulong stringsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblStringVerifyStringsResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblStringVerifyStringsResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBufferStrings, out SizeT stringsCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblTitleManagedStatsUpdateStatsAsync(XblContextHandle xblContextHandle, [In] XblTitleManagedStatistic[] statistics, SizeT statisticsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblTitleManagedStatsDeleteStatsAsync(XblContextHandle xblContextHandle, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblTitleManagedStatsWriteAsync(XblContextHandle xblContextHandle, ulong xboxUserId, [In] XblTitleManagedStatistic[] statistics, SizeT statisticsCount, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetSingleUserStatisticAsync(XblContextHandle xblContextHandle, ulong xboxUserId, byte[] serviceConfigurationId, byte[] statisticName, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetSingleUserStatisticResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetSingleUserStatisticResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetSingleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong xboxUserId, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetSingleUserStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetSingleUserStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT resultsCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, uint xboxUserIdsCount, IntPtr requestedServiceConfigurationStatisticsCollection, uint requestedServiceConfigurationStatisticsCollectionCount, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		[PreserveSig]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr results, out SizeT resultsCount, out SizeT bufferUsed);

		[PreserveSig]
		internal static extern int XblContextCreateHandle(XUserHandle user, out XblContextHandle context);

		[PreserveSig]
		internal static extern int XblContextCreateHandle(IntPtr user, out XblContextHandle context);

		[PreserveSig]
		internal static extern void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle);

		[PreserveSig]
		internal static extern XblErrorCondition XblGetErrorCondition(int hr);

		[PreserveSig]
		internal static extern int XblEventsWriteInGameEvent(XblContextHandle xboxLiveContext, byte[] eventName, [Optional] byte[] dimensionsJson, [Optional] byte[] measurementsJson);

		[PreserveSig]
		internal static extern int XblWrapper_XblInitialize(byte[] scid, XTaskQueueHandle internalWorkQueue);

		[PreserveSig]
		internal static extern int XblCleanupAsync(XAsyncBlockPtr asyncBlock);
	}
}
