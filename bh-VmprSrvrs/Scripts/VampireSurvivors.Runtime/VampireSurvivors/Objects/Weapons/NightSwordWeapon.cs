using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class NightSwordWeapon : Weapon
	{
		public int _FireCounter;

		public int[] _FireAngles;

		public int[] _FireX;

		private bool _canExplode;

		public bool _CanFinish;

		private Timer _expodeTimer;

		private float _retaliationDelay;

		private bool _removedFiringTimer;

		public float _Volume;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public void SetAsRetaliatoryOnly()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public List<EnemyController> Closest(CharacterController source, PhysicsGroup targets)
		{
			return null;
		}

		public override void Cleanup()
		{
		}

		private void ExplodeOnPlayerDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
		{
		}

		private void ExplodeOnPlayerShield(GameplaySignals.CharacterLostShieldSignal signal)
		{
		}

		private void ExplodeOnPlayer()
		{
		}

		public override Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnBulletOverlapsEnemyRetaliation(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
