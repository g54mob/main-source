using System.Collections.Generic;
using UnityEngine;

public class CatmullRom
{
	public static void FillSegment(Vector3[] output, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		for (int i = 0; i < output.Length; i++)
		{
			float num = (float)i / (float)(output.Length - 1);
			Vector3 vector = 0.5f * (2f * p1 + (-p0 + p2) * num + (2f * p0 - 5f * p1 + 4f * p2 - p3) * (num * num) + (-p0 + 3f * p1 - 3f * p2 + p3) * (num * num * num));
			output[i] = vector;
		}
	}

	public static IEnumerable<Vector3> IterateLine(int numPointsPerSegment, List<Vector3> points)
	{
		Vector3[] segment = new Vector3[numPointsPerSegment];
		for (int i = 0; i < points.Count - 1; i++)
		{
			int i2 = Mathf.Max(0, i - 1);
			int i3 = i;
			int i4 = Mathf.Min(points.Count - 1, i + 1);
			FillSegment(p3: points[Mathf.Min(points.Count - 1, i + 2)], output: segment, p0: points[i2], p1: points[i3], p2: points[i4]);
			int numSegPoints = ((i != points.Count - 2) ? (segment.Length - 1) : segment.Length);
			for (int j = 0; j < numSegPoints; j++)
			{
				yield return segment[j];
			}
		}
	}
}
