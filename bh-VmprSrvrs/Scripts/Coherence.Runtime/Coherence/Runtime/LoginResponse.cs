using System;
using System.Collections.Generic;
using System.ComponentModel;
using Coherence.Cloud;
using Newtonsoft.Json;

namespace Coherence.Runtime
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct LoginResponse
	{
		[JsonProperty("kv")]
		public List<KvPair> KvStoreState;

		[JsonProperty("lobbies")]
		public List<string> LobbyIds;

		[JsonProperty("session_token")]
		internal string sessionToken;

		[JsonProperty("id")]
		private string id;

		[JsonProperty("username")]
		internal string Username;

		[JsonProperty("email")]
		internal string Email;

		[JsonProperty("display_name")]
		internal string DisplayName;

		[JsonProperty("avatar_url")]
		internal string AvatarUrl;

		[JsonProperty("verified")]
		internal bool IsVerified;

		[JsonProperty("new_player")]
		internal bool IsNewPlayer;

		[JsonIgnore]
		public SessionToken SessionToken => default(SessionToken);

		[JsonIgnore]
		public PlayerAccountId Id => default(PlayerAccountId);

		[JsonIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Id instead.")]
		[Deprecated("04/2025", 1, 6, 0, Reason = "Use Id instead.")]
		public string UserId => null;
	}
}
