using PugTilemap;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct CrackableTileCD : IComponentData, IQueryTypeParameter
{
	public TileType crackTileType;

	public Tileset crackTileset;

	public TileType baseTileType;

	public int currentLevel;
}
