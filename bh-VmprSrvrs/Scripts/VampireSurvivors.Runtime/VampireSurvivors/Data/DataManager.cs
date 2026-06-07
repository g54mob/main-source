using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using Zenject;

namespace VampireSurvivors.Data
{
	[UsedImplicitly]
	public class DataManager : IInitializable, IDisposable
	{
		[Inject]
		private DataManagerSettings _settings;

		[Inject]
		private PlayerOptions _playerOptions;

		private Dictionary<CharacterType, List<CharacterData>> _characterData;

		private Dictionary<PowerUpType, List<PowerUpData>> _powerUpData;

		private Dictionary<StageType, List<StageData>> _stageData;

		private Dictionary<WeaponType, List<WeaponData>> _weaponData;

		private Dictionary<EnemyType, List<EnemyData>> _enemyData;

		private bool _characterDataChangedForOnline;

		private bool _powerUpDataChangedForOnline;

		private bool _stageDataChangedForOnline;

		private bool _weaponDataChangedForOnline;

		private bool _enemyDataChangedForOnline;

		private Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>> _dlcCharacterData;

		private Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>> _dlcPowerUpData;

		private Dictionary<DlcType, Dictionary<StageType, List<StageData>>> _dlcStageData;

		private Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>> _dlcWeaponData;

		private Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>> _dlcEnemyData;

		private Dictionary<DlcType, Dictionary<BgmType, MusicData>> _dlcMusicData;

		private Dictionary<DlcType, HashSet<string>> _dlcSfxData;

		private JsonMergeSettings _mergeSettings;

		private JObject _allWeaponDataJson;

		private JObject _allCharactersJson;

		private JObject _allEnemiesJson;

		private JObject _allItemsJson;

		private JObject _allPowerUpsJson;

		private JObject _allPropsJson;

		private JObject _allStagesJson;

		private JObject _allArcanasJson;

		private JObject _allHitVfxDataJson;

		private JObject _allMusicDataJson;

		private JObject _allLimitBreakDataJson;

		private JObject _allAchievementsJson;

		private JObject _allSecretsJson;

		private JObject _allAdventuresJson;

		private JObject _allStageSetJson;

		private JObject _allAdventureStagesJson;

		private JObject _allAdventureMerchantsJson;

		private JObject _allAlbumData;

		private JObject _allCustomMerchantsJson;

		private JObject _allCPUJson;

		private Dictionary<CharacterType, List<CharacterData>> _adventureCharacterData;

		private Dictionary<StageType, List<StageData>> _adventureStageData;

		private Dictionary<EnemyType, List<EnemyData>> _adventureBestiaryData;

		private Dictionary<CharacterType, CustomMerchantData> _adventureMerchantsData;

		private static readonly ProfilerMarker MarkerReloadAllData;

		private static readonly ProfilerMarker MarkerLoadDataFromJson;

		private static readonly ProfilerMarker MarkerBuildConvertedData;

		private static readonly ProfilerMarker MarkerLoadBaseJObjects;

		public const string JsonPartFileNameAchievement = "achievementData";

		public const string JsonPartFileNameArcana = "arcanaData";

		public const string JsonPartFileNameCharacter = "characterData";

		public const string JsonPartFileNameEnemy = "enemyData";

		public const string JsonPartFileNameHitVfx = "hitVfxData";

		public const string JsonPartFileNameItem = "itemData";

		public const string JsonPartFileNameLimitBreak = "limitBreakData";

		public const string JsonPartFileNameMusic = "musicData";

		public const string JsonPartFileNamePowerUp = "powerUpData";

		public const string JsonPartFileNameProps = "propsData";

		public const string JsonPartFileNameSecrets = "secretData";

		public const string JsonPartFileNameStage = "stageData";

		public const string JsonPartFileNameWeapon = "weaponData";

		public const string JsonPartFileNameAlbum = "albumData";

		public const string JsonPartFileNameAdventure = "adventureData";

		public const string JsonPartFileNameAdventuresStageSet = "adventuresStageSetData";

		public const string JsonPartFileNameAdventuresMerchants = "adventuresMerchantsData";

		public DataManagerSettings DefaultData => null;

		public Dictionary<WeaponType, JArray> AllWeaponData { get; private set; }

		public Dictionary<CharacterType, JArray> AllCharacters { get; private set; }

		public Dictionary<EnemyType, JArray> AllEnemies { get; private set; }

		public Dictionary<ItemType, ItemData> AllItems { get; private set; }

		public Dictionary<PowerUpType, JArray> AllPowerUps { get; private set; }

		public Dictionary<PropType, PropData> AllProps { get; private set; }

		public Dictionary<StageType, JArray> AllStages { get; private set; }

		public Dictionary<ArcanaType, ArcanaData> AllArcanas { get; private set; }

		public Dictionary<HitVfxType, HitVfxData> AllHitVfxData { get; private set; }

		public Dictionary<BgmType, MusicData> AllMusicData { get; private set; }

		public Dictionary<WeaponType, JArray> AllLimitBreakData { get; private set; }

		public Dictionary<AchievementType, AchievementData> AllAchievements { get; private set; }

		public Dictionary<SecretType, SecretData> AllSecrets { get; private set; }

		public Dictionary<AdventureType, AdventureData> AllAdventures { get; private set; }

		public Dictionary<AIType, AIData> AllCPU { get; private set; }

		public Dictionary<StageSetType, JObject> AllStageSetData { get; private set; }

		public Dictionary<CharacterType, CustomMerchantData> AllAdventureMerchantsData { get; private set; }

		public Dictionary<CharacterType, CustomMerchantData> AllCustomMerchantsData { get; private set; }

		public Dictionary<AlbumType, AlbumData> AllAlbumData { get; private set; }

		public HashSet<AchievementType> AllLoadedAchievements { get; private set; }

		public Dictionary<DlcType, List<AchievementType>> AllDlcAchievements { get; private set; }

		public Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>> AllDlcCharacterData => null;

		public Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>> AllDlcPowerUpData => null;

		public Dictionary<DlcType, Dictionary<StageType, List<StageData>>> AllDlcStageData => null;

		public Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>> AllDlcWeaponData => null;

		public Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>> AllDlcEnemyData => null;

		public Dictionary<DlcType, Dictionary<BgmType, MusicData>> AllDlcMusicData => null;

		public Dictionary<DlcType, HashSet<string>> AllDlcSfxData => null;

		public Dictionary<CharacterType, List<CharacterData>> AdventureCharacterData => null;

		public Dictionary<StageType, List<StageData>> AdventureStageData => null;

		public Dictionary<EnemyType, List<EnemyData>> AdventureBestiaryData => null;

		public static List<string> AllJsonPartFileNames => null;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void ReloadAllData()
		{
		}

		public Dictionary<CharacterType, List<CharacterData>> GetConvertedDlcCharacterData(DlcType dlcType)
		{
			return null;
		}

		public Dictionary<StageType, List<StageData>> GetConvertedDlcStageData(DlcType dlcType)
		{
			return null;
		}

		public Dictionary<WeaponType, List<WeaponData>> GetConvertedDlcWeaponData(DlcType dlcType)
		{
			return null;
		}

		public Dictionary<EnemyType, List<EnemyData>> GetConvertedDlcEnemyData(DlcType dlcType)
		{
			return null;
		}

		public Dictionary<PowerUpType, List<PowerUpData>> GetConvertedDlcPowerUpData(DlcType dlcType)
		{
			return null;
		}

		public Dictionary<BgmType, MusicData> GetConvertedDlcMusicData(DlcType dlcType)
		{
			return null;
		}

		public Dictionary<CharacterType, List<CharacterData>> GetConvertedCharacterData()
		{
			return null;
		}

		public Dictionary<EnemyType, List<EnemyData>> GetConvertedEnemyData()
		{
			return null;
		}

		public Dictionary<PowerUpType, List<PowerUpData>> GetConvertedPowerUpData()
		{
			return null;
		}

		public Dictionary<StageType, List<StageData>> GetConvertedStages()
		{
			return null;
		}

		public Dictionary<StageType, List<StageData>> GetConvertedAdventureStages()
		{
			return null;
		}

		public Dictionary<WeaponType, List<WeaponData>> GetConvertedWeapons()
		{
			return null;
		}

		public PropData GetPropData(PropType propType)
		{
			return null;
		}

		public void AddDefaultUnlocksToSaveData()
		{
		}

		public void UpdateAllCharacterHiddenPropertiesForAdventures(AdventureData adventureData)
		{
		}

		public void GenerateAdventureSpecificData(AdventureData adventureData)
		{
		}

		public void ExitAdventure()
		{
		}

		private bool IsOnline()
		{
			return false;
		}

		private void LoadBaseJObjects()
		{
		}

		private void LoadDataFromJson()
		{
		}

		public void MergeInJsonData(DataManagerSettings settings, DlcType dlcType)
		{
		}

		private void InternalMergeInJsonData(DataManagerSettings settings, DlcType dlcType, bool reload = true)
		{
		}

		private void CacheBaseGameLoadedAchievements()
		{
		}

		public void MergeInDlcAchievements(DlcType dlcType, TextAsset achievements)
		{
		}

		public void MergeInSFXTypes(DlcType dlc, Transform instantiatedSoundGroup)
		{
		}

		private void LoadAndMergeIn(JObject original, TextAsset newAsset)
		{
		}

		private void BuildConvertedDlcData(DataManagerSettings settings, DlcType dlcType)
		{
		}

		public void ClearConvertedDlcData()
		{
		}

		private void ClearConvertedData()
		{
		}

		private void BuildConvertedData()
		{
		}

		private static Dictionary<EnemyType, List<EnemyData>> ConvertEnemyDataJsonToObjects(Dictionary<EnemyType, JArray> enemyJson)
		{
			return null;
		}

		private static Dictionary<WeaponType, List<WeaponData>> ConvertWeaponDataJsonToObjects(Dictionary<WeaponType, JArray> weaponJson)
		{
			return null;
		}

		private static Dictionary<StageType, List<StageData>> ConvertStageDataJsonToObjects(Dictionary<StageType, JArray> jsonData)
		{
			return null;
		}

		private static Dictionary<CharacterType, List<CharacterData>> ConvertCharacterJsonDataToObjects(Dictionary<CharacterType, JArray> jsonData)
		{
			return null;
		}

		private static Dictionary<PowerUpType, List<PowerUpData>> ConvertPowerUpJsonData(Dictionary<PowerUpType, JArray> jsonData)
		{
			return null;
		}

		private static Dictionary<BgmType, List<MusicData>> ConvertMusicJsonDataToObjects(Dictionary<BgmType, JArray> jsonData)
		{
			return null;
		}

		private static void CacheEnemyDataStrings(EnemyData enemyData)
		{
		}

		private void AdjustAchievementDataWithTypes()
		{
		}

		private void AdjustAdventureProgressDataWithTypes()
		{
		}

		private void GenerateBestiaryDataForAdventure(AdventureData adventureData)
		{
		}

		private EnemyType? FindEnemyBaseVariant(EnemyType enemyType)
		{
			return null;
		}
	}
}
