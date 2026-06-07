using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class CarnageWeapon : Weapon
	{
		private int _exploIndex;

		private bool _canExplode;

		private Tween _explodeTimer;

		private bool _generatedPools;

		private BulletPool _onGetHitExplosionPool;

		private BulletPool _tvExplosionPool;

		public BulletPool TVExplosionPool => null;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override int ActiveProjectileCount()
		{
			return 0;
		}

		public override void Cleanup()
		{
		}

		protected override void OnStart()
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
	}
}
