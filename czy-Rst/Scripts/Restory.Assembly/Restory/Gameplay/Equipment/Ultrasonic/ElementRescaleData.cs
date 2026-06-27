using System;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	[Serializable]
	public struct ElementRescaleData
	{
		public Vector3 OriginalScale { get; set; }

		public float RescaleFactor { get; set; }
	}
}
