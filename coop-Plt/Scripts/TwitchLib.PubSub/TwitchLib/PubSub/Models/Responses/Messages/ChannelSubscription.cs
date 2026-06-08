using System;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Common;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class ChannelSubscription : MessageData
	{
		public string Username { get; }

		public string DisplayName { get; }

		public string RecipientName { get; }

		public string RecipientDisplayName { get; }

		public string ChannelName { get; }

		public string UserId { get; }

		public string ChannelId { get; }

		public string RecipientId { get; }

		public DateTime Time { get; }

		public SubscriptionPlan SubscriptionPlan { get; }

		public string SubscriptionPlanName { get; }

		public int? Months { get; }

		public int? CumulativeMonths { get; }

		public int? StreakMonths { get; }

		public string Context { get; }

		public SubMessage SubMessage { get; }

		public bool? IsGift { get; }

		public int? MultiMonthDuration { get; }

		public ChannelSubscription(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			Username = jObject.SelectToken("user_name")?.ToString();
			DisplayName = jObject.SelectToken("display_name")?.ToString();
			RecipientName = jObject.SelectToken("recipient_user_name")?.ToString();
			RecipientDisplayName = jObject.SelectToken("recipient_display_name")?.ToString();
			ChannelName = jObject.SelectToken("channel_name")?.ToString();
			UserId = jObject.SelectToken("user_id")?.ToString();
			RecipientId = jObject.SelectToken("recipient_id")?.ToString();
			ChannelId = jObject.SelectToken("channel_id")?.ToString();
			Time = Helpers.DateTimeStringToObject(jObject.SelectToken("time")?.ToString());
			switch (jObject.SelectToken("sub_plan").ToString().ToLower())
			{
			case "prime":
				SubscriptionPlan = SubscriptionPlan.Prime;
				break;
			case "1000":
				SubscriptionPlan = SubscriptionPlan.Tier1;
				break;
			case "2000":
				SubscriptionPlan = SubscriptionPlan.Tier2;
				break;
			case "3000":
				SubscriptionPlan = SubscriptionPlan.Tier3;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			SubscriptionPlanName = jObject.SelectToken("sub_plan_name")?.ToString();
			SubMessage = new SubMessage(jObject.SelectToken("sub_message"));
			string text = jObject.SelectToken("is_gift")?.ToString();
			if (text != null)
			{
				IsGift = Convert.ToBoolean(text.ToString());
			}
			string text2 = jObject.SelectToken("multi_month_duration")?.ToString();
			if (text2 != null)
			{
				MultiMonthDuration = int.Parse(text2.ToString());
			}
			Context = jObject.SelectToken("context")?.ToString();
			JToken jToken = jObject.SelectToken("months");
			if (jToken != null)
			{
				Months = int.Parse(jToken.ToString());
			}
			JToken jToken2 = jObject.SelectToken("cumulative_months");
			if (jToken2 != null)
			{
				CumulativeMonths = int.Parse(jToken2.ToString());
			}
			JToken jToken3 = jObject.SelectToken("streak_months");
			if (jToken3 != null)
			{
				StreakMonths = int.Parse(jToken3.ToString());
			}
		}
	}
}
