using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_CoinToss1_Projectile : Projectile
	{
		private float _IndexOffsetScaleFactor;

		private Ex_CoinToss1_Weapon _trueWeapon;

		private readonly List<SfxType> sfx;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetSpriteFromIndex(int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
