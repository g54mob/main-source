using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Neutron2_Weapon : Weapon
	{
		private const float _explosionDamageMultiplier = 2f;

		private int _exploIndex;

		private bool _canExplode;

		private Tween _explodeTimer;

		private bool _generatedPools;

		private BulletPool _onGetHitExplosionPool;

		private BulletPool _neutronExplosionPool;

		public BulletPool NeutronExplosionPool => null;

		protected override void OnStart()
		{
		}

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

		public override void SetVisible(bool visible)
		{
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

		private bool OnBulletOverlapsEnemy_Explosion(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
