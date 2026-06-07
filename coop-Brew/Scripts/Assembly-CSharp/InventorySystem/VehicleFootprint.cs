using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public struct VehicleFootprint
	{
		[Header("Grid Placement")]
		[Tooltip("Can this item be placed in a vehicle bed?")]
		public bool canPlaceInVehicle;

		[Tooltip("Width of the item in grid cells (columns)")]
		[Range(1f, 4f)]
		public int gridWidth;

		[Tooltip("Height of the item in grid cells (rows)")]
		[Range(1f, 4f)]
		public int gridHeight;

		[Header("Visual Transform")]
		[Tooltip("Offset to apply when spawning the visual model in the cell")]
		public Vector3 visualOffset;

		[Tooltip("Rotation to apply when spawning the visual model")]
		public Quaternion visualRotation;

		public static VehicleFootprint None => default(VehicleFootprint);

		public static VehicleFootprint Small => default(VehicleFootprint);

		public static VehicleFootprint Crate => default(VehicleFootprint);

		public static VehicleFootprint Barrel => default(VehicleFootprint);

		public static VehicleFootprint PlankHorizontal => default(VehicleFootprint);

		public static VehicleFootprint PoleVertical => default(VehicleFootprint);

		public int GetTotalCells()
		{
			return 0;
		}

		public (int, int)[] GetCellOffsets()
		{
			return null;
		}

		public bool CanFitAt(int startRow, int startCol, int gridRows, int gridCols)
		{
			return false;
		}
	}
}
