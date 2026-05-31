using System.Collections.Generic;
using UnityEngine;

public class SortableBoxManager : NoktaSingleton<SortableBoxManager>
{
	[SerializeField]
	private bool m_IsDrawGismos;

	public Dictionary<Vector3Int, SortableAreaCell> cells;

	public Vector3Int SortAreaLimit;

	public float CellSize;

	[SerializeField]
	private List<SortableBox> m_SortableBoxes;

	private BoxCollider m_Collider;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void OnDeliveryCompleted(List<GameObject> products)
	{
	}

	private void CreateSortArea()
	{
	}

	private void ReCreateSortArea()
	{
	}

	private void PlaceBox(SortableBox box)
	{
	}

	private void ClearGrid()
	{
	}

	private void AddBox(GameObject box)
	{
	}

	[ContextMenu("WakeUpAllBoxesInStreet")]
	public void WakeUpAllBoxesInStreet()
	{
	}

	private void GetBoxesInArea()
	{
	}

	private bool GetAvailability(Vector3Int currentCellKey, SortableBox box)
	{
		return false;
	}

	private void OrderByDescending(List<SortableBox> sortableBoxesList)
	{
	}

	private void OnTakeBoxFromStreet(Box box)
	{
	}
}
