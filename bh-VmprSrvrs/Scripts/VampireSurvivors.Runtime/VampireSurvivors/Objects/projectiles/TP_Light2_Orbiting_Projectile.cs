using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Light2_Orbiting_Projectile : Projectile
	{
		[SerializeField]
		protected TrailRenderer _LightTrail;

		private float _orbitRadius;

		private float _bodyRadius;

		private MultiTargetTween _scaleTween;

		protected MultiTargetTween _fadeInTrailTween;

		private bool _isLight;

		private float _waveAngle1;

		private float _waveAngle2;

		protected Sprite _cachedLightSprite;

		protected PhaserSprite _animatedSprite;

		protected PhaserSprite _glowSprite;

		protected override void Awake()
		{
		}

		public virtual void MakeTrailAndSprites()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected virtual void InitLightTrail(float multiplier)
		{
		}

		private void StartDespawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
