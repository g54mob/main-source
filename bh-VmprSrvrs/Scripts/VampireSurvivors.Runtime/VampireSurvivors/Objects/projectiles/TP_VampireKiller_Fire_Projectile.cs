using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_VampireKiller_Fire_Projectile : Projectile
	{
		private ParticleSystem _pfxEmitter;

		private Tween _scaleTween;

		private PhaserSprite _animatedSprite;

		private uint[] _tints;

		private bool _isDespawning;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetAngleVelocity_Deg(float angleDeg)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public void StartDespawn()
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
