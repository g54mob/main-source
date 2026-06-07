using System.Collections.Generic;
using UnityEngine;

public class PointCloudGestureTemplate : ScriptableObject
{
	[SerializeField]
	private List<int> strokeIds;

	[SerializeField]
	private List<Vector2> positions;

	[SerializeField]
	private int strokeCount;

	[SerializeField]
	private Vector2 size = Vector2.zero;

	public Vector2 Size => size;

	public float Width => size.x;

	public float Height => size.y;

	public int PointCount => positions.Count;

	public int StrokeCount => strokeCount;

	private void Awake()
	{
		if (positions == null)
		{
			positions = new List<Vector2>();
		}
		if (strokeIds == null)
		{
			strokeIds = new List<int>();
		}
	}

	public void BeginPoints()
	{
		positions.Clear();
		strokeIds.Clear();
		strokeCount = 0;
		size = Vector2.zero;
	}

	public void AddPoint(int stroke, Vector2 p)
	{
		strokeIds.Add(stroke);
		positions.Add(p);
	}

	public void AddPoint(int stroke, float x, float y)
	{
		AddPoint(stroke, new Vector2(x, y));
	}

	public void EndPoints()
	{
		Normalize();
		List<int> list = new List<int>();
		for (int i = 0; i < strokeIds.Count; i++)
		{
			int item = strokeIds[i];
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}
		strokeCount = list.Count;
		MakeDirty();
	}

	public Vector2 GetPosition(int pointIndex)
	{
		return positions[pointIndex];
	}

	public int GetStrokeId(int pointIndex)
	{
		return strokeIds[pointIndex];
	}

	public void Normalize()
	{
		Vector2 vector = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
		Vector2 vector2 = new Vector2(float.NegativeInfinity, float.NegativeInfinity);
		for (int i = 0; i < positions.Count; i++)
		{
			Vector2 vector3 = positions[i];
			vector.x = Mathf.Min(vector.x, vector3.x);
			vector.y = Mathf.Min(vector.y, vector3.y);
			vector2.x = Mathf.Max(vector2.x, vector3.x);
			vector2.y = Mathf.Max(vector2.y, vector3.y);
		}
		float num = vector2.x - vector.x;
		float num2 = vector2.y - vector.y;
		float num3 = Mathf.Max(num, num2);
		float num4 = 1f / num3;
		size.x = num * num4;
		size.y = num2 * num4;
		Vector2 vector4 = -0.5f * size;
		for (int j = 0; j < positions.Count; j++)
		{
			positions[j] = (positions[j] - vector) * num4 + vector4;
		}
	}

	private void MakeDirty()
	{
	}
}
