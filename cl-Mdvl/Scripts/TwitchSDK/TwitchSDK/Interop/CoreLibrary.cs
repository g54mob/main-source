using System;

namespace TwitchSDK.Interop
{
	public class CoreLibrary : BaseDisposable
	{
		private IntPtr Native;

		private PlatformAbstractionLayer PAL;

		public GameTask<AuthState> GetAuthState()
		{
			return Types.InvokeMarshallable<AuthState>(NativeApi.R66Api_GetAuthState, Native);
		}

		public GameTask<AuthenticationInfo> GetAuthenticationInfo(string scopes)
		{
			return Types.InvokeMarshallable<PlainString, AuthenticationInfo>(NativeApi.R66Api_GetAuthenticationInfo, Native, new PlainString
			{
				Data = scopes
			});
		}

		public GameTask LogOut()
		{
			return Types.InvokeMarshallable<None>(NativeApi.R66Api_LogOut, Native);
		}

		public GameTask<UserInfo> GetMyUserInfo()
		{
			return Types.InvokeMarshallable<UserInfo>(NativeApi.R66Api_GetMyUserInfo, Native);
		}

		public GameTask<UserInfo> GetUserInfoById(string id)
		{
			return Types.InvokeMarshallable<PlainString, UserInfo>(NativeApi.R66Api_GetUserInfoById, Native, new PlainString
			{
				Data = id
			});
		}

		public GameTask<UserInfo> GetUserInfoByLoginName(string login)
		{
			return Types.InvokeMarshallable<PlainString, UserInfo>(NativeApi.R66Api_GetUserInfoByLoginName, Native, new PlainString
			{
				Data = login
			});
		}

		public GameTask<StreamInfo> GetMyStreamInfo()
		{
			return Types.InvokeMarshallable<StreamInfo>(NativeApi.R66Api_GetMyStreamInfo, Native);
		}

		public GameTask<StreamQueryResult> QueryStreams(StreamQuery query)
		{
			return Types.InvokeMarshallable<StreamQuery, StreamQueryResult>(NativeApi.R66Api_QueryStreams, Native, query);
		}

		public GameTask<UserSubscriptionCheckResult> CheckUserSubscription(string broadcaster)
		{
			return Types.InvokeMarshallable<PlainString, UserSubscriptionCheckResult>(NativeApi.R66Api_CheckUserSubscription, Native, new PlainString
			{
				Data = broadcaster
			});
		}

		public GameTask<ClipInfo> CreateClip(bool hasDelay)
		{
			return Types.InvokeMarshallable<PlainBool, ClipInfo>(NativeApi.R66Api_CreateClip, Native, new PlainBool
			{
				Data = hasDelay
			});
		}

		public GameTask<StreamMarkerInfo> CreateStreamMarker(string description)
		{
			return Types.InvokeMarshallable<PlainString, StreamMarkerInfo>(NativeApi.R66Api_CreateStreamMarker, Native, new PlainString
			{
				Data = description
			});
		}

		public GameTask<PollInfo> CreatePoll(PollDefinition p)
		{
			return Types.InvokeMarshallable<PollDefinition, PollInfo>(NativeApi.R66Api_CreatePoll, Native, p);
		}

		public GameTask<PollInfo> WaitForPollUpdate(string poll)
		{
			return Types.InvokeMarshallable<PlainString, PollInfo>(NativeApi.R66Api_WaitForPollUpdate, Native, new PlainString
			{
				Data = poll
			});
		}

		public GameTask<PollInfo> EndPoll(EndPollRequest req)
		{
			return Types.InvokeMarshallable<EndPollRequest, PollInfo>(NativeApi.R66Api_EndPoll, Native, req);
		}

		public GameTask UnsubscribeFromPoll(string id)
		{
			return Types.InvokeMarshallable<PlainString, None>(NativeApi.R66Api_UnsubscribeFromPoll, Native, new PlainString
			{
				Data = id
			});
		}

		public GameTask<PredictionInfo> CreatePrediction(PredictionDefinition p)
		{
			return Types.InvokeMarshallable<PredictionDefinition, PredictionInfo>(NativeApi.R66Api_CreatePrediction, Native, p);
		}

		public GameTask<PredictionInfo> WaitForPredictionUpdate(string prediction)
		{
			return Types.InvokeMarshallable<PlainString, PredictionInfo>(NativeApi.R66Api_WaitForPredictionUpdate, Native, new PlainString
			{
				Data = prediction
			});
		}

		public GameTask<PredictionInfo> EndPrediction(EndPredictionRequest req)
		{
			return Types.InvokeMarshallable<EndPredictionRequest, PredictionInfo>(NativeApi.R66Api_EndPrediction, Native, req);
		}

		public GameTask UnsubscribeFromPrediction(string id)
		{
			return Types.InvokeMarshallable<PlainString, None>(NativeApi.R66Api_UnsubscribeFromPrediction, Native, new PlainString
			{
				Data = id
			});
		}

		public GameTask ModifyChannelInformation(ModifyChannelInfoRequest req)
		{
			return Types.InvokeMarshallable<ModifyChannelInfoRequest, None>(NativeApi.R66Api_ModifyChannelInformation, Native, req);
		}

		public GameTask<BitsLeaderboard> GetBitsLeaderboard(BitsLeaderboardRequest req)
		{
			return Types.InvokeMarshallable<BitsLeaderboardRequest, BitsLeaderboard>(NativeApi.R66Api_GetBitsLeaderboard, Native, req);
		}

		public GameTask ReplaceCustomRewards(CustomRewardList req)
		{
			return Types.InvokeMarshallable<CustomRewardList, None>(NativeApi.R66Api_ReplaceCustomRewards, Native, req);
		}

		public GameTask ResolveCustomReward(CustomRewardResolveRequest req)
		{
			return Types.InvokeMarshallable<CustomRewardResolveRequest, None>(NativeApi.R66Api_ResolveCustomReward, Native, req);
		}

		public GameTask<EventStreamDesc> SubscribeToEventStream(EventStreamRequest req)
		{
			return Types.InvokeMarshallable<EventStreamRequest, EventStreamDesc>(NativeApi.R66Api_SubscribeToEventStream, Native, req);
		}

		public GameTask<ChannelSubscribeEvent> WaitForChannelSubscribeEvent(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, ChannelSubscribeEvent>(NativeApi.R66Api_WaitForChannelSubscribeEvent, Native, desc);
		}

		public GameTask<ChannelFollowEvent> WaitForChannelFollowEvent(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, ChannelFollowEvent>(NativeApi.R66Api_WaitForChannelFollowEvent, Native, desc);
		}

		public GameTask<ChannelCheerEvent> WaitForChannelCheerEvent(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, ChannelCheerEvent>(NativeApi.R66Api_WaitForChannelCheerEvent, Native, desc);
		}

		public GameTask<CustomRewardEvent> WaitForCustomRewardEvent(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, CustomRewardEvent>(NativeApi.R66Api_WaitForCustomRewardEvent, Native, desc);
		}

		public GameTask<HypeTrainEvent> WaitForHypeTrainEvent(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, HypeTrainEvent>(NativeApi.R66Api_WaitForHypeTrainEvent, Native, desc);
		}

		public GameTask<ChannelRaidEvent> WaitForChannelRaidEvent(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, ChannelRaidEvent>(NativeApi.R66Api_WaitForChannelRaidEvent, Native, desc);
		}

		public GameTask CloseEventStream(EventStreamDesc desc)
		{
			return Types.InvokeMarshallable<EventStreamDesc, None>(NativeApi.R66Api_CloseEventStream, Native, desc);
		}

		public GameTask PrepareShutdown()
		{
			return Types.InvokeMarshallable<None>(NativeApi.R66Api_PrepareShutdown, Native);
		}

		public CoreLibrary(PlatformAbstractionLayer pal, string clientId, bool useEventSubProxy)
		{
			Native = NativeApi.R66Api_new(pal.Native, clientId, useEventSubProxy);
			PAL = pal;
		}

		protected override void DisposeUnmanaged()
		{
			PAL.Dispose();
			NativeApi.R66Api_Dispose(Native);
			Native = IntPtr.Zero;
		}
	}
}
