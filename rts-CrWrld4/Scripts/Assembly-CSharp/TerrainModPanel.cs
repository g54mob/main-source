using System.Collections.Generic;
using UnityEngine;

public class TerrainModPanel : MonoBehaviour
{
	private class Indicator
	{
		public int index;

		public int cellX;

		public int cellY;

		public Indicator(int cellX, int cellY, int index)
		{
		}
	}

	private Mesh mesh;

	private MeshFilter meshFilter;

	private bool semiDirty;

	private bool dirty;

	private float QUAD_SIZE;

	public const int atlas_isize = 256;

	public const int atlas_width = 2048;

	public const int atlas_height = 1024;

	private Stack<Indicator> indicatorStack;

	private Dictionary<int, Indicator> indicatorTable;

	private Vector3[] vs;

	private Vector2[] uv;

	private int[] ts;

	private bool initialized;

	private void Awake()
	{
	}

	public void Init()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateIndicator(int cellX, int cellY)
	{
	}

	private void RestoreIndicatorFromLoad(int loc)
	{
	}

	public void RestoreIndicatorsFromLoad()
	{
	}

	private void RemoveIndicator(int cellX, int cellY)
	{
	}

	public void UpdateIndicatorQuadPosition(int cellX, int cellY)
	{
	}

	private void UpdateMesh()
	{
	}

	private void SetTexture(Indicator ind, int px, int py)
	{
	}

	private Indicator PopIndicator()
	{
		return null;
	}

	private void PushIndicator(Indicator ind)
	{
	}

	private void CreateIndicators(int count)
	{
	}
}
