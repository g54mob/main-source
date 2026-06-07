namespace Brewery.NPC.Simple
{
	public enum RoutineState
	{
		Disabled = 0,
		HomeIdle = 1,
		WalkToHotspot = 2,
		HotspotIdle = 3,
		WalkToStand = 4,
		AtStand = 5,
		LeaveStand = 6,
		WalkToBar = 7,
		WalkToClosedBar = 8,
		LookingAtClosedBar = 9,
		AcquireBarSpot = 10,
		WalkToBarSpot = 11,
		AtBar = 12,
		WalkHome = 13
	}
}
