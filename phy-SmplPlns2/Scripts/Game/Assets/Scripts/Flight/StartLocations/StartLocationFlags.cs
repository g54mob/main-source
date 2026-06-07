using System;

namespace Assets.Scripts.Flight.StartLocations
{
	[Flags]
	public enum StartLocationFlags : byte
	{
		None = 0,
		IsRunwayTakeoff = 1,
		IsFinalApproach = 2
	}
}
