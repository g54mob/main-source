namespace Coherence.Cloud
{
	public readonly struct LegacyLoginData
	{
		public static readonly LegacyLoginData None;

		public string Username { get; }

		public string GuestPassword { get; }

		public SessionToken SessionToken { get; }

		private LegacyLoginData(string username, string guestPassword, SessionToken sessionToken)
		{
			Username = null;
			GuestPassword = null;
			SessionToken = default(SessionToken);
		}

		[Deprecated("15/10/2024", 1, 4, 0, Reason = "coherence/unity#6843")]
		internal static void SetCredentials(string projectId, string uniqueId, string username, string guestPassword)
		{
		}

		public static LegacyLoginData Get(string projectId, string uniqueId = "")
		{
			return default(LegacyLoginData);
		}

		public static void ClearForProject(string projectId)
		{
		}

		public static void Clear(string projectId, string uniqueId)
		{
		}

		internal static bool Exists(string projectId, CloudUniqueId uniqueId)
		{
			return false;
		}

		internal static string GetUsernamePrefsKey(string projectId, string uniqueId)
		{
			return null;
		}

		internal static string GetGuestPasswordPrefsKey(string projectId, string uniqueId)
		{
			return null;
		}

		private static string GetSessionTokenPrefsKey(string projectId, string uniqueId)
		{
			return null;
		}
	}
}
