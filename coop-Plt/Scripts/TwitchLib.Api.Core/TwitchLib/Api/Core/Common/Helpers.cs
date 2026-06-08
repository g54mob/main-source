using System;
using System.Text;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Core.Common
{
	public static class Helpers
	{
		public static string FormatOAuth(string token)
		{
			return token.Contains(" ") ? token.Split(' ')[1] : token;
		}

		public static string AuthScopesToString(AuthScopes scope)
		{
			return scope switch
			{
				AuthScopes.Channel_Check_Subscription => "channel_check_subscription", 
				AuthScopes.Channel_Commercial => "channel_commercial", 
				AuthScopes.Channel_Editor => "channel_editor", 
				AuthScopes.Channel_Feed_Edit => "channel_feed_edit", 
				AuthScopes.Channel_Feed_Read => "channel_feed_read", 
				AuthScopes.Channel_Read => "channel_read", 
				AuthScopes.Channel_Stream => "channel_stream", 
				AuthScopes.Channel_Subscriptions => "channel_subscriptions", 
				AuthScopes.Chat_Login => "chat_login", 
				AuthScopes.Collections_Edit => "collections_edit", 
				AuthScopes.Communities_Edit => "communities_edit", 
				AuthScopes.Communities_Moderate => "communities_moderate", 
				AuthScopes.User_Blocks_Edit => "user_blocks_edit", 
				AuthScopes.User_Blocks_Read => "user_blocks_read", 
				AuthScopes.User_Follows_Edit => "user_follows_edit", 
				AuthScopes.User_Read => "user_read", 
				AuthScopes.User_Subscriptions => "user_subscriptions", 
				AuthScopes.Viewing_Activity_Read => "viewing_activity_read", 
				AuthScopes.OpenId => "openid", 
				AuthScopes.Helix_User_Edit_Broadcast => "user:edit:broadcast", 
				AuthScopes.Helix_Analytics_Read_Extensions => "analytics:read:extensions", 
				AuthScopes.Helix_Analytics_Read_Games => "analytics:read:games", 
				AuthScopes.Helix_Bits_Read => "bits:read", 
				AuthScopes.Helix_Channel_Edit_Commercial => "channel:edit:commercial", 
				AuthScopes.Helix_Channel_Manage_Broadcast => "channel:manage:broadcast", 
				AuthScopes.Helix_Channel_Manage_Extensions => "channel:manage:extensions", 
				AuthScopes.Helix_Channel_Manage_Redemptions => "channel:manage:redemptions", 
				AuthScopes.Helix_Channel_Read_Hype_Train => "channel:read:hype_train", 
				AuthScopes.Helix_Channel_Read_Redemptions => "channel:read:redemptions", 
				AuthScopes.Helix_Channel_Read_Stream_Key => "channel:read:stream_key", 
				AuthScopes.Helix_Channel_Read_Subscriptions => "channel:read:subscriptions", 
				AuthScopes.Helix_Clips_Edit => "clips:edit", 
				AuthScopes.Helix_Moderation_Read => "moderation:read", 
				AuthScopes.Helix_User_Edit => "user:edit", 
				AuthScopes.Helix_User_Edit_Follows => "user:edit:follows", 
				AuthScopes.Helix_User_Read_Broadcast => "user:read:broadcast", 
				AuthScopes.Helix_User_Read_Email => "user:read:email", 
				AuthScopes.Helix_Channel_Read_Editors => "channel:read:editors", 
				AuthScopes.Helix_Channel_Manage_Videos => "channel:manage:videos", 
				AuthScopes.Helix_User_Read_BlockedUsers => "user:read:blocked_users", 
				AuthScopes.Helix_User_Manage_BlockedUsers => "user:manage:blocked_users", 
				AuthScopes.Helix_User_Read_Subscriptions => "user:read:subscriptions", 
				_ => "", 
			};
		}

		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}
	}
}
