using UnityEngine;

public class LandmarkMapObstacle : MapObstacle
{
	public WorldMapLandmark MapLandmark { get; private set; }

	public LandmarkMapObstacle(WorldMapLandmark mapLandmark, Vector2 position, float radius)
		: base(position, radius)
	{
		MapLandmark = mapLandmark;
	}
}
