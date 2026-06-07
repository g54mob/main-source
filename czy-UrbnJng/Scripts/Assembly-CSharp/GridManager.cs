using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField]
	private Grid grid;

	[SerializeField]
	private Transform gridPlane;

	[SerializeField]
	private Renderer gridRenderer;

	[SerializeField]
	private Vector3 gridCellSize;

	private int gridCellsAmountX;

	private int gridCellsAmountZ;

	[SerializeField]
	private Vector2Int defaultScale = new Vector2Int(10, 10);

	private List<GridObject> gridObjectsList;

	private float offsetY = 0.015f;

	[SerializeField]
	private Transform debugTextTemplate;

	[SerializeField]
	private Transform debugUI;

	[SerializeField]
	private BaseSurface floorSurface;

	[SerializeField]
	private string cellSizeParameter = "_GridSize";

	[SerializeField]
	private string defaultScaleParameter = "_DefaultScale";

	public static GridManager Instance { get; private set; }

	public Vector2Int gridSize => Vector2Int.RoundToInt(defaultScale * new Vector2(gridPlane.transform.localScale.x, gridPlane.transform.localScale.z));

	private void Awake()
	{
		Instance = this;
		gridObjectsList = new List<GridObject>();
	}

	private void Start()
	{
		grid.cellSize = gridCellSize;
		gridCellsAmountX = (int)((float)gridSize.x / grid.cellSize.x);
		gridCellsAmountZ = (int)((float)gridSize.y / grid.cellSize.z);
		gridRenderer.material.SetVector(cellSizeParameter, new Vector2(1f / gridCellSize.x, 1f / gridCellSize.z));
		gridRenderer.material.SetVector(defaultScaleParameter, new Vector2(defaultScale.x, defaultScale.y));
		SetupDebugText();
	}

	private void SetupDebugText()
	{
		for (int i = -gridCellsAmountX / 2; i < gridCellsAmountX / 2; i++)
		{
			for (int j = -gridCellsAmountZ / 2; j < gridCellsAmountZ / 2; j++)
			{
				GridObject gridObject = new GridObject(this, new Vector3Int(i, (int)offsetY, j));
				gridObject.SetDebugTextTransform(Object.Instantiate(debugTextTemplate, debugUI));
				Transform debugTextTransform = gridObject.GetDebugTextTransform();
				debugTextTransform.position = new Vector3(GetWorldPosition(gridObject.GetCellPosition()).x + gridCellSize.x / 2f, offsetY, GetWorldPosition(gridObject.GetCellPosition()).z + gridCellSize.z / 2f);
				debugTextTransform.GetComponent<TextMeshProUGUI>().text = i + ", " + j + "\n" + gridObject.GetPlacedObject();
				debugTextTransform.gameObject.SetActive(value: true);
				gridObjectsList.Add(gridObject);
			}
		}
	}

	public Vector2Int GetGridCellsAmount()
	{
		return new Vector2Int(gridCellsAmountX, gridCellsAmountZ);
	}

	public GridObject GetGridObject(Vector3Int cellPosition)
	{
		return gridObjectsList.Find((GridObject gridObject) => gridObject.GetCellPosition() == cellPosition);
	}

	public Vector3Int GetCellPosition(Vector3 worldPosition)
	{
		return grid.WorldToCell(worldPosition);
	}

	public Vector3 GetWorldPosition(Vector3Int cellPosition)
	{
		return grid.CellToWorld(cellPosition);
	}

	public void ToggleGrid(bool value)
	{
		gridPlane.gameObject.SetActive(value);
	}

	public void ToggleGridRenderer(bool value)
	{
		gridRenderer.gameObject.SetActive(value);
	}

	public bool IsCellEmpty(Vector2Int cellPosition)
	{
		foreach (Vector2Int occupiedCell in floorSurface.GetOccupiedCells())
		{
			if (occupiedCell == cellPosition)
			{
				return false;
			}
		}
		return true;
	}

	public void ToggleDebugUI(bool value)
	{
		debugUI.gameObject.SetActive(value);
	}
}
