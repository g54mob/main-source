using System;
using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events
{
	public class BombExplodedEventArgs : EventArgs
	{
		public Vector3 BlastDirection { get; private set; }

		public BombScript Bomb { get; private set; }

		public ExplosiveWeaponImpactType ImpactType { get; private set; }

		public Vector3 Position { get; private set; }

		public BombExplodedEventArgs(BombScript bomb, Vector3 blastDirection, ExplosiveWeaponImpactType impactType)
		{
			Bomb = bomb;
			Position = bomb.transform.position;
			BlastDirection = blastDirection;
			ImpactType = impactType;
		}
	}
}
