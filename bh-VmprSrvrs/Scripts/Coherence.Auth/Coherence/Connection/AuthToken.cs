namespace Coherence.Connection
{
	public static class AuthToken
	{
		public const string LocalDevelopmentSecret = "local-development";

		public static string ForLocalDevelopment(ConnectionType connectionType)
		{
			return null;
		}

		public static string ForLocalDevelopment(string playUserId, ConnectionType connectionType)
		{
			return null;
		}

		public static string Custom(string playUserId, ConnectionType connectionType, string secret)
		{
			return null;
		}
	}
}
