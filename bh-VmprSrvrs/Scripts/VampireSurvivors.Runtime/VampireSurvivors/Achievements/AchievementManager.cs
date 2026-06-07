using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Achievements
{
	[UsedImplicitly]
	public class AchievementManager : IInitializable, IDisposable
	{
		[Serializable]
		public enum AchievementUnlockType
		{
			KillXNumberOfEnemies = 1,
			KillXNumberOfEnemiesOfTypes = 2,
			KillXNumberOfEnemiesInRun = 3,
			KillBossTypesInRun = 4,
			PlayInStage = 5,
			SurviveXSeconds = 6,
			FindItems = 7,
			FindXNumberOfItems = 8,
			FindXNumberOfAnyItems = 9,
			HaveOpenedCoffinForXCharacter = 10,
			FindWeapons = 11,
			CollectedWeapons = 12,
			HaveLeveledWeaponToSpecificLevel = 13,
			HaveLeveledWeaponToSpecificLevelOrEvolved = 14,
			ReachedXLevel = 15,
			ReachedXLevelAsCharacter = 16,
			PlayXCharacter = 17,
			HaveModifiers = 18
		}

		[Serializable]
		public enum ModifierType
		{
			Hyper = 1,
			Hurry = 2,
			LimitBreak = 3,
			Inverse = 4,
			Endless = 5
		}

		public List<AchievementType> AchievementsUnlockedOnPlatform;

		[Inject]
		private DataManager _dataManager;

		[Inject]
		private AdventureProgressManager _adventureProgressManager;

		[Inject]
		private AdventureManager _adventureManager;

		private Dictionary<AchievementType, AchievementData> _Achievements;

		private List<AchievementType> _UnAchievedAchievements;

		private List<AchievementData> _recentlyUnlocked;

		private List<AchievementData> _recentlyUnlockedAdventureProgress;

		private List<SecretType> _newSecrets;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _Characters;

		private List<AchievementType> _AchivementsToUnlock;

		private List<ICustomAchievements> _CustomAchievementHandellers;

		private PlayerOptions _playerOptions;

		private GameSessionData _sessionData;

		private MultiplayerManager _multiplayer;

		public bool allowUnlocking;

		private int _CollectionCount;

		public List<SecretType> NewSecrets => null;

		public List<VampireSurvivors.Objects.Characters.CharacterController> Characters => null;

		[Inject]
		private void Construct(PlayerOptions playerOptions, GameSessionData session, MultiplayerManager multi)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Setup()
		{
		}

		public void UnlockAchievement(AchievementType achievement)
		{
		}

		public void UnlockAchievementDirectly(AchievementType t)
		{
		}

		public void CheckForStartupAchievements()
		{
		}

		public void FixUnlocks()
		{
		}

		public List<SecretType> CheckAllSecrets()
		{
			return null;
		}

		public List<AchievementData> CheckAllAchievements()
		{
			return null;
		}

		private List<AchievementData> BuildAchievedList(Dictionary<AdventureAchievementType, AchievementData> achieved)
		{
			return null;
		}

		public void UnlockAchievementsAndGiveRewards()
		{
		}

		public bool Unlock(AchievementType t)
		{
			return false;
		}

		private void PopPlatformAchievement(AchievementType t)
		{
		}

		private bool CheckAchievement(AchievementData achievementData)
		{
			return false;
		}

		private bool CheckUnlockCondition(AchievementUnlockConditionData unlockConditionData)
		{
			return false;
		}

		private bool CheckKillXNumberOfEnemies(int requiredNumberOfKills)
		{
			return false;
		}

		private bool CheckKillXNumberOfEnemiesOfTypes(List<EnemyType> enemyTypes, int requiredNumberOfKills)
		{
			return false;
		}

		private bool CheckKillXNumberOfEnemiesInRun(int requiredNumberOfKills)
		{
			return false;
		}

		private bool CheckKillBossTypesInRun(List<EnemyType> enemyTypes)
		{
			return false;
		}

		private bool CheckPlayInStage(StageType requiredStage)
		{
			return false;
		}

		private bool CheckSurviveXSeconds(float requiredSurvivedSeconds)
		{
			return false;
		}

		private bool CheckFindItems(List<ItemType> requiredItemTypes)
		{
			return false;
		}

		private bool CheckFindXNumberOfItems(List<ItemType> requiredItemTypes, int requiredNumberOfItems)
		{
			return false;
		}

		private bool CheckFindXNumberOfAnyItems(int requiredNumberOfItems)
		{
			return false;
		}

		public bool CheckHaveOpenedCoffinForXCharacter(CharacterType requiredCharacterType)
		{
			return false;
		}

		private bool CheckFindWeapons(List<WeaponType> requiredWeapons)
		{
			return false;
		}

		private bool CheckCollectedWeapons(List<WeaponType> requiredWeapons)
		{
			return false;
		}

		private bool CheckHaveLeveledWeaponToSpecificLevel(WeaponType weaponType, int level)
		{
			return false;
		}

		private bool CheckHaveLeveledWeaponToSpecificLevelOrEvolved(WeaponType weaponType, int level, WeaponType evolvedWeaponType)
		{
			return false;
		}

		private bool CheckReachedXLevel(int requiredLevel)
		{
			return false;
		}

		private bool ReachedXLevelAsCharacter(CharacterType characterType, int requiredLevel)
		{
			return false;
		}

		private bool CheckPlayXCharacter(CharacterType requiredCharacterType)
		{
			return false;
		}

		private bool CheckHaveModifiers(List<ModifierType> requiredModifierTypes)
		{
			return false;
		}

		public void AddRecentlyUnlockedAdventureProgress(AchievementData achievementData)
		{
		}

		public Sprite GetSpriteForAchievement(AchievementData bad)
		{
			return null;
		}

		public Sprite GetFrameForSprite(AchievementData bad)
		{
			return null;
		}

		public string GetUnlockText(AchievementData bad)
		{
			return null;
		}

		public bool CheckForCoffinOpen(CharacterType characterType)
		{
			return false;
		}

		public int GetPickUpCount(ItemType t)
		{
			return 0;
		}

		public int GetPlayerWeaponLevel(VampireSurvivors.Objects.Characters.CharacterController character, WeaponType t, bool checkRemovedEquipment = true, bool checkHiddenEquipment = false)
		{
			return 0;
		}

		public void ApplyPlatformAchievementsRetroactively()
		{
		}

		public int CountKilledEnemiesAndVariants(EnemyType enemyType)
		{
			return 0;
		}

		public bool CheckRequiredCharacterUnlocked(AchievementType achievementType)
		{
			return false;
		}
	}
}
