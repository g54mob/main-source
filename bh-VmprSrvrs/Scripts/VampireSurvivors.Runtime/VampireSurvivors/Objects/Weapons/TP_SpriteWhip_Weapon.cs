using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SpriteWhip_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _fireballPrefab;

		private BulletPool _fireballPool;

		[SerializeField]
		private Projectile _explosionPrefab;

		private BulletPool _explosionPool;

		private List<float> _fireBallAngles;

		private List<float> _fireBallAnglesFlipped;

		public int _activationsCount;

		public int _specialCounter;

		private float BossBonus;

		public virtual bool ShootFireballs => false;

		public override float PPower()
		{
			return 0f;
		}

		public void CalculateBossBonus()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void OnStart()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public Projectile FireFireballProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public Projectile FireExplosionProjectile(Vector2 pos, int index, EnemyController target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
