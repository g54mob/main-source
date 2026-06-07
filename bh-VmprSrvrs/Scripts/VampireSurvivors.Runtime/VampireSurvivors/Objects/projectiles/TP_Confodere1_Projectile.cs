using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Confodere1_Projectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeTween;

		private TP_Confodere1_Weapon _trueWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		public override void SetNullTarget()
		{
		}

		public override void SetTarget(Transform target)
		{
		}
	}
}
