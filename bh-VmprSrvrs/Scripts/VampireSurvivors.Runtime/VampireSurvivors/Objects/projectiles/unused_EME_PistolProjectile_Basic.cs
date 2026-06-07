using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class unused_EME_PistolProjectile_Basic : Projectile
	{
		[SerializeField]
		private ParticleSystem pistolBasicVFX;

		[SerializeField]
		private ParticleSystem pistolTargetingVFX;

		[SerializeField]
		private ParticleEventCall pistolBasicParticleEventCall;

		[SerializeField]
		private ParticleEventCall pistolTargetingParticleEventCall;

		private const float MAX_HOMING_ANGLE_CHANGE_PER_SECOND = 360f;

		private bool _projectileLaunched;

		private float penetrationAmount;

		protected EnemyController _targetEnemyController;

		private SpriteAnimation _anims;

		private bool _useHoming;

		private Timer _prefireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVisuals()
		{
		}

		public void EnableProjectileLaunch()
		{
		}

		private void ApplyInitialVelocity(Vector2 targetPosition, Transform playerTransform, bool rotate = true, Vector3? customFromPosition = null)
		{
		}

		public override void Despawn()
		{
		}

		private void DespawnAfterParticlesStopped()
		{
		}

		private void FinishDespawn()
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

		private static EnemyController GetRandomEnemyControllerOnScreen(Rectangle _rect)
		{
			return null;
		}
	}
}
