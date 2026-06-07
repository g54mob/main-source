using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class SwordWeapon : Weapon
	{
		private int _firingCounter;

		private int _lastFiringCounter;

		private int _maxFiringCounter;

		private BulletPool _finisherPool;

		private BulletPool _retaliationPool;

		private bool _canRetaliate;

		private Timer _retaliationTimer;

		private Timer _meleeAnimEvent;

		protected bool _canDoFinisher;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void ParadoxFire()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void ScreenShake()
		{
		}

		protected override void OnStart()
		{
		}

		private void OnPlayerHitDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
		{
		}

		private void OnPlayerHitShield(GameplaySignals.CharacterLostShieldSignal signal)
		{
		}

		private void OnPlayerHit()
		{
		}

		protected virtual void FireInternal(bool isRetaliatory = false, bool skipTriggers = false)
		{
		}

		public Projectile FireOneProjectile(Vector2 pos, int index, float volume)
		{
			return null;
		}

		private Projectile FireOneRetaliatoryProjectile(Vector2 pos, int index, float volume)
		{
			return null;
		}

		private Projectile FireOneFinisherProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
