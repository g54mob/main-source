using System;

[Flags]
public enum DecorationType
{
	None = 0,
	Plant = 1,
	Decoraton = 2,
	Crop = 4,
	Border = 8,
	Energy = 0x10
}
