using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Pocket2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _InvisibleProjectilePrefab;

		private const float MaxBonusPower = 0.5f;

		private const float MaxBonusArmor = 5f;

		private const float MaxBonusCritMul = 1f;

		private const float SuperAttackFireInterval = 7f;

		private const float SuperAttackDamageMultiplier = 1.7f;

		private float _bonusPower;

		private float _bonusArmor;

		private float _bonusCritMul;

		private bool _bonusStatsApplied;

		private int _fireCounter;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _burstTween1;

		private MultiTargetTween _burstTween2;

		private PhaserSprite _ringSprite;

		private PhaserSprite _burstSprite1;

		private PhaserSprite _burstSprite2;

		private BulletPool _invisibleProjectilePool;

		public float PAreaMax => 0f;

		public BulletPool InvisibleProjectilePool => null;

		public override float PArea()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateStatBonuses()
		{
		}

		private void RemoveCurrentStatBonuses()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireProjectile(int index, bool flipped, bool isSuperAttack)
		{
		}

		private void DoSuperAttackVfx()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void Cleanup()
		{
		}

		private void KillTweens()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
