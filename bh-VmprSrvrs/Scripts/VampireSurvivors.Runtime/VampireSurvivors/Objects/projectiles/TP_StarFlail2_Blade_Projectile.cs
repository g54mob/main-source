using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_StarFlail2_Blade_Projectile : Projectile
	{
		private MultiTargetTween _posTween;

		private SpriteAnimation _anim;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _scaleTween;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private float _angle;

		private const float RotationSpeed = 500f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void ManualIntProjectile(float flyAngle, bool isFlipped)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateRotation()
		{
		}

		public void Shoot()
		{
		}

		public void FadeOut()
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
