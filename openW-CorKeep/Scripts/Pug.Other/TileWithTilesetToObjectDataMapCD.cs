using Unity.Collections;
using Unity.Entities;

public struct TileWithTilesetToObjectDataMapCD : IComponentData, IQueryTypeParameter
{
	public NativeHashMap<TileTypeTileSetTuple, ObjectDataCD> lookup;
}
