using UnityEngine;

namespace Brewery.Shelf
{
	[CreateAssetMenu(fileName = "ShelfConfig", menuName = "Brewery/Shelf/Shelf Config", order = 1)]
	[ExecuteAlways]
	public class ShelfConfig : ScriptableObject
	{
		[Header("Shelf Identity")]
		[Tooltip("Display name for this shelf type")]
		public string shelfName;

		[Header("Row Configuration")]
		[Tooltip("Number of rows on this shelf (each row has 4 slots)")]
		[Range(1f, 10f)]
		public int rowCount;

		[Tooltip("Horizontal spacing between slots in a row")]
		public float slotSpacing;

		[Tooltip("Vertical spacing between rows")]
		public float rowHeight;

		[Tooltip("Starting position offset for the entire shelf grid")]
		public Vector3 gridStartOffset;

		[HideInInspector]
		public Vector3[] slotPositions;

		[Header("Barrel Display Settings")]
		[Tooltip("Position offset applied to barrel items (relative to slot position)")]
		public Vector3 barrelPositionOffset;

		[Tooltip("Rotation applied to barrel items (Euler angles)")]
		public Vector3 barrelRotation;

		[Tooltip("Scale multiplier for barrel items")]
		public float barrelScale;

		[Header("Crate Display Settings")]
		[Tooltip("Position offset applied to crate items (relative to slot position)")]
		public Vector3 cratePositionOffset;

		[Tooltip("Rotation applied to crate items (Euler angles)")]
		public Vector3 crateRotation;

		[Tooltip("Scale multiplier for crate items")]
		public float crateScale;

		[Header("Box Display Settings")]
		[Tooltip("Position offset applied to cardboard box items (relative to slot position)")]
		public Vector3 boxPositionOffset;

		[Tooltip("Rotation applied to cardboard box items (Euler angles)")]
		public Vector3 boxRotation;

		[Tooltip("Scale multiplier for cardboard box items")]
		public float boxScale;

		[Header("Bottle Display Settings")]
		[Tooltip("Position offset applied to bottle items (relative to slot position)")]
		public Vector3 bottlePositionOffset;

		[Tooltip("Rotation applied to bottle items (Euler angles)")]
		public Vector3 bottleRotation;

		[Tooltip("Scale multiplier for bottle items")]
		public float bottleScale;

		[Header("Bottle Sub-Grid Layout")]
		[Tooltip("Number of columns in the bottle sub-grid (horizontal)")]
		[Range(1f, 6f)]
		public int bottleSubGridColumns;

		[Tooltip("Number of rows in the bottle sub-grid (vertical)")]
		[Range(1f, 6f)]
		public int bottleSubGridRows;

		[Tooltip("Spacing between individual bottles in the sub-grid")]
		public Vector3 bottleSubGridSpacing;

		[Tooltip("Center the bottle grid within the slot")]
		public bool centerBottleGrid;

		[HideInInspector]
		public int slotCount => 0;
	}
}
