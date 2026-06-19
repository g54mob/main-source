using System;
using System.Collections.Generic;

namespace WorldEnvironment.Islands
{
	[Serializable]
	public class WorldGridParams
	{
		public float AnyIslandLocateChance;

		public int GridSize;

		public int MinChunkDistance;

		public int MaxChunkDistance;

		public int ChunkSize;

		public int MinHeight;

		public int MaxHeight;

		public List<IslandSpawnParams> IslandSpawnParams;
	}
}
