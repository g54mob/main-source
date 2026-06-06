using System.Collections.Generic;
using UnityEngine;

public abstract class MapPathCalculator : ScriptableObject
{
	public abstract void CalculatePath(MapPath path, Vector3 from, Vector3 to);

	protected void CalculatePointsOnPath(List<MapObstacle> obstacles, Vector2 startPosition, Vector2 endPosition, List<Vector2> points)
	{
		points.Add(startPosition);
		MapObstacle obstacle;
		Vector2 projection;
		while (TryReturnClosestIntersectingObstacle(obstacles, startPosition, endPosition, out obstacle, out projection))
		{
			Vector2 normalized = (projection - obstacle.Position).normalized;
			startPosition = obstacle.Position + normalized * obstacle.Radius;
			points.Add(startPosition);
		}
		points.Add(endPosition);
	}

	protected bool TryReturnClosestIntersectingObstacle(List<MapObstacle> obstacles, Vector2 startPosition, Vector3 endPosition, out MapObstacle obstacle, out Vector2 projection)
	{
		float num = float.MaxValue;
		obstacle = null;
		projection = Vector2.zero;
		for (int i = 0; i < obstacles.Count; i++)
		{
			MapObstacle mapObstacle = obstacles[i];
			if (!mapObstacle.HasPointInRadius(startPosition) && !mapObstacle.HasPointInRadius(endPosition) && mapObstacle.IsIntersecting(startPosition, endPosition, out var projectionPoint))
			{
				float sqrMagnitude = (mapObstacle.Position - startPosition).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					obstacle = mapObstacle;
					num = sqrMagnitude;
					projection = projectionPoint;
				}
			}
		}
		return obstacle != null;
	}
}
