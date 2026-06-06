using System;
using M4.Session;
using UnityEngine;

[CreateAssetMenu(fileName = "FallbackWorldTileProvider", menuName = "Flotsam/World/Fallback World Tile Provider")]
public class FallbackWorldTileProvider : WorldTileProvider
{
	public override WorldTile GetNextWorldTile(World world, ILandmarkPicker landmarkPicker = null)
	{
		WorldTile nextWorldTile = base.GetNextWorldTile(world, landmarkPicker);
		if (nextWorldTile == null)
		{
			Debug.LogException(new Exception("FallbackWorldTileProvider was unable to generate a world tile the LandmarkPicker could pick from, falling back to a random tile."));
			return nextWorldTile;
		}
		if (Session.Profile.ActiveRun.IsDebugRun)
		{
			Debug.LogError("FallbackWorldTileProvider was used to get the next WorldTile");
			return nextWorldTile;
		}
		Debug.LogException(new Exception("FallbackWorldTileProvider was used to get the next WorldTile"));
		return nextWorldTile;
	}
}
