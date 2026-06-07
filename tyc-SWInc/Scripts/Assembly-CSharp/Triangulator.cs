using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Triangulation.Polygon;
using UnityEngine;

public class Triangulator
{
	public List<Vector2> Points = new List<Vector2>();

	public Triangulator(IEnumerable<Vector2> points)
	{
		Points = new List<Vector2>(points);
	}

	private List<Vector2[]> JoinHoles(List<Vector2[]> holes)
	{
		List<Vector2[]> list = holes.ToList();
		List<Vector2[]> list2 = new List<Vector2[]>();
		list2.Add(list[0]);
		list.Remove(list2[0]);
		for (int i = 0; i < list2.Count; i++)
		{
			for (int j = 0; j < list.Count; j++)
			{
				Vector2[] array = JoinPolygons(list2[i], list[j]);
				if (array != null)
				{
					list.RemoveAt(j);
					list2.RemoveAt(i);
					list2.Insert(i, array);
					j = -1;
				}
			}
			if (list.Count > 0)
			{
				Vector2[] item = list[0];
				list2.Add(item);
				list.Remove(item);
			}
		}
		return list2;
	}

	private Vector2[] JoinPolygons(Vector2[] a, Vector2[] b)
	{
		int[] array = new int[a.Length];
		for (int i = 0; i < a.Length; i++)
		{
			bool flag = false;
			for (int j = 0; j < b.Length; j++)
			{
				if (a[i] == b[j])
				{
					array[i] = j;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[i] = -1;
			}
		}
		int num = -1;
		int num2 = -1;
		for (int k = 0; k < array.Length; k++)
		{
			int num3 = ((k == 0) ? (array.Length - 1) : (k - 1));
			int num4 = ((k != array.Length - 1) ? (k + 1) : 0);
			if (array[num3] == -1 && array[k] > -1 && array[num4] == -1)
			{
				num = k;
				num2 = array[k];
				break;
			}
		}
		if (num > -1)
		{
			Vector2 vector = a[num] - b[num2];
			vector = new Vector2(0f - vector.y, vector.x).normalized;
			List<Vector2> list = a.ToList();
			List<Vector2> list2 = b.Skip(num2 + 1).Take(b.Length - num2 - 1).Concat(b.Take(num2))
				.ToList();
			list2.Add(b[num2]);
			list.InsertRange(num + 1, list2);
			int num5 = num + b.Length;
			Vector2 obj = ((num == 0) ? list.Last() : list[num - 1]);
			Vector2 vector2 = list[num + 1];
			Vector2 vector3 = (obj + vector2) * 0.5f;
			list[num] += (vector3 - list[num]).normalized;
			Vector2 vector4 = list[num5 - 1];
			vector2 = ((num5 == list.Count - 1) ? list[0] : list[num5 + 1]);
			vector3 = (vector4 + vector2) * 0.5f;
			list[num5] += (vector3 - list[num5]).normalized;
			return list.ToArray();
		}
		return null;
	}

	private Dictionary<int, int> fixPolygons(List<Vector2[]> holes)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<Vector2[]> list = holes.ToList();
		while (list.Count > 0)
		{
			float num = float.PositiveInfinity;
			Vector2[] p = null;
			int num2 = 0;
			int p2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list[i].Length; j++)
				{
					for (int k = 0; k < Points.Count; k++)
					{
						if (!dictionary.ContainsKey(k) && !dictionary.ContainsValue(k))
						{
							float sqrMagnitude = (list[i][j] - Points[k]).sqrMagnitude;
							if (sqrMagnitude < num)
							{
								p = list[i];
								num = sqrMagnitude;
								num2 = j;
								p2 = k;
							}
						}
					}
				}
			}
			if (p[num2] == Points[p2])
			{
				List<Vector2> list2 = p.Reverse().ToList();
				int num3 = num2;
				num2 = p.Length - 1 - num2;
				List<Vector2> list3 = list2.Skip(num2 + 1).Take(list2.Count - num2 - 1).Concat(list2.Take(num2))
					.ToList();
				list3.Add(p[num3]);
				num2 = p.Length - 1;
				Points.InsertRange(p2 + 1, list3);
				num2 += p2 + 1;
				Vector2 vector = ((num2 == Points.Count - 1) ? Points[0] : Points[num2 + 1]);
				Points[num2] += (vector - Points[num2]).normalized;
				dictionary = dictionary.ToDictionary((KeyValuePair<int, int> x) => (x.Key < p2) ? x.Key : (x.Key + p.Length), (KeyValuePair<int, int> x) => (x.Value < p2) ? x.Value : (x.Value + p.Length));
				dictionary[p2] = num2;
			}
			else
			{
				Vector2 vector2 = p[num2] - Points[p2];
				vector2 = new Vector2(0f - vector2.y, vector2.x).normalized;
				Vector2 vector3 = Points[p2];
				num2 = p.Length - 1 - num2;
				List<Vector2> list4 = p.Reverse().ToList();
				Vector2[] shift = list4.Skip(num2).Take(list4.Count - num2).Concat(list4.Take(num2))
					.ToArray();
				Points.InsertRange(p2 + 1, shift);
				dictionary = dictionary.ToDictionary((KeyValuePair<int, int> x) => (x.Key < p2) ? x.Key : (x.Key + shift.Length + 2), (KeyValuePair<int, int> x) => (x.Value < p2) ? x.Value : (x.Value + shift.Length + 2));
				dictionary[p2 + 1] = p2 + shift.Length + 1;
				dictionary[p2] = p2 + shift.Length + 2;
				Points.Insert(p2 + shift.Length + 1, shift.First() - vector2);
				Points.Insert(p2 + shift.Length + 2, vector3 - vector2);
			}
			list.Remove(p);
		}
		return dictionary;
	}

	public int[] Triangulate(IEnumerable<Vector2[]> holes, DTSweepContext context)
	{
		List<PolygonPoint> list = new List<PolygonPoint>();
		PolygonPoint[] array = Points.Select((Vector2 x, int i) => new PolygonPoint(x.x, x.y, i)).ToArray();
		int t = Points.Count;
		Polygon polygon = new Polygon(array);
		list.AddRange(array);
		foreach (Vector2[] hole in holes)
		{
			array = hole.Select((Vector2 x, int i) => new PolygonPoint(x.x, x.y, t + i)).ToArray();
			list.AddRange(array);
			polygon.AddHole(new Polygon(array));
			t += array.Length;
		}
		context.PrepareTriangulation(polygon);
		DTSweep.Triangulate(context);
		context.Clear();
		Points = Points.Concat(holes.SelectMany((Vector2[] x) => x)).ToList();
		return polygon.Triangles.SelectMany((DelaunayTriangle x) => x.Points.Select((TriangulationPoint z) => z.I)).ToArray();
	}

	private List<PolygonPoint> MakeHole(Vector2[] hole, List<PolygonPoint> existingPoints, ref int t)
	{
		List<PolygonPoint> list = new List<PolygonPoint>();
		for (int i = 0; i < hole.Length; i++)
		{
			PolygonPoint polygonPoint = null;
			foreach (PolygonPoint existingPoint in existingPoints)
			{
				if (Mathf.Abs(existingPoint.Xf - hole[i].x) < 0.1f && Mathf.Abs(existingPoint.Yf - hole[i].y) < 0.1f)
				{
					polygonPoint = existingPoint;
					break;
				}
			}
			if (polygonPoint != null)
			{
				list.Add(polygonPoint);
				continue;
			}
			polygonPoint = new PolygonPoint(hole[i].x, hole[i].y, t);
			list.Add(polygonPoint);
			existingPoints.Add(polygonPoint);
			t++;
		}
		return list;
	}

	public int[] Triangulate(IEnumerable<Vector2[]> holes)
	{
		List<Vector2[]> list = holes.ToList();
		if (list.Count == 0)
		{
			return Triangulate();
		}
		Dictionary<int, int> dictionary = fixPolygons(list);
		int[] array = Triangulate();
		foreach (KeyValuePair<int, int> item in dictionary)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == item.Value)
				{
					array[i] = item.Key;
				}
			}
		}
		foreach (int item2 in dictionary.Values.OrderByDescending((int x) => x))
		{
			for (int num = 0; num < array.Length; num++)
			{
				if (array[num] > item2)
				{
					array[num]--;
				}
			}
			Points.RemoveAt(item2);
		}
		return array;
	}

	public int[] Triangulate()
	{
		List<int> list = new List<int>();
		int count = Points.Count;
		if (count < 3)
		{
			return list.ToArray();
		}
		int[] array = new int[count];
		if (Area() > 0f)
		{
			for (int i = 0; i < count; i++)
			{
				array[i] = i;
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				array[j] = count - 1 - j;
			}
		}
		int num = count;
		int num2 = 2 * num;
		int num3 = 0;
		int num4 = num - 1;
		while (num > 2)
		{
			if (num2-- <= 0)
			{
				return list.ToArray();
			}
			int num5 = num4;
			if (num <= num5)
			{
				num5 = 0;
			}
			num4 = num5 + 1;
			if (num <= num4)
			{
				num4 = 0;
			}
			int num6 = num4 + 1;
			if (num <= num6)
			{
				num6 = 0;
			}
			if (Snip(num5, num4, num6, num, array))
			{
				int item = array[num5];
				int item2 = array[num4];
				int item3 = array[num6];
				list.Add(item);
				list.Add(item2);
				list.Add(item3);
				num3++;
				int num7 = num4;
				for (int k = num4 + 1; k < num; k++)
				{
					array[num7] = array[k];
					num7++;
				}
				num--;
				num2 = 2 * num;
			}
		}
		list.Reverse();
		return list.ToArray();
	}

	private float Area()
	{
		int count = Points.Count;
		float num = 0f;
		int index = count - 1;
		int num2 = 0;
		while (num2 < count)
		{
			Vector2 vector = Points[index];
			Vector2 vector2 = Points[num2];
			num += vector.x * vector2.y - vector2.x * vector.y;
			index = num2++;
		}
		return num * 0.5f;
	}

	private bool Snip(int u, int v, int w, int n, int[] V)
	{
		Vector2 a = Points[V[u]];
		Vector2 b = Points[V[v]];
		Vector2 c = Points[V[w]];
		if (Mathf.Epsilon > (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x))
		{
			return false;
		}
		for (int i = 0; i < n; i++)
		{
			if (i != u && i != v && i != w)
			{
				Vector2 p = Points[V[i]];
				if (InsideTriangle(a, b, c, p))
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
	{
		float num = C.x - B.x;
		float num2 = C.y - B.y;
		float num3 = A.x - C.x;
		float num4 = A.y - C.y;
		float num5 = B.x - A.x;
		float num6 = B.y - A.y;
		float num7 = P.x - A.x;
		float num8 = P.y - A.y;
		float num9 = P.x - B.x;
		float num10 = P.y - B.y;
		float num11 = P.x - C.x;
		float num12 = P.y - C.y;
		float num13 = num * num10 - num2 * num9;
		float num14 = num5 * num8 - num6 * num7;
		float num15 = num3 * num12 - num4 * num11;
		if (num13 >= 0f && num15 >= 0f)
		{
			return num14 >= 0f;
		}
		return false;
	}
}
