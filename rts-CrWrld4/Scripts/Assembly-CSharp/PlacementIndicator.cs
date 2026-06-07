using System.Collections.Generic;
using UnityEngine;

public class PlacementIndicator : MonoBehaviour
{
	private Mesh mesh;

	private MeshFilter meshFilter;

	private List<Vector3> vertexList;

	private List<Vector2> uvList;

	private const float SQUARE_SIZE = 0.5f;

	private int lastCellX;

	private int lastCellZ;

	private int lastRange;

	private Vector2 noneVector;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	private void LOSCallback(bool hasLOS, int cellX, int cellY, int terrainHeight)
	{
	}

	public void Refresh(int cellX, int cellZ, int range, int WIDTH, int HEIGHT, bool ignoreLand, bool onlyOnResource, bool avoidContaminant, bool ignoreFog, bool onlyOnVoid, bool allowPlatform, bool avoidMesh, bool force)
	{
	}

	private void OnDestroy()
	{
	}
}
