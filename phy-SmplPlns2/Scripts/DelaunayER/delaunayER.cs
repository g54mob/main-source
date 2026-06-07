using System;
using System.Collections.Generic;
using UnityEngine;

public class delaunayER
{
	private void Start()
	{
		List<Vector3> list = new List<Vector3>();
		List<PointER> list2 = new List<PointER>();
		for (int i = 0; i < 25; i++)
		{
			for (int j = 0; j < 25; j++)
			{
				Vector3 item = new Vector3(UnityEngine.Random.value * 25f, 0f, UnityEngine.Random.value * 25f);
				list.Add(item);
				list2.Add(new PointER(item.x, item.z, 0f));
			}
		}
		List<TriangleER> list3 = Triangulate(list2);
		List<int> list4 = new List<int>();
		for (int i = 0; i < list3.Count; i++)
		{
			list4.Add(FindVertice(new Vector3(list3[i].Vertex1.x, list3[i].Vertex1.z, list3[i].Vertex1.y), list));
			list4.Add(FindVertice(new Vector3(list3[i].Vertex3.x, list3[i].Vertex3.z, list3[i].Vertex3.y), list));
			list4.Add(FindVertice(new Vector3(list3[i].Vertex2.x, list3[i].Vertex2.z, list3[i].Vertex2.y), list));
		}
		Mesh mesh = new Mesh();
		mesh.vertices = list.ToArray();
		mesh.triangles = list4.ToArray();
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		Debug.Log("Done 2 " + list4.Count);
	}

	private void Update()
	{
	}

	public static int FindVertice(Vector3 v, List<Vector3> vecs)
	{
		for (int i = 0; i < vecs.Count; i++)
		{
			if (vecs[i].x == v.x && vecs[i].z == v.z)
			{
				return i;
			}
		}
		return 0;
	}

	public static List<TriangleER> Triangulate(List<PointER> triangulationPoints)
	{
		if (triangulationPoints.Count < 3)
		{
			throw new ArgumentException("Can not triangulate less than three vertices!");
		}
		List<TriangleER> list = new List<TriangleER>();
		TriangleER triangleER = SuperTriangle(triangulationPoints);
		list.Add(triangleER);
		for (int i = 0; i < triangulationPoints.Count; i++)
		{
			List<EdgeER> list2 = new List<EdgeER>();
			for (int num = list.Count - 1; num >= 0; num--)
			{
				TriangleER triangleER2 = list[num];
				if (triangleER2.ContainsInCircumcircle(triangulationPoints[i]) > 0.0)
				{
					list2.Add(new EdgeER(triangleER2.Vertex1, triangleER2.Vertex2));
					list2.Add(new EdgeER(triangleER2.Vertex2, triangleER2.Vertex3));
					list2.Add(new EdgeER(triangleER2.Vertex3, triangleER2.Vertex1));
					list.RemoveAt(num);
				}
			}
			for (int num = list2.Count - 2; num >= 0; num--)
			{
				for (int num2 = list2.Count - 1; num2 >= num + 1; num2--)
				{
					if (list2[num] == list2[num2])
					{
						list2.RemoveAt(num2);
						list2.RemoveAt(num);
						num2--;
					}
				}
			}
			for (int num = 0; num < list2.Count; num++)
			{
				list.Add(new TriangleER(list2[num].StartPoint, list2[num].EndPoint, triangulationPoints[i]));
			}
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (list[i].SharesVertexWith(triangleER))
			{
				list.RemoveAt(i);
			}
		}
		return list;
	}

	public static TriangleER SuperTriangle(List<PointER> triangulationPoints)
	{
		float num = triangulationPoints[0].x;
		for (int i = 1; i < triangulationPoints.Count; i++)
		{
			float num2 = Mathf.Abs(triangulationPoints[i].x);
			float num3 = Mathf.Abs(triangulationPoints[i].y);
			if (num2 > num)
			{
				num = num2;
			}
			if (num3 > num)
			{
				num = num3;
			}
		}
		PointER vertex = new PointER(10f * num, 0f, 0f);
		PointER vertex2 = new PointER(0f, 10f * num, 0f);
		PointER vertex3 = new PointER(-10f * num, -10f * num, 0f);
		return new TriangleER(vertex, vertex2, vertex3);
	}
}
