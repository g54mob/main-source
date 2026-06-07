using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Ice2_Weapon : Weapon
	{
		private BulletPool _invisibleProjectilePool;

		[SerializeField]
		private Projectile _invisibleProjectilePrefab;

		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private bool _hasGemini;

		private Timer rainStopTimer;

		private TP_Ice1_Weapon _ice1Weapon;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireProjectiles(Vector2 pos)
		{
		}

		public override void CheckArcanas()
		{
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
