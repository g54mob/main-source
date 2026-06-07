using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_HomingProjectile : Projectile
	{
		[SerializeField]
		private SpriteAnimation _anim;

		public float2 _targetPosition;

		public float _timeSinceChangedTarget;

		public float _facingAngle;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
