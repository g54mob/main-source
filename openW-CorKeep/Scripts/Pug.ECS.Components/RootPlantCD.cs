using PugTilemap;
using Unity.Collections;
using Unity.Entities;

public struct RootPlantCD : IComponentData, IQueryTypeParameter
{
	public Tileset tileset;

	public float minTimeBetweenSpread;

	public float maxTimeBetweenSpread;

	public FixedList64Bytes<Tileset> allowedTilesets;
}
