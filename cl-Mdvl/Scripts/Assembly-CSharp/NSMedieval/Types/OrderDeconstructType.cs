using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum OrderDeconstructType
	{
		AllBuildings = 1,
		Floors = 2,
		Walls = 4,
		Roofs = 8,
		WorkbenchFurniture = 0x10
	}
}
