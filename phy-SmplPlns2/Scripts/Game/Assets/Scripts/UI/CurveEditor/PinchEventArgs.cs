using System;
using UnityEngine;

namespace Assets.Scripts.UI.CurveEditor
{
	public class PinchEventArgs : EventArgs
	{
		public float Distance { get; set; }

		public float DistanceDelta { get; set; }

		public InputState InputState { get; set; }

		public Vector2 Midpoint { get; set; }

		public Vector2 MidpointDelta { get; set; }

		public float StartDistance { get; set; }

		public Vector2 StartMidpoint { get; set; }
	}
}
