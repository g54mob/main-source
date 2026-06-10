namespace TwitchSDK
{
	public class TwitchOAuthScope
	{
		public static class Channel
		{
			public static TwitchOAuthScope ManagePolls => new TwitchOAuthScope("channel:manage:polls");

			public static TwitchOAuthScope ManagePredictions => new TwitchOAuthScope("channel:manage:predictions");

			public static TwitchOAuthScope ManageBroadcast => new TwitchOAuthScope("channel:manage:broadcast");

			public static TwitchOAuthScope ManageRedemptions => new TwitchOAuthScope("channel:manage:redemptions");

			public static TwitchOAuthScope ReadHypeTrain => new TwitchOAuthScope("channel:read:hype_train");
		}

		public static class Clips
		{
			public static TwitchOAuthScope Edit => new TwitchOAuthScope("clips:edit");
		}

		public static class User
		{
			public static TwitchOAuthScope ReadSubscriptions => new TwitchOAuthScope("user:read:subscriptions");
		}

		public static class Bits
		{
			public static TwitchOAuthScope Read => new TwitchOAuthScope("bits:read");
		}

		public string Scope { get; }

		public TwitchOAuthScope(string scope)
		{
			Scope = scope;
		}
	}
}
