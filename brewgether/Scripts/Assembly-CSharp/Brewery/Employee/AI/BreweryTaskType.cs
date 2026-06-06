namespace Brewery.Employee.AI
{
	public enum BreweryTaskType
	{
		Idle = 0,
		BottleBarrel = 1,
		CollectStationOutput = 2,
		FetchAndLoadStation = 3,
		StartStationProcessing = 4,
		WaitForStationProcessing = 5,
		StoreCarriedItem = 6,
		CatalyzeFromShelf = 7
	}
}
