namespace ModIO.Implementation.Platform
{
	internal static class PlatformConfiguration
	{
		public static string RESTAPI_HEADER = RestApiPlatform.Windows.ToString();

		public const bool SynchronizedDataJobs = false;

		public static ResultAnd<IUserDataService> CreateUserDataService(string userProfileIdentifier, long gameId, BuildSettings settings)
		{
			IUserDataService userDataService = new SystemIODataService();
			return ResultAnd.Create(userDataService.Initialize(userProfileIdentifier, gameId, settings), userDataService);
		}

		public static ResultAnd<IPersistentDataService> CreatePersistentDataService(long gameId, BuildSettings settings)
		{
			IPersistentDataService persistentDataService = new SystemIODataService();
			return ResultAnd.Create(persistentDataService.Initialize(gameId, settings), persistentDataService);
		}

		public static ResultAnd<ITempDataService> CreateTempDataService(long gameId, BuildSettings settings)
		{
			ITempDataService tempDataService = new SystemIODataService();
			return ResultAnd.Create(tempDataService.Initialize(gameId, settings), tempDataService);
		}
	}
}
