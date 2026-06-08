using System;
using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class ChannelCommerceEvents : MessageData
	{
		public string Username { get; }

		public string DisplayName { get; }

		public string ChannelName { get; }

		public string UserId { get; }

		public string ChannelId { get; }

		public string Time { get; }

		public string ItemImageURL { get; }

		public string ItemDescription { get; }

		public bool SupportsChannel { get; }

		public string PurchaseMessage { get; }

		public ChannelCommerceEvents(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			Username = jObject.SelectToken("data").SelectToken("user_name")?.ToString();
			DisplayName = jObject.SelectToken("data").SelectToken("display_name")?.ToString();
			ChannelName = jObject.SelectToken("data").SelectToken("channel_name")?.ToString();
			UserId = jObject.SelectToken("data").SelectToken("user_id")?.ToString();
			ChannelId = jObject.SelectToken("data").SelectToken("channel_id")?.ToString();
			Time = jObject.SelectToken("data").SelectToken("time")?.ToString();
			ItemImageURL = jObject.SelectToken("data").SelectToken("image_item_url")?.ToString();
			ItemDescription = jObject.SelectToken("data").SelectToken("item_description")?.ToString();
			SupportsChannel = bool.Parse(jObject.SelectToken("data").SelectToken("supports_channel")?.ToString() ?? throw new InvalidOperationException());
			PurchaseMessage = jObject.SelectToken("data").SelectToken("purchase_message").SelectToken("message")?.ToString();
		}
	}
}
