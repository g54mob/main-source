using System;
using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events
{
	public class MissileExplodedEventArgs : EventArgs
	{
		public Vector3 BlastDirection { get; private set; }

		public ExplosiveWeaponImpactType ImpactType { get; private set; }

		public MissileScript Missile { get; private set; }

		public Vector3 Position { get; private set; }

		public MissileExplodedEventArgs(MissileScript missile, Vector3 blastDirection, ExplosiveWeaponImpactType impactType)
		{
			Missile = missile;
			Position = missile.transform.position;
			BlastDirection = blastDirection;
			ImpactType = impactType;
		}
	}
}
