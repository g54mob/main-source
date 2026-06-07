using System;
using System.ComponentModel;
using Coherence.Cloud;
using Newtonsoft.Json;

namespace Coherence.Runtime
{
	public struct MatchedPlayer
	{
		[JsonProperty("user_id")]
		internal string id;

		[JsonProperty("team")]
		public string Team;

		[JsonProperty("score")]
		public int Score;

		[JsonProperty("payload")]
		public string Payload;

		[JsonIgnore]
		public PlayerAccountId Id => default(PlayerAccountId);

		[JsonIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Id instead.")]
		[Deprecated("04/2025", 1, 6, 0, Reason = "Use Id instead.")]
		public string UserId => null;
	}
}
