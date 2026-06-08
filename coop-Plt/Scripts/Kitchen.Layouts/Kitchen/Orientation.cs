using System;

namespace Kitchen
{
	[Flags]
	public enum Orientation
	{
		Null = 0,
		Right = 1,
		Down = 2,
		Left = 4,
		Up = 8
	}
}
