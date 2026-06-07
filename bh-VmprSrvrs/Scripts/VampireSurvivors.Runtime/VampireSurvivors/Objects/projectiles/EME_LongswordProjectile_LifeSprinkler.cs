using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_LongswordProjectile_LifeSprinkler : Projectile
	{
		[SerializeField]
		private ParticleSystem lifeSprinklerFullVFX;

		[SerializeField]
		private ParticleEventCall lifeSprinklerFullVFXParticleEventCall;

		[SerializeField]
		private ParticleSystem lifeSprinklerCrossVFX;

		[SerializeField]
		private ParticleEventCall lifeSprinklerCrossVFXParticleEventCall;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		private MultiTargetTween _moveTween;

		private Timer _movementTimer;

		private EME_Longsword1Weapon _trueweapon;

		private PhaserSprite cloneImage1;

		private PhaserSprite cloneImage2;

		private PhaserSprite cloneImage3;

		private PhaserSprite cloneImage4;

		private MultiTargetTween _fadeInClonesTween;

		private MultiTargetTween _fadeClonesTween;

		protected override void Awake()
		{
		}

		private void MakeCloneSprites()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void GoToNearestEnemy()
		{
		}

		public override void Despawn()
		{
		}

		private void LateUpdate()
		{
		}

		private void DespawnAfterParticlesToFinish()
		{
		}
	}
}
