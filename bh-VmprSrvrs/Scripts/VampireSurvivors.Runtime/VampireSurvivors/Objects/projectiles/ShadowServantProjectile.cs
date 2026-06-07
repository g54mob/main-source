using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class ShadowServantProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		private PhaserSprite _displaySprite;

		private MultiTargetTween _explosionTween;

		private bool _isExploding;

		private ShadowServantWeapon _trueWeapon;

		private Transform _trailFollower;

		public float _trailFollowerCounter;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		public void Explode()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Disable()
		{
		}

		public override void Despawn()
		{
		}

		private void LogTrailPositions()
		{
		}
	}
}
