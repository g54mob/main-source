using System;

public enum Biome
{
	None = 0,
	Slime = 1,
	Larva = 2,
	Stone = 3,
	[Obsolete("Not used in full release world generation")]
	Obsidian = 4,
	Nature = 5,
	[Obsolete("Not used in full release world generation")]
	GreatWall = 6,
	Sea = 7,
	Desert = 8,
	Crystal = 9,
	Passage = 10,
	Excavation = 11,
	__MAX_VALUE__ = 12
}
