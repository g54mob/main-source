using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Lapiste2_Projectile : Projectile
	{
		[SerializeField]
		private Transform _BodyTarget;

		private TP_Lapiste2_Weapon _trueWeapon;

		private TP_Lapiste2_InvisibleProjectile _invisibleProjectile;

		private float _initialRotation;

		private PhaserSprite _fistSprite;

		private ParticleEmitterManager _pfxEmitter;

		private ParticleSystem _projEmitter;

		private MultiTargetTween _scaleTween;

		private Timer _launchTimer;

		private SpriteTextureData FistSprite1 => default(SpriteTextureData);

		private SpriteTextureData FistSprite2 => default(SpriteTextureData);

		private float[] FireAngles => null;

		protected override void Awake()
		{
		}

		private void GeneratePfx()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void CreateInvisibleBody()
		{
		}

		private void ScaleIn()
		{
		}

		private void PlaySfx()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePfx()
		{
		}

		public override void Despawn()
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		private void LaunchProjectile()
		{
		}
	}
}
