using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Icicle2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _LaunchProjectilePrefab;

		[SerializeField]
		private Projectile _RuneProjectilePrefab;

		[SerializeField]
		private Transform _RuneContainer;

		private Timer _runeTimer;

		public float ProjScale => 0f;

		public Transform RuneContainer => null;

		private float RuneZRotSpeed => 0f;

		public int NumRunes { get; private set; }

		public BulletPool LaunchProjectilePool { get; private set; }

		public BulletPool RuneProjectilePool { get; private set; }

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void StartRuneTimer()
		{
		}

		public override float PArea()
		{
			return 0f;
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		public override float SecondaryPAmount()
		{
			return 0f;
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target, BulletPool pool = null)
		{
			return null;
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateRuneContainer()
		{
		}

		private void UpdateRuneAmount()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
