using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class unused_EME_LongswordProjectile_LifeSprinkler : Projectile
	{
		[SerializeField]
		private ParticleSystem lifeSprinklerFullVFX;

		[SerializeField]
		private ParticleEventCall lifeSprinklerFullVFXParticleEventCall;

		[SerializeField]
		private ParticleSystem lifeSprinklerCrossVFX;

		[SerializeField]
		private ParticleEventCall lifeSprinklerCrossVFXParticleEventCall;

		[SerializeField]
		private float radius;

		[SerializeField]
		private int hitMultiplier;

		private int _amountOfHits;

		private float _spriteHalfHeight;

		private EnemyController _strongestEnemy;

		private Timer _hitboxTimer;

		private Camera _camera;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVFX()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void RefreshHitbox()
		{
		}

		private EnemyController GetStrongestTarget()
		{
			return null;
		}

		public override void Despawn()
		{
		}

		private void SprinklerFullVFXStopped()
		{
		}

		private void SprinklerCrossVFXStopped()
		{
		}

		private void FinishDespawn()
		{
		}
	}
}
