using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class DiamondProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private Timer _expireTimer;

		private float _saveVelX;

		private float _saveVelY;

		private readonly List<int> _targetAngles;

		private bool isFullColourRange;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		private void SetupTrails()
		{
		}

		public Color ColorFromUInt(uint value)
		{
			return default(Color);
		}

		private void FadeOutAndDispose()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
