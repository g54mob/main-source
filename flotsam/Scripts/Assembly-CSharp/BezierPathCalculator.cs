using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Map/Bezier Path Calculator")]
public class BezierPathCalculator : MapPathCalculator
{
	[SerializeField]
	private float _bezierSmoothness = 0.25f;

	[SerializeField]
	private int _bezierResolution = 10;

	public override void CalculatePath(MapPath mapPath, Vector3 from, Vector3 to)
	{
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		Vector2 startPosition = from.Vector2TopDown();
		Vector2 endPosition = to.Vector2TopDown();
		CalculatePointsOnPath(mapPath.Obstacles, startPosition, endPosition, list);
		CalculateBezierPathPoints(mapPath, startPosition, endPosition, list);
	}

	private void CalculateBezierPathPoints(MapPath path, Vector2 startPosition, Vector2 endPosition, List<Vector2> positions)
	{
		if (positions.IsNullOrEmpty())
		{
			return;
		}
		Vector2 vector = startPosition;
		Vector2 vector2 = positions[0];
		int count = positions.Count;
		int num = count - 1;
		float num2 = _bezierResolution;
		for (int i = 1; i < count; i++)
		{
			Vector2 vector3 = positions[i];
			float num3 = (vector2 - vector3).magnitude / 2f;
			Vector2 vector4 = (endPosition - vector).normalized * num3 * _bezierSmoothness;
			Vector2 startCurve;
			Vector2 endCurve;
			if (i == 1)
			{
				startCurve = Vector2.Lerp(vector2, vector3, 0.5f);
				endCurve = vector3 - vector4;
			}
			else
			{
				startCurve = vector2 + vector4;
				endCurve = ((i != num) ? (vector3 - vector4) : Vector2.Lerp(vector2, vector3, 0.5f));
			}
			for (int j = 0; j <= _bezierResolution; j++)
			{
				path.AddPathPoint(Bezier.CalculateBezierPoint((float)j / num2, vector2, startCurve, endCurve, vector3));
			}
			vector = vector2;
			vector2 = vector3;
		}
	}
}
