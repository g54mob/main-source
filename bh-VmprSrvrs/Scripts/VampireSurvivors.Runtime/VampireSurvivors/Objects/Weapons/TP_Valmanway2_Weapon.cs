using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Valmanway2_Weapon : Weapon
	{
		private const float BonusAreaGainedPerSecond = 0.1f;

		private const float BonusAreaLostPerSecond = 0.25f;

		private const float BonusAreaMax = 1f;

		private float _bonusArea;

		public override float PArea()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateBonusArea()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
