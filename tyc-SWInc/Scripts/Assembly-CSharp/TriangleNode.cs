using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriangleNode
{
	public struct Portal
	{
		public readonly Vector2 Left;

		public readonly Vector2 Right;

		public Portal(Vector2 l, Vector2 r)
		{
			Left = l;
			Right = r;
		}

		public Portal(Vector2 b)
		{
			Left = b;
			Right = b;
		}
	}

	public static uint MainPathToggle = 0u;

	public bool StartEnd;

	public Vector2 Center;

	public Vector2[] Points;

	public Vector2[] PortalPoints;

	public int[] PointIndices;

	public TriangleNode[] Connections = new TriangleNode[3];

	public Dictionary<TriangleNode, float> Weight = new Dictionary<TriangleNode, float>(3);

	public PathNode<TriangleNode> PathNode;

	public Rect rect;

	public float Area;

	public Vector2 preferredPoint = Vector2.zero;

	public uint PathToggle;

	private int HashCode;

	public const float MinSqueezeSqr = 0.16000001f;

	public const float SqueezePenalty = 19f;

	private static readonly Vector2[] PortalCheck = new Vector2[3];

	public override int GetHashCode()
	{
		return HashCode;
	}

	public TriangleNode(Vector2[] points, int[] indices)
	{
		Points = points;
		PortalPoints = Points.ToArray();
		PointIndices = indices;
		bool flag = true;
		HashCode = 0;
		for (int i = 0; i < Points.Length; i++)
		{
			if (flag)
			{
				flag = false;
				HashCode = Points[i].x.GetHashCode();
			}
			else
			{
				HashCode = (HashCode * 397) ^ Points[i].x.GetHashCode();
			}
			HashCode = (HashCode * 397) ^ Points[i].y.GetHashCode();
		}
		Center = Utilities.GetTriangleCentroid(Points);
		PathNode = new PathNode<TriangleNode>(this, this);
		Area = GetArea();
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		for (int j = 0; j < points.Length; j++)
		{
			num = Mathf.Min(points[j].x, num);
			num2 = Mathf.Min(points[j].y, num2);
			num3 = Mathf.Max(points[j].x, num3);
			num4 = Mathf.Max(points[j].y, num4);
		}
		rect = new Rect(num, num2, num3 - num, num4 - num2);
	}

	private bool CheckProjection(Vector2 a, Vector2 b, Vector2 c, float max)
	{
		Vector2 res;
		if (Utilities.ProjectToLine(a, b, c, out res))
		{
			return (a - res).magnitude > max;
		}
		return true;
	}

	public bool IsInside(Vector2 p)
	{
		if (rect.ContainsEntirely(p))
		{
			return InsideTriangle(p, Points[0], Points[1], Points[2]);
		}
		return false;
	}

	public void SetConnection(TriangleNode n, int e, float minWidthPenalty, bool outside)
	{
		if ((Points[e] - Points[(e + 1) % 3]).sqrMagnitude < minWidthPenalty)
		{
			Weight[n] = 20f;
		}
		else
		{
			Weight[n] = (outside ? 0.5f : 1f);
		}
		Connections[e] = n;
		PathNode.AddConnection(n.PathNode);
	}

	public static float CalcPenalty(float squeezeFactor)
	{
		return 19f * (1f - squeezeFactor * (2f - squeezeFactor)) + 1f;
	}

	public void UpdateWeight(bool outside)
	{
		int num = 0;
		for (int i = 0; i < Connections.Length; i++)
		{
			if (Connections[i] == null)
			{
				continue;
			}
			num++;
			float orDefault = Connections[i].Weight.GetOrDefault(this, 1f);
			float sqrMagnitude = (Points[i] - Points[(i + 1) % 3]).sqrMagnitude;
			if (sqrMagnitude < 0.16000001f)
			{
				float num2 = CalcPenalty(sqrMagnitude / 0.16000001f);
				if (num2 > orDefault)
				{
					Weight[Connections[i]] = num2;
					Connections[i].Weight[this] = num2;
				}
			}
			else
			{
				if (outside || Connections[(i + 1) % 3] != null)
				{
					continue;
				}
				sqrMagnitude = 2f * Area / (Points[(i + 2) % 3] - Points[(i + 1) % 3]).magnitude;
				if (sqrMagnitude < 0.16000001f)
				{
					float num3 = CalcPenalty(sqrMagnitude / 0.16000001f);
					if (num3 > orDefault)
					{
						Weight[Connections[i]] = num3;
						Connections[i].Weight[this] = num3;
					}
				}
			}
		}
		if ((!outside && num != 3) || !(Area > 1f))
		{
			return;
		}
		for (int j = 0; j < Connections.Length; j++)
		{
			TriangleNode triangleNode = Connections[j];
			if (triangleNode != null)
			{
				float orDefault2 = Weight.GetOrDefault(triangleNode, 1f);
				float num4 = 0.75f + (1f - (Mathf.Min(2f, Area) - 1f)) * 0.25f;
				if (orDefault2 <= 1f && num4 < orDefault2)
				{
					Weight[triangleNode] = num4;
					triangleNode.Weight[this] = num4;
				}
			}
		}
	}

	public static KeyValuePair<Vector2[], int[]> GenerateMesh(IEnumerable<TriangleNode> nodes)
	{
		Dictionary<Vector2, int> dictionary = new Dictionary<Vector2, int>();
		List<int> list = new List<int>();
		int num = 0;
		foreach (TriangleNode node in nodes)
		{
			for (int i = 0; i < 3; i++)
			{
				int value = -1;
				if (dictionary.TryGetValue(node.PortalPoints[i], out value))
				{
					list.Add(value);
					continue;
				}
				dictionary.Add(node.PortalPoints[i], num);
				list.Add(num);
				num++;
			}
		}
		return new KeyValuePair<Vector2[], int[]>((from x in dictionary
			orderby x.Value
			select x.Key).ToArray(), list.ToArray());
	}

	public void FixPortalsInitial(Dictionary<int, Vector2> offsets, float agentRadius)
	{
		PortalCheck[0] = Points[0];
		PortalCheck[1] = Points[1];
		PortalCheck[2] = Points[2];
		for (int i = 0; i < Points.Length; i++)
		{
			int key = PointIndices[i];
			Vector2 value;
			if (!offsets.TryGetValue(key, out value))
			{
				continue;
			}
			PortalCheck[i] = value;
			float num = Mathf.Max(agentRadius * 0.5f, (PortalPoints[i] - value).magnitude);
			if (2f * Area / (Points[(i + 2) % 3] - Points[(i + 1) % 3]).magnitude < num)
			{
				offsets.Remove(key);
				continue;
			}
			Vector2 vector = PortalCheck[i] - PortalCheck[(i + 1) % 3];
			Vector2 vector2 = PortalCheck[(i + 2) % 3] - PortalCheck[(i + 1) % 3];
			if (vector.x * vector2.y - vector.y * vector2.x > 0f)
			{
				offsets.Remove(key);
			}
		}
	}

	public void FixPortals(Dictionary<int, Vector2> offsets)
	{
		for (int i = 0; i < Points.Length; i++)
		{
			int key = PointIndices[i];
			Vector2 value;
			if (offsets.TryGetValue(key, out value))
			{
				PortalPoints[i] = value;
			}
		}
	}

	public static TriangleNode[] GenerateMap(Vector2[] vertices, int[] indices, float agentRadius, bool outside)
	{
		int num = indices.Length / 3;
		int[][] array = new int[num][];
		int num2 = num * 3;
		if (num2 != indices.Length)
		{
			throw new Exception("Got vertex count for navmesh: " + indices.Length + ", but should have: " + num2);
		}
		int num3 = 0;
		for (int i = 0; i < num2; i += 3)
		{
			if (indices[i] != -1 && indices[i + 1] != -1 && indices[i + 2] != -1)
			{
				if (indices[i] >= vertices.Length || indices[i] < 0)
				{
					throw new Exception("Got out of bounds vertex index: " + indices[i] + ", with vertices: " + vertices.Length);
				}
				if (indices[i + 1] >= vertices.Length || indices[i + 1] < 0)
				{
					throw new Exception("Got out of bounds vertex index: " + indices[i + 1] + ", with vertices: " + vertices.Length);
				}
				if (indices[i + 2] >= vertices.Length || indices[i + 2] < 0)
				{
					throw new Exception("Got out of bounds vertex index: " + indices[i + 2] + ", with vertices: " + vertices.Length);
				}
				Vector2 vector = vertices[indices[i]] - vertices[indices[i + 1]];
				Vector2 vector2 = vertices[indices[i + 2]] - vertices[indices[i + 1]];
				float num4 = vector.x * vector2.y - vector.y * vector2.x;
				if (num4 < 0f)
				{
					array[num3] = new int[3]
					{
						indices[i],
						indices[i + 1],
						indices[i + 2]
					};
					num3++;
				}
				else if (num4 > 0f)
				{
					array[num3] = new int[3]
					{
						indices[i + 2],
						indices[i + 1],
						indices[i]
					};
					num3++;
				}
			}
		}
		TriangleNode[] array2 = new TriangleNode[num3];
		Dictionary<int, List<KeyValuePair<int, int>>> dictionary = new Dictionary<int, List<KeyValuePair<int, int>>>();
		for (int j = 0; j < array2.Length; j++)
		{
			for (int k = j + 1; k < array2.Length; k++)
			{
				int[] array3 = ShareEdge(array[j], array[k]);
				if (array3 != null)
				{
					dictionary.Append(j, new KeyValuePair<int, int>(k, array3[0]));
					dictionary.Append(k, new KeyValuePair<int, int>(j, array3[1]));
				}
			}
		}
		for (int l = 0; l < array2.Length; l++)
		{
			int[] array4 = array[l];
			array2[l] = new TriangleNode(new Vector2[3]
			{
				vertices[array4[0]],
				vertices[array4[1]],
				vertices[array4[2]]
			}, array4);
		}
		float minWidthPenalty = agentRadius * agentRadius;
		foreach (KeyValuePair<int, List<KeyValuePair<int, int>>> item in dictionary)
		{
			for (int m = 0; m < item.Value.Count; m++)
			{
				KeyValuePair<int, int> keyValuePair = item.Value[m];
				array2[item.Key].SetConnection(array2[keyValuePair.Key], keyValuePair.Value, minWidthPenalty, outside);
			}
		}
		int[,] array5 = new int[vertices.Length, 2];
		for (int n = 0; n < array5.GetLength(0); n++)
		{
			array5[n, 0] = -1;
			array5[n, 1] = -1;
		}
		for (int num5 = 0; num5 < array2.Length; num5++)
		{
			for (int num6 = 0; num6 < 3; num6++)
			{
				if (array2[num5].Connections[num6] == null)
				{
					array5[array2[num5].PointIndices[num6], 0] = array2[num5].PointIndices[(num6 + 1) % 3];
					array5[array2[num5].PointIndices[(num6 + 1) % 3], 1] = array2[num5].PointIndices[num6];
				}
			}
		}
		Dictionary<int, Vector2> dictionary2 = new Dictionary<int, Vector2>();
		for (int num7 = 0; num7 < array5.GetLength(0); num7++)
		{
			int num8 = array5[num7, 0];
			int num9 = array5[num7, 1];
			if (num8 > -1 && num9 > -1)
			{
				Vector2 offset = Utilities.GetOffset(vertices[num9], vertices[num7], vertices[num8], agentRadius);
				dictionary2[num7] = offset;
			}
		}
		for (int num10 = 0; num10 < array2.Length; num10++)
		{
			array2[num10].UpdateWeight(outside);
			array2[num10].FixPortalsInitial(dictionary2, agentRadius);
		}
		for (int num11 = 0; num11 < array2.Length; num11++)
		{
			array2[num11].FixPortals(dictionary2);
		}
		return array2;
	}

	public float GetArea()
	{
		float magnitude = (Points[0] - Points[1]).magnitude;
		float magnitude2 = (Points[1] - Points[2]).magnitude;
		float magnitude3 = (Points[2] - Points[0]).magnitude;
		float num = (magnitude + magnitude2 + magnitude3) / 2f;
		return Mathf.Sqrt(num * (num - magnitude) * (num - magnitude2) * (num - magnitude3));
	}

	private static int[] ShareEdge(int[] tr1, int[] tr2)
	{
		for (int i = 0; i < tr1.Length; i++)
		{
			for (int j = 0; j < tr2.Length; j++)
			{
				if (tr1[i] == tr2[j])
				{
					int num = ((i != 2) ? (i + 1) : 0);
					int num2 = ((j == 0) ? 2 : (j - 1));
					int num3 = ((j != 2) ? (j + 1) : 0);
					if (tr1[num] == tr2[num2])
					{
						return new int[2] { i, num2 };
					}
					if (tr1[num] == tr2[num3])
					{
						return new int[2] { i, j };
					}
				}
			}
		}
		return null;
	}

	private static float Sign(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
	}

	public static bool InsideTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
	{
		bool num = Sign(pt, v1, v2) < 0f;
		bool flag = Sign(pt, v2, v3) < 0f;
		bool flag2 = Sign(pt, v3, v1) < 0f;
		if (num == flag)
		{
			return flag == flag2;
		}
		return false;
	}

	public static int IndexOf(TriangleNode[] array, TriangleNode n)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == n)
			{
				return i;
			}
		}
		return -1;
	}

	public static void GetPortals(List<TriangleNode> nodes, Vector2 start, List<Portal> result)
	{
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			int num = IndexOf(nodes[i].Connections, nodes[i + 1]);
			if (num >= 0)
			{
				Vector2 vector = nodes[i].PortalPoints[num];
				Vector2 vector2 = nodes[i].PortalPoints[(num + 1) % 3];
				if (i == 0 && Utilities.IsLeft(vector, vector2, start) <= 0)
				{
					continue;
				}
				result.Add(new Portal(vector2, vector));
			}
			num = IndexOf(nodes[i + 1].Connections, nodes[i]);
			if (num >= 0)
			{
				Vector2 l = nodes[i + 1].PortalPoints[num];
				Vector2 r = nodes[i + 1].PortalPoints[(num + 1) % 3];
				result.Add(new Portal(l, r));
			}
		}
	}

	private static float triarea2(Vector2 a, Vector2 b, Vector2 c)
	{
		float num = b.x - a.x;
		float num2 = b.y - a.y;
		float num3 = c.x - a.x;
		float num4 = c.y - a.y;
		return num3 * num2 - num * num4;
	}

	private static bool FastVectorEquals(Vector2 v1, Vector2 v2)
	{
		if (v1.x.Appx(v2.x))
		{
			return v1.y.Appx(v2.y);
		}
		return false;
	}

	public static List<Vector2> StringPull(List<Portal> portals)
	{
		List<Vector2> list = new List<Vector2>();
		Vector2 vector = portals[0].Left;
		Vector2 vector2 = portals[0].Left;
		Vector2 vector3 = portals[0].Right;
		int num = 0;
		int num2 = 0;
		list.Add(vector);
		for (int i = 1; i < portals.Count; i++)
		{
			Vector2 left = portals[i].Left;
			Vector2 right = portals[i].Right;
			if (triarea2(vector, vector3, right) <= 0f)
			{
				if (!FastVectorEquals(vector, vector3) && !(triarea2(vector, vector2, right) > 0f))
				{
					list.Add(vector2);
					vector = vector2;
					int num3 = num;
					vector2 = vector;
					vector3 = vector;
					num = num3;
					num2 = num3;
					i = num3;
					continue;
				}
				vector3 = right;
				num2 = i;
			}
			if (triarea2(vector, vector2, left) >= 0f)
			{
				if (FastVectorEquals(vector, vector2) || triarea2(vector, vector3, left) < 0f)
				{
					vector2 = left;
					num = i;
					continue;
				}
				list.Add(vector3);
				vector = vector3;
				int num4 = num2;
				vector2 = vector;
				vector3 = vector;
				num = num4;
				num2 = num4;
				i = num4;
			}
		}
		list.Add(portals.Last().Left);
		return list;
	}
}
