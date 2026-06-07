using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_WineGlass1_Projectile : Projectile
	{
		private PhaserSprite _animatedSprite;

		private TP_WineGlass1_Weapon _trueWeapon;

		private SpriteAnimation spriteAnim;

		private TweenerCore<Vector2, Vector2, VectorOptions> throwTween;

		private List<SfxType> Glass_Light;

		private List<SfxType> Glass_Medium;

		private List<SfxType> Glass_Heavy;

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
