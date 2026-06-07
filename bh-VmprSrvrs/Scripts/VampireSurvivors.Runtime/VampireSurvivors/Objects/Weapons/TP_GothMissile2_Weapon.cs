using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_GothMissile2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _SongProjectilePrefab;

		private const float FireDelayMillis = 700f;

		private const float SniperAlpha = 0.8f;

		private const float SongDamageMultiplier = 2.5f;

		private BulletPool _songProjectilePool;

		private PhaserSprite _sniperSprite1;

		private PhaserSprite _sniperSprite2;

		private PhaserSprite _sniperSprite1A;

		private PhaserSprite _sniperSprite1B;

		private PhaserSprite _sniperSprite2A;

		private PhaserSprite _sniperSprite2B;

		private PhaserSprite _sniperSprite1_BG;

		private PhaserSprite _sniperSprite2_BG;

		private PhaserSprite _sniperSprite1A_BG;

		private PhaserSprite _sniperSprite1B_BG;

		private PhaserSprite _sniperSprite2A_BG;

		private PhaserSprite _sniperSprite2B_BG;

		private MultiTargetTween _sniperTween1;

		private MultiTargetTween _sniperTween2;

		private MultiTargetTween _critSniperTween;

		private Timer _critSniperTimer;

		private Timer _songFiringTimer;

		public override float HeartOfFirePower => 0f;

		public override float PInterval()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireMissiles(int index, bool isCrit)
		{
		}

		private PhaserSprite CreateSniperSprite(ref PhaserSprite spriteBG, bool mainSniper = false, bool flipped = false, float2? extraOffset = null)
		{
			return null;
		}

		private void ShowCritSnipers(bool show)
		{
		}

		private void PlayCritSfx(float detune = 0f)
		{
		}

		private void DoSniperTweens()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		private bool OnBulletOverlapsEnemy_Song(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
