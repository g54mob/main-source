using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.DevConsole;
using NSMedieval.GameEventSystem;
using NSMedieval.InfoMessages;
using NSMedieval.Manager.RaidPointsFactors;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.Research;
using NSMedieval.Resources;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Tools;
using NSMedieval.Weather;
using Raid.Config;
using Repository;
using Repository.Map;
using UnityEngine;

namespace NSMedieval.Repository
{
	[Serializable]
	public class RepositoryManager : MonoSingleton<RepositoryManager>
	{
		private readonly Dictionary<string, Action<string>> addRepoActions = new Dictionary<string, Action<string>>();

		private readonly Dictionary<string, Action<string>> removeRepoActions = new Dictionary<string, Action<string>>();

		private readonly Dictionary<string, Action<string>> updateRepoActions = new Dictionary<string, Action<string>>();

		public Action OnRefreshRepoAction;

		private bool initialized;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private new static void OnDomainReload()
		{
			if (MonoSingleton<RepositoryManager>.IsInstantiated())
			{
				RepositoryManager repositoryManager = MonoSingleton<RepositoryManager>.Instance;
				repositoryManager.addRepoActions.Clear();
				repositoryManager.removeRepoActions.Clear();
				repositoryManager.updateRepoActions.Clear();
				repositoryManager.initialized = false;
				repositoryManager.OnRefreshRepoAction = null;
			}
		}

		public void RefreshRepositories()
		{
			OnRefreshRepoAction?.Invoke();
		}

		public void RegisterRepoActions(string jsonFile, Action<string> addAction, Action<string> removeAction, Action<string> updateAction)
		{
			addRepoActions.TryAdd(jsonFile, addAction);
			removeRepoActions.TryAdd(jsonFile, removeAction);
			updateRepoActions.TryAdd(jsonFile, updateAction);
		}

		public void AddRepository(string jsonFile, string jsonPath)
		{
			if (!addRepoActions.TryGetValue(jsonFile, out var value))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\RepositoryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No Add action registered for ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(jsonFile));
				}
				Log.Error(messageBuilder);
			}
			else
			{
				value?.Invoke(jsonPath);
			}
		}

		public void UpdateRepository(string jsonFile, string jsonPath)
		{
			if (!updateRepoActions.TryGetValue(jsonFile, out var value))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\RepositoryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No Update action registered for ");
					messageBuilder.AppendFormatted(jsonFile);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				value?.Invoke(jsonPath);
			}
		}

		public void RemoveRepository(string jsonFile, string jsonPath)
		{
			if (!removeRepoActions.TryGetValue(jsonFile, out var value))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\RepositoryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No Remove action registered for ");
					messageBuilder.AppendFormatted(jsonFile);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				value?.Invoke(jsonPath);
			}
		}

		public T GetRepository<T>() where T : MonoBehaviour
		{
			T componentInChildren = GetComponentInChildren<T>();
			if (componentInChildren != null)
			{
				return componentInChildren;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\RepositoryManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating new repository of type ");
				messageBuilder.AppendFormatted(typeof(T).Name);
			}
			Log.Debug(messageBuilder);
			GameObject obj = new GameObject("RepositoryManager created: " + typeof(T).Name);
			obj.transform.parent = base.transform;
			return obj.AddComponent<T>();
		}

		public bool IsInitialized()
		{
			return initialized;
		}

		public void Initialize()
		{
			_ = MonoRepository<SpriteRepository, KeySpritePair>.Instance;
			_ = MonoRepository<SpriteAssetRepository, KeySpriteAssetPair>.Instance;
			_ = MonoRepository<TextureRepository, KeyTexturePair>.Instance;
			_ = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance;
			_ = MonoRepository<MeshRepository, KeyGameObjectPair>.Instance;
			if (!Repository<DefaultPlayerControlsData, DefaultPlayerControls>.IsInstantiated())
			{
				new DefaultPlayerControlsData();
			}
			new GameSettingsData();
			new AchievementSettingsData();
			new BattleScalesSettingsData();
			new RaidSpawnSettingsData();
			new SiegePathfinderSettingsData();
			new MapPlaceSettingsData();
			new CaravanAmbushSettingsData();
			new LeaveMapOutcomeSettingsData();
			new GameplayCameraSettingsData();
			new PhotoCameraSettingsData();
			new StructurePresetCameraSettingsData();
			new BaseWealthEffectorsData();
			new DaysFromStartMultipliersRepository();
			new BuildingWealthMultipliersData();
			new PilesWealthMultipliersData();
			new WorkerCountMultipliersData();
			new DaysFromVillagerKilledMultipliersData();
			new RaidMaxPrisonersBySettlersAliveData();
			new RaidSurrenderChanceBySettlersAliveData();
			new ReleasePrisonersFriendlinessBuffByMoodData();
			new RaidSurrenderChanceByPrisonersCountData();
			new MerchantLimitPrisonersByPrisonerCountData();
			new MerchantLimitPrisonersByWorkerCountData();
			new CropBlightSpotsByRaidPointsData();
			new SnowMeltSpeedData();
			new RoomImpWealthMultipliersData();
			new RoomImpSpaceMultipliersData();
			new RoomImpBeautyMultipliersData();
			new DateTimeSettingsData();
			new FactionGameModeSettingsData();
			new FactionRelationsData();
			new FireSettingsData();
			new GridDataTypeAttackTraversePenaltyData();
			new ResourceSettingsData();
			new RoomImpressivenessSettingsData();
			new TemperatureSettingsData();
			new TradingSettingsData();
			new WardenRoleSettingsData();
			new WorldMapSettingsData();
			new XpDecaySettingsData();
			new SiegeWeaponSettingsData();
			new GlobalStatRepository();
			new ObjectiveRepository();
			new WeatherEventRepository();
			new UniversalStorageRepository();
			new GameplayTipsScheduleRepository();
			new DifficultyOptionsRepository();
			new RoomTypeRepository();
			new StartingEventsRepository();
			new DayTimeDebugConfigRepository();
			new SeasonDebugConfigRepository();
			ConstructableQualitySettingsRepository constructableQualitySettingsRepository = new ConstructableQualitySettingsRepository();
			new StabilityRepository();
			new ThermalModelRepository();
			new AdditionalMenuRepository();
			new AnimatedAgentDataRepository();
			new JobPriorityRepository();
			new JobRepository();
			new ObjectActionDataRepository();
			new ActionInfoDataRepository();
			new ReligionRepository();
			new PlantShapeRepository();
			new GenerationSettingsRepository();
			new StatRepository();
			new BackgroundRepository();
			new BackStoryRepository();
			new NPCCustomWarningMessageRepository();
			new BuildingEventPropsRepository();
			new CombatLogDataRepository();
			new ConversationLogDataRepository();
			new ConversationTopicRepository();
			new EventInteractionDataRepository();
			new HealthLogDataRepository();
			new LifeEventLogRepository();
			new SocialCompatibilitySettingsRepository();
			new MapPropTypeRepository();
			new MapRepository();
			new SlopeRepository();
			new VoxelTypeRepository();
			new AttributeRepository();
			new AttributesListRepository();
			new EffectorRepository();
			new StatsModelRepository();
			new WoundsRepository();
			new ResourceGroupsRepository();
			new StockpileRepository();
			new CropfieldRepository();
			new ResearchRepository();
			new ManageGroupRepository();
			new BeamComponentRepository();
			new BedComponentRepository();
			new CaravanPostComponentRepository();
			new ChairComponentRepository();
			new DecorationComponentRepository();
			new DoorComponentRepository();
			new EntertainmentComponentRepository();
			new FuelConsumerComponentRepository();
			new GallowsComponentRepository();
			new GraveComponentRepository();
			new LadderComponentRepository();
			new MapTableComponentRepository();
			new PenMarkerComponentRepository();
			new RallyPointMarkerComponentRepository();
			new ProductionComponentsRepository();
			new RoofComponentRepository();
			new RugComponentRepository();
			new ShelfComponentRepository();
			new ShrineComponentRepository();
			new SignComponentRepository();
			new SlopeBuildingComponentRepository();
			new StairsComponentRepository();
			new TableComponentRepository();
			new TradingPostComponentRepository();
			new TrapComponentRepository();
			new VoxelBuildingComponentRepository();
			new WindowComponentRepository();
			new WellComponentRepository();
			new SiegeWeaponComponentRepository();
			new SiegeWeaponProjectileRepository();
			new OilBlobComponentRepository();
			new AnimalProductionRepository();
			new AnimalAttackGroupRepository();
			new AnimalBaseRepository();
			new CombatAiAgentRepository();
			new DamageTakingAgentSettingsRepository();
			new DietModelRepository();
			new HumanAppearanceRepository();
			new HumanTypeRepository();
			new NPCPresetRepository();
			new NPCRepository();
			new EventGroupRepository();
			new FactionRepository();
			new FactionTypeRepository();
			new GameEventSettingsRepository();
			new DecayIconSettingsRepository();
			new GoalPreferenceLevelRepository();
			new GoalPreferenceRepository();
			new ScheduleConfigRepository();
			new ScheduleModelRepository();
			new HitEffectorGroupRepository();
			new WeaponTypeSettingsRepository();
			new MapSizeRepository();
			new PathfindingPenaltyRepository();
			new PlayerTriggeredEventRepository();
			new DecayModifiersRepository();
			new DigMarkerResourceRepository();
			new FishMapResourceRepository();
			new PlantMapResourceRepository();
			new ProductionRepository();
			new ProductQualityChanceRepository();
			new RoleRepository();
			new TraderStockModifierRepository();
			new TraderStockRepository();
			new TraderTypeRepository();
			new TrebuchetRepository();
			new VillageNameRepository();
			new WalkableModelRepository();
			new WalkSpeedMultiplierRepository();
			new AnimalNameRepository();
			new NameRepository();
			new PseudonymRepository();
			new WorkerBaseRepository();
			new WorkerPresetRepository();
			new PerkRepository();
			new SkillLevelsRepository();
			new SkillTagRepository();
			new ScenarioRepository();
			new BellComponentRepository();
			new MaterialSettingsRepository();
			new ArmorQualitySettingsRepository();
			new GarmentQualitySettingsRepository();
			new WeaponQualitySettingsRepository();
			ResourceRepository resourceRepository = new ResourceRepository();
			new EquipmentRepository(resourceRepository);
			new BaseBuildingRepository(resourceRepository, constructableQualitySettingsRepository);
			new LinkRepository();
			new CharacterPresetRepository();
			new ManageGroupPresetRepository();
			new SecondMapSaveRepository();
			new SecondMapLootConfigRepository();
			new TwitchEventsRepository();
			initialized = true;
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnLeavingHome;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			OnRefreshRepoAction = null;
		}

		private void OnLeavingHome()
		{
			if (!Repository<AlmanacRepository, NSMedieval.Almanac.Almanac>.IsInstantiated())
			{
				new AlmanacRepository();
			}
			if (!Repository<AlmanacEntriesRepository, AlmanacEntry>.IsInstantiated())
			{
				new AlmanacEntriesRepository();
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnLeavingHome;
			}
		}
	}
}
