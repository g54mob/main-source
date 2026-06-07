using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class GrangattiWeapon : Weapon
	{
		private List<float> _RANDOMS;

		private int _randomIndex;

		private int _plusMinusIndex;

		private List<float> _PLUSMINUS;

		private double _chanceBonus;

		private int _success;

		private int _fail;

		private static ItemType[] _gold;

		private static ItemType[] _edible;

		private static ItemType[] _ignore;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		public double goldChance;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
		{
			return false;
		}

		public float GetRandom()
		{
			return 0f;
		}

		public float GetPlusMinus()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
		{
			return false;
		}

		public bool OnBulletOverlapsEnemyNoKB(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public bool TurnToGold(ArcadeSprite target, bool certain = false)
		{
			return false;
		}

		protected override void MakeLevelOne()
		{
		}
	}
}
