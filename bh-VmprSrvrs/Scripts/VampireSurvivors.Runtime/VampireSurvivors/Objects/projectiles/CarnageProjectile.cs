using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class CarnageProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private Tween _expireTimer;

		private Tween _explodeTimer;

		private bool _canExplode;

		private float _saveVelX;

		private float _saveVelY;

		private int _exploIndex;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		private void SetupTrails()
		{
		}

		private void FadeOutAndDispose()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void Explode()
		{
		}

		public override void Despawn()
		{
		}
	}
}
