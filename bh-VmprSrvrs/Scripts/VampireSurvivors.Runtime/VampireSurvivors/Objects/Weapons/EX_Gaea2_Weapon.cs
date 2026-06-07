using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class EX_Gaea2_Weapon : EX_Gaea1_Weapon
	{
		private BulletPool _retaliationPool;

		private bool _canRetaliate;

		private Timer _retaliationTimer;

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
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

		private void OnPlayerHit()
		{
		}

		private Projectile FireOneRetaliatoryProjectile(Vector2 pos, int index)
		{
			return null;
		}
	}
}
