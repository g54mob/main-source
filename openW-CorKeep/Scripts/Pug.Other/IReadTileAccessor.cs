using System;
using PugTilemap;
using Unity.Collections;
using Unity.Mathematics;

public interface IReadTileAccessor
{
	bool HasType(int2 worldPosition, TileType tileType);

	bool HasTypeAndTileset(int2 worldPosition, TileType tileType, int tileset);

	bool GetType(int2 worldPosition, TileType tileType, out TileCD tileCD);

	TileCD GetTopDamageableTile(int2 worldPosition);

	[Obsolete("Deprecated in 1.1.2.2 in favor of TryGetBlockingTile. Will get removed in a future update.")]
	TileCD GetBlockingTile(int2 worldPosition, bool includeLowColliders = true);

	bool TryGetBlockingTile(int2 worldPosition, out TileCD tileCD, bool includeLowColliders = true);

	NativeArray<TileCD> Get(int2 worldPosition, Allocator allocator);

	TileCD GetTop(int2 worldPosition);

	TileType GetTopType(int2 worldPosition);

	int GetSurfacePriority(TileType tileType);
}
