using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PunchProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer groundVFX;

		[SerializeField]
		private ParticleSystem punchVFX;

		[SerializeField]
		private ParticleSystem dustVFX;

		[SerializeField]
		private ParticleEventCall dustVFXparticleEventCall;

		[SerializeField]
		private float Radius;

		private const float FRONT_OFFSET = 30f;

		private bool flipVerticalVFX;

		private Vector3 _punchScale;

		private Vector3 _dustScale;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private float _totalTime;

		private float _elapsedTime;

		private bool _showVFX;

		private bool _cachedFlipX;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupTimers()
		{
		}

		private void SetupVFX()
		{
		}

		public void PlayPunch()
		{
		}

		public void SetFlipDirection(bool flip)
		{
		}

		public void EnableGroundVFX()
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

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
