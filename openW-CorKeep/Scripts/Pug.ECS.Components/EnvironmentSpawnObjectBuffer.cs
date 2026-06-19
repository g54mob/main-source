using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;

[InternalBufferCapacity(0)]
public struct EnvironmentSpawnObjectBuffer : IBufferElementData
{
	public bool respawn;

	public ObjectID objectId;

	public BlobAssetReference<BlobArray<int>> variations;

	public BlobAssetReference<BlobArray<float>> accumulatedVariationProbability;

	public int amount;

	public bool isTile;

	public TileType tileType;

	public Tileset tileset;

	public WorldGenSettingDependentValue<float> spawnChance;

	public float maxSpawnPerTile;

	public float respawnChanceDecay;

	public float minTilesRequiredToRespawn;

	public int maxSpawnsPerRespawn;

	public FixedList64Bytes<TileRequirement> adjacentTiles;

	public EnvironmentObjectSpawnAlgorithm spawnAlgorithm;

	public float clusterSpawnChance;

	public float clusterSpreadChance;

	public ClusterSpreadType clusterSpreadType;

	public Biome spawnsInBiome;

	public bool canSpawnInBlockedArea;

	public bool skipSpawnForPartialMap;

	public RangeInt mustBeWithinDistanceFromCore;

	public TileType spawnsOnTileType;

	public FixedList32Bytes<Tileset> onlySpawnsOnTilesets;

	public int alsoSpawnNextNObjectsFromSameBiome;
}
