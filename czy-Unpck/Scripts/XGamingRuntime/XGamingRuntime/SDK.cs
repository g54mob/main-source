using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class SDK
	{
		public delegate void XStoreQueryGameAndDlcPackageUpdatesCompleted(int hresult, XStorePackageUpdate[] packageUpdates);

		public delegate void XStoreDownloadAndInstallPackagesCompleted(int hresult, string[] packageIdentifiers);

		public delegate void XStoreDownloadAndInstallPackageUpdatesCompleted(int hresult);

		public delegate void XStoreDownloadPackageUpdatesCompleted(int hresult);

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

			public delegate void XblMultiplayerWriteSessionHandleResult(int hresult, XblMultiplayerSessionHandle handle);

			public delegate void XblMultiplayerCreateSearchHandleResult(int hresult, XblMultiplayerSearchHandle handle);

			public delegate void XblMultiplayerDeleteSearchHandleResult(int hresult);

			public delegate void XblMultiplayerGetSearchHandlesResult(int hresult, XblMultiplayerSearchHandle[] searchHandles);

			public delegate void XblMultiplayerSessionChangedHandler(XblMultiplayerSessionChangeEventArgs args);

			public delegate void XblMultiplayerSessionSubscriptionLostHandler();

			public delegate void XblMultiplayerConnectionIdChangedHandler();

			public delegate void XblMultiplayerGetActivitiesWithPropertiesResult(int hresult, XblMultiplayerActivityDetails[] result);

			public delegate void XblCleanupResult(int hresult);

			public static int XblAchievementsResultGetAchievements(XblAchievementsResultHandle resultHandle, out XblAchievement[] achievements)
			{
				if (resultHandle == null)
				{
					achievements = null;
					return -2147024809;
				}
				IntPtr achievements2;
				SizeT achievementsCount;
				int num = XblInterop.XblAchievementsResultGetAchievements(resultHandle.InteropHandle, out achievements2, out achievementsCount);
				if (HR.FAILED(num))
				{
					achievements = null;
					return num;
				}
				achievements = Converters.PtrToClassArray(achievements2, achievementsCount, (XGamingRuntime.Interop.XblAchievement a) => new XblAchievement(a));
				return num;
			}

			public static int XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext)
			{
				if (resultHandle == null)
				{
					hasNext = false;
					return -2147024809;
				}
				return XblInterop.XblAchievementsResultHasNext(resultHandle.InteropHandle, out hasNext);
			}

			public static void XblAchievementsResultGetNextAsync(XblAchievementsResultHandle resultHandle, uint maxItems, XblAchievementsResultGetNextResult completionRoutine)
			{
				if (resultHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblAchievementsResultHandle resultHandle2;
					int num2 = XblInterop.XblAchievementsResultGetNextResult(block, out resultHandle2);
					if (HR.SUCCEEDED(num2))
					{
						completionRoutine(num2, new XblAchievementsResultHandle(resultHandle2));
					}
					else
					{
						completionRoutine(num2, null);
					}
				});
				int num = XblInterop.XblAchievementsResultGetNextAsync(resultHandle.InteropHandle, maxItems, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblAchievementsGetAchievementsForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, XblAchievementsGetAchievementsForTitleIdResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblAchievementsResultHandle result;
					int num2 = XblInterop.XblAchievementsGetAchievementsForTitleIdResult(block, out result);
					if (HR.SUCCEEDED(num2))
					{
						completionRoutine(num2, new XblAchievementsResultHandle(result));
					}
					else
					{
						completionRoutine(num2, null);
					}
				});
				int num = XblInterop.XblAchievementsGetAchievementsForTitleIdAsync(xboxLiveContext.InteropHandle, xboxUserId, titleId, type, unlockedOnly, orderBy, skipItems, maxItems, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
					completionRoutine(hresult);
				});
				int num = XblInterop.XblAchievementsUpdateAchievementAsync(xboxLiveContext.InteropHandle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, string serviceConfigurationId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
					completionRoutine(hresult);
				});
				int num = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(xboxLiveContext.InteropHandle, xboxUserId, titleId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static void XblAchievementsGetAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string serviceConfigurationId, string achievementId, XblAchievementsGetAchievementResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblAchievementsResultHandle result;
					int num2 = XblInterop.XblAchievementsGetAchievementResult(block, out result);
					if (HR.SUCCEEDED(num2))
					{
						completionRoutine(num2, new XblAchievementsResultHandle(result));
					}
					else
					{
						completionRoutine(num2, null);
					}
				});
				int num = XblInterop.XblAchievementsGetAchievementAsync(xboxLiveContext.InteropHandle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static int XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle)
			{
				if (handle == null)
				{
					duplicatedHandle = null;
					return -2147024809;
				}
				XGamingRuntime.Interop.XblAchievementsResultHandle duplicatedHandle2;
				int num = XblInterop.XblAchievementsResultDuplicateHandle(handle.InteropHandle, out duplicatedHandle2);
				if (HR.SUCCEEDED(num))
				{
					duplicatedHandle = new XblAchievementsResultHandle(duplicatedHandle2);
					return num;
				}
				duplicatedHandle = null;
				return num;
			}

			public static void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle)
			{
				if (!(handle == null))
				{
					XblInterop.XblAchievementsResultCloseHandle(handle.InteropHandle);
					handle.InteropHandle = default(XGamingRuntime.Interop.XblAchievementsResultHandle);
				}
			}

			public static XblErrorCondition XblGetErrorCondition(int hr)
			{
				return XblInterop.XblGetErrorCondition(hr);
			}

			public static XblHresult XblGetHRESULT(int hr)
			{
				XblHresult xblHresult = XblHresult.HRESULT_NOT_RECOGNIZED;
				try
				{
					return (XblHresult)Enum.GetValues(typeof(XblHresult)).GetValue(hr);
				}
				catch (IndexOutOfRangeException)
				{
					return XblHresult.HRESULT_NOT_RECOGNIZED;
				}
			}

			public static int XblEventsWriteInGameEvent(XblContextHandle xboxLiveContext, string eventName, string dimensionsJson, string measurementsJson)
			{
				if (xboxLiveContext == null)
				{
					return -2147024809;
				}
				return XblInterop.XblEventsWriteInGameEvent(xboxLiveContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(eventName), Converters.StringToNullTerminatedUTF8ByteArray(dimensionsJson), Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
			}

			public static int XblHttpCallRequestSetRequestBodyBytes(XblHttpCallHandle call, byte[] requestBodyBytes)
			{
				if (call == null || requestBodyBytes == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRequestBodyBytes(call.InteropHandle, requestBodyBytes, (uint)requestBodyBytes.Length);
			}

			public static int XblHttpCallGetNetworkErrorCode(XblHttpCallHandle call, out int networkErrorCode, out uint platformNetworkErrorCode)
			{
				if (call == null)
				{
					networkErrorCode = 0;
					platformNetworkErrorCode = 0u;
					return -2147024809;
				}
				return XblInterop.XblHttpCallGetNetworkErrorCode(call.InteropHandle, out networkErrorCode, out platformNetworkErrorCode);
			}

			public static int XblHttpCallRequestSetLongHttpCall(XblHttpCallHandle call, bool longHttpCall)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetLongHttpCall(call.InteropHandle, new NativeBool(longHttpCall));
			}

			public static void XblHttpCallPerformAsync(XblHttpCallHandle call, XblHttpCallResponseBodyType type, XblHttpCallPerformCompleted completionRoutine)
			{
				if (call == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				int num = XblInterop.XblHttpCallPerformAsync(call.InteropHandle, type, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static int XblHttpCallSetTracing(XblHttpCallHandle call, bool traceCall)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallSetTracing(call.InteropHandle, new NativeBool(traceCall));
			}

			public static int XblHttpCallCreate(XblContextHandle xblContext, string method, string url, out XblHttpCallHandle call)
			{
				if (xblContext == null)
				{
					call = null;
					return -2147024809;
				}
				XGamingRuntime.Interop.XblHttpCallHandle call2;
				return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblHttpCallCreate(xblContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(method), Converters.StringToNullTerminatedUTF8ByteArray(url), out call2), call2, out call);
			}

			public static void XblHttpCallCloseHandle(XblHttpCallHandle call)
			{
				if (!(call == null))
				{
					XblInterop.XblHttpCallCloseHandle(call.InteropHandle);
					call.InteropHandle = default(XGamingRuntime.Interop.XblHttpCallHandle);
				}
			}

			public static int XblHttpCallRequestSetRequestBodyString(XblHttpCallHandle call, string requestBodyString)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRequestBodyString(call.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(requestBodyString));
			}

			public static int XblHttpCallGetResponseString(XblHttpCallHandle call, out string responseString)
			{
				responseString = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr responseString2;
				int num = XblInterop.XblHttpCallGetResponseString(call.InteropHandle, out responseString2);
				if (HR.SUCCEEDED(num))
				{
					responseString = responseString2.GetString();
				}
				return num;
			}

			public static int XblHttpCallGetHeaderAtIndex(XblHttpCallHandle call, uint headerIndex, out string headerName, out string headerValue)
			{
				headerName = null;
				headerValue = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr headerName2;
				UTF8StringPtr headerValue2;
				int num = XblInterop.XblHttpCallGetHeaderAtIndex(call.InteropHandle, headerIndex, out headerName2, out headerValue2);
				if (HR.SUCCEEDED(num))
				{
					headerName = headerName2.GetString();
					headerValue = headerValue2.GetString();
				}
				return num;
			}

			public static int XblHttpCallGetPlatformNetworkErrorMessage(XblHttpCallHandle call, out string platformNetworkErrorMessage)
			{
				platformNetworkErrorMessage = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr platformNetworkErrorMessage2;
				int num = XblInterop.XblHttpCallGetPlatformNetworkErrorMessage(call.InteropHandle, out platformNetworkErrorMessage2);
				if (HR.SUCCEEDED(num))
				{
					platformNetworkErrorMessage = platformNetworkErrorMessage2.GetString();
				}
				return num;
			}

			public static int XblHttpCallGetResponseBodyBytes(XblHttpCallHandle call, out byte[] buffer)
			{
				buffer = null;
				if (call == null)
				{
					return -2147024809;
				}
				SizeT bufferSize;
				int num = XblInterop.XblHttpCallGetResponseBodyBytesSize(call.InteropHandle, out bufferSize);
				if (HR.SUCCEEDED(num))
				{
					buffer = new byte[bufferSize.ToInt32()];
					SizeT bufferUsed;
					return XblInterop.XblHttpCallGetResponseBodyBytes(call.InteropHandle, bufferSize, buffer, out bufferUsed);
				}
				return num;
			}

			public static int XblHttpCallRequestSetRetryAllowed(XblHttpCallHandle call, bool retryAllowed)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRetryAllowed(call.InteropHandle, new NativeBool(retryAllowed));
			}

			public static int XblHttpCallRequestSetHeader(XblHttpCallHandle call, string headerName, string headerValue, bool allowTracing)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetHeader(call.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(headerName), Converters.StringToNullTerminatedUTF8ByteArray(headerValue), new NativeBool(allowTracing));
			}

			public static int XblHttpCallDuplicateHandle(XblHttpCallHandle call, out XblHttpCallHandle duplicateHandle)
			{
				if (call == null)
				{
					duplicateHandle = null;
					return -2147024809;
				}
				XGamingRuntime.Interop.XblHttpCallHandle duplicateHandle2;
				return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblHttpCallDuplicateHandle(call.InteropHandle, out duplicateHandle2), duplicateHandle2, out duplicateHandle);
			}

			public static int XblHttpCallGetNumHeaders(XblHttpCallHandle call, out uint numHeaders)
			{
				if (call == null)
				{
					numHeaders = 0u;
					return -2147024809;
				}
				return XblInterop.XblHttpCallGetNumHeaders(call.InteropHandle, out numHeaders);
			}

			public static int XblHttpCallGetStatusCode(XblHttpCallHandle call, out uint statusCode)
			{
				if (call == null)
				{
					statusCode = 0u;
					return -2147024809;
				}
				return XblInterop.XblHttpCallGetStatusCode(call.InteropHandle, out statusCode);
			}

			public static int XblHttpCallGetHeader(XblHttpCallHandle call, string headerName, out string headerValue)
			{
				headerValue = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr headerValue2;
				int num = XblInterop.XblHttpCallGetHeader(call.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(headerName), out headerValue2);
				if (HR.SUCCEEDED(num))
				{
					headerValue = headerValue2.GetString();
				}
				return num;
			}

			public static int XblHttpCallGetRequestUrl(XblHttpCallHandle call, out string url)
			{
				url = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr url2;
				int num = XblInterop.XblHttpCallGetRequestUrl(call.InteropHandle, out url2);
				if (HR.SUCCEEDED(num))
				{
					url = url2.GetString();
				}
				return num;
			}

			public static int XblHttpCallRequestSetRetryCacheId(XblHttpCallHandle call, uint retryAfterCacheId)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRetryCacheId(call.InteropHandle, retryAfterCacheId);
			}

			public static void XblLeaderboardGetLeaderboardAsync(XblContextHandle xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XblLeaderboardGetLeaderboardCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblLeaderboardGetLeaderboardResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblLeaderboardGetLeaderboardResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (XGamingRuntime.Interop.XblLeaderboardResult r) => new XblLeaderboardResult(r)));
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblLeaderboardGetLeaderboardAsync(xboxLiveContext.InteropHandle, new XGamingRuntime.Interop.XblLeaderboardQuery(leaderboardQuery, disposableCollection), asyncBlock);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			public static void XblLeaderboardResultGetNextAsync(XblContextHandle xboxLiveContext, XblLeaderboardResult leaderboardResult, uint maxItems, XblLeaderboardGetNextCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblLeaderboardResultGetNextResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblLeaderboardResultGetNextResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (XGamingRuntime.Interop.XblLeaderboardResult r) => new XblLeaderboardResult(r)));
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XGamingRuntime.Interop.XblLeaderboardResult leaderboardResult2 = new XGamingRuntime.Interop.XblLeaderboardResult(leaderboardResult, disposableCollection);
					int num = XblInterop.XblLeaderboardResultGetNextAsync(xboxLiveContext.InteropHandle, ref leaderboardResult2, maxItems, asyncBlock);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			public static XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionInitArgs initArgs)
			{
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2 = new XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionRef);
					XGamingRuntime.Interop.XblMultiplayerSessionInitArgs initArgs2 = new XGamingRuntime.Interop.XblMultiplayerSessionInitArgs(initArgs, disposableCollection);
					return new XblMultiplayerSessionHandle(XblInterop.XblMultiplayerSessionCreateHandle(xboxUserId, ref sessionRef2, ref initArgs2));
				}
			}

			public static void XblMultiplayerSessionCloseHandle(XblMultiplayerSessionHandle handle)
			{
				if (handle != null)
				{
					XblInterop.XblMultiplayerSessionCloseHandle(handle.InteropHandle);
				}
			}

			public unsafe static XblMultiplayerSessionProperties XblMultiplayerSessionSessionProperties(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return null;
				}
				XGamingRuntime.Interop.XblMultiplayerSessionProperties* ptr = XblInterop.XblMultiplayerSessionSessionProperties(handle.InteropHandle);
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionProperties(*ptr);
			}

			public static int XblMultiplayerSessionMembers(XblMultiplayerSessionHandle handle, out XblMultiplayerSessionMember[] members)
			{
				IntPtr members2;
				SizeT membersCount;
				int num = XblInterop.XblMultiplayerSessionMembers(handle.InteropHandle, out members2, out membersCount);
				if (HR.FAILED(num) || membersCount.IsZero)
				{
					members = null;
					return num;
				}
				members = Converters.PtrToClassArray(members2, membersCount, (XGamingRuntime.Interop.XblMultiplayerSessionMember x) => new XblMultiplayerSessionMember(x));
				return num;
			}

			public unsafe static XblMultiplayerSessionMember XblMultiplayerSessionCurrentUser(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return null;
				}
				XGamingRuntime.Interop.XblMultiplayerSessionMember* ptr = XblInterop.XblMultiplayerSessionCurrentUser(handle.InteropHandle);
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionMember(*ptr);
			}

			public static XblWriteSessionStatus XblMultiplayerSessionWriteStatus(XblMultiplayerSessionHandle handle)
			{
				return XblInterop.XblMultiplayerSessionWriteStatus(handle.InteropHandle);
			}

			public static int XblMultiplayerSessionJoin(XblMultiplayerSessionHandle handle, string memberCustomConstantsJson, bool initializeRequested, bool joinWithActiveStatus)
			{
				return XblInterop.XblMultiplayerSessionJoin(handle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(memberCustomConstantsJson), initializeRequested, joinWithActiveStatus);
			}

			public static void XblMultiplayerSessionSetHostDeviceToken(XblMultiplayerSessionHandle handle, XblDeviceToken hostDeviceToken)
			{
				if (!(handle == null))
				{
					XblInterop.XblMultiplayerSessionSetHostDeviceToken(handle.InteropHandle, new XGamingRuntime.Interop.XblDeviceToken(hostDeviceToken));
				}
			}

			public static void XblMultiplayerSessionSetClosed(XblMultiplayerSessionHandle handle, bool closed)
			{
				if (handle != null)
				{
					XblInterop.XblMultiplayerSessionSetClosed(handle.InteropHandle, closed);
				}
			}

			public static int XblMultiplayerSessionSetSessionChangeSubscription(XblMultiplayerSessionHandle handle, XblMultiplayerSessionChangeTypes changeTypes)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionSetSessionChangeSubscription(handle.InteropHandle, changeTypes);
				}
				return -2147024809;
			}

			public static int XblMultiplayerSessionLeave(XblMultiplayerSessionHandle handle)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionLeave(handle.InteropHandle);
				}
				return -2147024809;
			}

			public static int XblMultiplayerSessionCurrentUserSetStatus(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberStatus status)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionCurrentUserSetStatus(handle.InteropHandle, status);
				}
				return -2147024809;
			}

			public static int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(XblMultiplayerSessionHandle handle, string value)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(handle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(value));
				}
				return -2147024809;
			}

			public static int XblFormatSecureDeviceAddress(string deviceId, out string address)
			{
				if (deviceId != null)
				{
					XblFormattedSecureDeviceAddress address2;
					int result = XblInterop.XblFormatSecureDeviceAddress(Converters.StringToNullTerminatedUTF8ByteArray(deviceId), out address2);
					address = address2.GetValue();
					return result;
				}
				address = null;
				return -2147024809;
			}

			public static int XblMultiplayerSearchHandleDuplicateHandle(XblMultiplayerSearchHandle handle, out XblMultiplayerSearchHandle duplicatedHandle)
			{
				duplicatedHandle = null;
				if (handle == null)
				{
					return -2147024809;
				}
				XGamingRuntime.Interop.XblMultiplayerSearchHandle duplicatedHandle2;
				int num = XblInterop.XblMultiplayerSearchHandleDuplicateHandle(handle.InteropHandle, out duplicatedHandle2);
				if (!HR.FAILED(num))
				{
					duplicatedHandle = new XblMultiplayerSearchHandle(duplicatedHandle2);
				}
				return num;
			}

			public static void XblMultiplayerSearchHandleCloseHandle(XblMultiplayerSearchHandle handle)
			{
				if (handle != null)
				{
					XblInterop.XblMultiplayerSearchHandleCloseHandle(handle.InteropHandle);
				}
			}

			public static int XblMultiplayerSearchHandleGetSessionReference(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionReference sessionRef)
			{
				XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2;
				int num = XblInterop.XblMultiplayerSearchHandleGetSessionReference(handle.InteropHandle, out sessionRef2);
				if (HR.FAILED(num))
				{
					sessionRef = null;
					return num;
				}
				sessionRef = new XblMultiplayerSessionReference(sessionRef2);
				return num;
			}

			public static int XblMultiplayerSearchHandleGetId(XblMultiplayerSearchHandle handle, out string id)
			{
				UTF8StringPtr id2;
				int num = XblInterop.XblMultiplayerSearchHandleGetId(handle.InteropHandle, out id2);
				if (HR.FAILED(num))
				{
					id = null;
					return num;
				}
				id = id2.GetString();
				return num;
			}

			public static int XblMultiplayerSearchHandleGetSessionOwnerXuids(XblMultiplayerSearchHandle handle, out ulong[] xuids)
			{
				IntPtr xuids2;
				SizeT xuidsCount;
				int num = XblInterop.XblMultiplayerSearchHandleGetSessionOwnerXuids(handle.InteropHandle, out xuids2, out xuidsCount);
				if (HR.FAILED(num) || xuidsCount.IsZero)
				{
					xuids = null;
					return num;
				}
				xuids = Converters.PtrToClassArray(xuids2, xuidsCount.ToUInt32(), (ulong x) => x);
				return num;
			}

			public static int XblMultiplayerSearchHandleGetTags(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionTag[] tags)
			{
				IntPtr tags2;
				SizeT tagsCount;
				int num = XblInterop.XblMultiplayerSearchHandleGetTags(handle.InteropHandle, out tags2, out tagsCount);
				if (HR.FAILED(num) || tagsCount.IsZero)
				{
					tags = null;
					return num;
				}
				tags = Converters.PtrToClassArray(tags2, tagsCount, (XGamingRuntime.Interop.XblMultiplayerSessionTag x) => new XblMultiplayerSessionTag(x));
				return num;
			}

			public static int XblMultiplayerSearchHandleGetStringAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionStringAttribute[] attributes)
			{
				IntPtr attributes2;
				SizeT attributesCount;
				int num = XblInterop.XblMultiplayerSearchHandleGetStringAttributes(handle.InteropHandle, out attributes2, out attributesCount);
				if (HR.FAILED(num) || attributesCount.IsZero)
				{
					attributes = null;
					return num;
				}
				attributes = Converters.PtrToClassArray(attributes2, attributesCount, (XGamingRuntime.Interop.XblMultiplayerSessionStringAttribute x) => new XblMultiplayerSessionStringAttribute(x));
				return num;
			}

			public static int XblMultiplayerSearchHandleGetNumberAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionNumberAttribute[] attributes)
			{
				IntPtr attributes2;
				SizeT attributesCount;
				int num = XblInterop.XblMultiplayerSearchHandleGetNumberAttributes(handle.InteropHandle, out attributes2, out attributesCount);
				if (HR.FAILED(num) || attributesCount.IsZero)
				{
					attributes = null;
					return num;
				}
				attributes = Converters.PtrToClassArray(attributes2, attributesCount, (XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute x) => new XblMultiplayerSessionNumberAttribute(x));
				return num;
			}

			public static int XblMultiplayerSearchHandleGetVisibility(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionVisibility visibility)
			{
				return XblInterop.XblMultiplayerSearchHandleGetVisibility(handle.InteropHandle, out visibility);
			}

			public static int XblMultiplayerSearchHandleGetJoinRestriction(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionRestriction joinRestriction)
			{
				return XblInterop.XblMultiplayerSearchHandleGetJoinRestriction(handle.InteropHandle, out joinRestriction);
			}

			public static int XblMultiplayerSearchHandleGetSessionClosed(XblMultiplayerSearchHandle handle, out bool closed)
			{
				return XblInterop.XblMultiplayerSearchHandleGetSessionClosed(handle.InteropHandle, out closed);
			}

			public static int XblMultiplayerSearchHandleGetMemberCounts(XblMultiplayerSearchHandle handle, out uint maxMembers, out uint currentMembers)
			{
				maxMembers = 0u;
				currentMembers = 0u;
				if (handle == null)
				{
					return -2147024809;
				}
				SizeT maxMembers2;
				SizeT currentMembers2;
				int num = XblInterop.XblMultiplayerSearchHandleGetMemberCounts(handle.InteropHandle, out maxMembers2, out currentMembers2);
				if (HR.SUCCEEDED(num))
				{
					maxMembers = maxMembers2.ToUInt32();
					currentMembers = currentMembers2.ToUInt32();
				}
				return num;
			}

			public static int XblMultiplayerSearchHandleGetCreationTime(XblMultiplayerSearchHandle handle, out DateTime creationTime)
			{
				creationTime = default(DateTime);
				if (handle == null)
				{
					return -2147024809;
				}
				TimeT creationTime2;
				int num = XblInterop.XblMultiplayerSearchHandleGetCreationTime(handle.InteropHandle, out creationTime2);
				if (HR.SUCCEEDED(num))
				{
					creationTime = creationTime2.DateTime;
				}
				return num;
			}

			public static int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(XblMultiplayerSearchHandle handle, out string customPropertiesJson)
			{
				customPropertiesJson = null;
				if (handle == null)
				{
					return -2147024809;
				}
				UTF8StringPtr customPropertiesJson2;
				int num = XblInterop.XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(handle.InteropHandle, out customPropertiesJson2);
				if (HR.SUCCEEDED(num))
				{
					customPropertiesJson = customPropertiesJson2.GetString();
				}
				return num;
			}

			public static void XblMultiplayerWriteSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, XblMultiplayerWriteSessionHandleResult completionRoutine)
			{
				if (xblContext == null || handle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblMultiplayerSessionHandle handle2;
					int num2 = XblInterop.XblMultiplayerWriteSessionResult(block, out handle2);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, new XblMultiplayerSessionHandle(handle2));
					}
				});
				int num = XblInterop.XblMultiplayerWriteSessionAsync(xblContext.InteropHandle, handle.InteropHandle, writeMode, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblMultiplayerCreateSearchHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionTag[] tags, XblMultiplayerSessionNumberAttribute[] numberAttributes, XblMultiplayerSessionStringAttribute[] stringAttributes, XblMultiplayerCreateSearchHandleResult completionRoutine)
			{
				if (xblContext == null || sessionRef == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblMultiplayerSearchHandle handle;
					int num2 = XblInterop.XblMultiplayerCreateSearchHandleResult(block, out handle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, new XblMultiplayerSearchHandle(handle));
					}
				});
				XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2 = new XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionRef);
				XGamingRuntime.Interop.XblMultiplayerSessionTag[] array = Converters.ConvertArrayToFixedLength(tags, tags.Length, (XblMultiplayerSessionTag r) => new XGamingRuntime.Interop.XblMultiplayerSessionTag(r));
				XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute[] array2 = Converters.ConvertArrayToFixedLength(numberAttributes, numberAttributes.Length, (XblMultiplayerSessionNumberAttribute r) => new XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute(r));
				XGamingRuntime.Interop.XblMultiplayerSessionStringAttribute[] array3 = Converters.ConvertArrayToFixedLength(stringAttributes, stringAttributes.Length, (XblMultiplayerSessionStringAttribute r) => new XGamingRuntime.Interop.XblMultiplayerSessionStringAttribute(r));
				int num = XblInterop.XblMultiplayerCreateSearchHandleAsync(xblContext.InteropHandle, ref sessionRef2, array, new SizeT(array.Length), array2, new SizeT(array2.Length), array3, new SizeT(array3.Length), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblMultiplayerDeleteSearchHandleAsync(XblContextHandle xblContext, string handleId, XblMultiplayerDeleteSearchHandleResult completionRoutine)
			{
				if (xblContext == null || handleId == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				int num = XblInterop.XblMultiplayerDeleteSearchHandleAsync(xblContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(handleId), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static void XblMultiplayerGetSearchHandlesAsync(XblContextHandle xboxLiveContext, string scid, string sessionTemplateName, string orderByAttribute, bool orderAscending, string searchFilter, string socialGroup, XblMultiplayerGetSearchHandlesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerSearchHandle[0]);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					SizeT searchHandleCount;
					int num2 = XblInterop.XblMultiplayerGetSearchHandlesResultCount(block, out searchHandleCount);
					if (HR.FAILED(num2) || searchHandleCount.IsZero)
					{
						completionRoutine(num2, new XblMultiplayerSearchHandle[0]);
					}
					else
					{
						XGamingRuntime.Interop.XblMultiplayerSearchHandle[] array = new XGamingRuntime.Interop.XblMultiplayerSearchHandle[searchHandleCount.ToInt32()];
						int num3 = XblInterop.XblMultiplayerGetSearchHandlesResult(block, array, searchHandleCount);
						if (!HR.FAILED(num3))
						{
							completionRoutine(num3, Array.ConvertAll(array, (XGamingRuntime.Interop.XblMultiplayerSearchHandle h) => new XblMultiplayerSearchHandle(h)));
						}
						else
						{
							completionRoutine(num3, new XblMultiplayerSearchHandle[0]);
						}
					}
				});
				int num = XblInterop.XblMultiplayerGetSearchHandlesAsync(xboxLiveContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(scid), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(orderByAttribute), orderAscending, Converters.StringToNullTerminatedUTF8ByteArray(searchFilter), Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, new XblMultiplayerSearchHandle[0]);
				}
			}

			public static int XblMultiplayerSetSubscriptionsEnabled(XblContextHandle xblContext, bool subscriptionsEnabled)
			{
				return XblInterop.XblMultiplayerSetSubscriptionsEnabled(xblContext.InteropHandle, subscriptionsEnabled);
			}

			public static bool XblMultiplayerSubscriptionsEnabled(XblContextHandle xblHandle)
			{
				return XblInterop.XblMultiplayerSubscriptionsEnabled(xblHandle.InteropHandle);
			}

			public unsafe static void XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(XblContextHandle xboxLiveContext, string scid, ulong[] xuids, XblMultiplayerGetActivitiesWithPropertiesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						if (!resultSizeInBytes.IsZero)
						{
							using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
							{
								num2 = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var ptrToBufferCount, out var _);
								if (HR.FAILED(num2))
								{
									completionRoutine(num2, null);
								}
								else
								{
									List<XblMultiplayerActivityDetails> list = new List<XblMultiplayerActivityDetails>();
									for (int i = 0; i < ptrToBufferCount.ToInt32(); i++)
									{
										list.Add(new XblMultiplayerActivityDetails(ptrToBuffer[i]));
									}
									completionRoutine(num2, list.ToArray());
								}
								return;
							}
						}
						completionRoutine(0, new XblMultiplayerActivityDetails[0]);
					}
				});
				SizeT xuidsCount = new SizeT(0);
				if (xuids != null && xuids.Length != 0)
				{
					xuidsCount = new SizeT(xuids.Length);
				}
				int num = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(xboxLiveContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(scid), xuids, xuidsCount, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public unsafe static void XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(XblContextHandle xboxLiveContext, string scid, ulong socialGroupOwnerXuid, string socialGroup, XblMultiplayerGetActivitiesWithPropertiesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						if (!resultSizeInBytes.IsZero)
						{
							using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
							{
								num2 = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var ptrToBufferCount, out var _);
								if (HR.FAILED(num2))
								{
									completionRoutine(num2, null);
								}
								else
								{
									List<XblMultiplayerActivityDetails> list = new List<XblMultiplayerActivityDetails>();
									for (int i = 0; i < ptrToBufferCount.ToInt32(); i++)
									{
										list.Add(new XblMultiplayerActivityDetails(ptrToBuffer[i]));
									}
									completionRoutine(num2, list.ToArray());
								}
								return;
							}
						}
						completionRoutine(0, new XblMultiplayerActivityDetails[0]);
					}
				});
				int num = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(xboxLiveContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(scid), socialGroupOwnerXuid, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public unsafe static void XblMultiplayerActivityGetActivityAsync(XblContextHandle xblContextHandle, ulong[] xuids, XblMultiplayerActivityGetActivityCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblMultiplayerActivityGetActivityResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblMultiplayerActivityGetActivityResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBufferResults, out var resultCount, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							List<XblMultiplayerActivityInfo> list = new List<XblMultiplayerActivityInfo>();
							for (int i = 0; i < resultCount.ToInt32(); i++)
							{
								list.Add(new XblMultiplayerActivityInfo(ptrToBufferResults[i]));
							}
							completionRoutine(num2, list.ToArray());
						}
					}
				});
				using (new DisposableCollection())
				{
					SizeT xuidsCount = new SizeT(0);
					if (xuids != null && xuids.Length != 0)
					{
						xuidsCount = new SizeT(xuids.Length);
					}
					int num = XblInterop.XblMultiplayerActivityGetActivityAsync(xblContextHandle.InteropHandle, xuids, xuidsCount, xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num, null);
					}
				}
			}

			public static void XblMultiplayerActivityFlushRecentPlayersAsync(XblContextHandle xblContextHandle, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				int num = XblInterop.XblMultiplayerActivityFlushRecentPlayersAsync(xblContextHandle.InteropHandle, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static void XblMultiplayerActivitySendInvitesAsync(XblContextHandle xblContextHandle, ulong[] xuids, bool allowCrossPlatformJoin, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
				XblMultiplayerActivitySendInvitesAsync(xblContextHandle, xuids, allowCrossPlatformJoin, string.Empty, completionRoutine);
			}

			public static void XblMultiplayerActivitySendInvitesAsync(XblContextHandle xblContextHandle, ulong[] xuids, bool allowCrossPlatformJoin, string connectionString, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				SizeT xuidsCount = new SizeT(0);
				if (xuids != null && xuids.Length != 0)
				{
					xuidsCount = new SizeT(xuids.Length);
				}
				int num = XblInterop.XblMultiplayerActivitySendInvitesAsync(xblContextHandle.InteropHandle, xuids, xuidsCount, new NativeBool(allowCrossPlatformJoin), Converters.StringToNullTerminatedUTF8ByteArray(connectionString), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static void XblMultiplayerActivityDeleteActivityAsync(XblContextHandle xblContextHandle, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				int num = XblInterop.XblMultiplayerActivityDeleteActivityAsync(xblContextHandle.InteropHandle, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static void XblMultiplayerActivitySetActivityAsync(XblContextHandle xblContextHandle, XblMultiplayerActivityInfo activityInfo, bool allowCrossPlatformJoin, XblMultiplayerActivityOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblMultiplayerActivitySetActivityAsync(xblContextHandle.InteropHandle, new XGamingRuntime.Interop.XblMultiplayerActivityInfo(activityInfo, disposableCollection), new NativeBool(allowCrossPlatformJoin), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num);
					}
				}
			}

			public static int XblMultiplayerActivityUpdateRecentPlayers(XblContextHandle xblContextHandle, XblMultiplayerActivityRecentPlayerUpdate[] recentPlayerUpdates)
			{
				XGamingRuntime.Interop.XblMultiplayerActivityRecentPlayerUpdate[] array = Array.ConvertAll(recentPlayerUpdates, (XblMultiplayerActivityRecentPlayerUpdate r) => new XGamingRuntime.Interop.XblMultiplayerActivityRecentPlayerUpdate(r));
				return XblInterop.XblMultiplayerActivityUpdateRecentPlayers(xblContextHandle.InteropHandle, array, new SizeT(array.Length));
			}

			public static int XblMultiplayerManagerInitialize(string lobbySessionTemplateName)
			{
				return XblInterop.XblMultiplayerManagerInitialize(Converters.StringToNullTerminatedUTF8ByteArray(lobbySessionTemplateName), defaultQueue.handle);
			}

			public static int XblMultiplayerManagerDoWork(out XblMultiplayerEvent[] events)
			{
				IntPtr multiplayerEvents;
				SizeT multiplayerEventsCount;
				int num = XblInterop.XblMultiplayerManagerDoWork(out multiplayerEvents, out multiplayerEventsCount);
				if (HR.FAILED(num))
				{
					events = null;
					return num;
				}
				events = Converters.PtrToClassArray(multiplayerEvents, multiplayerEventsCount, (XGamingRuntime.Interop.XblMultiplayerEvent x) => new XblMultiplayerEvent(x));
				return num;
			}

			public static XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(string scid, string sessionTemplateName, string sessionName)
			{
				return new XblMultiplayerSessionReference(XblInterop.XblMultiplayerSessionReferenceCreate(Converters.StringToNullTerminatedUTF8ByteArray(scid), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(sessionName)));
			}

			public static int XblMultiplayerManagerJoinLobby(string handleId, XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerJoinLobby(Converters.StringToNullTerminatedUTF8ByteArray(handleId), user.InteropHandle);
			}

			public static int XblMultiplayerManagerSetQosMeasurements(string measurementsJson)
			{
				return XblInterop.XblMultiplayerManagerSetQosMeasurements(Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
			}

			public static int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerSetJoinability(joinability, ctx), context);
			}

			public static int XblMultiplayerManagerJoinGameFromLobby(string sessionTemplateName)
			{
				return XblInterop.XblMultiplayerManagerJoinGameFromLobby(Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName));
			}

			public static void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(bool autoFillMembers)
			{
				XblInterop.XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(new NativeBool(autoFillMembers));
			}

			public static XblMultiplayerJoinability XblMultiplayerManagerJoinability()
			{
				return XblInterop.XblMultiplayerManagerJoinability();
			}

			public static void XblMultiplayerManagerCancelMatch()
			{
				XblInterop.XblMultiplayerManagerCancelMatch();
			}

			public static uint XblMultiplayerManagerEstimatedMatchWaitTime()
			{
				return XblInterop.XblMultiplayerManagerEstimatedMatchWaitTime();
			}

			public static bool XblMultiplayerManagerMemberAreMembersOnSameDevice(XblMultiplayerManagerMember first, XblMultiplayerManagerMember second)
			{
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XGamingRuntime.Interop.XblMultiplayerManagerMember first2 = new XGamingRuntime.Interop.XblMultiplayerManagerMember(first, disposableCollection);
					XGamingRuntime.Interop.XblMultiplayerManagerMember second2 = new XGamingRuntime.Interop.XblMultiplayerManagerMember(second, disposableCollection);
					return XblInterop.XblMultiplayerManagerMemberAreMembersOnSameDevice(ref first2, ref second2).Value;
				}
			}

			public static int XblMultiplayerSessionReferenceParseFromUriPath(string path, out XblMultiplayerSessionReference sessionReference)
			{
				XGamingRuntime.Interop.XblMultiplayerSessionReference sessionReference2;
				int num = XblInterop.XblMultiplayerSessionReferenceParseFromUriPath(Converters.StringToNullTerminatedUTF8ByteArray(path), out sessionReference2);
				if (HR.FAILED(num))
				{
					sessionReference = null;
					return num;
				}
				sessionReference = new XblMultiplayerSessionReference(sessionReference2);
				return num;
			}

			public static int XblMultiplayerManagerLeaveGame()
			{
				return XblInterop.XblMultiplayerManagerLeaveGame();
			}

			public static XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus()
			{
				return XblInterop.XblMultiplayerManagerMatchStatus();
			}

			public static bool XblMultiplayerManagerAutoFillMembersDuringMatchmaking()
			{
				return XblInterop.XblMultiplayerManagerAutoFillMembersDuringMatchmaking().Value;
			}

			public static int XblMultiplayerManagerFindMatch(string hopperName, string attributesJson, uint timeoutInSeconds)
			{
				return XblInterop.XblMultiplayerManagerFindMatch(Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(attributesJson), timeoutInSeconds);
			}

			public static bool XblMultiplayerSessionReferenceIsValid(XblMultiplayerSessionReference sessionReference)
			{
				XGamingRuntime.Interop.XblMultiplayerSessionReference sessionReference2 = new XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionReference);
				return XblInterop.XblMultiplayerSessionReferenceIsValid(ref sessionReference2).Value;
			}

			public static int XblMultiplayerManagerJoinGame(string sessionName, string sessionTemplateName, ulong[] xuids)
			{
				return XblInterop.XblMultiplayerManagerJoinGame(Converters.StringToNullTerminatedUTF8ByteArray(sessionName), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), xuids, new SizeT(xuids.Length));
			}

			public static int XblMultiplayerEventArgsTournamentRegistrationStateChanged(XblMultiplayerEventArgsHandle argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason)
			{
				if (argsHandle == null)
				{
					registrationState = XblTournamentRegistrationState.Unknown;
					registrationReason = XblTournamentRegistrationReason.Unknown;
					return -2147024809;
				}
				return XblInterop.XblMultiplayerEventArgsTournamentRegistrationStateChanged(argsHandle.InteropHandle, out registrationState, out registrationReason);
			}

			public static int XblMultiplayerEventArgsFindMatchCompleted(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause)
			{
				if (argsHandle == null)
				{
					matchStatus = XblMultiplayerMatchStatus.None;
					initializationFailureCause = XblMultiplayerMeasurementFailure.Unknown;
					return -2147024809;
				}
				return XblInterop.XblMultiplayerEventArgsFindMatchCompleted(argsHandle.InteropHandle, out matchStatus, out initializationFailureCause);
			}

			public static int XblMultiplayerEventArgsPropertiesJson(XblMultiplayerEventArgsHandle argsHandle, out string properties)
			{
				properties = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				UTF8StringPtr properties2;
				int num = XblInterop.XblMultiplayerEventArgsPropertiesJson(argsHandle.InteropHandle, out properties2);
				if (HR.SUCCEEDED(num))
				{
					properties = properties2.GetString();
				}
				return num;
			}

			public static int XblMultiplayerEventArgsXuid(XblMultiplayerEventArgsHandle argsHandle, out ulong xuid)
			{
				xuid = 0uL;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerEventArgsXuid(argsHandle.InteropHandle, out xuid);
			}

			public static int XblMultiplayerEventArgsTournamentGameSessionReady(XblMultiplayerEventArgsHandle argsHandle, out DateTime startTime)
			{
				startTime = default(DateTime);
				if (argsHandle == null)
				{
					return -2147024809;
				}
				TimeT startTime2;
				int num = XblInterop.XblMultiplayerEventArgsTournamentGameSessionReady(argsHandle.InteropHandle, out startTime2);
				if (HR.SUCCEEDED(num))
				{
					startTime = startTime2.DateTime;
				}
				return num;
			}

			public static int XblMultiplayerEventArgsMember(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember member)
			{
				member = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				XGamingRuntime.Interop.XblMultiplayerManagerMember member2;
				int num = XblInterop.XblMultiplayerEventArgsMember(argsHandle.InteropHandle, out member2);
				if (HR.SUCCEEDED(num))
				{
					member = new XblMultiplayerManagerMember(member2);
				}
				return num;
			}

			public static int XblMultiplayerEventArgsMembers(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember[] members)
			{
				members = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				int num = XblInterop.XblMultiplayerEventArgsMembersCount(argsHandle.InteropHandle, out var memberCount);
				if (HR.FAILED(num))
				{
					return num;
				}
				XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new XGamingRuntime.Interop.XblMultiplayerManagerMember[memberCount.ToInt32()];
				num = XblInterop.XblMultiplayerEventArgsMembers(argsHandle.InteropHandle, memberCount, array);
				if (HR.SUCCEEDED(num))
				{
					members = Array.ConvertAll(array, (XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			public static int XblMultiplayerEventArgsPerformQoSMeasurements(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs)
			{
				performQoSMeasurementsArgs = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				XGamingRuntime.Interop.XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs2;
				int num = XblInterop.XblMultiplayerEventArgsPerformQoSMeasurements(argsHandle.InteropHandle, out performQoSMeasurementsArgs2);
				if (HR.SUCCEEDED(num))
				{
					performQoSMeasurementsArgs = new XblMultiplayerPerformQoSMeasurementsArgs(performQoSMeasurementsArgs2);
				}
				return num;
			}

			private static int SessionSetInternalWithMarshalledContext(Func<IntPtr, int> setterFunction, object context)
			{
				IntPtr intPtr = IntPtr.Zero;
				if (context != null)
				{
					intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(context));
				}
				int num = setterFunction(intPtr);
				if (HR.FAILED(num) && intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
				return num;
			}

			public static bool XblMultiplayerManagerGameSessionIsHost(ulong xuid)
			{
				return XblInterop.XblMultiplayerManagerGameSessionIsHost(xuid).Value;
			}

			public static int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember)
			{
				hostMember = null;
				XGamingRuntime.Interop.XblMultiplayerManagerMember hostMember2;
				int num = XblInterop.XblMultiplayerManagerGameSessionHost(out hostMember2);
				if (HR.SUCCEEDED(num))
				{
					hostMember = new XblMultiplayerManagerMember(hostMember2);
				}
				return num;
			}

			public unsafe static XblMultiplayerSessionReference XblMultiplayerManagerGameSessionSessionReference()
			{
				XGamingRuntime.Interop.XblMultiplayerSessionReference* ptr = XblInterop.XblMultiplayerManagerGameSessionSessionReference();
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionReference(*ptr);
			}

			public static bool XblMultiplayerManagerGameSessionActive()
			{
				return XblInterop.XblMultiplayerManagerGameSessionActive().Value;
			}

			public static int XblMultiplayerManagerGameSessionSetProperties(string name, string valueJson, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			public static int XblMultiplayerManagerGameSessionSetSynchronizedHost(string deviceToken, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedHost(Converters.StringToNullTerminatedUTF8ByteArray(deviceToken), ctx), context);
			}

			public static int XblMultiplayerManagerGameSessionSetSynchronizedProperties(string name, string valueJson, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			public static string XblMultiplayerManagerGameSessionCorrelationId()
			{
				return XblInterop.XblMultiplayerManagerGameSessionCorrelationId().GetString();
			}

			public unsafe static XblMultiplayerSessionConstants XblMultiplayerManagerGameSessionConstants()
			{
				XGamingRuntime.Interop.XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerManagerGameSessionConstants();
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionConstants(*ptr);
			}

			public static int XblMultiplayerManagerGameSessionMembers(out XblMultiplayerManagerMember[] members)
			{
				members = null;
				SizeT membersCount = XblInterop.XblMultiplayerManagerGameSessionMembersCount();
				if (membersCount.IsZero)
				{
					return 0;
				}
				XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new XGamingRuntime.Interop.XblMultiplayerManagerMember[membersCount.ToInt32()];
				int num = XblInterop.XblMultiplayerManagerGameSessionMembers(membersCount, array);
				if (HR.SUCCEEDED(num))
				{
					members = Array.ConvertAll(array, (XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			public static string XblMultiplayerManagerGameSessionPropertiesJson()
			{
				return XblInterop.XblMultiplayerManagerGameSessionPropertiesJson().GetString();
			}

			public static int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember)
			{
				hostMember = null;
				XGamingRuntime.Interop.XblMultiplayerManagerMember hostMember2;
				int num = XblInterop.XblMultiplayerManagerLobbySessionHost(out hostMember2);
				if (HR.SUCCEEDED(num))
				{
					hostMember = new XblMultiplayerManagerMember(hostMember2);
				}
				return num;
			}

			public static int XblMultiplayerManagerLobbySessionInviteUsers(XUserHandle user, ulong[] xuids, string contextStringId, string customActivationContext)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionInviteUsers(user.InteropHandle, xuids, new SizeT(xuids.Length), Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
			}

			public static int XblMultiplayerManagerLobbySessionInviteFriends(XUserHandle requestingUser, string contextStringId, string customActivationContext)
			{
				if (requestingUser == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionInviteFriends(requestingUser.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
			}

			public static int XblMultiplayerManagerLobbySessionAddLocalUser(XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionAddLocalUser(user.InteropHandle);
			}

			public static int XblMultiplayerManagerLobbySessionMembers(out XblMultiplayerManagerMember[] members)
			{
				members = null;
				SizeT membersCount = XblInterop.XblMultiplayerManagerLobbySessionMembersCount();
				if (membersCount.IsZero)
				{
					return 0;
				}
				XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new XGamingRuntime.Interop.XblMultiplayerManagerMember[membersCount.ToInt32()];
				int num = XblInterop.XblMultiplayerManagerLobbySessionMembers(membersCount, array);
				if (HR.SUCCEEDED(num))
				{
					members = Array.ConvertAll(array, (XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			public static string XblMultiplayerManagerLobbySessionPropertiesJson()
			{
				return XblInterop.XblMultiplayerManagerLobbySessionPropertiesJson().GetString();
			}

			public unsafe static XblMultiplayerSessionConstants XblMultiplayerManagerLobbySessionConstants()
			{
				XGamingRuntime.Interop.XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerManagerLobbySessionConstants();
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionConstants(*ptr);
			}

			public static int XblMultiplayerManagerLobbySessionLocalMembers(out XblMultiplayerManagerMember[] localMembers)
			{
				localMembers = null;
				SizeT localMembersCount = XblInterop.XblMultiplayerManagerLobbySessionLocalMembersCount();
				if (localMembersCount.IsZero)
				{
					return 0;
				}
				XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new XGamingRuntime.Interop.XblMultiplayerManagerMember[localMembersCount.ToInt32()];
				int num = XblInterop.XblMultiplayerManagerLobbySessionLocalMembers(localMembersCount, array);
				if (HR.SUCCEEDED(num))
				{
					localMembers = Array.ConvertAll(array, (XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			public static int XblMultiplayerManagerLobbySessionRemoveLocalUser(XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionRemoveLocalUser(user.InteropHandle);
			}

			public unsafe static XblTournamentTeamResult XblMultiplayerManagerLobbySessionLastTournamentTeamResult()
			{
				XGamingRuntime.Interop.XblTournamentTeamResult* ptr = XblInterop.XblMultiplayerManagerLobbySessionLastTournamentTeamResult();
				if (ptr == null)
				{
					return null;
				}
				return new XblTournamentTeamResult(*ptr);
			}

			public static bool XblMultiplayerManagerLobbySessionIsHost(ulong xuid)
			{
				return XblInterop.XblMultiplayerManagerLobbySessionIsHost(xuid).Value;
			}

			public static int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId)
			{
				correlationId = null;
				XGamingRuntime.Interop.XblGuid correlationId2;
				int num = XblInterop.XblMultiplayerManagerLobbySessionCorrelationId(out correlationId2);
				if (HR.SUCCEEDED(num))
				{
					correlationId = new XblGuid(correlationId2);
				}
				return num;
			}

			public static int XblMultiplayerManagerLobbySessionSetSynchronizedHost(string deviceToken, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedHost(Converters.StringToNullTerminatedUTF8ByteArray(deviceToken), ctx), context);
			}

			public static int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference)
			{
				sessionReference = null;
				XGamingRuntime.Interop.XblMultiplayerSessionReference sessionReference2;
				int num = XblInterop.XblMultiplayerManagerLobbySessionSessionReference(out sessionReference2);
				if (!HR.FAILED(num))
				{
					sessionReference = new XblMultiplayerSessionReference(sessionReference2);
				}
				return num;
			}

			public static int XblMultiplayerManagerLobbySessionSetProperties(string name, string valueJson, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			public static int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(XUserHandle user, string name, string valueJson, object context)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberProperties(user.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			public static int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(string name, string valueJson, object context)
			{
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			public static int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(XUserHandle user, string connectionAddress, object context)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(user.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(connectionAddress), ctx), context);
			}

			public static int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(XUserHandle user, string name, object context)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(user.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(name), ctx), context);
			}

			public static int XblPresenceRecordGetXuid(XblPresenceRecordHandle handle, out ulong xuid)
			{
				if (handle == null)
				{
					xuid = 0uL;
					return -2147024809;
				}
				return XblInterop.XblPresenceRecordGetXuid(handle.InteropHandle, out xuid);
			}

			public static int XblPresenceRecordGetUserState(XblPresenceRecordHandle handle, out XblPresenceUserState userState)
			{
				if (handle == null)
				{
					userState = XblPresenceUserState.Unknown;
					return -2147024809;
				}
				return XblInterop.XblPresenceRecordGetUserState(handle.InteropHandle, out userState);
			}

			public static int XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle handle, out XblPresenceDeviceRecord[] deviceRecords)
			{
				if (handle == null)
				{
					deviceRecords = null;
					return -2147024809;
				}
				IntPtr deviceRecords2;
				SizeT deviceRecordsCount;
				int num = XblInterop.XblPresenceRecordGetDeviceRecords(handle.InteropHandle, out deviceRecords2, out deviceRecordsCount);
				if (HR.FAILED(num))
				{
					deviceRecords = null;
					return num;
				}
				deviceRecords = Converters.PtrToClassArray(deviceRecords2, deviceRecordsCount, (XGamingRuntime.Interop.XblPresenceDeviceRecord dr) => new XblPresenceDeviceRecord(dr));
				return num;
			}

			public static int XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle handle, out XblPresenceRecordHandle duplicatedHandle)
			{
				if (handle == null)
				{
					duplicatedHandle = null;
					return -2147024809;
				}
				XGamingRuntime.Interop.XblPresenceRecordHandle duplicatedHandle2;
				return XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblPresenceRecordDuplicateHandle(handle.InteropHandle, out duplicatedHandle2), duplicatedHandle2, out duplicatedHandle);
			}

			public static void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle)
			{
				if (!(handle == null))
				{
					XblInterop.XblPresenceRecordCloseHandle(handle.InteropHandle);
				}
			}

			public static void XblPresenceSetPresenceAsync(XblContextHandle xblContextHandle, bool isUserActiveInTitle, XblPresenceRichPresenceIds richPresenceIds, XblPresenceSetPresenceCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblPresenceSetPresenceAsync(xblContextHandle.InteropHandle, isUserActiveInTitle, (richPresenceIds == null) ? null : new XblPresenceRichPresenceIdsRef(richPresenceIds, disposableCollection), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num);
					}
				}
			}

			public static void XblPresenceGetPresenceAsync(XblContextHandle xblContextHandle, ulong xuid, XblPresenceGetPresenceCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblPresenceRecordHandle presenceRecordHandle;
					int hresult = XblInterop.XblPresenceGetPresenceResult(block, out presenceRecordHandle);
					XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(hresult, presenceRecordHandle, out var handle);
					completionRoutine(hresult, handle);
				});
				int num = XblInterop.XblPresenceGetPresenceAsync(xblContextHandle.InteropHandle, xuid, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblPresenceGetPresenceForMultipleUsersAsync(XblContextHandle xblContextHandle, ulong[] xuids, XblPresenceQueryFilters filters, XblPresenceGetPresenceForMultipleUsersCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblPresenceGetPresenceForMultipleUsersResultCount(block, out var resultCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						XGamingRuntime.Interop.XblPresenceRecordHandle[] array = new XGamingRuntime.Interop.XblPresenceRecordHandle[resultCount.ToInt32()];
						num2 = XblInterop.XblPresenceGetPresenceForMultipleUsersResult(block, array, resultCount);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Array.ConvertAll(array, (XGamingRuntime.Interop.XblPresenceRecordHandle h) => new XblPresenceRecordHandle(h)));
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					SizeT xuidsCount = new SizeT(0);
					if (xuids != null && xuids.Length != 0)
					{
						xuidsCount = new SizeT(xuids.Length);
					}
					int num = XblInterop.XblPresenceGetPresenceForMultipleUsersAsync(xblContextHandle.InteropHandle, xuids, xuidsCount, (filters == null) ? null : new XblPresenceQueryFiltersRef(filters, disposableCollection), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num, null);
					}
				}
			}

			public static void XblPresenceGetPresenceForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroupName, ulong? socialGroupOwnerXuid, XblPresenceQueryFilters filters, XblPresenceGetPresenceForSocialGroupCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblPresenceGetPresenceForSocialGroupResultCount(block, out var resultCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						XGamingRuntime.Interop.XblPresenceRecordHandle[] array = new XGamingRuntime.Interop.XblPresenceRecordHandle[resultCount.ToInt32()];
						num2 = XblInterop.XblPresenceGetPresenceForSocialGroupResult(block, array, resultCount);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Array.ConvertAll(array, (XGamingRuntime.Interop.XblPresenceRecordHandle h) => new XblPresenceRecordHandle(h)));
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblPresenceGetPresenceForSocialGroupAsync(xblContextHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(socialGroupName), (!socialGroupOwnerXuid.HasValue) ? null : new UInt64Ref(socialGroupOwnerXuid.Value), (filters == null) ? null : new XblPresenceQueryFiltersRef(filters, disposableCollection), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num, null);
					}
				}
			}

			public static void XblPrivacyGetAvoidListAsync(XblContextHandle xblContextHandle, XblPrivacyGetAvoidListCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblPrivacyGetAvoidListResultCount(block, out var xuidCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						ulong[] xuids = new ulong[xuidCount.ToInt32()];
						num2 = XblInterop.XblPrivacyGetAvoidListResult(block, xuidCount, xuids);
						completionRoutine(num2, xuids);
					}
				});
				int num = XblInterop.XblPrivacyGetAvoidListAsync(xblContextHandle.InteropHandle, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblPrivacyGetMuteListAsync(XblContextHandle xblContextHandle, XblPrivacyGetMuteListCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblPrivacyGetMuteListResultCount(block, out var xuidCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						ulong[] xuids = new ulong[xuidCount.ToInt32()];
						num2 = XblInterop.XblPrivacyGetMuteListResult(block, xuidCount, xuids);
						completionRoutine(num2, xuids);
					}
				});
				int num = XblInterop.XblPrivacyGetMuteListAsync(xblContextHandle.InteropHandle, xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}

			public static void XblPrivacyCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XblPrivacyCheckPermissionCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblPrivacyCheckPermissionResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblPrivacyCheckPermissionResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var result, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass(result, (XGamingRuntime.Interop.XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
						}
					}
				});
				int num = XblInterop.XblPrivacyCheckPermissionAsync(xblContextHandle.InteropHandle, permissionToCheck, targetXuid, async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static void XblPrivacyBatchCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission[] permissionsToCheck, ulong[] targetXuids, XblAnonymousUserType[] targetAnonymousUserTypes, XblPrivacyBatchCheckPermissionCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblPrivacyBatchCheckPermissionResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblPrivacyBatchCheckPermissionResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var results, out var resultsCount, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClassArray(results, resultsCount, (XGamingRuntime.Interop.XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
						}
					}
				});
				int num = XblInterop.XblPrivacyBatchCheckPermissionAsync(xblContextHandle.InteropHandle, permissionsToCheck, new SizeT((permissionsToCheck != null) ? permissionsToCheck.Length : 0), targetXuids, new SizeT((targetXuids != null) ? targetXuids.Length : 0), targetAnonymousUserTypes, new SizeT((targetAnonymousUserTypes != null) ? targetAnonymousUserTypes.Length : 0), async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static void XblProfileGetUserProfileAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblProfileGetUserProfileCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					XGamingRuntime.Interop.XblUserProfile profile;
					int num2 = XblInterop.XblProfileGetUserProfileResult(block, out profile);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, new XblUserProfile(profile));
					}
				});
				int num = XblInterop.XblProfileGetUserProfileAsync(xblContextHandle.InteropHandle, xboxUserId, async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static void XblProfileGetUserProfilesAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblProfileGetUserProfilesCompleted completionRoutine)
			{
				if (xblContextHandle == null || xboxUserIds == null || xboxUserIds.Length == 0)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblProfileGetUserProfilesResultCount(block, out var profileCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						XGamingRuntime.Interop.XblUserProfile[] array = new XGamingRuntime.Interop.XblUserProfile[profileCount.ToInt32()];
						num2 = XblInterop.XblProfileGetUserProfilesResult(block, profileCount, array);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Array.ConvertAll(array, (XGamingRuntime.Interop.XblUserProfile x) => new XblUserProfile(x)));
						}
					}
				});
				int num = XblInterop.XblProfileGetUserProfilesAsync(xblContextHandle.InteropHandle, xboxUserIds, new SizeT(xboxUserIds.Length), async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static void XblProfileGetUserProfilesForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroup, XblProfileGetUserProfilesForSocialGroupCompleted completionRoutine)
			{
				if (xblContextHandle == null || socialGroup == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblProfileGetUserProfilesForSocialGroupResultCount(block, out var profileCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						XGamingRuntime.Interop.XblUserProfile[] array = new XGamingRuntime.Interop.XblUserProfile[profileCount.ToInt32()];
						num2 = XblInterop.XblProfileGetUserProfilesForSocialGroupResult(block, profileCount, array);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Array.ConvertAll(array, (XGamingRuntime.Interop.XblUserProfile x) => new XblUserProfile(x)));
						}
					}
				});
				int num = XblInterop.XblProfileGetUserProfilesForSocialGroupAsync(xblContextHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static bool XblSocialManagerPresenceRecordIsUserPlayingTitle(XblSocialManagerPresenceRecord presenceRecord, uint titleId)
			{
				XGamingRuntime.Interop.XblSocialManagerPresenceRecord presenceRecord2 = new XGamingRuntime.Interop.XblSocialManagerPresenceRecord(presenceRecord);
				return XblInterop.XblSocialManagerPresenceRecordIsUserPlayingTitle(ref presenceRecord2, titleId);
			}

			public static int XblSocialManagerUserGroupGetUsers(XblSocialManagerUserGroupHandle group, out XblSocialManagerUser[] xboxSocialUsers)
			{
				xboxSocialUsers = null;
				if (group == null)
				{
					return -2147024809;
				}
				IntPtr xboxSocialUsers2;
				SizeT usersCount;
				int num = XblInterop.XblSocialManagerUserGroupGetUsers(group.InteropHandle, out xboxSocialUsers2, out usersCount);
				if (HR.FAILED(num))
				{
					return num;
				}
				xboxSocialUsers = Converters.PtrToClassArray(xboxSocialUsers2, usersCount, (IntPtr intPtr) => Converters.PtrToClass(intPtr, (XGamingRuntime.Interop.XblSocialManagerUser u) => new XblSocialManagerUser(u)));
				return num;
			}

			public static int XblSocialManagerUserGroupGetUsersTrackedByGroup(XblSocialManagerUserGroupHandle group, out ulong[] trackedUsers)
			{
				trackedUsers = null;
				if (group == null)
				{
					return -2147024809;
				}
				IntPtr trackedUsers2;
				SizeT trackedUsersCount;
				int num = XblInterop.XblSocialManagerUserGroupGetUsersTrackedByGroup(group.InteropHandle, out trackedUsers2, out trackedUsersCount);
				if (!HR.FAILED(num))
				{
					trackedUsers = Converters.PtrToClassArray(trackedUsers2, trackedUsersCount.ToUInt32(), (ulong x) => x);
				}
				return num;
			}

			public static int XblSocialManagerAddLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerAddLocalUser(user.InteropHandle, extraLevelDetail, defaultQueue.handle);
			}

			public static int XblSocialManagerRemoveLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerRemoveLocalUser(user.InteropHandle);
			}

			public static int XblSocialManagerDoWork(out XblSocialManagerEvent[] socialEvents)
			{
				IntPtr socialEvents2;
				SizeT socialEventsCount;
				int num = XblInterop.XblSocialManagerDoWork(out socialEvents2, out socialEventsCount);
				if (HR.FAILED(num))
				{
					socialEvents = null;
					return num;
				}
				if (socialEvents2 == IntPtr.Zero)
				{
					socialEvents = null;
				}
				else
				{
					socialEvents = Converters.PtrToClassArray(socialEvents2, socialEventsCount, (XGamingRuntime.Interop.XblSocialManagerEvent e) => new XblSocialManagerEvent(e));
				}
				return num;
			}

			public static int XblSocialManagerCreateSocialUserGroupFromFilters(XUserHandle user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group)
			{
				if (user == null)
				{
					group = null;
					return -2147024809;
				}
				XGamingRuntime.Interop.XblSocialManagerUserGroupHandle group2;
				return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerCreateSocialUserGroupFromFilters(user.InteropHandle, presenceDetailLevel, filter, out group2), group2, out group);
			}

			public static int XblSocialManagerCreateSocialUserGroupFromList(XUserHandle user, ulong[] xboxUserIdList, out XblSocialManagerUserGroupHandle group)
			{
				if (user == null)
				{
					group = null;
					return -2147024809;
				}
				SizeT xboxUserIdListCount = new SizeT(0);
				if (xboxUserIdList != null && xboxUserIdList.Length != 0)
				{
					xboxUserIdListCount = new SizeT(xboxUserIdList.Length);
				}
				XGamingRuntime.Interop.XblSocialManagerUserGroupHandle group2;
				return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerCreateSocialUserGroupFromList(user.InteropHandle, xboxUserIdList, xboxUserIdListCount, out group2), group2, out group);
			}

			public static int XblSocialManagerDestroySocialUserGroup(XblSocialManagerUserGroupHandle group)
			{
				if (group == null)
				{
					return -2147024809;
				}
				int num = XblInterop.XblSocialManagerDestroySocialUserGroup(group.InteropHandle);
				if (HR.FAILED(num))
				{
					return num;
				}
				group.ClearInteropHandle();
				return num;
			}

			public static int XblSocialManagerGetLocalUsers(out XUserHandle[] users)
			{
				SizeT usersCount = XblInterop.XblSocialManagerGetLocalUserCount();
				XGamingRuntime.Interop.XUserHandle[] array = new XGamingRuntime.Interop.XUserHandle[usersCount.ToInt32()];
				int num = XblInterop.XblSocialManagerGetLocalUsers(usersCount, array);
				if (HR.FAILED(num))
				{
					users = null;
					return num;
				}
				users = Array.ConvertAll(array, (XGamingRuntime.Interop.XUserHandle u) => new XUserHandle(u));
				return num;
			}

			public static int XblSocialManagerUpdateSocialUserGroup(XblSocialManagerUserGroupHandle group, ulong[] users)
			{
				if (group == null)
				{
					return -2147024809;
				}
				SizeT usersCount = new SizeT(0);
				if (users != null && users.Length != 0)
				{
					usersCount = new SizeT(users.Length);
				}
				return XblInterop.XblSocialManagerUpdateSocialUserGroup(group.InteropHandle, users, usersCount);
			}

			public static int XblSocialManagerSetRichPresencePollingStatus(XUserHandle user, bool shouldEnablePolling)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerSetRichPresencePollingStatus(user.InteropHandle, shouldEnablePolling);
			}

			public static int XblSocialManagerUserGroupGetType(XblSocialManagerUserGroupHandle group, out XblSocialUserGroupType type)
			{
				type = XblSocialUserGroupType.FilterType;
				if (group == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerUserGroupGetType(group.InteropHandle, out type);
			}

			public static int XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out XUserHandle localUser)
			{
				localUser = null;
				if (group == null)
				{
					return -2147024809;
				}
				XGamingRuntime.Interop.XUserHandle localUser2;
				return XUserHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerUserGroupGetLocalUser(group.InteropHandle, out localUser2), localUser2, out localUser);
			}

			public static int XblSocialManagerUserGroupGetFilters(XblSocialManagerUserGroupHandle group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter)
			{
				presenceFilter = XblPresenceFilter.Unknown;
				relationshipFilter = XblRelationshipFilter.Unknown;
				if (group == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerUserGroupGetFilters(group.InteropHandle, out presenceFilter, out relationshipFilter);
			}

			public static void XblStringVerifyStringAsync(XblContextHandle xblContextHandle, string stringToVerify, XblStringVerifyStringCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblStringVerifyStringResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblStringVerifyStringResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (XGamingRuntime.Interop.XblVerifyStringResult r) => new XblVerifyStringResult(r)));
						}
					}
				});
				int num = XblInterop.XblStringVerifyStringAsync(xblContextHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(stringToVerify), async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static void XblStringVerifyStringsAsync(XblContextHandle xblContextHandle, string[] stringsToVerify, XblStringVerifyStringsCompleted completionRoutine)
			{
				if (xblContextHandle == null || stringsToVerify == null || stringsToVerify.Length == 0)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblStringVerifyStringsResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblStringVerifyStringsResult(block, resultSizeInBytes, disposableBuffer2.IntPtr, out var ptrToBufferStrings, out var stringsCount, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClassArray(ptrToBufferStrings, stringsCount, (XGamingRuntime.Interop.XblVerifyStringResult r) => new XblVerifyStringResult(r)));
						}
					}
				});
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(stringsToVerify))
				{
					int num = XblInterop.XblStringVerifyStringsAsync(xblContextHandle.InteropHandle, disposableBuffer.IntPtr, Convert.ToUInt64(stringsToVerify.Length), async);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			public static void XblTitleManagedStatsUpdateStatsAsync(XblContextHandle xblContextHandle, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
					completionRoutine(hresult);
				});
				DisposableCollection disposableCollection = new DisposableCollection();
				try
				{
					XGamingRuntime.Interop.XblTitleManagedStatistic[] array = Array.ConvertAll(statistics, (XblTitleManagedStatistic s) => new XGamingRuntime.Interop.XblTitleManagedStatistic(s, disposableCollection));
					int num = XblInterop.XblTitleManagedStatsUpdateStatsAsync(xblContextHandle.InteropHandle, array, new SizeT(array.Length), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num);
					}
				}
				finally
				{
					if (disposableCollection != null)
					{
						((IDisposable)disposableCollection).Dispose();
					}
				}
			}

			public static void XblTitleManagedStatsDeleteStatsAsync(XblContextHandle xblContextHandle, string[] statisticNames, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
					completionRoutine(hresult);
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					SizeT count;
					IntPtr statisticNames2 = Converters.StringArrayToUTF8StringArray(statisticNames, disposableCollection, out count);
					int num = XblInterop.XblTitleManagedStatsDeleteStatsAsync(xblContextHandle.InteropHandle, statisticNames2, count, xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num);
					}
				}
			}

			public static void XblTitleManagedStatsWriteAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
					completionRoutine(hresult);
				});
				DisposableCollection disposableCollection = new DisposableCollection();
				try
				{
					XGamingRuntime.Interop.XblTitleManagedStatistic[] array = Array.ConvertAll(statistics, (XblTitleManagedStatistic s) => new XGamingRuntime.Interop.XblTitleManagedStatistic(s, disposableCollection));
					int num = XblInterop.XblTitleManagedStatsWriteAsync(xblContextHandle.InteropHandle, xboxUserId, array, new SizeT(array.Length), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num);
					}
				}
				finally
				{
					if (disposableCollection != null)
					{
						((IDisposable)disposableCollection).Dispose();
					}
				}
			}

			public static void XblUserStatisticsGetSingleUserStatisticAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string statisticName, XblUserStatisticsGetSingleUserStatisticCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult result = Converters.PtrToClass(ptrToBuffer, (XGamingRuntime.Interop.XblUserStatisticsResult r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, result);
						}
					}
				});
				int num = XblInterop.XblUserStatisticsGetSingleUserStatisticAsync(xblContextHandle.InteropHandle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(statisticName), asyncBlock);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			public static void XblUserStatisticsGetSingleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetSingleUserStatisticsCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticsResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticsResult(block, resultSizeInBytes, disposableBuffer2.IntPtr, out var ptrToBuffer, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult result = Converters.PtrToClass(ptrToBuffer, (XGamingRuntime.Interop.XblUserStatisticsResult r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, result);
						}
					}
				});
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
				{
					int num = XblInterop.XblUserStatisticsGetSingleUserStatisticsAsync(xblContextHandle.InteropHandle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), disposableBuffer.IntPtr, new SizeT(statisticNames.Length), asyncBlock);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			public static void XblUserStatisticsGetMultipleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetMultipleUserStatisticsCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResult(block, resultSizeInBytes, disposableBuffer2.IntPtr, out var ptrToBuffer, out var resultsCount, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult[] results = Converters.PtrToClassArray(ptrToBuffer, resultsCount, (XGamingRuntime.Interop.XblUserStatisticsResult r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, results);
						}
					}
				});
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
				{
					int num = XblInterop.XblUserStatisticsGetMultipleUserStatisticsAsync(xblContextHandle.InteropHandle, xboxUserIds, new SizeT(xboxUserIds.Length), Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), disposableBuffer.IntPtr, new SizeT(statisticNames.Length), asyncBlock);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			public static void XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblRequestedStatistics[] requestedServiceConfigurationStatisticsCollection, XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(block, out var resultSizeInBytes);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
					{
						num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var results, out var resultsCount, out var _);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult[] results2 = Converters.PtrToClassArray(results, resultsCount, (XGamingRuntime.Interop.XblUserStatisticsResult r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, results2);
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					SizeT arrayCount;
					IntPtr requestedServiceConfigurationStatisticsCollection2 = Converters.ClassArrayToPtr(requestedServiceConfigurationStatisticsCollection, (Func<XblRequestedStatistics, DisposableCollection, XGamingRuntime.Interop.XblRequestedStatistics>)((XblRequestedStatistics request, DisposableCollection disposables) => new XGamingRuntime.Interop.XblRequestedStatistics(request, disposables)), disposableCollection, out arrayCount);
					int num = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(xblContextHandle.InteropHandle, xboxUserIds, Convert.ToUInt32(xboxUserIds.Length), requestedServiceConfigurationStatisticsCollection2, arrayCount.ToUInt32(), asyncBlock);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			public static int XblInitialize(string scid)
			{
				return XblInterop.XblWrapper_XblInitialize(Converters.StringToNullTerminatedUTF8ByteArray(scid), defaultQueue.handle);
			}

			public static void XblCleanup(XblCleanupResult completionRoutine)
			{
				XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
				{
					int hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
					completionRoutine(hresult);
				});
				int num = XblInterop.XblCleanupAsync(xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}

			public static int XblContextCreateHandle(XUserHandle user, out XblContextHandle context)
			{
				if (user == null)
				{
					context = null;
					return -2147024809;
				}
				XGamingRuntime.Interop.XblContextHandle context2;
				int num = XblInterop.XblContextCreateHandle(user.InteropHandle, out context2);
				if (HR.SUCCEEDED(num))
				{
					context = new XblContextHandle(context2);
					return num;
				}
				context = null;
				return num;
			}

			public static void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle)
			{
				if (!(xboxLiveContextHandle == null))
				{
					XblInterop.XblContextCloseHandle(xboxLiveContextHandle.InteropHandle);
					xboxLiveContextHandle.InteropHandle = default(XGamingRuntime.Interop.XblContextHandle);
				}
			}
		}

		private static XTaskQueue defaultQueue;

		private static bool isInitialized;

		public static int XClosedCaptionGetProperties(out XClosedCaptionProperties properties)
		{
			XGamingRuntime.Interop.XClosedCaptionProperties properties2;
			int result = XGRInterop.XClosedCaptionGetProperties(out properties2);
			properties = new XClosedCaptionProperties(properties2);
			return result;
		}

		public static int XClosedCaptionSetEnabled(bool enabled)
		{
			return XGRInterop.XClosedCaptionSetEnabled(new NativeBool(enabled));
		}

		public static int XHighContrastGetMode(out XHighContrastMode mode)
		{
			return XGRInterop.XHighContrastGetMode(out mode);
		}

		public static int XSpeechToTextSendString(string speakerName, string content, XSpeechToTextType type)
		{
			return XGRInterop.XSpeechToTextSendString(Converters.StringToNullTerminatedUTF8ByteArray(speakerName), Converters.StringToNullTerminatedUTF8ByteArray(content), type);
		}

		public static int XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position)
		{
			return XGRInterop.XSpeechToTextSetPositionHint(position);
		}

		public static int XSpeechToTextBeginHypothesisString(string speakerName, string content, XSpeechToTextType type, out uint hypothesisId)
		{
			return XGRInterop.XSpeechToTextBeginHypothesisString(Converters.StringToNullTerminatedUTF8ByteArray(speakerName), Converters.StringToNullTerminatedUTF8ByteArray(content), type, out hypothesisId);
		}

		public static int XSpeechToTextUpdateHypothesisString(uint hypothesisId, string content)
		{
			return XGRInterop.XSpeechToTextUpdateHypothesisString(hypothesisId, Converters.StringToNullTerminatedUTF8ByteArray(content));
		}

		public static int XSpeechToTextFinalizeHypothesisString(uint hypothesisId, string content)
		{
			return XGRInterop.XSpeechToTextFinalizeHypothesisString(hypothesisId, Converters.StringToNullTerminatedUTF8ByteArray(content));
		}

		public static int XSpeechToTextCancelHypothesisString(uint hypothesisId)
		{
			return XGRInterop.XSpeechToTextCancelHypothesisString(hypothesisId);
		}

		public static int XAppCaptureTakeScreenshot(XUserHandle requestingUser, out XAppCaptureTakeScreenshotResult result)
		{
			XGamingRuntime.Interop.XAppCaptureTakeScreenshotResult result3;
			int result2 = XGRInterop.XAppCaptureTakeScreenshot(requestingUser.InteropHandle, out result3);
			result = new XAppCaptureTakeScreenshotResult(result3);
			return result2;
		}

		public static int XGameGetXboxTitleId(out uint titleId)
		{
			return XGRInterop.XGameGetXboxTitleId(out titleId);
		}

		[MonoPInvokeCallback]
		private static void XGameInviteEventCallback(IntPtr context, UTF8StringPtr inviteUri)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XGameInviteEventCallback, XGameInviteEventCallback> unmanagedCallback = GCHandle.FromIntPtr(context).Target as UnmanagedCallback<XGamingRuntime.Interop.XGameInviteEventCallback, XGameInviteEventCallback>;
			if (unmanagedCallback.userCallback != null)
			{
				unmanagedCallback.userCallback(inviteUri.GetString());
			}
		}

		public static int XGameInviteRegisterForEvent(XGameInviteEventCallback callback, out XRegistrationToken token)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XGameInviteEventCallback, XGameInviteEventCallback> unmanagedCallback = new UnmanagedCallback<XGamingRuntime.Interop.XGameInviteEventCallback, XGameInviteEventCallback>
			{
				directCallback = XGameInviteEventCallback,
				userCallback = callback
			};
			GCHandle gCHandle = GCHandle.Alloc(unmanagedCallback);
			XTaskQueueRegistrationToken token2;
			int num = XGRInterop.XGameInviteRegisterForEvent(defaultQueue.handle, GCHandle.ToIntPtr(gCHandle), unmanagedCallback.directCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token = new XRegistrationToken(gCHandle, token2);
				return num;
			}
			token = null;
			gCHandle.Free();
			return num;
		}

		public static void XGameInviteUnregisterForEvent(XRegistrationToken token)
		{
			if (token != null)
			{
				XGRInterop.XGameInviteUnregisterForEvent(token.Token, new NativeBool(value: true));
				token.CallbackHandle.Free();
			}
		}

		[MonoPInvokeCallback]
		private static NativeBool GetContainerInfoCallback(XGamingRuntime.Interop.XGameSaveContainerInfo interopInfo, IntPtr context)
		{
			GCHandle gCHandle = GCHandle.FromIntPtr(context);
			gCHandle.Target = new XGameSaveContainerInfo(interopInfo);
			return new NativeBool(value: false);
		}

		[MonoPInvokeCallback]
		private static NativeBool EnumerateContainerInfoCallback(XGamingRuntime.Interop.XGameSaveContainerInfo interopInfo, IntPtr context)
		{
			(GCHandle.FromIntPtr(context).Target as List<XGameSaveContainerInfo>).Add(new XGameSaveContainerInfo(interopInfo));
			return new NativeBool(value: true);
		}

		[MonoPInvokeCallback]
		private static NativeBool EnumerateBlobInfoCallback(XGamingRuntime.Interop.XGameSaveBlobInfo interopBlobInfo, IntPtr context)
		{
			(GCHandle.FromIntPtr(context).Target as List<XGameSaveBlobInfo>).Add(new XGameSaveBlobInfo(interopBlobInfo));
			return new NativeBool(value: true);
		}

		public static int XGameSaveInitializeProvider(XUserHandle userHandle, string configurationId, bool syncOnDemand, out XGameSaveProviderHandle gameSaveProviderHandle)
		{
			gameSaveProviderHandle = null;
			if (userHandle == null)
			{
				return -2147024809;
			}
			XGamingRuntime.Interop.XGameSaveProviderHandle provider;
			return XGameSaveProviderHandle.WrapInteropHandleAndReturnHResult(XGRInterop.XGameSaveInitializeProvider(userHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(configurationId), syncOnDemand, out provider), provider, out gameSaveProviderHandle);
		}

		public static void XGameSaveInitializeProviderAsync(XUserHandle userHandle, string configurationId, bool syncOnDemand, XGameSaveInitializeProviderCompleted completionRoutine)
		{
			if (userHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XGameSaveProviderHandle provider;
				int hresult = XGRInterop.XGameSaveInitializeProviderResult(block, out provider);
				XGameSaveProviderHandle.WrapInteropHandleAndReturnHResult(hresult, provider, out var userHandle2);
				completionRoutine(hresult, userHandle2);
			});
			int num = XGRInterop.XGameSaveInitializeProviderAsync(userHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(configurationId), syncOnDemand, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XGameSaveCloseProvider(XGameSaveProviderHandle gameSaveProviderHandle)
		{
			if (!(gameSaveProviderHandle == null))
			{
				XGRInterop.XGameSaveCloseProvider(gameSaveProviderHandle.InteropHandle);
			}
		}

		public static int XGameSaveGetRemainingQuota(XGameSaveProviderHandle gameSaveProviderHandle, out long remainingQuota)
		{
			if (gameSaveProviderHandle == null)
			{
				remainingQuota = 0L;
				return -2147024809;
			}
			return XGRInterop.XGameSaveGetRemainingQuota(gameSaveProviderHandle.InteropHandle, out remainingQuota);
		}

		public static void XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle gameSaveProviderHandle, XGameSaveGetRemainingQuotaCompleted completionRoutine)
		{
			if (gameSaveProviderHandle == null)
			{
				completionRoutine(-2147024809, 0L);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				long remainingQuota2;
				int hresult = XGRInterop.XGameSaveGetRemainingQuotaResult(block, out remainingQuota2);
				completionRoutine(hresult, remainingQuota2);
			});
			int num = XGRInterop.XGameSaveGetRemainingQuotaAsync(gameSaveProviderHandle.InteropHandle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				long remainingQuota = 0L;
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, remainingQuota);
			}
		}

		public static int XGameSaveDeleteContainer(XGameSaveProviderHandle gameSaveProviderHandle, string containerName)
		{
			if (gameSaveProviderHandle == null || string.IsNullOrEmpty(containerName))
			{
				return -2147024809;
			}
			return XGRInterop.XGameSaveDeleteContainer(gameSaveProviderHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(containerName));
		}

		public static void XGameSaveDeleteContainerAsync(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, XGameSaveDeleteContainerCompleted completionRoutine)
		{
			if (gameSaveProviderHandle == null || string.IsNullOrEmpty(containerName))
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XGameSaveDeleteContainerResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XGameSaveDeleteContainerAsync(gameSaveProviderHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(containerName), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				completionRoutine(num);
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
			}
		}

		public static int XGameSaveCreateContainer(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, out XGameSaveContainerHandle containerContext)
		{
			if (gameSaveProviderHandle == null || string.IsNullOrEmpty(containerName))
			{
				containerContext = null;
				return -2147024809;
			}
			XGamingRuntime.Interop.XGameSaveContainerHandle containerContext2;
			return XGameSaveContainerHandle.WrapInteropHandleAndReturnHResult(XGRInterop.XGameSaveCreateContainer(gameSaveProviderHandle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(containerName), out containerContext2), containerContext2, out containerContext);
		}

		public static void XGameSaveCloseContainer(XGameSaveContainerHandle containerHandle)
		{
			if (!(containerHandle == null))
			{
				XGRInterop.XGameSaveCloseContainer(containerHandle.InteropHandle);
			}
		}

		public static int XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, string containerName, out XGameSaveContainerInfo containerInfo)
		{
			containerInfo = null;
			if (provider == null || string.IsNullOrEmpty(containerName))
			{
				return -2147024809;
			}
			GCHandle value = GCHandle.Alloc(null);
			byte[] containerName2 = Converters.StringToNullTerminatedUTF8ByteArray(containerName);
			int result = XGRInterop.XGameSaveGetContainerInfo(provider.InteropHandle, containerName2, GCHandle.ToIntPtr(value), GetContainerInfoCallback);
			containerInfo = value.Target as XGameSaveContainerInfo;
			value.Free();
			return result;
		}

		public static int XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, out XGameSaveContainerInfo[] containerInfos)
		{
			containerInfos = null;
			if (provider == null)
			{
				return -2147024809;
			}
			List<XGameSaveContainerInfo> list = new List<XGameSaveContainerInfo>();
			GCHandle value = GCHandle.Alloc(list);
			int result = XGRInterop.XGameSaveEnumerateContainerInfo(provider.InteropHandle, GCHandle.ToIntPtr(value), EnumerateContainerInfoCallback);
			containerInfos = list.ToArray();
			value.Free();
			return result;
		}

		public static int XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, string containerNamePrefix, out XGameSaveContainerInfo[] containerInfos)
		{
			containerInfos = null;
			if (provider == null || string.IsNullOrEmpty(containerNamePrefix))
			{
				return -2147024809;
			}
			List<XGameSaveContainerInfo> list = new List<XGameSaveContainerInfo>();
			GCHandle value = GCHandle.Alloc(list);
			byte[] containerNamePrefix2 = Converters.StringToNullTerminatedUTF8ByteArray(containerNamePrefix);
			int result = XGRInterop.XGameSaveEnumerateContainerInfoByName(provider.InteropHandle, containerNamePrefix2, GCHandle.ToIntPtr(value), EnumerateContainerInfoCallback);
			containerInfos = list.ToArray();
			value.Free();
			return result;
		}

		public static int XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, out XGameSaveBlobInfo[] blobInfos)
		{
			blobInfos = null;
			if (container == null)
			{
				return -2147024809;
			}
			List<XGameSaveBlobInfo> list = new List<XGameSaveBlobInfo>();
			GCHandle value = GCHandle.Alloc(list);
			int result = XGRInterop.XGameSaveEnumerateBlobInfo(container.InteropHandle, GCHandle.ToIntPtr(value), EnumerateBlobInfoCallback);
			blobInfos = list.ToArray();
			value.Free();
			return result;
		}

		public static int XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle container, string blobNamePrefix, out XGameSaveBlobInfo[] blobInfos)
		{
			blobInfos = null;
			if (container == null || string.IsNullOrEmpty(blobNamePrefix))
			{
				return -2147024809;
			}
			List<XGameSaveBlobInfo> list = new List<XGameSaveBlobInfo>();
			GCHandle value = GCHandle.Alloc(list);
			byte[] blobNamePrefix2 = Converters.StringToNullTerminatedUTF8ByteArray(blobNamePrefix);
			int result = XGRInterop.XGameSaveEnumerateBlobInfoByName(container.InteropHandle, blobNamePrefix2, GCHandle.ToIntPtr(value), EnumerateBlobInfoCallback);
			blobInfos = list.ToArray();
			value.Free();
			return result;
		}

		public static int XGameSaveReadBlobData(XGameSaveContainerHandle container, XGameSaveBlobInfo[] blobInfos, out XGameSaveBlob[] blobs)
		{
			blobs = null;
			if (container == null || blobInfos == null)
			{
				return -2147024809;
			}
			string[] strings = blobInfos.Select((XGameSaveBlobInfo x) => x.Name).ToArray();
			uint countOfBlobs = Convert.ToUInt32(blobInfos.Length);
			SizeT blobsSize = new SizeT(blobInfos.Sum((XGameSaveBlobInfo x) => Marshal.SizeOf(typeof(XGamingRuntime.Interop.XGameSaveBlob)) + Converters.StringToNullTerminatedUTF8ByteArray(x.Name).Length + Convert.ToInt32(x.Size)));
			using (DisposableBuffer disposableBuffer = new DisposableBuffer(blobsSize.ToInt32()))
			{
				using (DisposableBuffer disposableBuffer2 = Converters.StringArrayToUTF8StringArray(strings))
				{
					int num = XGRInterop.XGameSaveReadBlobData(container.InteropHandle, disposableBuffer2.IntPtr, ref countOfBlobs, blobsSize, disposableBuffer.IntPtr);
					if (HR.SUCCEEDED(num))
					{
						blobs = Converters.PtrToClassArray(disposableBuffer.IntPtr, countOfBlobs, (XGamingRuntime.Interop.XGameSaveBlob x) => new XGameSaveBlob(x));
					}
					return num;
				}
			}
		}

		public static void XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, string[] blobNames, XGameSaveReadBlobDataCompleted completionRoutine)
		{
			if (container == null || blobNames == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num2 = XGRInterop.XAsyncGetStatus(block, wait: false);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					num2 = XGRInterop.XAsyncGetResultSize(block, out var bufferSize);
					if (!HR.FAILED(num2))
					{
						using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(bufferSize.ToInt32()))
						{
							num2 = XGRInterop.XGameSaveReadBlobDataResult(block, bufferSize, disposableBuffer2.IntPtr, out var countOfBlobs);
							XGameSaveBlob[] blobs = null;
							if (HR.SUCCEEDED(num2))
							{
								blobs = Converters.PtrToClassArray(disposableBuffer2.IntPtr, countOfBlobs, (XGamingRuntime.Interop.XGameSaveBlob x) => new XGameSaveBlob(x));
							}
							completionRoutine(num2, blobs);
							return;
						}
					}
					completionRoutine(num2, null);
				}
			});
			using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(blobNames))
			{
				int num = XGRInterop.XGameSaveReadBlobDataAsync(container.InteropHandle, disposableBuffer.IntPtr, Convert.ToUInt32(blobNames.Length), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}
		}

		public static int XGameSaveCreateUpdate(XGameSaveContainerHandle container, string containerDisplayName, out XGameSaveUpdateHandle updateHandle)
		{
			updateHandle = null;
			if (container == null)
			{
				return -2147024809;
			}
			byte[] containerDisplayName2 = Converters.StringToNullTerminatedUTF8ByteArray(containerDisplayName);
			XGamingRuntime.Interop.XGameSaveUpdateHandle updateContext = default(XGamingRuntime.Interop.XGameSaveUpdateHandle);
			return XGameSaveUpdateHandle.WrapInteropHandleAndReturnHResult(XGRInterop.XGameSaveCreateUpdate(container.InteropHandle, containerDisplayName2, ref updateContext), updateContext, out updateHandle);
		}

		public static void XGameSaveCloseUpdateHandle(XGameSaveUpdateHandle updateHandle)
		{
			if (!(updateHandle == null))
			{
				XGRInterop.XGameSaveCloseUpdate(updateHandle.InteropHandle);
			}
		}

		public static int XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateHandle, string blobName, byte[] data)
		{
			if (updateHandle == null || string.IsNullOrEmpty(blobName) || data == null)
			{
				return -2147024809;
			}
			byte[] blobName2 = Converters.StringToNullTerminatedUTF8ByteArray(blobName);
			return XGRInterop.XGameSaveSubmitBlobWrite(byteCount: new SizeT(data.Length), context: updateHandle.InteropHandle, blobName: blobName2, data: data);
		}

		public static int XGameSaveSubmitBlobDelete(XGameSaveUpdateHandle updateHandle, string blobName)
		{
			if (updateHandle == null || string.IsNullOrEmpty(blobName))
			{
				return -2147024809;
			}
			byte[] blobName2 = Converters.StringToNullTerminatedUTF8ByteArray(blobName);
			return XGRInterop.XGameSaveSubmitBlobDelete(updateHandle.InteropHandle, blobName2);
		}

		public static int XGameSaveSubmitUpdate(XGameSaveUpdateHandle updateHandle)
		{
			if (updateHandle == null)
			{
				return -2147024809;
			}
			return XGRInterop.XGameSaveSubmitUpdate(updateHandle.InteropHandle);
		}

		public static void XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateHandle, XGameSaveSubmitUpdateCompleted completionRoutine)
		{
			if (updateHandle == null || completionRoutine == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XGameSaveSubmitUpdateResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XGameSaveSubmitUpdateAsync(updateHandle.InteropHandle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XGameUiShowAchievementsAsync(XUserHandle requestingUser, uint titleId, XGameUiShowAchievementsCompleted completionRoutine)
		{
			if (requestingUser == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XGameUiShowAchievementsResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XGameUiShowAchievementsAsync(xAsyncBlockPtr, requestingUser.InteropHandle, titleId);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XGameUiShowMessageDialogAsync(string titleText, string contentText, string firstButtonText, string secondButtonText, string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton, XGameUiShowMessageDialogCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGameUiMessageDialogButton resultButton;
				int hresult = XGRInterop.XGameUiShowMessageDialogResult(block, out resultButton);
				completionRoutine(hresult, resultButton);
			});
			int num = XGRInterop.XGameUiShowMessageDialogAsync(xAsyncBlockPtr, Converters.StringToNullTerminatedUTF8ByteArray(titleText), Converters.StringToNullTerminatedUTF8ByteArray(contentText), Converters.StringToNullTerminatedUTF8ByteArray(firstButtonText), Converters.StringToNullTerminatedUTF8ByteArray(secondButtonText), Converters.StringToNullTerminatedUTF8ByteArray(thirdButtonText), defaultButton, cancelButton);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, XGameUiMessageDialogButton.First);
			}
		}

		public static void XGameUiShowErrorDialogAsync(int errorCode, string context, XGameUiShowErrorDialogCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XGameUiShowErrorDialogResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XGameUiShowErrorDialogAsync(xAsyncBlockPtr, errorCode, Converters.StringToNullTerminatedUTF8ByteArray(context));
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XGameUiShowTextEntryAsync(string titleText, string descriptionText, string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength, XGameUiShowTextEntryAsyncCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				uint resultTextBufferSize = 0u;
				uint resultTextBufferUsed = 0u;
				int num2 = XGRInterop.XGameUiShowTextEntryResultSize(block, out resultTextBufferSize);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				byte[] array = new byte[resultTextBufferSize];
				num2 = XGRInterop.XGameUiShowTextEntryResult(block, resultTextBufferSize, array, out resultTextBufferUsed);
				string resultText = Encoding.UTF8.GetString(array);
				completionRoutine(num2, resultText);
			});
			int num = XGRInterop.XGameUiShowTextEntryAsync(xAsyncBlockPtr, Converters.StringToNullTerminatedUTF8ByteArray(titleText), Converters.StringToNullTerminatedUTF8ByteArray(descriptionText), Converters.StringToNullTerminatedUTF8ByteArray(defaultText), inputScope, maxTextLength);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static int XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position)
		{
			return XGRInterop.XGameUiSetNotificationPositionHint(position);
		}

		public static void XGameUiShowSendGameInviteAsync(XUserHandle requestingUser, string sessionConfigurationId, string sessionTemplateName, string sessionId, string invitationText, string customActivationContext, XGameUiShowSendGameInviteAsyncCompleted completionRoutine)
		{
			if (requestingUser == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XGameUiShowSendGameInviteResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XGameUiShowSendGameInviteAsync(xAsyncBlockPtr, requestingUser.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(sessionConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(sessionId), Converters.StringToNullTerminatedUTF8ByteArray(invitationText), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XGameUIShowWebAuthenticationAsync(XUserHandle requestingUser, string requestUri, string completionUri, XGameUiShowWebAuthenticationAsyncCompleted completionRoutine)
		{
			if (requestingUser == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num2 = XGRInterop.XGameUiShowWebAuthenticationResultSize(block, out var bufferSize);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
				{
					num2 = XGRInterop.XGameUiShowWebAuthenticationResult(block, bufferSize, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						XGameUiWebAuthenticationResultData result = Converters.PtrToClass(ptrToBuffer, (XGamingRuntime.Interop.XGameUiWebAuthenticationResultData r) => new XGameUiWebAuthenticationResultData(r));
						completionRoutine(num2, result);
					}
				}
			});
			int num = XGRInterop.XGameUiShowWebAuthenticationAsync(xAsyncBlockPtr, requestingUser.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(requestUri), Converters.StringToNullTerminatedUTF8ByteArray(completionUri));
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XGameUiShowPlayerProfileCardAsync(XUserHandle requestingUser, ulong targetPlayer, XGameUiShowPlayerProfileCardAsyncCompleted completionRoutine)
		{
			if (requestingUser == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XGameUiShowPlayerProfileCardResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XGameUiShowPlayerProfileCardAsync(xAsyncBlockPtr, requestingUser.InteropHandle, targetPlayer);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XGameUiShowPlayerPickerAsync(XUserHandle requestingUser, string promptText, ulong[] selectFromPlayers, ulong[] preselectedPlayers, uint minSelectionCount, uint maxSelectionCount, XGameUiShowPlayerPickerAsyncCompleted completionRoutine)
		{
			if (requestingUser == null || selectFromPlayers == null || preselectedPlayers == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num2 = XGRInterop.XGameUiShowPlayerPickerResultCount(block, out var resultPlayersCount);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				ulong[] resultPlayers = new ulong[resultPlayersCount];
				num2 = XGRInterop.XGameUiShowPlayerPickerResult(block, resultPlayersCount, resultPlayers, out var _);
				completionRoutine(num2, resultPlayers);
			});
			int num = XGRInterop.XGameUiShowPlayerPickerAsync(xAsyncBlockPtr, requestingUser.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(promptText), (uint)selectFromPlayers.Length, selectFromPlayers, (uint)preselectedPlayers.Length, preselectedPlayers, minSelectionCount, maxSelectionCount);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static int XLaunchUri(XUserHandle requestingUser, string uri)
		{
			if (requestingUser == null)
			{
				return -2147024809;
			}
			return XGRInterop.XLaunchUri(requestingUser.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(uri));
		}

		[MonoPInvokeCallback]
		private unsafe static NativeBool EnumerationCallback(IntPtr context, XGamingRuntime.Interop.XPackageDetails* packageDetails)
		{
			(GCHandle.FromIntPtr(context).Target as List<XPackageDetails>).Add(new XPackageDetails(*packageDetails));
			return new NativeBool(value: true);
		}

		[MonoPInvokeCallback]
		private unsafe static NativeBool FeatureEnumerationCallback(IntPtr context, XGamingRuntime.Interop.XPackageFeature* feature)
		{
			(GCHandle.FromIntPtr(context).Target as List<XPackageFeature>).Add(new XPackageFeature(*feature));
			return new NativeBool(value: true);
		}

		[MonoPInvokeCallback]
		private unsafe static void PackageInstalledCallback(IntPtr context, XGamingRuntime.Interop.XPackageDetails* packageDetails)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XPackageInstalledCallback, XPackageInstalledCallback> unmanagedCallback = GCHandle.FromIntPtr(context).Target as UnmanagedCallback<XGamingRuntime.Interop.XPackageInstalledCallback, XPackageInstalledCallback>;
			if (unmanagedCallback.userCallback != null)
			{
				unmanagedCallback.userCallback(new XPackageDetails(*packageDetails));
			}
		}

		[MonoPInvokeCallback]
		private static void PackageInstallationProgressCallback(IntPtr context, XGamingRuntime.Interop.XPackageInstallationMonitorHandle monitor)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XPackageInstallationProgressCallback, XPackageInstallationProgressCallback> unmanagedCallback = GCHandle.FromIntPtr(context).Target as UnmanagedCallback<XGamingRuntime.Interop.XPackageInstallationProgressCallback, XPackageInstallationProgressCallback>;
			if (unmanagedCallback.userCallback != null)
			{
				unmanagedCallback.userCallback(new XPackageInstallationMonitorHandle(monitor));
			}
		}

		public static int XPackageGetCurrentProcessPackageIdentifier(out string identifier)
		{
			identifier = null;
			byte[] array = new byte[33];
			int num = XGRInterop.XPackageGetCurrentProcessPackageIdentifier(new SizeT(array.Length), array);
			if (HR.SUCCEEDED(num))
			{
				identifier = Converters.ByteArrayToString(array);
			}
			return num;
		}

		public static bool XPackageIsPackagedProcess()
		{
			return XGRInterop.XPackageIsPackagedProcess().Value;
		}

		public static int XPackageGetUserLocale(out string locale)
		{
			locale = null;
			byte[] array = new byte[85];
			int num = XGRInterop.XPackageGetUserLocale(new SizeT(array.Length), array);
			if (HR.SUCCEEDED(num))
			{
				locale = Converters.ByteArrayToString(array);
			}
			return num;
		}

		public unsafe static int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, out XPackageDetails[] details)
		{
			List<XPackageDetails> list = new List<XPackageDetails>();
			GCHandle value = GCHandle.Alloc(list);
			int result = XGRInterop.XPackageEnumeratePackages(kind, scope, GCHandle.ToIntPtr(value), EnumerationCallback);
			details = list.ToArray();
			value.Free();
			return result;
		}

		public unsafe static int XPackageRegisterPackageInstalled(XPackageInstalledCallback callback, out XRegistrationToken token)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XPackageInstalledCallback, XPackageInstalledCallback> unmanagedCallback = new UnmanagedCallback<XGamingRuntime.Interop.XPackageInstalledCallback, XPackageInstalledCallback>
			{
				directCallback = PackageInstalledCallback,
				userCallback = callback
			};
			GCHandle gCHandle = GCHandle.Alloc(unmanagedCallback);
			XTaskQueueRegistrationToken token2;
			int num = XGRInterop.XPackageRegisterPackageInstalled(defaultQueue.handle, GCHandle.ToIntPtr(gCHandle), unmanagedCallback.directCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token = new XRegistrationToken(gCHandle, token2);
				return num;
			}
			token = null;
			gCHandle.Free();
			return num;
		}

		public static void XPackageUnregisterPackageInstalled(XRegistrationToken token)
		{
			if (token != null)
			{
				XGRInterop.XPackageUnregisterPackageInstalled(token.Token, new NativeBool(value: true));
				token.CallbackHandle.Free();
			}
		}

		public unsafe static int XPackageEnumerateFeatures(string packageIdentifier, out XPackageFeature[] features)
		{
			List<XPackageFeature> list = new List<XPackageFeature>();
			GCHandle value = GCHandle.Alloc(list);
			int result = XGRInterop.XPackageEnumerateFeatures(Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), GCHandle.ToIntPtr(value), FeatureEnumerationCallback);
			features = list.ToArray();
			value.Free();
			return result;
		}

		public static int XPackageMount(string packageIdentifier, out XPackageMountHandle mountHandle)
		{
			mountHandle = null;
			XGamingRuntime.Interop.XPackageMountHandle mount;
			int num = XGRInterop.XPackageMount(Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), out mount);
			if (HR.SUCCEEDED(num))
			{
				mountHandle = new XPackageMountHandle(mount);
			}
			return num;
		}

		public static int XPackageGetMountPath(XPackageMountHandle mountHandle, out string path)
		{
			path = string.Empty;
			if (mountHandle == null)
			{
				return -2147024809;
			}
			int num = XGRInterop.XPackageGetMountPathSize(mountHandle.Handle, out var pathSize);
			if (HR.FAILED(num))
			{
				return num;
			}
			byte[] array = new byte[pathSize.ToInt32()];
			num = XGRInterop.XPackageGetMountPath(mountHandle.Handle, pathSize, array);
			if (HR.SUCCEEDED(num))
			{
				path = Converters.ByteArrayToString(array);
			}
			return num;
		}

		public static void XPackageCloseMountHandle(XPackageMountHandle mountHandle)
		{
			if (mountHandle != null)
			{
				XGRInterop.XPackageCloseMountHandle(mountHandle.Handle);
				mountHandle.Handle = new XGamingRuntime.Interop.XPackageMountHandle
				{
					handle = IntPtr.Zero
				};
			}
		}

		public static int XPackageCreateInstallationMonitor(string packageIdentifier, uint minimumUpdateIntervalMs, out XPackageInstallationMonitorHandle installationMonitor)
		{
			XGamingRuntime.Interop.XPackageInstallationMonitorHandle installationMonitor2;
			return XPackageInstallationMonitorHandle.WrapInteropHandleAndReturnHResult(XGRInterop.XPackageCreateInstallationMonitor(Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), 0u, null, minimumUpdateIntervalMs, defaultQueue.handle, out installationMonitor2), installationMonitor2, out installationMonitor);
		}

		public static void XPackageCloseInstallationMonitorHandle(XPackageInstallationMonitorHandle installationMonitor)
		{
			if (!(installationMonitor == null))
			{
				XGRInterop.XPackageCloseInstallationMonitorHandle(installationMonitor.InteropHandle);
				installationMonitor.InteropHandle = new XGamingRuntime.Interop.XPackageInstallationMonitorHandle
				{
					handle = IntPtr.Zero
				};
			}
		}

		public static void XPackageGetInstallationProgress(XPackageInstallationMonitorHandle installationMonitor, out XPackageInstallationProgress installationProgress)
		{
			if (installationMonitor == null)
			{
				installationProgress = null;
				return;
			}
			XGRInterop.XPackageGetInstallationProgress(installationMonitor.InteropHandle, out var progress);
			installationProgress = new XPackageInstallationProgress(progress);
		}

		public static bool XPackageUpdateInstallationMonitor(XPackageInstallationMonitorHandle installationMonitor)
		{
			if (installationMonitor == null)
			{
				return false;
			}
			return XGRInterop.XPackageUpdateInstallationMonitor(installationMonitor.InteropHandle).Value;
		}

		public static int XPackageRegisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageInstallationProgressCallback callback, out XRegistrationToken token)
		{
			token = null;
			if (installationMonitor == null)
			{
				return -2147024809;
			}
			UnmanagedCallback<XGamingRuntime.Interop.XPackageInstallationProgressCallback, XPackageInstallationProgressCallback> unmanagedCallback = new UnmanagedCallback<XGamingRuntime.Interop.XPackageInstallationProgressCallback, XPackageInstallationProgressCallback>
			{
				directCallback = PackageInstallationProgressCallback,
				userCallback = callback
			};
			GCHandle gCHandle = GCHandle.Alloc(unmanagedCallback);
			XTaskQueueRegistrationToken token2;
			int num = XGRInterop.XPackageRegisterInstallationProgressChanged(installationMonitor.InteropHandle, GCHandle.ToIntPtr(gCHandle), unmanagedCallback.directCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token = new XRegistrationToken(GCHandle.Alloc(gCHandle), token2);
				return num;
			}
			token = null;
			gCHandle.Free();
			return num;
		}

		public static void XPackageUnregisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XRegistrationToken token)
		{
			if (token != null && !(installationMonitor == null))
			{
				XGRInterop.XPackageUnregisterInstallationProgressChanged(installationMonitor.InteropHandle, token.Token, new NativeBool(value: true));
				token.CallbackHandle.Free();
			}
		}

		public static int XPackageEstimateDownloadSize(string packageIdentifier, out ulong downloadSize, out bool shouldPresentUserConfirmation)
		{
			NativeBool shouldPresentUserConfirmation2;
			int result = XGRInterop.XPackageEstimateDownloadSize(Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), 0u, null, out downloadSize, out shouldPresentUserConfirmation2);
			shouldPresentUserConfirmation = shouldPresentUserConfirmation2.Value;
			return result;
		}

		public static int XPackageGetWriteStats(out XPackageWriteStats writeStats)
		{
			XGamingRuntime.Interop.XPackageWriteStats writeStats2;
			int result = XGRInterop.XPackageGetWriteStats(out writeStats2);
			writeStats = new XPackageWriteStats(writeStats2);
			return result;
		}

		public static int XPackageUninstallUWPInstance(string packageName)
		{
			return XGRInterop.XPackageUninstallUWPInstance(Converters.StringToNullTerminatedUTF8ByteArray(packageName));
		}

		public static int XGameRuntimeInitialize()
		{
			int num = XGRInterop.XGameRuntimeInitialize();
			if (HR.SUCCEEDED(num))
			{
				num = XGRInterop.XTaskQueueCreate(XTaskQueueDispatchMode.ThreadPool, XTaskQueueDispatchMode.Manual, out var queue);
				defaultQueue = new XTaskQueue
				{
					handle = queue
				};
			}
			if (HR.SUCCEEDED(num))
			{
				isInitialized = true;
			}
			return num;
		}

		public static void XGameRuntimeUninitialize()
		{
			if (isInitialized)
			{
				XGRInterop.XTaskQueueCloseHandle(defaultQueue.handle);
				XGRInterop.XGameRuntimeUninitialize();
			}
		}

		public static void XTaskQueueDispatch(uint timeoutMs = 0u)
		{
			if (isInitialized)
			{
				XGRInterop.XTaskQueueDispatch(defaultQueue.handle, XTaskQueuePort.Completion, timeoutMs);
			}
		}

		public static int XStoreCreateContext(out XStoreContext storeContext)
		{
			return XStoreCreateContext(null, out storeContext);
		}

		public static int XStoreCreateContext(XUserHandle user, out XStoreContext storeContext)
		{
			storeContext = null;
			XStoreContextHandle storeContextHandle;
			int num = XGRInterop.XStoreCreateContext((user == null) ? default(XGamingRuntime.Interop.XUserHandle) : user.InteropHandle, out storeContextHandle);
			if (HR.SUCCEEDED(num))
			{
				storeContext = new XStoreContext
				{
					handle = storeContextHandle
				};
			}
			return num;
		}

		public static void XStoreCloseContextHandle(XStoreContext context)
		{
			if (!(context == null))
			{
				XGRInterop.XStoreCloseContextHandle(context.handle);
			}
		}

		public static bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability)
		{
			using (DisposableCollection disposableCollection = new DisposableCollection())
			{
				return XGRInterop.XStoreIsAvailabilityPurchasable(new XGamingRuntime.Interop.XStoreAvailability(availability, disposableCollection)).Value;
			}
		}

		[MonoPInvokeCallback]
		private static void LicenseChangedCallback(IntPtr context)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XStoreGameLicenseChangedCallback, XStoreGameLicenseChangedCallback> unmanagedCallback = GCHandle.FromIntPtr(context).Target as UnmanagedCallback<XGamingRuntime.Interop.XStoreGameLicenseChangedCallback, XStoreGameLicenseChangedCallback>;
			if (unmanagedCallback.userCallback != null)
			{
				unmanagedCallback.userCallback();
			}
		}

		[MonoPInvokeCallback]
		private static void LicenseLostCallback(IntPtr context)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XStorePackageLicenseLostCallback, XStorePackageLicenseLostCallback> unmanagedCallback = GCHandle.FromIntPtr(context).Target as UnmanagedCallback<XGamingRuntime.Interop.XStorePackageLicenseLostCallback, XStorePackageLicenseLostCallback>;
			if (unmanagedCallback.userCallback != null)
			{
				unmanagedCallback.userCallback();
			}
		}

		public static void XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreAcquireLicenseForPackageCompleted completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XStoreLicenseHandle storeLicenseHandle;
				int hresult = XGRInterop.XStoreAcquireLicenseForPackageResult(block, out storeLicenseHandle);
				completionRoutine(hresult, new XStoreLicense(storeLicenseHandle));
			});
			int num = XGRInterop.XStoreAcquireLicenseForPackageAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreCanAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreCanAcquireLicenseForPackageCompleted completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XStoreCanAcquireLicenseResult storeCanAcquireLicense;
				int hresult = XGRInterop.XStoreCanAcquireLicenseForPackageResult(block, out storeCanAcquireLicense);
				completionRoutine(hresult, new XStoreCanAcquireLicenseResult(storeCanAcquireLicense));
			});
			int num = XGRInterop.XStoreCanAcquireLicenseForPackageAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext context, string storeProductId, XStoreCanAcquireLicenseForStoreIdCompleted completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XStoreCanAcquireLicenseResult storeCanAcquireLicense;
				int hresult = XGRInterop.XStoreCanAcquireLicenseForStoreIdResult(block, out storeCanAcquireLicense);
				completionRoutine(hresult, new XStoreCanAcquireLicenseResult(storeCanAcquireLicense));
			});
			int num = XGRInterop.XStoreCanAcquireLicenseForStoreIdAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeProductId), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreCloseLicenseHandle(XStoreLicense license)
		{
			if (!(license == null))
			{
				XGRInterop.XStoreCloseLicenseHandle(license.Handle);
				license.Handle = default(XStoreLicenseHandle);
			}
		}

		public static bool XStoreIsLicenseValid(XStoreLicense license)
		{
			if (license == null)
			{
				return false;
			}
			return XGRInterop.XStoreIsLicenseValid(license.Handle).Value;
		}

		public static void XStoreQueryAddOnLicensesAsync(XStoreContext context, XStoreQueryAddOnLicensesCompleted completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num2 = XGRInterop.XStoreQueryAddOnLicensesResultCount(block, out var count);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XGamingRuntime.Interop.XStoreAddonLicense[] array = new XGamingRuntime.Interop.XStoreAddonLicense[count];
					num2 = XGRInterop.XStoreQueryAddOnLicensesResult(block, count, array);
					XStoreAddonLicense[] licenses = null;
					if (HR.SUCCEEDED(num2))
					{
						licenses = Array.ConvertAll(array, (XGamingRuntime.Interop.XStoreAddonLicense x) => new XStoreAddonLicense(x));
					}
					completionRoutine(num2, licenses);
				}
			});
			int num = XGRInterop.XStoreQueryAddOnLicensesAsync(context.handle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryGameLicenseAsync(XStoreContext context, XStoreQueryGameLicenseCompleted completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XStoreGameLicense license;
				int hresult = XGRInterop.XStoreQueryGameLicenseResult(block, out license);
				completionRoutine(hresult, new XStoreGameLicense(license));
			});
			int num = XGRInterop.XStoreQueryGameLicenseAsync(context.handle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryLicenseTokenAsync(XStoreContext context, string[] productIds, string customDeveloperString, XStoreQueryLicenseTokenCompleted completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num2 = XGRInterop.XStoreQueryLicenseTokenResultSize(block, out var size);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				byte[] array2 = new byte[size.ToUInt32()];
				num2 = XGRInterop.XStoreQueryLicenseTokenResult(block, size, array2);
				string token = Converters.ByteArrayToString(array2);
				completionRoutine(num2, token);
			});
			DisposableCollection collection = new DisposableCollection();
			try
			{
				UTF8StringPtr[] array = Array.ConvertAll(productIds, (string x) => new UTF8StringPtr(x, collection));
				int num = XGRInterop.XStoreQueryLicenseTokenAsync(context.handle, array, new SizeT(array.Length), Converters.StringToNullTerminatedUTF8ByteArray(customDeveloperString), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}
			finally
			{
				if (collection != null)
				{
					((IDisposable)collection).Dispose();
				}
			}
		}

		public static int XStoreRegisterGameLicenseChanged(XStoreContext context, XStoreGameLicenseChangedCallback callback, out XRegistrationToken token)
		{
			if (context == null)
			{
				token = null;
				return -2147024809;
			}
			UnmanagedCallback<XGamingRuntime.Interop.XStoreGameLicenseChangedCallback, XStoreGameLicenseChangedCallback> unmanagedCallback = new UnmanagedCallback<XGamingRuntime.Interop.XStoreGameLicenseChangedCallback, XStoreGameLicenseChangedCallback>
			{
				directCallback = LicenseChangedCallback,
				userCallback = callback
			};
			GCHandle gCHandle = GCHandle.Alloc(unmanagedCallback);
			XTaskQueueRegistrationToken token2;
			int num = XGRInterop.XStoreRegisterGameLicenseChanged(context.handle, defaultQueue.handle, GCHandle.ToIntPtr(gCHandle), unmanagedCallback.directCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token = new XRegistrationToken(gCHandle, token2);
				return num;
			}
			token = null;
			gCHandle.Free();
			return num;
		}

		public static int XStoreRegisterPackageLicenseLost(XStoreLicense license, XStorePackageLicenseLostCallback callback, out XRegistrationToken token)
		{
			if (license == null)
			{
				token = null;
				return -2147024809;
			}
			UnmanagedCallback<XGamingRuntime.Interop.XStorePackageLicenseLostCallback, XStorePackageLicenseLostCallback> unmanagedCallback = new UnmanagedCallback<XGamingRuntime.Interop.XStorePackageLicenseLostCallback, XStorePackageLicenseLostCallback>
			{
				directCallback = LicenseLostCallback,
				userCallback = callback
			};
			GCHandle gCHandle = GCHandle.Alloc(unmanagedCallback);
			XTaskQueueRegistrationToken token2;
			int num = XGRInterop.XStoreRegisterPackageLicenseLost(license.Handle, defaultQueue.handle, GCHandle.ToIntPtr(gCHandle), unmanagedCallback.directCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token = new XRegistrationToken(gCHandle, token2);
				return num;
			}
			token = null;
			gCHandle.Free();
			return num;
		}

		public static void XStoreUnregisterGameLicenseChanged(XStoreContext context, XRegistrationToken token)
		{
			if (!(context == null) && token != null)
			{
				XGRInterop.XStoreUnregisterGameLicenseChanged(context.handle, token.Token, new NativeBool(value: true));
				token.CallbackHandle.Free();
			}
		}

		public static void XStoreUnregisterPackageLicenseLost(XStoreLicense license, XRegistrationToken token)
		{
			if (!(license == null) && token != null)
			{
				XGRInterop.XStoreUnregisterPackageLicenseLost(license.Handle, token.Token, new NativeBool(value: true));
				token.CallbackHandle.Free();
			}
		}

		public static void XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XStoreAcquireLicenseForDurablesAsync completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XStoreLicenseHandle storeLicenseHandle;
				int hresult = XGRInterop.XStoreAcquireLicenseForDurablesResult(block, out storeLicenseHandle);
				completionRoutine(hresult, new XStoreLicense(storeLicenseHandle));
			});
			int num = XGRInterop.XStoreAcquireLicenseForDurablesAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeId), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext context, XStoreQueryGameAndDlcPackageUpdatesCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XStorePackageUpdate[] packageUpdates = null;
				uint count;
				int num2 = XGRInterop.XStoreQueryGameAndDlcPackageUpdatesResultCount(block, out count);
				if (num2 == 0 && count != 0)
				{
					XGamingRuntime.Interop.XStorePackageUpdate[] array = new XGamingRuntime.Interop.XStorePackageUpdate[count];
					num2 = XGRInterop.XStoreQueryGameAndDlcPackageUpdatesResult(block, count, array);
					if (num2 == 0)
					{
						packageUpdates = Array.ConvertAll(array, (XGamingRuntime.Interop.XStorePackageUpdate x) => new XStorePackageUpdate(x));
					}
				}
				completionRoutine(num2, packageUpdates);
			});
			int num = XGRInterop.XStoreQueryGameAndDlcPackageUpdatesAsync(context.handle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreDownloadAndInstallPackagesAsync(XStoreContext context, string[] storeIds, XStoreDownloadAndInstallPackagesCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				string[] array2 = null;
				uint count;
				int num2 = XGRInterop.XStoreDownloadAndInstallPackagesResultCount(block, out count);
				if (num2 == 0)
				{
					array2 = new string[count];
					if (count != 0)
					{
						byte[] array3 = new byte[count * 33];
						num2 = XGRInterop.XStoreDownloadAndInstallPackagesResult(block, count, array3);
						for (int i = 0; i < count; i++)
						{
							array2[i] = Converters.ByteArrayToString(array3, i * 33, 33);
						}
					}
				}
				completionRoutine(num2, array2);
			});
			DisposableCollection collection = new DisposableCollection();
			try
			{
				UTF8StringPtr[] array = Array.ConvertAll(storeIds, (string x) => new UTF8StringPtr(x, collection));
				int num = XGRInterop.XStoreDownloadAndInstallPackagesAsync(context.handle, array, new SizeT(array.Length), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num, null);
				}
			}
			finally
			{
				if (collection != null)
				{
					((IDisposable)collection).Dispose();
				}
			}
		}

		public static void XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext context, string[] packageIdentifiers, XStoreDownloadAndInstallPackageUpdatesCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XStoreDownloadPackageUpdatesResult(block);
				completionRoutine(hresult);
			});
			DisposableCollection collection = new DisposableCollection();
			try
			{
				UTF8StringPtr[] array = Array.ConvertAll(packageIdentifiers, (string x) => new UTF8StringPtr(x, collection));
				int num = XGRInterop.XStoreDownloadAndInstallPackageUpdatesAsync(context.handle, array, new SizeT(array.Length), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}
			finally
			{
				if (collection != null)
				{
					((IDisposable)collection).Dispose();
				}
			}
		}

		public static void XStoreDownloadPackageUpdatesAsync(XStoreContext context, string[] packageIdentifiers, XStoreDownloadPackageUpdatesCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XStoreDownloadPackageUpdatesResult(block);
				completionRoutine(hresult);
			});
			DisposableCollection collection = new DisposableCollection();
			try
			{
				UTF8StringPtr[] array = Array.ConvertAll(packageIdentifiers, (string x) => new UTF8StringPtr(x, collection));
				int num = XGRInterop.XStoreDownloadPackageUpdatesAsync(context.handle, array, new SizeT(array.Length), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}
			finally
			{
				if (collection != null)
				{
					((IDisposable)collection).Dispose();
				}
			}
		}

		public static int XStoreQueryPackageIdentifier(string storeId, out string packageIdentifier)
		{
			packageIdentifier = null;
			byte[] array = new byte[33];
			int num = XGRInterop.XStoreQueryPackageIdentifier(Converters.StringToNullTerminatedUTF8ByteArray(storeId), new SizeT(array.Length), array);
			if (HR.SUCCEEDED(num))
			{
				packageIdentifier = Converters.ByteArrayToString(array);
			}
			return num;
		}

		public static void XStoreShowRedeemTokenUIAsync(XStoreContext context, string token, string[] allowedStoreIds, bool disallowCsvRedeption, XStoreShowRedeemTokenUICompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XStoreShowRedeemTokenUIResult(block);
				completionRoutine(hresult);
			});
			DisposableCollection collection = new DisposableCollection();
			try
			{
				UTF8StringPtr[] array = Array.ConvertAll(allowedStoreIds, (string x) => new UTF8StringPtr(x, collection));
				int num = XGRInterop.XStoreShowRedeemTokenUIAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(token), array, new SizeT(array.Length), new NativeBool(disallowCsvRedeption), xAsyncBlockPtr);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
					completionRoutine(num);
				}
			}
			finally
			{
				if (collection != null)
				{
					((IDisposable)collection).Dispose();
				}
			}
		}

		public static void XStoreShowRateAndReviewUIAsync(XStoreContext context, XStoreShowRateAndReviewUICompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XStoreRateAndReviewResult result;
				int hresult = XGRInterop.XStoreShowRateAndReviewUIResult(block, out result);
				completionRoutine(hresult, result.wasUpdated.Value);
			});
			int num = XGRInterop.XStoreShowRateAndReviewUIAsync(context.handle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, wasUpdated: false);
			}
		}

		public static void XStoreShowPurchaseUIAsync(XStoreContext context, string storeId, string name, string extendedJsonData, XStoreShowPurchaseUICompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XStoreShowPurchaseUIResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XStoreShowPurchaseUIAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeId), Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(extendedJsonData), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XStoreQueryConsumableBalanceRemainingAsync(XStoreContext context, string storeProductId, XStoreQueryConsumableBalanceRemainingCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XStoreConsumableResult consumableResult;
				int hresult = XGRInterop.XStoreQueryConsumableBalanceRemainingResult(block, out consumableResult);
				completionRoutine(hresult, consumableResult.quantity);
			});
			int num = XGRInterop.XStoreQueryConsumableBalanceRemainingAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeProductId), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, 0u);
			}
		}

		public static void XStoreReportConsumableFulfillmentAsync(XStoreContext context, string storeProductId, uint quantity, Guid trackingId, XStoreReportConsumableFulfillmentCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XStoreConsumableResult consumableResult;
				int hresult = XGRInterop.XStoreReportConsumableFulfillmentResult(block, out consumableResult);
				completionRoutine(hresult, consumableResult.quantity);
			});
			int num = XGRInterop.XStoreReportConsumableFulfillmentAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(storeProductId), quantity, trackingId, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, 0u);
			}
		}

		public static void XStoreGetUserCollectionsIdAsync(XStoreContext context, string serviceTicket, string publisherUserId, XStoreGetUserCollectionsIdCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				string token = null;
				SizeT size;
				int num2 = XGRInterop.XStoreGetUserCollectionsIdResultSize(block, out size);
				if (num2 == 0)
				{
					byte[] array = new byte[size.ToUInt32()];
					num2 = XGRInterop.XStoreGetUserCollectionsIdResult(block, size, array);
					token = Converters.ByteArrayToString(array);
				}
				completionRoutine(num2, token);
			});
			int num = XGRInterop.XStoreGetUserCollectionsIdAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceTicket), Converters.StringToNullTerminatedUTF8ByteArray(publisherUserId), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreGetUserPurchaseIdAsync(XStoreContext context, string serviceTicket, string publisherUserId, XStoreGetUserPurchaseIdCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				string token = null;
				SizeT size;
				int num2 = XGRInterop.XStoreGetUserPurchaseIdResultSize(block, out size);
				if (num2 == 0)
				{
					byte[] array = new byte[size.ToUInt32()];
					num2 = XGRInterop.XStoreGetUserPurchaseIdResult(block, size, array);
					token = Converters.ByteArrayToString(array);
				}
				completionRoutine(num2, token);
			});
			int num = XGRInterop.XStoreGetUserPurchaseIdAsync(context.handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceTicket), Converters.StringToNullTerminatedUTF8ByteArray(publisherUserId), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		[MonoPInvokeCallback]
		private static NativeBool ProductQueryCallback(IntPtr product, IntPtr context)
		{
			XGamingRuntime.Interop.XStoreProduct interopStruct = (XGamingRuntime.Interop.XStoreProduct)Marshal.PtrToStructure(product, typeof(XGamingRuntime.Interop.XStoreProduct));
			(GCHandle.FromIntPtr(context).Target as List<XStoreProduct>).Add(new XStoreProduct(interopStruct));
			return new NativeBool(value: true);
		}

		private static int RetrieveQueryProducts(XStoreProductQueryHandle queryPage, out XStoreProduct[] result)
		{
			List<XStoreProduct> list = new List<XStoreProduct>();
			GCHandle value = GCHandle.Alloc(list);
			int result2 = XGRInterop.XStoreEnumerateProductsQuery(queryPage, GCHandle.ToIntPtr(value), ProductQueryCallback);
			result = list.ToArray();
			value.Free();
			return result2;
		}

		private static void ExtractQueryResultAndComplete(XStoreQueryComplete completionRoutine, XAsyncBlockPtr block, QueryExtractionFunction extractionFunction)
		{
			XStoreQueryResult result = null;
			XStoreProductQueryHandle queryHandle;
			int num = extractionFunction(block, out queryHandle);
			if (HR.SUCCEEDED(num))
			{
				bool value = XGRInterop.XStoreProductsQueryHasMorePages(queryHandle).Value;
				XStoreProduct[] result2 = null;
				num = RetrieveQueryProducts(queryHandle, out result2);
				result = new XStoreQueryResult(queryHandle, result2, value);
			}
			completionRoutine(num, result);
		}

		public static void XStoreQueryAssociatedProductsAsync(XStoreContext context, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				ExtractQueryResultAndComplete(completionRoutine, block, XGRInterop.XStoreQueryAssociatedProductsResult);
			});
			int num = XGRInterop.XStoreQueryAssociatedProductsAsync(context.handle, productKinds, maxItemsToRetrievePerPage, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryEntitledProductsAsync(XStoreContext context, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				ExtractQueryResultAndComplete(completionRoutine, block, XGRInterop.XStoreQueryEntitledProductsResult);
			});
			int num = XGRInterop.XStoreQueryEntitledProductsAsync(context.handle, productKinds, maxItemsToRetrievePerPage, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryProductForCurrentGameAsync(XStoreContext context, XStoreQueryComplete completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				ExtractQueryResultAndComplete(completionRoutine, block, XGRInterop.XStoreQueryProductForCurrentGameResult);
			});
			int num = XGRInterop.XStoreQueryProductForCurrentGameAsync(context.handle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryProductForPackageAsync(XStoreContext context, XStoreProductKind productKinds, string packageIdentifier, XStoreQueryComplete completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				ExtractQueryResultAndComplete(completionRoutine, block, XGRInterop.XStoreQueryProductForPackageResult);
			});
			int num = XGRInterop.XStoreQueryProductForPackageAsync(context.handle, productKinds, Converters.StringToNullTerminatedUTF8ByteArray(packageIdentifier), xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreQueryProductsAsync(XStoreContext context, XStoreProductKind productKinds, string[] storeIds, string[] actionFilters, XStoreQueryComplete completionRoutine)
		{
			if (context == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				ExtractQueryResultAndComplete(completionRoutine, block, XGRInterop.XStoreQueryProductsResult);
			});
			DisposableCollection storeIdsCollection = new DisposableCollection();
			try
			{
				DisposableCollection actionFiltersCollection = new DisposableCollection();
				try
				{
					UTF8StringPtr[] array = Array.ConvertAll(storeIds, (string x) => new UTF8StringPtr(x, storeIdsCollection));
					UTF8StringPtr[] array2 = Array.ConvertAll(actionFilters, (string x) => new UTF8StringPtr(x, actionFiltersCollection));
					int num = XGRInterop.XStoreQueryProductsAsync(context.handle, productKinds, array, new SizeT(array.Length), array2, new SizeT(array2.Length), xAsyncBlockPtr);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
						completionRoutine(num, null);
					}
				}
				finally
				{
					if (actionFiltersCollection != null)
					{
						((IDisposable)actionFiltersCollection).Dispose();
					}
				}
			}
			finally
			{
				if (storeIdsCollection != null)
				{
					((IDisposable)storeIdsCollection).Dispose();
				}
			}
		}

		public static void XStoreProductsQueryNextPageAsync(XStoreQueryResult currentPage, XStoreQueryComplete completionRoutine)
		{
			if (currentPage == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				ExtractQueryResultAndComplete(completionRoutine, block, XGRInterop.XStoreProductsQueryNextPageResult);
			});
			int num = XGRInterop.XStoreProductsQueryNextPageAsync(currentPage.QueryHandle, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static void XStoreCloseProductsQueryHandle(XStoreQueryResult result)
		{
			XGRInterop.XStoreCloseProductsQueryHandle(result.QueryHandle);
		}

		public static bool XThreadIsTimeSensitive()
		{
			return XGRInterop.XThreadIsTimeSensitive().Value;
		}

		public static int XThreadSetTimeSensitive(bool isTimeSensitiveThread)
		{
			return XGRInterop.XThreadSetTimeSensitive(new NativeBool(isTimeSensitiveThread));
		}

		public static void XThreadAssertNotTimeSensitive()
		{
			XGRInterop.XThreadAssertNotTimeSensitive();
		}

		[MonoPInvokeCallback]
		private static void UserChangeEventCallback(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent eventType)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XUserChangeEventCallback, XUserChangeEventCallback> unmanagedCallback = GCHandle.FromIntPtr(context).Target as UnmanagedCallback<XGamingRuntime.Interop.XUserChangeEventCallback, XUserChangeEventCallback>;
			if (unmanagedCallback.userCallback != null)
			{
				unmanagedCallback.userCallback(userLocalId, eventType);
			}
		}

		public static int XUserDuplicateHandle(XUserHandle handle, out XUserHandle duplicatedHandle)
		{
			if (handle == null)
			{
				duplicatedHandle = null;
				return -2147024809;
			}
			XGamingRuntime.Interop.XUserHandle duplicatedHandle2;
			return XUserHandle.WrapAndReturnHResult(XGRInterop.XUserDuplicateHandle(handle.InteropHandle, out duplicatedHandle2), duplicatedHandle2, out duplicatedHandle);
		}

		public static void XUserCloseHandle(XUserHandle user)
		{
			if (!(user == null))
			{
				XGRInterop.XUserCloseHandle(user.InteropHandle);
				user.ClearInteropHandle();
			}
		}

		public static int XUserCompare(XUserHandle user1, XUserHandle user2, out int comparisonResult)
		{
			if (user1 == null || user2 == null)
			{
				comparisonResult = 0;
				return -2147024809;
			}
			comparisonResult = XGRInterop.XUserCompare(user1.InteropHandle, user2.InteropHandle);
			return 0;
		}

		public static int XUserGetMaxUsers(out uint maxUsers)
		{
			return XGRInterop.XUserGetMaxUsers(out maxUsers);
		}

		public static void XUserAddAsync(XUserAddOptions options, XUserAddCompleted completionRoutine)
		{
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				XGamingRuntime.Interop.XUserHandle newUser;
				int hresult = XGRInterop.XUserAddResult(block, out newUser);
				XUserHandle.WrapAndReturnHResult(hresult, newUser, out var handle);
				completionRoutine(hresult, handle);
			});
			int num = XGRInterop.XUserAddAsync(options, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static int XUserGetId(XUserHandle user, out ulong userId)
		{
			if (user == null)
			{
				userId = 0uL;
				return -2147024809;
			}
			return XGRInterop.XUserGetId(user.InteropHandle, out userId);
		}

		public static int XUserFindUserById(ulong userId, out XUserHandle handle)
		{
			XGamingRuntime.Interop.XUserHandle handle2;
			int num = XGRInterop.XUserFindUserById(userId, out handle2);
			if (num == 0 && handle2.Ptr == IntPtr.Zero)
			{
				handle = null;
				return num;
			}
			return XUserHandle.WrapAndReturnHResult(num, handle2, out handle);
		}

		public static int XUserGetLocalId(XUserHandle user, out XUserLocalId userLocalId)
		{
			if (user == null)
			{
				userLocalId = default(XUserLocalId);
				return -2147024809;
			}
			return XGRInterop.XUserGetLocalId(user.InteropHandle, out userLocalId);
		}

		public static int XUserFindUserByLocalId(XUserLocalId userLocalId, out XUserHandle handle)
		{
			XGamingRuntime.Interop.XUserHandle handle2;
			int num = XGRInterop.XUserFindUserByLocalId(userLocalId, out handle2);
			if (num == 0 && handle2.Ptr == IntPtr.Zero)
			{
				handle = null;
				return num;
			}
			return XUserHandle.WrapAndReturnHResult(num, handle2, out handle);
		}

		public static int XUserGetIsGuest(XUserHandle user, out bool isGuest)
		{
			if (user == null)
			{
				isGuest = false;
				return -2147024809;
			}
			return XGRInterop.XUserGetIsGuest(user.InteropHandle, out isGuest);
		}

		public static int XUserGetState(XUserHandle user, out XUserState state)
		{
			if (user == null)
			{
				state = XUserState.SignedIn;
				return -2147024809;
			}
			return XGRInterop.XUserGetState(user.InteropHandle, out state);
		}

		public static int XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, out string gamertag)
		{
			if (user == null)
			{
				gamertag = null;
				return -2147024809;
			}
			int num = 0;
			switch (gamertagComponent)
			{
			case XUserGamertagComponent.Classic:
				num = 16;
				break;
			case XUserGamertagComponent.Modern:
				num = 97;
				break;
			case XUserGamertagComponent.ModernSuffix:
				num = 15;
				break;
			case XUserGamertagComponent.UniqueModern:
				num = 101;
				break;
			}
			byte[] array = new byte[num];
			SizeT gamertagUsed;
			int num2 = XGRInterop.XUserGetGamertag(user.InteropHandle, gamertagComponent, new SizeT(array.Length), array, out gamertagUsed);
			if (HR.SUCCEEDED(num2))
			{
				gamertag = Converters.ByteArrayToString(array, 0, gamertagUsed.ToInt32());
				return num2;
			}
			gamertag = null;
			return num2;
		}

		public static void XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XUserGetGamerPictureCompleted completionRoutine)
		{
			if (user == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num2 = XGRInterop.XUserGetGamerPictureResultSize(block, out var bufferSize);
				if (HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					byte[] array = new byte[bufferSize.ToUInt32()];
					num2 = XGRInterop.XUserGetGamerPictureResult(block, new SizeT(array.Length), array, out var _);
					completionRoutine(num2, array);
				}
			});
			int num = XGRInterop.XUserGetGamerPictureAsync(user.InteropHandle, pictureSize, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num, null);
			}
		}

		public static int XUserGetAgeGroup(XUserHandle user, out XUserAgeGroup ageGroup)
		{
			if (user == null)
			{
				ageGroup = XUserAgeGroup.Unknown;
				return -2147024809;
			}
			return XGRInterop.XUserGetAgeGroup(user.InteropHandle, out ageGroup);
		}

		public static int XUserCheckPrivilege(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, out bool hasPrivilege, out XUserPrivilegeDenyReason reason)
		{
			if (user == null)
			{
				hasPrivilege = false;
				reason = XUserPrivilegeDenyReason.None;
				return -2147024809;
			}
			return XGRInterop.XUserCheckPrivilege(user.InteropHandle, options, privilege, out hasPrivilege, out reason);
		}

		public static void XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XUserResolvePrivilegeWithUiCompleted completionRoutine)
		{
			if (user == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XUserResolvePrivilegeWithUiResult(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XUserResolvePrivilegeWithUiAsync(user.InteropHandle, options, privilege, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static void XUserGetTokenAndSignatureUtf16Async(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureUtf16HttpHeader[] headers, byte[] body, XUserGetTokenAndSignatureUtf16Result completionRoutine)
		{
			if (user == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int num4 = XGRInterop.XUserGetTokenAndSignatureUtf16ResultSize(block, out var bufferSize);
				if (HR.FAILED(num4))
				{
					completionRoutine(num4, null);
				}
				else
				{
					IntPtr intPtr = Marshal.AllocHGlobal(bufferSize.ToInt32());
					num4 = XGRInterop.XUserGetTokenAndSignatureUtf16Result(block, bufferSize, intPtr, out var ptrToBuffer, out var _);
					XUserGetTokenAndSignatureUtf16Data tokenAndSignature;
					if (HR.SUCCEEDED(num4))
					{
						XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data xUserGetTokenAndSignatureUtf16Data = (XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data)Marshal.PtrToStructure(ptrToBuffer, typeof(XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data));
						tokenAndSignature = new XUserGetTokenAndSignatureUtf16Data(xUserGetTokenAndSignatureUtf16Data.Token, xUserGetTokenAndSignatureUtf16Data.Signature);
					}
					else
					{
						tokenAndSignature = null;
					}
					Marshal.FreeHGlobal(intPtr);
					completionRoutine(num4, tokenAndSignature);
				}
			});
			int num = ((headers != null) ? headers.Length : 0);
			XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader[] array = null;
			if (num > 0)
			{
				array = new XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader[num];
				for (int num2 = 0; num2 < num; num2++)
				{
					array[num2] = new XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader
					{
						Name = headers[num2].Name,
						Value = headers[num2].Value
					};
				}
			}
			SizeT bodySize = new SizeT((body != null) ? body.Length : 0);
			int num3 = XGRInterop.XUserGetTokenAndSignatureUtf16Async(user.InteropHandle, options, method, url, new SizeT(num), array, bodySize, body, xAsyncBlockPtr);
			if (HR.FAILED(num3))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num3, null);
			}
		}

		public static void XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XUserResolveIssueWithUiUtf16Result completionRoutine)
		{
			if (user == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlockPtr xAsyncBlockPtr = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, delegate(XAsyncBlockPtr block)
			{
				int hresult = XGRInterop.XUserResolveIssueWithUiUtf16Result(block);
				completionRoutine(hresult);
			});
			int num = XGRInterop.XUserResolveIssueWithUiUtf16Async(user.InteropHandle, url, xAsyncBlockPtr);
			if (HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlockPtr);
				completionRoutine(num);
			}
		}

		public static int XUserRegisterForChangeEvent(XUserChangeEventCallback callback, out XRegistrationToken registrationToken)
		{
			UnmanagedCallback<XGamingRuntime.Interop.XUserChangeEventCallback, XUserChangeEventCallback> unmanagedCallback = new UnmanagedCallback<XGamingRuntime.Interop.XUserChangeEventCallback, XUserChangeEventCallback>
			{
				directCallback = UserChangeEventCallback,
				userCallback = callback
			};
			GCHandle gCHandle = GCHandle.Alloc(unmanagedCallback);
			XTaskQueueRegistrationToken token;
			int num = XGRInterop.XUserRegisterForChangeEvent(defaultQueue.handle, GCHandle.ToIntPtr(gCHandle), unmanagedCallback.directCallback, out token);
			if (HR.SUCCEEDED(num))
			{
				registrationToken = new XRegistrationToken(gCHandle, token);
				return num;
			}
			registrationToken = null;
			gCHandle.Free();
			return num;
		}

		public static void XUserUnregisterForChangeEvent(XRegistrationToken registrationToken)
		{
			if (registrationToken != null)
			{
				XGRInterop.XUserUnregisterForChangeEvent(registrationToken.Token, wait: true);
				registrationToken.CallbackHandle.Free();
			}
		}

		public static int XUserGetSignOutDeferral(out XUserSignOutDeferralHandle deferral)
		{
			XGamingRuntime.Interop.XUserSignOutDeferralHandle deferral2;
			int num = XGRInterop.XUserGetSignOutDeferral(out deferral2);
			if (HR.SUCCEEDED(num))
			{
				deferral = new XUserSignOutDeferralHandle(deferral2);
				return num;
			}
			deferral = null;
			return num;
		}

		public static int XUserCloseSignOutDeferralHandle(XUserSignOutDeferralHandle deferral)
		{
			if (deferral == null)
			{
				return -2147024809;
			}
			XGRInterop.XUserCloseSignOutDeferralHandle(deferral.InteropHandle);
			return 0;
		}
	}
}
