using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class FireExplosionWeapon : Weapon
	{
		private bool _canExplode;

		private Tween _explodeTimer;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		public void TriggerExplosion(Vector2 pos, int index)
		{
		}

		public override void ResetFiringTimer()
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

		private void ExplodeAt(Vector2 position, bool ignoreCooldown = false, bool retaliate = false)
		{
		}
	}
}
