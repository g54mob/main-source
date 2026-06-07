using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DarkRift2_Projectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _Trail;

		private const float Radius = 16f;

		private Tween _angleTween;

		private PhaserSprite _scytheSprite;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitVelocity()
		{
		}

		private void InitRotation()
		{
		}

		private void InitBounce()
		{
		}

		private void PlaySfx()
		{
		}

		public override void Despawn()
		{
		}

		private void Bounce(Body body, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}
	}
}
