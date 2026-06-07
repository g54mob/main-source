public interface IPolygonProvider
{
	Polygon Polygon { get; }

	bool TryGetPathfindingPolygons(out Polygon[] pathfindingPolygons);
}
