using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainChunkEditorHelper : MonoBehaviour
{
	[Header("Grid Settings")]
	public bool showGizmo = true;

	public int gridSizeX = 5;

	public int gridSizeZ = 5;

	public float cellScaleX = 1f;

	public float cellScaleZ = 1f;

	public float cellScaleY = 3f;

	private HashSet<int> selectedCellIds = new HashSet<int>();

	private Dictionary<int, Vector3> selectedCellPositions = new Dictionary<int, Vector3>();

	private bool isGridSelected;

	private bool isAreaSelecting;

	private Vector2 areaStartPosition;

	private Vector2 areaEndPosition;

	public GameObject connectedTerrain;

	public ChunkDataHolder chunkDataHolder;

	public bool isStartedTerrain;

	public List<GridCell> GetAllCells()
	{
		List<GridCell> list = new List<GridCell>();
		Vector3 position = base.transform.position;
		for (int i = 0; i < gridSizeZ; i++)
		{
			for (int j = 0; j < gridSizeX; j++)
			{
				Vector3 position2 = position + new Vector3((float)j * cellScaleX + cellScaleX * 0.5f, cellScaleY * 0.5f, (float)i * cellScaleZ + cellScaleZ * 0.5f);
				Vector3 size = new Vector3(cellScaleX, cellScaleY, cellScaleZ);
				int id = j + i * gridSizeX;
				GridCell item = new GridCell
				{
					id = id,
					position = position2,
					size = size
				};
				list.Add(item);
			}
		}
		Debug.Log($"Saved {list.Count} cells to list");
		return list;
	}

	public HashSet<int> GetSelectedCellIds()
	{
		return selectedCellIds;
	}
}
