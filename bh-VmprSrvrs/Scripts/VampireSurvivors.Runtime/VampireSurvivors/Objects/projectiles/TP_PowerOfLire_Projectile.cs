using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_PowerOfLire_Projectile : Projectile
	{
		private MultiTargetTween _tween1;

		private PhaserSprite _animatedSprite;

		private List<PhaserSprite> _sparkSprites;

		private int sparkCounter;

		private int frameIndex;

		private float frameTime;

		private bool _isActivated;

		private MultiTargetTween _tween2;

		private bool _canUpdate;

		private List<string> coinBagFrames;

		private List<int> _tints;

		private int tintCounter;

		private bool isFiring;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void FirePowerOfLire()
		{
		}

		private void FireSpark()
		{
		}

		private void Finish()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public void MakeCoin(Vector2 pos, float value)
		{
		}

		protected void TransformEnemies(bool erase = false)
		{
		}

		protected void TransformItems()
		{
		}
	}
}
