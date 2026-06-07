using System;
using System.Collections.Generic;
using UnityEngine;

public class TerraformPanel : MonoBehaviour
{
	private class Indicator
	{
		public int cellX;

		public int cellY;

		public int height;

		public Indicator(int cellX, int cellY, int height)
		{
		}
	}

	private Mesh mesh;

	private MeshFilter meshFilter;

	private Stack<int> quadStack;

	private bool semiDirty;

	private bool dirty;

	private float QUAD_SIZE;

	public const int atlas_cols = 7;

	public const int atlas_pad = 8;

	public const int atlas_isize = 128;

	public const int atlas_width = 1024;

	public const int atlas_height = 512;

	private Dictionary<int, Indicator> indicatorTable;

	private List<Indicator> indicators;

	private List<Vector3> vertices;

	private List<Vector2> uv;

	private List<int> triangles;

	[NonSerialized]
	public bool ignoreMVerse;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public bool AddIndicator(int cellX, int cellY, int height, bool allowVoid)
	{
		return false;
	}

	private void CreateIndicator(int cellX, int cellY, int height)
	{
	}

	public void RestoreIndicatorFromLoad(int loc, int height)
	{
	}

	private void CreateGeometry(int index)
	{
	}

	private void RemoveGeometry(int index)
	{
	}

	public int GetIndicator(int cellX, int cellY)
	{
		return 0;
	}

	public void RemoveIndicator(int cellX, int cellY, bool allowVoid)
	{
	}

	public void UpdateIndicatorQuadPosition(int cellX, int cellY)
	{
	}

	private void UpdateMesh()
	{
	}

	private void SetTexture(int t, int index)
	{
	}

	private static Vector2 GetUVUnscaled(int t)
	{
		return default(Vector2);
	}
}
