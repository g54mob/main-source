public interface IWorldTileProvider
{
	WorldTile GetNextWorldTile(World world, ILandmarkPicker landmarkPicker = null);
}
