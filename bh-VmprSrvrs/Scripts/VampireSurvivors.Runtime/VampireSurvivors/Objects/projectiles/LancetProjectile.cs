using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LancetProjectile : Projectile
	{
		private Timer _expireTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetTargetPosition(Vector2 targetPos)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
