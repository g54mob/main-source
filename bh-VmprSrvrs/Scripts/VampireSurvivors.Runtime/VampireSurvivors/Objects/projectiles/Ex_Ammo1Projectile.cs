using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Ex_Ammo1Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer mainVisuals;

		[SerializeField]
		private SpriteTrail trail;

		private float _hitboxSize;

		private const float MAX_HOMING_ANGLE_CHANGE_PER_SECOND = 360f;

		private float penetrationAmount;

		protected EnemyController _targetEnemyController;

		private SpriteAnimation _anims;

		private Timer _prefireTimer;

		private Bounds _camBounds;

		private Ex_Ammo1Weapon trueWeapon;

		private bool _isMirrored;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private EnemyController FindTargetEnemy()
		{
			return null;
		}

		private void SetupMechanics()
		{
		}

		private void ApplyInitialVelocity(Vector2 targetPosition, Vector2 firePosition, bool rotate = true, Vector3? customFromPosition = null)
		{
		}

		public override void Despawn()
		{
		}

		private Vector2 GetLeadAimPosition(Vector2 firePosition, Vector2 targetPosition, Vector2 targetVelocity)
		{
			return default(Vector2);
		}

		private void SetProjectileVelocity(Vector2 projectileDirection, bool rotate)
		{
		}

		public override void InternalUpdate()
		{
		}

		private static void FireDirectlyAtTarget(Vector2 targetPosition, Vector2 playerPosition, ref Vector2 projectileDirection)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
