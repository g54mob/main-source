using System.Collections.Generic;
using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class EnemyTaka : EnemyController
	{
		private EnemyWeakPoint _weakPoint;

		private Timer _bundleSpawnTimer;

		private Timer _swarmSpawnTimer;

		private Timer _bulletSpawnTimer;

		private List<Sprite> _explosionFrames;

		private List<PhaserSprite> _explosionSprites;

		private List<PhaserSprite> _readyExplosionSprites;

		private bool _isExploding;

		private float _explosionTimer;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void AddExplosionEffect(float2 position)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void StartExploding()
		{
		}

		private void LateUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void Die()
		{
		}

		[Command]
		public void StartExplodingOnline()
		{
		}

		public override void Despawn()
		{
		}

		private void Clearup()
		{
		}

		private void CancelAttacks()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void FireBullet()
		{
		}

		private void FireBundle()
		{
		}

		private void HandleBundle(EnemyController enemy)
		{
		}

		[Command]
		public void OnBundleSpawned(CoherenceSync bundle)
		{
		}

		private void FireSwarm()
		{
		}
	}
}
