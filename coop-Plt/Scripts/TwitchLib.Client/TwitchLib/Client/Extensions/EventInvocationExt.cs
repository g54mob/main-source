using System;
using System.Collections.Generic;
using System.Drawing;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Exceptions;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
	public static class EventInvocationExt
	{
		public static void InvokeOnBeingHosted(this TwitchClient client, string channel, string botUsername, string hostedByChannel, int viewers, bool isAutoHosted)
		{
			OnBeingHostedArgs args = new OnBeingHostedArgs
			{
				BeingHostedNotification = new BeingHostedNotification(channel, botUsername, hostedByChannel, viewers, isAutoHosted)
			};
			client.RaiseEvent("OnBeingHosted", args);
		}

		public static void InvokeChannelStateChanged(this TwitchClient client, string channel, bool r9k, bool rituals, bool subOnly, int slowMode, bool emoteOnly, string broadcasterLanguage, TimeSpan followersOnly, bool mercury, string roomId)
		{
			ChannelState channelState = new ChannelState(r9k, rituals, subOnly, slowMode, emoteOnly, broadcasterLanguage, channel, followersOnly, mercury, roomId);
			OnChannelStateChangedArgs args = new OnChannelStateChangedArgs
			{
				Channel = channel,
				ChannelState = channelState
			};
			client.RaiseEvent("OnChannelStateChanged", args);
		}

		public static void InvokeChatCleared(this TwitchClient client, string channel)
		{
			OnChatClearedArgs args = new OnChatClearedArgs
			{
				Channel = channel
			};
			client.RaiseEvent("OnChatCleared", args);
		}

		public static void InvokeChatCommandsReceived(this TwitchClient client, string botUsername, string userId, string userName, string displayName, string colorHex, Color color, EmoteSet emoteSet, string message, UserType userType, string channel, string id, bool isSubscriber, int subscribedMonthCount, string roomId, bool isTurbo, bool isModerator, bool isMe, bool isBroadcaster, bool isVip, bool isPartner, bool isStaff, Noisy noisy, string rawIrcMessage, string emoteReplacedMessage, List<KeyValuePair<string, string>> badges, CheerBadge cheerBadge, int bits, double bitsInDollars, string commandText, string argumentsAsString, List<string> argumentsAsList, char commandIdentifier)
		{
			ChatMessage chatMessage = new ChatMessage(botUsername, userId, userName, displayName, colorHex, color, emoteSet, message, userType, channel, id, isSubscriber, subscribedMonthCount, roomId, isTurbo, isModerator, isMe, isBroadcaster, isVip, isPartner, isStaff, noisy, rawIrcMessage, emoteReplacedMessage, badges, cheerBadge, bits, bitsInDollars);
			OnChatCommandReceivedArgs args = new OnChatCommandReceivedArgs
			{
				Command = new ChatCommand(chatMessage, commandText, argumentsAsString, argumentsAsList, commandIdentifier)
			};
			client.RaiseEvent("OnChatCommandReceived", args);
		}

		public static void InvokeConnected(this TwitchClient client, string autoJoinChannel, string botUsername)
		{
			OnConnectedArgs args = new OnConnectedArgs
			{
				AutoJoinChannel = autoJoinChannel,
				BotUsername = botUsername
			};
			client.RaiseEvent("OnConnected", args);
		}

		public static void InvokeConnectionError(this TwitchClient client, string botUsername, ErrorEvent errorEvent)
		{
			OnConnectionErrorArgs args = new OnConnectionErrorArgs
			{
				BotUsername = botUsername,
				Error = errorEvent
			};
			client.RaiseEvent("OnConnectionError", args);
		}

		public static void InvokeDisconnected(this TwitchClient client, string botUsername)
		{
			OnDisconnectedArgs args = new OnDisconnectedArgs
			{
				BotUsername = botUsername
			};
			client.RaiseEvent("OnDisconnected", args);
		}

		public static void InvokeExistingUsersDetected(this TwitchClient client, string channel, List<string> users)
		{
			OnExistingUsersDetectedArgs args = new OnExistingUsersDetectedArgs
			{
				Channel = channel,
				Users = users
			};
			client.RaiseEvent("OnExistingUsersDetected", args);
		}

		public static void InvokeGiftedSubscription(this TwitchClient client, List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string color, string displayName, string emotes, string id, string login, bool isModerator, string msgId, string msgParamMonths, string msgParamRecipientDisplayName, string msgParamRecipientId, string msgParamRecipientUserName, string msgParamSubPlanName, string msgMultiMonthGiftDuration, SubscriptionPlan msgParamSubPlan, string roomId, bool isSubscriber, string systemMsg, string systemMsgParsed, string tmiSentTs, bool isTurbo, UserType userType, string userId)
		{
			OnGiftedSubscriptionArgs args = new OnGiftedSubscriptionArgs
			{
				GiftedSubscription = new GiftedSubscription(badges, badgeInfo, color, displayName, emotes, id, login, isModerator, msgId, msgParamMonths, msgParamRecipientDisplayName, msgParamRecipientId, msgParamRecipientUserName, msgParamSubPlanName, msgMultiMonthGiftDuration, msgParamSubPlan, roomId, isSubscriber, systemMsg, systemMsgParsed, tmiSentTs, isTurbo, userType, userId)
			};
			client.RaiseEvent("OnGiftedSubscription", args);
		}

		public static void InvokeOnHostingStarted(this TwitchClient client, string hostingChannel, string targetChannel, int viewers)
		{
			OnHostingStartedArgs args = new OnHostingStartedArgs
			{
				HostingStarted = new HostingStarted(hostingChannel, targetChannel, viewers)
			};
			client.RaiseEvent("OnHostingStarted", args);
		}

		public static void InvokeOnHostingStopped(this TwitchClient client, string hostingChannel, int viewers)
		{
			OnHostingStoppedArgs args = new OnHostingStoppedArgs
			{
				HostingStopped = new HostingStopped(hostingChannel, viewers)
			};
			client.RaiseEvent("OnHostingStopped", args);
		}

		public static void InvokeHostLeft(this TwitchClient client)
		{
			client.RaiseEvent("OnHostLeft");
		}

		public static void InvokeIncorrectLogin(this TwitchClient client, ErrorLoggingInException ex)
		{
			OnIncorrectLoginArgs args = new OnIncorrectLoginArgs
			{
				Exception = ex
			};
			client.RaiseEvent("OnIncorrectLogin", args);
		}

		public static void InvokeJoinedChannel(this TwitchClient client, string botUsername, string channel)
		{
			OnJoinedChannelArgs args = new OnJoinedChannelArgs
			{
				BotUsername = botUsername,
				Channel = channel
			};
			client.RaiseEvent("OnJoinedChannel", args);
		}

		public static void InvokeLeftChannel(this TwitchClient client, string botUsername, string channel)
		{
			OnLeftChannelArgs args = new OnLeftChannelArgs
			{
				BotUsername = botUsername,
				Channel = channel
			};
			client.RaiseEvent("OnLeftChannel", args);
		}

		public static void InvokeLog(this TwitchClient client, string botUsername, string data, DateTime dateTime)
		{
			OnLogArgs args = new OnLogArgs
			{
				BotUsername = botUsername,
				Data = data,
				DateTime = dateTime
			};
			client.RaiseEvent("OnLog", args);
		}

		public static void InvokeMessageReceived(this TwitchClient client, string botUsername, string userId, string userName, string displayName, string colorHex, Color color, EmoteSet emoteSet, string message, UserType userType, string channel, string id, bool isSubscriber, int subscribedMonthCount, string roomId, bool isTurbo, bool isModerator, bool isMe, bool isBroadcaster, bool isVip, bool isPartner, bool isStaff, Noisy noisy, string rawIrcMessage, string emoteReplacedMessage, List<KeyValuePair<string, string>> badges, CheerBadge cheerBadge, int bits, double bitsInDollars)
		{
			OnMessageReceivedArgs args = new OnMessageReceivedArgs
			{
				ChatMessage = new ChatMessage(botUsername, userId, userName, displayName, colorHex, color, emoteSet, message, userType, channel, id, isSubscriber, subscribedMonthCount, roomId, isTurbo, isModerator, isMe, isBroadcaster, isVip, isPartner, isStaff, noisy, rawIrcMessage, emoteReplacedMessage, badges, cheerBadge, bits, bitsInDollars)
			};
			client.RaiseEvent("OnMessageReceived", args);
		}

		public static void InvokeMessageSent(this TwitchClient client, List<KeyValuePair<string, string>> badges, string channel, string colorHex, string displayName, string emoteSet, bool isModerator, bool isSubscriber, UserType userType, string message)
		{
			OnMessageSentArgs args = new OnMessageSentArgs
			{
				SentMessage = new SentMessage(badges, channel, colorHex, displayName, emoteSet, isModerator, isSubscriber, userType, message)
			};
			client.RaiseEvent("OnMessageSent", args);
		}

		public static void InvokeModeratorJoined(this TwitchClient client, string channel, string username)
		{
			OnModeratorJoinedArgs args = new OnModeratorJoinedArgs
			{
				Channel = channel,
				Username = username
			};
			client.RaiseEvent("OnModeratorJoined", args);
		}

		public static void InvokeModeratorLeft(this TwitchClient client, string channel, string username)
		{
			OnModeratorLeftArgs args = new OnModeratorLeftArgs
			{
				Channel = channel,
				Username = username
			};
			client.RaiseEvent("OnModeratorLeft", args);
		}

		public static void InvokeModeratorsReceived(this TwitchClient client, string channel, List<string> moderators)
		{
			OnModeratorsReceivedArgs args = new OnModeratorsReceivedArgs
			{
				Channel = channel,
				Moderators = moderators
			};
			client.RaiseEvent("OnModeratorsReceived", args);
		}

		public static void InvokeNewSubscriber(this TwitchClient client, List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string colorHex, Color color, string displayName, string emoteSet, string id, string login, string systemMessage, string msgId, string msgParamCumulativeMonths, string msgParamStreakMonths, bool msgParamShouldShareStreak, string systemMessageParsed, string resubMessage, SubscriptionPlan subscriptionPlan, string subscriptionPlanName, string roomId, string userId, bool isModerator, bool isTurbo, bool isSubscriber, bool isPartner, string tmiSentTs, UserType userType, string rawIrc, string channel)
		{
			OnNewSubscriberArgs args = new OnNewSubscriberArgs
			{
				Subscriber = new Subscriber(badges, badgeInfo, colorHex, color, displayName, emoteSet, id, login, systemMessage, msgId, msgParamCumulativeMonths, msgParamStreakMonths, msgParamShouldShareStreak, systemMessageParsed, resubMessage, subscriptionPlan, subscriptionPlanName, roomId, userId, isModerator, isTurbo, isSubscriber, isPartner, tmiSentTs, userType, rawIrc, channel)
			};
			client.RaiseEvent("OnNewSubscriber", args);
		}

		public static void InvokeNowHosting(this TwitchClient client, string channel, string hostedChannel)
		{
			OnNowHostingArgs args = new OnNowHostingArgs
			{
				Channel = channel,
				HostedChannel = hostedChannel
			};
			client.RaiseEvent("OnNowHosting", args);
		}

		public static void InvokeRaidNotification(this TwitchClient client, string channel, List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string color, string displayName, string emotes, string id, string login, bool moderator, string msgId, string msgParamDisplayName, string msgParamLogin, string msgParamViewerCount, string roomId, bool subscriber, string systemMsg, string systemMsgParsed, string tmiSentTs, bool turbo, UserType userType, string userId)
		{
			OnRaidNotificationArgs args = new OnRaidNotificationArgs
			{
				Channel = channel,
				RaidNotification = new RaidNotification(badges, badgeInfo, color, displayName, emotes, id, login, moderator, msgId, msgParamDisplayName, msgParamLogin, msgParamViewerCount, roomId, subscriber, systemMsg, systemMsgParsed, tmiSentTs, turbo, userType, userId)
			};
			client.RaiseEvent("OnRaidNotification", args);
		}

		public static void InvokeReSubscriber(this TwitchClient client, List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string colorHex, Color color, string displayName, string emoteSet, string id, string login, string systemMessage, string msgId, string msgParamCumulativeMonths, string msgParamStreakMonths, bool msgParamShouldShareStreak, string systemMessageParsed, string resubMessage, SubscriptionPlan subscriptionPlan, string subscriptionPlanName, string roomId, string userId, bool isModerator, bool isTurbo, bool isSubscriber, bool isPartner, string tmiSentTs, UserType userType, string rawIrc, string channel)
		{
			OnReSubscriberArgs args = new OnReSubscriberArgs
			{
				ReSubscriber = new ReSubscriber(badges, badgeInfo, colorHex, color, displayName, emoteSet, id, login, systemMessage, msgId, msgParamCumulativeMonths, msgParamStreakMonths, msgParamShouldShareStreak, systemMessageParsed, resubMessage, subscriptionPlan, subscriptionPlanName, roomId, userId, isModerator, isTurbo, isSubscriber, isPartner, tmiSentTs, userType, rawIrc, channel)
			};
			client.RaiseEvent("OnReSubscriber", args);
		}

		public static void InvokeSendReceiveData(this TwitchClient client, string data, SendReceiveDirection direction)
		{
			OnSendReceiveDataArgs args = new OnSendReceiveDataArgs
			{
				Data = data,
				Direction = direction
			};
			client.RaiseEvent("OnSendReceiveData", args);
		}

		public static void InvokeUserBanned(this TwitchClient client, string channel, string username, string banReason, string roomId, string targetUserId)
		{
			OnUserBannedArgs args = new OnUserBannedArgs
			{
				UserBan = new UserBan(channel, username, banReason, roomId, targetUserId)
			};
			client.RaiseEvent("OnUserBanned", args);
		}

		public static void InvokeUserJoined(this TwitchClient client, string channel, string username)
		{
			OnUserJoinedArgs args = new OnUserJoinedArgs
			{
				Channel = channel,
				Username = username
			};
			client.RaiseEvent("OnUserJoined", args);
		}

		public static void InvokeUserLeft(this TwitchClient client, string channel, string username)
		{
			OnUserLeftArgs args = new OnUserLeftArgs
			{
				Channel = channel,
				Username = username
			};
			client.RaiseEvent("OnUserLeft", args);
		}

		public static void InvokeUserStateChanged(this TwitchClient client, List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string colorHex, string displayName, string emoteSet, string channel, bool isSubscriber, bool isModerator, UserType userType)
		{
			OnUserStateChangedArgs args = new OnUserStateChangedArgs
			{
				UserState = new UserState(badges, badgeInfo, colorHex, displayName, emoteSet, channel, isSubscriber, isModerator, userType)
			};
			client.RaiseEvent("OnUserStateChanged", args);
		}

		public static void InvokeUserTimedout(this TwitchClient client, string channel, string username, int timeoutDuration, string timeoutReason)
		{
			OnUserTimedoutArgs args = new OnUserTimedoutArgs
			{
				UserTimeout = new UserTimeout(channel, username, timeoutDuration, timeoutReason)
			};
			client.RaiseEvent("OnUserTimedout", args);
		}

		public static void InvokeWhisperCommandReceived(this TwitchClient client, List<KeyValuePair<string, string>> badges, string colorHex, Color color, string username, string displayName, EmoteSet emoteSet, string threadId, string messageId, string userId, bool isTurbo, string botUsername, string message, UserType userType, string commandText, string argumentsAsString, List<string> argumentsAsList, char commandIdentifier)
		{
			WhisperMessage whisperMessage = new WhisperMessage(badges, colorHex, color, username, displayName, emoteSet, threadId, messageId, userId, isTurbo, botUsername, message, userType);
			OnWhisperCommandReceivedArgs args = new OnWhisperCommandReceivedArgs
			{
				Command = new WhisperCommand(whisperMessage, commandText, argumentsAsString, argumentsAsList, commandIdentifier)
			};
			client.RaiseEvent("OnWhisperCommandReceived", args);
		}

		public static void InvokeWhisperReceived(this TwitchClient client, List<KeyValuePair<string, string>> badges, string colorHex, Color color, string username, string displayName, EmoteSet emoteSet, string threadId, string messageId, string userId, bool isTurbo, string botUsername, string message, UserType userType)
		{
			OnWhisperReceivedArgs args = new OnWhisperReceivedArgs
			{
				WhisperMessage = new WhisperMessage(badges, colorHex, color, username, displayName, emoteSet, threadId, messageId, userId, isTurbo, botUsername, message, userType)
			};
			client.RaiseEvent("OnWhisperReceived", args);
		}

		public static void InvokeWhisperSent(this TwitchClient client, string username, string receiver, string message)
		{
			OnWhisperSentArgs args = new OnWhisperSentArgs
			{
				Message = message,
				Receiver = receiver,
				Username = username
			};
			client.RaiseEvent("OnWhisperSent", args);
		}
	}
}
