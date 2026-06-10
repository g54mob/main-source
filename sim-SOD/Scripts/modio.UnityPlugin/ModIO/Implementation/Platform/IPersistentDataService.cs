namespace ModIO.Implementation.Platform
{
	internal interface IPersistentDataService : IDataService
	{
		Result Initialize(long gameId, BuildSettings settings);
	}
}
