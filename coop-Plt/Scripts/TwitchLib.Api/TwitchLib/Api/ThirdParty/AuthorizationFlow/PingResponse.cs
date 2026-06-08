using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.ThirdParty.AuthorizationFlow
{
	public class PingResponse
	{
		public bool Success { get; protected set; }

		public string Id { get; protected set; }

		public int Error { get; protected set; }

		public string Message { get; protected set; }

		public List<AuthScopes> Scopes { get; protected set; }

		public string Token { get; protected set; }

		public string Refresh { get; protected set; }

		public string Username { get; protected set; }

		public string ClientId { get; protected set; }

		public PingResponse(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			Success = bool.Parse(jObject.SelectToken("success").ToString());
			if (!Success)
			{
				Error = int.Parse(jObject.SelectToken("error").ToString());
				Message = jObject.SelectToken("message").ToString();
				return;
			}
			Scopes = new List<AuthScopes>();
			foreach (JToken item in (IEnumerable<JToken>)jObject.SelectToken("scopes"))
			{
				Scopes.Add(StringToScope(item.ToString()));
			}
			Token = jObject.SelectToken("token").ToString();
			Refresh = jObject.SelectToken("refresh").ToString();
			Username = jObject.SelectToken("username").ToString();
			ClientId = jObject.SelectToken("client_id").ToString();
		}

		private AuthScopes StringToScope(string scope)
		{
			return scope switch
			{
				"user_read" => AuthScopes.User_Read, 
				"user_blocks_edit" => AuthScopes.User_Blocks_Edit, 
				"user_blocks_read" => AuthScopes.User_Blocks_Read, 
				"user_follows_edit" => AuthScopes.User_Follows_Edit, 
				"channel_read" => AuthScopes.Channel_Read, 
				"channel_commercial" => AuthScopes.Channel_Commercial, 
				"channel_stream" => AuthScopes.Channel_Subscriptions, 
				"channel_subscriptions" => AuthScopes.Channel_Subscriptions, 
				"user_subscriptions" => AuthScopes.User_Subscriptions, 
				"channel_check_subscription" => AuthScopes.Channel_Check_Subscription, 
				"chat_login" => AuthScopes.Chat_Login, 
				"channel_editor" => AuthScopes.Channel_Editor, 
				"channel_feed_read" => AuthScopes.Channel_Feed_Read, 
				"channel_feed_edit" => AuthScopes.Channel_Feed_Edit, 
				"collections_edit" => AuthScopes.Collections_Edit, 
				"communities_edit" => AuthScopes.Communities_Edit, 
				"communities_moderate" => AuthScopes.Communities_Moderate, 
				"viewing_activity_read" => AuthScopes.Viewing_Activity_Read, 
				"user:edit" => AuthScopes.Helix_User_Edit, 
				"user:read:email" => AuthScopes.Helix_User_Read_Email, 
				"clips:edit" => AuthScopes.Helix_Clips_Edit, 
				"analytics:read:games" => AuthScopes.Helix_Analytics_Read_Games, 
				"bits:read" => AuthScopes.Helix_Bits_Read, 
				"channel:read:subscriptions" => AuthScopes.Helix_Channel_Read_Subscriptions, 
				"channel:read:hype_train" => AuthScopes.Helix_Channel_Read_Hype_Train, 
				"channel:manage:redemptions" => AuthScopes.Helix_Channel_Manage_Redemptions, 
				"channel:edit:commercial" => AuthScopes.Helix_Channel_Edit_Commercial, 
				"channel:read:stream_key" => AuthScopes.Helix_Channel_Read_Stream_Key, 
				"channel:read:editors" => AuthScopes.Helix_Channel_Read_Editors, 
				"channel:manage:videos" => AuthScopes.Helix_Channel_Manage_Videos, 
				"user:read:blocked_users" => AuthScopes.Helix_User_Read_BlockedUsers, 
				"user:manage:blocked_users" => AuthScopes.Helix_User_Manage_BlockedUsers, 
				"user:read:subscriptions" => AuthScopes.Helix_User_Read_Subscriptions, 
				"channel:manage:polls" => AuthScopes.Helix_Channel_Manage_Polls, 
				"channel:manage:predictions" => AuthScopes.Helix_Channel_Manage_Predictions, 
				"channel:read:polls" => AuthScopes.Helix_Channel_Read_Polls, 
				"channel:read:predictions" => AuthScopes.Helix_Channel_Read_Predictions, 
				"moderator:manage:automod" => AuthScopes.Helix_Channel_Moderator_Manage_Automod, 
				"" => AuthScopes.None, 
				_ => throw new Exception("Unknown scope"), 
			};
		}
	}
}
