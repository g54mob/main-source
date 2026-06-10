using System;

namespace NSMedieval.WorldMap
{
	[Serializable]
	public enum CaravanState
	{
		None = 0,
		Travelling = 1,
		Returning = 2,
		Arrived = 3,
		Finished = 4
	}
}
