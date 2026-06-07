using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodRapidusProjectile : Projectile
	{
		private float _amount;

		private BloodAstronomiaWeapon _trueWeapon;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private Timer _expireTimer;

		private Timer _activationTimer;

		private List<string> _frameNames;

		private MultiTargetTween _localTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void OverrideWeaponData(Weapon weapon)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override bool CanExplode()
		{
			return false;
		}

		public override void Explode(Vector2? pos = null)
		{
		}

		private void FadeOut()
		{
		}
	}
}
