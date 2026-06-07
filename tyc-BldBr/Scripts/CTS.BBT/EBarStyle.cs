using UnityEngine;

[InspectorOrder(InspectorSort.ByName, InspectorSortDirection.Ascending)]
public enum EBarStyle
{
	None = 0,
	Cheap = 1,
	Basic = 2,
	Industrial = 4,
	Kawaii = 8,
	Western = 0x10,
	Dark = 0x20,
	Cyberpunk = 0x40,
	Vampire = 0x80,
	Pirate = 0x100,
	Tiki = 0x200,
	Disco = 0x400,
	RockDinner = 0x800,
	ArtDeco = 0x1000,
	Biker = 0x2000,
	Underwater = 0x4000
}
