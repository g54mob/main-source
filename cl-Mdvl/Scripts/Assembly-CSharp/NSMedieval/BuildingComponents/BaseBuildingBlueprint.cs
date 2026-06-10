using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components.Base;
using NSMedieval.Construction;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.OcclusionCulling;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class BaseBuildingBlueprint : NSEipix.Base.Model
	{
		private const string DefaultMeshVariationName = "default";

		[SerializeField]
		private string id;

		[SerializeField]
		private bool hasDestructionAnimation;

		[SerializeField]
		private int buildTime;

		[SerializeField]
		private float installationMultiplier;

		[SerializeField]
		private int minBuildSkillRequired;

		[SerializeField]
		private Vec3Int size;

		[SerializeField]
		private StringIntDictionary materials = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();

		[SerializeField]
		private StringKeyPair returnOnDestroy = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();

		[SerializeField]
		private StringKeyPair returnOnDeconstruct = SerializableDictionary<string, float>.CreateNew<StringKeyPair>();

		[SerializeField]
		private StorageBase storageBase;

		[SerializeField]
		private BuildingType buildingType;

		[SerializeField]
		private BuildingCategoryUI buildingCategoryUI;

		[SerializeField]
		private BuildingSubCategoryUI buildingSubCategoryUI;

		[SerializeField]
		private SoundMaterialCategory soundMaterialCategory;

		[SerializeField]
		private ConstructableBaseCategory constructableBaseCategory;

		[SerializeField]
		private BuildingType replacementFlag;

		[SerializeField]
		private ReachableLevel reachableLevel;

		[SerializeField]
		private bool canHaveOwner;

		[SerializeField]
		private PlacementType placementType;

		[SerializeField]
		private PlacementCheck placementCheck;

		[SerializeField]
		private string groupIdentifier;

		[SerializeField]
		private int maxPoolCount;

		[SerializeField]
		private int refillThreshold;

		[SerializeField]
		private bool placeableBellowOthers;

		[SerializeField]
		private float layerHideOffset;

		[SerializeField]
		private float layerShadowOffset;

		[SerializeField]
		private bool forbidUnderBeamPlacement;

		[SerializeField]
		private ushort pathfindingPenalty = ushort.MaxValue;

		[SerializeField]
		private ushort pathfindingPenaltyConstruction = 4000;

		[SerializeField]
		private ushort pathfindingPenaltyAlwaysOpen = 2000;

		[SerializeField]
		private float walkSpeedMultiplier = 0.25f;

		[SerializeField]
		private float walkSpeedMultiplierConstruction = 0.6f;

		[SerializeField]
		private float walkSpeedMultiplierAlwaysOpen = 0.9f;

		[SerializeField]
		private bool passThroughDestroyable;

		[SerializeField]
		private float attackTraversePenalty;

		[SerializeField]
		private Stat[] stats;

		[SerializeField]
		private float cover;

		[SerializeField]
		private float coverClosed;

		[SerializeField]
		private bool passthroughFloor;

		[SerializeField]
		private bool waterFlowThroughFloor;

		[SerializeField]
		private bool hasQuality;

		[SerializeField]
		private bool passivePredatorProtection;

		[SerializeField]
		private float coverIgnore;

		[SerializeField]
		private float wealthPoints;

		[SerializeField]
		private bool ignorePileRelocation;

		[SerializeField]
		private bool canPlaceOnBeam;

		[SerializeField]
		private bool canPlaceOnWater;

		[SerializeField]
		private List<string> almanacTags;

		[SerializeField]
		private string destroyParticles;

		[SerializeField]
		private bool canBeMoved;

		[SerializeField]
		private bool spawnStructurePileOnStabilityLoss;

		private ConstructionParameters constructionParameters;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private string iconColorOverlay;

		[SerializeField]
		private string prefabID;

		[SerializeField]
		private string previewPrefabID;

		[SerializeField]
		private bool isRegionBridge;

		[SerializeField]
		private float beautyInput;

		[SerializeField]
		private bool beautyBlocker;

		[NonSerialized]
		private ThermalModel defaultThermalModel;

		[SerializeField]
		private string defaultThermalModelID;

		[SerializeField]
		private string sortingGroup;

		[SerializeField]
		private bool floorDecoration;

		[SerializeField]
		private string protoId;

		[SerializeField]
		private bool idleTargetForbidden;

		[SerializeField]
		private SoundWalkableMaterialCategory soundWalkableMaterialCategory;

		[SerializeField]
		private List<string> defaultVariations;

		[SerializeField]
		private List<MeshVariationList> variationLists;

		[SerializeField]
		private string lightCookieId;

		[SerializeField]
		private bool useShadowCasters;

		[SerializeField]
		private bool useLOD;

		[SerializeField]
		private TransformSettings[] transformSettingsArray;

		[SerializeField]
		private HashSet<MeshVariationList> variationsSet;

		[SerializeField]
		private string pilePrefabID;

		[SerializeField]
		private List<MeshVariationList> pileVariationLists;

		[SerializeField]
		private string decomposeModifiersId;

		[SerializeField]
		private float weight;

		[SerializeField]
		private bool meshVariationCanRotate;

		[SerializeField]
		private bool meshVariationCanRotate180;

		[SerializeField]
		private bool meshVariationCanFlipX;

		[SerializeField]
		private bool meshVariationCanFlipZ;

		[SerializeField]
		private bool hideAutomaticMeshCheckbox;

		[SerializeField]
		private ForbiddenAreaInfo forbiddenAreaInfo;

		[SerializeField]
		private BoxColliderSettings boxColliderSettings;

		[SerializeField]
		private TransformSettings[] workPositionsArray;

		[SerializeField]
		private string voxelTypeID;

		[SerializeField]
		private ProductQuality quality;

		[SerializeField]
		private OcclusionCullingMode occlusionCullingMode;

		[SerializeField]
		private float occlusionCullingBoundingBoxHeightModifier = 1f;

		[SerializeField]
		private string beamComponentID;

		[SerializeField]
		private string bedComponentID;

		[SerializeField]
		private string caravanPostComponentID;

		[SerializeField]
		private string chairComponentID;

		[SerializeField]
		private string decorationComponentID;

		[SerializeField]
		private string doorComponentID;

		[SerializeField]
		private string gateComponentID;

		[SerializeField]
		private string entertainmentComponentID;

		[SerializeField]
		private string fuelConsumerComponentID;

		[SerializeField]
		private string graveComponentID;

		[SerializeField]
		private string ladderComponentID;

		[SerializeField]
		private string mapTableComponentID;

		[SerializeField]
		private string penMarkerComponentID;

		[SerializeField]
		private string rallyPointMarkerComponentID;

		[SerializeField]
		private string productionComponentID;

		[SerializeField]
		private string roofComponentID;

		[SerializeField]
		private string rugComponentID;

		[SerializeField]
		private string shelfComponentID;

		[SerializeField]
		private string shrineComponentID;

		[SerializeField]
		private string signComponentID;

		[SerializeField]
		private string stairComponentID;

		[SerializeField]
		private string tableComponentID;

		[SerializeField]
		private string tradingPostComponentID;

		[SerializeField]
		private string gallowsComponentID;

		[SerializeField]
		private string trapComponentID;

		[SerializeField]
		private string windowComponentID;

		[SerializeField]
		private string voxelComponentID;

		[SerializeField]
		private string buildAnimationTrigger;

		[SerializeField]
		private string buildItem;

		[SerializeField]
		private string slopeComponentID;

		[SerializeField]
		private string wellComponentID;

		[SerializeField]
		private string oilBlobComponentID;

		[SerializeField]
		private string siegeWeaponComponentID;

		[SerializeField]
		private string bellComponentID;

		[SerializeField]
		private float spawnFireOnDestroy;

		[SerializeField]
		private bool isVerticalFireBlocker;

		[SerializeField]
		private float flammability = 0.75f;

		[SerializeField]
		private float heatDamageThreshold;

		[SerializeField]
		private float heatDamage;

		[NonSerialized]
		private bool variationsSetInit;

		[SerializeField]
		private bool cantFailConstruction;

		[SerializeField]
		private string eventPropsId;

		[SerializeField]
		private string meshColliderMeshId;

		[SerializeField]
		private string previewMarkerPrefabId;

		[SerializeField]
		private TransformSettings previewMarkerOffset;

		[SerializeField]
		private bool isArt;

		[FormerlySerializedAs("colliderSettingsOverride")]
		[SerializeField]
		private BoxColliderSettings combatBoxColliderSettings;

		private string defaultMeshId;

		[NonSerialized]
		private List<string> playerTriggeredEvents;

		private Bounds occlusionBoundingBox;

		[NonSerialized]
		private Dictionary<string, MeshVariation> meshVariationsByName;

		[NonSerialized]
		private bool showVariationsInit;

		[NonSerialized]
		private bool showVariations;

		public OcclusionCullingMode OcclusionCullingMode
		{
			get
			{
				return occlusionCullingMode;
			}
			set
			{
				occlusionCullingMode = value;
			}
		}

		public ForbiddenAreaInfo ForbiddenAreaInfo => forbiddenAreaInfo;

		public string BeamComponentID => beamComponentID ?? string.Empty;

		public string BedComponentID => bedComponentID ?? string.Empty;

		public string CaravanPostComponentID => caravanPostComponentID ?? string.Empty;

		public string ChairComponentID => chairComponentID ?? string.Empty;

		public string DecorationComponentID => decorationComponentID ?? string.Empty;

		public string DoorComponentID => doorComponentID ?? string.Empty;

		public string GateComponentID => gateComponentID ?? string.Empty;

		public string EntertainmentComponentID => entertainmentComponentID ?? string.Empty;

		public string FuelConsumerComponentID => fuelConsumerComponentID ?? string.Empty;

		public string GraveComponentID => graveComponentID ?? string.Empty;

		public string LadderComponentID => ladderComponentID ?? string.Empty;

		public string MapTableComponentID => mapTableComponentID ?? string.Empty;

		public string PenMarkerComponentID => penMarkerComponentID ?? string.Empty;

		public string RallyPointMarkerComponentID => rallyPointMarkerComponentID ?? string.Empty;

		public string ProductionComponentID => productionComponentID ?? string.Empty;

		public string RoofComponentID => roofComponentID ?? string.Empty;

		public string RugComponentID => rugComponentID ?? string.Empty;

		public string ShelfComponentID => shelfComponentID ?? string.Empty;

		public string ShrineComponentID => shrineComponentID ?? string.Empty;

		public string SignComponentID => signComponentID ?? string.Empty;

		public string StairComponentID => stairComponentID ?? string.Empty;

		public string TableComponentID => tableComponentID ?? string.Empty;

		public string TradingPostComponentID => tradingPostComponentID ?? string.Empty;

		public string GallowsComponentID => gallowsComponentID ?? string.Empty;

		public string TrapComponentID => trapComponentID ?? string.Empty;

		public string WindowComponentID => windowComponentID ?? string.Empty;

		public string VoxelComponentID => voxelComponentID ?? string.Empty;

		public string BuildAnimationTrigger => buildAnimationTrigger ?? string.Empty;

		public string BuildItem => buildItem ?? string.Empty;

		public string SlopeComponentID => slopeComponentID ?? string.Empty;

		public string WellComponentID => wellComponentID ?? string.Empty;

		public string OilBlobComponentID => oilBlobComponentID ?? string.Empty;

		public string SiegeWeaponComponentID => siegeWeaponComponentID ?? string.Empty;

		public string BellComponentID => bellComponentID ?? string.Empty;

		public float SpawnFireOnDestroy => spawnFireOnDestroy;

		public bool IsVerticalFireBlocker => isVerticalFireBlocker;

		public bool CanHaveOwner => canHaveOwner;

		public string VoxelTypeID => voxelTypeID;

		public float Cover => cover;

		public float CoverClosed => coverClosed;

		public float CoverIgnore => coverIgnore;

		public bool HasDestructionAnimation => hasDestructionAnimation;

		public int BuildTime => buildTime;

		public float InstallationMultiplier => installationMultiplier;

		public int MinBuildSkillRequired => minBuildSkillRequired;

		public float AttackTraversePenalty => attackTraversePenalty;

		public Vec3Int Size => size;

		public StringIntDictionary Materials => materials;

		public StringKeyPair ReturnOnDestroy => returnOnDestroy;

		public StringKeyPair ReturnOnDeconstruct => returnOnDeconstruct;

		public StorageBase StorageBase => storageBase;

		public BuildingType BuildingType => buildingType;

		public BuildingCategoryUI BuildingCategoryUI => buildingCategoryUI;

		public BuildingSubCategoryUI BuildingSubCategoryUI => buildingSubCategoryUI;

		public SoundMaterialCategory SoundMaterialCategory => soundMaterialCategory;

		public ConstructableBaseCategory ConstructableBaseCategory => constructableBaseCategory;

		public BuildingType ReplacementFlag => replacementFlag;

		public PlacementType PlacementType => placementType;

		public PlacementCheck PlacementCheck => placementCheck;

		public bool FloorDecoration => floorDecoration;

		public int MaxPoolCount => maxPoolCount;

		public int RefillThreshold => refillThreshold;

		public bool Poolable => maxPoolCount > 0;

		public bool PlaceableBellowOthers => placeableBellowOthers;

		public float LayerHideOffset => layerHideOffset;

		public float LayerShadowOffset => layerShadowOffset;

		public bool ForbidUnderBeamPlacement => forbidUnderBeamPlacement;

		public bool PassivePredatorProtection => passivePredatorProtection;

		public ushort PathfindingPenaltyConstruction => pathfindingPenaltyConstruction;

		public ushort PathfindingPenalty => pathfindingPenalty;

		public float WalkSpeedMultiplierConstruction => walkSpeedMultiplierConstruction;

		public float WalkSpeedMultiplier => walkSpeedMultiplier;

		public ThermalModel DefaultThermalModel
		{
			get
			{
				if (defaultThermalModelID == null)
				{
					return null;
				}
				if (defaultThermalModel == null)
				{
					defaultThermalModel = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(defaultThermalModelID);
				}
				return defaultThermalModel;
			}
		}

		public bool Socketable => placementType.Equals(PlacementType.WallSocket);

		public bool IgnorePileRelocation => ignorePileRelocation;

		public bool CanBeMoved => canBeMoved;

		public bool SpawnStructurePileOnStabilityLoss => spawnStructurePileOnStabilityLoss;

		public bool PassthroughFloor => passthroughFloor;

		public bool WaterFlowThroughFloor => waterFlowThroughFloor;

		public bool HasQuality => hasQuality;

		public List<string> DefaultVariations => defaultVariations;

		public string PilePrefabID
		{
			get
			{
				if (!string.IsNullOrEmpty(pilePrefabID))
				{
					return pilePrefabID;
				}
				return "default_building_pile";
			}
		}

		public string DecomposeModifiersId => decomposeModifiersId;

		public float Weight => weight;

		public ProductQuality Quality
		{
			get
			{
				return quality;
			}
			set
			{
				quality = value;
			}
		}

		public Bounds OcclusionBoundingBox
		{
			get
			{
				if (occlusionBoundingBox == default(Bounds))
				{
					occlusionBoundingBox = new Bounds(boxColliderSettings.CenterOffset, boxColliderSettings.SizeOffset);
				}
				return occlusionBoundingBox;
			}
		}

		public ConstructionParameters ConstructionParameters => constructionParameters ?? (constructionParameters = new ConstructionParameters(buildTime, AttributeType.ConstructionSpeed, AttributeType.ConstructionFail, SkillType.Construction, 10f, string.Empty));

		public bool ShouldTriggerFenceMeshUpdate
		{
			get
			{
				BuildingType buildingType = this.buildingType;
				return buildingType == BuildingType.Fence || buildingType == BuildingType.FenceGate || buildingType == BuildingType.BarnDoor || buildingType == BuildingType.Wall || buildingType == BuildingType.Door;
			}
		}

		private Dictionary<string, MeshVariation> MeshVariationsByName
		{
			get
			{
				if (meshVariationsByName == null)
				{
					meshVariationsByName = new Dictionary<string, MeshVariation>();
					foreach (MeshVariationList variationList in variationLists)
					{
						foreach (MeshVariation variation in variationList.Variations)
						{
							meshVariationsByName.Add(variation.Name, variation);
						}
					}
				}
				return meshVariationsByName;
			}
		}

		public float WealthPoints
		{
			get
			{
				return wealthPoints;
			}
			protected set
			{
				wealthPoints = value;
			}
		}

		public Stat[] Stats
		{
			get
			{
				return stats;
			}
			protected set
			{
				stats = value;
			}
		}

		public bool CanPlaceOnBeam => canPlaceOnBeam;

		public bool CanPlaceOnWater => canPlaceOnWater;

		public List<string> AlmanacTags => almanacTags;

		public string DestroyParticles => destroyParticles;

		public string GroupIdentifier => groupIdentifier;

		public LocKeys[] LocKeys => locKeys;

		public string IconPath => iconPath;

		public string PrefabID => prefabID;

		public string PreviewPrefabID => previewPrefabID;

		public bool IsRegionBridge => isRegionBridge;

		public bool IsSign => buildingSubCategoryUI == BuildingSubCategoryUI.SubCtgSign;

		public float BeautyInput
		{
			get
			{
				return beautyInput;
			}
			protected set
			{
				beautyInput = value;
			}
		}

		public bool BeautyBlocker
		{
			get
			{
				return beautyBlocker;
			}
			protected set
			{
				beautyBlocker = value;
			}
		}

		public string ID
		{
			get
			{
				return id;
			}
			protected set
			{
				id = value;
			}
		}

		public string SortingGroup
		{
			get
			{
				if (!string.IsNullOrEmpty(sortingGroup))
				{
					return sortingGroup;
				}
				return string.Empty;
			}
		}

		public string ProtoId => protoId ?? (protoId = string.Empty);

		public bool IdleTargetForbidden => idleTargetForbidden;

		public List<MeshVariationList> VariationLists => variationLists;

		public HashSet<MeshVariationList> VariationsSet
		{
			get
			{
				if (!variationsSetInit)
				{
					variationsSetInit = true;
					variationsSet = new HashSet<MeshVariationList>();
					variationsSet.AddRange(variationLists);
				}
				return variationsSet;
			}
		}

		public SoundWalkableMaterialCategory WalkableMaterialCategory => soundWalkableMaterialCategory;

		public bool MeshVariationCanRotate => meshVariationCanRotate;

		public bool MeshVariationCanRotate180 => meshVariationCanRotate180;

		public bool MeshVariationCanFlipX => meshVariationCanFlipX;

		public bool MeshVariationCanFlipZ => meshVariationCanFlipZ;

		public bool HideAutomaticMeshCheckbox => hideAutomaticMeshCheckbox;

		public float Flammability => flammability;

		public float HeatDamageThreshold => heatDamageThreshold;

		public float HeatDamage => heatDamage;

		public bool CantFailConstruction => cantFailConstruction;

		public bool ShowVariations
		{
			get
			{
				if (!showVariationsInit)
				{
					showVariationsInit = true;
					showVariations = (VariationLists != null && VariationLists.Count > 0 && VariationLists.Any((MeshVariationList vl) => !vl.HideInUI)) || meshVariationCanRotate || meshVariationCanRotate180 || meshVariationCanFlipX || meshVariationCanFlipZ;
				}
				return showVariations;
			}
		}

		public List<string> PlayerTriggeredEvents
		{
			get
			{
				if (playerTriggeredEvents == null)
				{
					playerTriggeredEvents = new List<string>();
					foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
					{
						string[] buildingIds = allItem.BuildingIds;
						for (int i = 0; i < buildingIds.Length; i++)
						{
							if (buildingIds[i].Equals(id))
							{
								playerTriggeredEvents.Add(allItem.GetID());
							}
						}
					}
				}
				return playerTriggeredEvents;
			}
		}

		public List<MeshVariationList> PileVariationLists => pileVariationLists;

		public TransformSettings[] TransformSettingsArray => transformSettingsArray;

		public string LightCookieId => lightCookieId;

		public bool UseShadowCasters => useShadowCasters;

		public bool UseLOD => useLOD;

		public BoxColliderSettings BoxColliderSettings => boxColliderSettings;

		public TransformSettings[] WorkPositionsArray => workPositionsArray;

		public string EventPropsId => eventPropsId;

		public string MeshColliderMeshId => meshColliderMeshId;

		public BoxColliderSettings CombatBoxColliderSettings => combatBoxColliderSettings;

		public TransformSettings PreviewMarkerOffset => previewMarkerOffset;

		public bool IsArt => isArt;

		public string PreviewMarkerPrefabId => previewMarkerPrefabId;

		public string IconColorOverlay => iconColorOverlay;

		public bool PassThroughDestroyable => passThroughDestroyable;

		public bool ContainsMeshVariation(string meshVariationName)
		{
			return MeshVariationsByName.ContainsKey(meshVariationName);
		}

		public MeshVariation GetMeshVariation(string meshVariationName)
		{
			MeshVariationsByName.TryGetValue(meshVariationName, out var value);
			return value;
		}

		public string GetDefaultMeshId()
		{
			if (!string.IsNullOrEmpty(defaultMeshId))
			{
				return defaultMeshId;
			}
			bool isEnabled;
			if (!MeshVariationsByName.ContainsKey("default"))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Blueprints\\BaseBuildingBlueprint.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetID());
					messageBuilder.AppendLiteral(" blueprint is missing MeshVariation named \"default\"");
				}
				Log.Error(messageBuilder);
				return null;
			}
			SlotPropertySetter slotPropertySetter = meshVariationsByName["default"].Slots.FirstOrDefault((SlotPropertySetter s) => s.SlotType == SlotType.Mesh);
			if (slotPropertySetter == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Blueprints\\BaseBuildingBlueprint.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetID());
					messageBuilder.AppendLiteral(" blueprint is missing MeshSlot of type \"SlotType.Mesh\"");
				}
				Log.Error(messageBuilder);
				return null;
			}
			if (string.IsNullOrEmpty(slotPropertySetter.Value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Blueprints\\BaseBuildingBlueprint.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetID());
					messageBuilder.AppendLiteral(" blueprint MeshSlot ");
					messageBuilder.AppendFormatted(slotPropertySetter.Slot);
					messageBuilder.AppendLiteral(" has no \"value\" field assigned");
				}
				Log.Error(messageBuilder);
				return null;
			}
			defaultMeshId = slotPropertySetter.Value;
			return defaultMeshId;
		}

		public override string GetID()
		{
			return id;
		}

		public Stat GetStat(StatType statType)
		{
			for (int i = 0; i < stats.Length; i++)
			{
				if (stats[i].Type == statType)
				{
					return stats[i];
				}
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsWallTypeBuilding()
		{
			return (buildingType & (BuildingType.AnyDoor | BuildingType.Wall | BuildingType.Window)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsWallTypeBuildingWithVerticalStability()
		{
			return (buildingType & (BuildingType.Wall | BuildingType.Voxel | BuildingType.Window | BuildingType.Door | BuildingType.BarnDoor)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CanSupportRoof()
		{
			return (buildingType & (BuildingType.Wall | BuildingType.Floor | BuildingType.Voxel | BuildingType.Beam | BuildingType.Window | BuildingType.Door | BuildingType.BarnDoor)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasVerticalStability()
		{
			return (buildingType & (BuildingType.Wall | BuildingType.Voxel | BuildingType.Beam | BuildingType.Window | BuildingType.Door | BuildingType.BarnDoor | BuildingType.Ladder)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool VerticalStabilityCanStandOn()
		{
			return (buildingType & (BuildingType.Wall | BuildingType.Voxel | BuildingType.Window | BuildingType.Door | BuildingType.BarnDoor | BuildingType.Ladder)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TransfersStability()
		{
			return (buildingType & (BuildingType.Wall | BuildingType.Floor | BuildingType.Voxel | BuildingType.Window | BuildingType.Door | BuildingType.Merlon | BuildingType.BarnDoor | BuildingType.Ladder)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasSideStability()
		{
			if (TransfersStability())
			{
				return buildingType != BuildingType.Beam;
			}
			return false;
		}

		public bool TransfersStabilityIncludeBeams()
		{
			return (buildingType & (BuildingType.Wall | BuildingType.Floor | BuildingType.Voxel | BuildingType.Beam | BuildingType.Window | BuildingType.Door | BuildingType.Merlon | BuildingType.BarnDoor | BuildingType.Ladder)) != 0;
		}

		public bool CanHostPlayerTriggeredEvents()
		{
			if (PlayerTriggeredEvents != null)
			{
				return PlayerTriggeredEvents.Count > 0;
			}
			return false;
		}

		public bool HasCommonPlacementCheck()
		{
			BuildingType buildingType = BuildingType.PassThroughDamageable | BuildingType.Stairs | BuildingType.ProductionBuilding | BuildingType.Table | BuildingType.Bed | BuildingType.Decoration | BuildingType.Shrine | BuildingType.Trap | BuildingType.FenceGate | BuildingType.Rug | BuildingType.PenMarker;
			return buildingType.HasFlag(this.buildingType);
		}

		public bool UseBasicHasStabilityCheck()
		{
			return TransfersStabilityIncludeBeams();
		}

		public BaseBuildingBlueprint GetQualityClone(ProductQuality quality, float wealthPoints, float beautyInput, Stat healthStat)
		{
			BaseBuildingBlueprint baseBuildingBlueprint = (BaseBuildingBlueprint)MemberwiseClone();
			baseBuildingBlueprint.ID = quality.ToString().ToLower() + "_" + GetID();
			baseBuildingBlueprint.quality = quality;
			baseBuildingBlueprint.WealthPoints = wealthPoints;
			baseBuildingBlueprint.BeautyInput = beautyInput;
			baseBuildingBlueprint.BeautyBlocker = BeautyBlocker;
			baseBuildingBlueprint.Stats = new Stat[Stats.Length];
			for (int i = 0; i < Stats.Length; i++)
			{
				Stat stat = Stats[i];
				if (stat.Type.Equals(healthStat.Type))
				{
					stat = healthStat;
				}
				baseBuildingBlueprint.Stats[i] = new Stat(stat.Type, stat.InitialValue, new StatAttributeModifiers(stat.Min, stat.Max, stat.Step, stat.ThresholdAttributes));
			}
			baseBuildingBlueprint.beamComponentID = beamComponentID;
			baseBuildingBlueprint.bedComponentID = bedComponentID;
			baseBuildingBlueprint.caravanPostComponentID = caravanPostComponentID;
			baseBuildingBlueprint.chairComponentID = chairComponentID;
			baseBuildingBlueprint.decorationComponentID = decorationComponentID;
			baseBuildingBlueprint.doorComponentID = doorComponentID;
			baseBuildingBlueprint.entertainmentComponentID = entertainmentComponentID;
			baseBuildingBlueprint.fuelConsumerComponentID = fuelConsumerComponentID;
			baseBuildingBlueprint.graveComponentID = graveComponentID;
			baseBuildingBlueprint.ladderComponentID = ladderComponentID;
			baseBuildingBlueprint.mapTableComponentID = mapTableComponentID;
			baseBuildingBlueprint.penMarkerComponentID = penMarkerComponentID;
			baseBuildingBlueprint.productionComponentID = productionComponentID;
			baseBuildingBlueprint.rallyPointMarkerComponentID = rallyPointMarkerComponentID;
			baseBuildingBlueprint.roofComponentID = roofComponentID;
			baseBuildingBlueprint.rugComponentID = rugComponentID;
			baseBuildingBlueprint.shelfComponentID = shelfComponentID;
			baseBuildingBlueprint.shrineComponentID = shrineComponentID;
			baseBuildingBlueprint.signComponentID = signComponentID;
			baseBuildingBlueprint.stairComponentID = stairComponentID;
			baseBuildingBlueprint.tableComponentID = tableComponentID;
			baseBuildingBlueprint.tradingPostComponentID = tradingPostComponentID;
			baseBuildingBlueprint.gallowsComponentID = gallowsComponentID;
			baseBuildingBlueprint.trapComponentID = trapComponentID;
			baseBuildingBlueprint.windowComponentID = windowComponentID;
			baseBuildingBlueprint.voxelComponentID = voxelComponentID;
			baseBuildingBlueprint.slopeComponentID = slopeComponentID;
			baseBuildingBlueprint.bellComponentID = bellComponentID;
			return baseBuildingBlueprint;
		}

		public bool Furniture()
		{
			BuildingType buildingType = BuildingType.Chair | BuildingType.Table | BuildingType.Bed | BuildingType.Decoration | BuildingType.Shrine | BuildingType.Rug;
			return buildingType.HasFlag(this.buildingType);
		}
	}
}
