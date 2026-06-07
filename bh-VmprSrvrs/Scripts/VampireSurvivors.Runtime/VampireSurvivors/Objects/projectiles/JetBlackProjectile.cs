using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class JetBlackProjectile : Projectile
	{
		[SerializeField]
		private SpriteAnimation _animation;

		[SerializeField]
		private SpriteRenderer _starSprite;

		[SerializeField]
		private SpriteRenderer _bubbleSprite;

		private bool _initialisedParticles;

		private GravityWell _gravityWell;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private float _radiusX;

		private float _radiusY;

		private float _offsetX;

		private float _offsetY;

		private MultiTargetTween _tween4;

		private Tween _dTween1;

		private Tween _dTween2;

		private float renderingAngle;

		private float renderingAngle2;

		private float _radiusY2;

		private float accelDuration;

		private float accelTime;

		private bool isActive;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private ParticleSystem _pfx2;

		private float emissionTime;

		private JetBlackWeapon _trueWeapon;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle()
		{
		}

		private void FadeIn()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
