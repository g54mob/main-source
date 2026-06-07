using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class CreateExplosionInfo
	{
		public int? AttackerPlayerId { get; set; }

		public Vector3? BlastDirection { get; set; }

		public string ExplosionPrefabName { get; set; }

		public float ExplosionScale { get; set; }

		public Vector3d GlobalPosition { get; set; }

		public Vector3? ImpactDirection { get; set; }

		public ExplosiveWeaponImpactType ImpactType { get; set; }
	}
}
