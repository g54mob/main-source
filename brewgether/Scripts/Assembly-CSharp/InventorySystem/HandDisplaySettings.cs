using System;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public struct HandDisplaySettings
	{
		[Tooltip("Position offset from the hand socket")]
		public Vector3 positionOffset;

		[Tooltip("Rotation in euler angles")]
		public Vector3 rotationOffset;

		[Tooltip("Scale when held (defaults to 1,1,1 if zero)")]
		public Vector3 scale;

		public static HandDisplaySettings Default => default(HandDisplaySettings);

		public Vector3 GetScale()
		{
			return default(Vector3);
		}
	}
}
