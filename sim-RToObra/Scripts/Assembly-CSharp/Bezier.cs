using System.Collections.Generic;
using UnityEngine;

public class Bezier
{
	private struct AutoSmoothNode
	{
		public Vector3 p1;

		public Vector3 p2;

		public float a;

		public float b;

		public float c;

		public Vector3 r;

		public void Init(float a_, float b_, float c_, Vector3 r_)
		{
			a = a_;
			b = b_;
			c = c_;
			r = r_;
		}
	}

	public static IEnumerable<Vector3> IterateLine(int numPointsPerSegment, List<Vector3> points)
	{
		for (int i = 0; i < points.Count - 3; i += 3)
		{
			int i2 = i;
			int i3 = i + 1;
			int i4 = i + 2;
			int i5 = i + 3;
			for (int j = 0; j < numPointsPerSegment; j++)
			{
				float t = (float)j / (float)numPointsPerSegment;
				float t2 = t * t;
				float t3 = t * t2;
				float s = 1f - t;
				float s2 = s * s;
				float s3 = s * s2;
				yield return s3 * points[i2] + 3f * s2 * t * points[i3] + 3f * s * t2 * points[i4] + t3 * points[i5];
			}
		}
		if (points.Count > 0)
		{
			yield return points[points.Count - 1];
		}
	}

	public static List<Vector3> AutoSmoothed(List<Vector3> k)
	{
		List<Vector3> list = new List<Vector3>();
		if (k.Count == 2)
		{
			list.Add(k[0]);
			list.Add(k[0]);
			list.Add(k[1]);
			list.Add(k[1]);
			return list;
		}
		int num = k.Count - 1;
		AutoSmoothNode[] array = new AutoSmoothNode[num];
		array[0].Init(0f, 2f, 1f, k[0] + 2f * k[1]);
		for (int i = 1; i < num - 1; i++)
		{
			array[i].Init(1f, 4f, 1f, 4f * k[i] + 2f * k[i + 1]);
		}
		array[num - 1].Init(2f, 7f, 0f, 8f * k[num - 1] + k[num]);
		for (int j = 1; j < num; j++)
		{
			AutoSmoothNode autoSmoothNode = array[j];
			AutoSmoothNode autoSmoothNode2 = array[j - 1];
			float num2 = autoSmoothNode.a / autoSmoothNode2.b;
			array[j].b = autoSmoothNode.b - num2 * autoSmoothNode2.c;
			array[j].r = autoSmoothNode.r - num2 * autoSmoothNode2.r;
		}
		array[num - 1].p1 = array[num - 1].r / array[num - 1].b;
		for (int num3 = num - 2; num3 >= 0; num3--)
		{
			array[num3].p1 = (array[num3].r - array[num3].c * array[num3 + 1].p1) / array[num3].b;
		}
		for (int l = 0; l < num - 1; l++)
		{
			array[l].p2 = 2f * k[l + 1] - array[l + 1].p1;
		}
		Vector3 vector = k[num];
		Vector3 vector2 = 0.5f * (k[num] + array[num - 1].p1);
		array[num - 1].p2 = vector + (vector2 - vector) * 1f;
		for (int m = 0; m < num; m++)
		{
			list.Add(k[m]);
			list.Add(array[m].p1);
			list.Add(array[m].p2);
		}
		list.Add(k[num]);
		return list;
	}
}
