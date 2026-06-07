using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Achievements
{
	public class ThosePeople_CustomAchivementHandleing : ICustomAchievements
	{
		public static void RunManualCreditsUnlockChecks(AchievementManager achievementManager, PlayerOptions playerOptions)
		{
		}

		public List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
		{
			return null;
		}

		public List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions)
		{
			return null;
		}

		public List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions)
		{
			return null;
		}

		public void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager)
		{
		}

		public bool Check_MorningStar(PlayerOptions playerOptions)
		{
			return false;
		}

		public bool Check_Spellbook(PlayerOptions playerOptions)
		{
			return false;
		}

		public bool Check_CoatOfArms(PlayerOptions playerOptions)
		{
			return false;
		}

		public bool Check_Diabologue(PlayerOptions playerOptions)
		{
			return false;
		}

		public bool Check_SpectralSword(PlayerOptions playerOptions)
		{
			return false;
		}

		public bool Check_CandyboxSkins(PlayerOptions playerOptions)
		{
			return false;
		}

		private bool CheckForFireTypeWeapons(CharacterController currentCharacter)
		{
			return false;
		}

		private bool CheckForCoatOfArmsEvos(CharacterController currentCharacter)
		{
			return false;
		}

		public bool Weapon_Unlock_Damage_Achievement(AchievementManager achievementManager, List<WeaponType> weapons, float damage = 1000f)
		{
			return false;
		}
	}
}
