using Unity.Collections;
using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonSpawnTableBuffer : IBufferElementData
	{
		public FixedString32Bytes name;

		public Entity prefabEntity;

		public float spawnValue;

		public float spawnChance;
	}
}
