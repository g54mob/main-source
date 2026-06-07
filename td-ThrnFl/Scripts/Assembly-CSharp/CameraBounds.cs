using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CameraBounds : ScriptableObject
{
	public List<Vector2> bounds = new List<Vector2>();

	private List<Vector2> boundsToUse = new List<Vector2>();

	public void PrepareBounds(float offset)
	{
		boundsToUse = new List<Vector2>(bounds);
		for (int i = 0; i < 10; i++)
		{
			GrowShrinkPoly(boundsToUse, offset / 10f, offset / 10f * 2f);
		}
		MakeBoundsConvex(boundsToUse);
	}

	public static void GrowShrinkPoly(List<Vector2> bounds, float offset, float minDistance)
	{
		int count = bounds.Count;
		for (int i = 0; i < count; i++)
		{
			Vector2 vector = bounds[(i - 1 + count) % count];
			Vector2 vector2 = bounds[i];
			Vector2 vector3 = bounds[(i + 1) % count];
			Vector2 normalized = (vector2 - vector).normalized;
			Vector2 normalized2 = (vector3 - vector2).normalized;
			Vector2 vector4 = new Vector2(0f - normalized.y, normalized.x);
			Vector2 vector5 = new Vector2(0f - normalized2.y, normalized2.x);
			Vector2 vector6 = (vector4 + vector5) / 2f;
			Vector2 vector7 = vector2 + vector6 * offset;
			float num = Vector2.Distance(vector7, vector);
			float num2 = Vector2.Distance(vector7, vector3);
			if (num >= minDistance && num2 >= minDistance)
			{
				bounds[i] = vector7;
			}
		}
	}

	public static void BevelPolygon(List<Vector2> bounds, float percentageOfSideLength)
	{
		List<Vector2> list = new List<Vector2>();
		for (int i = 0; i < bounds.Count; i++)
		{
			Vector2 vector = bounds[(i - 1 + bounds.Count) % bounds.Count];
			Vector2 vector2 = bounds[i];
			Vector2 vector3 = bounds[(i + 1) % bounds.Count];
			Vector2 normalized = (vector - vector2).normalized;
			Vector2 normalized2 = (vector3 - vector2).normalized;
			float num = (vector - vector2).magnitude * percentageOfSideLength;
			float num2 = (vector3 - vector2).magnitude * percentageOfSideLength;
			Vector2 item = vector2 + normalized * num;
			Vector2 item2 = vector2 + normalized2 * num2;
			list.Add(item);
			list.Add(item2);
		}
		bounds.Clear();
		bounds.AddRange(list);
	}

	public static void DrawPolygonDebug(List<Vector2> bounds, float height)
	{
		int count = bounds.Count;
		for (int i = 0; i < count; i++)
		{
			Vector3 start = new Vector3(bounds[i].x, height, bounds[i].y);
			Vector3 end = new Vector3(bounds[(i + 1) % count].x, height, bounds[(i + 1) % count].y);
			Debug.DrawLine(start, end, Color.red, Time.deltaTime * 3f);
		}
	}

	public static void MakeBoundsConvex(List<Vector2> bounds)
	{
		int num = 0;
		while (num < bounds.Count)
		{
			Vector2 vector = bounds[num];
			Vector2 vector2 = bounds[(num + 1) % bounds.Count];
			Vector2 vector3 = bounds[(num + 2) % bounds.Count];
			float current = Mathf.Atan2(vector.y - vector2.y, vector.x - vector2.x) * 57.29578f;
			float target = Mathf.Atan2(vector3.y - vector2.y, vector3.x - vector2.x) * 57.29578f;
			if (Mathf.DeltaAngle(current, target) <= 0f)
			{
				bounds.RemoveAt((num + 1) % bounds.Count);
			}
			else
			{
				num++;
			}
		}
	}

	public bool IsInBounds(Vector2 point)
	{
		bool flag = false;
		int num = 0;
		int index = boundsToUse.Count - 1;
		while (num < boundsToUse.Count)
		{
			if (boundsToUse[num].y > point.y != boundsToUse[index].y > point.y && point.x < (boundsToUse[index].x - boundsToUse[num].x) * (point.y - boundsToUse[num].y) / (boundsToUse[index].y - boundsToUse[num].y) + boundsToUse[num].x)
			{
				flag = !flag;
			}
			index = num++;
		}
		return flag;
	}

	public Vector2 ClosestPointOnBounds(Vector2 point)
	{
		Vector2 result = default(Vector2);
		float num = float.MaxValue;
		int num2 = 0;
		int index = boundsToUse.Count - 1;
		while (num2 < boundsToUse.Count)
		{
			Vector2 vector = boundsToUse[index];
			Vector2 vector2 = boundsToUse[num2];
			float num3 = Vector2.Dot(point - vector, vector2 - vector) / Vector2.Dot(vector2 - vector, vector2 - vector);
			Vector2 vector3 = ((num3 < 0f) ? vector : ((!(num3 > 1f)) ? (vector + num3 * (vector2 - vector)) : vector2));
			float sqrMagnitude = (vector3 - point).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = vector3;
			}
			index = num2++;
		}
		return result;
	}
}
