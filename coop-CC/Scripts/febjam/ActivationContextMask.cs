using System;

[Flags]
public enum ActivationContextMask
{
	Kicked = 1,
	Impact = 2,
	Explosion = 4,
	Fire = 8,
	DevCmd = int.MinValue
}
