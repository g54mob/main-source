using System.Collections.Generic;
using UnityEngine;

public class MathEquations
{
	public static Vector3Int ConvertToVector3Int(Vector3 vector3)
	{
		return new Vector3Int(Mathf.RoundToInt(vector3.x) - 1, Mathf.RoundToInt(vector3.y) - 1, Mathf.RoundToInt(vector3.z));
	}

	public static float GetPivotPoints(float width, float height)
	{
		if (width == 16f)
		{
			return width / height;
		}
		if (height == 16f)
		{
			return height / width;
		}
		return 1f;
	}

	public static List<T> Shuffle<T>(List<T> ts)
	{
		int count = ts.Count;
		int num = count - 1;
		for (int i = 0; i < num; i++)
		{
			int index = Random.Range(i, count);
			T value = ts[i];
			ts[i] = ts[index];
			ts[index] = value;
		}
		return ts;
	}
}
