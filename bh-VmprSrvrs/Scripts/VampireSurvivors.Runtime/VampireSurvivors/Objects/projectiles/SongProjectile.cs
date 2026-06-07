using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SongProjectile : Projectile
	{
		private Blitter _blitter;

		private Blitter _blitterBg;

		private bool _blittersMade;

		private MultiTargetTween _fadeOutTween;

		private Timer _fadeOutTimer;

		private MultiTargetTween _scaleTween;

		private bool _isBroken;

		private Timer _hitboxTimer;

		private const float BobAlpha = 0.5f;

		private const float ScaleX = 32f;

		private List<Sprite> _spriteList;

		private static int _fps;

		private static double _frameTime;

		private double _frameTimeMS;

		private double _elapsed;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void Shoot()
		{
		}

		private void UpdateBlitter(Blitter blitter, float factor = 0.01f)
		{
		}

		private void BlitterBounce(Blitter blitter, float left, float right, float top, float bottom)
		{
		}

		private void MakeBlitters()
		{
		}

		private void AddBobs(Blitter blitter, int amount)
		{
		}
	}
}
