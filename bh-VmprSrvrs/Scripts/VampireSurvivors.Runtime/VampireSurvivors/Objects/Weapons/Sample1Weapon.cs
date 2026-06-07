using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Sample1Weapon : Weapon
	{
		protected int _samplesAmount;

		protected List<float2> screenGrid;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		protected uint[] tints;

		private float[] _randomOffsets;

		private int _randomOffsetsIndex;

		public override float SecondaryPPower()
		{
			return 0f;
		}

		protected override void MakeLevelOne()
		{
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireSample(Vector2 pos, int index, Transform target = null)
		{
		}

		public void SpawnExplosionClustersAt(float2 pos)
		{
		}

		public override Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
