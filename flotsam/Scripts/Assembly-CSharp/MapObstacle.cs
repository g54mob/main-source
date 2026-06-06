using UnityEngine;

public class MapObstacle
{
	private float _poweredRadius;

	public Vector2 Position { get; private set; }

	public float Radius { get; private set; }

	public MapObstacle(Vector2 position, float radius)
	{
		Position = position;
		Radius = radius;
		_poweredRadius = Mathf.Pow(Radius, 2f);
	}

	public bool HasPointInRadius(Vector2 position)
	{
		Vector2 vector = Position - position;
		if (!(vector.sqrMagnitude <= _poweredRadius))
		{
			return Mathf.Approximately(vector.sqrMagnitude, _poweredRadius);
		}
		return true;
	}

	private Vector2 ReturnProjectedPoint(Vector2 lineStart, Vector2 lineEnd, out bool canProject)
	{
		Vector2 vector = lineEnd - lineStart;
		float sqrMagnitude = (lineEnd - lineStart).sqrMagnitude;
		float num = ((Position.x - lineStart.x) * (lineEnd.x - lineStart.x) + (Position.y - lineStart.y) * (lineEnd.y - lineStart.y)) / sqrMagnitude;
		canProject = num >= 0f && num <= 1f;
		return lineStart + num * vector;
	}

	public bool IsIntersecting(Vector2 lineStart, Vector2 lineEnd, out Vector2 projectionPoint)
	{
		projectionPoint = Vector2.zero;
		if (HasPointInRadius(lineEnd))
		{
			return true;
		}
		projectionPoint = ReturnProjectedPoint(lineStart, lineEnd, out var canProject);
		if (!canProject)
		{
			return false;
		}
		return (projectionPoint - Position).sqrMagnitude <= _poweredRadius;
	}
}
