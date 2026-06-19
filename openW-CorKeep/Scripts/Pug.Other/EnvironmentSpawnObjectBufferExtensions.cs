using PugTilemap;
using Unity.Collections;
using Unity.Mathematics;

public static class EnvironmentSpawnObjectBufferExtensions
{
	public static float SpawnChance(this EnvironmentSpawnObjectBuffer b, int2 pos, ref TileAccessor tileLookup, ref BiomeLookup biomeLookup, int2 left, int2 right, int2 top, int2 bot, bool respawn, int alreadyExistingAmount, NativeArray<WorldGenerationSettingLevel> worldGenSettings)
	{
		bool flag = true;
		if (b.mustBeWithinDistanceFromCore.max > 0)
		{
			float num = math.length(pos);
			flag = (float)b.mustBeWithinDistanceFromCore.min <= num && (float)b.mustBeWithinDistanceFromCore.max >= num;
		}
		if (flag)
		{
			flag = b.spawnsInBiome == Biome.None || biomeLookup.GetBiome(pos) == b.spawnsInBiome;
		}
		if (flag)
		{
			TileCD top2 = tileLookup.GetTop(pos);
			bool flag2 = b.onlySpawnsOnTilesets.Length == 0;
			for (int i = 0; i < b.onlySpawnsOnTilesets.Length; i++)
			{
				if (b.onlySpawnsOnTilesets[i] == (Tileset)top2.tileset)
				{
					flag2 = true;
					break;
				}
			}
			flag = top2.tileType == b.spawnsOnTileType && flag2;
		}
		if (!flag)
		{
			return 0f;
		}
		float num2 = b.spawnChance.GetValue(worldGenSettings[(int)b.spawnChance.worldGenSetting]);
		if (respawn)
		{
			num2 = b.GetRespawnChance(num2, alreadyExistingAmount);
		}
		float result = ((b.adjacentTiles.Length == 0) ? num2 : 0f);
		for (int j = 0; j < b.adjacentTiles.Length; j++)
		{
			TileRequirement tileRequirement = b.adjacentTiles[j];
			bool flag3 = false;
			if ((!tileRequirement.mustAlsoMatchTileset) ? ((tileLookup.GetType(pos + left, tileRequirement.tileType, out var tileCD) && tileCD.tileset != 2) || (tileLookup.GetType(pos + right, tileRequirement.tileType, out var tileCD2) && tileCD2.tileset != 2) || (tileLookup.GetType(pos + top, tileRequirement.tileType, out var tileCD3) && tileCD3.tileset != 2) || (tileLookup.GetType(pos + bot, tileRequirement.tileType, out var tileCD4) && tileCD4.tileset != 2)) : (tileLookup.HasTypeAndTileset(pos + left, tileRequirement.tileType, (int)tileRequirement.tileset) || tileLookup.HasTypeAndTileset(pos + right, tileRequirement.tileType, (int)tileRequirement.tileset) || tileLookup.HasTypeAndTileset(pos + top, tileRequirement.tileType, (int)tileRequirement.tileset) || tileLookup.HasTypeAndTileset(pos + bot, tileRequirement.tileType, (int)tileRequirement.tileset)))
			{
				result = num2;
				break;
			}
		}
		return result;
	}

	private static float GetRespawnChance(this EnvironmentSpawnObjectBuffer buffer, float respawn, int alreadyExistingAmount)
	{
		if (buffer.respawnChanceDecay > 0f)
		{
			return respawn * math.pow(1f - buffer.respawnChanceDecay, alreadyExistingAmount);
		}
		return respawn;
	}

	public static bool ShouldSpawn(this EnvironmentSpawnObjectBuffer buffer, int2 pos, ref Random rng, ref TileAccessor tileLookup, ref BiomeLookup biomeLookup, int2 left, int2 right, int2 top, int2 bot, bool respawn, int alreadyExistingAmount, float spawnChanceMultiplier, NativeArray<WorldGenerationSettingLevel> worldGenSettings)
	{
		float num = buffer.SpawnChance(pos, ref tileLookup, ref biomeLookup, left, right, top, bot, respawn, alreadyExistingAmount, worldGenSettings);
		num *= spawnChanceMultiplier;
		return rng.NextFloat() < num;
	}
}
