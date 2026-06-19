using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonBiomeSpawnTableBuffer : IBufferElementData
	{
		public Entity tableEntity;

		public WorldGenerationTypeDependentValue<Biome> biome;

		public int minDistanceFromCoreInClassicWorlds;
	}
}
