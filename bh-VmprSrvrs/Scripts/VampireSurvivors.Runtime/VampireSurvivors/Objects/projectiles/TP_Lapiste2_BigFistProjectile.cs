using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Lapiste2_BigFistProjectile : Projectile
	{
		private const float Radius = 36f;

		private PhaserSprite _fistSprite;

		private PhaserSprite _slamSprite;

		private bool _isOnScreen;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _screenShakeTween;

		private Timer _timer;

		private float FistScale => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetBody()
		{
		}

		private void MoveFistToCentre()
		{
		}

		private void DoFistBump()
		{
		}

		protected void DoScreenShake()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void CheckForSfx()
		{
		}

		private void PlaySfx()
		{
		}

		private void FadeOut()
		{
		}

		private void DoTwilightExplosions()
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
