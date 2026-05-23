using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SharpCornerMidigator : MonoModifier
{
	public float extendCorners = 2f;

	private List<Vector3> path;

	private Vector3 pathPointLast;

	private Vector2 toLastPoint;

	private Vector2 toNextPoint;

	private float angle;

	private Vector2 normal2d;

	private float strngth;

	private Vector3 normal;

	public override int Order => 100;

	public override void Apply(Path _p)
	{
		if (_p.path != null && _p.path.Count != 0 && _p.vectorPath != null && _p.vectorPath.Count != 0)
		{
			path = _p.vectorPath;
			pathPointLast = path[0];
			for (int i = 1; i < path.Count - 1; i++)
			{
				toLastPoint = new Vector2(pathPointLast.x, pathPointLast.z) - new Vector2(path[i].x, path[i].z);
				toNextPoint = new Vector2(path[i + 1].x, path[i + 1].z) - new Vector2(path[i].x, path[i].z);
				angle = Vector2.Angle(toLastPoint, toNextPoint);
				normal2d = -(toLastPoint.normalized + toNextPoint.normalized).normalized;
				strngth = (180f - angle) / 180f;
				normal = new Vector3(normal2d.x, 0f, normal2d.y);
				pathPointLast = path[i];
				path[i] += normal * strngth * extendCorners;
			}
		}
	}
}
