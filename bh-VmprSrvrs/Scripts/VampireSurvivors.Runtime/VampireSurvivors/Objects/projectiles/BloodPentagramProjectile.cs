using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodPentagramProjectile : Projectile
	{
		private Timer _expireTimer;

		private MultiTargetTween _alphaTween;

		private BloodAstronomiaWeapon _trueWeapon;

		private float _amount;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void OverrideWeaponData(Weapon weapon)
		{
		}

		public override bool CanExplode()
		{
			return false;
		}

		public override void Explode(Vector2? position = null)
		{
		}

		public override void Despawn()
		{
		}

		private void FadeOut()
		{
		}
	}
}
