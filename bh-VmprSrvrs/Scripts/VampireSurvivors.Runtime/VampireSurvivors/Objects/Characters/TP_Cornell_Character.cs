using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Cornell_Character : TP_Character
	{
		private float _amountBonus;

		private float _armorBonus;

		private float _maxHpBonus;

		private float _moveSpeedBonus;

		private MorphVFX _morphVFX;

		private bool _isMorphed;

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}

		private void MakeMorphVFX()
		{
		}

		private void Morph()
		{
		}
	}
}
