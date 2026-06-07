using System;
using UnityEngine;

namespace PlacementSystem
{
	[Serializable]
	public struct PlacementFootprint
	{
		[Header("Placement Settings")]
		[Tooltip("Can this item be placed in the world?")]
		public bool canBePlaced;

		[Tooltip("Can this item be placed on StorageFloor surfaces? (e.g., storage shelves)")]
		public bool canPlaceOnStorageFloor;

		[Header("Visual Transform")]
		[Tooltip("Offset to apply when spawning the placed object")]
		public Vector3 visualOffset;

		[Tooltip("Base rotation to apply when spawning")]
		public Quaternion visualRotation;

		public static PlacementFootprint None => default(PlacementFootprint);

		public static PlacementFootprint Default => default(PlacementFootprint);

		public PlacementFootprint GetRotated(int rotationSteps)
		{
			return default(PlacementFootprint);
		}
	}
}
