using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_RapierProjectile_Shocking : Projectile
	{
		[SerializeField]
		private MeshRenderer _Quad1;

		[SerializeField]
		private MeshRenderer _Quad2;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_RapierWeapon _trueWeapon;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private PhaserSprite crystalSprite;

		private bool isInitialised;

		private PhaserSprite impactSprite;

		private MultiTargetTween _tween3;

		protected bool hasHit;

		private static readonly int _AlphaMul;

		protected uint _pfxTint => 0u;

		public virtual void makeSprites()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void Despawn()
		{
		}

		public void DespawnNow()
		{
		}

		public override void SetNullTarget()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
