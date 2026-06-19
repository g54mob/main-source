using Unity.Entities;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct DungeonSpawnedObjectBuffer : IBufferElementData
	{
		public int2 position;

		public ObjectData objectData;

		public LootTableID loot;

		public Entity prefabEntity;

		public float2 prefabEntityPosition;

		public int optionalSceneIndex;

		public int optionalScenePrefabIndex;
	}
}
