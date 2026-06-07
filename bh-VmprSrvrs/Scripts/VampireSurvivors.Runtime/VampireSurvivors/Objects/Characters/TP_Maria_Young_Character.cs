using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Maria_Young_Character : TP_Character
	{
		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		protected override void OnUpdate()
		{
		}
	}
}
