using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Energy2_Projectile : Projectile
	{
		private TP_Energy2_Weapon _trueWeapon;

		private float _cachedArea;

		private bool _isBeamInfinite;

		private PhaserSprite _beamSprite;

		private PhaserSprite _shotSprite;

		private PhaserSprite _chargeSprite;

		private const float SpriteWidth = 120f;

		private const float SpriteHeight = 25f;

		private const int SpriteDepth = 5000;

		private const int AnimFPS = 50;

		private Timer _expireTimer;

		private Timer _hitboxTimer;

		private Timer _sfxTimer;

		private const float SfxStartDuration = 600f;

		private const float SfxLoopDuration = 400f;

		private float SfxVolume;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _chargeAlphaTween;

		private MultiTargetTween _chargeScaleTween;

		private const float ScaleTweenDuration = 200f;

		private const float ChargeTweenDuration = 500f;

		private bool _scaleInFinished;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void StartExpireTimer()
		{
		}

		private void UpdatePosition()
		{
		}

		private void StartHitboxTimer()
		{
		}

		private void PlaySfxLoop()
		{
		}

		private void StopSfxLoop()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
