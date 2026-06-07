using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class JetBlackWeapon : Weapon
	{
		private List<GravityWell> _gravityWells;

		private List<System.Numerics.Vector3> _offsets;

		private bool _initialisedParticles;

		private ParticleSystem ownerBloodVfx;

		private bool canFire;

		private float firingTimer;

		private float accumulatedDamage;

		private float accumulatedRecovery;

		public ParticleSystem DamageVfx;

		public override float PPower()
		{
			return 0f;
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void OnPlayerHitDamage(float value)
		{
		}

		public void OnPlayerRecovery(float value)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public void SpawnExplosionsAt(float2 _pos)
		{
		}
	}
}
