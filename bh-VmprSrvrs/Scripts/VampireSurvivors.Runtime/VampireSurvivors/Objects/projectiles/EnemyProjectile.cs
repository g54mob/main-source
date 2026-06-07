using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EnemyProjectile : ArcadeSprite
	{
		protected SpriteTrail _spriteTrail;

		protected float _speed;

		protected int _indexInWeapon;

		private EnemyBulletPool _pool;

		public float ProjectileSpeed => 0f;

		public float Damage { get; protected set; }

		protected virtual void Awake()
		{
		}

		public virtual void InitProjectile(int index, float2 direction, EnemyBulletPool pool)
		{
		}

		public virtual void Despawn()
		{
		}

		public virtual void OnHitPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public virtual void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public virtual bool ShouldHitWalls()
		{
			return false;
		}

		public void SetVelocity(Vector2 velocity)
		{
		}
	}
}
