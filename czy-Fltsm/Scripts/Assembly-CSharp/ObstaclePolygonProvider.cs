using UnityEngine;

public class ObstaclePolygonProvider : MonoBehaviour, IPolygonProvider
{
	[SerializeField]
	private Polygon _mapPolygon;

	[SerializeField]
	private Polygon[] _polygons;

	public Polygon Polygon => _mapPolygon;

	private void OnDrawGizmos()
	{
		_mapPolygon.DrawVertices(Color.yellow);
		Polygon[] polygons = _polygons;
		for (int i = 0; i < polygons.Length; i++)
		{
			polygons[i].DrawVertices(Color.white);
		}
	}

	public bool TryGetPathfindingPolygons(out Polygon[] pathfindingPolygons)
	{
		pathfindingPolygons = _polygons;
		return !_polygons.IsNullOrEmpty();
	}
}
