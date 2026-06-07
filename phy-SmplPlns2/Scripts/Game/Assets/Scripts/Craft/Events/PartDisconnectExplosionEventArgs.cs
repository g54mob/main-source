using System;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Events
{
	public class PartDisconnectExplosionEventArgs : EventArgs
	{
		public AircraftScript Aircraft { get; private set; }

		public int CascadeCount { get; private set; }

		public float Force { get; private set; }

		public PartScript Part { get; private set; }

		public Vector3 Position { get; private set; }

		public PartDisconnectExplosionEventArgs(AircraftScript aircraft, PartScript part, Vector3 position, float force, int cascadeCount)
		{
			Aircraft = aircraft;
			Part = part;
			Position = position;
			Force = force;
			CascadeCount = cascadeCount;
		}
	}
}
