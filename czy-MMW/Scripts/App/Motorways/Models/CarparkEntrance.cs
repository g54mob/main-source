using System;

namespace Motorways.Models
{
	[Flags]
	public enum CarparkEntrance
	{
		TopLeft = 1,
		BottomRight = 2,
		TopLeftAndBottomRight = 3
	}
}
