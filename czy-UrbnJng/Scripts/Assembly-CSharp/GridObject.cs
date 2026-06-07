using TMPro;
using UnityEngine;

public class GridObject
{
	private GridManager gridManager;

	private Vector3Int cellPosition;

	private PlacedObject placedObject;

	private Transform debugTextTransform;

	public GridObject(GridManager gridManager, Vector3Int cellPosition)
	{
		this.gridManager = gridManager;
		this.cellPosition = cellPosition;
	}

	public Vector3Int GetCellPosition()
	{
		return cellPosition;
	}

	public void SetPlacedObject(PlacedObject placedObject)
	{
		this.placedObject = placedObject;
		UpdateDebugTextTransform();
	}

	public PlacedObject GetPlacedObject()
	{
		return placedObject;
	}

	public void ClearPlacedObject()
	{
		placedObject = null;
		UpdateDebugTextTransform();
	}

	public bool CanBuild()
	{
		return placedObject == null;
	}

	public void SetDebugTextTransform(Transform debugTextTransform)
	{
		this.debugTextTransform = debugTextTransform;
	}

	public Transform GetDebugTextTransform()
	{
		return debugTextTransform;
	}

	public void UpdateDebugTextTransform()
	{
		debugTextTransform.GetComponent<TextMeshProUGUI>().text = cellPosition.x + ", " + cellPosition.z + "\n" + placedObject;
	}
}
