using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_PrototypeAProjectile : Projectile
	{
		private float _offset;

		private float _offsetDist;

		private float2 _centralPos;

		private Vector3 _direction;

		private SpriteAnimation _anims;

		private float _wArea;

		private float _MaxAlpha;

		private float _AlphaDiff;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable target)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
		{
		}
	}
}
