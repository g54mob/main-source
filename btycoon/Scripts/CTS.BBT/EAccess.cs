using System;

[Flags]
public enum EAccess
{
	Empty = 1,
	Inaccessible = 2,
	WrongAccess = 4,
	Accessible = 8
}
