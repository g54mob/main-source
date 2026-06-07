using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_AuraBlast2_HellfireProjectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _Trail;

		private const float Radius = 16f;

		private const float Gravity = 6.25f;

		private Vector2 _velocity;

		private PhaserSprite _hellfireSprite;

		private MultiTargetTween _scaleTween;

		private Timer _leftBounceTimer;

		private Timer _rightBounceTimer;

		private Timer _bottomBounceTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitTrail()
		{
		}

		private void InitVelocity()
		{
		}

		private void InitTimers()
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

		private void UpdateVelocity()
		{
		}

		private void CheckForBounce()
		{
		}

		private void Bounce(bool invertX, bool invertY)
		{
		}

		private void CheckForDespawn()
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
