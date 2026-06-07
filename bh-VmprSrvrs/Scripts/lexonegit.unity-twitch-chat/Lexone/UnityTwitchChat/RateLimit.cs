using System;

namespace Lexone.UnityTwitchChat
{
	public struct RateLimit
	{
		public int count;

		public TimeSpan timeSpan;

		public static readonly RateLimit ChatRegular;

		public static readonly RateLimit ChatModerator;

		public static readonly RateLimit SiteLimitVerified;

		public static readonly RateLimit AuthAttemptsRegular;

		public static readonly RateLimit JoinAttemptsRegular;

		public static readonly RateLimit AuthAttemptsVerified;

		public static readonly RateLimit JoinAttemptsVerified;

		public static readonly RateLimit WhispersA;

		public static readonly RateLimit WhispersB;

		public static readonly RateLimit WhisperChannels;

		public RateLimit(int count, TimeSpan timeSpan)
		{
			this.count = 0;
			this.timeSpan = default(TimeSpan);
		}
	}
}
