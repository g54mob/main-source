using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Coherence.Runtime
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Replaced by MatchedPlayer")]
	[Deprecated("04/2025", 1, 6, 0, Reason = "Replaced by MatchedPlayer for consistency and to avoid avoid naming conflicts.")]
	public struct PlayerPayload
	{
		[JsonProperty("user_id")]
		public string UserId;

		[JsonProperty("team")]
		public string Team;

		[JsonProperty("score")]
		public int Score;

		[JsonProperty("payload")]
		public string Payload;

		public static implicit operator MatchedPlayer(PlayerPayload player)
		{
			return default(MatchedPlayer);
		}

		public static implicit operator PlayerPayload(MatchedPlayer player)
		{
			return default(PlayerPayload);
		}
	}
}
