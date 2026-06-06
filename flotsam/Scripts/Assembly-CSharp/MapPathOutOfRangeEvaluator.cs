public class MapPathOutOfRangeEvaluator : MapPath.IStateEvaluator
{
	private Engine _engine;

	public MapPathOutOfRangeEvaluator(Engine engine)
	{
		_engine = engine;
	}

	public MapPath.State ReturnEvaluatedState(MapPath mapPath)
	{
		if (_engine.ReturnEnergyRange() < mapPath.Length)
		{
			return MapPath.State.DestinationOutOfRange;
		}
		return MapPath.State.Ok;
	}
}
