using Pug.Conversion;
using Unity.Entities;

namespace PugWorldGen
{
	public class DungeonSpawnTableConverter : SingleAuthoringComponentConverter<DungeonSpawnTable>
	{
		protected override void Convert(DungeonSpawnTable authoring)
		{
			EnsureHasBuffer<DungeonBiomeSpawnTableBuffer>();
			foreach (DungeonSpawnTable.DungeonSpawnTableBiome biome in authoring.biomes)
			{
				biome.spawnEntries.Sort((DungeonSpawnTable.DungeonSpawnTableEntry a, DungeonSpawnTable.DungeonSpawnTableEntry c) => a.spawnChance.CompareTo(c.spawnChance));
				Entity entity = CreateAdditionalEntity();
				EnsureHasBuffer<DungeonSpawnTableBuffer>(entity);
				float num = 0f;
				foreach (DungeonSpawnTable.DungeonSpawnTableEntry spawnEntry in biome.spawnEntries)
				{
					if (!(spawnEntry.prefab == null))
					{
						DungeonSpawnTableBuffer elementData = new DungeonSpawnTableBuffer
						{
							name = spawnEntry.prefab.name,
							prefabEntity = GetPrefabDependency(spawnEntry.prefab),
							spawnValue = spawnEntry.spawnChance + num,
							spawnChance = spawnEntry.spawnChance
						};
						num += spawnEntry.spawnChance;
						AddToBuffer(entity, elementData);
					}
				}
				AddToBuffer(new DungeonBiomeSpawnTableBuffer
				{
					tableEntity = entity,
					biome = biome.biome,
					minDistanceFromCoreInClassicWorlds = biome.minDistanceFromCoreInClassicWorlds
				});
			}
		}
	}
}
