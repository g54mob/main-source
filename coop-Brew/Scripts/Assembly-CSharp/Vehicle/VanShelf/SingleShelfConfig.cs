using System;
using UnityEngine;

namespace Vehicle.VanShelf
{
	[Serializable]
	public class SingleShelfConfig
	{
		[Header("Identity")]
		[Tooltip("Display name for this shelf (e.g., 'Left Top', 'Back Middle')")]
		public string shelfName;

		[Tooltip("Which wall this shelf is mounted on")]
		public VanWall wall;

		[Header("Slot Configuration")]
		[Tooltip("Total number of slots on this shelf")]
		[Range(1f, 24f)]
		public int slotCount;

		[Tooltip("Number of slots per row (for multi-row shelves)")]
		[Range(1f, 8f)]
		public int slotsPerRow;

		[Header("Positioning")]
		[Tooltip("Local position relative to the van's shelf root transform")]
		public Vector3 localPosition;

		[Tooltip("Local rotation in Euler angles")]
		public Vector3 localRotation;

		[Tooltip("Spacing between slots horizontally")]
		public float slotSpacing;

		[Tooltip("Spacing between rows vertically")]
		public float rowSpacing;

		public int RowCount => 0;

		public Vector3 GetSlotLocalPosition(int localSlotIndex)
		{
			return default(Vector3);
		}

		public Vector3[] GetAllSlotLocalPositions()
		{
			return null;
		}
	}
}
