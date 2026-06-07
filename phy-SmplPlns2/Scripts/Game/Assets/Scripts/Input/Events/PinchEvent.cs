using UnityEngine;

namespace Assets.Scripts.Input.Events
{
	public class PinchEvent
	{
		public float Distance { get; set; }

		public float DistanceDelta { get; set; }

		public InputState InputState { get; set; }

		public Vector2 Midpoint { get; set; }

		public Vector2 MidpointDelta { get; set; }

		public float StartDistance { get; set; }

		public Vector2 StartMidpoint { get; set; }

		public float TotalDistanceDelta => Distance - StartDistance;

		public Vector2 TotalMidpointDelta => Midpoint - StartMidpoint;
	}
}
