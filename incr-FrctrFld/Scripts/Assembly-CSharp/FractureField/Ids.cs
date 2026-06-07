namespace FractureField
{
	public static class Ids
	{
		public const string PackageName = "com.typeten.fracturefield";

		private static string _playerId;

		private static readonly string _overrideDeviceId;

		private static string _deviceId;

		private static string _gameId;

		public static string Version => null;

		public static string Platform => null;

		public static long SessionId => 0L;

		public static long SessionCount => 0L;

		public static string UnityUserId => null;

		public static string PlayerId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static string DeviceId => null;

		public static string GameId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private static void SetPlayerId(string playerId, bool setPlayerPref = true)
		{
		}

		public static string GenerateGUID()
		{
			return null;
		}
	}
}
