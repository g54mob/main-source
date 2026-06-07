using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Achievements
{
	public static class AchivementManagerSupport
	{
		public static bool HasAlreadyUnlocked(AchievementType t, PlayerOptionsData config)
		{
			return false;
		}

		public static int GetPlayerWeaponLevel(CharacterController character, WeaponType t, bool checkRemovedEquipment = true, bool checkHiddenEquipment = false)
		{
			return 0;
		}

		public static int CalcualteNewCollectionCount(DataManager _dataManager, PlayerOptions _playerOptions)
		{
			return 0;
		}

		public static Equipment GetPlayerEquipment(CharacterController character, WeaponType t, bool checkRemovedEquipment = false)
		{
			return null;
		}
	}
}
