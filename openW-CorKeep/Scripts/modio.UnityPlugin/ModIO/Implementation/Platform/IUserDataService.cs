namespace ModIO.Implementation.Platform
{
	internal interface IUserDataService : IDataService
	{
		Result Initialize(string userProfileIdentifier, long gameId, BuildSettings settings);
	}
}
