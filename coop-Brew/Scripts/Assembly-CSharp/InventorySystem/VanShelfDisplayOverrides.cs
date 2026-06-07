using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public struct VanShelfDisplayOverrides
	{
		[Tooltip("If enabled, this item CANNOT be placed on van shelves")]
		public bool preventVanShelfPlacement;

		[Tooltip("Enable to apply van-specific overrides on top of the shelf display settings")]
		public bool enabled;

		[Header("Position Override")]
		public bool overridePosition;

		public Vector3 positionOffset;

		[Header("Rotation Override")]
		public bool overrideRotation;

		public Vector3 rotation;

		[Header("Scale Override")]
		public bool overrideScale;

		[Tooltip("Scale multiplier (1.0 = default size)")]
		public float scale;

		[Header("Grid Override")]
		public bool overrideGrid;

		public int subGridColumns;

		public int subGridRows;

		public Vector3 subGridSpacing;

		public bool centerSubGrid;

		[Header("Scale By Quantity Override")]
		public bool overrideScaleByQuantity;

		public bool useScaleByQuantity;

		public float minQuantityScale;

		public float maxQuantityScale;

		[Header("Display Count Override")]
		public bool overrideMaxDisplayCount;

		public bool useMaxDisplayCount;

		public int maxDisplayCount;

		[Header("Random Rotation")]
		[Tooltip("When enabled, adds a random Y rotation to each spawned item")]
		public bool useRandomRotation;

		[Tooltip("Max random Y rotation in degrees (e.g. 15 means -15 to +15)")]
		public float randomRotationRange;

		public bool CanPlaceOnVanShelf => false;
	}
}
