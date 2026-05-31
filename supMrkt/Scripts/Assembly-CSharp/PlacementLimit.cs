using System;

[Flags]
public enum PlacementLimit
{
	None = 0,
	Count = 1,
	Volume = 2,
	MaxY = 4
}
