using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public class VehicleGridCell
	{
		[Header("Grid Position")]
		[Tooltip("Row index in the grid (0-based)")]
		public int row;

		[Tooltip("Column index in the grid (0-based)")]
		public int column;

		[Header("World Transform")]
		[Tooltip("Local position of this cell relative to vehicle bed anchor")]
		public Vector3 localPosition;

		[Tooltip("Local rotation of this cell")]
		public Quaternion localRotation;

		[Header("Occupancy")]
		[Tooltip("Whether this cell is currently occupied by an item")]
		public bool isOccupied;

		[Tooltip("Item ID of the item occupying this cell (if any)")]
		public string occupiedByItemId;

		[Tooltip("If occupied, index of the anchor cell (top-left cell) of the occupying item")]
		public int anchorCellIndex;

		[Header("Visualization")]
		[Tooltip("Color to use for gizmo drawing (green=free, red=occupied)")]
		public Color gizmoColor;

		public VehicleGridCell(int row, int column, Vector3 localPosition)
		{
		}

		public void Occupy(string itemId, int anchorIndex)
		{
		}

		public void Clear()
		{
		}

		public string GetDisplayName()
		{
			return null;
		}

		public int GetLinearIndex(int gridColumns)
		{
			return 0;
		}
	}
}
