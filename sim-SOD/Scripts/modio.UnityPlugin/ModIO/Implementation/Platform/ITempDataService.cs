namespace ModIO.Implementation.Platform
{
	internal interface ITempDataService : IDataService
	{
		Result Initialize(long gameId, BuildSettings settings);
	}
}
