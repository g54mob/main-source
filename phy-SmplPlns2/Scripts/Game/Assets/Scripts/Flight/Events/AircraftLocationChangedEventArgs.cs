using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Events
{
	public class AircraftLocationChangedEventArgs : EventArgs
	{
		public Vector3 NewPosition { get; private set; }

		public AircraftLocationChangedEventArgs(Vector3 newPosition)
		{
			NewPosition = newPosition;
		}
	}
}
