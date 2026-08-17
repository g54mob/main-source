using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Props;
using VampireSurvivors.UI;

namespace VampireSurvivors.Data;

[Serializable]
public class PlayerOptionsData
{
	private string _003CsaveDate_003Ek__BackingField;

	private string _003CPlatform_003Ek__BackingField;

	private bool _003CSaveSyncPlatformAchievements_003Ek__BackingField;

	private SystemPlatformTypes? _003CSaveOriginalPlatform_003Ek__BackingField;

	private List<SystemPlatformTypes> _003CSaveTouchedPlatforms_003Ek__BackingField;

	private int _003CitemInCollection_003Ek__BackingField;

	private int _003CitemInUnlocks_003Ek__BackingField;

	private int _003CitemInSecrets_003Ek__BackingField;

	private CharacterType _selectedChar;

	private StageType _003CSelectedStage_003Ek__BackingField;

	private bool _003CSelectedHyper_003Ek__BackingField;

	private bool _003CAcceptedEULA_003Ek__BackingField;

	private bool _003CSelectedHurry_003Ek__BackingField;

	private bool _003CSelectedMazzo_003Ek__BackingField;

	private bool _003CSelectedLimitBreak_003Ek__BackingField;

	private bool _003CSelectedInverse_003Ek__BackingField;

	private bool _003CSelectedReapers_003Ek__BackingField;

	private bool _003CSelectedGoldenEggs_003Ek__BackingField;

	private bool _003CSelectedSharePassives_003Ek__BackingField;

	private int _003CSelectedArcana_003Ek__BackingField;

	private bool _003CSelectedSurvarots_003Ek__BackingField;

	private bool _003CForcedSurvarots_003Ek__BackingField;

	private int _003CRunFoundSurvarots_003Ek__BackingField;

	private bool _003CSelectedRandomEvents_003Ek__BackingField;

	private bool _003CSelectedRandomLevels_003Ek__BackingField;

	private bool _003CSelectedBGMSave_003Ek__BackingField;

	private BgmType _003CSelectedBGM_003Ek__BackingField;

	private BgmModType _003CSelectedBGMMod_003Ek__BackingField;

	private BgmPlaybackType _003CSelectedBGMPlayback_003Ek__BackingField;

	private bool _003CSelectedOnlineFreeRoam_003Ek__BackingField;

	private bool _003CPlayBGMOnlyDuringRun_003Ek__BackingField;

	private int _003CSelectedMaxWeapons_003Ek__BackingField;

	private bool _003CFullscreen_003Ek__BackingField;

	private bool _003CAutoEnableCloudSavesMobile_003Ek__BackingField;

	private int _003CVersion_003Ek__BackingField;

	private float _003CCoins_003Ek__BackingField;

	private float _003CRunCoins_003Ek__BackingField;

	private int _003CRunEnemies_003Ek__BackingField;

	private int _003CRunBossesCount_003Ek__BackingField;

	private List<ItemType> _003CRunPickups_003Ek__BackingField;

	private List<WeaponType> _003CRunWeapons_003Ek__BackingField;

	private List<CharacterType> _003CRunCoffins_003Ek__BackingField;

	private List<EnemyType> _003CRunBossesTypes_003Ek__BackingField;

	private int _003CRunStarryHeavnes_003Ek__BackingField;

	private int _003CRunWeirdSoulsPurifier_003Ek__BackingField;

	private Dictionary<EnemyType, int> _003CRunKillCount_003Ek__BackingField;

	private int _003CRunPickups_Coins_003Ek__BackingField;

	private float _003CLifetimeCoins_003Ek__BackingField;

	private float _003CTotalCoins_003Ek__BackingField;

	private int _003CBeginnersLuck_003Ek__BackingField;

	private float _003CRunFever_003Ek__BackingField;

	private int _003CRunHunger_003Ek__BackingField;

	private float _003CRawRunHeal_003Ek__BackingField;

	private float _003CLifetimeSurvived_003Ek__BackingField;

	private float _003CLifetimeHeal_003Ek__BackingField;

	private float _003COwO_003Ek__BackingField;

	private int _003CCompletedHurries_003Ek__BackingField;

	private float _003CTrainHazardEnemiesHit_003Ek__BackingField;

	private int _003CTopLapsCarlo_003Ek__BackingField;

	private int _003CTotalLapsCarlo_003Ek__BackingField;

	private int _003CTopLapsHighway_003Ek__BackingField;

	private int _003CTotalLapsHighway_003Ek__BackingField;

	private bool _003CReducePhysics_003Ek__BackingField;

	private bool _003CClassicMusic_003Ek__BackingField;

	private bool _003CVisuallyInvertStages_003Ek__BackingField;

	private bool _003CHideProgress_003Ek__BackingField;

	private bool _003CSoundsEnabled_003Ek__BackingField;

	private bool _003CMusicEnabled_003Ek__BackingField;

	private float _003CSoundsVolume_003Ek__BackingField;

	private float _003CMusicVolume_003Ek__BackingField;

	private bool _003CFlashingVFXEnabled_003Ek__BackingField;

	private bool _003CJoystickVisible_003Ek__BackingField;

	private VisibleJoystickType _003CSelectedJoystickType_003Ek__BackingField;

	private bool _003CHideAdsButtons_003Ek__BackingField;

	private bool _003CDamageNumbersEnabled_003Ek__BackingField;

	private bool _003CGlimmerCarouselEnabled_003Ek__BackingField;

	private bool _003CStreamSafeEnabled_003Ek__BackingField;

	private bool _003ChideXPBar_003Ek__BackingField;

	private bool _003CCheatCodeUsed_003Ek__BackingField;

	private bool _003CHasKilledTheFinalBoss_003Ek__BackingField;

	private bool _003CHasSeenFinalFireworks_003Ek__BackingField;

	private string _003CLanguage_003Ek__BackingField;

	private bool _003CShowQuitDescription_003Ek__BackingField;

	private bool _003CHideCompletedAchievements_003Ek__BackingField;

	private int _003CPlayedRNJ_003Ek__BackingField;

	private bool _003CShowPickups_003Ek__BackingField;

	private bool _003CShowSmallMapIcons_003Ek__BackingField;

	private float _003CLongestFever_003Ek__BackingField;

	private float _003CHighestFever_003Ek__BackingField;

	private bool _003CHasUsedMirror_003Ek__BackingField;

	private bool _003CHasUsedTrumpet_003Ek__BackingField;

	private List<CharacterType> _003CBoughtCharacters_003Ek__BackingField;

	private List<SkinType> _003CBoughtSkins_003Ek__BackingField;

	private List<PowerUpLevel> _003CBoughtPowerups_003Ek__BackingField;

	private List<WeaponType> _003CCollectedWeapons_003Ek__BackingField;

	private List<WeaponType> _003CUnlockedWeapons_003Ek__BackingField;

	private List<CharacterType> _003CUnlockedCharacters_003Ek__BackingField;

	private List<CharacterType> _003CHostOnlyUnlockedCharacters_003Ek__BackingField;

	private List<CharacterType> _003COpenedCoffins_003Ek__BackingField;

	private List<ItemType> _003CCollectedItems_003Ek__BackingField;

	private List<AchievementType> _003CAchievements_003Ek__BackingField;

	private List<SecretType> _003CSecrets_003Ek__BackingField;

	private List<StageType> _003CUnlockedStages_003Ek__BackingField;

	private List<StageType> _003CUnlockedHypers_003Ek__BackingField;

	private List<PowerUpType> _003CUnlockedPowerUpRanks_003Ek__BackingField;

	private List<ArcanaType> _003CUnlockedArcanas_003Ek__BackingField;

	private List<PowerUpType> _003CDisabledPowerups_003Ek__BackingField;

	private Dictionary<EnemyType, int> _003CKillCount_003Ek__BackingField;

	private Dictionary<ItemType, int> _003CPickupCount_003Ek__BackingField;

	private Dictionary<PropType, int> _003CDestroyedCount_003Ek__BackingField;

	private Dictionary<CharacterType, List<StageType>> _003CStageCompletionLog_003Ek__BackingField;

	private Dictionary<CharacterType, List<CharacterStageData>> _003CCharacterStageData_003Ek__BackingField;

	private Dictionary<CharacterType, int> _003CCharacterEnemiesKilled_003Ek__BackingField;

	private Dictionary<CharacterType, int> _003CCharacterSurvivedMinutes_003Ek__BackingField;

	private Dictionary<CharacterType, List<SkinType>> _003CUnlockedSkins_003Ek__BackingField;

	private Dictionary<CharacterType, List<SkinType>> _003CUnlockedSkinsV2_003Ek__BackingField;

	private Dictionary<CharacterType, int> _003CSelectedSkins_003Ek__BackingField;

	private Dictionary<CharacterType, SkinType> _003CSelectedSkinsV2_003Ek__BackingField;

	private Dictionary<StageType, BgmType> _003CMusicSelectionPerStage_003Ek__BackingField;

	private string _003Cchecksum_003Ek__BackingField;

	private Dictionary<CharacterType, Dictionary<string, float>> _003CCharacterEggInfo_003Ek__BackingField;

	private Dictionary<CharacterType, float> _003CCharacterEggCount_003Ek__BackingField;

	private float _003CTotalEggCount_003Ek__BackingField;

	private bool _003CDidit_003Ek__BackingField;

	private int _003CSeals_003Ek__BackingField;

	private List<ItemType> _003CSealedItems_003Ek__BackingField;

	private List<WeaponType> _003CSealedWeapons_003Ek__BackingField;

	private List<ItemType> _003CContentGroupSealedItems_003Ek__BackingField;

	private List<WeaponType> _003CContentGroupSealedWeapons_003Ek__BackingField;

	private bool _003CEnableBonusAdsMechanics_003Ek__BackingField;

	private bool _003CScreenShakeEnabled_003Ek__BackingField;

	private bool _003CControllerVibrationEnabled_003Ek__BackingField;

	private bool _003CAssignControllerToPlayer1_003Ek__BackingField;

	private bool _003CPopupsShouldFollowPriority_003Ek__BackingField;

	private bool _003CShowPlayerIndicators_003Ek__BackingField;

	private bool _003CPermanentCoopOutlines_003Ek__BackingField;

	private bool _003CTintUISelection_003Ek__BackingField;

	private uint[] _003CPlayerColours_003Ek__BackingField;

	private bool _003CSequentialChestMode_003Ek__BackingField;

	private bool _003CHideDebugUI_003Ek__BackingField;

	private bool _003CHideGameUI_003Ek__BackingField;

	private bool _003CDisableMovingBackground_003Ek__BackingField;

	private bool _003CDisableBlood_003Ek__BackingField;

	private BorderType _003CBorderType_003Ek__BackingField;

	private bool _003CPixelFont_003Ek__BackingField;

	private bool _003CDisplayDefangedEnemies_003Ek__BackingField;

	private bool _003CStageLighting_003Ek__BackingField;

	private bool _003CHasSeenAdventureReveal_003Ek__BackingField;

	public CollectionsPage.FilterType CollectionFilterMode;

	private bool _003CShouldPlayAdventureReveal_003Ek__BackingField;

	private bool _003CHideUnavailableAdventures_003Ek__BackingField;

	private bool _003CHasSeenAdventuresIntroTutorial_003Ek__BackingField;

	private float _003CAdventureStars_003Ek__BackingField;

	private bool _003CHasPlayedStage3_003Ek__BackingField;

	private bool _003CHasSeenDarkanaTransition_003Ek__BackingField;

	private bool _003CHasFixedSkinIds_003Ek__BackingField;

	public List<ContentGroupType> BanishedContentGroups;

	private bool _003CShowTPCredits_003Ek__BackingField;

	public int TP_FrozenShadesCount;

	public int TP_AxeArmorCount;

	public int TP_SniperCount;

	public int TP_PortraitsCount;

	private int _003CLibraryMerchantGoldSpent_003Ek__BackingField;

	private bool _003CPassedGaeaEvent_003Ek__BackingField;

	private int _003CEME_NextBossBiome_003Ek__BackingField;

	private int _003CWW_ZoneProgress_003Ek__BackingField;

	private AdventureType? _003CSelectedAdventureType_003Ek__BackingField;

	private int _003CAdventureCompletionCount_003Ek__BackingField;

	private List<AdventureAchievementType> _003CAdventureProgress_003Ek__BackingField;

	private Dictionary<AdventureType, PlayerOptionsData> _003CAdventuresSaveData_003Ek__BackingField;

	private float _003CTotalAdventurePlaytime_003Ek__BackingField;

	private float _003CAllTimeAdventurePlaytime_003Ek__BackingField;

	private Dictionary<PowerUpType, int> _003CAscensionPointsAllocation_003Ek__BackingField;

	private List<AdventureType> _003CCompletedAdventures_003Ek__BackingField;

	private bool _003CHasSeenMerchantTutorial_003Ek__BackingField;

	private List<AdventureType> _003CSeenAscensionPopups_003Ek__BackingField;

	private Dictionary<PropType, int> _003CRunDestroyedProps_003Ek__BackingField;

	private Dictionary<ItemType, int> _003CRunItemsPickupCount_003Ek__BackingField;

	private StageType _003CNextAutoSelectStage_003Ek__BackingField;

	public List<CharacterType> OnlineMultiplayerSelections;

	public string saveDate
	{
		get
		{
			return _003CsaveDate_003Ek__BackingField;
		}
		set
		{
			_003CsaveDate_003Ek__BackingField = value;
		}
	}

	public string Platform
	{
		get
		{
			return _003CPlatform_003Ek__BackingField;
		}
		set
		{
			_003CPlatform_003Ek__BackingField = value;
		}
	}

	public bool SaveSyncPlatformAchievements
	{
		get
		{
			return _003CSaveSyncPlatformAchievements_003Ek__BackingField;
		}
		set
		{
			_003CSaveSyncPlatformAchievements_003Ek__BackingField = value;
		}
	}

	public SystemPlatformTypes? SaveOriginalPlatform
	{
		get
		{
			return _003CSaveOriginalPlatform_003Ek__BackingField;
		}
		set
		{
			_003CSaveOriginalPlatform_003Ek__BackingField = value;
		}
	}

	public List<SystemPlatformTypes> SaveTouchedPlatforms
	{
		get
		{
			return _003CSaveTouchedPlatforms_003Ek__BackingField;
		}
		set
		{
			_003CSaveTouchedPlatforms_003Ek__BackingField = value;
		}
	}

	public int itemInCollection
	{
		get
		{
			return _003CitemInCollection_003Ek__BackingField;
		}
		set
		{
			_003CitemInCollection_003Ek__BackingField = value;
		}
	}

	public int itemInUnlocks
	{
		get
		{
			return _003CitemInUnlocks_003Ek__BackingField;
		}
		set
		{
			_003CitemInUnlocks_003Ek__BackingField = value;
		}
	}

	public int itemInSecrets
	{
		get
		{
			return _003CitemInSecrets_003Ek__BackingField;
		}
		set
		{
			_003CitemInSecrets_003Ek__BackingField = value;
		}
	}

	public unsafe CharacterType SelectedCharacter
	{
		get
		{
			return _selectedChar;
		}
		set
		{
			//IL_0022: Expected O, but got Ref
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string message = "Setting selected character to " + text;
			Debug.Log(message);
			_selectedChar = value;
		}
	}

	public StageType SelectedStage
	{
		get
		{
			return _003CSelectedStage_003Ek__BackingField;
		}
		set
		{
			_003CSelectedStage_003Ek__BackingField = value;
		}
	}

	public bool SelectedHyper
	{
		get
		{
			return _003CSelectedHyper_003Ek__BackingField;
		}
		set
		{
			_003CSelectedHyper_003Ek__BackingField = value;
		}
	}

	public bool AcceptedEULA
	{
		get
		{
			return _003CAcceptedEULA_003Ek__BackingField;
		}
		set
		{
			_003CAcceptedEULA_003Ek__BackingField = value;
		}
	}

	public bool SelectedHurry
	{
		get
		{
			return _003CSelectedHurry_003Ek__BackingField;
		}
		set
		{
			_003CSelectedHurry_003Ek__BackingField = value;
		}
	}

	public bool SelectedMazzo
	{
		get
		{
			return _003CSelectedMazzo_003Ek__BackingField;
		}
		set
		{
			_003CSelectedMazzo_003Ek__BackingField = value;
		}
	}

	public bool SelectedLimitBreak
	{
		get
		{
			return _003CSelectedLimitBreak_003Ek__BackingField;
		}
		set
		{
			_003CSelectedLimitBreak_003Ek__BackingField = value;
		}
	}

	public bool SelectedInverse
	{
		get
		{
			return _003CSelectedInverse_003Ek__BackingField;
		}
		set
		{
			_003CSelectedInverse_003Ek__BackingField = value;
		}
	}

	public bool SelectedReapers
	{
		get
		{
			return _003CSelectedReapers_003Ek__BackingField;
		}
		set
		{
			_003CSelectedReapers_003Ek__BackingField = value;
		}
	}

	public bool SelectedGoldenEggs
	{
		get
		{
			return _003CSelectedGoldenEggs_003Ek__BackingField;
		}
		set
		{
			_003CSelectedGoldenEggs_003Ek__BackingField = value;
		}
	}

	public bool SelectedSharePassives
	{
		get
		{
			return _003CSelectedSharePassives_003Ek__BackingField;
		}
		set
		{
			_003CSelectedSharePassives_003Ek__BackingField = value;
		}
	}

	public int SelectedArcana
	{
		get
		{
			return _003CSelectedArcana_003Ek__BackingField;
		}
		set
		{
			_003CSelectedArcana_003Ek__BackingField = value;
		}
	}

	public bool SelectedSurvarots
	{
		get
		{
			return _003CSelectedSurvarots_003Ek__BackingField;
		}
		set
		{
			_003CSelectedSurvarots_003Ek__BackingField = value;
		}
	}

	public bool ForcedSurvarots
	{
		get
		{
			return _003CForcedSurvarots_003Ek__BackingField;
		}
		set
		{
			_003CForcedSurvarots_003Ek__BackingField = value;
		}
	}

	public int RunFoundSurvarots
	{
		get
		{
			return _003CRunFoundSurvarots_003Ek__BackingField;
		}
		set
		{
			_003CRunFoundSurvarots_003Ek__BackingField = value;
		}
	}

	public bool SelectedRandomEvents
	{
		get
		{
			return _003CSelectedRandomEvents_003Ek__BackingField;
		}
		set
		{
			_003CSelectedRandomEvents_003Ek__BackingField = value;
		}
	}

	public bool SelectedRandomLevels
	{
		get
		{
			return _003CSelectedRandomLevels_003Ek__BackingField;
		}
		set
		{
			_003CSelectedRandomLevels_003Ek__BackingField = value;
		}
	}

	public bool SelectedBGMSave
	{
		get
		{
			return _003CSelectedBGMSave_003Ek__BackingField;
		}
		set
		{
			_003CSelectedBGMSave_003Ek__BackingField = value;
		}
	}

	public BgmType SelectedBGM
	{
		get
		{
			return _003CSelectedBGM_003Ek__BackingField;
		}
		set
		{
			_003CSelectedBGM_003Ek__BackingField = value;
		}
	}

	public BgmModType SelectedBGMMod
	{
		get
		{
			return _003CSelectedBGMMod_003Ek__BackingField;
		}
		set
		{
			_003CSelectedBGMMod_003Ek__BackingField = value;
		}
	}

	public BgmPlaybackType SelectedBGMPlayback
	{
		get
		{
			return _003CSelectedBGMPlayback_003Ek__BackingField;
		}
		set
		{
			_003CSelectedBGMPlayback_003Ek__BackingField = value;
		}
	}

	public bool SelectedOnlineFreeRoam
	{
		get
		{
			return _003CSelectedOnlineFreeRoam_003Ek__BackingField;
		}
		set
		{
			_003CSelectedOnlineFreeRoam_003Ek__BackingField = value;
		}
	}

	public bool PlayBGMOnlyDuringRun
	{
		get
		{
			return _003CPlayBGMOnlyDuringRun_003Ek__BackingField;
		}
		set
		{
			_003CPlayBGMOnlyDuringRun_003Ek__BackingField = value;
		}
	}

	public int SelectedMaxWeapons
	{
		get
		{
			return _003CSelectedMaxWeapons_003Ek__BackingField;
		}
		set
		{
			_003CSelectedMaxWeapons_003Ek__BackingField = value;
		}
	}

	public bool Fullscreen
	{
		get
		{
			return _003CFullscreen_003Ek__BackingField;
		}
		set
		{
			_003CFullscreen_003Ek__BackingField = value;
		}
	}

	public bool AutoEnableCloudSavesMobile
	{
		get
		{
			return _003CAutoEnableCloudSavesMobile_003Ek__BackingField;
		}
		set
		{
			_003CAutoEnableCloudSavesMobile_003Ek__BackingField = value;
		}
	}

	public int Version
	{
		get
		{
			return _003CVersion_003Ek__BackingField;
		}
		set
		{
			_003CVersion_003Ek__BackingField = value;
		}
	}

	public float Coins
	{
		get
		{
			return _003CCoins_003Ek__BackingField;
		}
		set
		{
			_003CCoins_003Ek__BackingField = value;
		}
	}

	public float RunCoins
	{
		get
		{
			return _003CRunCoins_003Ek__BackingField;
		}
		set
		{
			_003CRunCoins_003Ek__BackingField = value;
		}
	}

	public int RunEnemies
	{
		get
		{
			return _003CRunEnemies_003Ek__BackingField;
		}
		set
		{
			_003CRunEnemies_003Ek__BackingField = value;
		}
	}

	public int RunBossesCount
	{
		get
		{
			return _003CRunBossesCount_003Ek__BackingField;
		}
		set
		{
			_003CRunBossesCount_003Ek__BackingField = value;
		}
	}

	public List<ItemType> RunPickups
	{
		get
		{
			return _003CRunPickups_003Ek__BackingField;
		}
		set
		{
			_003CRunPickups_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> RunWeapons
	{
		get
		{
			return _003CRunWeapons_003Ek__BackingField;
		}
		set
		{
			_003CRunWeapons_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> RunCoffins
	{
		get
		{
			return _003CRunCoffins_003Ek__BackingField;
		}
		set
		{
			_003CRunCoffins_003Ek__BackingField = value;
		}
	}

	public List<EnemyType> RunBossesTypes
	{
		get
		{
			return _003CRunBossesTypes_003Ek__BackingField;
		}
		set
		{
			_003CRunBossesTypes_003Ek__BackingField = value;
		}
	}

	public int RunStarryHeavnes
	{
		get
		{
			return _003CRunStarryHeavnes_003Ek__BackingField;
		}
		set
		{
			_003CRunStarryHeavnes_003Ek__BackingField = value;
		}
	}

	public int RunWeirdSoulsPurifier
	{
		get
		{
			return _003CRunWeirdSoulsPurifier_003Ek__BackingField;
		}
		set
		{
			_003CRunWeirdSoulsPurifier_003Ek__BackingField = value;
		}
	}

	public Dictionary<EnemyType, int> RunKillCount
	{
		get
		{
			return _003CRunKillCount_003Ek__BackingField;
		}
		set
		{
			_003CRunKillCount_003Ek__BackingField = value;
		}
	}

	public int RunPickups_Coins
	{
		get
		{
			return _003CRunPickups_Coins_003Ek__BackingField;
		}
		set
		{
			_003CRunPickups_Coins_003Ek__BackingField = value;
		}
	}

	public float LifetimeCoins
	{
		get
		{
			return _003CLifetimeCoins_003Ek__BackingField;
		}
		set
		{
			_003CLifetimeCoins_003Ek__BackingField = value;
		}
	}

	public float TotalCoins
	{
		get
		{
			return _003CTotalCoins_003Ek__BackingField;
		}
		set
		{
			_003CTotalCoins_003Ek__BackingField = value;
		}
	}

	public int BeginnersLuck
	{
		get
		{
			return _003CBeginnersLuck_003Ek__BackingField;
		}
		set
		{
			_003CBeginnersLuck_003Ek__BackingField = value;
		}
	}

	public float RunFever
	{
		get
		{
			return _003CRunFever_003Ek__BackingField;
		}
		set
		{
			_003CRunFever_003Ek__BackingField = value;
		}
	}

	public int RunHunger
	{
		get
		{
			return _003CRunHunger_003Ek__BackingField;
		}
		set
		{
			_003CRunHunger_003Ek__BackingField = value;
		}
	}

	public float RawRunHeal
	{
		get
		{
			return _003CRawRunHeal_003Ek__BackingField;
		}
		set
		{
			_003CRawRunHeal_003Ek__BackingField = value;
		}
	}

	public float LifetimeSurvived
	{
		get
		{
			return _003CLifetimeSurvived_003Ek__BackingField;
		}
		set
		{
			_003CLifetimeSurvived_003Ek__BackingField = value;
		}
	}

	public float LifetimeHeal
	{
		get
		{
			return _003CLifetimeHeal_003Ek__BackingField;
		}
		set
		{
			_003CLifetimeHeal_003Ek__BackingField = value;
		}
	}

	public float OwO
	{
		get
		{
			return _003COwO_003Ek__BackingField;
		}
		set
		{
			_003COwO_003Ek__BackingField = value;
		}
	}

	public int CompletedHurries
	{
		get
		{
			return _003CCompletedHurries_003Ek__BackingField;
		}
		set
		{
			_003CCompletedHurries_003Ek__BackingField = value;
		}
	}

	public float TrainHazardEnemiesHit
	{
		get
		{
			return _003CTrainHazardEnemiesHit_003Ek__BackingField;
		}
		set
		{
			_003CTrainHazardEnemiesHit_003Ek__BackingField = value;
		}
	}

	public int TopLapsCarlo
	{
		get
		{
			return _003CTopLapsCarlo_003Ek__BackingField;
		}
		set
		{
			_003CTopLapsCarlo_003Ek__BackingField = value;
		}
	}

	public int TotalLapsCarlo
	{
		get
		{
			return _003CTotalLapsCarlo_003Ek__BackingField;
		}
		set
		{
			_003CTotalLapsCarlo_003Ek__BackingField = value;
		}
	}

	public int TopLapsHighway
	{
		get
		{
			return _003CTopLapsHighway_003Ek__BackingField;
		}
		set
		{
			_003CTopLapsHighway_003Ek__BackingField = value;
		}
	}

	public int TotalLapsHighway
	{
		get
		{
			return _003CTotalLapsHighway_003Ek__BackingField;
		}
		set
		{
			_003CTotalLapsHighway_003Ek__BackingField = value;
		}
	}

	public bool ReducePhysics
	{
		get
		{
			return _003CReducePhysics_003Ek__BackingField;
		}
		set
		{
			_003CReducePhysics_003Ek__BackingField = value;
		}
	}

	public bool ClassicMusic
	{
		get
		{
			return _003CClassicMusic_003Ek__BackingField;
		}
		set
		{
			_003CClassicMusic_003Ek__BackingField = value;
		}
	}

	public bool VisuallyInvertStages
	{
		get
		{
			return _003CVisuallyInvertStages_003Ek__BackingField;
		}
		set
		{
			_003CVisuallyInvertStages_003Ek__BackingField = value;
		}
	}

	public bool HideProgress
	{
		get
		{
			return _003CHideProgress_003Ek__BackingField;
		}
		set
		{
			_003CHideProgress_003Ek__BackingField = value;
		}
	}

	public bool SoundsEnabled
	{
		get
		{
			return _003CSoundsEnabled_003Ek__BackingField;
		}
		set
		{
			_003CSoundsEnabled_003Ek__BackingField = value;
		}
	}

	public bool MusicEnabled
	{
		get
		{
			return _003CMusicEnabled_003Ek__BackingField;
		}
		set
		{
			_003CMusicEnabled_003Ek__BackingField = value;
		}
	}

	public float SoundsVolume
	{
		get
		{
			return _003CSoundsVolume_003Ek__BackingField;
		}
		set
		{
			_003CSoundsVolume_003Ek__BackingField = value;
		}
	}

	public float MusicVolume
	{
		get
		{
			return _003CMusicVolume_003Ek__BackingField;
		}
		set
		{
			_003CMusicVolume_003Ek__BackingField = value;
		}
	}

	public bool FlashingVFXEnabled
	{
		get
		{
			return _003CFlashingVFXEnabled_003Ek__BackingField;
		}
		set
		{
			_003CFlashingVFXEnabled_003Ek__BackingField = value;
		}
	}

	public bool JoystickVisible
	{
		get
		{
			return _003CJoystickVisible_003Ek__BackingField;
		}
		set
		{
			_003CJoystickVisible_003Ek__BackingField = value;
		}
	}

	public VisibleJoystickType SelectedJoystickType
	{
		get
		{
			return _003CSelectedJoystickType_003Ek__BackingField;
		}
		set
		{
			_003CSelectedJoystickType_003Ek__BackingField = value;
		}
	}

	public bool HideAdsButtons
	{
		get
		{
			return _003CHideAdsButtons_003Ek__BackingField;
		}
		set
		{
			_003CHideAdsButtons_003Ek__BackingField = value;
		}
	}

	public bool DamageNumbersEnabled
	{
		get
		{
			return _003CDamageNumbersEnabled_003Ek__BackingField;
		}
		set
		{
			_003CDamageNumbersEnabled_003Ek__BackingField = value;
		}
	}

	public bool GlimmerCarouselEnabled
	{
		get
		{
			return _003CGlimmerCarouselEnabled_003Ek__BackingField;
		}
		set
		{
			_003CGlimmerCarouselEnabled_003Ek__BackingField = value;
		}
	}

	public bool StreamSafeEnabled
	{
		get
		{
			return _003CStreamSafeEnabled_003Ek__BackingField;
		}
		set
		{
			_003CStreamSafeEnabled_003Ek__BackingField = value;
		}
	}

	public bool hideXPBar
	{
		get
		{
			return _003ChideXPBar_003Ek__BackingField;
		}
		set
		{
			_003ChideXPBar_003Ek__BackingField = value;
		}
	}

	public bool CheatCodeUsed
	{
		get
		{
			return _003CCheatCodeUsed_003Ek__BackingField;
		}
		set
		{
			_003CCheatCodeUsed_003Ek__BackingField = value;
		}
	}

	public bool HasKilledTheFinalBoss
	{
		get
		{
			return _003CHasKilledTheFinalBoss_003Ek__BackingField;
		}
		set
		{
			_003CHasKilledTheFinalBoss_003Ek__BackingField = value;
		}
	}

	public bool HasSeenFinalFireworks
	{
		get
		{
			return _003CHasSeenFinalFireworks_003Ek__BackingField;
		}
		set
		{
			_003CHasSeenFinalFireworks_003Ek__BackingField = value;
		}
	}

	public string Language
	{
		get
		{
			return _003CLanguage_003Ek__BackingField;
		}
		set
		{
			_003CLanguage_003Ek__BackingField = value;
		}
	}

	public bool ShowQuitDescription
	{
		get
		{
			return _003CShowQuitDescription_003Ek__BackingField;
		}
		set
		{
			_003CShowQuitDescription_003Ek__BackingField = value;
		}
	}

	public bool HideCompletedAchievements
	{
		get
		{
			return _003CHideCompletedAchievements_003Ek__BackingField;
		}
		set
		{
			_003CHideCompletedAchievements_003Ek__BackingField = value;
		}
	}

	public int PlayedRNJ
	{
		get
		{
			return _003CPlayedRNJ_003Ek__BackingField;
		}
		set
		{
			_003CPlayedRNJ_003Ek__BackingField = value;
		}
	}

	public bool ShowPickups
	{
		get
		{
			return _003CShowPickups_003Ek__BackingField;
		}
		set
		{
			_003CShowPickups_003Ek__BackingField = value;
		}
	}

	public bool ShowSmallMapIcons
	{
		get
		{
			return _003CShowSmallMapIcons_003Ek__BackingField;
		}
		set
		{
			_003CShowSmallMapIcons_003Ek__BackingField = value;
		}
	}

	public float LongestFever
	{
		get
		{
			return _003CLongestFever_003Ek__BackingField;
		}
		set
		{
			_003CLongestFever_003Ek__BackingField = value;
		}
	}

	public float HighestFever
	{
		get
		{
			return _003CHighestFever_003Ek__BackingField;
		}
		set
		{
			_003CHighestFever_003Ek__BackingField = value;
		}
	}

	public bool HasUsedMirror
	{
		get
		{
			return _003CHasUsedMirror_003Ek__BackingField;
		}
		set
		{
			_003CHasUsedMirror_003Ek__BackingField = value;
		}
	}

	public bool HasUsedTrumpet
	{
		get
		{
			return _003CHasUsedTrumpet_003Ek__BackingField;
		}
		set
		{
			_003CHasUsedTrumpet_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> BoughtCharacters
	{
		get
		{
			return _003CBoughtCharacters_003Ek__BackingField;
		}
		set
		{
			_003CBoughtCharacters_003Ek__BackingField = value;
		}
	}

	public List<SkinType> BoughtSkins
	{
		get
		{
			return _003CBoughtSkins_003Ek__BackingField;
		}
		set
		{
			_003CBoughtSkins_003Ek__BackingField = value;
		}
	}

	public List<PowerUpLevel> BoughtPowerups
	{
		get
		{
			return _003CBoughtPowerups_003Ek__BackingField;
		}
		set
		{
			_003CBoughtPowerups_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> CollectedWeapons
	{
		get
		{
			return _003CCollectedWeapons_003Ek__BackingField;
		}
		set
		{
			_003CCollectedWeapons_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> UnlockedWeapons
	{
		get
		{
			return _003CUnlockedWeapons_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedWeapons_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> UnlockedCharacters
	{
		get
		{
			return _003CUnlockedCharacters_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedCharacters_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> HostOnlyUnlockedCharacters
	{
		get
		{
			return _003CHostOnlyUnlockedCharacters_003Ek__BackingField;
		}
		set
		{
			_003CHostOnlyUnlockedCharacters_003Ek__BackingField = value;
		}
	}

	public List<CharacterType> OpenedCoffins
	{
		get
		{
			return _003COpenedCoffins_003Ek__BackingField;
		}
		set
		{
			_003COpenedCoffins_003Ek__BackingField = value;
		}
	}

	public List<ItemType> CollectedItems
	{
		get
		{
			return _003CCollectedItems_003Ek__BackingField;
		}
		set
		{
			_003CCollectedItems_003Ek__BackingField = value;
		}
	}

	public List<AchievementType> Achievements
	{
		get
		{
			return _003CAchievements_003Ek__BackingField;
		}
		set
		{
			_003CAchievements_003Ek__BackingField = value;
		}
	}

	public List<SecretType> Secrets
	{
		get
		{
			return _003CSecrets_003Ek__BackingField;
		}
		set
		{
			_003CSecrets_003Ek__BackingField = value;
		}
	}

	public List<StageType> UnlockedStages
	{
		get
		{
			return _003CUnlockedStages_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedStages_003Ek__BackingField = value;
		}
	}

	public List<StageType> UnlockedHypers
	{
		get
		{
			return _003CUnlockedHypers_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedHypers_003Ek__BackingField = value;
		}
	}

	public List<PowerUpType> UnlockedPowerUpRanks
	{
		get
		{
			return _003CUnlockedPowerUpRanks_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedPowerUpRanks_003Ek__BackingField = value;
		}
	}

	public List<ArcanaType> UnlockedArcanas
	{
		get
		{
			return _003CUnlockedArcanas_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedArcanas_003Ek__BackingField = value;
		}
	}

	public List<PowerUpType> DisabledPowerups
	{
		get
		{
			return _003CDisabledPowerups_003Ek__BackingField;
		}
		set
		{
			_003CDisabledPowerups_003Ek__BackingField = value;
		}
	}

	public Dictionary<EnemyType, int> KillCount
	{
		get
		{
			return _003CKillCount_003Ek__BackingField;
		}
		set
		{
			_003CKillCount_003Ek__BackingField = value;
		}
	}

	public Dictionary<ItemType, int> PickupCount
	{
		get
		{
			return _003CPickupCount_003Ek__BackingField;
		}
		set
		{
			_003CPickupCount_003Ek__BackingField = value;
		}
	}

	public Dictionary<PropType, int> DestroyedCount
	{
		get
		{
			return _003CDestroyedCount_003Ek__BackingField;
		}
		set
		{
			_003CDestroyedCount_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, List<StageType>> StageCompletionLog
	{
		get
		{
			return _003CStageCompletionLog_003Ek__BackingField;
		}
		set
		{
			_003CStageCompletionLog_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, List<CharacterStageData>> CharacterStageData
	{
		get
		{
			return _003CCharacterStageData_003Ek__BackingField;
		}
		set
		{
			_003CCharacterStageData_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, int> CharacterEnemiesKilled
	{
		get
		{
			return _003CCharacterEnemiesKilled_003Ek__BackingField;
		}
		set
		{
			_003CCharacterEnemiesKilled_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, int> CharacterSurvivedMinutes
	{
		get
		{
			return _003CCharacterSurvivedMinutes_003Ek__BackingField;
		}
		set
		{
			_003CCharacterSurvivedMinutes_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, List<SkinType>> UnlockedSkins
	{
		get
		{
			return _003CUnlockedSkins_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedSkins_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, List<SkinType>> UnlockedSkinsV2
	{
		get
		{
			return _003CUnlockedSkinsV2_003Ek__BackingField;
		}
		set
		{
			_003CUnlockedSkinsV2_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, int> SelectedSkins
	{
		get
		{
			return _003CSelectedSkins_003Ek__BackingField;
		}
		set
		{
			_003CSelectedSkins_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, SkinType> SelectedSkinsV2
	{
		get
		{
			return _003CSelectedSkinsV2_003Ek__BackingField;
		}
		set
		{
			_003CSelectedSkinsV2_003Ek__BackingField = value;
		}
	}

	public Dictionary<StageType, BgmType> MusicSelectionPerStage
	{
		get
		{
			return _003CMusicSelectionPerStage_003Ek__BackingField;
		}
		set
		{
			_003CMusicSelectionPerStage_003Ek__BackingField = value;
		}
	}

	public string checksum
	{
		get
		{
			return _003Cchecksum_003Ek__BackingField;
		}
		set
		{
			_003Cchecksum_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, Dictionary<string, float>> CharacterEggInfo
	{
		get
		{
			return _003CCharacterEggInfo_003Ek__BackingField;
		}
		set
		{
			_003CCharacterEggInfo_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, float> CharacterEggCount
	{
		get
		{
			return _003CCharacterEggCount_003Ek__BackingField;
		}
		set
		{
			_003CCharacterEggCount_003Ek__BackingField = value;
		}
	}

	public float TotalEggCount
	{
		get
		{
			return _003CTotalEggCount_003Ek__BackingField;
		}
		set
		{
			_003CTotalEggCount_003Ek__BackingField = value;
		}
	}

	public bool Didit
	{
		get
		{
			return _003CDidit_003Ek__BackingField;
		}
		set
		{
			_003CDidit_003Ek__BackingField = value;
		}
	}

	public int Seals
	{
		get
		{
			return _003CSeals_003Ek__BackingField;
		}
		set
		{
			_003CSeals_003Ek__BackingField = value;
		}
	}

	public List<ItemType> SealedItems
	{
		get
		{
			return _003CSealedItems_003Ek__BackingField;
		}
		set
		{
			_003CSealedItems_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> SealedWeapons
	{
		get
		{
			return _003CSealedWeapons_003Ek__BackingField;
		}
		set
		{
			_003CSealedWeapons_003Ek__BackingField = value;
		}
	}

	public List<ItemType> ContentGroupSealedItems
	{
		get
		{
			return _003CContentGroupSealedItems_003Ek__BackingField;
		}
		set
		{
			_003CContentGroupSealedItems_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> ContentGroupSealedWeapons
	{
		get
		{
			return _003CContentGroupSealedWeapons_003Ek__BackingField;
		}
		set
		{
			_003CContentGroupSealedWeapons_003Ek__BackingField = value;
		}
	}

	public bool EnableBonusAdsMechanics
	{
		get
		{
			return _003CEnableBonusAdsMechanics_003Ek__BackingField;
		}
		set
		{
			_003CEnableBonusAdsMechanics_003Ek__BackingField = value;
		}
	}

	public bool ScreenShakeEnabled
	{
		get
		{
			return _003CScreenShakeEnabled_003Ek__BackingField;
		}
		set
		{
			_003CScreenShakeEnabled_003Ek__BackingField = value;
		}
	}

	public bool ControllerVibrationEnabled
	{
		get
		{
			return _003CControllerVibrationEnabled_003Ek__BackingField;
		}
		set
		{
			_003CControllerVibrationEnabled_003Ek__BackingField = value;
		}
	}

	public bool AssignControllerToPlayer1
	{
		get
		{
			return _003CAssignControllerToPlayer1_003Ek__BackingField;
		}
		set
		{
			_003CAssignControllerToPlayer1_003Ek__BackingField = value;
		}
	}

	public bool PopupsShouldFollowPriority
	{
		get
		{
			return _003CPopupsShouldFollowPriority_003Ek__BackingField;
		}
		set
		{
			_003CPopupsShouldFollowPriority_003Ek__BackingField = value;
		}
	}

	public bool ShowPlayerIndicators
	{
		get
		{
			return _003CShowPlayerIndicators_003Ek__BackingField;
		}
		set
		{
			_003CShowPlayerIndicators_003Ek__BackingField = value;
		}
	}

	public bool PermanentCoopOutlines
	{
		get
		{
			return _003CPermanentCoopOutlines_003Ek__BackingField;
		}
		set
		{
			_003CPermanentCoopOutlines_003Ek__BackingField = value;
		}
	}

	public bool TintUISelection
	{
		get
		{
			return _003CTintUISelection_003Ek__BackingField;
		}
		set
		{
			_003CTintUISelection_003Ek__BackingField = value;
		}
	}

	public uint[] PlayerColours
	{
		get
		{
			return _003CPlayerColours_003Ek__BackingField;
		}
		set
		{
			_003CPlayerColours_003Ek__BackingField = value;
		}
	}

	public bool SequentialChestMode
	{
		get
		{
			return _003CSequentialChestMode_003Ek__BackingField;
		}
		set
		{
			_003CSequentialChestMode_003Ek__BackingField = value;
		}
	}

	public bool HideDebugUI
	{
		get
		{
			return _003CHideDebugUI_003Ek__BackingField;
		}
		set
		{
			_003CHideDebugUI_003Ek__BackingField = value;
		}
	}

	public bool HideGameUI
	{
		get
		{
			return _003CHideGameUI_003Ek__BackingField;
		}
		set
		{
			_003CHideGameUI_003Ek__BackingField = value;
		}
	}

	public bool DisableMovingBackground
	{
		get
		{
			return _003CDisableMovingBackground_003Ek__BackingField;
		}
		set
		{
			_003CDisableMovingBackground_003Ek__BackingField = value;
		}
	}

	public bool DisableBlood
	{
		get
		{
			return _003CDisableBlood_003Ek__BackingField;
		}
		set
		{
			_003CDisableBlood_003Ek__BackingField = value;
		}
	}

	public BorderType BorderType
	{
		get
		{
			return _003CBorderType_003Ek__BackingField;
		}
		set
		{
			_003CBorderType_003Ek__BackingField = value;
		}
	}

	public bool PixelFont
	{
		get
		{
			return _003CPixelFont_003Ek__BackingField;
		}
		set
		{
			_003CPixelFont_003Ek__BackingField = value;
		}
	}

	public bool DisplayDefangedEnemies
	{
		get
		{
			return _003CDisplayDefangedEnemies_003Ek__BackingField;
		}
		set
		{
			_003CDisplayDefangedEnemies_003Ek__BackingField = value;
		}
	}

	public bool StageLighting
	{
		get
		{
			return _003CStageLighting_003Ek__BackingField;
		}
		set
		{
			_003CStageLighting_003Ek__BackingField = value;
		}
	}

	public bool HasSeenAdventureReveal
	{
		get
		{
			return _003CHasSeenAdventureReveal_003Ek__BackingField;
		}
		set
		{
			_003CHasSeenAdventureReveal_003Ek__BackingField = value;
		}
	}

	public bool ShouldPlayAdventureReveal
	{
		get
		{
			return _003CShouldPlayAdventureReveal_003Ek__BackingField;
		}
		set
		{
			_003CShouldPlayAdventureReveal_003Ek__BackingField = value;
		}
	}

	public bool HideUnavailableAdventures
	{
		get
		{
			return _003CHideUnavailableAdventures_003Ek__BackingField;
		}
		set
		{
			_003CHideUnavailableAdventures_003Ek__BackingField = value;
		}
	}

	public bool HasSeenAdventuresIntroTutorial
	{
		get
		{
			return _003CHasSeenAdventuresIntroTutorial_003Ek__BackingField;
		}
		set
		{
			_003CHasSeenAdventuresIntroTutorial_003Ek__BackingField = value;
		}
	}

	public float AdventureStars
	{
		get
		{
			return _003CAdventureStars_003Ek__BackingField;
		}
		set
		{
			_003CAdventureStars_003Ek__BackingField = value;
		}
	}

	public bool HasPlayedStage3
	{
		get
		{
			return _003CHasPlayedStage3_003Ek__BackingField;
		}
		set
		{
			_003CHasPlayedStage3_003Ek__BackingField = value;
		}
	}

	public bool HasSeenDarkanaTransition
	{
		get
		{
			return _003CHasSeenDarkanaTransition_003Ek__BackingField;
		}
		set
		{
			_003CHasSeenDarkanaTransition_003Ek__BackingField = value;
		}
	}

	public bool HasFixedSkinIds
	{
		get
		{
			return _003CHasFixedSkinIds_003Ek__BackingField;
		}
		set
		{
			_003CHasFixedSkinIds_003Ek__BackingField = value;
		}
	}

	public bool ShowTPCredits
	{
		get
		{
			return _003CShowTPCredits_003Ek__BackingField;
		}
		set
		{
			_003CShowTPCredits_003Ek__BackingField = value;
		}
	}

	public int LibraryMerchantGoldSpent
	{
		get
		{
			return _003CLibraryMerchantGoldSpent_003Ek__BackingField;
		}
		set
		{
			_003CLibraryMerchantGoldSpent_003Ek__BackingField = value;
		}
	}

	public bool PassedGaeaEvent
	{
		get
		{
			return _003CPassedGaeaEvent_003Ek__BackingField;
		}
		set
		{
			_003CPassedGaeaEvent_003Ek__BackingField = value;
		}
	}

	public int EME_NextBossBiome
	{
		get
		{
			return _003CEME_NextBossBiome_003Ek__BackingField;
		}
		set
		{
			_003CEME_NextBossBiome_003Ek__BackingField = value;
		}
	}

	public int WW_ZoneProgress
	{
		get
		{
			return _003CWW_ZoneProgress_003Ek__BackingField;
		}
		set
		{
			_003CWW_ZoneProgress_003Ek__BackingField = value;
		}
	}

	public AdventureType? SelectedAdventureType
	{
		get
		{
			return _003CSelectedAdventureType_003Ek__BackingField;
		}
		set
		{
			_003CSelectedAdventureType_003Ek__BackingField = value;
		}
	}

	public int AdventureCompletionCount
	{
		get
		{
			return _003CAdventureCompletionCount_003Ek__BackingField;
		}
		set
		{
			_003CAdventureCompletionCount_003Ek__BackingField = value;
		}
	}

	public List<AdventureAchievementType> AdventureProgress
	{
		get
		{
			return _003CAdventureProgress_003Ek__BackingField;
		}
		set
		{
			_003CAdventureProgress_003Ek__BackingField = value;
		}
	}

	public Dictionary<AdventureType, PlayerOptionsData> AdventuresSaveData
	{
		get
		{
			return _003CAdventuresSaveData_003Ek__BackingField;
		}
		set
		{
			_003CAdventuresSaveData_003Ek__BackingField = value;
		}
	}

	public float TotalAdventurePlaytime
	{
		get
		{
			return _003CTotalAdventurePlaytime_003Ek__BackingField;
		}
		set
		{
			_003CTotalAdventurePlaytime_003Ek__BackingField = value;
		}
	}

	public float AllTimeAdventurePlaytime
	{
		get
		{
			return _003CAllTimeAdventurePlaytime_003Ek__BackingField;
		}
		set
		{
			_003CAllTimeAdventurePlaytime_003Ek__BackingField = value;
		}
	}

	public Dictionary<PowerUpType, int> AscensionPointsAllocation
	{
		get
		{
			return _003CAscensionPointsAllocation_003Ek__BackingField;
		}
		set
		{
			_003CAscensionPointsAllocation_003Ek__BackingField = value;
		}
	}

	public List<AdventureType> CompletedAdventures
	{
		get
		{
			return _003CCompletedAdventures_003Ek__BackingField;
		}
		set
		{
			_003CCompletedAdventures_003Ek__BackingField = value;
		}
	}

	public bool HasSeenMerchantTutorial
	{
		get
		{
			return _003CHasSeenMerchantTutorial_003Ek__BackingField;
		}
		set
		{
			_003CHasSeenMerchantTutorial_003Ek__BackingField = value;
		}
	}

	public List<AdventureType> SeenAscensionPopups
	{
		get
		{
			return _003CSeenAscensionPopups_003Ek__BackingField;
		}
		set
		{
			_003CSeenAscensionPopups_003Ek__BackingField = value;
		}
	}

	public Dictionary<PropType, int> RunDestroyedProps
	{
		get
		{
			return _003CRunDestroyedProps_003Ek__BackingField;
		}
		set
		{
			_003CRunDestroyedProps_003Ek__BackingField = value;
		}
	}

	public Dictionary<ItemType, int> RunItemsPickupCount
	{
		get
		{
			return _003CRunItemsPickupCount_003Ek__BackingField;
		}
		set
		{
			_003CRunItemsPickupCount_003Ek__BackingField = value;
		}
	}

	public StageType NextAutoSelectStage
	{
		get
		{
			return _003CNextAutoSelectStage_003Ek__BackingField;
		}
		set
		{
			_003CNextAutoSelectStage_003Ek__BackingField = value;
		}
	}

	public unsafe PlayerOptionsData(bool addDefaults = true)
	{
		//IL_057f: Expected I8, but got I4
		//IL_0720: Expected I8, but got I4
		//IL_0751: Expected I8, but got I4
		//IL_0790: Expected I8, but got I4
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Expected Ref, but got Unknown
		//IL_07c5: Expected I8, but got I4
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected Ref, but got Unknown
		_003CsaveDate_003Ek__BackingField = "";
		_003CPlatform_003Ek__BackingField = "";
		_003CSaveSyncPlatformAchievements_003Ek__BackingField = true;
		List<SystemPlatformTypes> list = new List<SystemPlatformTypes>();
		_003CSaveTouchedPlatforms_003Ek__BackingField = list;
		_selectedChar = CharacterType.ANTONIO;
		_003CSelectedMazzo_003Ek__BackingField = true;
		_003CSelectedGoldenEggs_003Ek__BackingField = true;
		_003CSelectedSurvarots_003Ek__BackingField = true;
		_003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Forest_B;
		_003CSelectedBGMPlayback_003Ek__BackingField = BgmPlaybackType.None;
		_003CSelectedOnlineFreeRoam_003Ek__BackingField = true;
		_003CSelectedMaxWeapons_003Ek__BackingField = 6;
		List<ItemType> list2 = new List<ItemType>();
		_003CRunPickups_003Ek__BackingField = list2;
		List<WeaponType> list3 = new List<WeaponType>();
		_003CRunWeapons_003Ek__BackingField = list3;
		List<CharacterType> list4 = new List<CharacterType>();
		_003CRunCoffins_003Ek__BackingField = list4;
		List<EnemyType> list5 = new List<EnemyType>();
		_003CRunBossesTypes_003Ek__BackingField = list5;
		Dictionary<EnemyType, int> dictionary = new Dictionary<EnemyType, int>();
		_003CRunKillCount_003Ek__BackingField = dictionary;
		_003CReducePhysics_003Ek__BackingField = true;
		_003CVisuallyInvertStages_003Ek__BackingField = true;
		_003CSoundsEnabled_003Ek__BackingField = true;
		_003CSoundsVolume_003Ek__BackingField = 0.5f;
		_003CMusicVolume_003Ek__BackingField = 0.5f;
		_003CFlashingVFXEnabled_003Ek__BackingField = true;
		_003CDamageNumbersEnabled_003Ek__BackingField = true;
		_003CStreamSafeEnabled_003Ek__BackingField = true;
		_003CLanguage_003Ek__BackingField = "en";
		_003CShowQuitDescription_003Ek__BackingField = true;
		_003CShowSmallMapIcons_003Ek__BackingField = true;
		List<CharacterType> list6 = new List<CharacterType>();
		_003CBoughtCharacters_003Ek__BackingField = list6;
		List<SkinType> list7 = new List<SkinType>();
		_003CBoughtSkins_003Ek__BackingField = list7;
		List<PowerUpLevel> list8 = new List<PowerUpLevel>();
		_003CBoughtPowerups_003Ek__BackingField = list8;
		List<WeaponType> list9 = new List<WeaponType>();
		_003CCollectedWeapons_003Ek__BackingField = list9;
		List<WeaponType> list10 = new List<WeaponType>();
		_003CUnlockedWeapons_003Ek__BackingField = list10;
		List<CharacterType> list11 = new List<CharacterType>();
		_003CUnlockedCharacters_003Ek__BackingField = list11;
		List<CharacterType> list12 = new List<CharacterType>();
		_003CHostOnlyUnlockedCharacters_003Ek__BackingField = list12;
		List<CharacterType> list13 = new List<CharacterType>();
		_003COpenedCoffins_003Ek__BackingField = list13;
		List<ItemType> list14 = new List<ItemType>();
		_003CCollectedItems_003Ek__BackingField = list14;
		List<AchievementType> list15 = new List<AchievementType>();
		_003CAchievements_003Ek__BackingField = list15;
		List<SecretType> list16 = new List<SecretType>();
		_003CSecrets_003Ek__BackingField = list16;
		List<StageType> list17 = new List<StageType>();
		_003CUnlockedStages_003Ek__BackingField = list17;
		List<StageType> list18 = new List<StageType>();
		_003CUnlockedHypers_003Ek__BackingField = list18;
		List<PowerUpType> list19 = new List<PowerUpType>();
		_003CUnlockedPowerUpRanks_003Ek__BackingField = list19;
		List<ArcanaType> list20 = new List<ArcanaType>();
		_003CUnlockedArcanas_003Ek__BackingField = list20;
		List<PowerUpType> list21 = new List<PowerUpType>();
		_003CDisabledPowerups_003Ek__BackingField = list21;
		Dictionary<EnemyType, int> dictionary2 = new Dictionary<EnemyType, int>();
		_003CKillCount_003Ek__BackingField = dictionary2;
		Dictionary<ItemType, int> dictionary3 = new Dictionary<ItemType, int>();
		_003CPickupCount_003Ek__BackingField = dictionary3;
		Dictionary<PropType, int> dictionary4 = new Dictionary<PropType, int>();
		_003CDestroyedCount_003Ek__BackingField = dictionary4;
		Dictionary<CharacterType, List<StageType>> dictionary5 = new Dictionary<CharacterType, List<StageType>>();
		_003CStageCompletionLog_003Ek__BackingField = dictionary5;
		Dictionary<CharacterType, List<CharacterStageData>> dictionary6 = new Dictionary<CharacterType, List<CharacterStageData>>();
		_003CCharacterStageData_003Ek__BackingField = dictionary6;
		Dictionary<CharacterType, int> dictionary7 = new Dictionary<CharacterType, int>();
		_003CCharacterEnemiesKilled_003Ek__BackingField = dictionary7;
		Dictionary<CharacterType, int> dictionary8 = new Dictionary<CharacterType, int>();
		_003CCharacterSurvivedMinutes_003Ek__BackingField = dictionary8;
		Dictionary<CharacterType, List<SkinType>> dictionary9 = new Dictionary<CharacterType, List<SkinType>>();
		_003CUnlockedSkins_003Ek__BackingField = dictionary9;
		Dictionary<CharacterType, List<SkinType>> dictionary10 = new Dictionary<CharacterType, List<SkinType>>();
		_003CUnlockedSkinsV2_003Ek__BackingField = dictionary10;
		Dictionary<CharacterType, int> dictionary11 = new Dictionary<CharacterType, int>();
		_003CSelectedSkins_003Ek__BackingField = dictionary11;
		Dictionary<CharacterType, SkinType> dictionary12 = new Dictionary<CharacterType, SkinType>();
		_003CSelectedSkinsV2_003Ek__BackingField = dictionary12;
		Dictionary<StageType, BgmType> dictionary13 = new Dictionary<StageType, BgmType>();
		_003CMusicSelectionPerStage_003Ek__BackingField = dictionary13;
		_003Cchecksum_003Ek__BackingField = "";
		Dictionary<CharacterType, Dictionary<string, float>> dictionary14 = new Dictionary<CharacterType, Dictionary<string, float>>();
		_003CCharacterEggInfo_003Ek__BackingField = dictionary14;
		Dictionary<CharacterType, float> dictionary15 = new Dictionary<CharacterType, float>();
		_003CCharacterEggCount_003Ek__BackingField = dictionary15;
		_003CSeals_003Ek__BackingField = 10;
		List<ItemType> list22 = new List<ItemType>();
		_003CSealedItems_003Ek__BackingField = list22;
		List<WeaponType> list23 = new List<WeaponType>();
		_003CSealedWeapons_003Ek__BackingField = list23;
		List<ItemType> list24 = new List<ItemType>();
		_003CContentGroupSealedItems_003Ek__BackingField = list24;
		List<WeaponType> list25 = new List<WeaponType>();
		_003CContentGroupSealedWeapons_003Ek__BackingField = list25;
		_003CEnableBonusAdsMechanics_003Ek__BackingField = true;
		_003CPopupsShouldFollowPriority_003Ek__BackingField = true;
		_003CTintUISelection_003Ek__BackingField = true;
		_003CPlayerColours_003Ek__BackingField = new uint[4] { 16068142u, 5530623u, 16762647u, 2072128u };
		ulong num = 0uL;
		_003CBorderType_003Ek__BackingField = BorderType.TRANSPARENT;
		_003CPixelFont_003Ek__BackingField = true;
		_003CStageLighting_003Ek__BackingField = true;
		List<ContentGroupType> banishedContentGroups = new List<ContentGroupType>();
		BanishedContentGroups = banishedContentGroups;
		List<AdventureAchievementType> list26 = new List<AdventureAchievementType>();
		_003CAdventureProgress_003Ek__BackingField = list26;
		Dictionary<AdventureType, PlayerOptionsData> dictionary16 = new Dictionary<AdventureType, PlayerOptionsData>();
		_003CAdventuresSaveData_003Ek__BackingField = dictionary16;
		Dictionary<PowerUpType, int> dictionary17 = new Dictionary<PowerUpType, int>();
		_003CAscensionPointsAllocation_003Ek__BackingField = dictionary17;
		List<AdventureType> list27 = new List<AdventureType>();
		_003CCompletedAdventures_003Ek__BackingField = list27;
		List<AdventureType> list28 = new List<AdventureType>();
		_003CSeenAscensionPopups_003Ek__BackingField = list28;
		Dictionary<PropType, int> dictionary18 = new Dictionary<PropType, int>();
		_003CRunDestroyedProps_003Ek__BackingField = dictionary18;
		Dictionary<ItemType, int> dictionary19 = new Dictionary<ItemType, int>();
		_003CRunItemsPickupCount_003Ek__BackingField = dictionary19;
		List<CharacterType> onlineMultiplayerSelections = new List<CharacterType>();
		OnlineMultiplayerSelections = onlineMultiplayerSelections;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		string defaultLanguage = sInstance.m_CurrentSystem.GetDefaultLanguage();
		string text = _003CLanguage_003Ek__BackingField;
		object obj = "en";
		if ((object)_003CLanguage_003Ek__BackingField == "en")
		{
			goto IL_0814;
		}
		bool flag = _003CLanguage_003Ek__BackingField == null;
		string text2 = _003CLanguage_003Ek__BackingField;
		ulong num2 = 0uL;
		if (!flag)
		{
			bool flag2 = "en" == null;
			text2 = _003CLanguage_003Ek__BackingField;
			num2 = 0uL;
			if (!flag2)
			{
				int stringLength = text._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3721 @ rdx_v103+10]");
				bool flag3 = (nint)stringLength != 0;
				text2 = _003CLanguage_003Ek__BackingField;
				num2 = 0uL;
				if (!flag3)
				{
					ref byte first = ref *(byte*)(_003CLanguage_003Ek__BackingField + 20);
					num = (ulong)(text._stringLength + text._stringLength);
					bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("en" + 20), num);
					bool flag5 = !flag4;
					text = null;
					text2 = null;
					num2 = num;
					if (!flag5)
					{
						goto IL_0814;
					}
				}
			}
		}
		goto IL_0833;
		IL_0814:
		Language = defaultLanguage;
		text2 = text;
		num2 = num;
		goto IL_0833;
		IL_0833:
		if (addDefaults)
		{
			List<CharacterType> boughtCharacters = new List<CharacterType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			BoughtCharacters = boughtCharacters;
			List<CharacterType> unlockedCharacters = new List<CharacterType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
			UnlockedCharacters = unlockedCharacters;
			List<StageType> unlockedStages = new List<StageType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
			UnlockedStages = unlockedStages;
		}
	}

	public unsafe bool Equals(PlayerOptionsData data)
	{
		//IL_012f: Expected I4, but got O
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Ref, but got Unknown
		//IL_00eb: Expected I8, but got I4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		if (data != null)
		{
			string text = _003Cchecksum_003Ek__BackingField;
			if (_003Cchecksum_003Ek__BackingField != null)
			{
				string text2 = data._003Cchecksum_003Ek__BackingField;
				if ((object)_003Cchecksum_003Ek__BackingField != data._003Cchecksum_003Ek__BackingField)
				{
					if (data._003Cchecksum_003Ek__BackingField != null && text._stringLength == text2._stringLength)
					{
						ref byte second = ref *(byte*)(data._003Cchecksum_003Ek__BackingField + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						return System.SpanHelpers.SequenceEqual(ref *(byte*)(_003Cchecksum_003Ek__BackingField + 20), ref second, length);
					}
					return false;
				}
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasCollectedItem(ItemType item)
	{
		//IL_0022: Expected I4, but got O
		if (_003CCollectedItems_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool PlatformAchievementsAllowed()
	{
		//IL_01b7: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0074: Expected I, but got O
		//IL_0183: Expected I, but got O
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected I4, but got Unknown
		//IL_013d: Expected O, but got I4
		object obj = SystemPlatform.Platform + -2;
		if ((nint)obj > 1)
		{
			return true;
		}
		if (_003CSaveTouchedPlatforms_003Ek__BackingField != null)
		{
			List<SystemPlatformTypes> list = _003CSaveTouchedPlatforms_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>)+18]");
			if ((nint)0 != 0)
			{
				object obj3 = default(object);
				object obj2 = obj3;
				object obj4 = 0;
				nint num = unchecked((nint)null);
				object obj5 = default(object);
				object obj6 = default(object);
				while (true)
				{
					if (obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-28_v2+1C]");
						if (obj6 != null)
						{
							break;
						}
						object obj7 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-28_v2+18]");
						if ((nint)obj7 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-28_v2+10]");
						num = 0;
						obj2++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v6 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>+Enumerator<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>>)+20+v93 @ rdx…");
						if ((nint)0 != 2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v6 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>+Enumerator<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes>>)+20+v93 @ rdx…");
							if ((nint)0 != 3)
							{
								obj4 = 1;
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag = obj5 == null;
				num = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-28_v2+1C]");
					if (obj6 == null)
					{
						return (byte)(obj4 ^ 1) != 0;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
		}
		return false;
	}

	public PlayerOptionsData Clone()
	{
		//IL_0543: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		object obj = MemberwiseClone();
		nint num = (nint)typeof(PlayerOptionsData);
		if (obj != null)
		{
			nint num2 = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1 (Il2CppClass<VampireSurvivors.Data.PlayerOptionsData>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v177 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rdx_v1 (Il2CppClass<VampireSurvivors.Data.PlayerOptionsData>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v177 (Il2CppClass<System.Object>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v283+FFFFFFF8+v55 @ rax_v280*8]");
				if (0 == (nint)typeof(PlayerOptionsData))
				{
					goto IL_0086;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_0086;
		IL_0086:
		List<CharacterType> list = (List<CharacterType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CBoughtCharacters_003Ek__BackingField);
		if (obj != null)
		{
			((PlayerOptionsData)obj)._003CBoughtCharacters_003Ek__BackingField = list;
			List<PowerUpLevel> list2 = (List<PowerUpLevel>)(object)new List<object>(_003CBoughtPowerups_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CBoughtPowerups_003Ek__BackingField = list2;
			List<WeaponType> list3 = (List<WeaponType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CCollectedWeapons_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CCollectedWeapons_003Ek__BackingField = list3;
			List<WeaponType> list4 = (List<WeaponType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedWeapons_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedWeapons_003Ek__BackingField = list4;
			List<CharacterType> list5 = (List<CharacterType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedCharacters_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedCharacters_003Ek__BackingField = list5;
			List<CharacterType> list6 = (List<CharacterType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003COpenedCoffins_003Ek__BackingField);
			((PlayerOptionsData)obj)._003COpenedCoffins_003Ek__BackingField = list6;
			List<ItemType> list7 = (List<ItemType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CCollectedItems_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CCollectedItems_003Ek__BackingField = list7;
			List<AchievementType> list8 = (List<AchievementType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CAchievements_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CAchievements_003Ek__BackingField = list8;
			List<SecretType> list9 = (List<SecretType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CSecrets_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CSecrets_003Ek__BackingField = list9;
			List<StageType> list10 = (List<StageType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedStages_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedStages_003Ek__BackingField = list10;
			List<StageType> list11 = (List<StageType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedHypers_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedHypers_003Ek__BackingField = list11;
			List<PowerUpType> list12 = (List<PowerUpType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedPowerUpRanks_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedPowerUpRanks_003Ek__BackingField = list12;
			List<ArcanaType> list13 = (List<ArcanaType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedArcanas_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedArcanas_003Ek__BackingField = list13;
			List<PowerUpType> list14 = (List<PowerUpType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CDisabledPowerups_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CDisabledPowerups_003Ek__BackingField = list14;
			List<PowerUpType> list15 = (List<PowerUpType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CUnlockedPowerUpRanks_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CUnlockedPowerUpRanks_003Ek__BackingField = list15;
			Dictionary<EnemyType, int> dictionary = (Dictionary<EnemyType, int>)(object)new Dictionary<System.Int32Enum, int>((IDictionary<System.Int32Enum, int>)_003CKillCount_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CKillCount_003Ek__BackingField = dictionary;
			Dictionary<ItemType, int> dictionary2 = (Dictionary<ItemType, int>)(object)new Dictionary<System.Int32Enum, int>((IDictionary<System.Int32Enum, int>)_003CPickupCount_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CPickupCount_003Ek__BackingField = dictionary2;
			Dictionary<PropType, int> dictionary3 = (Dictionary<PropType, int>)(object)new Dictionary<System.Int32Enum, int>((IDictionary<System.Int32Enum, int>)_003CDestroyedCount_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CDestroyedCount_003Ek__BackingField = dictionary3;
			Dictionary<CharacterType, List<StageType>> dictionary4 = (Dictionary<CharacterType, List<StageType>>)(object)new Dictionary<System.Int32Enum, object>((IDictionary<System.Int32Enum, object>)_003CStageCompletionLog_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CStageCompletionLog_003Ek__BackingField = dictionary4;
			Dictionary<CharacterType, List<CharacterStageData>> dictionary5 = (Dictionary<CharacterType, List<CharacterStageData>>)(object)new Dictionary<System.Int32Enum, object>((IDictionary<System.Int32Enum, object>)_003CCharacterStageData_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CCharacterStageData_003Ek__BackingField = dictionary5;
			Dictionary<CharacterType, int> dictionary6 = (Dictionary<CharacterType, int>)(object)new Dictionary<System.Int32Enum, int>((IDictionary<System.Int32Enum, int>)_003CCharacterEnemiesKilled_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CCharacterEnemiesKilled_003Ek__BackingField = dictionary6;
			Dictionary<CharacterType, int> dictionary7 = (Dictionary<CharacterType, int>)(object)new Dictionary<System.Int32Enum, int>((IDictionary<System.Int32Enum, int>)_003CCharacterSurvivedMinutes_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CCharacterSurvivedMinutes_003Ek__BackingField = dictionary7;
			Dictionary<CharacterType, List<SkinType>> dictionary8 = (Dictionary<CharacterType, List<SkinType>>)(object)new Dictionary<System.Int32Enum, object>((IDictionary<System.Int32Enum, object>)_003CUnlockedSkins_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CUnlockedSkins_003Ek__BackingField = dictionary8;
			Dictionary<CharacterType, int> dictionary9 = (Dictionary<CharacterType, int>)(object)new Dictionary<System.Int32Enum, int>((IDictionary<System.Int32Enum, int>)_003CSelectedSkins_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CSelectedSkins_003Ek__BackingField = dictionary9;
			Dictionary<StageType, BgmType> dictionary10 = (Dictionary<StageType, BgmType>)(object)new Dictionary<System.Int32Enum, System.Int32Enum>((IDictionary<System.Int32Enum, System.Int32Enum>)_003CMusicSelectionPerStage_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CMusicSelectionPerStage_003Ek__BackingField = dictionary10;
			Dictionary<CharacterType, Dictionary<string, float>> dictionary11 = (Dictionary<CharacterType, Dictionary<string, float>>)(object)new Dictionary<System.Int32Enum, object>((IDictionary<System.Int32Enum, object>)_003CCharacterEggInfo_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CCharacterEggInfo_003Ek__BackingField = dictionary11;
			Dictionary<CharacterType, float> dictionary12 = (Dictionary<CharacterType, float>)(object)new Dictionary<System.Int32Enum, float>((IDictionary<System.Int32Enum, float>)_003CCharacterEggCount_003Ek__BackingField, null);
			((PlayerOptionsData)obj)._003CCharacterEggCount_003Ek__BackingField = dictionary12;
			List<ItemType> list16 = (List<ItemType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CSealedItems_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CSealedItems_003Ek__BackingField = list16;
			List<WeaponType> list17 = (List<WeaponType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CSealedWeapons_003Ek__BackingField);
			((PlayerOptionsData)obj)._003CSealedWeapons_003Ek__BackingField = list17;
			return (PlayerOptionsData)obj;
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}
}
