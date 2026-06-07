using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.projectiles
{
	public class ReportProjectile : Projectile
	{
		[SerializeField]
		protected SpriteRenderer _visuals;

		[SerializeField]
		protected SpriteAnimation _anim;

		private float2 _firingDirection;

		[NonSerialized]
		public float _life;

		protected float2 offset;

		protected bool visualInitalised;

		protected virtual bool followPlayerFacing => false;

		protected virtual void InitVisuals()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
