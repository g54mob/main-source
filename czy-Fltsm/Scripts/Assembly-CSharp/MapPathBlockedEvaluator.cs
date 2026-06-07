using PajamaLlama.Math;

public class MapPathBlockedEvaluator : MapPath.IStateEvaluator
{
	private WorldMap _worldMap;

	private float _radiusSquared;

	public MapPathBlockedEvaluator(WorldMap worldMap, float radius)
	{
		_worldMap = worldMap;
		_radiusSquared = radius * radius;
	}

	public MapPath.State ReturnEvaluatedState(MapPath mapPath)
	{
		if (_worldMap.HasLandmarkInSquareRadius(mapPath.Destination.Vector2TopDown(), _radiusSquared))
		{
			return MapPath.State.DestinationBlocked;
		}
		return MapPath.State.Ok;
	}
}
