using System;

namespace AirFishLab.ScrollingList.ListStateProcessing
{
	[Flags]
	public enum ListFocusingState
	{
		None = 0,
		Top = 1,
		Middle = 2,
		Bottom = 4,
		TopAndBottom = 5
	}
}
