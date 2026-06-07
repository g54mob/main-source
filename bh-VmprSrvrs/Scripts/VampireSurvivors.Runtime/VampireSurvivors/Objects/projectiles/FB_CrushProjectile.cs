using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_CrushProjectile : Projectile
	{
		private Timer _hitboxTimer;

		private MultiTargetTween _flightPositionTween;

		private MultiTargetTween _flightScaleTween;

		private MultiTargetTween _scaleOutTween;

		private Timer _appearTimer;

		private Timer _disappearTimer;

		private bool _hasHitGround;

		private SpriteAnimation _spriteAnim;

		private PhaserSprite _displaySprite;

		private MultiTargetTween _blackBubbleTween;

		private void SetupAnimation()
		{
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void CreateBubble()
		{
		}

		private void OnHitGround()
		{
		}

		private void PopBubble()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Cleanup()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
