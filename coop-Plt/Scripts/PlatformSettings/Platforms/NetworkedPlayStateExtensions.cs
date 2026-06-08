namespace Platforms
{
	public static class NetworkedPlayStateExtensions
	{
		public static bool IsNetworked(this NetworkedPlayState n)
		{
			if (n != NetworkedPlayState.Client)
			{
				return n == NetworkedPlayState.Host;
			}
			return true;
		}

		public static bool IsOwnGame(this NetworkedPlayState n)
		{
			if (n != NetworkedPlayState.Host)
			{
				return n == NetworkedPlayState.NotNetworked;
			}
			return true;
		}
	}
}
