using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_WineGlass2_Projectile : Projectile
	{
		private PhaserSprite _animatedSprite;

		private TP_WineGlass2_Weapon _trueWeapon;

		private SpriteAnimation spriteAnim;

		private TweenerCore<Vector2, Vector2, VectorOptions> throwTween;

		private MultiTargetTween _angleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnBreak()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
