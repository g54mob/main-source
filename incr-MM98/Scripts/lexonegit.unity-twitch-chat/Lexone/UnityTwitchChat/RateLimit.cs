using System;

namespace Lexone.UnityTwitchChat
{
	public struct RateLimit
	{
		public int count;

		public TimeSpan timeSpan;

		public static readonly RateLimit ChatRegular = new RateLimit(20, new TimeSpan(0, 0, 30));

		public static readonly RateLimit ChatModerator = new RateLimit(100, new TimeSpan(0, 0, 30));

		public static readonly RateLimit SiteLimitVerified = new RateLimit(7500, new TimeSpan(0, 0, 30));

		public static readonly RateLimit AuthAttemptsRegular = new RateLimit(20, new TimeSpan(0, 0, 10));

		public static readonly RateLimit JoinAttemptsRegular = new RateLimit(20, new TimeSpan(0, 0, 10));

		public static readonly RateLimit AuthAttemptsVerified = new RateLimit(200, new TimeSpan(0, 0, 10));

		public static readonly RateLimit JoinAttemptsVerified = new RateLimit(2000, new TimeSpan(0, 0, 10));

		public static readonly RateLimit WhispersA = new RateLimit(3, new TimeSpan(0, 0, 1));

		public static readonly RateLimit WhispersB = new RateLimit(100, new TimeSpan(0, 1, 0));

		public static readonly RateLimit WhisperChannels = new RateLimit(40, new TimeSpan(1, 0, 0, 0));

		public RateLimit(int count, TimeSpan timeSpan)
		{
			this.count = count;
			this.timeSpan = timeSpan;
		}
	}
}
