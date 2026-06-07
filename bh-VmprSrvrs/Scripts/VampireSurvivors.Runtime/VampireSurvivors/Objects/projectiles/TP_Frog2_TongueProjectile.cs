using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Frog2_TongueProjectile : Projectile
	{
		private enum TongueState
		{
			Launch = 0,
			Hold = 1,
			Retract = 2
		}

		private const float LaunchDurationMS = 100f;

		private const float HoldDurationMS = 300f;

		private const float RetractDurationMS = 200f;

		private PhaserSprite _tongueSprite;

		private PhaserSprite _fakeEnemySprite;

		private Vector2 _targetPos;

		private EnemyController _targetEnemy;

		private float _tongueSpriteWidth;

		private Timer _tongueTimer;

		private Timer _frogSpawnTimer;

		private TongueState _tongueState;

		private TP_Frog2_Weapon _trueWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LaunchTongue()
		{
		}

		private void HoldTongue()
		{
		}

		private void RetractTongue()
		{
		}

		private void MorphTargetEnemy()
		{
		}

		public void SetTargetEnemy(EnemyController enemy)
		{
		}

		private void PlayLaunchSfx()
		{
		}

		private void PlayRetractSfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
