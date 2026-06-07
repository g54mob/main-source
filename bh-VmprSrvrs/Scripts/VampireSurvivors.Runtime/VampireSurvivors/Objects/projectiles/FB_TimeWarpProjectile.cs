using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_TimeWarpProjectile : Projectile
	{
		private List<Sprite> _animationFrames;

		private float _animationProgress;

		private float _loopTimer;

		private Timer _hitboxTimer;

		private int FrameRate => 0;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void OnCircleComplete()
		{
		}

		private void LateUpdate()
		{
		}

		private void InitAnimation()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
