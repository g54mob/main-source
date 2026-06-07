using System;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class MillionaireWeapon : Weapon, IMillionaire
	{
		private PhaserSprite _rays1;

		private PhaserSprite _rays2;

		private float _coinsQueue;

		private float _coinsTime;

		private const float CoinsDelay = 0.1f;

		private MultiTargetTween _rays1Tween;

		private MultiTargetTween _rays2Tween;

		private Timer _rangedAnimEvent;

		private Action<float> _onCoinPickupCallback;

		public override float PPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public void PlayNextRangedAnim()
		{
		}

		protected override void FakeConstruct()
		{
		}

		public void OnCoinPickup(float value = 1f)
		{
		}

		public override void Cleanup()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void Millionaire(float x, float y, float angle, int times = 4)
		{
		}

		private void RaysVFX(bool left, int repeats)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void FireVolley(Vector2 pos, int _amount, Transform target = null)
		{
		}
	}
}
