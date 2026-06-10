using System;

namespace NSMedieval.Objectives
{
	[Flags]
	public enum ObjectiveTaskRequirementType
	{
		None = 0,
		HaveRole = 1,
		HaveRoom = 2,
		HaveResource = 4,
		HaveNpcByEvent = 8,
		HoldPlayerTriggeredEvent = 0x10,
		HaveBuilding = 0x20,
		HavePlantInRoom = 0x40,
		HavePlant = 0x80,
		DefeatObjectivesBanditCamps = 0x100,
		HaveTradeDeal = 0x200,
		FinishEvent = 0x400,
		All = 0x3FF
	}
}
