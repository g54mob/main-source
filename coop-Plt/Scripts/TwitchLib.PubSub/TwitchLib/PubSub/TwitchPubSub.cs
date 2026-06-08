using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Enums;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Events;
using TwitchLib.PubSub.Interfaces;
using TwitchLib.PubSub.Models;
using TwitchLib.PubSub.Models.Responses;
using TwitchLib.PubSub.Models.Responses.Messages;
using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

namespace TwitchLib.PubSub
{
	public class TwitchPubSub : ITwitchPubSub
	{
		private readonly WebSocketClient _socket;

		private readonly List<PreviousRequest> _previousRequests = new List<PreviousRequest>();

		private readonly Semaphore _previousRequestsSemaphore = new Semaphore(1, 1);

		private readonly ILogger<TwitchPubSub> _logger;

		private readonly System.Timers.Timer _pingTimer = new System.Timers.Timer();

		private readonly System.Timers.Timer _pongTimer = new System.Timers.Timer();

		private bool _pongReceived = false;

		private readonly List<string> _topicList = new List<string>();

		private readonly Dictionary<string, string> _topicToChannelId = new Dictionary<string, string>();

		private static readonly Random Random = new Random();

		public event EventHandler OnPubSubServiceConnected;

		public event EventHandler<OnPubSubServiceErrorArgs> OnPubSubServiceError;

		public event EventHandler OnPubSubServiceClosed;

		public event EventHandler<OnListenResponseArgs> OnListenResponse;

		public event EventHandler<OnTimeoutArgs> OnTimeout;

		public event EventHandler<OnBanArgs> OnBan;

		public event EventHandler<OnMessageDeletedArgs> OnMessageDeleted;

		public event EventHandler<OnUnbanArgs> OnUnban;

		public event EventHandler<OnUntimeoutArgs> OnUntimeout;

		public event EventHandler<OnHostArgs> OnHost;

		public event EventHandler<OnSubscribersOnlyArgs> OnSubscribersOnly;

		public event EventHandler<OnSubscribersOnlyOffArgs> OnSubscribersOnlyOff;

		public event EventHandler<OnClearArgs> OnClear;

		public event EventHandler<OnEmoteOnlyArgs> OnEmoteOnly;

		public event EventHandler<OnEmoteOnlyOffArgs> OnEmoteOnlyOff;

		public event EventHandler<OnR9kBetaArgs> OnR9kBeta;

		public event EventHandler<OnR9kBetaOffArgs> OnR9kBetaOff;

		public event EventHandler<OnBitsReceivedArgs> OnBitsReceived;

		public event EventHandler<OnBitsReceivedV2Args> OnBitsReceivedV2;

		public event EventHandler<OnChannelCommerceReceivedArgs> OnChannelCommerceReceived;

		public event EventHandler<OnStreamUpArgs> OnStreamUp;

		public event EventHandler<OnStreamDownArgs> OnStreamDown;

		public event EventHandler<OnViewCountArgs> OnViewCount;

		public event EventHandler<OnWhisperArgs> OnWhisper;

		public event EventHandler<OnChannelSubscriptionArgs> OnChannelSubscription;

		public event EventHandler<OnChannelExtensionBroadcastArgs> OnChannelExtensionBroadcast;

		public event EventHandler<OnFollowArgs> OnFollow;

		[Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
		public event EventHandler<OnCustomRewardCreatedArgs> OnCustomRewardCreated;

		[Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
		public event EventHandler<OnCustomRewardUpdatedArgs> OnCustomRewardUpdated;

		[Obsolete("This event fires on an undocumented/retired/obsolete topic.", false)]
		public event EventHandler<OnCustomRewardDeletedArgs> OnCustomRewardDeleted;

		[Obsolete("This event fires on an undocumented/retired/obsolete topic. Consider using OnChannelPointsRewardRedeemed", false)]
		public event EventHandler<OnRewardRedeemedArgs> OnRewardRedeemed;

		public event EventHandler<OnChannelPointsRewardRedeemedArgs> OnChannelPointsRewardRedeemed;

		public event EventHandler<OnLeaderboardEventArgs> OnLeaderboardSubs;

		public event EventHandler<OnLeaderboardEventArgs> OnLeaderboardBits;

		public event EventHandler<OnRaidUpdateArgs> OnRaidUpdate;

		public event EventHandler<OnRaidUpdateV2Args> OnRaidUpdateV2;

		public event EventHandler<OnRaidGoArgs> OnRaidGo;

		public event EventHandler<OnLogArgs> OnLog;

		public event EventHandler<OnCommercialArgs> OnCommercial;

		public event EventHandler<OnPredictionArgs> OnPrediction;

		public TwitchPubSub(ILogger<TwitchPubSub> logger = null)
		{
			_logger = logger;
			ClientOptions options = new ClientOptions
			{
				ClientType = ClientType.PubSub
			};
			_socket = new WebSocketClient(options);
			_socket.OnConnected += Socket_OnConnected;
			_socket.OnError += OnError;
			_socket.OnMessage += OnMessage;
			_socket.OnDisconnected += Socket_OnDisconnected;
			_pongTimer.Interval = 15000.0;
			_pongTimer.Elapsed += PongTimerTick;
		}

		private void OnError(object sender, OnErrorEventArgs e)
		{
			_logger?.LogError($"OnError in PubSub Websocket connection occured! Exception: {e.Exception}");
			this.OnPubSubServiceError?.Invoke(this, new OnPubSubServiceErrorArgs
			{
				Exception = e.Exception
			});
		}

		private void OnMessage(object sender, OnMessageEventArgs e)
		{
			_logger?.LogDebug("Received Websocket OnMessage: " + e.Message);
			this.OnLog?.Invoke(this, new OnLogArgs
			{
				Data = e.Message
			});
			ParseMessage(e.Message);
		}

		private void Socket_OnDisconnected(object sender, EventArgs e)
		{
			_logger?.LogWarning("PubSub Websocket connection closed");
			_pingTimer.Stop();
			_pongTimer.Stop();
			this.OnPubSubServiceClosed?.Invoke(this, null);
		}

		private void Socket_OnConnected(object sender, EventArgs e)
		{
			_logger?.LogInformation("PubSub Websocket connection established");
			_pingTimer.Interval = 180000.0;
			_pingTimer.Elapsed += PingTimerTick;
			_pingTimer.Start();
			this.OnPubSubServiceConnected?.Invoke(this, null);
		}

		private void PingTimerTick(object sender, ElapsedEventArgs e)
		{
			_pongReceived = false;
			JObject jObject = new JObject(new JProperty("type", "PING"));
			_socket.Send(jObject.ToString());
			_pongTimer.Start();
		}

		private void PongTimerTick(object sender, ElapsedEventArgs e)
		{
			_pongTimer.Stop();
			if (_pongReceived)
			{
				_pongReceived = false;
			}
			else
			{
				_socket.Close();
			}
		}

		private void ParseMessage(string message)
		{
			switch ((JObject.Parse(message).SelectToken("type")?.ToString())?.ToLower())
			{
			case "response":
			{
				Response response = new Response(message);
				if (_previousRequests.Count == 0)
				{
					break;
				}
				bool flag = false;
				_previousRequestsSemaphore.WaitOne();
				try
				{
					int num = 0;
					while (num < _previousRequests.Count)
					{
						PreviousRequest previousRequest = _previousRequests[num];
						if (string.Equals(previousRequest.Nonce, response.Nonce, StringComparison.CurrentCulture))
						{
							_previousRequests.RemoveAt(num);
							_topicToChannelId.TryGetValue(previousRequest.Topic, out var value2);
							this.OnListenResponse?.Invoke(this, new OnListenResponseArgs
							{
								Response = response,
								Topic = previousRequest.Topic,
								Successful = response.Successful,
								ChannelId = value2
							});
							flag = true;
						}
						else
						{
							num++;
						}
					}
				}
				finally
				{
					_previousRequestsSemaphore.Release();
				}
				if (flag)
				{
					return;
				}
				break;
			}
			case "message":
			{
				Message message2 = new Message(message);
				_topicToChannelId.TryGetValue(message2.Topic, out var value);
				value = value ?? "";
				switch (message2.Topic.Split('.')[0])
				{
				case "channel-subscribe-events-v1":
				{
					ChannelSubscription subscription = message2.MessageData as ChannelSubscription;
					this.OnChannelSubscription?.Invoke(this, new OnChannelSubscriptionArgs
					{
						Subscription = subscription,
						ChannelId = value
					});
					return;
				}
				case "whispers":
				{
					Whisper whisper = (Whisper)message2.MessageData;
					this.OnWhisper?.Invoke(this, new OnWhisperArgs
					{
						Whisper = whisper,
						ChannelId = value
					});
					return;
				}
				case "chat_moderator_actions":
				{
					ChatModeratorActions chatModeratorActions = message2.MessageData as ChatModeratorActions;
					string text = "";
					switch (chatModeratorActions?.ModerationAction.ToLower())
					{
					case "timeout":
						if (chatModeratorActions.Args.Count > 2)
						{
							text = chatModeratorActions.Args[2];
						}
						this.OnTimeout?.Invoke(this, new OnTimeoutArgs
						{
							TimedoutBy = chatModeratorActions.CreatedBy,
							TimedoutById = chatModeratorActions.CreatedByUserId,
							TimedoutUserId = chatModeratorActions.TargetUserId,
							TimeoutDuration = TimeSpan.FromSeconds(int.Parse(chatModeratorActions.Args[1])),
							TimeoutReason = text,
							TimedoutUser = chatModeratorActions.Args[0],
							ChannelId = value
						});
						return;
					case "ban":
						if (chatModeratorActions.Args.Count > 1)
						{
							text = chatModeratorActions.Args[1];
						}
						this.OnBan?.Invoke(this, new OnBanArgs
						{
							BannedBy = chatModeratorActions.CreatedBy,
							BannedByUserId = chatModeratorActions.CreatedByUserId,
							BannedUserId = chatModeratorActions.TargetUserId,
							BanReason = text,
							BannedUser = chatModeratorActions.Args[0],
							ChannelId = value
						});
						return;
					case "delete":
						this.OnMessageDeleted?.Invoke(this, new OnMessageDeletedArgs
						{
							DeletedBy = chatModeratorActions.CreatedBy,
							DeletedByUserId = chatModeratorActions.CreatedByUserId,
							TargetUserId = chatModeratorActions.TargetUserId,
							TargetUser = chatModeratorActions.Args[0],
							Message = chatModeratorActions.Args[1],
							MessageId = chatModeratorActions.Args[2],
							ChannelId = value
						});
						return;
					case "unban":
						this.OnUnban?.Invoke(this, new OnUnbanArgs
						{
							UnbannedBy = chatModeratorActions.CreatedBy,
							UnbannedByUserId = chatModeratorActions.CreatedByUserId,
							UnbannedUserId = chatModeratorActions.TargetUserId,
							UnbannedUser = chatModeratorActions.Args[0],
							ChannelId = value
						});
						return;
					case "untimeout":
						this.OnUntimeout?.Invoke(this, new OnUntimeoutArgs
						{
							UntimeoutedBy = chatModeratorActions.CreatedBy,
							UntimeoutedByUserId = chatModeratorActions.CreatedByUserId,
							UntimeoutedUserId = chatModeratorActions.TargetUserId,
							UntimeoutedUser = chatModeratorActions.Args[0],
							ChannelId = value
						});
						return;
					case "host":
						this.OnHost?.Invoke(this, new OnHostArgs
						{
							HostedChannel = chatModeratorActions.Args[0],
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "subscribers":
						this.OnSubscribersOnly?.Invoke(this, new OnSubscribersOnlyArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "subscribersoff":
						this.OnSubscribersOnlyOff?.Invoke(this, new OnSubscribersOnlyOffArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "clear":
						this.OnClear?.Invoke(this, new OnClearArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "emoteonly":
						this.OnEmoteOnly?.Invoke(this, new OnEmoteOnlyArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "emoteonlyoff":
						this.OnEmoteOnlyOff?.Invoke(this, new OnEmoteOnlyOffArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "r9kbeta":
						this.OnR9kBeta?.Invoke(this, new OnR9kBetaArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					case "r9kbetaoff":
						this.OnR9kBetaOff?.Invoke(this, new OnR9kBetaOffArgs
						{
							Moderator = chatModeratorActions.CreatedBy,
							ChannelId = value
						});
						return;
					}
					break;
				}
				case "channel-bits-events-v1":
					if (message2.MessageData is ChannelBitsEvents channelBitsEvents)
					{
						this.OnBitsReceived?.Invoke(this, new OnBitsReceivedArgs
						{
							BitsUsed = channelBitsEvents.BitsUsed,
							ChannelId = channelBitsEvents.ChannelId,
							ChannelName = channelBitsEvents.ChannelName,
							ChatMessage = channelBitsEvents.ChatMessage,
							Context = channelBitsEvents.Context,
							Time = channelBitsEvents.Time,
							TotalBitsUsed = channelBitsEvents.TotalBitsUsed,
							UserId = channelBitsEvents.UserId,
							Username = channelBitsEvents.Username
						});
						return;
					}
					break;
				case "channel-bits-events-v2":
					if (message2.MessageData is ChannelBitsEventsV2 channelBitsEventsV)
					{
						this.OnBitsReceivedV2?.Invoke(this, new OnBitsReceivedV2Args
						{
							IsAnonymous = channelBitsEventsV.IsAnonymous,
							BitsUsed = channelBitsEventsV.BitsUsed,
							ChannelId = channelBitsEventsV.ChannelId,
							ChannelName = channelBitsEventsV.ChannelName,
							ChatMessage = channelBitsEventsV.ChatMessage,
							Context = channelBitsEventsV.Context,
							Time = channelBitsEventsV.Time,
							TotalBitsUsed = channelBitsEventsV.TotalBitsUsed,
							UserId = channelBitsEventsV.UserId,
							UserName = channelBitsEventsV.UserName
						});
						return;
					}
					break;
				case "channel-commerce-events-v1":
					if (message2.MessageData is ChannelCommerceEvents channelCommerceEvents)
					{
						this.OnChannelCommerceReceived?.Invoke(this, new OnChannelCommerceReceivedArgs
						{
							Username = channelCommerceEvents.Username,
							DisplayName = channelCommerceEvents.DisplayName,
							ChannelName = channelCommerceEvents.ChannelName,
							UserId = channelCommerceEvents.UserId,
							ChannelId = channelCommerceEvents.ChannelId,
							Time = channelCommerceEvents.Time,
							ItemImageURL = channelCommerceEvents.ItemImageURL,
							ItemDescription = channelCommerceEvents.ItemDescription,
							SupportsChannel = channelCommerceEvents.SupportsChannel,
							PurchaseMessage = channelCommerceEvents.PurchaseMessage
						});
						return;
					}
					break;
				case "channel-ext-v1":
				{
					ChannelExtensionBroadcast channelExtensionBroadcast = message2.MessageData as ChannelExtensionBroadcast;
					this.OnChannelExtensionBroadcast?.Invoke(this, new OnChannelExtensionBroadcastArgs
					{
						Messages = channelExtensionBroadcast.Messages,
						ChannelId = value
					});
					return;
				}
				case "video-playback-by-id":
				{
					VideoPlayback videoPlayback = message2.MessageData as VideoPlayback;
					switch (videoPlayback?.Type)
					{
					case VideoPlaybackType.StreamDown:
						this.OnStreamDown?.Invoke(this, new OnStreamDownArgs
						{
							ServerTime = videoPlayback.ServerTime,
							ChannelId = value
						});
						return;
					case VideoPlaybackType.StreamUp:
						this.OnStreamUp?.Invoke(this, new OnStreamUpArgs
						{
							PlayDelay = videoPlayback.PlayDelay,
							ServerTime = videoPlayback.ServerTime,
							ChannelId = value
						});
						return;
					case VideoPlaybackType.ViewCount:
						this.OnViewCount?.Invoke(this, new OnViewCountArgs
						{
							ServerTime = videoPlayback.ServerTime,
							Viewers = videoPlayback.Viewers,
							ChannelId = value
						});
						return;
					case VideoPlaybackType.Commercial:
						this.OnCommercial?.Invoke(this, new OnCommercialArgs
						{
							ServerTime = videoPlayback.ServerTime,
							Length = videoPlayback.Length,
							ChannelId = value
						});
						return;
					}
					break;
				}
				case "following":
				{
					Following following = (Following)message2.MessageData;
					following.FollowedChannelId = message2.Topic.Split('.')[1];
					this.OnFollow?.Invoke(this, new OnFollowArgs
					{
						FollowedChannelId = following.FollowedChannelId,
						DisplayName = following.DisplayName,
						UserId = following.UserId,
						Username = following.Username
					});
					return;
				}
				case "community-points-channel-v1":
				{
					CommunityPointsChannel communityPointsChannel = message2.MessageData as CommunityPointsChannel;
					CommunityPointsChannelType? communityPointsChannelType = communityPointsChannel?.Type;
					CommunityPointsChannelType? communityPointsChannelType2 = communityPointsChannelType;
					if (communityPointsChannelType2.HasValue)
					{
						switch (communityPointsChannelType2.GetValueOrDefault())
						{
						case CommunityPointsChannelType.RewardRedeemed:
							this.OnRewardRedeemed?.Invoke(this, new OnRewardRedeemedArgs
							{
								TimeStamp = communityPointsChannel.TimeStamp,
								ChannelId = communityPointsChannel.ChannelId,
								Login = communityPointsChannel.Login,
								DisplayName = communityPointsChannel.DisplayName,
								Message = communityPointsChannel.Message,
								RewardId = communityPointsChannel.RewardId,
								RewardTitle = communityPointsChannel.RewardTitle,
								RewardPrompt = communityPointsChannel.RewardPrompt,
								RewardCost = communityPointsChannel.RewardCost,
								Status = communityPointsChannel.Status,
								RedemptionId = communityPointsChannel.RedemptionId
							});
							break;
						case CommunityPointsChannelType.CustomRewardUpdated:
							this.OnCustomRewardUpdated?.Invoke(this, new OnCustomRewardUpdatedArgs
							{
								TimeStamp = communityPointsChannel.TimeStamp,
								ChannelId = communityPointsChannel.ChannelId,
								RewardId = communityPointsChannel.RewardId,
								RewardTitle = communityPointsChannel.RewardTitle,
								RewardPrompt = communityPointsChannel.RewardPrompt,
								RewardCost = communityPointsChannel.RewardCost
							});
							break;
						case CommunityPointsChannelType.CustomRewardCreated:
							this.OnCustomRewardCreated?.Invoke(this, new OnCustomRewardCreatedArgs
							{
								TimeStamp = communityPointsChannel.TimeStamp,
								ChannelId = communityPointsChannel.ChannelId,
								RewardId = communityPointsChannel.RewardId,
								RewardTitle = communityPointsChannel.RewardTitle,
								RewardPrompt = communityPointsChannel.RewardPrompt,
								RewardCost = communityPointsChannel.RewardCost
							});
							break;
						case CommunityPointsChannelType.CustomRewardDeleted:
							this.OnCustomRewardDeleted?.Invoke(this, new OnCustomRewardDeletedArgs
							{
								TimeStamp = communityPointsChannel.TimeStamp,
								ChannelId = communityPointsChannel.ChannelId,
								RewardId = communityPointsChannel.RewardId,
								RewardTitle = communityPointsChannel.RewardTitle,
								RewardPrompt = communityPointsChannel.RewardPrompt
							});
							break;
						}
					}
					return;
				}
				case "channel-points-channel-v1":
				{
					ChannelPointsChannel channelPointsChannel = message2.MessageData as ChannelPointsChannel;
					switch (channelPointsChannel.Type)
					{
					case ChannelPointsChannelType.RewardRedeemed:
					{
						RewardRedeemed rewardRedeemed = channelPointsChannel.Data as RewardRedeemed;
						this.OnChannelPointsRewardRedeemed?.Invoke(this, new OnChannelPointsRewardRedeemedArgs
						{
							ChannelId = rewardRedeemed.Redemption.ChannelId,
							RewardRedeemed = rewardRedeemed
						});
						break;
					}
					case ChannelPointsChannelType.Unknown:
						UnaccountedFor("Unknown channel points type. Msg: " + channelPointsChannel.RawData);
						break;
					}
					return;
				}
				case "leaderboard-events-v1":
				{
					LeaderboardEvents leaderboardEvents = message2.MessageData as LeaderboardEvents;
					LeaderBoardType? leaderBoardType = leaderboardEvents?.Type;
					LeaderBoardType? leaderBoardType2 = leaderBoardType;
					if (leaderBoardType2.HasValue)
					{
						switch (leaderBoardType2.GetValueOrDefault())
						{
						case LeaderBoardType.BitsUsageByChannel:
							this.OnLeaderboardBits?.Invoke(this, new OnLeaderboardEventArgs
							{
								ChannelId = leaderboardEvents.ChannelId,
								TopList = leaderboardEvents.Top
							});
							break;
						case LeaderBoardType.SubGiftSent:
							this.OnLeaderboardSubs?.Invoke(this, new OnLeaderboardEventArgs
							{
								ChannelId = leaderboardEvents.ChannelId,
								TopList = leaderboardEvents.Top
							});
							break;
						}
					}
					return;
				}
				case "raid":
				{
					RaidEvents raidEvents = message2.MessageData as RaidEvents;
					RaidType? raidType = raidEvents?.Type;
					RaidType? raidType2 = raidType;
					if (raidType2.HasValue)
					{
						switch (raidType2.GetValueOrDefault())
						{
						case RaidType.RaidUpdate:
							this.OnRaidUpdate?.Invoke(this, new OnRaidUpdateArgs
							{
								Id = raidEvents.Id,
								ChannelId = raidEvents.ChannelId,
								TargetChannelId = raidEvents.TargetChannelId,
								AnnounceTime = raidEvents.AnnounceTime,
								RaidTime = raidEvents.RaidTime,
								RemainingDurationSeconds = raidEvents.RemainigDurationSeconds,
								ViewerCount = raidEvents.ViewerCount
							});
							break;
						case RaidType.RaidUpdateV2:
							this.OnRaidUpdateV2?.Invoke(this, new OnRaidUpdateV2Args
							{
								Id = raidEvents.Id,
								ChannelId = raidEvents.ChannelId,
								TargetChannelId = raidEvents.TargetChannelId,
								TargetLogin = raidEvents.TargetLogin,
								TargetDisplayName = raidEvents.TargetDisplayName,
								TargetProfileImage = raidEvents.TargetProfileImage,
								ViewerCount = raidEvents.ViewerCount
							});
							break;
						case RaidType.RaidGo:
							this.OnRaidGo?.Invoke(this, new OnRaidGoArgs
							{
								Id = raidEvents.Id,
								ChannelId = raidEvents.ChannelId,
								TargetChannelId = raidEvents.TargetChannelId,
								TargetLogin = raidEvents.TargetLogin,
								TargetDisplayName = raidEvents.TargetDisplayName,
								TargetProfileImage = raidEvents.TargetProfileImage,
								ViewerCount = raidEvents.ViewerCount
							});
							break;
						}
					}
					return;
				}
				case "predictions-channel-v1":
				{
					PredictionEvents predictionEvents = message2.MessageData as PredictionEvents;
					switch (predictionEvents?.Type)
					{
					case PredictionType.EventCreated:
						this.OnPrediction?.Invoke(this, new OnPredictionArgs
						{
							CreatedAt = predictionEvents.CreatedAt,
							Title = predictionEvents.Title,
							ChannelId = predictionEvents.ChannelId,
							EndedAt = predictionEvents.EndedAt,
							Id = predictionEvents.Id,
							Outcomes = predictionEvents.Outcomes,
							LockedAt = predictionEvents.LockedAt,
							PredictionTime = predictionEvents.PredictionTime,
							Status = predictionEvents.Status,
							WinningOutcomeId = predictionEvents.WinningOutcomeId,
							Type = predictionEvents.Type
						});
						break;
					case PredictionType.EventUpdated:
						this.OnPrediction?.Invoke(this, new OnPredictionArgs
						{
							CreatedAt = predictionEvents.CreatedAt,
							Title = predictionEvents.Title,
							ChannelId = predictionEvents.ChannelId,
							EndedAt = predictionEvents.EndedAt,
							Id = predictionEvents.Id,
							Outcomes = predictionEvents.Outcomes,
							LockedAt = predictionEvents.LockedAt,
							PredictionTime = predictionEvents.PredictionTime,
							Status = predictionEvents.Status,
							WinningOutcomeId = predictionEvents.WinningOutcomeId,
							Type = predictionEvents.Type
						});
						break;
					case null:
						UnaccountedFor("Prediction Type: null");
						break;
					default:
						UnaccountedFor($"Prediction Type: {predictionEvents.Type}");
						break;
					}
					return;
				}
				}
				break;
			}
			case "pong":
				_pongReceived = true;
				return;
			case "reconnect":
				_socket.Close();
				break;
			}
			UnaccountedFor(message);
		}

		private static string GenerateNonce()
		{
			return new string((from s in Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8)
				select s[Random.Next(s.Length)]).ToArray());
		}

		private void ListenToTopic(string topic)
		{
			_topicList.Add(topic);
		}

		private void ListenToTopics(params string[] topics)
		{
			foreach (string item in topics)
			{
				_topicList.Add(item);
			}
		}

		public void SendTopics(string oauth = null, bool unlisten = false)
		{
			if (oauth != null && oauth.Contains("oauth:"))
			{
				oauth = oauth.Replace("oauth:", "");
			}
			string text = GenerateNonce();
			JArray jArray = new JArray();
			_previousRequestsSemaphore.WaitOne();
			try
			{
				foreach (string topic in _topicList)
				{
					_previousRequests.Add(new PreviousRequest(text, PubSubRequestType.ListenToTopic, topic));
					jArray.Add(new JValue(topic));
				}
			}
			finally
			{
				_previousRequestsSemaphore.Release();
			}
			JObject jObject = new JObject(new JProperty("type", (!unlisten) ? "LISTEN" : "UNLISTEN"), new JProperty("nonce", text), new JProperty("data", new JObject(new JProperty("topics", jArray))));
			if (oauth != null)
			{
				((JObject)jObject.SelectToken("data"))?.Add(new JProperty("auth_token", oauth));
			}
			_socket.Send(jObject.ToString());
			_topicList.Clear();
		}

		private void UnaccountedFor(string message)
		{
			_logger?.LogInformation("[TwitchPubSub] " + message);
		}

		public void ListenToFollows(string channelId)
		{
			string text = "following." + channelId;
			_topicToChannelId[text] = channelId;
			ListenToTopic(text);
		}

		public void ListenToChatModeratorActions(string myTwitchId, string channelTwitchId)
		{
			string text = "chat_moderator_actions." + myTwitchId + "." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToChannelExtensionBroadcast(string channelId, string extensionId)
		{
			string text = "channel-ext-v1." + channelId + "-" + extensionId + "-broadcast";
			_topicToChannelId[text] = channelId;
			ListenToTopic(text);
		}

		[Obsolete("This topic is depreacted by Twitch. Please use ListenToBitsEventsV2()", false)]
		public void ListenToBitsEvents(string channelTwitchId)
		{
			string text = "channel-bits-events-v1." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToBitsEventsV2(string channelTwitchId)
		{
			string text = "channel-bits-events-v2." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToCommerce(string channelTwitchId)
		{
			string text = "channel-commerce-events-v1." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToVideoPlayback(string channelTwitchId)
		{
			string text = "video-playback-by-id." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToWhispers(string channelTwitchId)
		{
			string text = "whispers." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		[Obsolete("This method listens to an undocumented/retired/obsolete topic. Consider using ListenToChannelPoints()", false)]
		public void ListenToRewards(string channelTwitchId)
		{
			string text = "community-points-channel-v1." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToChannelPoints(string channelTwitchId)
		{
			string text = "channel-points-channel-v1." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToLeaderboards(string channelTwitchId)
		{
			string text = "leaderboard-events-v1.bits-usage-by-channel-v1-" + channelTwitchId + "-WEEK";
			string text2 = "leaderboard-events-v1.sub-gift-sent-" + channelTwitchId + "-WEEK";
			_topicToChannelId[text] = channelTwitchId;
			_topicToChannelId[text2] = channelTwitchId;
			ListenToTopics(text, text2);
		}

		public void ListenToRaid(string channelTwitchId)
		{
			string text = "raid." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void ListenToSubscriptions(string channelId)
		{
			string text = "channel-subscribe-events-v1." + channelId;
			_topicToChannelId[text] = channelId;
			ListenToTopic(text);
		}

		public void ListenToPredictions(string channelTwitchId)
		{
			string text = "predictions-channel-v1." + channelTwitchId;
			_topicToChannelId[text] = channelTwitchId;
			ListenToTopic(text);
		}

		public void Connect()
		{
			_socket.Open();
		}

		public void Disconnect()
		{
			_socket.Close();
		}

		public void TestMessageParser(string testJsonString)
		{
			ParseMessage(testJsonString);
		}
	}
}
