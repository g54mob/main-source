using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodLaurelProjectile : Projectile
	{
		private Timer _expireTimer;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _imageTween;

		private MultiTargetTween _scaleTween;

		private float _amount;

		private BloodAstronomiaWeapon _trueWeapon;

		private Timer _activationTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void OverrideWeaponData(Weapon weapon)
		{
		}

		public override void Despawn()
		{
		}

		public override bool CanExplode()
		{
			return false;
		}

		public override void Explode(Vector2? position = null)
		{
		}

		private void FadeOut()
		{
		}
	}
}
