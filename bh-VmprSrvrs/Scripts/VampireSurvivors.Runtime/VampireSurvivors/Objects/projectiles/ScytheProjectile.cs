using DG.Tweening;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class ScytheProjectile : Projectile
	{
		private Tween _angleTween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		private void Bounce(Body body, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}
	}
}
