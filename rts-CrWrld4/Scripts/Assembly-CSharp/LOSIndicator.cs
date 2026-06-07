using System.Collections.Generic;
using UnityEngine;

public class LOSIndicator : MonoBehaviour
{
	private Mesh mesh;

	private MeshFilter meshFilter;

	private List<Vector3> vertexList;

	private List<Vector2> uvList;

	private const float SQUARE_SIZE = 0.25f;

	private Vector3 lastStart;

	private int lastRange;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	private void LOSCallback(bool hasLOS, int cellX, int cellY, int terrainHeight)
	{
	}

	public void Refresh(Vector3 start, int range, float targetHeightOffset, bool ignoreTerrain, float terrainHeightMod, bool losIndirect, float losIndirectHeightOffset, float startDistBias)
	{
	}

	private void OnDestroy()
	{
	}
}
