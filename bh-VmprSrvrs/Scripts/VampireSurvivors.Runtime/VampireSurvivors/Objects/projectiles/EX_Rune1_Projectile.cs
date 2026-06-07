using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_Rune1_Projectile : Projectile
	{
		private float _IndexOffsetScaleFactor;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private EX_Rune1_Weapon trueWeapon;

		private EnemyController targetEnemy;

		protected Vector3 start;

		protected Vector3 end;

		protected float midYOffset;

		protected float t;

		protected float speed;

		protected SpriteAnimation _spriteAnimation;

		public virtual List<string> ParticleFrames => null;

		public virtual void MakeSpriteAnimation()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetEnemyTarget(EnemyController enemy, bool flipMyY = false)
		{
		}

		private void GenerateParticleSystem()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void InternalUpdate()
		{
		}

		private float TriMap(float x)
		{
			return 0f;
		}
	}
}
