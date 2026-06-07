using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Planets1_Projectile : Projectile
	{
		private LEM_Planets1_Weapon _trueWeapon;

		private LEM_Planets1_Weapon.PlanetData _planetData;

		private PhaserSprite _planetSprite;

		private PhaserSprite _negativePlanetSprite;

		private float _angle;

		private float _areaMultiplierMultiplier;

		private float _speedMultiplier;

		private bool _wasMovingRight;

		private Tween _scaleTween;

		private Tween _speedTween;

		private Tween _negativeAlphaTween;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private float SpeedModifier => 0f;

		private float XOrbitModifier => 0f;

		private float YOrbitModifier => 0f;

		private bool IsMovingRight => false;

		private float AreaMultiplier => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitPosition()
		{
		}

		private void InitSprites()
		{
		}

		private void TweenIn()
		{
		}

		private int GetModifiedIndex()
		{
			return 0;
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateRotation()
		{
		}

		private void UpdateDepth()
		{
		}

		private void UpdateHitBox()
		{
		}

		private void UpdatePfx()
		{
		}

		public void SetNegative(bool enable)
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void Despawn()
		{
		}
	}
}
