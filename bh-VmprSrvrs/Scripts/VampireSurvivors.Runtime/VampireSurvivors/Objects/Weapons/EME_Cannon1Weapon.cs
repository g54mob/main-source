using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Cannon1Weapon : EME_Weapon
	{
		private const float QUANTISATION_STEP = 1f;

		private const float SECONDS_TO_ROTATE_AIM_360 = 0.9f;

		protected float _amount;

		private float _firingAngleDegrees;

		private List<float> _shuffledIndexes;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected override void InitGlimmer2BulletPool()
		{
		}

		protected override void InitGlimmer3BulletPool()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		private void GenerateShuffleIndexes(float amount)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void ShowTinyDamage(float value, Vector3 position)
		{
		}
	}
}
