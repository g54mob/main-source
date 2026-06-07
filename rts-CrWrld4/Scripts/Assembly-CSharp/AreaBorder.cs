using System;
using System.Collections.Generic;
using UnityEngine;

public class AreaBorder : MonoBehaviour
{
	private struct Line
	{
		public float sx;

		public float sy;

		public float ex;

		public float ey;

		public Line(float sx, float sy, float ex, float ey)
		{
			this.sx = 0f;
			this.sy = 0f;
			this.ex = 0f;
			this.ey = 0f;
		}
	}

	public float thickness;

	public Color color;

	public Vector3 offset;

	private Mesh mesh;

	private MeshFilter meshFilter;

	private bool[] data;

	private int width;

	private int height;

	[NonSerialized]
	public bool squareWhenZero;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private List<Line> GetLines()
	{
		return null;
	}

	private bool ShouldLine(int x, int y, bool horizontal)
	{
		return false;
	}

	private void CreateLine(Line line, Vector3[] vertices, Vector2[] uvs, Color32[] colors, int[] triangles, int i, float thickness)
	{
	}

	public void Refresh(bool[] data, int width)
	{
	}

	private void RefreshColor()
	{
	}

	private void MakeTriangles(int[] triangles, int num, int v1, int v2, int v3, int v4)
	{
	}
}
