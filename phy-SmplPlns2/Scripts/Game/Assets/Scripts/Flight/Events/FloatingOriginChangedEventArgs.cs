using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Events
{
	public class FloatingOriginChangedEventArgs : EventArgs
	{
		public Vector3 Delta => OldFloatingOriginOffset - NewFloatingOriginOffset;

		public Vector3 NewFloatingOriginOffset { get; private set; }

		public Vector3 OldFloatingOriginOffset { get; private set; }

		public FloatingOriginChangedEventArgs(Vector3 oldOffset, Vector3 newOffset)
		{
			OldFloatingOriginOffset = oldOffset;
			NewFloatingOriginOffset = newOffset;
		}
	}
}
