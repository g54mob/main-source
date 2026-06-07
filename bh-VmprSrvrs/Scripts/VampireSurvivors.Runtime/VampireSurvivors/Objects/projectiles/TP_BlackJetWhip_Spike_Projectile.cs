using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_BlackJetWhip_Spike_Projectile : Projectile
	{
		private float pxWidth;

		private float pxHeight;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _scale2Tween;

		private PhaserSprite _animatedSprite;

		private MultiTargetTween _alphaTween;

		private float _currentScale;

		private MultiTargetTween _durationTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
