using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_RapierWeapon : EME_Weapon
	{
		[SerializeField]
		protected Projectile _MegaSinglePrefab;

		[SerializeField]
		protected Projectile _NoDamageFreezePrefab;

		[SerializeField]
		protected Projectile _NoDamageSlowPrefab;

		[HideInInspector]
		public int[] _FireAngles;

		[HideInInspector]
		public int[] _FireX;

		[HideInInspector]
		public int[] _FireY;

		protected BulletPool _megaSinglePool;

		protected BulletPool _freezeOnlyPool;

		protected BulletPool _slowOnlyPool;

		public BulletPool FreezeOnlyPool => null;

		public BulletPool SlowOnlyPool => null;

		public BulletPool MegaSinglePool => null;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		public virtual int DisplayedSlashes()
		{
			return 0;
		}

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		public override float PPower()
		{
			return 0f;
		}

		protected override float FinalGlimmerChance()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected override void InitGlimmer2BulletPool()
		{
		}

		protected override void OnStart()
		{
		}

		protected bool OnBulletOverlapsEnemy_Mega(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy_Freeze(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy_Shock(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy_NoDamageFreeze(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy_NoDamageSlow(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override void Fire_DoTargeting()
		{
		}
	}
}
