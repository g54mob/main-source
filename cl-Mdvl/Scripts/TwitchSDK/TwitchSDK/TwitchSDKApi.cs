using System;
using System.Linq;
using System.Runtime.InteropServices;
using TwitchSDK.Interop;

namespace TwitchSDK
{
	public class TwitchSDKApi : BaseDisposable
	{
		private readonly CoreLibrary Core;

		private ResultCache<AuthenticationInfo> AuthenticationInfoCache = new ResultCache<AuthenticationInfo>(TimeSpan.FromSeconds(0.25));

		private ResultCache<string, UserSubscriptionCheckResult> CheckUserSubscriptionCache = new ResultCache<string, UserSubscriptionCheckResult>(TimeSpan.FromSeconds(15.0));

		public static string Version => Marshal.PtrToStringUni(NativeApi.R66_GetVersion());

		public TwitchSDKApi(string clientId, bool useEventSubProxy = false)
		{
			Core = new CoreLibrary(CreatePAL(), clientId, useEventSubProxy);
		}

		protected virtual PlatformAbstractionLayer CreatePAL()
		{
			return new ManagedPAL();
		}

		public GameTask<AuthenticationInfo> GetAuthenticationInfo(params TwitchOAuthScope[] scopes)
		{
			return AuthenticationInfoCache.GetOrInsert(async delegate
			{
				AuthenticationInfo authenticationInfo = await Core.GetAuthenticationInfo(string.Join(" ", scopes.Select((TwitchOAuthScope x) => x.Scope)));
				return string.IsNullOrEmpty(authenticationInfo.Uri) ? null : authenticationInfo;
			});
		}

		public GameTask<AuthState> GetAuthState()
		{
			return Core.GetAuthState();
		}

		public GameTask LogOut()
		{
			return Core.LogOut();
		}

		public GameTask<UserInfo> GetMyUserInfo()
		{
			return Core.GetMyUserInfo();
		}

		public GameTask<UserInfo> GetUserInfoById(string login)
		{
			return Core.GetUserInfoById(login);
		}

		public GameTask<UserInfo> GetUserInfoByLoginName(string login)
		{
			return Core.GetUserInfoByLoginName(login);
		}

		public GameTask<StreamInfo> GetMyStreamInfo()
		{
			return Core.GetMyStreamInfo();
		}

		public GameTask<StreamQueryResult> QueryStreams(StreamQuery query)
		{
			return Core.QueryStreams(query);
		}

		public async GameTask<StreamInfo> GetStreamInfoById(string id)
		{
			return (await QueryStreams(new StreamQuery
			{
				UserIds = new string[1] { id }
			})).Streams.FirstOrDefault();
		}

		public async GameTask<Poll> NewPoll(PollDefinition def)
		{
			return new Poll(await Core.CreatePoll(def), Core);
		}

		public GameTask<ClipInfo> CreateClip(bool hasDelay)
		{
			return Core.CreateClip(hasDelay);
		}

		public GameTask<StreamMarkerInfo> CreateStreamMarker(string description)
		{
			return Core.CreateStreamMarker(description);
		}

		public GameTask<UserSubscriptionCheckResult> CheckUserSubscription(string broadcasterId)
		{
			return CheckUserSubscriptionCache.GetOrInsert(broadcasterId, () => Core.CheckUserSubscription(broadcasterId));
		}

		public async GameTask<Prediction> NewPrediction(PredictionDefinition def)
		{
			return new Prediction(await Core.CreatePrediction(def), Core);
		}

		public GameTask ModifyChannelInformation(string gameId = null, string language = null, string title = null, int delay = -1, string[] tags = null)
		{
			return Core.ModifyChannelInformation(new ModifyChannelInfoRequest
			{
				GameId = gameId,
				Language = language,
				Title = title,
				Delay = delay,
				Tags = tags,
				ForceUpdateTags = (tags != null)
			});
		}

		public GameTask<BitsLeaderboard> GetBitsLeaderboard(int count = -1, string period = null, string startedAt = null, string userId = null)
		{
			return Core.GetBitsLeaderboard(new BitsLeaderboardRequest
			{
				Count = count,
				Period = period,
				StartedAt = startedAt,
				UserId = userId
			});
		}

		public GameTask ReplaceCustomRewards(params CustomRewardDefinition[] rewards)
		{
			return Core.ReplaceCustomRewards(new CustomRewardList
			{
				Rewards = rewards
			});
		}

		public GameTask ResolveCustomReward(CustomRewardEvent e, CustomRewardRedemptionState resolution)
		{
			return ResolveCustomReward(new CustomRewardResolveRequest
			{
				BroadcasterId = e.BroadcasterId,
				CustomRewardId = e.CustomRewardId,
				RedemptionId = e.RedemptionId,
				Resolution = resolution
			});
		}

		public GameTask ResolveCustomReward(CustomRewardResolveRequest req)
		{
			return Core.ResolveCustomReward(req);
		}

		private async GameTask<EventStream<T>> SubscribeToEventStream<T>(EventStreamKind kind, Func<EventStreamDesc, GameTask<T>> waitFn)
		{
			return new EventStream<T>(await Core.SubscribeToEventStream(new EventStreamRequest
			{
				Kind = kind
			}), Core, waitFn);
		}

		public GameTask<EventStream<ChannelFollowEvent>> SubscribeToChannelFollowEvents()
		{
			return SubscribeToEventStream(EventStreamKind.Follower, Core.WaitForChannelFollowEvent);
		}

		public GameTask<EventStream<ChannelSubscribeEvent>> SubscribeToChannelSubscribeEvents()
		{
			return SubscribeToEventStream(EventStreamKind.Subscription, Core.WaitForChannelSubscribeEvent);
		}

		public GameTask<EventStream<ChannelCheerEvent>> SubscribeToChannelCheerEvents()
		{
			return SubscribeToEventStream(EventStreamKind.Cheer, Core.WaitForChannelCheerEvent);
		}

		public GameTask<EventStream<CustomRewardEvent>> SubscribeToCustomRewardEvents()
		{
			return SubscribeToEventStream(EventStreamKind.CustomRewardRedemption, Core.WaitForCustomRewardEvent);
		}

		public GameTask<EventStream<HypeTrainEvent>> SubscribeToHypeTrainEvents()
		{
			return SubscribeToEventStream(EventStreamKind.HypeTrain, Core.WaitForHypeTrainEvent);
		}

		public GameTask<EventStream<ChannelRaidEvent>> SubscribeToChannelRaidEvents()
		{
			return SubscribeToEventStream(EventStreamKind.ChannelRaid, Core.WaitForChannelRaidEvent);
		}

		protected override void DisposeManaged()
		{
			Core.Dispose();
		}
	}
}
