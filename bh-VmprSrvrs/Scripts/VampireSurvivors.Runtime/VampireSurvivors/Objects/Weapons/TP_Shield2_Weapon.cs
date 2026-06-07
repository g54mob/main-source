using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Shield2_Weapon : Weapon
	{
		private BulletPool _standardPool;

		private BulletPool _retaliationPool;

		private bool _canRetaliate;

		private Timer _retaliationTimer;

		private float RetaliationDelay;

		public int SlotNumber;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void OnPlayerHit()
		{
		}

		public override void Cleanup()
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

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireStandardProjectiles(Vector2 position)
		{
		}

		public void FireProjectiles(BulletPool pool, Vector2 position, bool allDirections = false)
		{
		}
	}
}
