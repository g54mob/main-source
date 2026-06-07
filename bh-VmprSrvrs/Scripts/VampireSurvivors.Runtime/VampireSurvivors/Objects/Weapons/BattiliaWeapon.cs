using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class BattiliaWeapon : Weapon
	{
		private bool canRetaliate;

		private Timer _retaliationTimer;

		private float _retaliationDelay;

		private bool soundToPlay;

		protected Circle _damageZone;

		protected List<float> firingAngles;

		public float batAlpha;

		public float shadowAlpha;

		public float physScale;

		public float maxPhysScale;

		private BulletPool _retaliationPool;

		protected virtual BulletPool GetBulletPool()
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private bool OnBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void OnPlayerHit(GameplaySignals.CharacterReceivedDamageSignal signal)
		{
		}

		private void OnPlayerShieldHit(GameplaySignals.CharacterLostShieldSignal signal)
		{
		}

		public void FireRetaliation()
		{
		}

		public void TriggerOnlineRetaliation()
		{
		}

		public override void Cleanup()
		{
		}

		public float2 PickPosition()
		{
			return default(float2);
		}

		private void CheckMaxScale()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireInternal(bool isRetaliatory = false, bool skipTriggers = false)
		{
		}
	}
}
