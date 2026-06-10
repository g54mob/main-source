namespace ModIO.Implementation.Platform
{
	internal static class PlatformConfiguration
	{
		public static string RESTAPI_HEADER;

		public const bool SynchronizedDataJobs = false;

		public static ResultAnd<IUserDataService> CreateUserDataService(string userProfileIdentifier, long gameId, BuildSettings settings)
		{
			return null;
		}

		public static ResultAnd<IPersistentDataService> CreatePersistentDataService(long gameId, BuildSettings settings)
		{
			return null;
		}

		public static ResultAnd<ITempDataService> CreateTempDataService(long gameId, BuildSettings settings)
		{
			return null;
		}
	}
}
