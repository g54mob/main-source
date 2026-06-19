using Unity.Entities;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct UniqueDungeonSpawnPosition : IBufferElementData
	{
		public int2 Position;

		public bool HasBeenSpawned;

		public PugWorldGenCD SpawnEntry;
	}
}
