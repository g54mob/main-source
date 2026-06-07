using PajamaLlama.Flotsam.World;
using UnityEngine;

public abstract class WorldTileProviderBase : ScriptableObject, IWorldTileProvider
{
	public bool TryGetNextWorldTile(out WorldTile worldTile, World world, ILandmarkPicker landmarkPicker = null)
	{
		worldTile = GetNextWorldTile(world, landmarkPicker);
		return worldTile != null;
	}

	public abstract WorldTile GetNextWorldTile(World world, ILandmarkPicker landmarkPicker = null);

	public abstract bool Contains(TileGeneratorBase tile);

	public bool Contains(WorldTile worldTile)
	{
		return Contains(worldTile.SubTileGeneratorPrefab);
	}
}
