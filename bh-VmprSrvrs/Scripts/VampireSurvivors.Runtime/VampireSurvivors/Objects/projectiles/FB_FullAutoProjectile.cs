using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_FullAutoProjectile : Projectile
	{
		private static string[] s_frameNames;

		private float _MaxAlpha;

		private float _AlphaDiff;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable target)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
		{
		}
	}
}
