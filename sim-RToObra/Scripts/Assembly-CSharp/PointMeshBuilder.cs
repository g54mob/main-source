using System.Collections.Generic;
using UnityEngine;

public class PointMeshBuilder
{
	private List<Vector3> points = new List<Vector3>();

	public int numTriangles
	{
		get
		{
			return points.Count * 2;
		}
	}

	private Vector3[] vertices
	{
		get
		{
			Vector3[] array = new Vector3[points.Count * 4];
			for (int i = 0; i < points.Count; i++)
			{
				array[i * 4] = points[i];
				array[i * 4 + 1] = points[i];
				array[i * 4 + 2] = points[i];
				array[i * 4 + 3] = points[i];
			}
			return array;
		}
	}

	private int[] triangles
	{
		get
		{
			int[] array = new int[points.Count * 6];
			for (int i = 0; i < points.Count; i++)
			{
				array[i * 6] = i * 4;
				array[i * 6 + 1] = i * 4 + 1;
				array[i * 6 + 2] = i * 4 + 3;
				array[i * 6 + 3] = i * 4 + 1;
				array[i * 6 + 4] = i * 4 + 2;
				array[i * 6 + 5] = i * 4 + 3;
			}
			return array;
		}
	}

	private Vector2[] uv
	{
		get
		{
			Vector2[] array = new Vector2[points.Count * 4];
			for (int i = 0; i < points.Count; i++)
			{
				array[i * 4] = new Vector2(-1f, 1f);
				array[i * 4 + 1] = new Vector2(1f, 1f);
				array[i * 4 + 2] = new Vector2(1f, -1f);
				array[i * 4 + 3] = new Vector2(-1f, -1f);
			}
			return array;
		}
	}

	public PointMeshBuilder()
	{
	}

	public PointMeshBuilder(List<Vector3> points_)
	{
		points = points_;
	}

	public void Add(Vector3 p)
	{
		points.Add(p);
	}

	public void Clear()
	{
		points.Clear();
	}

	public void Apply(Mesh mesh)
	{
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.SetTriangles(triangles, 0);
		mesh.RecalculateBounds();
	}
}
