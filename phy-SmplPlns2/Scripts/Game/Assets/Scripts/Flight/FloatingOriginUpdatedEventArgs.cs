using System;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class FloatingOriginUpdatedEventArgs : EventArgs
	{
		public Vector3 Delta { get; }

		public FloatingOriginUpdatedEventArgs(Vector3 delta)
		{
			Delta = delta;
		}
	}
}
