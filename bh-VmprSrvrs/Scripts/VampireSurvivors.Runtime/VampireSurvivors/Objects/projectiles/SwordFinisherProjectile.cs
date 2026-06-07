using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SwordFinisherProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _tween2;

		private PhaserSprite _highlightSprite;

		private MultiTargetTween _posTween;

		private MultiTargetTween _alphaTween;

		private PhaserSprite _crackSprite;

		private MultiTargetTween _damageTween;

		private MultiTargetTween _fadeOutTween;

		private MultiTargetTween _alphaCrackTween;

		private float spriteRatio;

		private SwordWeapon _trueWeapon;

		private ParticleSystem _pfxEmitter;

		private PhaserSprite _impactSprite;

		private MultiTargetTween _impactTween;

		public float sfxVolume;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
