using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodLancetProjectile : Projectile
	{
		[SerializeField]
		private Transform _NumbersParent;

		[SerializeField]
		private List<PhaserSprite> _Numbers;

		private Timer _expireTimer;

		private BloodAstronomiaWeapon _trueWeapon;

		public List<Radi> _radii;

		private float _amount;

		private float _slowPower;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _imageTween;

		private MultiTargetTween _angleTween;

		private MultiTargetTween _alphaTween;

		private List<Tweener> _radiusTween;

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

		public override void InternalUpdate()
		{
		}

		private void InitNumbers()
		{
		}

		private void FadeOut()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
