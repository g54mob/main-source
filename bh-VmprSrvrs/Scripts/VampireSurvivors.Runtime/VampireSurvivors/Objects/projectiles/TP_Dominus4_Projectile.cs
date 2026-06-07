using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Dominus4_Projectile : Projectile
	{
		private float _displaySpritePxSize;

		private float _innerRadius;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private PhaserSprite _displaySprite;

		private int frameIndex;

		private float frameTime;

		private bool _isActivated;

		private bool _canUpdate;

		private PhaserSprite _draculaAnimSprite;

		private List<PhaserSprite> explosionSprites;

		private PhaserSprite _redCircleSprite;

		private MultiTargetTween _circleTween;

		private List<PhaserSprite> raySprites;

		private float _maxRadius;

		private MultiTargetTween _circleTween2;

		private MultiTargetTween _tween4;

		private TP_Dominus4_Weapon _trueWeapon;

		private bool _canFire;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ShowDracula()
		{
		}

		private void FadeOutDracula()
		{
		}

		private void DisplayBlackScreen()
		{
		}

		private void DisplayRedCircle()
		{
		}

		private void DisplayRays()
		{
		}

		private void DisplayExplosions()
		{
		}

		private void HideBlackScreen()
		{
		}

		public override void Despawn()
		{
		}
	}
}
