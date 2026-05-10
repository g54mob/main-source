using System.Collections.Generic;
using UnityEngine;

public class SortState
{
	private struct BoundsIntersection
	{
		public float Distance;

		public Vector3 Point;
	}

	private List<SortableBox> m_SortableBoxes;

	private Dictionary<Vector3Int, SortableAreaCell> m_Cells;

	private Vector3Int m_SortAreaLimit;

	private float m_ScaleFactor;

	private Dictionary<SortableBox, SortResult> m_Result;

	public bool IsSortingValid { get; private set; }

	public SortState(List<SortableBox> boxes, Vector3Int areaLimit, float scaleFactor)
	{
	}

	public bool TryGetResult(SortableBox forBox, out SortResult result)
	{
		result = default(SortResult);
		return false;
	}

	public float GetHeight()
	{
		return 0f;
	}

	private IEnumerable<SortableBox> OrderByDescending(IEnumerable<SortableBox> sortableBoxesList)
	{
		return null;
	}

	private void CreateSortArea()
	{
	}

	private void ClearGrid()
	{
	}

	private void CalculatePositionFor(SortableBox box)
	{
	}

	private bool GetAvailability(Vector3Int currentCellKey, SortableBox box)
	{
		return false;
	}

	private bool ScanGrid(SortableBox box, out Vector3Int position, out Vector3Int size, out bool isRotated)
	{
		position = default(Vector3Int);
		size = default(Vector3Int);
		isRotated = default(bool);
		return false;
	}

	public void Sort()
	{
	}

	private IEnumerable<SortableBox> OrderByHeight(IEnumerable<SortableBox> sortableBoxesList)
	{
		return null;
	}

	private void DoSecondPass()
	{
	}

	private void OccupyArea(Vector3Int gridPoint, Vector3Int size)
	{
	}

	private bool IsInRange(Vector3Int gridPoint, Vector3Int productSize)
	{
		return false;
	}

	private bool IsPointAvailable(Vector3Int gridPoint, Vector3Int productSize)
	{
		return false;
	}

	public void Release()
	{
	}

	public void Add(SortableBox box)
	{
	}
}
