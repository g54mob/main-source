using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Spear1Weapon : EME_Weapon
	{
		[Header("Triumvirate Transforms")]
		[SerializeField]
		protected Transform TriumvirateContainer;

		[SerializeField]
		protected List<Transform> TriumvirateSpawnPoints;

		private const float BaseOffsetY = 0.16f;

		private List<float> _basicAttackRepeatOffsets;

		private const float StardustOffsetAngleMin = 105f;

		private const float StardustOffsetAngleMax = 170f;

		private Timer _glimmerShotTimer;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		public Vector2 CachedPlayerDirection { get; set; }

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		private Vector2 GetBasicProjectilePosition(float offsetPos)
		{
			return default(Vector2);
		}

		private Vector2 GetStarDustProjectilePosition(float offsetAngle)
		{
			return default(Vector2);
		}

		private float GetBasicProjectileOffset(int index)
		{
			return 0f;
		}

		private float GetStardustProjectileOffset(int index)
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		public override void Cleanup()
		{
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected override void InitGlimmer3BulletPool()
		{
		}

		protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
