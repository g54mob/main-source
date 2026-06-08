using System;

namespace XRL.World.ZoneBuilders
{
	[Serializable]
	public enum InfluenceMapSeedStrategy
	{
		FurthestPoint = 0,
		LargestRegion = 1,
		RandomPointFurtherThan4 = 2,
		RandomPointFurtherThan1 = 3,
		RandomPoint = 4
	}
}
