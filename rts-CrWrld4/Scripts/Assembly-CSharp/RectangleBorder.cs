using System;
using UnityEngine;

public class RectangleBorder : MonoBehaviour
{
	[NonSerialized]
	public float width;

	[NonSerialized]
	public float height;

	public float thickness;

	[NonSerialized]
	public Color color;

	private Mesh mesh;

	private MeshFilter meshFilter;

	public bool refreshOnAwake;

	public bool anchorLowerLeft;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void Init(float width, float height, Color color)
	{
	}

	public void SetColor(Color color)
	{
	}

	public void Refresh()
	{
	}

	private void RefreshColor()
	{
	}

	private void MakeTriangles(int[] triangles, int num, int v1, int v2, int v3, int v4)
	{
	}
}
