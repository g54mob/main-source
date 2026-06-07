using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX.Shatter;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Banana2_Hidden_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _InvisProjectilePrefab;

		[SerializeField]
		private ParticleSystem[] _ParticleSystems;

		[SerializeField]
		private float _ParticleLaunchVelocity;

		[SerializeField]
		private float _ParticleGravity;

		private Camera _mainCamera;

		private ParticleSystem.Particle[] _activeParticles;

		private BulletPool _invisProjectilesPool;

		private float[] _randomBounceValues;

		private readonly List<RapidDamageInstance> _rapidDamageInstances;

		private Vector3 _cameraOrthographicSize;

		private PhaserSprite _card;

		private ShatterVFX _shatterVfx;

		private MultiTargetTween[] _shatterTweens;

		private Vector3 _gravityVector => default(Vector3);

		private Vector3 ParticleStartPos => default(Vector3);

		private int ParticleAmount => 0;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void Awake()
		{
		}

		private void InitBounceValues()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private void DoCardTween()
		{
		}

		private void PlayBuildUpSfx()
		{
		}

		private void PlayShatterSfx()
		{
		}

		private void PlayBananastropheSfx()
		{
		}

		private void ShatterCard()
		{
		}

		private void InitShatterVfx()
		{
		}

		public Vector3 GetRandomActiveParticlePosition()
		{
			return default(Vector3);
		}

		public void EmitParticles(int amount)
		{
		}

		private void ApplyParticleVelocity(ParticleSystem.Particle[] particles, int particleCount, float left, float right, float top, float bottom)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
