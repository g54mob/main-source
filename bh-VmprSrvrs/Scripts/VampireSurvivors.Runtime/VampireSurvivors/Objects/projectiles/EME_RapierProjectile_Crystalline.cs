using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_RapierProjectile_Crystalline : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_RapierWeapon _trueWeapon;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		private readonly SfxType[] _sounds;

		private int _sfxIndex;

		private PhaserSprite crystalSprite;

		private bool isInitialised;

		private PhaserSprite impactSprite;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		protected bool hasHit;

		protected virtual uint _pfxTint => 0u;

		public virtual void makeSprites()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void PlaySfx()
		{
		}

		public virtual void DespawnNow()
		{
		}

		public override void Despawn()
		{
		}

		public override void SetNullTarget()
		{
		}

		public override void SetTarget(Transform target)
		{
		}
	}
}
