using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct CustomSceneBlob
{
	public FixedString64Bytes sceneName;

	public BlobArray<TileCD> tiles;

	public BlobArray<int2> tilePositions;

	public BlobArray<Entity> prefabs;

	public BlobArray<float3> prefabPositions;

	public BlobArray<OptionalValue<float3>> prefabDirections;

	public BlobArray<OptionalValue<PaintableColor>> prefabColors;

	public BlobArray<InventoryOverrideData> prefabInventoryOverrides;

	public BlobArray<int2> prefabSizes;

	public BlobArray<int2> prefabCornerOffsets;

	public BlobArray<ObjectDataCD> prefabObjectDatas;

	public int2 centerPosition;

	public bool canFlipX;

	public bool canFlipY;

	public int maxOccurrences;

	public OptionalValue<DataBlockAddress> replacedByContentBundle;

	public WorldGenerationTypeDependentValue<BlobArray<Biome>> biomesToSpawnIn;

	public int minDistanceFromCoreInClassicWorlds;

	public bool hasCenter;

	public int2 center;

	public int2 boundsSize;

	public float radius;
}
