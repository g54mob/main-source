using System;
using Restory.Data.Elements;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	[Serializable]
	public class ElementFitData
	{
		public ElementInfo ElementInfo;

		public Vector3 OriginalScale;

		public float FitScaleFactor;

		public Vector2 OffsetRangeX;

		public Vector2 OffsetRangeZ;
	}
}
