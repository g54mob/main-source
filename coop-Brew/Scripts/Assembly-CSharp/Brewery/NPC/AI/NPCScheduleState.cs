namespace Brewery.NPC.AI
{
	public enum NPCScheduleState
	{
		OffDutyHome = 0,
		CommutingToWork = 1,
		AtWork = 2,
		CommutingToHotspot = 3,
		AtHotspot = 4,
		CommutingToBar = 5,
		AtBar = 6,
		CommutingHome = 7,
		Cooldown = 8
	}
}
