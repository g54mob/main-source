using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Newtonsoft.Json.Linq;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using Zenject;

namespace VampireSurvivors.Data;

public class DataManager : IInitializable, IDisposable
{
	private DataManagerSettings _settings;

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

	private JsonMergeSettings _mergeSettings = new JsonMergeSettings
	{
		_propertyNameComparison = StringComparison.Ordinal,
		_mergeArrayHandling = MergeArrayHandling.Replace
	};

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

	private Dictionary<WeaponType, JArray> _003CAllWeaponData_003Ek__BackingField;

	private Dictionary<CharacterType, JArray> _003CAllCharacters_003Ek__BackingField;

	private Dictionary<EnemyType, JArray> _003CAllEnemies_003Ek__BackingField;

	private Dictionary<ItemType, ItemData> _003CAllItems_003Ek__BackingField;

	private Dictionary<PowerUpType, JArray> _003CAllPowerUps_003Ek__BackingField;

	private Dictionary<PropType, PropData> _003CAllProps_003Ek__BackingField;

	private Dictionary<StageType, JArray> _003CAllStages_003Ek__BackingField;

	private Dictionary<ArcanaType, ArcanaData> _003CAllArcanas_003Ek__BackingField;

	private Dictionary<HitVfxType, HitVfxData> _003CAllHitVfxData_003Ek__BackingField;

	private Dictionary<BgmType, MusicData> _003CAllMusicData_003Ek__BackingField;

	private Dictionary<WeaponType, JArray> _003CAllLimitBreakData_003Ek__BackingField;

	private Dictionary<AchievementType, AchievementData> _003CAllAchievements_003Ek__BackingField;

	private Dictionary<SecretType, SecretData> _003CAllSecrets_003Ek__BackingField;

	private Dictionary<AdventureType, AdventureData> _003CAllAdventures_003Ek__BackingField;

	private Dictionary<AIType, AIData> _003CAllCPU_003Ek__BackingField;

	private Dictionary<StageSetType, JObject> _003CAllStageSetData_003Ek__BackingField;

	private Dictionary<CharacterType, CustomMerchantData> _003CAllAdventureMerchantsData_003Ek__BackingField;

	private Dictionary<CharacterType, CustomMerchantData> _003CAllCustomMerchantsData_003Ek__BackingField;

	private Dictionary<AlbumType, AlbumData> _003CAllAlbumData_003Ek__BackingField;

	private HashSet<AchievementType> _003CAllLoadedAchievements_003Ek__BackingField;

	private Dictionary<DlcType, List<AchievementType>> _003CAllDlcAchievements_003Ek__BackingField;

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

	public DataManagerSettings DefaultData => _settings;

	public Dictionary<WeaponType, JArray> AllWeaponData
	{
		get
		{
			return _003CAllWeaponData_003Ek__BackingField;
		}
		private set
		{
			_003CAllWeaponData_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, JArray> AllCharacters
	{
		get
		{
			return _003CAllCharacters_003Ek__BackingField;
		}
		private set
		{
			_003CAllCharacters_003Ek__BackingField = value;
		}
	}

	public Dictionary<EnemyType, JArray> AllEnemies
	{
		get
		{
			return _003CAllEnemies_003Ek__BackingField;
		}
		private set
		{
			_003CAllEnemies_003Ek__BackingField = value;
		}
	}

	public Dictionary<ItemType, ItemData> AllItems
	{
		get
		{
			return _003CAllItems_003Ek__BackingField;
		}
		private set
		{
			_003CAllItems_003Ek__BackingField = value;
		}
	}

	public Dictionary<PowerUpType, JArray> AllPowerUps
	{
		get
		{
			return _003CAllPowerUps_003Ek__BackingField;
		}
		private set
		{
			_003CAllPowerUps_003Ek__BackingField = value;
		}
	}

	public Dictionary<PropType, PropData> AllProps
	{
		get
		{
			return _003CAllProps_003Ek__BackingField;
		}
		private set
		{
			_003CAllProps_003Ek__BackingField = value;
		}
	}

	public Dictionary<StageType, JArray> AllStages
	{
		get
		{
			return _003CAllStages_003Ek__BackingField;
		}
		private set
		{
			_003CAllStages_003Ek__BackingField = value;
		}
	}

	public Dictionary<ArcanaType, ArcanaData> AllArcanas
	{
		get
		{
			return _003CAllArcanas_003Ek__BackingField;
		}
		private set
		{
			_003CAllArcanas_003Ek__BackingField = value;
		}
	}

	public Dictionary<HitVfxType, HitVfxData> AllHitVfxData
	{
		get
		{
			return _003CAllHitVfxData_003Ek__BackingField;
		}
		private set
		{
			_003CAllHitVfxData_003Ek__BackingField = value;
		}
	}

	public Dictionary<BgmType, MusicData> AllMusicData
	{
		get
		{
			return _003CAllMusicData_003Ek__BackingField;
		}
		private set
		{
			_003CAllMusicData_003Ek__BackingField = value;
		}
	}

	public Dictionary<WeaponType, JArray> AllLimitBreakData
	{
		get
		{
			return _003CAllLimitBreakData_003Ek__BackingField;
		}
		private set
		{
			_003CAllLimitBreakData_003Ek__BackingField = value;
		}
	}

	public Dictionary<AchievementType, AchievementData> AllAchievements
	{
		get
		{
			return _003CAllAchievements_003Ek__BackingField;
		}
		private set
		{
			_003CAllAchievements_003Ek__BackingField = value;
		}
	}

	public Dictionary<SecretType, SecretData> AllSecrets
	{
		get
		{
			return _003CAllSecrets_003Ek__BackingField;
		}
		private set
		{
			_003CAllSecrets_003Ek__BackingField = value;
		}
	}

	public Dictionary<AdventureType, AdventureData> AllAdventures
	{
		get
		{
			return _003CAllAdventures_003Ek__BackingField;
		}
		private set
		{
			_003CAllAdventures_003Ek__BackingField = value;
		}
	}

	public Dictionary<AIType, AIData> AllCPU
	{
		get
		{
			return _003CAllCPU_003Ek__BackingField;
		}
		private set
		{
			_003CAllCPU_003Ek__BackingField = value;
		}
	}

	public Dictionary<StageSetType, JObject> AllStageSetData
	{
		get
		{
			return _003CAllStageSetData_003Ek__BackingField;
		}
		private set
		{
			_003CAllStageSetData_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, CustomMerchantData> AllAdventureMerchantsData
	{
		get
		{
			return _003CAllAdventureMerchantsData_003Ek__BackingField;
		}
		private set
		{
			_003CAllAdventureMerchantsData_003Ek__BackingField = value;
		}
	}

	public Dictionary<CharacterType, CustomMerchantData> AllCustomMerchantsData
	{
		get
		{
			return _003CAllCustomMerchantsData_003Ek__BackingField;
		}
		private set
		{
			_003CAllCustomMerchantsData_003Ek__BackingField = value;
		}
	}

	public Dictionary<AlbumType, AlbumData> AllAlbumData
	{
		get
		{
			return _003CAllAlbumData_003Ek__BackingField;
		}
		private set
		{
			_003CAllAlbumData_003Ek__BackingField = value;
		}
	}

	public HashSet<AchievementType> AllLoadedAchievements
	{
		get
		{
			return _003CAllLoadedAchievements_003Ek__BackingField;
		}
		private set
		{
			_003CAllLoadedAchievements_003Ek__BackingField = value;
		}
	}

	public Dictionary<DlcType, List<AchievementType>> AllDlcAchievements
	{
		get
		{
			return _003CAllDlcAchievements_003Ek__BackingField;
		}
		private set
		{
			_003CAllDlcAchievements_003Ek__BackingField = value;
		}
	}

	public Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>> AllDlcCharacterData => _dlcCharacterData;

	public Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>> AllDlcPowerUpData => _dlcPowerUpData;

	public Dictionary<DlcType, Dictionary<StageType, List<StageData>>> AllDlcStageData => _dlcStageData;

	public Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>> AllDlcWeaponData => _dlcWeaponData;

	public Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>> AllDlcEnemyData => _dlcEnemyData;

	public Dictionary<DlcType, Dictionary<BgmType, MusicData>> AllDlcMusicData => _dlcMusicData;

	public Dictionary<DlcType, HashSet<string>> AllDlcSfxData => _dlcSfxData;

	public Dictionary<CharacterType, List<CharacterData>> AdventureCharacterData => _adventureCharacterData;

	public Dictionary<StageType, List<StageData>> AdventureStageData => _adventureStageData;

	public Dictionary<EnemyType, List<EnemyData>> AdventureBestiaryData => _adventureBestiaryData;

	public static List<string> AllJsonPartFileNames
	{
		get
		{
			List<string> list = new List<string>();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"achievementData");
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version2 = list._version + 1;
					list._version = version2;
					string[] items2 = list._items;
					if (list._items != null)
					{
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"arcanaData");
						}
						else
						{
							int size2 = list._size + 1;
							list._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version3 = list._version + 1;
						list._version = version3;
						string[] items3 = list._items;
						if (list._items != null)
						{
							if (list._size >= items3.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"characterData");
							}
							else
							{
								int size3 = list._size + 1;
								list._size = size3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version4 = list._version + 1;
							list._version = version4;
							string[] items4 = list._items;
							if (list._items != null)
							{
								if (list._size >= items4.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"enemyData");
								}
								else
								{
									int size4 = list._size + 1;
									list._size = size4;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version5 = list._version + 1;
								list._version = version5;
								string[] items5 = list._items;
								if (list._items != null)
								{
									if (list._size >= items5.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"hitVfxData");
									}
									else
									{
										int size5 = list._size + 1;
										list._size = size5;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version6 = list._version + 1;
									list._version = version6;
									string[] items6 = list._items;
									if (list._items != null)
									{
										if (list._size >= items6.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"itemData");
										}
										else
										{
											int size6 = list._size + 1;
											list._size = size6;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version7 = list._version + 1;
										list._version = version7;
										string[] items7 = list._items;
										if (list._items != null)
										{
											if (list._size >= items7.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"limitBreakData");
											}
											else
											{
												int size7 = list._size + 1;
												list._size = size7;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version8 = list._version + 1;
											list._version = version8;
											string[] items8 = list._items;
											if (list._items != null)
											{
												if (list._size >= items8.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"musicData");
												}
												else
												{
													int size8 = list._size + 1;
													list._size = size8;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version9 = list._version + 1;
												list._version = version9;
												string[] items9 = list._items;
												if (list._items != null)
												{
													if (list._size >= items9.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"powerUpData");
													}
													else
													{
														int size9 = list._size + 1;
														list._size = size9;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version10 = list._version + 1;
													list._version = version10;
													string[] items10 = list._items;
													if (list._items != null)
													{
														if (list._size >= items10.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"propsData");
														}
														else
														{
															int size10 = list._size + 1;
															list._size = size10;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version11 = list._version + 1;
														list._version = version11;
														string[] items11 = list._items;
														if (list._items != null)
														{
															if (list._size >= items11.Length)
															{
																((List<object>)(object)list).AddWithResize((object)"secretData");
															}
															else
															{
																int size11 = list._size + 1;
																list._size = size11;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version12 = list._version + 1;
															list._version = version12;
															string[] items12 = list._items;
															if (list._items != null)
															{
																if (list._size >= items12.Length)
																{
																	((List<object>)(object)list).AddWithResize((object)"stageData");
																}
																else
																{
																	int size12 = list._size + 1;
																	list._size = size12;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																int version13 = list._version + 1;
																list._version = version13;
																string[] items13 = list._items;
																if (list._items != null)
																{
																	if (list._size >= items13.Length)
																	{
																		((List<object>)(object)list).AddWithResize((object)"weaponData");
																	}
																	else
																	{
																		int size13 = list._size + 1;
																		list._size = size13;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	int version14 = list._version + 1;
																	list._version = version14;
																	string[] items14 = list._items;
																	if (list._items != null)
																	{
																		if (list._size >= items14.Length)
																		{
																			((List<object>)(object)list).AddWithResize((object)"albumData");
																		}
																		else
																		{
																			int size14 = list._size + 1;
																			list._size = size14;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		int version15 = list._version + 1;
																		list._version = version15;
																		string[] items15 = list._items;
																		if (list._items != null)
																		{
																			if (list._size >= items15.Length)
																			{
																				((List<object>)(object)list).AddWithResize((object)"adventureData");
																			}
																			else
																			{
																				int size15 = list._size + 1;
																				list._size = size15;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			}
																			int version16 = list._version + 1;
																			list._version = version16;
																			string[] items16 = list._items;
																			if (list._items != null)
																			{
																				if (list._size >= items16.Length)
																				{
																					((List<object>)(object)list).AddWithResize((object)"adventuresStageSetData");
																				}
																				else
																				{
																					int size16 = list._size + 1;
																					list._size = size16;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				int version17 = list._version + 1;
																				list._version = version17;
																				string[] items17 = list._items;
																				if (list._items != null)
																				{
																					if (list._size >= items17.Length)
																					{
																						((List<object>)(object)list).AddWithResize((object)"adventuresMerchantsData");
																						return list;
																					}
																					int size17 = list._size + 1;
																					list._size = size17;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					return list;
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return (List<string>)(object)new NullReferenceException();
		}
	}

	public void Initialize()
	{
		LoadBaseJObjects();
		LoadDataFromJson();
		ClearConvertedDlcData();
		BuildConvertedData();
	}

	public void Dispose()
	{
	}

	public void ReloadAllData()
	{
		//IL_003f: Expected I, but got O
		if ((object)MarkerReloadAllData != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerReloadAllData);
		}
		ClearConvertedData();
		LoadDataFromJson();
		BuildConvertedData();
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	public Dictionary<CharacterType, List<CharacterData>> GetConvertedDlcCharacterData(DlcType dlcType)
	{
		if (_dlcCharacterData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcCharacterData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_dlcCharacterData != null)
			{
				return (Dictionary<CharacterType, List<CharacterData>>)((Dictionary<System.Int32Enum, object>)(object)_dlcCharacterData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (Dictionary<CharacterType, List<CharacterData>>)(object)new NullReferenceException();
	}

	public Dictionary<StageType, List<StageData>> GetConvertedDlcStageData(DlcType dlcType)
	{
		if (_dlcStageData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcStageData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_dlcStageData != null)
			{
				return (Dictionary<StageType, List<StageData>>)((Dictionary<System.Int32Enum, object>)(object)_dlcStageData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (Dictionary<StageType, List<StageData>>)(object)new NullReferenceException();
	}

	public Dictionary<WeaponType, List<WeaponData>> GetConvertedDlcWeaponData(DlcType dlcType)
	{
		if (_dlcWeaponData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcWeaponData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_dlcWeaponData != null)
			{
				return (Dictionary<WeaponType, List<WeaponData>>)((Dictionary<System.Int32Enum, object>)(object)_dlcWeaponData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (Dictionary<WeaponType, List<WeaponData>>)(object)new NullReferenceException();
	}

	public Dictionary<EnemyType, List<EnemyData>> GetConvertedDlcEnemyData(DlcType dlcType)
	{
		if (_dlcEnemyData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcEnemyData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_dlcEnemyData != null)
			{
				return (Dictionary<EnemyType, List<EnemyData>>)((Dictionary<System.Int32Enum, object>)(object)_dlcEnemyData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (Dictionary<EnemyType, List<EnemyData>>)(object)new NullReferenceException();
	}

	public Dictionary<PowerUpType, List<PowerUpData>> GetConvertedDlcPowerUpData(DlcType dlcType)
	{
		if (_dlcPowerUpData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcPowerUpData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_dlcPowerUpData != null)
			{
				return (Dictionary<PowerUpType, List<PowerUpData>>)((Dictionary<System.Int32Enum, object>)(object)_dlcPowerUpData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (Dictionary<PowerUpType, List<PowerUpData>>)(object)new NullReferenceException();
	}

	public Dictionary<BgmType, MusicData> GetConvertedDlcMusicData(DlcType dlcType)
	{
		if (_dlcMusicData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcMusicData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_dlcMusicData != null)
			{
				return (Dictionary<BgmType, MusicData>)((Dictionary<System.Int32Enum, object>)(object)_dlcMusicData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (Dictionary<BgmType, MusicData>)(object)new NullReferenceException();
	}

	public Dictionary<CharacterType, List<CharacterData>> GetConvertedCharacterData()
	{
		if (_characterData == null || (_characterDataChangedForOnline && !IsOnline()))
		{
			Dictionary<CharacterType, List<CharacterData>> characterData = ConvertCharacterJsonDataToObjects(_003CAllCharacters_003Ek__BackingField);
			_characterData = characterData;
			_characterDataChangedForOnline = false;
		}
		if (IsOnline() && !_characterDataChangedForOnline)
		{
			_characterDataChangedForOnline = true;
			if (_dlcCharacterData != null)
			{
				Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Dictionary<System.Int32Enum, object> onlineAvaliableDlcTypes = (Dictionary<System.Int32Enum, object>)(object)DlcSystem.OnlineAvaliableDlcTypes;
					if (DlcSystem.OnlineAvaliableDlcTypes != null)
					{
						if (!((Dictionary<CharacterType, List<CharacterData>>)(object)DlcSystem.OnlineAvaliableDlcTypes).Remove(CharacterType.VOID))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
		}
		return _characterData;
	}

	public Dictionary<EnemyType, List<EnemyData>> GetConvertedEnemyData()
	{
		if (_enemyData == null || (_enemyDataChangedForOnline && !IsOnline()))
		{
			Dictionary<EnemyType, List<EnemyData>> enemyData = ConvertEnemyDataJsonToObjects(_003CAllEnemies_003Ek__BackingField);
			_enemyData = enemyData;
			_enemyDataChangedForOnline = false;
		}
		if (IsOnline() && !_enemyDataChangedForOnline)
		{
			_enemyDataChangedForOnline = true;
			if (_dlcEnemyData != null)
			{
				Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Dictionary<System.Int32Enum, object> onlineAvaliableDlcTypes = (Dictionary<System.Int32Enum, object>)(object)DlcSystem.OnlineAvaliableDlcTypes;
					if (DlcSystem.OnlineAvaliableDlcTypes != null)
					{
						if (!((Dictionary<EnemyType, List<EnemyData>>)(object)DlcSystem.OnlineAvaliableDlcTypes).Remove(EnemyType.BAT1))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
		}
		return _enemyData;
	}

	public Dictionary<PowerUpType, List<PowerUpData>> GetConvertedPowerUpData()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected I, but got Unknown
		//IL_02f0: Expected O, but got I4
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		if (_powerUpData == null || (_powerUpDataChangedForOnline && !IsOnline()))
		{
			Dictionary<PowerUpType, List<PowerUpData>> powerUpData = ConvertPowerUpJsonData(_003CAllPowerUps_003Ek__BackingField);
			_powerUpData = powerUpData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj = this + 40;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = 6603577472L + obj5;
				nint num = (nint)(obj3 & 0x3F);
				nint num3;
				do
				{
					object obj7 = 1 << (int)num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v18+462E0]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v18+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v18+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v18+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v18+462E0]");
				}
				while (num3 != 0);
			}
		}
		if (IsOnline() && !_powerUpDataChangedForOnline)
		{
			_powerUpDataChangedForOnline = true;
			if (_dlcPowerUpData != null)
			{
				Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Dictionary<System.Int32Enum, object> onlineAvaliableDlcTypes = (Dictionary<System.Int32Enum, object>)(object)DlcSystem.OnlineAvaliableDlcTypes;
					if (DlcSystem.OnlineAvaliableDlcTypes != null)
					{
						if (!((Dictionary<PowerUpType, List<PowerUpData>>)(object)DlcSystem.OnlineAvaliableDlcTypes).Remove(PowerUpType.POWER))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
		}
		return _powerUpData;
	}

	public Dictionary<StageType, List<StageData>> GetConvertedStages()
	{
		if (_stageData == null || (_stageDataChangedForOnline && !IsOnline()))
		{
			Dictionary<StageType, List<StageData>> stageData = ConvertStageDataJsonToObjects(_003CAllStages_003Ek__BackingField);
			_stageData = stageData;
			_stageDataChangedForOnline = false;
		}
		if (IsOnline() && !_stageDataChangedForOnline)
		{
			_stageDataChangedForOnline = true;
			if (_dlcStageData != null)
			{
				Dictionary<DlcType, Dictionary<StageType, List<StageData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<StageType, List<StageData>>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Dictionary<System.Int32Enum, object> onlineAvaliableDlcTypes = (Dictionary<System.Int32Enum, object>)(object)DlcSystem.OnlineAvaliableDlcTypes;
					if (DlcSystem.OnlineAvaliableDlcTypes != null)
					{
						if (!((Dictionary<StageType, List<StageData>>)(object)DlcSystem.OnlineAvaliableDlcTypes).Remove(StageType.FOREST))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
		}
		return _stageData;
	}

	public Dictionary<StageType, List<StageData>> GetConvertedAdventureStages()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0120: Expected O, but got I4
		Dictionary<StageType, List<StageData>> dictionary;
		if (_adventureStageData == null)
		{
			dictionary = ConvertStageDataJsonToObjects(_003CAllStages_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			_adventureStageData = dictionary;
			if (flag)
			{
				goto IL_00ee;
			}
			object obj = this + 312;
			object obj2 = obj >> 12;
			object obj3 = obj2 & 0x1FFFFF;
			object obj4 = obj3 >> 6;
			object obj5 = obj3 & 0x3F;
			object obj6 = obj4 * 8;
			object obj7 = 6603864928L + obj6;
			do
			{
				object obj8 = 1 << (int)obj5;
				object obj9 = obj7 | obj8;
				if (obj7 == obj7)
				{
					obj7 = obj9;
				}
			}
			while (obj7 != obj7);
		}
		dictionary = _adventureStageData;
		goto IL_00ee;
		IL_00ee:
		return dictionary;
	}

	public Dictionary<WeaponType, List<WeaponData>> GetConvertedWeapons()
	{
		if (_weaponData == null || (_weaponDataChangedForOnline && !IsOnline()))
		{
			Dictionary<WeaponType, List<WeaponData>> weaponData = ConvertWeaponDataJsonToObjects(_003CAllWeaponData_003Ek__BackingField);
			_weaponData = weaponData;
			_weaponDataChangedForOnline = false;
		}
		if (IsOnline() && !_weaponDataChangedForOnline)
		{
			_weaponDataChangedForOnline = true;
			if (_dlcWeaponData != null)
			{
				Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Dictionary<System.Int32Enum, object> onlineAvaliableDlcTypes = (Dictionary<System.Int32Enum, object>)(object)DlcSystem.OnlineAvaliableDlcTypes;
					if (DlcSystem.OnlineAvaliableDlcTypes != null)
					{
						if (!((Dictionary<WeaponType, List<WeaponData>>)(object)DlcSystem.OnlineAvaliableDlcTypes).Remove(WeaponType.VOID))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
		}
		return _weaponData;
	}

	public PropData GetPropData(PropType propType)
	{
		if (_003CAllProps_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_003CAllProps_003Ek__BackingField).FindEntry((System.Int32Enum)propType);
			if (num < 0)
			{
				return null;
			}
			if (_003CAllProps_003Ek__BackingField != null)
			{
				return (PropData)((Dictionary<System.Int32Enum, object>)(object)_003CAllProps_003Ek__BackingField).get_Item((System.Int32Enum)propType);
			}
		}
		return (PropData)(object)new NullReferenceException();
	}

	public void AddDefaultUnlocksToSaveData()
	{
		//IL_0027: Expected O, but got I4
		//IL_0142: Expected I, but got O
		//IL_006a: Expected O, but got I
		//IL_007f: Expected O, but got I
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		object obj4 = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			object obj = 0;
			nint num = 0;
			if (0 == 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v13+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v13+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rbx_v8+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rbx_v17+88]");
				if ((nint)0 == 0)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rbx_v17+10]");
				if ((nint)0 == 0)
				{
					PlayerOptionsData config = _playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					if (obj4 == null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					}
				}
				continue;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			num = unchecked((nint)null);
			break;
		}
		throw new NullReferenceException();
	}

	public void UpdateAllCharacterHiddenPropertiesForAdventures(AdventureData adventureData)
	{
		Dictionary<CharacterType, JArray>.Enumerator enumerator = default(Dictionary<CharacterType, JArray>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
	}

	public unsafe void GenerateAdventureSpecificData(AdventureData adventureData)
	{
		//IL_04a7: Expected O, but got I
		//IL_0079: Expected O, but got I
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_04e3: Expected O, but got Ref
		//IL_01c9: Expected O, but got Ref
		Dictionary<CharacterType, JArray> dictionary = new Dictionary<CharacterType, JArray>();
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-E0_v18+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-E0_v18+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-E0_v18+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						Dictionary<CharacterType, JArray> dictionary2 = _003CAllCharacters_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v57+20+v215 @ stack_-D8_v17*4]");
						bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryGetValue((System.Int32Enum)0, out object value);
						bool flag2 = !flag;
						obj4 = obj6;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v57+20+v836 @ rcx_v63*4]");
							bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag4 = obj == null;
		Dictionary<CharacterType, JArray> dictionary3 = (Dictionary<CharacterType, JArray>)0;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-E0_v18+1C]");
			if (obj2 == null)
			{
				Dictionary<CharacterType, List<CharacterData>> adventureCharacterData = ConvertCharacterJsonDataToObjects(dictionary);
				_adventureCharacterData = adventureCharacterData;
				if (((Dictionary<System.Int32Enum, object>)(object)_003CAllStageSetData_003Ek__BackingField).TryGetValue((System.Int32Enum)adventureData._003CStageSetType_003Ek__BackingField, out object value2))
				{
					Dictionary<StageType, List<StageData>> adventureStageData = new Dictionary<StageType, List<StageData>>();
					_adventureStageData = adventureStageData;
					object obj7 = ((JToken)value2).ToObject<object>();
					Dictionary<StageType, JArray>.Enumerator enumerator = default(Dictionary<StageType, JArray>.Enumerator);
					if (enumerator.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						Dictionary<System.Int32Enum, object> dictionary4 = (Dictionary<System.Int32Enum, object>)(&enumerator);
						throw new NullReferenceException();
					}
				}
				else
				{
					System.Int32Enum int32Enum = default(System.Int32Enum);
					object arg = (StageSetType)int32Enum;
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					System.ParamsArray paramsArray2 = default(System.ParamsArray);
					string message = string.FormatHelper((IFormatProvider)null, "Could not find any StageData for StageSetType: {0}", (System.ParamsArray)(&paramsArray2));
					Debug.LogError(message);
				}
				GenerateBestiaryDataForAdventure(adventureData);
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary3 = null;
		}
		throw new NullReferenceException();
	}

	public void ExitAdventure()
	{
		_adventureStageData = null;
		_adventureCharacterData = null;
		ReloadAllData();
	}

	private bool IsOnline()
	{
		//IL_00e2: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null && core2._multiplayer != null)
			{
				return core2._multiplayer.IsOnlineMultiplayer;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null)
		{
			bool flag = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	private void LoadBaseJObjects()
	{
		//IL_070f: Expected I, but got O
		if ((object)MarkerLoadBaseJObjects != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerLoadBaseJObjects);
		}
		DataManagerSettings settings = _settings;
		bool flag = _settings == null;
		bool flag2 = (object)settings._WeaponDataJsonAsset == null;
		string text = settings._WeaponDataJsonAsset.text;
		JObject allWeaponDataJson = JObject.Parse(text, null);
		_allWeaponDataJson = allWeaponDataJson;
		bool flag3 = (object)settings._CharacterDataJsonAsset == null;
		string text2 = settings._CharacterDataJsonAsset.text;
		JObject allCharactersJson = JObject.Parse(text2, null);
		_allCharactersJson = allCharactersJson;
		bool flag4 = (object)settings._EnemyDataJsonAsset == null;
		string text3 = settings._EnemyDataJsonAsset.text;
		JObject allEnemiesJson = JObject.Parse(text3, null);
		_allEnemiesJson = allEnemiesJson;
		bool flag5 = (object)settings._ItemDataJsonAsset == null;
		string text4 = settings._ItemDataJsonAsset.text;
		JObject allItemsJson = JObject.Parse(text4, null);
		_allItemsJson = allItemsJson;
		bool flag6 = (object)settings._PowerUpDataJsonAsset == null;
		string text5 = settings._PowerUpDataJsonAsset.text;
		JObject allPowerUpsJson = JObject.Parse(text5, null);
		_allPowerUpsJson = allPowerUpsJson;
		bool flag7 = (object)settings._PropsDataJsonAsset == null;
		string text6 = settings._PropsDataJsonAsset.text;
		JObject allPropsJson = JObject.Parse(text6, null);
		_allPropsJson = allPropsJson;
		bool flag8 = (object)settings._StageDataJsonAsset == null;
		string text7 = settings._StageDataJsonAsset.text;
		JObject allStagesJson = JObject.Parse(text7, null);
		_allStagesJson = allStagesJson;
		bool flag9 = (object)settings._ArcanaDataJsonAsset == null;
		string text8 = settings._ArcanaDataJsonAsset.text;
		JObject allArcanasJson = JObject.Parse(text8, null);
		_allArcanasJson = allArcanasJson;
		bool flag10 = (object)settings._HitVfxDataJsonAsset == null;
		string text9 = settings._HitVfxDataJsonAsset.text;
		JObject allHitVfxDataJson = JObject.Parse(text9, null);
		_allHitVfxDataJson = allHitVfxDataJson;
		bool flag11 = (object)settings._MusicDataJsonAsset == null;
		string text10 = settings._MusicDataJsonAsset.text;
		JObject allMusicDataJson = JObject.Parse(text10, null);
		_allMusicDataJson = allMusicDataJson;
		bool flag12 = (object)settings._LimitBreakDataJsonAsset == null;
		string text11 = settings._LimitBreakDataJsonAsset.text;
		JObject allLimitBreakDataJson = JObject.Parse(text11, null);
		_allLimitBreakDataJson = allLimitBreakDataJson;
		bool flag13 = (object)settings._AchievementDataJsonAsset == null;
		string text12 = settings._AchievementDataJsonAsset.text;
		JObject allAchievementsJson = JObject.Parse(text12, null);
		_allAchievementsJson = allAchievementsJson;
		bool flag14 = (object)settings._SecretsDataJsonAsset == null;
		string text13 = settings._SecretsDataJsonAsset.text;
		JObject allSecretsJson = JObject.Parse(text13, null);
		_allSecretsJson = allSecretsJson;
		bool flag15 = (object)settings._AdventureDataJsonAsset == null;
		string text14 = settings._AdventureDataJsonAsset.text;
		JObject allAdventuresJson = JObject.Parse(text14, null);
		_allAdventuresJson = allAdventuresJson;
		bool flag16 = (object)settings._AdventuresStageSetDataJsonAsset == null;
		string text15 = settings._AdventuresStageSetDataJsonAsset.text;
		JObject allStageSetJson = JObject.Parse(text15, null);
		_allStageSetJson = allStageSetJson;
		bool flag17 = (object)settings._AdventuresStagesJsonAsset == null;
		string text16 = settings._AdventuresStagesJsonAsset.text;
		JObject allAdventureStagesJson = JObject.Parse(text16, null);
		_allAdventureStagesJson = allAdventureStagesJson;
		bool flag18 = (object)settings._AdventuresMerchantsDataJsonAsset == null;
		string text17 = settings._AdventuresMerchantsDataJsonAsset.text;
		JObject allAdventureMerchantsJson = JObject.Parse(text17, null);
		_allAdventureMerchantsJson = allAdventureMerchantsJson;
		bool flag19 = (object)settings._AlbumDataJsonAsset == null;
		string text18 = settings._AlbumDataJsonAsset.text;
		JObject allAlbumData = JObject.Parse(text18, null);
		_allAlbumData = allAlbumData;
		bool flag20 = (object)settings._CustomMerchantsDataJsonAsset == null;
		string text19 = settings._CustomMerchantsDataJsonAsset.text;
		JObject allCustomMerchantsJson = JObject.Parse(text19, null);
		_allCustomMerchantsJson = allCustomMerchantsJson;
		bool flag21 = (object)settings._AllCPUAsset == null;
		string text20 = settings._AllCPUAsset.text;
		JObject allCPUJson = JObject.Parse(text20, null);
		_allCPUJson = allCPUJson;
		Dictionary<DlcType, HashSet<string>> dlcSfxData = new Dictionary<DlcType, HashSet<string>>();
		_dlcSfxData = dlcSfxData;
		HashSet<AchievementType> hashSet = (HashSet<AchievementType>)(object)new HashSet<System.Int32Enum>();
		_003CAllLoadedAchievements_003Ek__BackingField = hashSet;
		Dictionary<DlcType, List<AchievementType>> dictionary = new Dictionary<DlcType, List<AchievementType>>();
		_003CAllDlcAchievements_003Ek__BackingField = dictionary;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	private unsafe void LoadDataFromJson()
	{
		//IL_080d: Expected I, but got O
		//IL_040b: Expected O, but got Ref
		//IL_0503: Expected O, but got I
		//IL_0518: Expected I, but got O
		//IL_052f: Expected O, but got I
		//IL_0555: Expected O, but got I4
		//IL_0627: Expected O, but got I4
		//IL_062c: Expected I, but got O
		//IL_05f1: Expected O, but got I4
		//IL_06e8->IL084b: Incompatible stack heights: 20 vs 18
		//IL_0564->IL0812: Incompatible stack heights: 23 vs 18
		//IL_0686->IL0812: Incompatible stack heights: 22 vs 18
		//IL_0639->IL082b: Incompatible stack heights: 23 vs 22
		//IL_05ff->IL0681: Incompatible stack heights: 25 vs 22
		if ((object)MarkerLoadDataFromJson != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerLoadDataFromJson);
		}
		bool flag = _allWeaponDataJson == null;
		object obj = _allWeaponDataJson.ToObject<object>();
		_003CAllWeaponData_003Ek__BackingField = (Dictionary<WeaponType, JArray>)obj;
		bool flag2 = _allCharactersJson == null;
		object obj2 = _allCharactersJson.ToObject<object>();
		_003CAllCharacters_003Ek__BackingField = (Dictionary<CharacterType, JArray>)obj2;
		bool flag3 = _allEnemiesJson == null;
		object obj3 = _allEnemiesJson.ToObject<object>();
		_003CAllEnemies_003Ek__BackingField = (Dictionary<EnemyType, JArray>)obj3;
		bool flag4 = _allItemsJson == null;
		object obj4 = _allItemsJson.ToObject<object>();
		_003CAllItems_003Ek__BackingField = (Dictionary<ItemType, ItemData>)obj4;
		bool flag5 = _allPowerUpsJson == null;
		object obj5 = _allPowerUpsJson.ToObject<object>();
		_003CAllPowerUps_003Ek__BackingField = (Dictionary<PowerUpType, JArray>)obj5;
		bool flag6 = _allPropsJson == null;
		object obj6 = _allPropsJson.ToObject<object>();
		_003CAllProps_003Ek__BackingField = (Dictionary<PropType, PropData>)obj6;
		bool flag7 = _allStagesJson == null;
		object obj7 = _allStagesJson.ToObject<object>();
		_003CAllStages_003Ek__BackingField = (Dictionary<StageType, JArray>)obj7;
		bool flag8 = _allArcanasJson == null;
		object obj8 = _allArcanasJson.ToObject<object>();
		_003CAllArcanas_003Ek__BackingField = (Dictionary<ArcanaType, ArcanaData>)obj8;
		bool flag9 = _allHitVfxDataJson == null;
		object obj9 = _allHitVfxDataJson.ToObject<object>();
		_003CAllHitVfxData_003Ek__BackingField = (Dictionary<HitVfxType, HitVfxData>)obj9;
		bool flag10 = _allMusicDataJson == null;
		object obj10 = _allMusicDataJson.ToObject<object>();
		_003CAllMusicData_003Ek__BackingField = (Dictionary<BgmType, MusicData>)obj10;
		bool flag11 = _allLimitBreakDataJson == null;
		object obj11 = _allLimitBreakDataJson.ToObject<object>();
		_003CAllLimitBreakData_003Ek__BackingField = (Dictionary<WeaponType, JArray>)obj11;
		bool flag12 = _allAchievementsJson == null;
		object obj12 = _allAchievementsJson.ToObject<object>();
		_003CAllAchievements_003Ek__BackingField = (Dictionary<AchievementType, AchievementData>)obj12;
		bool flag13 = _allSecretsJson == null;
		object obj13 = _allSecretsJson.ToObject<object>();
		_003CAllSecrets_003Ek__BackingField = (Dictionary<SecretType, SecretData>)obj13;
		bool flag14 = _allAdventuresJson == null;
		object obj14 = _allAdventuresJson.ToObject<object>();
		_003CAllAdventures_003Ek__BackingField = (Dictionary<AdventureType, AdventureData>)obj14;
		bool flag15 = _allCPUJson == null;
		object obj15 = _allCPUJson.ToObject<object>();
		_003CAllCPU_003Ek__BackingField = (Dictionary<AIType, AIData>)obj15;
		bool flag16 = _allStageSetJson == null;
		object obj16 = _allStageSetJson.ToObject<object>();
		bool flag17 = _allAdventureStagesJson == null;
		object obj17 = _allAdventureStagesJson.ToObject<object>();
		Dictionary<StageSetType, JObject> dictionary = new Dictionary<StageSetType, JObject>();
		bool flag18 = obj16 == null;
		JToken value = null;
		object value2 = null;
		Dictionary<StageSetType, JObject> dictionary2 = dictionary;
		Dictionary<StageSetType, JArray>.Enumerator enumerator = default(Dictionary<StageSetType, JArray>.Enumerator);
		object obj19 = default(object);
		object obj20 = default(object);
		JToken jToken = default(JToken);
		System.Int32Enum key = default(System.Int32Enum);
		JObject jObject2 = default(JObject);
		while (enumerator.MoveNext())
		{
			JObject jObject = new JObject();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			IEnumerator<JToken> enumerator2 = ((JArray)null).GetEnumerator();
			object obj18 = (object)(&obj19);
			System.Collections.Generic.InsertionBehavior insertionBehavior;
			while (true)
			{
				bool flag19 = obj19 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj20 == null)
				{
					break;
				}
				bool flag20 = obj19 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804860B0");
				bool flag21 = jToken == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ADE0");
				bool flag22 = obj17 == null;
				nint num3;
				string message;
				if (((Dictionary<System.Int32Enum, object>)obj17).TryGetValue(key, out value2))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					bool flag23 = value2 == null;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3905 @ rdx_v71 (Il2CppMethodInfo)+50]");
					object obj21 = (nint)0 + (nint)20;
					object obj22 = obj21 + obj21;
					nint num2 = (nint)value2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3909 @ rax_v117 (Il2CppClass<System.Object>)+v3908 @ rcx_v93*8]");
					bool flag24 = ((Dictionary<StageType, JArray>)0).TryGetValue(StageType.FOREST, out *(JArray*)(&value2));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3911 @ rax_v118 (System.Boolean)+8] (should have been resolved before IL gen)");
					bool flag25 = jObject2 == null;
					object obj23 = 0;
					insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
					if (flag25)
					{
						continue;
					}
					if (jObject2.TryGetValue("stageKey", out value))
					{
						bool flag26 = value == null;
						object propertyName = value.ToObject<object>();
						bool flag27 = jObject == null;
						jObject.Add((string)propertyName, (JToken)value2);
						obj23 = 0;
						insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						continue;
					}
					string text = jToken.ToString();
					string text2 = "Could not find stageKey in stageSetData for stageSetTyp[e: " + text;
					obj23 = 0;
					num3 = unchecked((nint)null);
					message = text2;
				}
				else
				{
					string text3 = jToken.ToString();
					string text4 = "Could not find any stage set data for stageSetType: " + text3;
					num3 = 0;
					message = text4;
				}
				Debug.LogError(message);
				insertionBehavior = (System.Collections.Generic.InsertionBehavior)num3;
			}
			if (obj18 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			bool flag28 = dictionary == null;
			bool flag29 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)jObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			dictionary2 = dictionary;
		}
		_003CAllStageSetData_003Ek__BackingField = dictionary2;
		bool flag30 = _allAdventureMerchantsJson == null;
		object obj24 = _allAdventureMerchantsJson.ToObject<object>();
		_003CAllAdventureMerchantsData_003Ek__BackingField = (Dictionary<CharacterType, CustomMerchantData>)obj24;
		bool flag31 = _allAlbumData == null;
		object obj25 = _allAlbumData.ToObject<object>();
		_003CAllAlbumData_003Ek__BackingField = (Dictionary<AlbumType, AlbumData>)obj25;
		bool flag32 = _allCustomMerchantsJson == null;
		object obj26 = _allCustomMerchantsJson.ToObject<object>();
		_003CAllCustomMerchantsData_003Ek__BackingField = (Dictionary<CharacterType, CustomMerchantData>)obj26;
		HashSet<AchievementType> hashSet = (HashSet<AchievementType>)(object)new HashSet<System.Int32Enum>();
		_003CAllLoadedAchievements_003Ek__BackingField = hashSet;
		CacheBaseGameLoadedAchievements();
		AdjustAchievementDataWithTypes();
		AdjustAdventureProgressDataWithTypes();
		ProfilerMarker profilerMarker = default(ProfilerMarker);
		((ProfilerMarker.AutoScope*)(&profilerMarker))->Dispose();
	}

	public void MergeInJsonData(DataManagerSettings settings, DlcType dlcType)
	{
		LoadAndMergeIn(_allWeaponDataJson, settings._WeaponDataJsonAsset);
		LoadAndMergeIn(_allCharactersJson, settings._CharacterDataJsonAsset);
		LoadAndMergeIn(_allEnemiesJson, settings._EnemyDataJsonAsset);
		LoadAndMergeIn(_allItemsJson, settings._ItemDataJsonAsset);
		LoadAndMergeIn(_allPowerUpsJson, settings._PowerUpDataJsonAsset);
		LoadAndMergeIn(_allPropsJson, settings._PropsDataJsonAsset);
		LoadAndMergeIn(_allStagesJson, settings._StageDataJsonAsset);
		LoadAndMergeIn(_allArcanasJson, settings._ArcanaDataJsonAsset);
		LoadAndMergeIn(_allHitVfxDataJson, settings._HitVfxDataJsonAsset);
		LoadAndMergeIn(_allMusicDataJson, settings._MusicDataJsonAsset);
		LoadAndMergeIn(_allLimitBreakDataJson, settings._LimitBreakDataJsonAsset);
		LoadAndMergeIn(_allAchievementsJson, settings._AchievementDataJsonAsset);
		LoadAndMergeIn(_allSecretsJson, settings._SecretsDataJsonAsset);
		LoadAndMergeIn(_allAlbumData, settings._AlbumDataJsonAsset);
		LoadAndMergeIn(_allCPUJson, settings._AllCPUAsset);
		MergeInDlcAchievements(dlcType, settings._AchievementDataJsonAsset);
		BuildConvertedDlcData(settings, dlcType);
		ReloadAllData();
	}

	private void InternalMergeInJsonData(DataManagerSettings settings, DlcType dlcType, bool reload = true)
	{
		LoadAndMergeIn(_allWeaponDataJson, settings._WeaponDataJsonAsset);
		LoadAndMergeIn(_allCharactersJson, settings._CharacterDataJsonAsset);
		LoadAndMergeIn(_allEnemiesJson, settings._EnemyDataJsonAsset);
		LoadAndMergeIn(_allItemsJson, settings._ItemDataJsonAsset);
		LoadAndMergeIn(_allPowerUpsJson, settings._PowerUpDataJsonAsset);
		LoadAndMergeIn(_allPropsJson, settings._PropsDataJsonAsset);
		LoadAndMergeIn(_allStagesJson, settings._StageDataJsonAsset);
		LoadAndMergeIn(_allArcanasJson, settings._ArcanaDataJsonAsset);
		LoadAndMergeIn(_allHitVfxDataJson, settings._HitVfxDataJsonAsset);
		LoadAndMergeIn(_allMusicDataJson, settings._MusicDataJsonAsset);
		LoadAndMergeIn(_allLimitBreakDataJson, settings._LimitBreakDataJsonAsset);
		LoadAndMergeIn(_allAchievementsJson, settings._AchievementDataJsonAsset);
		LoadAndMergeIn(_allSecretsJson, settings._SecretsDataJsonAsset);
		LoadAndMergeIn(_allAlbumData, settings._AlbumDataJsonAsset);
		LoadAndMergeIn(_allCPUJson, settings._AllCPUAsset);
		MergeInDlcAchievements(dlcType, settings._AchievementDataJsonAsset);
		BuildConvertedDlcData(settings, dlcType);
		if (reload)
		{
			ReloadAllData();
		}
	}

	private void CacheBaseGameLoadedAchievements()
	{
		Dictionary<AchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AchievementType, AchievementData>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (_003CAllLoadedAchievements_003Ek__BackingField == null)
				{
					break;
				}
				bool flag = ((HashSet<System.Int32Enum>)(object)_003CAllLoadedAchievements_003Ek__BackingField).AddIfNotPresent((System.Int32Enum)0);
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void MergeInDlcAchievements(DlcType dlcType, TextAsset achievements)
	{
		//IL_0159: Expected O, but got I
		//IL_0169: Expected O, but got I
		//IL_01e3: Expected O, but got I
		if ((object)achievements == null || ((UnityEngine.Object)achievements).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string text = achievements.text;
		JObject jObject = JObject.Parse(text, null);
		bool flag = jObject == null;
		string text2 = text;
		if (!flag)
		{
			object obj = jObject.ToObject<object>();
			List<AchievementType> list = new List<AchievementType>();
			bool flag2 = obj == null;
			text2 = (string)(object)list;
			if (!flag2)
			{
				Dictionary<AchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AchievementType, AchievementData>.Enumerator);
				while (enumerator.MoveNext())
				{
					bool flag3 = _003CAllLoadedAchievements_003Ek__BackingField == null;
					text2 = (string)(object)_003CAllLoadedAchievements_003Ek__BackingField;
					if (!flag3)
					{
						bool flag4 = ((HashSet<System.Int32Enum>)(object)_003CAllLoadedAchievements_003Ek__BackingField).AddIfNotPresent((System.Int32Enum)0);
						bool flag5 = list == null;
						text2 = (string)(object)_003CAllLoadedAchievements_003Ek__BackingField;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
							text2 = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v23+18]");
								if (num >= 0)
								{
									((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								object obj3 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v23+18]");
								if (num2 < 0)
								{
									_ = 0;
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (_003CAllDlcAchievements_003Ek__BackingField != null)
				{
					int num3 = ((Dictionary<System.Int32Enum, object>)(object)_003CAllDlcAchievements_003Ek__BackingField).FindEntry((System.Int32Enum)dlcType);
					if (num3 >= 0)
					{
						if (_003CAllDlcAchievements_003Ek__BackingField == null)
						{
							goto IL_02cf;
						}
						bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)_003CAllDlcAchievements_003Ek__BackingField).Remove((System.Int32Enum)dlcType);
					}
					if (_003CAllDlcAchievements_003Ek__BackingField != null)
					{
						bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)_003CAllDlcAchievements_003Ek__BackingField).TryInsert((System.Int32Enum)dlcType, (object)list, System.Collections.Generic.InsertionBehavior.None);
						return;
					}
				}
			}
		}
		goto IL_02cf;
		IL_02cf:
		throw new NullReferenceException();
	}

	public void MergeInSFXTypes(DlcType dlc, Transform instantiatedSoundGroup)
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_00ef: Expected O, but got I
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_012d: Expected O, but got I
		//IL_014e->IL0191: Incompatible stack heights: 1 vs 0
		Transform transform = default(Transform);
		DynamicSoundGroup[] componentsInChildren = transform.GetComponentsInChildren<DynamicSoundGroup>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < componentsInChildren.Length)
		{
			DynamicSoundGroup dynamicSoundGroup = componentsInChildren[obj2];
			bool flag = ((UnityEngine.Object)dynamicSoundGroup).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)dynamicSoundGroup).m_CachedPtr);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			string name = ((UnityEngine.Object)gameObject).GetName();
			int num = ((Dictionary<System.Int32Enum, object>)(object)_dlcSfxData).FindEntry((System.Int32Enum)dlc);
			if (num < 0)
			{
				HashSet<string> value = (HashSet<string>)(object)new HashSet<object>();
				bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)_dlcSfxData).TryInsert((System.Int32Enum)dlc, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)_dlcSfxData).get_Item((System.Int32Enum)dlc);
			bool flag3 = ((HashSet<object>)obj3).Contains((object)name);
			transform = (Transform)0;
			if (!flag3)
			{
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)_dlcSfxData).get_Item((System.Int32Enum)dlc);
				bool flag4 = ((HashSet<object>)obj4).AddIfNotPresent((object)name);
				transform = (Transform)0;
			}
			obj2++;
			obj = obj2;
		}
	}

	private void LoadAndMergeIn(JObject original, TextAsset newAsset)
	{
		if ((object)newAsset != null && ((UnityEngine.Object)newAsset).m_CachedPtr != (IntPtr)0)
		{
			string text = newAsset.text;
			JObject jObject = JObject.Parse(text, null);
			if (jObject != null)
			{
				((JContainer)original).ValidateContent((object)jObject);
				original.MergeItem((object)jObject, _mergeSettings);
			}
		}
	}

	private unsafe void BuildConvertedDlcData(DataManagerSettings settings, DlcType dlcType)
	{
		//IL_0594: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "DataManager.BuildConvertedDlcData for " + text;
		Debug.Log(message);
		TextAsset characterDataJsonAsset = settings._CharacterDataJsonAsset;
		if ((object)settings._CharacterDataJsonAsset != null && ((UnityEngine.Object)characterDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			string text2 = settings._CharacterDataJsonAsset.text;
			JObject jObject = JObject.Parse(text2, null);
			object jsonData = jObject.ToObject<object>();
			if (_dlcCharacterData == null)
			{
				Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>> dlcCharacterData = new Dictionary<DlcType, Dictionary<CharacterType, List<CharacterData>>>();
				_dlcCharacterData = dlcCharacterData;
			}
			Dictionary<CharacterType, List<CharacterData>> value = ConvertCharacterJsonDataToObjects((Dictionary<CharacterType, JArray>)jsonData);
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)_dlcCharacterData).TryInsert((System.Int32Enum)dlcType, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		TextAsset stageDataJsonAsset = settings._StageDataJsonAsset;
		if ((object)settings._StageDataJsonAsset != null && ((UnityEngine.Object)stageDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			string text3 = settings._StageDataJsonAsset.text;
			JObject jObject2 = JObject.Parse(text3, null);
			object jsonData2 = jObject2.ToObject<object>();
			if (_dlcStageData == null)
			{
				Dictionary<DlcType, Dictionary<StageType, List<StageData>>> dlcStageData = new Dictionary<DlcType, Dictionary<StageType, List<StageData>>>();
				_dlcStageData = dlcStageData;
			}
			Dictionary<StageType, List<StageData>> value2 = ConvertStageDataJsonToObjects((Dictionary<StageType, JArray>)jsonData2);
			bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)_dlcStageData).TryInsert((System.Int32Enum)dlcType, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		TextAsset weaponDataJsonAsset = settings._WeaponDataJsonAsset;
		if ((object)settings._WeaponDataJsonAsset != null && ((UnityEngine.Object)weaponDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			string text4 = settings._WeaponDataJsonAsset.text;
			JObject jObject3 = JObject.Parse(text4, null);
			object weaponJson = jObject3.ToObject<object>();
			if (_dlcWeaponData == null)
			{
				Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>> dlcWeaponData = new Dictionary<DlcType, Dictionary<WeaponType, List<WeaponData>>>();
				_dlcWeaponData = dlcWeaponData;
			}
			Dictionary<WeaponType, List<WeaponData>> value3 = ConvertWeaponDataJsonToObjects((Dictionary<WeaponType, JArray>)weaponJson);
			bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)_dlcWeaponData).TryInsert((System.Int32Enum)dlcType, (object)value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		TextAsset enemyDataJsonAsset = settings._EnemyDataJsonAsset;
		if ((object)settings._EnemyDataJsonAsset != null && ((UnityEngine.Object)enemyDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			string text5 = settings._EnemyDataJsonAsset.text;
			JObject jObject4 = JObject.Parse(text5, null);
			object enemyJson = jObject4.ToObject<object>();
			if (_dlcEnemyData == null)
			{
				Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>> dlcEnemyData = new Dictionary<DlcType, Dictionary<EnemyType, List<EnemyData>>>();
				_dlcEnemyData = dlcEnemyData;
			}
			Dictionary<EnemyType, List<EnemyData>> value4 = ConvertEnemyDataJsonToObjects((Dictionary<EnemyType, JArray>)enemyJson);
			bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)_dlcEnemyData).TryInsert((System.Int32Enum)dlcType, (object)value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		TextAsset powerUpDataJsonAsset = settings._PowerUpDataJsonAsset;
		if ((object)settings._PowerUpDataJsonAsset != null && ((UnityEngine.Object)powerUpDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			string text6 = settings._PowerUpDataJsonAsset.text;
			JObject jObject5 = JObject.Parse(text6, null);
			object jsonData3 = jObject5.ToObject<object>();
			if (_dlcPowerUpData == null)
			{
				Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>> dlcPowerUpData = new Dictionary<DlcType, Dictionary<PowerUpType, List<PowerUpData>>>();
				_dlcPowerUpData = dlcPowerUpData;
			}
			Dictionary<PowerUpType, List<PowerUpData>> value5 = ConvertPowerUpJsonData((Dictionary<PowerUpType, JArray>)jsonData3);
			bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)_dlcPowerUpData).TryInsert((System.Int32Enum)dlcType, (object)value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		TextAsset musicDataJsonAsset = settings._MusicDataJsonAsset;
		if ((object)settings._MusicDataJsonAsset != null && ((UnityEngine.Object)musicDataJsonAsset).m_CachedPtr != (IntPtr)0)
		{
			string text7 = settings._MusicDataJsonAsset.text;
			JObject jObject6 = JObject.Parse(text7, null);
			object value6 = jObject6.ToObject<object>();
			if (_dlcMusicData == null)
			{
				Dictionary<DlcType, Dictionary<BgmType, MusicData>> dlcMusicData = new Dictionary<DlcType, Dictionary<BgmType, MusicData>>();
				_dlcMusicData = dlcMusicData;
			}
			bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)_dlcMusicData).TryInsert((System.Int32Enum)dlcType, value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	public void ClearConvertedDlcData()
	{
		Debug.Log("DataManager.ClearConvertedDLCData");
		_dlcCharacterData = null;
		_dlcStageData = null;
		_dlcWeaponData = null;
		_dlcEnemyData = null;
		_dlcPowerUpData = null;
		_dlcMusicData = null;
	}

	private void ClearConvertedData()
	{
		_characterData = null;
		_powerUpData = null;
		_stageData = null;
		_weaponData = null;
		_enemyData = null;
	}

	private void BuildConvertedData()
	{
		//IL_0064: Expected I, but got O
		if ((object)MarkerBuildConvertedData != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerBuildConvertedData);
		}
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = GetConvertedCharacterData();
		Dictionary<StageType, List<StageData>> convertedStages = GetConvertedStages();
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = GetConvertedWeapons();
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = GetConvertedEnemyData();
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = GetConvertedPowerUpData();
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	private unsafe static Dictionary<EnemyType, List<EnemyData>> ConvertEnemyDataJsonToObjects(Dictionary<EnemyType, JArray> enemyJson)
	{
		//IL_0128: Expected O, but got Ref
		Dictionary<EnemyType, List<EnemyData>> dictionary = new Dictionary<EnemyType, List<EnemyData>>();
		if (enemyJson == null)
		{
			throw new NullReferenceException();
		}
		Dictionary<EnemyType, JArray>.Enumerator enumerator = default(Dictionary<EnemyType, JArray>.Enumerator);
		JToken jToken = default(JToken);
		List<EnemyData>.Enumerator enumerator2 = default(List<EnemyData>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (jToken != null)
				{
					object obj = jToken.ToObject<object>();
					if (obj == null)
					{
						throw new NullReferenceException();
					}
					while (enumerator2.MoveNext())
					{
						CacheEnemyDataStrings(null);
					}
					bool flag = dictionary == null;
					List<EnemyData>.Enumerator enumerator3 = (List<EnemyData>.Enumerator)(&enumerator2);
					if (flag)
					{
						break;
					}
					bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, obj, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					continue;
				}
				throw new NullReferenceException();
			}
			return dictionary;
		}
		throw new NullReferenceException();
	}

	private static Dictionary<WeaponType, List<WeaponData>> ConvertWeaponDataJsonToObjects(Dictionary<WeaponType, JArray> weaponJson)
	{
		//IL_002b: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		Dictionary<WeaponType, List<WeaponData>> dictionary = new Dictionary<WeaponType, List<WeaponData>>();
		Dictionary<WeaponType, JArray>.Enumerator enumerator = default(Dictionary<WeaponType, JArray>.Enumerator);
		JToken jToken = default(JToken);
		while (enumerator.MoveNext())
		{
			bool flag = jToken == null;
			System.Int32Enum int32Enum = (System.Int32Enum)0;
			object obj = 2;
			if (!flag)
			{
				object obj2 = jToken.ToObject<object>();
				bool flag2 = dictionary == null;
				object obj3 = obj2;
				int32Enum = (System.Int32Enum)0;
				obj = 2;
				if (!flag2)
				{
					bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, obj2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					obj3 = obj2;
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return dictionary;
	}

	private static Dictionary<StageType, List<StageData>> ConvertStageDataJsonToObjects(Dictionary<StageType, JArray> jsonData)
	{
		//IL_002b: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		Dictionary<StageType, List<StageData>> dictionary = new Dictionary<StageType, List<StageData>>();
		Dictionary<StageType, JArray>.Enumerator enumerator = default(Dictionary<StageType, JArray>.Enumerator);
		JToken jToken = default(JToken);
		while (enumerator.MoveNext())
		{
			bool flag = jToken == null;
			System.Int32Enum int32Enum = (System.Int32Enum)0;
			object obj = 2;
			if (!flag)
			{
				object obj2 = jToken.ToObject<object>();
				bool flag2 = dictionary == null;
				object obj3 = obj2;
				int32Enum = (System.Int32Enum)0;
				obj = 2;
				if (!flag2)
				{
					bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, obj2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					obj3 = obj2;
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return dictionary;
	}

	private static Dictionary<CharacterType, List<CharacterData>> ConvertCharacterJsonDataToObjects(Dictionary<CharacterType, JArray> jsonData)
	{
		Dictionary<CharacterType, List<CharacterData>> result = new Dictionary<CharacterType, List<CharacterData>>();
		Dictionary<CharacterType, JArray>.Enumerator enumerator = default(Dictionary<CharacterType, JArray>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			JToken jToken = null;
			throw new NullReferenceException();
		}
		return result;
	}

	private static Dictionary<PowerUpType, List<PowerUpData>> ConvertPowerUpJsonData(Dictionary<PowerUpType, JArray> jsonData)
	{
		Dictionary<PowerUpType, List<PowerUpData>> result = new Dictionary<PowerUpType, List<PowerUpData>>();
		Dictionary<PowerUpType, JArray>.Enumerator enumerator = default(Dictionary<PowerUpType, JArray>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			JToken jToken = null;
			throw new NullReferenceException();
		}
		return result;
	}

	private static Dictionary<BgmType, List<MusicData>> ConvertMusicJsonDataToObjects(Dictionary<BgmType, JArray> jsonData)
	{
		Dictionary<BgmType, List<MusicData>> result = new Dictionary<BgmType, List<MusicData>>();
		Dictionary<BgmType, JArray>.Enumerator enumerator = default(Dictionary<BgmType, JArray>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			JToken jToken = null;
			throw new NullReferenceException();
		}
		return result;
	}

	private static void CacheEnemyDataStrings(EnemyData enemyData)
	{
		//IL_009e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_012c: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_01c7: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_034b: Expected O, but got I
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		List<string> list = enemyData._003CframeNames_003Ek__BackingField;
		List<string> internal_FrameNamesAnim = new List<string>(list._size);
		enemyData.Internal_FrameNamesAnim = internal_FrameNamesAnim;
		List<List<string>> internal_IdleAnimFrameNames = new List<List<string>>(list._size);
		enemyData.Internal_IdleAnimFrameNames = internal_IdleAnimFrameNames;
		List<List<string>> internal_DeathAnimFrameNames = new List<List<string>>(list._size);
		enemyData.Internal_DeathAnimFrameNames = internal_DeathAnimFrameNames;
		object obj = 0;
		object obj2 = 0;
		string text4 = default(string);
		while (true)
		{
			List<string> list2 = enemyData._003CframeNames_003Ek__BackingField;
			if ((nint)obj2 >= list2._size)
			{
				return;
			}
			if ((nint)obj >= list2._size)
			{
				break;
			}
			string[] items = list2._items;
			string text = items[obj].ToLowerInvariant();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v18+B8]");
			object newValue = 0;
			string text2 = text.Replace(".png", (string)newValue);
			List<string> list3 = enemyData._003CframeNames_003Ek__BackingField;
			if ((nint)obj >= list3._size)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			int version = list3._version + 1;
			list3._version = version;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v23+B8]");
			object newValue2 = 0;
			string text3 = text2.Replace("_0", (string)newValue2);
			List<object> internal_FrameNamesAnim2 = (List<object>)(object)enemyData.Internal_FrameNamesAnim;
			int version2 = internal_FrameNamesAnim2._version + 1;
			internal_FrameNamesAnim2._version = version2;
			object[] items2 = internal_FrameNamesAnim2._items;
			if (internal_FrameNamesAnim2._size >= items2.Length)
			{
				internal_FrameNamesAnim2.AddWithResize((object)text3);
			}
			else
			{
				int size = internal_FrameNamesAnim2._size + 1;
				internal_FrameNamesAnim2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<object> internal_IdleAnimFrameNames2 = (List<object>)(object)enemyData.Internal_IdleAnimFrameNames;
			string prefix = text3 + "_i";
			List<string> list4 = SpriteManager.GenerateFrameNames(1, enemyData._003CidleFrameCount_003Ek__BackingField, 2, prefix);
			int version3 = internal_IdleAnimFrameNames2._version + 1;
			internal_IdleAnimFrameNames2._version = version3;
			object[] items3 = internal_IdleAnimFrameNames2._items;
			if (internal_IdleAnimFrameNames2._size >= items3.Length)
			{
				internal_IdleAnimFrameNames2.AddWithResize((object)list4);
				List<string> list5 = (List<string>)0;
			}
			else
			{
				int size2 = internal_IdleAnimFrameNames2._size + 1;
				internal_IdleAnimFrameNames2._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				List<string> list5 = list4;
			}
			List<string> list6 = enemyData._003CframeNames_003Ek__BackingField;
			if (list6._size == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if (!text4.Contains("_0"))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
					obj++;
					obj2 = obj;
					continue;
				}
			}
			string prefix2 = text3 + "_";
			List<string> list7 = SpriteManager.GenerateFrameNames(0, enemyData._003Cend_003Ek__BackingField, 0, prefix2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AEC0");
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void AdjustAchievementDataWithTypes()
	{
		Dictionary<AchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AchievementType, AchievementData>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			if (obj != null)
			{
				_ = 0;
			}
		}
	}

	private void AdjustAdventureProgressDataWithTypes()
	{
		//IL_0016: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		List<AchievementData>.Enumerator enumerator = (List<AchievementData>.Enumerator)0;
		Dictionary<AdventureType, AdventureData>.Enumerator enumerator2 = default(Dictionary<AdventureType, AdventureData>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj = 0;
		}
	}

	private unsafe void GenerateBestiaryDataForAdventure(AdventureData adventureData)
	{
		//IL_004f: Expected O, but got I
		//IL_0975: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_01cc: Expected O, but got I4
		//IL_01e9: Expected O, but got Ref
		//IL_0209: Expected O, but got Ref
		//IL_0588: Expected O, but got I
		//IL_0765: Expected O, but got I
		//IL_05ff: Expected O, but got I
		//IL_08fe: Expected I, but got O
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Expected O, but got Unknown
		//IL_0639: Expected O, but got I
		//IL_06a2: Expected I4, but got O
		Dictionary<StageType, List<StageData>>.KeyCollection keys = _adventureStageData.Keys;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rbx_v30 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			IntPtr intPtr = default(IntPtr);
			bool flag = ((Dictionary<StageType, List<StageData>>)0).TryGetValue(StageType.FOREST, out *(List<StageData>*)intPtr);
		}
		List<System.Int32Enum> list2;
		Dictionary<EnemyType, List<EnemyData>> dictionary4;
		int num3;
		int num4;
		if (keys != null)
		{
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys);
			Dictionary<StageType, List<StageData>> dictionary = new Dictionary<StageType, List<StageData>>();
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ stack_-108_v31+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ stack_-108_v31+18]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ stack_-108_v31+10]");
							object obj5 = 0;
							object obj6 = obj4 + 1;
							Dictionary<StageType, List<StageData>> stageData = _stageData;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rdx_v89+20+v374 @ stack_-100_v30*4]");
							bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)stageData).TryGetValue((System.Int32Enum)0, out object value);
							bool flag3 = !flag2;
							obj4 = obj6;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rdx_v89+20+v1689 @ rcx_v129*4]");
								bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								obj4 = obj6;
							}
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag5 = obj == null;
			Dictionary<StageType, List<StageData>> dictionary2 = (Dictionary<StageType, List<StageData>>)0;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ stack_-108_v31+1C]");
				if (obj2 == null)
				{
					List<EnemyType> source = new List<EnemyType>();
					nint num2 = 0;
					List<EnemyType?>.Enumerator enumerator = (List<EnemyType?>.Enumerator)0;
					Dictionary<StageType, List<StageData>>.Enumerator enumerator2 = default(Dictionary<StageType, List<StageData>>.Enumerator);
					IntPtr intPtr2 = default(IntPtr);
					List<StageData>.Enumerator enumerator4 = default(List<StageData>.Enumerator);
					while (enumerator2.MoveNext())
					{
						bool flag6 = intPtr2 == (IntPtr)0;
						List<EnemyType?>.Enumerator enumerator3 = (List<EnemyType?>.Enumerator)(&enumerator2);
						if (flag6)
						{
							throw new NullReferenceException();
						}
						if (enumerator4.MoveNext())
						{
							Dictionary<StageType, List<StageData>> dictionary3 = null;
							enumerator3 = (List<EnemyType?>.Enumerator)(&enumerator4);
							throw new NullReferenceException();
						}
					}
					IEnumerable<EnemyType> enumerable = Enumerable.Distinct(source);
					if (enumerable != null)
					{
						list2 = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
						if (adventureData._003CExtraBestiaryTypes_003Ek__BackingField != null)
						{
							IEnumerable<System.Int32Enum> collection = (IEnumerable<System.Int32Enum>)adventureData._003CExtraBestiaryTypes_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v149 (System.Collections.Generic.IEnumerable`1<System.Int32Enum>)+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2760 @ rax_v101 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
								list2.InsertRange(0, collection);
								Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = GetConvertedEnemyData();
								dictionary4 = convertedEnemyData;
								num3 = 0;
								num4 = 0;
								goto IL_0ab5;
							}
						}
						Dictionary<EnemyType, List<EnemyData>> convertedEnemyData2 = GetConvertedEnemyData();
						dictionary4 = convertedEnemyData2;
						num3 = 0;
						num4 = 0;
						goto IL_0ab5;
					}
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				dictionary2 = null;
			}
			throw new NullReferenceException();
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
		IL_0ab5:
		EnemyType value3 = default(EnemyType);
		object obj10 = default(object);
		object obj11 = default(object);
		object obj13 = default(object);
		while (true)
		{
			int num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2760 @ rax_v101 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			if ((nint)num5 < (nint)0)
			{
				int num6 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2760 @ rax_v101 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				if ((nint)num6 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2760 @ rax_v101 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				object obj7 = 0;
				Dictionary<EnemyType, List<EnemyData>> dictionary5 = dictionary4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v89+20+v206 @ rbx_v34 (System.Int32)*4]");
				bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary5).TryGetValue((System.Int32Enum)0, out object value2);
				if (value2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ stack_-E0_v32 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ stack_-E0_v32 (System.Object)+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v93+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v93+20]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3471 @ rcx_v94+148]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v89+20+v206 @ rbx_v34 (System.Int32)*4]");
							EnemyType? enemyType = FindEnemyBaseVariant(EnemyType.BAT1);
							if ((object)enemyType != null)
							{
								EnemyType key = (EnemyType)((object?)enemyType >> 32);
								if (!((Dictionary<EnemyType, List<EnemyData>>)(object)list2).TryGetValue(key, out *(List<EnemyData>*)null))
								{
									((List<EnemyType>)(object)list2).set_Item(num3, value3);
								}
							}
						}
					}
				}
				num3++;
				num4 = num3;
				continue;
			}
			Dictionary<EnemyType, JArray> dictionary6 = new Dictionary<EnemyType, JArray>();
			while (true)
			{
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ stack_-120_v12+1C]");
					if (obj11 == null)
					{
						object obj12 = obj13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ stack_-120_v12+18]");
						if ((nint)obj12 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ stack_-120_v12+10]");
							object obj14 = 0;
							object obj15 = obj13 + 1;
							Dictionary<EnemyType, JArray> dictionary7 = _003CAllEnemies_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2564 @ rdx_v57+20+v2514 @ stack_-118_v10*4]");
							bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary7).TryGetValue((System.Int32Enum)0, out object value4);
							bool flag9 = !flag8;
							obj13 = obj15;
							if (!flag9)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2564 @ rdx_v57+20+v3567 @ rcx_v81*4]");
								bool flag10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary6).TryInsert((System.Int32Enum)0, value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								obj13 = obj15;
							}
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag11 = obj10 == null;
			nint num7 = 0;
			if (!flag11)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ stack_-120_v12+1C]");
				if (obj11 == null)
				{
					Dictionary<EnemyType, List<EnemyData>> adventureBestiaryData = ConvertEnemyDataJsonToObjects(dictionary6);
					_adventureBestiaryData = adventureBestiaryData;
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				num7 = unchecked((nint)null);
			}
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private EnemyType? FindEnemyBaseVariant(EnemyType enemyType)
	{
		//IL_01f2: Expected O, but got I4
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = GetConvertedEnemyData();
		DataManager dataManager = null;
		Dictionary<EnemyType, List<EnemyData>> dictionary = convertedEnemyData;
		Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator = default(Dictionary<EnemyType, List<EnemyData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			DataManager dataManager2 = null;
			DataManager dataManager3 = null;
			throw new NullReferenceException();
		}
		return (EnemyType?)(object)0;
	}

	public DataManager()
	{
		Dictionary<CharacterType, List<CharacterData>> adventureCharacterData = new Dictionary<CharacterType, List<CharacterData>>();
		_adventureCharacterData = adventureCharacterData;
		Dictionary<StageType, List<StageData>> adventureStageData = new Dictionary<StageType, List<StageData>>();
		_adventureStageData = adventureStageData;
		Dictionary<EnemyType, List<EnemyData>> adventureBestiaryData = new Dictionary<EnemyType, List<EnemyData>>();
		_adventureBestiaryData = adventureBestiaryData;
		Dictionary<CharacterType, CustomMerchantData> adventureMerchantsData = new Dictionary<CharacterType, CustomMerchantData>();
		_adventureMerchantsData = adventureMerchantsData;
		Dictionary<DlcType, List<AchievementType>> dictionary = new Dictionary<DlcType, List<AchievementType>>();
		_003CAllDlcAchievements_003Ek__BackingField = dictionary;
	}

	static DataManager()
	{
		//IL_005b: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_000e: Expected O, but got I
		//IL_0034: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("DataManager.ReloadAllData", 1, MarkerFlags.Default, 0);
		MarkerReloadAllData = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("DataManager.LoadDataFromJson", 1, MarkerFlags.Default, 0);
		MarkerLoadDataFromJson = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("DataManager.BuildConvertedData", 1, MarkerFlags.Default, 0);
		MarkerBuildConvertedData = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("DataManager.LoadBaseJObjects", 1, MarkerFlags.Default, 0);
		MarkerLoadBaseJObjects = (ProfilerMarker)(nint)intPtr4;
	}
}
