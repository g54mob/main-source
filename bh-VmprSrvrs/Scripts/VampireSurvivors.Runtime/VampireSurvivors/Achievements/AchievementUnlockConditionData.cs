using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Achievements
{
	public class AchievementUnlockConditionData
	{
		public AchievementManager.AchievementUnlockType AchievementUnlockType;

		public int RequiredNumEnemiesKilled;

		public List<EnemyType> RequiredEnemyTypes;

		public StageType RequiredStageType;

		public float RequiredSurvivedSeconds;

		public List<ItemType> RequiredItems;

		public int RequiredNumberOfItems;

		public CharacterType RequiredCharacterType;

		public List<WeaponType> RequiredWeapons;

		public List<WeaponType> RequiredEvolvedWeapons;

		public int RequiredLevel;

		public List<AchievementManager.ModifierType> RequiredMofiers;
	}
}
