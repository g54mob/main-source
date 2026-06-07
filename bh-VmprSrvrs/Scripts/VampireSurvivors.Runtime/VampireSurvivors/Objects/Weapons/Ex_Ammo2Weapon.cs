using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Ex_Ammo2Weapon : Weapon
	{
		private BulletPool InvisProjectilesPool;

		[SerializeField]
		private Projectile InvisProjectilePrefab;

		[SerializeField]
		private ParticleSystem[] _gunastropheParticleSystem;

		[SerializeField]
		private float _particleLaunchVelocity;

		[SerializeField]
		private float _particleGravity;

		private Camera _mainCamera;

		private ParticleSystem.Particle[] _activeParticles;

		private float[] _randomBounceValues;

		private readonly List<RapidDamageInstance> _rapidDamageInstances;

		private const WeaponType _counterWeaponType = WeaponType.EX_AMMO1_COUNTER;

		private Weapon _counterWeapon;

		private Vector3 _cameraOrthographicSize;

		private Vector3 _gravityVector => default(Vector3);

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void Awake()
		{
		}

		public override void CheckArcanas()
		{
		}

		private void InitBounceValues()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
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

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
