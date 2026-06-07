using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Pocket2_Projectile : Projectile
	{
		[SerializeField]
		private Transform _BodyTarget1;

		[SerializeField]
		private Transform _BodyTarget2;

		private TP_Pocket2_Weapon _trueWeapon;

		private TP_Pocket2_InvisibleProjectile _invisibleProjectile1;

		private TP_Pocket2_InvisibleProjectile _invisibleProjectile2;

		private PhaserSprite _swordSprite;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private MultiTargetTween _rotateTween;

		private MultiTargetTween _fadeTween;

		private Timer _timer;

		private bool _isDespawning;

		private bool _isSuperAttack;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void FinishInitialisation(bool isSuperAttack, bool flipped)
		{
		}

		private void SetPositonAndRotation(bool flipped)
		{
		}

		private void FadeIn()
		{
		}

		private void CreateInvisibleBody(ref TP_Pocket2_InvisibleProjectile invisibleBody, ref Transform attachPoint)
		{
		}

		private void EnableInvisibleBody(ref TP_Pocket2_InvisibleProjectile invisibleBody, bool enable)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePfx()
		{
		}

		private void PlaySfx()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		private void FadeOut()
		{
		}

		private void WaitForPfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
