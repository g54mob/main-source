using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public struct ShelfDisplaySettings
	{
		[Tooltip("If enabled, this item CANNOT be placed on shelves")]
		public bool preventShelfPlacement;

		[Tooltip("Enable to use custom shelf display settings instead of defaults")]
		public bool useCustomSettings;

		[Header("Transform Settings")]
		[Tooltip("Position offset from the slot center")]
		public Vector3 positionOffset;

		[Tooltip("Rotation in euler angles")]
		public Vector3 rotation;

		[Tooltip("Scale multiplier (1.0 = default size)")]
		public float scale;

		[Header("Grid Settings (Stackable Items)")]
		[Tooltip("Number of columns in the sub-grid (0 = use shelf config default)")]
		public int subGridColumns;

		[Tooltip("Number of rows in the sub-grid (0 = use shelf config default)")]
		public int subGridRows;

		[Tooltip("Spacing between items in the grid (zero = use shelf config default)")]
		public Vector3 subGridSpacing;

		[Tooltip("Center the grid within the slot")]
		public bool centerSubGrid;

		[Header("Scale By Quantity (Single-Model Stacking)")]
		[Tooltip("When enabled, stackable items display as a single model that scales with quantity instead of a grid")]
		public bool useScaleByQuantity;

		[Tooltip("Scale multiplier at quantity 1")]
		public float minQuantityScale;

		[Tooltip("Scale multiplier at max stack size")]
		public float maxQuantityScale;

		[Header("Display Count Limit (Grid Items)")]
		[Tooltip("When enabled, caps the number of visual items shown on the shelf. The display count scales proportionally with the actual quantity.")]
		public bool useMaxDisplayCount;

		[Tooltip("Maximum number of visual items to show on the shelf (actual stack can be larger)")]
		public int maxDisplayCount;

		public bool CanPlaceOnShelf => false;

		public bool HasCustomGridSettings => false;

		public bool HasScaleByQuantity => false;

		public bool HasMaxDisplayCount => false;

		public static ShelfDisplaySettings Default => default(ShelfDisplaySettings);
	}
}
