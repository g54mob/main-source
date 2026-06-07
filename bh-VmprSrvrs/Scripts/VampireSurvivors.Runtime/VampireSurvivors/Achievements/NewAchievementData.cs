using System.Collections.Generic;
using Newtonsoft.Json;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements
{
	public class NewAchievementData
	{
		public List<AchievementUnlockConditionData> UnlockConditions { get; set; }

		public string description { get; set; }

		public int goldPrize { get; set; }

		public string weaponIcon { get; set; }

		public bool achieved { get; set; }

		public string hyperToUnlock { get; set; }

		public string stageToUnlock { get; set; }

		public string weaponToUnlock { get; set; }

		public bool mistery { get; set; }

		public string relicToUnlock { get; set; }

		public string arcanaToUnlock { get; set; }

		public string characterToUnlock { get; set; }

		public List<CharacterType> charactersToUnlock { get; set; }

		public string powerUpToUnlock { get; set; }

		public AchievementType Type { get; set; }

		public CharacterType requiresChar { get; set; }

		public ItemType requiresItem { get; set; }

		public StageType? requiresStage { get; set; }

		public WeaponType? requiresWeapon { get; set; }

		public List<SkinToUnlock> skinsToUnlock { get; set; }

		public AdventureProgressData adventureUnlockData { get; set; }

		public AchievementPlatformData[] PlatformsData { get; set; }

		[JsonIgnore]
		public string CurrentPlatformData => null;

		public virtual string GetLocalizedDescription(AchievementType type)
		{
			return null;
		}

		public virtual string GetLocalizedDescription(AdventureAchievementType type)
		{
			return null;
		}

		public virtual string GetLocalizedUnlocks()
		{
			return null;
		}

		public virtual string GetLocalizedName()
		{
			return null;
		}

		public string GetLocalizationKey()
		{
			return null;
		}

		public virtual bool CheckForCompletion()
		{
			return false;
		}

		public virtual void Unlock(PlayerOptionsData config, PlayerOptions playerOptions)
		{
		}

		public virtual void FixUnlock(PlayerOptions playerOptions, DataManager dataManager, AchievementType type, Dictionary<PowerUpType, int> powerUpCounts)
		{
		}
	}
}
