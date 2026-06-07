namespace Brewery.NPC.AI
{
	public enum NPCActivityState
	{
		None = 0,
		Spawning = 1,
		AcquireTransport = 2,
		TravellingToBar = 3,
		WaitingForBarEntry = 4,
		Purchasing = 5,
		Drinking = 6,
		LeavingBar = 7,
		TravellingHome = 8,
		Recovering = 9
	}
}
