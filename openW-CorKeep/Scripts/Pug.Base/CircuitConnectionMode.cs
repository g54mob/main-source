using System;

[Flags]
public enum CircuitConnectionMode
{
	None = 0,
	AccordingToDirection = 1,
	Cross = 2,
	T = 4,
	L = 8,
	I = 0x10,
	BlockingDirectionCircuitTypes = 0x1C
}
