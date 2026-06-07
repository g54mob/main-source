using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events
{
	public class RocketExplodedEventArgs : EventArgs
	{
		public Vector3 BlastDirection { get; private set; }

		public Vector3 Position { get; private set; }

		public RocketScript Rocket { get; private set; }

		public RocketExplodedEventArgs(RocketScript rocket, Vector3 blastDirection)
		{
			Rocket = rocket;
			Position = rocket.transform.position;
			BlastDirection = blastDirection;
		}
	}
}
