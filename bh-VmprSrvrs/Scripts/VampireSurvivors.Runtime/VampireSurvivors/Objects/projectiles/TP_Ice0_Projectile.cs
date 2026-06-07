using System.Collections.Generic;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Ice0_Projectile : Projectile
	{
		private List<string> _frames;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _scaleTween2;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
