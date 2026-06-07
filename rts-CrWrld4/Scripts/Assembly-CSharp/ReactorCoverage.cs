using System.Collections.Generic;
using UnityEngine;

public class ReactorCoverage : MonoBehaviour
{
	private Mesh mesh;

	private MeshFilter meshFilter;

	private List<Vector3> vertexList;

	private List<Color32> colorList;

	private List<int> triangleList;

	private const float SQUARE_SIZE = 0.4f;

	private int width;

	private int height;

	private Color32 offColor;

	private Color32 onColor;

	private bool inited;

	private void Awake()
	{
	}

	private void Init()
	{
	}

	private void SetColors(int gsx, int gsy, UnitManager.ORIENTATION orientation)
	{
	}

	private void SetCellColor(int cx, int cy, byte bl)
	{
	}

	public void Refresh(int gsx, int gsy, UnitManager.ORIENTATION orientation)
	{
	}

	private void OnDestroy()
	{
	}
}
