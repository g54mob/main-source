using System;
using System.Collections.Generic;
using AOT;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class SDK
	{
		public delegate void XStoreQueryGameAndDlcPackageUpdatesCompleted(int hresult, XStorePackageUpdate[] packageUpdates);

		public delegate void XStoreDownloadAndInstallPackagesCompleted(int hresult, string[] packageIdentifiers);

		public delegate void XStoreDownloadAndInstallPackageUpdatesCompleted(int hresult);

		public delegate void XStoreDownloadPackageUpdatesCompleted(int hresult);

		public delegate void XStoreShowProductPageUICompleted(int hresult);

		public delegate void XStoreShowAssociatedProductsPageUICompleted(int hresult);

		public delegate void XStoreShowRedeemTokenUICompleted(int hresult);

		public delegate void XStoreShowRateAndReviewUICompleted(int hresult, bool wasUpdated);

		public delegate void XStoreShowPurchaseUICompleted(int hresult);

		public delegate void XStoreQueryConsumableBalanceRemainingCompleted(int hresult, uint quantity);

		public delegate void XStoreReportConsumableFulfillmentCompleted(int hresult, uint quantity);

		public delegate void XStoreGetUserCollectionsIdCompleted(int hresult, string token);

		public delegate void XStoreGetUserPurchaseIdCompleted(int hresult, string token);

		public class XBL
		{
			public delegate void XblAchievementsResultGetNextResult(int hresult, XblAchievementsResultHandle result);

			public delegate void XblAchievementsGetAchievementsForTitleIdResult(int hresult, XblAchievementsResultHandle result);

			public delegate void XblAchievementsUpdateAchievementResult(int hresult);

			public delegate void XblAchievementsUpdateAchievementForTitleIdResult(int hresult);

			public delegate void XblAchievementsGetAchievementResult(int hresult, XblAchievementsResultHandle result);

			public delegate void XblMultiplayerQuerySessionsResult(int hresult, XblMultiplayerSessionQueryResult[] sessionsQueryResult);

			public delegate void XblMultiplayerWriteSessionHandleResult(int hresult, XblMultiplayerSessionHandle handle);

			public delegate void XblMultiplayerCreateSearchHandleResult(int hresult, XblMultiplayerSearchHandle handle);

			public delegate void XblMultiplayerDeleteSearchHandleResult(int hresult);

			public delegate void XblMultiplayerGetSearchHandlesResult(int hresult, XblMultiplayerSearchHandle[] searchHandles);

			public delegate void XblMultiplayerSessionChangedHandler(XblMultiplayerSessionChangeEventArgs args);

			public delegate void XblMultiplayerSessionSubscriptionLostHandler();

			public delegate void XblMultiplayerConnectionIdChangedHandler();

			public delegate void XblMultiplayerGetActivitiesWithPropertiesResult(int hresult, XblMultiplayerActivityDetails[] result);

			private class SubscriptionLostCallbackManager : InteropCallbackManager<XblSubscriptionLostCallback>
			{
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context)
				{
				}

				private void IssueEventCallback(int functionId)
				{
				}
			}

			private class ConnectionIdChangedCallbackManager : InteropCallbackManager<XblConnectionIdChangedCallback>
			{
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context)
				{
				}

				private void IssueEventCallback(int functionId)
				{
				}
			}

			private class SessionChangedCallbackManager : InteropCallbackManager<XblSessionChangedCallback>
			{
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context, XGamingRuntime.Interop.XblMultiplayerSessionChangeEventArgs args)
				{
				}

				private void IssueEventCallback(int functionId, XblMultiplayerSessionChangeEventArgs eventArgs)
				{
				}
			}

			public delegate void XblMultiplayerSetTransferHandleResult(int hresult, string transferHandle);

			private class ConnectionStateChangeCallbackManager : InteropCallbackManager<XblConnectionStateChangeCallback>
			{
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context, XGamingRuntime.Interop.XblRealTimeActivityConnectionState newConnectionState)
				{
				}

				private void IssueEventCallback(int functionId, XblRealTimeActivityConnectionState newConnectionState)
				{
				}
			}

			private class ConnectionResyncCallbackManager : InteropCallbackManager<XblConnectionResyncCallback>
			{
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context)
				{
				}

				private void IssueEventCallback(int functionId)
				{
				}
			}

			private class SocialRelationshipChangeCallbackManager : InteropCallbackManager<XblSocialRelationshipChangedCallback>
			{
				[MonoPInvokeCallback]
				internal unsafe static void InteropPInvokeCallback(XGamingRuntime.Interop.XblSocialRelationshipChangeEventArgs* eventArgs, IntPtr context)
				{
				}

				private unsafe void IssueEventCallback(int functionId, XGamingRuntime.Interop.XblSocialRelationshipChangeEventArgs* eventArgs)
				{
				}
			}

			private class UserStatisticsChangeCallbackManager : InteropCallbackManager<XblStatisticChangedCallback>
			{
				[MonoPInvokeCallback]
				internal unsafe static void InteropPInvokeCallback(XGamingRuntime.Interop.XblStatisticChangeEventArgs eventArgs, void* context)
				{
				}

				private void IssueEventCallback(int functionId, XGamingRuntime.Interop.XblStatisticChangeEventArgs eventArgs)
				{
				}
			}

			public delegate void XblCleanupResult(int hresult);

			private static SubscriptionLostCallbackManager _subscriptionLostCallbackManager;

			private static ConnectionIdChangedCallbackManager _connectionIdChangedCallbackManager;

			private static SessionChangedCallbackManager _sessionChangedCallbackManager;

			private static ConnectionStateChangeCallbackManager _connectionStateChangeCallbackManager;

			private static ConnectionResyncCallbackManager _connectionResyncCallbackManager;

			private static SocialRelationshipChangeCallbackManager _socialRelationshipChangeCallbackManager;

			private static UserStatisticsChangeCallbackManager _userStatisticsChangeCallbackManager;

			public const int StandardScidLength = 36;

			public static int XblAchievementsResultGetAchievements(XblAchievementsResultHandle resultHandle, out XblAchievement[] achievements)
			{
				achievements = null;
				return 0;
			}

			public static int XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext)
			{
				hasNext = default(bool);
				return 0;
			}

			public static void XblAchievementsResultGetNextAsync(XblAchievementsResultHandle resultHandle, uint maxItems, XblAchievementsResultGetNextResult completionRoutine)
			{
			}

			public static void XblAchievementsGetAchievementsForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, XblAchievementsGetAchievementsForTitleIdResult completionRoutine)
			{
			}

			public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementResult completionRoutine)
			{
			}

			public static void XblAchievementsUpdateAchievementForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, string serviceConfigurationId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
			{
			}

			public static void XblAchievementsGetAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string serviceConfigurationId, string achievementId, XblAchievementsGetAchievementResult completionRoutine)
			{
			}

			public static int XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle)
			{
				duplicatedHandle = null;
				return 0;
			}

			public static void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle)
			{
			}

			public static XblErrorCondition XblGetErrorCondition(int hr)
			{
				return default(XblErrorCondition);
			}

			public static XblHresult XblGetHRESULT(int hr)
			{
				return default(XblHresult);
			}

			public static int XblEventsWriteInGameEvent(XblContextHandle xboxLiveContext, string eventName, string dimensionsJson, string measurementsJson)
			{
				return 0;
			}

			public static int XblHttpCallRequestSetRequestBodyBytes(XblHttpCallHandle call, byte[] requestBodyBytes)
			{
				return 0;
			}

			public static int XblHttpCallGetNetworkErrorCode(XblHttpCallHandle call, out int networkErrorCode, out uint platformNetworkErrorCode)
			{
				networkErrorCode = default(int);
				platformNetworkErrorCode = default(uint);
				return 0;
			}

			public static int XblHttpCallRequestSetLongHttpCall(XblHttpCallHandle call, bool longHttpCall)
			{
				return 0;
			}

			public static void XblHttpCallPerformAsync(XblHttpCallHandle call, XblHttpCallResponseBodyType type, XblHttpCallPerformCompleted completionRoutine)
			{
			}

			public static int XblHttpCallSetTracing(XblHttpCallHandle call, bool traceCall)
			{
				return 0;
			}

			public static int XblHttpCallCreate(XblContextHandle xblContext, string method, string url, out XblHttpCallHandle call)
			{
				call = null;
				return 0;
			}

			public static void XblHttpCallCloseHandle(XblHttpCallHandle call)
			{
			}

			public static int XblHttpCallRequestSetRequestBodyString(XblHttpCallHandle call, string requestBodyString)
			{
				return 0;
			}

			public static int XblHttpCallGetResponseString(XblHttpCallHandle call, out string responseString)
			{
				responseString = null;
				return 0;
			}

			public static int XblHttpCallGetHeaderAtIndex(XblHttpCallHandle call, uint headerIndex, out string headerName, out string headerValue)
			{
				headerName = null;
				headerValue = null;
				return 0;
			}

			public static int XblHttpCallGetPlatformNetworkErrorMessage(XblHttpCallHandle call, out string platformNetworkErrorMessage)
			{
				platformNetworkErrorMessage = null;
				return 0;
			}

			public static int XblHttpCallGetResponseBodyBytes(XblHttpCallHandle call, out byte[] buffer)
			{
				buffer = null;
				return 0;
			}

			public static int XblHttpCallRequestSetRetryAllowed(XblHttpCallHandle call, bool retryAllowed)
			{
				return 0;
			}

			public static int XblHttpCallRequestSetHeader(XblHttpCallHandle call, string headerName, string headerValue, bool allowTracing)
			{
				return 0;
			}

			public static int XblHttpCallDuplicateHandle(XblHttpCallHandle call, out XblHttpCallHandle duplicateHandle)
			{
				duplicateHandle = null;
				return 0;
			}

			public static int XblHttpCallGetNumHeaders(XblHttpCallHandle call, out uint numHeaders)
			{
				numHeaders = default(uint);
				return 0;
			}

			public static int XblHttpCallGetStatusCode(XblHttpCallHandle call, out uint statusCode)
			{
				statusCode = default(uint);
				return 0;
			}

			public static int XblHttpCallGetHeader(XblHttpCallHandle call, string headerName, out string headerValue)
			{
				headerValue = null;
				return 0;
			}

			public static int XblHttpCallGetRequestUrl(XblHttpCallHandle call, out string url)
			{
				url = null;
				return 0;
			}

			public static int XblHttpCallRequestSetRetryCacheId(XblHttpCallHandle call, uint retryAfterCacheId)
			{
				return 0;
			}

			public static void XblLeaderboardGetLeaderboardAsync(XblContextHandle xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XblLeaderboardGetLeaderboardCompleted completionRoutine)
			{
			}

			public static void XblLeaderboardResultGetNextAsync(XblContextHandle xboxLiveContext, XblLeaderboardResult leaderboardResult, uint maxItems, XblLeaderboardGetNextCompleted completionRoutine)
			{
			}

			public static int XblMatchmakingCreateMatchTicketAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference sessionReference, string serviceConfigurationId, string hopperName, ulong ticketTimeout, XblPreserveSessionMode preserveSessionMode, string ticketAttributesJson, XblMatchmakingCreateTicketCallback createCompletionCallback)
			{
				return 0;
			}

			public static int XblMatchmakingDeleteMatchTicketAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, string matchTicketId, XblMatchmakingDeleteTicketCallback deleteCompletionCallback)
			{
				return 0;
			}

			public static int XblMatchmakingGetMatchTicketDetailsAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, string matchTicketId, XblMatchmakingTicketDetailsCallback completionCallback)
			{
				return 0;
			}

			public static int XblMatchmakingGetHopperStatisticsAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, XblMatchmakingStatisticsCallback completionCallback)
			{
				return 0;
			}

			public static XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionInitArgs initArgs)
			{
				return null;
			}

			public static void XblMultiplayerSessionCloseHandle(XblMultiplayerSessionHandle handle)
			{
			}

			public static int XblMultiplayerQuerySessionsAsync(XblContextHandle xblContext, XblMultiplayerSessionQuery sessionQuery, XblMultiplayerQuerySessionsResult completionRoutine)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserSetEncounters(XblMultiplayerSessionHandle handle, string[] encounters)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserSetGroups(XblMultiplayerSessionHandle handle, string[] groups)
			{
				return 0;
			}

			public static int XblMultiplayerSessionPropertiesSetTurnCollection(XblMultiplayerSessionHandle handle, uint[] turnCollectionMemberIds)
			{
				return 0;
			}

			public static int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference sessionReference, out string sessionReferenceUri)
			{
				sessionReferenceUri = null;
				return 0;
			}

			public static int XblMultiplayerSessionSetServerConnectionStringCandidates(XblMultiplayerSessionHandle handle, string[] serverConnectionStringCandidates)
			{
				return 0;
			}

			public static XblMultiplayerSessionProperties XblMultiplayerSessionSessionProperties(XblMultiplayerSessionHandle handle)
			{
				return null;
			}

			public static int XblMultiplayerSessionMembers(XblMultiplayerSessionHandle handle, out XblMultiplayerSessionMember[] members)
			{
				members = null;
				return 0;
			}

			public static XblMultiplayerSessionMember XblMultiplayerSessionCurrentUser(XblMultiplayerSessionHandle handle)
			{
				return null;
			}

			public static XblWriteSessionStatus XblMultiplayerSessionWriteStatus(XblMultiplayerSessionHandle handle)
			{
				return default(XblWriteSessionStatus);
			}

			public static int XblMultiplayerSessionJoin(XblMultiplayerSessionHandle handle, string memberCustomConstantsJson, bool initializeRequested, bool joinWithActiveStatus)
			{
				return 0;
			}

			public static void XblMultiplayerSessionSetHostDeviceToken(XblMultiplayerSessionHandle handle, XblDeviceToken hostDeviceToken)
			{
			}

			public static void XblMultiplayerSessionSetClosed(XblMultiplayerSessionHandle handle, bool closed)
			{
			}

			public static int XblMultiplayerSessionSetSessionChangeSubscription(XblMultiplayerSessionHandle handle, XblMultiplayerSessionChangeTypes changeTypes)
			{
				return 0;
			}

			public static int XblMultiplayerSessionLeave(XblMultiplayerSessionHandle handle)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserSetStatus(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberStatus status)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(XblMultiplayerSessionHandle handle, string value)
			{
				return 0;
			}

			public static int XblFormatSecureDeviceAddress(string deviceId, out string address)
			{
				address = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleDuplicateHandle(XblMultiplayerSearchHandle handle, out XblMultiplayerSearchHandle duplicatedHandle)
			{
				duplicatedHandle = null;
				return 0;
			}

			public static void XblMultiplayerSearchHandleCloseHandle(XblMultiplayerSearchHandle handle)
			{
			}

			public static int XblMultiplayerSearchHandleGetSessionReference(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionReference sessionRef)
			{
				sessionRef = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetId(XblMultiplayerSearchHandle handle, out string id)
			{
				id = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetSessionOwnerXuids(XblMultiplayerSearchHandle handle, out ulong[] xuids)
			{
				xuids = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetTags(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionTag[] tags)
			{
				tags = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetStringAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionStringAttribute[] attributes)
			{
				attributes = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetNumberAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionNumberAttribute[] attributes)
			{
				attributes = null;
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetVisibility(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionVisibility visibility)
			{
				visibility = default(XblMultiplayerSessionVisibility);
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetJoinRestriction(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionRestriction joinRestriction)
			{
				joinRestriction = default(XblMultiplayerSessionRestriction);
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetSessionClosed(XblMultiplayerSearchHandle handle, out bool closed)
			{
				closed = default(bool);
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetMemberCounts(XblMultiplayerSearchHandle handle, out uint maxMembers, out uint currentMembers)
			{
				maxMembers = default(uint);
				currentMembers = default(uint);
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetCreationTime(XblMultiplayerSearchHandle handle, out DateTime creationTime)
			{
				creationTime = default(DateTime);
				return 0;
			}

			public static int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(XblMultiplayerSearchHandle handle, out string customPropertiesJson)
			{
				customPropertiesJson = null;
				return 0;
			}

			public static void XblMultiplayerWriteSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, XblMultiplayerWriteSessionHandleResult completionRoutine)
			{
			}

			public static void XblMultiplayerCreateSearchHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionTag[] tags, XblMultiplayerSessionNumberAttribute[] numberAttributes, XblMultiplayerSessionStringAttribute[] stringAttributes, XblMultiplayerCreateSearchHandleResult completionRoutine)
			{
			}

			public static void XblMultiplayerDeleteSearchHandleAsync(XblContextHandle xblContext, string handleId, XblMultiplayerDeleteSearchHandleResult completionRoutine)
			{
			}

			public static void XblMultiplayerGetSearchHandlesAsync(XblContextHandle xboxLiveContext, string scid, string sessionTemplateName, string orderByAttribute, bool orderAscending, string searchFilter, string socialGroup, XblMultiplayerGetSearchHandlesResult completionRoutine)
			{
			}

			public static int XblMultiplayerSetSubscriptionsEnabled(XblContextHandle xblContext, bool subscriptionsEnabled)
			{
				return 0;
			}

			public static bool XblMultiplayerSubscriptionsEnabled(XblContextHandle xblHandle)
			{
				return false;
			}

			public static void XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(XblContextHandle xboxLiveContext, string scid, ulong[] xuids, XblMultiplayerGetActivitiesWithPropertiesResult completionRoutine)
			{
			}

			public static void XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(XblContextHandle xboxLiveContext, string scid, ulong socialGroupOwnerXuid, string socialGroup, XblMultiplayerGetActivitiesWithPropertiesResult completionRoutine)
			{
			}

			public static XblMultiplayerHandlerCallbackToken XblMultiplayerAddSubscriptionLostHandler(XblContextHandle xboxLiveContext, XblSubscriptionLostCallback callback)
			{
				return default(XblMultiplayerHandlerCallbackToken);
			}

			public static int XblMultiplayerRemoveSubscriptionLostHandler(XblContextHandle xboxLiveContext, ref XblMultiplayerHandlerCallbackToken subscriptionLostCallbackToken)
			{
				return 0;
			}

			public static XblMultiplayerHandlerCallbackToken XblMultiplayerAddConnectionIdChangedHandler(XblContextHandle xboxLiveContext, XblConnectionIdChangedCallback callback)
			{
				return default(XblMultiplayerHandlerCallbackToken);
			}

			public static int XblMultiplayerRemoveConnectionIdChangedHandler(XblContextHandle xboxLiveContext, ref XblMultiplayerHandlerCallbackToken connectionIdChangedCallbackToken)
			{
				return 0;
			}

			public static XblMultiplayerHandlerCallbackToken XblMultiplayerAddSessionChangedHandler(XblContextHandle xboxLiveContext, XblSessionChangedCallback callback)
			{
				return default(XblMultiplayerHandlerCallbackToken);
			}

			public static int XblMultiplayerRemoveSessionChangedHandler(XblContextHandle xboxLiveContext, ref XblMultiplayerHandlerCallbackToken sessionChangedCallbackToken)
			{
				return 0;
			}

			public static XblMultiplayerMatchmakingServer XblMultiplayerSessionMatchmakingServer(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static int XblMultiplayerSessionDuplicateHandle(XblMultiplayerSessionHandle srcHandle, out XblMultiplayerSessionHandle dstHandle)
			{
				dstHandle = null;
				return 0;
			}

			public static DateTime XblMultiplayerSessionTimeOfSession(XblMultiplayerSessionHandle sessionHandle)
			{
				return default(DateTime);
			}

			public static XblMultiplayerSessionInitializationInfo XblMultiplayerSessionGetInitializationInfo(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(XblMultiplayerSessionHandle sessionHandle)
			{
				return default(XblMultiplayerSessionChangeTypes);
			}

			public static int XblMultiplayerSessionHostCandidates(XblMultiplayerSessionHandle sessionHandle, out XblDeviceToken[] deviceTokens)
			{
				deviceTokens = null;
				return 0;
			}

			public static XblMultiplayerSessionReference XblMultiplayerSessionSessionReference(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static XblMultiplayerSessionConstants XblMultiplayerSessionSessionConstants(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static void XblMultiplayerSessionConstantsSetMaxMembersInSession(XblMultiplayerSessionHandle sessionHandle, uint maxMembersInSession)
			{
			}

			public static void XblMultiplayerSessionConstantsSetVisibility(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerSessionVisibility visibility)
			{
			}

			public static int XblMultiplayerSessionConstantsSetTimeouts(XblMultiplayerSessionHandle sessionHandle, TimeSpan memberReservedTimeout, TimeSpan memberInactiveTimeout, TimeSpan memberReadyTimeout, TimeSpan sessionEmptyTimeout)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetArbitrationTimeouts(XblMultiplayerSessionHandle sessionHandle, TimeSpan arbitrationTimeout, TimeSpan forfeitTimeout)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(XblMultiplayerSessionHandle sessionHandle, bool enableLatencyMetric, bool enableBandwidthDownMetric, bool enableBandwidthUpMetric, bool enableCustomMetric)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetMemberInitialization(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerMemberInitialization memberInitialization)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerPeerToPeerRequirements requirements)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetPeerToHostRequirements(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerPeerToHostRequirements requirements)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(XblMultiplayerSessionHandle sessionHandle, string measurementServerAddressesJson)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetCapabilities(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerSessionCapabilities capabilities)
			{
				return 0;
			}

			public static int XblMultiplayerSessionConstantsSetCloudComputePackageJson(XblMultiplayerSessionHandle sessionHandle, string sessionCloudComputePackageConstantsJson)
			{
				return 0;
			}

			public static void XblMultiplayerSessionPropertiesSetJoinRestriction(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerSessionRestriction joinRestriction)
			{
			}

			public static void XblMultiplayerSessionPropertiesSetReadRestriction(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerSessionRestriction readRestriction)
			{
			}

			public static int XblMultiplayerSessionSetMutableRoleSettings(XblMultiplayerSessionHandle sessionHandle, string roleTypeName, string roleName, uint? maxMemberCount, uint? targetMemberCount)
			{
				return 0;
			}

			public static XblMultiplayerSessionMember XblMultiplayerSessionGetMember(XblMultiplayerSessionHandle sessionHandle, uint memberId)
			{
				return null;
			}

			public static uint XblMultiplayerSessionMembersAccepted(XblMultiplayerSessionHandle sessionHandle)
			{
				return 0u;
			}

			public static string XblMultiplayerSessionRawServersJson(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static int XblMultiplayerSessionSetRawServersJson(XblMultiplayerSessionHandle sessionHandle, string rawServersJson)
			{
				return 0;
			}

			public static string XblMultiplayerSessionEtag(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static XblMultiplayerSessionInfo XblMultiplayerSessionGetInfo(XblMultiplayerSessionHandle sessionHandle)
			{
				return null;
			}

			public static int XblMultiplayerSessionAddMemberReservation(XblMultiplayerSessionHandle sessionHandle, ulong xuid, string memberCustomConstantsJson, bool initializeRequested)
			{
				return 0;
			}

			public static void XblMultiplayerSessionSetInitializationSucceeded(XblMultiplayerSessionHandle sessionHandle, bool initializationSucceeded)
			{
			}

			public static void XblMultiplayerSessionSetMatchmakingServerConnectionPath(XblMultiplayerSessionHandle sessionHandle, string serverConnectionPath)
			{
			}

			public static void XblMultiplayerSessionSetLocked(XblMultiplayerSessionHandle sessionHandle, bool isLocked)
			{
			}

			public static void XblMultiplayerSessionSetAllocateCloudCompute(XblMultiplayerSessionHandle sessionHandle, bool allocateCloudCompute)
			{
			}

			public static void XblMultiplayerSessionSetMatchmakingResubmit(XblMultiplayerSessionHandle sessionHandle, bool matchResubmit)
			{
			}

			public static int XblMultiplayerSessionCurrentUserSetRoles(XblMultiplayerSessionHandle sessionHandle, XblMultiplayerSessionMemberRole[] memberRoles)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserSetQosMeasurements(XblMultiplayerSessionHandle sessionHandle, string measurements)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(XblMultiplayerSessionHandle sessionHandle, string propertyName, string propertyValueJson)
			{
				return 0;
			}

			public static int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(XblMultiplayerSessionHandle sessionHandle, string propertyName)
			{
				return 0;
			}

			public static int XblMultiplayerSessionSetMatchmakingTargetSessionConstantsJson(XblMultiplayerSessionHandle sessionHandle, string matchmakingTargetSessionConstantsJson)
			{
				return 0;
			}

			public static int XblMultiplayerSessionSetCustomPropertyJson(XblMultiplayerSessionHandle sessionHandle, string propertyName, string propertyValueJson)
			{
				return 0;
			}

			public static int XblMultiplayerSessionDeleteCustomPropertyJson(XblMultiplayerSessionHandle sessionHandle, string propertyName)
			{
				return 0;
			}

			public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(XblMultiplayerSessionHandle currentSessionHandle, XblMultiplayerSessionHandle oldSessionHandle)
			{
				return default(XblMultiplayerSessionChangeTypes);
			}

			public static int XblMultiplayerWriteSessionByHandleAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionHandle sessionHandle, XblMultiplayerSessionWriteMode writeMode, string sessionHandleId, XblWriteSessionByHandleCallback completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerGetSessionAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference sessionReference, XblGetSessionCallback completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerGetSessionByHandleAsync(XblContextHandle xboxLiveContext, string sessionHandleId, XblGetSessionCallback completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerSetActivityAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference sessionReference, XblActivityCompletionCallback completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerClearActivityAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, XblActivityCompletionCallback completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerSendInvitesAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference sessionReference, ulong[] xuidsForUsersToInvite, uint titleId, string contextStringId, string customActivationContext, XblSendInvitesCompletionCallback completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerSessionPropertiesSetKeyword(XblMultiplayerSessionHandle sessionHandle, string keyword)
			{
				return 0;
			}

			public static int XblMultiplayerSetTransferHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference targetSessionReference, XblMultiplayerSessionReference originSessionReference, XblMultiplayerSetTransferHandleResult completionCallback)
			{
				return 0;
			}

			public static int XblMultiplayerSessionRoleTypes(XblMultiplayerSessionHandle sessionHandle, out XblMultiplayerRoleType[] roleTypes)
			{
				roleTypes = null;
				return 0;
			}

			public static int XblMultiplayerSessionGetRoleByName(XblMultiplayerSessionHandle sessionHandle, string roleTypeName, string roleName, out XblMultiplayerRole role)
			{
				role = null;
				return 0;
			}

			public static void XblMultiplayerActivityGetActivityAsync(XblContextHandle xblContextHandle, ulong[] xuids, XblMultiplayerActivityGetActivityCompleted completionRoutine)
			{
			}

			public static void XblMultiplayerActivityFlushRecentPlayersAsync(XblContextHandle xblContextHandle, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
			}

			public static void XblMultiplayerActivitySendInvitesAsync(XblContextHandle xblContextHandle, ulong[] xuids, bool allowCrossPlatformJoin, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
			}

			public static void XblMultiplayerActivitySendInvitesAsync(XblContextHandle xblContextHandle, ulong[] xuids, bool allowCrossPlatformJoin, string connectionString, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
			}

			public static void XblMultiplayerActivityDeleteActivityAsync(XblContextHandle xblContextHandle, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
			}

			public static void XblMultiplayerActivitySetActivityAsync(XblContextHandle xblContextHandle, XblMultiplayerActivityInfo activityInfo, bool allowCrossPlatformJoin, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
			}

			public static int XblMultiplayerActivityUpdateRecentPlayers(XblContextHandle xblContextHandle, XblMultiplayerActivityRecentPlayerUpdate[] recentPlayerUpdates)
			{
				return 0;
			}

			public static int XblMultiplayerManagerInitialize(string lobbySessionTemplateName)
			{
				return 0;
			}

			public static int XblMultiplayerManagerDoWork(out XblMultiplayerEvent[] events)
			{
				events = null;
				return 0;
			}

			public static XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(string scid, string sessionTemplateName, string sessionName)
			{
				return null;
			}

			public static int XblMultiplayerManagerJoinLobby(string handleId, XUserHandle user)
			{
				return 0;
			}

			public static int XblMultiplayerManagerSetQosMeasurements(string measurementsJson)
			{
				return 0;
			}

			public static int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerJoinGameFromLobby(string sessionTemplateName)
			{
				return 0;
			}

			public static void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(bool autoFillMembers)
			{
			}

			public static XblMultiplayerJoinability XblMultiplayerManagerJoinability()
			{
				return default(XblMultiplayerJoinability);
			}

			public static void XblMultiplayerManagerCancelMatch()
			{
			}

			public static uint XblMultiplayerManagerEstimatedMatchWaitTime()
			{
				return 0u;
			}

			public static bool XblMultiplayerManagerMemberAreMembersOnSameDevice(XblMultiplayerManagerMember first, XblMultiplayerManagerMember second)
			{
				return false;
			}

			public static int XblMultiplayerSessionReferenceParseFromUriPath(string path, out XblMultiplayerSessionReference sessionReference)
			{
				sessionReference = null;
				return 0;
			}

			public static int XblMultiplayerManagerLeaveGame()
			{
				return 0;
			}

			public static XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus()
			{
				return default(XblMultiplayerMatchStatus);
			}

			public static bool XblMultiplayerManagerAutoFillMembersDuringMatchmaking()
			{
				return false;
			}

			public static int XblMultiplayerManagerFindMatch(string hopperName, string attributesJson, uint timeoutInSeconds)
			{
				return 0;
			}

			public static bool XblMultiplayerSessionReferenceIsValid(XblMultiplayerSessionReference sessionReference)
			{
				return false;
			}

			public static int XblMultiplayerManagerJoinGame(string sessionName, string sessionTemplateName, ulong[] xuids)
			{
				return 0;
			}

			public static int XblMultiplayerEventArgsTournamentRegistrationStateChanged(XblMultiplayerEventArgsHandle argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason)
			{
				registrationState = default(XblTournamentRegistrationState);
				registrationReason = default(XblTournamentRegistrationReason);
				return 0;
			}

			public static int XblMultiplayerEventArgsFindMatchCompleted(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause)
			{
				matchStatus = default(XblMultiplayerMatchStatus);
				initializationFailureCause = default(XblMultiplayerMeasurementFailure);
				return 0;
			}

			public static int XblMultiplayerEventArgsPropertiesJson(XblMultiplayerEventArgsHandle argsHandle, out string properties)
			{
				properties = null;
				return 0;
			}

			public static int XblMultiplayerEventArgsXuid(XblMultiplayerEventArgsHandle argsHandle, out ulong xuid)
			{
				xuid = default(ulong);
				return 0;
			}

			public static int XblMultiplayerEventArgsTournamentGameSessionReady(XblMultiplayerEventArgsHandle argsHandle, out DateTime startTime)
			{
				startTime = default(DateTime);
				return 0;
			}

			public static int XblMultiplayerEventArgsMember(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember member)
			{
				member = null;
				return 0;
			}

			public static int XblMultiplayerEventArgsMembers(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember[] members)
			{
				members = null;
				return 0;
			}

			public static int XblMultiplayerEventArgsPerformQoSMeasurements(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs)
			{
				performQoSMeasurementsArgs = null;
				return 0;
			}

			private static int SessionSetInternalWithMarshalledContext(Func<IntPtr, int> setterFunction, object context)
			{
				return 0;
			}

			public static bool XblMultiplayerManagerGameSessionIsHost(ulong xuid)
			{
				return false;
			}

			public static int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember)
			{
				hostMember = null;
				return 0;
			}

			public static XblMultiplayerSessionReference XblMultiplayerManagerGameSessionSessionReference()
			{
				return null;
			}

			public static bool XblMultiplayerManagerGameSessionActive()
			{
				return false;
			}

			public static int XblMultiplayerManagerGameSessionSetProperties(string name, string valueJson, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerGameSessionSetSynchronizedHost(string deviceToken, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerGameSessionSetSynchronizedProperties(string name, string valueJson, object context)
			{
				return 0;
			}

			public static string XblMultiplayerManagerGameSessionCorrelationId()
			{
				return null;
			}

			public static XblMultiplayerSessionConstants XblMultiplayerManagerGameSessionConstants()
			{
				return null;
			}

			public static int XblMultiplayerManagerGameSessionMembers(out XblMultiplayerManagerMember[] members)
			{
				members = null;
				return 0;
			}

			public static string XblMultiplayerManagerGameSessionPropertiesJson()
			{
				return null;
			}

			public static int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember)
			{
				hostMember = null;
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionInviteUsers(XUserHandle user, ulong[] xuids, string contextStringId, string customActivationContext)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionInviteFriends(XUserHandle requestingUser, string contextStringId, string customActivationContext)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionAddLocalUser(XUserHandle user)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionMembers(out XblMultiplayerManagerMember[] members)
			{
				members = null;
				return 0;
			}

			public static string XblMultiplayerManagerLobbySessionPropertiesJson()
			{
				return null;
			}

			public static XblMultiplayerSessionConstants XblMultiplayerManagerLobbySessionConstants()
			{
				return null;
			}

			public static int XblMultiplayerManagerLobbySessionLocalMembers(out XblMultiplayerManagerMember[] localMembers)
			{
				localMembers = null;
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionRemoveLocalUser(XUserHandle user)
			{
				return 0;
			}

			public static XblTournamentTeamResult XblMultiplayerManagerLobbySessionLastTournamentTeamResult()
			{
				return null;
			}

			public static bool XblMultiplayerManagerLobbySessionIsHost(ulong xuid)
			{
				return false;
			}

			public static int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId)
			{
				correlationId = null;
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionSetSynchronizedHost(string deviceToken, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference)
			{
				sessionReference = null;
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionSetProperties(string name, string valueJson, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(XUserHandle user, string name, string valueJson, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(string name, string valueJson, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(XUserHandle user, string connectionAddress, object context)
			{
				return 0;
			}

			public static int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(XUserHandle user, string name, object context)
			{
				return 0;
			}

			public static int XblPresenceRecordGetXuid(XblPresenceRecordHandle handle, out ulong xuid)
			{
				xuid = default(ulong);
				return 0;
			}

			public static int XblPresenceRecordGetUserState(XblPresenceRecordHandle handle, out XblPresenceUserState userState)
			{
				userState = default(XblPresenceUserState);
				return 0;
			}

			public static int XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle handle, out XblPresenceDeviceRecord[] deviceRecords)
			{
				deviceRecords = null;
				return 0;
			}

			public static int XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle handle, out XblPresenceRecordHandle duplicatedHandle)
			{
				duplicatedHandle = null;
				return 0;
			}

			public static void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle)
			{
			}

			public static void XblPresenceSetPresenceAsync(XblContextHandle xblContextHandle, bool isUserActiveInTitle, XblPresenceRichPresenceIds richPresenceIds, XblPresenceSetPresenceCompleted completionRoutine)
			{
			}

			public static void XblPresenceGetPresenceAsync(XblContextHandle xblContextHandle, ulong xuid, XblPresenceGetPresenceCompleted completionRoutine)
			{
			}

			public static void XblPresenceGetPresenceForMultipleUsersAsync(XblContextHandle xblContextHandle, ulong[] xuids, XblPresenceQueryFilters filters, XblPresenceGetPresenceForMultipleUsersCompleted completionRoutine)
			{
			}

			public static void XblPresenceGetPresenceForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroupName, ulong? socialGroupOwnerXuid, XblPresenceQueryFilters filters, XblPresenceGetPresenceForSocialGroupCompleted completionRoutine)
			{
			}

			public static void XblPrivacyGetAvoidListAsync(XblContextHandle xblContextHandle, XblPrivacyGetAvoidListCompleted completionRoutine)
			{
			}

			public static void XblPrivacyGetMuteListAsync(XblContextHandle xblContextHandle, XblPrivacyGetMuteListCompleted completionRoutine)
			{
			}

			public static void XblPrivacyCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XblPrivacyCheckPermissionCompleted completionRoutine)
			{
			}

			public static void XblPrivacyBatchCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission[] permissionsToCheck, ulong[] targetXuids, XblAnonymousUserType[] targetAnonymousUserTypes, XblPrivacyBatchCheckPermissionCompleted completionRoutine)
			{
			}

			public static void XblProfileGetUserProfileAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblProfileGetUserProfileCompleted completionRoutine)
			{
			}

			public static void XblProfileGetUserProfilesAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblProfileGetUserProfilesCompleted completionRoutine)
			{
			}

			public static void XblProfileGetUserProfilesForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroup, XblProfileGetUserProfilesForSocialGroupCompleted completionRoutine)
			{
			}

			public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddConnectionStateChangeHandler(XblContextHandle xboxLiveContext, XblConnectionStateChangeCallback callback)
			{
				return default(XblRealTimeActivityCallbackToken);
			}

			public static int XblRealTimeActivityRemoveConnectionStateChangeHandler(XblContextHandle xboxLiveContext, ref XblRealTimeActivityCallbackToken connectionStateChangeCallbackToken)
			{
				return 0;
			}

			public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddResyncHandler(XblContextHandle xboxLiveContext, XblConnectionResyncCallback callback)
			{
				return default(XblRealTimeActivityCallbackToken);
			}

			public static int XblRealTimeActivityRemoveResyncHandler(XblContextHandle xboxLiveContext, ref XblRealTimeActivityCallbackToken connectionResyncCallbackToken)
			{
				return 0;
			}

			public static int XblSocialGetSocialRelationshipsAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, uint startIndex, uint maxItems, XblSocialRelationshipCallback completionCallback)
			{
				return 0;
			}

			public static int XblSocialRelationshipResultGetRelationships(XblSocialHandle socialHandle, out XblSocialRelationship[] relationships)
			{
				relationships = null;
				return 0;
			}

			public static int XblSocialRelationshipResultHasNext(XblSocialHandle socialHandle, ref bool hasNext)
			{
				return 0;
			}

			public static int XblSocialRelationshipResultGetTotalCount(XblSocialHandle socialHandle, ref uint totalCount)
			{
				return 0;
			}

			public static int XblSocialRelationshipResultGetNextAsync(XblContextHandle xboxLiveContext, XblSocialHandle socialHandle, uint maxItems, XblSocialRelationshipCallback completionCallback)
			{
				return 0;
			}

			public static int XblSocialRelationshipResultDuplicateHandle(XblSocialHandle socialHandle, out XblSocialHandle duplicatedHandle)
			{
				duplicatedHandle = default(XblSocialHandle);
				return 0;
			}

			public static void XblSocialRelationshipResultCloseHandle(XblSocialHandle socialHandle)
			{
			}

			public static int XblSocialAddSocialRelationshipChangedHandler(XblContextHandle xboxLiveContext, XblSocialRelationshipChangedCallback eventCallback)
			{
				return 0;
			}

			public static int XblSocialRemoveSocialRelationshipChangedHandler(XblContextHandle xboxLiveContext, int callbackFunctionId)
			{
				return 0;
			}

			public static bool XblSocialManagerPresenceRecordIsUserPlayingTitle(XblSocialManagerPresenceRecord presenceRecord, uint titleId)
			{
				return false;
			}

			public static int XblSocialManagerUserGroupGetUsers(XblSocialManagerUserGroupHandle group, out XblSocialManagerUser[] xboxSocialUsers)
			{
				xboxSocialUsers = null;
				return 0;
			}

			public static int XblSocialManagerUserGroupGetUsersTrackedByGroup(XblSocialManagerUserGroupHandle group, out ulong[] trackedUsers)
			{
				trackedUsers = null;
				return 0;
			}

			public static int XblSocialManagerAddLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
			{
				return 0;
			}

			public static int XblSocialManagerRemoveLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
			{
				return 0;
			}

			public static int XblSocialManagerDoWork(out XblSocialManagerEvent[] socialEvents)
			{
				socialEvents = null;
				return 0;
			}

			public static int XblSocialManagerCreateSocialUserGroupFromFilters(XUserHandle user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group)
			{
				group = null;
				return 0;
			}

			public static int XblSocialManagerCreateSocialUserGroupFromList(XUserHandle user, ulong[] xboxUserIdList, out XblSocialManagerUserGroupHandle group)
			{
				group = null;
				return 0;
			}

			public static int XblSocialManagerDestroySocialUserGroup(XblSocialManagerUserGroupHandle group)
			{
				return 0;
			}

			public static int XblSocialManagerGetLocalUsers(out XUserHandle[] users)
			{
				users = null;
				return 0;
			}

			public static int XblSocialManagerUpdateSocialUserGroup(XblSocialManagerUserGroupHandle group, ulong[] users)
			{
				return 0;
			}

			public static int XblSocialManagerSetRichPresencePollingStatus(XUserHandle user, bool shouldEnablePolling)
			{
				return 0;
			}

			public static int XblSocialManagerUserGroupGetType(XblSocialManagerUserGroupHandle group, out XblSocialUserGroupType type)
			{
				type = default(XblSocialUserGroupType);
				return 0;
			}

			public static int XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out XUserHandle localUser)
			{
				localUser = null;
				return 0;
			}

			public static int XblSocialManagerUserGroupGetFilters(XblSocialManagerUserGroupHandle group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter)
			{
				presenceFilter = default(XblPresenceFilter);
				relationshipFilter = default(XblRelationshipFilter);
				return 0;
			}

			public static void XblStringVerifyStringAsync(XblContextHandle xblContextHandle, string stringToVerify, XblStringVerifyStringCompleted completionRoutine)
			{
			}

			public static void XblStringVerifyStringsAsync(XblContextHandle xblContextHandle, string[] stringsToVerify, XblStringVerifyStringsCompleted completionRoutine)
			{
			}

			public static void XblTitleManagedStatsUpdateStatsAsync(XblContextHandle xblContextHandle, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
			}

			public static void XblTitleManagedStatsDeleteStatsAsync(XblContextHandle xblContextHandle, string[] statisticNames, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
			}

			public static void XblTitleManagedStatsWriteAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
			}

			public static void XblUserStatisticsGetSingleUserStatisticAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string statisticName, XblUserStatisticsGetSingleUserStatisticCompleted completionRoutine)
			{
			}

			public static void XblUserStatisticsGetSingleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetSingleUserStatisticsCompleted completionRoutine)
			{
			}

			public static void XblUserStatisticsGetMultipleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetMultipleUserStatisticsCompleted completionRoutine)
			{
			}

			public static void XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblRequestedStatistics[] requestedServiceConfigurationStatisticsCollection, XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsCompleted completionRoutine)
			{
			}

			public static int XblUserStatisticsAddStatisticChangedHandler(XblContextHandle xblContextHandle, XblStatisticChangedCallback eventCallback)
			{
				return 0;
			}

			public static void XblUserStatisticsRemoveStatisticChangedHandler(XblContextHandle xblContextHandle, int callbackFunctionId)
			{
			}

			public static void XblUserStatisticsTrackStatistics(XblContextHandle xblContextHandle, ulong[] xuids, string serviceConfigurationId, string[] statisticNames)
			{
			}

			public static void XblUserStatisticsStopTrackingStatistics(XblContextHandle xblContextHandle, ulong[] xuids, string serviceConfigurationId, string[] statisticNames)
			{
			}

			public static void XblUserStatisticsStopTrackingUsers(XblContextHandle xblContextHandle, ulong[] xuids)
			{
			}

			public static int XblInitialize(string scid)
			{
				return 0;
			}

			public static void XblCleanup(XblCleanupResult completionRoutine)
			{
			}

			public static int XblContextCreateHandle(XUserHandle user, out XblContextHandle context)
			{
				context = null;
				return 0;
			}

			public static void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle)
			{
			}

			public static int XblContextDuplicateHandle(XblContextHandle srcXboxLiveContextHandle, out XblContextHandle dstXboxLiveContextHandle)
			{
				dstXboxLiveContextHandle = null;
				return 0;
			}

			public static int XblContextGetUser(XblContextHandle xboxLiveContextHandle, out XUserHandle dstUserHandle)
			{
				dstUserHandle = null;
				return 0;
			}

			public static int XblContextGetXboxUserId(XblContextHandle xboxLiveContextHandle, ref ulong dstXboxUserId)
			{
				return 0;
			}

			public static int XblGetScid(ref string resultScid)
			{
				return 0;
			}
		}

		public static XTaskQueue defaultQueue;

		public static XTaskQueueHandle SafeDefaultQueue;

		private static bool isInitialized;

		private static Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>> asyncWorkCallbackDictionary;

		public static int XClosedCaptionGetProperties(out XClosedCaptionProperties properties)
		{
			properties = null;
			return 0;
		}

		public static int XClosedCaptionSetEnabled(bool enabled)
		{
			return 0;
		}

		public static int XHighContrastGetMode(out XHighContrastMode mode)
		{
			mode = default(XHighContrastMode);
			return 0;
		}

		public static int XSpeechToTextSendString(string speakerName, string content, XSpeechToTextType type)
		{
			return 0;
		}

		public static int XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position)
		{
			return 0;
		}

		public static int XSpeechToTextBeginHypothesisString(string speakerName, string content, XSpeechToTextType type, out uint hypothesisId)
		{
			hypothesisId = default(uint);
			return 0;
		}

		public static int XSpeechToTextUpdateHypothesisString(uint hypothesisId, string content)
		{
			return 0;
		}

		public static int XSpeechToTextFinalizeHypothesisString(uint hypothesisId, string content)
		{
			return 0;
		}

		public static int XSpeechToTextCancelHypothesisString(uint hypothesisId)
		{
			return 0;
		}

		public static int XGameGetXboxTitleId(out uint titleId)
		{
			titleId = default(uint);
			return 0;
		}

		public static void XLaunchNewGame(string exePath, string args, XUserHandle defaultUser)
		{
		}

		public static int XLaunchRestartOnCrash(string args, uint reserved)
		{
			return 0;
		}

		[MonoPInvokeCallback]
		private static void XGameInviteEventCallback(IntPtr context, UTF8StringPtr inviteUri)
		{
		}

		public static int XGameInviteRegisterForEvent(XGameInviteEventCallback callback, out XRegistrationToken token)
		{
			token = null;
			return 0;
		}

		public static void XGameInviteUnregisterForEvent(XRegistrationToken token)
		{
		}

		[MonoPInvokeCallback]
		private static NativeBool GetContainerInfoCallback(XGamingRuntime.Interop.XGameSaveContainerInfo interopInfo, IntPtr context)
		{
			return default(NativeBool);
		}

		[MonoPInvokeCallback]
		private static NativeBool EnumerateContainerInfoCallback(XGamingRuntime.Interop.XGameSaveContainerInfo interopInfo, IntPtr context)
		{
			return default(NativeBool);
		}

		[MonoPInvokeCallback]
		private static NativeBool EnumerateBlobInfoCallback(XGamingRuntime.Interop.XGameSaveBlobInfo interopBlobInfo, IntPtr context)
		{
			return default(NativeBool);
		}

		public static int XGameSaveInitializeProvider(XUserHandle userHandle, string configurationId, bool syncOnDemand, out XGameSaveProviderHandle gameSaveProviderHandle)
		{
			gameSaveProviderHandle = null;
			return 0;
		}

		public static void XGameSaveInitializeProviderAsync(XUserHandle userHandle, string configurationId, bool syncOnDemand, XGameSaveInitializeProviderCompleted completionRoutine)
		{
		}

		public static void XGameSaveCloseProvider(XGameSaveProviderHandle gameSaveProviderHandle)
		{
		}

		public static int XGameSaveGetRemainingQuota(XGameSaveProviderHandle gameSaveProviderHandle, out long remainingQuota)
		{
			remainingQuota = default(long);
			return 0;
		}

		public static void XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle gameSaveProviderHandle, XGameSaveGetRemainingQuotaCompleted completionRoutine)
		{
		}

		public static int XGameSaveDeleteContainer(XGameSaveProviderHandle gameSaveProviderHandle, string containerName)
		{
			return 0;
		}

		public static void XGameSaveDeleteContainerAsync(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, XGameSaveDeleteContainerCompleted completionRoutine)
		{
		}

		public static int XGameSaveCreateContainer(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, out XGameSaveContainerHandle containerContext)
		{
			containerContext = null;
			return 0;
		}

		public static void XGameSaveCloseContainer(XGameSaveContainerHandle containerHandle)
		{
		}

		public static int XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, string containerName, out XGameSaveContainerInfo containerInfo)
		{
			containerInfo = null;
			return 0;
		}

		public static int XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, out XGameSaveContainerInfo[] containerInfos)
		{
			containerInfos = null;
			return 0;
		}

		public static int XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, string containerNamePrefix, out XGameSaveContainerInfo[] containerInfos)
		{
			containerInfos = null;
			return 0;
		}

		public static int XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, out XGameSaveBlobInfo[] blobInfos)
		{
			blobInfos = null;
			return 0;
		}

		public static int XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle container, string blobNamePrefix, out XGameSaveBlobInfo[] blobInfos)
		{
			blobInfos = null;
			return 0;
		}

		public static int XGameSaveReadBlobData(XGameSaveContainerHandle container, XGameSaveBlobInfo[] blobInfos, out XGameSaveBlob[] blobs)
		{
			blobs = null;
			return 0;
		}

		public static void XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, string[] blobNames, XGameSaveReadBlobDataCompleted completionRoutine)
		{
		}

		public static int XGameSaveCreateUpdate(XGameSaveContainerHandle container, string containerDisplayName, out XGameSaveUpdateHandle updateHandle)
		{
			updateHandle = null;
			return 0;
		}

		public static void XGameSaveCloseUpdateHandle(XGameSaveUpdateHandle updateHandle)
		{
		}

		public static int XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateHandle, string blobName, byte[] data)
		{
			return 0;
		}

		public static int XGameSaveSubmitBlobDelete(XGameSaveUpdateHandle updateHandle, string blobName)
		{
			return 0;
		}

		public static int XGameSaveSubmitUpdate(XGameSaveUpdateHandle updateHandle)
		{
			return 0;
		}

		public static void XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateHandle, XGameSaveSubmitUpdateCompleted completionRoutine)
		{
		}

		public static void XGameUiShowAchievementsAsync(XUserHandle requestingUser, uint titleId, XGameUiShowAchievementsCompleted completionRoutine)
		{
		}

		public static void XGameUiShowMessageDialogAsync(string titleText, string contentText, string firstButtonText, string secondButtonText, string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton, XGameUiShowMessageDialogCompleted completionRoutine)
		{
		}

		public static int XGameUiShowMultiplayerActivityGameInviteAsync(XAsyncBlock async, XUserHandle requestingUser)
		{
			return 0;
		}

		public static int XGameUiShowMultiplayerActivityGameInviteResult(XAsyncBlock async)
		{
			return 0;
		}

		public static void XGameUiShowErrorDialogAsync(int errorCode, string context, XGameUiShowErrorDialogCompleted completionRoutine)
		{
		}

		public static void XGameUiShowTextEntryAsync(string titleText, string descriptionText, string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength, XGameUiShowTextEntryAsyncCompleted completionRoutine)
		{
		}

		public static int XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position)
		{
			return 0;
		}

		public static void XGameUiShowSendGameInviteAsync(XUserHandle requestingUser, string sessionConfigurationId, string sessionTemplateName, string sessionId, string invitationText, string customActivationContext, XGameUiShowSendGameInviteAsyncCompleted completionRoutine)
		{
		}

		public static void XGameUIShowWebAuthenticationAsync(XUserHandle requestingUser, string requestUri, string completionUri, XGameUiShowWebAuthenticationAsyncCompleted completionRoutine)
		{
		}

		public static void XGameUiShowPlayerProfileCardAsync(XUserHandle requestingUser, ulong targetPlayer, XGameUiShowPlayerProfileCardAsyncCompleted completionRoutine)
		{
		}

		public static void XGameUiShowPlayerPickerAsync(XUserHandle requestingUser, string promptText, ulong[] selectFromPlayers, ulong[] preselectedPlayers, uint minSelectionCount, uint maxSelectionCount, XGameUiShowPlayerPickerAsyncCompleted completionRoutine)
		{
		}

		public static int XLaunchUri(XUserHandle requestingUser, string uri)
		{
			return 0;
		}

		[MonoPInvokeCallback]
		private unsafe static NativeBool EnumerationCallback(IntPtr context, XGamingRuntime.Interop.XPackageDetails* packageDetails)
		{
			return default(NativeBool);
		}

		[MonoPInvokeCallback]
		private unsafe static NativeBool FeatureEnumerationCallback(IntPtr context, XGamingRuntime.Interop.XPackageFeature* feature)
		{
			return default(NativeBool);
		}

		[MonoPInvokeCallback]
		private unsafe static void PackageInstalledCallback(IntPtr context, XGamingRuntime.Interop.XPackageDetails* packageDetails)
		{
		}

		[MonoPInvokeCallback]
		private static void PackageInstallationProgressCallback(IntPtr context, XGamingRuntime.Interop.XPackageInstallationMonitorHandle monitor)
		{
		}

		public static int XPackageGetCurrentProcessPackageIdentifier(out string identifier)
		{
			identifier = null;
			return 0;
		}

		public static bool XPackageIsPackagedProcess()
		{
			return false;
		}

		public static int XPackageGetUserLocale(out string locale)
		{
			locale = null;
			return 0;
		}

		public static int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, out XPackageDetails[] details)
		{
			details = null;
			return 0;
		}

		public static int XPackageRegisterPackageInstalled(XPackageInstalledCallback callback, out XRegistrationToken token)
		{
			token = null;
			return 0;
		}

		public static void XPackageUnregisterPackageInstalled(XRegistrationToken token)
		{
		}

		public static int XPackageEnumerateFeatures(string packageIdentifier, out XPackageFeature[] features)
		{
			features = null;
			return 0;
		}

		[Obsolete("XPackageMount is deprecated, please use XPackageMountWithUiAsync instead.", true)]
		public static int XPackageMount(string packageIdentifier, out XPackageMountHandle mountHandle)
		{
			mountHandle = null;
			return 0;
		}

		public static int XPackageMountWithUiAsync(string packageIdentifier, XAsyncBlock asyncBlock)
		{
			return 0;
		}

		public static int XPackageMountWithUiResult(XAsyncBlock async, out XPackageMountHandle mount)
		{
			mount = null;
			return 0;
		}

		public static int XPackageGetMountPath(XPackageMountHandle mountHandle, out string path)
		{
			path = null;
			return 0;
		}

		public static void XPackageCloseMountHandle(XPackageMountHandle mountHandle)
		{
		}

		public static int XPackageCreateInstallationMonitor(string packageIdentifier, uint minimumUpdateIntervalMs, out XPackageInstallationMonitorHandle installationMonitor)
		{
			installationMonitor = null;
			return 0;
		}

		public static void XPackageCloseInstallationMonitorHandle(XPackageInstallationMonitorHandle installationMonitor)
		{
		}

		public static void XPackageGetInstallationProgress(XPackageInstallationMonitorHandle installationMonitor, out XPackageInstallationProgress installationProgress)
		{
			installationProgress = null;
		}

		public static bool XPackageUpdateInstallationMonitor(XPackageInstallationMonitorHandle installationMonitor)
		{
			return false;
		}

		public static int XPackageRegisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageInstallationProgressCallback callback, out XRegistrationToken token)
		{
			token = null;
			return 0;
		}

		public static void XPackageUnregisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XRegistrationToken token)
		{
		}

		public static int XPackageEstimateDownloadSize(string packageIdentifier, out ulong downloadSize, out bool shouldPresentUserConfirmation)
		{
			downloadSize = default(ulong);
			shouldPresentUserConfirmation = default(bool);
			return 0;
		}

		public static int XPackageGetWriteStats(out XPackageWriteStats writeStats)
		{
			writeStats = null;
			return 0;
		}

		public static int XPackageUninstallUWPInstance(string packageName)
		{
			return 0;
		}

		public static int XGameRuntimeInitialize()
		{
			return 0;
		}

		public static void XGameRuntimeUninitialize()
		{
		}

		public static void XTaskQueueDispatch(uint timeoutMs = 0u)
		{
		}

		public static int XStoreCreateContext(out XStoreContext storeContext)
		{
			storeContext = null;
			return 0;
		}

		public static int XStoreCreateContext(XUserHandle user, out XStoreContext storeContext)
		{
			storeContext = null;
			return 0;
		}

		public static void XStoreCloseContextHandle(XStoreContext context)
		{
		}

		public static bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability)
		{
			return false;
		}

		[MonoPInvokeCallback]
		private static void LicenseChangedCallback(IntPtr context)
		{
		}

		[MonoPInvokeCallback]
		private static void LicenseLostCallback(IntPtr context)
		{
		}

		public static void XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreAcquireLicenseForPackageCompleted completionRoutine)
		{
		}

		public static void XStoreCanAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreCanAcquireLicenseForPackageCompleted completionRoutine)
		{
		}

		public static void XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext context, string storeProductId, XStoreCanAcquireLicenseForStoreIdCompleted completionRoutine)
		{
		}

		public static void XStoreCloseLicenseHandle(XStoreLicense license)
		{
		}

		public static bool XStoreIsLicenseValid(XStoreLicense license)
		{
			return false;
		}

		public static void XStoreQueryAddOnLicensesAsync(XStoreContext context, XStoreQueryAddOnLicensesCompleted completionRoutine)
		{
		}

		public static void XStoreQueryGameLicenseAsync(XStoreContext context, XStoreQueryGameLicenseCompleted completionRoutine)
		{
		}

		public static void XStoreQueryLicenseTokenAsync(XStoreContext context, string[] productIds, string customDeveloperString, XStoreQueryLicenseTokenCompleted completionRoutine)
		{
		}

		public static int XStoreRegisterGameLicenseChanged(XStoreContext context, XStoreGameLicenseChangedCallback callback, out XRegistrationToken token)
		{
			token = null;
			return 0;
		}

		public static int XStoreRegisterPackageLicenseLost(XStoreLicense license, XStorePackageLicenseLostCallback callback, out XRegistrationToken token)
		{
			token = null;
			return 0;
		}

		public static void XStoreUnregisterGameLicenseChanged(XStoreContext context, XRegistrationToken token)
		{
		}

		public static void XStoreUnregisterPackageLicenseLost(XStoreLicense license, XRegistrationToken token)
		{
		}

		public static void XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XStoreAcquireLicenseForDurablesAsync completionRoutine)
		{
		}

		public static void XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext context, XStoreQueryGameAndDlcPackageUpdatesCompleted completionRoutine)
		{
		}

		public static void XStoreDownloadAndInstallPackagesAsync(XStoreContext context, string[] storeIds, XStoreDownloadAndInstallPackagesCompleted completionRoutine)
		{
		}

		public static void XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext context, string[] packageIdentifiers, XStoreDownloadAndInstallPackageUpdatesCompleted completionRoutine)
		{
		}

		public static void XStoreDownloadPackageUpdatesAsync(XStoreContext context, string[] packageIdentifiers, XStoreDownloadPackageUpdatesCompleted completionRoutine)
		{
		}

		public static int XStoreQueryPackageIdentifier(string storeId, out string packageIdentifier)
		{
			packageIdentifier = null;
			return 0;
		}

		public static int XStoreShowProductPageUIAsync(XStoreContext context, string storeId, XStoreShowProductPageUICompleted completionRoutine)
		{
			return 0;
		}

		public static int XStoreShowAssociatedProductsUIAsync(XStoreContext context, string storeId, XStoreProductKind productKinds, XStoreShowAssociatedProductsPageUICompleted completionRoutine)
		{
			return 0;
		}

		public static void XStoreShowRedeemTokenUIAsync(XStoreContext context, string token, string[] allowedStoreIds, bool disallowCsvRedeption, XStoreShowRedeemTokenUICompleted completionRoutine)
		{
		}

		public static void XStoreShowRateAndReviewUIAsync(XStoreContext context, XStoreShowRateAndReviewUICompleted completionRoutine)
		{
		}

		public static void XStoreShowPurchaseUIAsync(XStoreContext context, string storeId, string name, string extendedJsonData, XStoreShowPurchaseUICompleted completionRoutine)
		{
		}

		public static void XStoreQueryConsumableBalanceRemainingAsync(XStoreContext context, string storeProductId, XStoreQueryConsumableBalanceRemainingCompleted completionRoutine)
		{
		}

		public static void XStoreReportConsumableFulfillmentAsync(XStoreContext context, string storeProductId, uint quantity, Guid trackingId, XStoreReportConsumableFulfillmentCompleted completionRoutine)
		{
		}

		public static void XStoreGetUserCollectionsIdAsync(XStoreContext context, string serviceTicket, string publisherUserId, XStoreGetUserCollectionsIdCompleted completionRoutine)
		{
		}

		public static void XStoreGetUserPurchaseIdAsync(XStoreContext context, string serviceTicket, string publisherUserId, XStoreGetUserPurchaseIdCompleted completionRoutine)
		{
		}

		[MonoPInvokeCallback]
		private static NativeBool ProductQueryCallback(IntPtr product, IntPtr context)
		{
			return default(NativeBool);
		}

		private static int RetrieveQueryProducts(XStoreProductQueryHandle queryPage, out XStoreProduct[] result)
		{
			result = null;
			return 0;
		}

		private static void ExtractQueryResultAndComplete(XStoreQueryComplete completionRoutine, XAsyncBlockPtr block, QueryExtractionFunction extractionFunction)
		{
		}

		public static void XStoreQueryAssociatedProductsAsync(XStoreContext context, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete completionRoutine)
		{
		}

		public static void XStoreQueryEntitledProductsAsync(XStoreContext context, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete completionRoutine)
		{
		}

		public static void XStoreQueryProductForCurrentGameAsync(XStoreContext context, XStoreQueryComplete completionRoutine)
		{
		}

		public static void XStoreQueryProductForPackageAsync(XStoreContext context, XStoreProductKind productKinds, string packageIdentifier, XStoreQueryComplete completionRoutine)
		{
		}

		public static void XStoreQueryProductsAsync(XStoreContext context, XStoreProductKind productKinds, string[] storeIds, string[] actionFilters, XStoreQueryComplete completionRoutine)
		{
		}

		public static void XStoreProductsQueryNextPageAsync(XStoreQueryResult currentPage, XStoreQueryComplete completionRoutine)
		{
		}

		public static void XStoreCloseProductsQueryHandle(XStoreQueryResult result)
		{
		}

		public static bool XThreadIsTimeSensitive()
		{
			return false;
		}

		public static int XThreadSetTimeSensitive(bool isTimeSensitiveThread)
		{
			return 0;
		}

		public static void XThreadAssertNotTimeSensitive()
		{
		}

		[MonoPInvokeCallback]
		private static void UserChangeEventCallback(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent eventType)
		{
		}

		public static int XUserDuplicateHandle(XUserHandle handle, out XUserHandle duplicatedHandle)
		{
			duplicatedHandle = null;
			return 0;
		}

		public static void XUserCloseHandle(XUserHandle user)
		{
		}

		public static int XUserCompare(XUserHandle user1, XUserHandle user2, out int comparisonResult)
		{
			comparisonResult = default(int);
			return 0;
		}

		public static int XUserGetMaxUsers(out uint maxUsers)
		{
			maxUsers = default(uint);
			return 0;
		}

		public static void XUserAddAsync(XUserAddOptions options, XUserAddCompleted completionRoutine)
		{
		}

		public static int XUserGetId(XUserHandle user, out ulong userId)
		{
			userId = default(ulong);
			return 0;
		}

		public static int XUserFindUserById(ulong userId, out XUserHandle handle)
		{
			handle = null;
			return 0;
		}

		public static int XUserGetLocalId(XUserHandle user, out XUserLocalId userLocalId)
		{
			userLocalId = default(XUserLocalId);
			return 0;
		}

		public static int XUserFindUserByLocalId(XUserLocalId userLocalId, out XUserHandle handle)
		{
			handle = null;
			return 0;
		}

		public static int XUserGetIsGuest(XUserHandle user, out bool isGuest)
		{
			isGuest = default(bool);
			return 0;
		}

		public static int XUserGetState(XUserHandle user, out XUserState state)
		{
			state = default(XUserState);
			return 0;
		}

		public static int XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, out string gamertag)
		{
			gamertag = null;
			return 0;
		}

		public static void XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XUserGetGamerPictureCompleted completionRoutine)
		{
		}

		public static int XUserGetAgeGroup(XUserHandle user, out XUserAgeGroup ageGroup)
		{
			ageGroup = default(XUserAgeGroup);
			return 0;
		}

		public static int XUserCheckPrivilege(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, out bool hasPrivilege, out XUserPrivilegeDenyReason reason)
		{
			hasPrivilege = default(bool);
			reason = default(XUserPrivilegeDenyReason);
			return 0;
		}

		public static void XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XUserResolvePrivilegeWithUiCompleted completionRoutine)
		{
		}

		public static void XUserGetTokenAndSignatureUtf16Async(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureUtf16HttpHeader[] headers, byte[] body, XUserGetTokenAndSignatureUtf16Result completionRoutine)
		{
		}

		public static void XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XUserResolveIssueWithUiUtf16Result completionRoutine)
		{
		}

		public static int XUserRegisterForChangeEvent(XUserChangeEventCallback callback, out XRegistrationToken registrationToken)
		{
			registrationToken = null;
			return 0;
		}

		public static void XUserUnregisterForChangeEvent(XRegistrationToken registrationToken)
		{
		}

		public static int XUserGetSignOutDeferral(out XUserSignOutDeferralHandle deferral)
		{
			deferral = null;
			return 0;
		}

		public static int XUserCloseSignOutDeferralHandle(XUserSignOutDeferralHandle deferral)
		{
			return 0;
		}

		[AOT.MonoPInvokeCallback(typeof(XAsyncWorkInterop))]
		private static int OnAsyncWorkCallback(IntPtr asyncBlock)
		{
			return 0;
		}

		public static int XAsyncGetStatus(XAsyncBlock asyncBlock, bool wait)
		{
			return 0;
		}

		public static int XAsyncGetResultSize(XAsyncBlock asyncBlock, out ulong bufferSize)
		{
			bufferSize = default(ulong);
			return 0;
		}

		public static void XAsyncCancel(XAsyncBlock asyncBlock)
		{
		}

		public static int XAsyncRun(XAsyncBlock asyncBlock, XAsyncWork work)
		{
			return 0;
		}
	}
}
