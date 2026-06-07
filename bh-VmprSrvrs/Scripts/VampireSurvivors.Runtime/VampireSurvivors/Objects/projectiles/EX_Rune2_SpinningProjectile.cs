using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_Rune2_SpinningProjectile : Projectile
	{
		private Timer _hitBoxTimer;

		private Timer _expireTimer;

		public Transform _toFollow;

		private bool _alreadyRecycled;

		private List<PhaserSprite> magicCircles;

		private float _angle1;

		private float _angle2;

		private float _angle3;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetObjectToFollow(Transform toFollow)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
