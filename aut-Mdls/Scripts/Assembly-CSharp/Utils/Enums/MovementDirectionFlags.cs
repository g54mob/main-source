using System;

namespace Utils.Enums
{
	[Flags]
	public enum MovementDirectionFlags
	{
		None = 0,
		Up = 1,
		Down = 2,
		Left = 4,
		Right = 8
	}
}
