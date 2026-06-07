using System;
using UnityEngine;

namespace Brewery.Bar
{
	[Serializable]
	public class ShelfRow
	{
		[Tooltip("Number of bottle positions available in this row")]
		public int bottleCapacity;

		[Tooltip("Starting position for the first bottle in this row (local to shelf transform)")]
		public Vector3 startOffset;

		[Tooltip("Spacing vector between consecutive bottles in this row")]
		public Vector3 bottleSpacing;

		[Header("Visual Settings")]
		[Tooltip("Show gizmos for this row in the editor")]
		public bool showGizmos;

		[Tooltip("Color used for gizmos and labels for this row")]
		public Color gizmoColor;

		public Vector3 GetBottleLocalPosition(int bottleIndex)
		{
			return default(Vector3);
		}
	}
}
