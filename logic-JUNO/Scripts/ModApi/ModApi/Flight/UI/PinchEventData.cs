using UnityEngine;

namespace ModApi.Flight.UI
{
	public class PinchEventData
	{
		public float AngleDelta { get; set; }

		public float Distance { get; set; }

		public float DistanceDelta { get; set; }

		public Vector2 Midpoint { get; set; }

		public Vector2 MidpointDelta { get; set; }

		public float StartDistance { get; set; }

		public Vector2 StartMidpoint { get; set; }
	}
}
