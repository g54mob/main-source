using System;
using System.Collections.Generic;
using Rewired.Utils.Libraries.TinyJson;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Props;
using VampireSurvivors.UI;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class PlayerOptionsData
	{
		private CharacterType _selectedChar;

		public CollectionsPage.FilterType CollectionFilterMode;

		public List<ContentGroupType> BanishedContentGroups;

		public int TP_FrozenShadesCount;

		public int TP_AxeArmorCount;

		public int TP_SniperCount;

		public int TP_PortraitsCount;

		public List<CharacterType> OnlineMultiplayerSelections;

		public string saveDate { get; set; }

		public string Platform { get; set; }

		public bool SaveSyncPlatformAchievements { get; set; }

		public SystemPlatformTypes? SaveOriginalPlatform { get; set; }

		public List<SystemPlatformTypes> SaveTouchedPlatforms { get; set; }

		public int itemInCollection { get; set; }

		public int itemInUnlocks { get; set; }

		public int itemInSecrets { get; set; }

		public CharacterType SelectedCharacter
		{
			get
			{
				return default(CharacterType);
			}
			set
			{
			}
		}

		public StageType SelectedStage { get; set; }

		public bool SelectedHyper { get; set; }

		public bool AcceptedEULA { get; set; }

		public bool SelectedHurry { get; set; }

		public bool SelectedMazzo { get; set; }

		public bool SelectedLimitBreak { get; set; }

		public bool SelectedInverse { get; set; }

		public bool SelectedReapers { get; set; }

		public bool SelectedGoldenEggs { get; set; }

		public bool SelectedSharePassives { get; set; }

		public int SelectedArcana { get; set; }

		public bool SelectedSurvarots { get; set; }

		public bool ForcedSurvarots { get; set; }

		public int RunFoundSurvarots { get; set; }

		public bool SelectedRandomEvents { get; set; }

		public bool SelectedRandomLevels { get; set; }

		public bool SelectedBGMSave { get; set; }

		public BgmType SelectedBGM { get; set; }

		public BgmModType SelectedBGMMod { get; set; }

		public BgmPlaybackType SelectedBGMPlayback { get; set; }

		public bool SelectedOnlineFreeRoam { get; set; }

		public bool PlayBGMOnlyDuringRun { get; set; }

		public int SelectedMaxWeapons { get; set; }

		public bool Fullscreen { get; set; }

		public bool AutoEnableCloudSavesMobile { get; set; }

		public int Version { get; set; }

		public float Coins { get; set; }

		[DoNotSerialize]
		public float RunCoins { get; set; }

		[DoNotSerialize]
		public int RunEnemies { get; set; }

		[DoNotSerialize]
		public int RunBossesCount { get; set; }

		[DoNotSerialize]
		public List<ItemType> RunPickups { get; set; }

		[DoNotSerialize]
		public List<WeaponType> RunWeapons { get; set; }

		[DoNotSerialize]
		public List<CharacterType> RunCoffins { get; set; }

		[DoNotSerialize]
		public List<EnemyType> RunBossesTypes { get; set; }

		[DoNotSerialize]
		public int RunStarryHeavnes { get; set; }

		[DoNotSerialize]
		public int RunWeirdSoulsPurifier { get; set; }

		[DoNotSerialize]
		public Dictionary<EnemyType, int> RunKillCount { get; set; }

		[DoNotSerialize]
		public int RunPickups_Coins { get; set; }

		public float LifetimeCoins { get; set; }

		public float TotalCoins { get; set; }

		public int BeginnersLuck { get; set; }

		public float RunFever { get; set; }

		[DoNotSerialize]
		public int RunHunger { get; set; }

		public float RawRunHeal { get; set; }

		public float LifetimeSurvived { get; set; }

		public float LifetimeHeal { get; set; }

		public float OwO { get; set; }

		public int CompletedHurries { get; set; }

		public float TrainHazardEnemiesHit { get; set; }

		public int TopLapsCarlo { get; set; }

		public int TotalLapsCarlo { get; set; }

		public int TopLapsHighway { get; set; }

		public int TotalLapsHighway { get; set; }

		public bool ReducePhysics { get; set; }

		public bool ClassicMusic { get; set; }

		public bool VisuallyInvertStages { get; set; }

		public bool HideProgress { get; set; }

		public bool SoundsEnabled { get; set; }

		public bool MusicEnabled { get; set; }

		public float SoundsVolume { get; set; }

		public float MusicVolume { get; set; }

		public bool FlashingVFXEnabled { get; set; }

		public bool JoystickVisible { get; set; }

		public VisibleJoystickType SelectedJoystickType { get; set; }

		public bool HideAdsButtons { get; set; }

		public bool DamageNumbersEnabled { get; set; }

		public bool GlimmerCarouselEnabled { get; set; }

		public bool StreamSafeEnabled { get; set; }

		public bool hideXPBar { get; set; }

		public bool CheatCodeUsed { get; set; }

		public bool HasKilledTheFinalBoss { get; set; }

		public bool HasSeenFinalFireworks { get; set; }

		public string Language { get; set; }

		public bool ShowQuitDescription { get; set; }

		public bool HideCompletedAchievements { get; set; }

		public int PlayedRNJ { get; set; }

		public bool ShowPickups { get; set; }

		public bool ShowSmallMapIcons { get; set; }

		public float LongestFever { get; set; }

		public float HighestFever { get; set; }

		public bool HasUsedMirror { get; set; }

		public bool HasUsedTrumpet { get; set; }

		public List<CharacterType> BoughtCharacters { get; set; }

		public List<SkinType> BoughtSkins { get; set; }

		public List<PowerUpLevel> BoughtPowerups { get; set; }

		public List<WeaponType> CollectedWeapons { get; set; }

		public List<WeaponType> UnlockedWeapons { get; set; }

		public List<CharacterType> UnlockedCharacters { get; set; }

		public List<CharacterType> HostOnlyUnlockedCharacters { get; set; }

		public List<CharacterType> OpenedCoffins { get; set; }

		public List<ItemType> CollectedItems { get; set; }

		public List<AchievementType> Achievements { get; set; }

		public List<SecretType> Secrets { get; set; }

		public List<StageType> UnlockedStages { get; set; }

		public List<StageType> UnlockedHypers { get; set; }

		public List<PowerUpType> UnlockedPowerUpRanks { get; set; }

		public List<ArcanaType> UnlockedArcanas { get; set; }

		public List<PowerUpType> DisabledPowerups { get; set; }

		public Dictionary<EnemyType, int> KillCount { get; set; }

		public Dictionary<ItemType, int> PickupCount { get; set; }

		public Dictionary<PropType, int> DestroyedCount { get; set; }

		public Dictionary<CharacterType, List<StageType>> StageCompletionLog { get; set; }

		public Dictionary<CharacterType, List<CharacterStageData>> CharacterStageData { get; set; }

		public Dictionary<CharacterType, int> CharacterEnemiesKilled { get; set; }

		public Dictionary<CharacterType, int> CharacterSurvivedMinutes { get; set; }

		[Obsolete("UnlockedSkins is deprecated, please use UnlockedSkinsV2 instead.")]
		public Dictionary<CharacterType, List<SkinType>> UnlockedSkins { get; set; }

		public Dictionary<CharacterType, List<SkinType>> UnlockedSkinsV2 { get; set; }

		[Obsolete("SelectedSkins is deprecated, please use SelectedSkinsV2 instead.")]
		public Dictionary<CharacterType, int> SelectedSkins { get; set; }

		public Dictionary<CharacterType, SkinType> SelectedSkinsV2 { get; set; }

		public Dictionary<StageType, BgmType> MusicSelectionPerStage { get; set; }

		public string checksum { get; set; }

		public Dictionary<CharacterType, Dictionary<string, float>> CharacterEggInfo { get; set; }

		public Dictionary<CharacterType, float> CharacterEggCount { get; set; }

		public float TotalEggCount { get; set; }

		public bool Didit { get; set; }

		public int Seals { get; set; }

		public List<ItemType> SealedItems { get; set; }

		public List<WeaponType> SealedWeapons { get; set; }

		public List<ItemType> ContentGroupSealedItems { get; set; }

		public List<WeaponType> ContentGroupSealedWeapons { get; set; }

		public bool EnableBonusAdsMechanics { get; set; }

		public bool ScreenShakeEnabled { get; set; }

		public bool ControllerVibrationEnabled { get; set; }

		public bool AssignControllerToPlayer1 { get; set; }

		public bool PopupsShouldFollowPriority { get; set; }

		public bool ShowPlayerIndicators { get; set; }

		public bool PermanentCoopOutlines { get; set; }

		public bool TintUISelection { get; set; }

		public uint[] PlayerColours { get; set; }

		public bool SequentialChestMode { get; set; }

		[DoNotSerialize]
		public bool HideDebugUI { get; set; }

		[DoNotSerialize]
		public bool HideGameUI { get; set; }

		public bool DisableMovingBackground { get; set; }

		public bool DisableBlood { get; set; }

		public BorderType BorderType { get; set; }

		public bool PixelFont { get; set; }

		public bool DisplayDefangedEnemies { get; set; }

		public bool StageLighting { get; set; }

		public bool HasSeenAdventureReveal { get; set; }

		public bool ShouldPlayAdventureReveal { get; set; }

		public bool HideUnavailableAdventures { get; set; }

		public bool HasSeenAdventuresIntroTutorial { get; set; }

		public float AdventureStars { get; set; }

		public bool HasPlayedStage3 { get; set; }

		public bool HasSeenDarkanaTransition { get; set; }

		public bool HasFixedSkinIds { get; set; }

		public bool ShowTPCredits { get; set; }

		public int LibraryMerchantGoldSpent { get; set; }

		public bool PassedGaeaEvent { get; set; }

		public int EME_NextBossBiome { get; set; }

		public int WW_ZoneProgress { get; set; }

		public AdventureType? SelectedAdventureType { get; set; }

		public int AdventureCompletionCount { get; set; }

		public List<AdventureAchievementType> AdventureProgress { get; set; }

		public Dictionary<AdventureType, PlayerOptionsData> AdventuresSaveData { get; set; }

		public float TotalAdventurePlaytime { get; set; }

		public float AllTimeAdventurePlaytime { get; set; }

		public Dictionary<PowerUpType, int> AscensionPointsAllocation { get; set; }

		public List<AdventureType> CompletedAdventures { get; set; }

		public bool HasSeenMerchantTutorial { get; set; }

		public List<AdventureType> SeenAscensionPopups { get; set; }

		[DoNotSerialize]
		public Dictionary<PropType, int> RunDestroyedProps { get; set; }

		[DoNotSerialize]
		public Dictionary<ItemType, int> RunItemsPickupCount { get; set; }

		public StageType NextAutoSelectStage { get; set; }

		public PlayerOptionsData(bool addDefaults = true)
		{
		}

		public bool Equals(PlayerOptionsData data)
		{
			return false;
		}

		public bool HasCollectedItem(ItemType item)
		{
			return false;
		}

		public bool PlatformAchievementsAllowed()
		{
			return false;
		}

		public PlayerOptionsData Clone()
		{
			return null;
		}
	}
}
