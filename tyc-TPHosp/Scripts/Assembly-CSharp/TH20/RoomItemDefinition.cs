using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using FullSerializer;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemDefinition : IRoomItemDefinition, IPriceModifier, IEntityDefinition, ISilverUnlockable, ISilverUnlockToken
	{
		public enum Type
		{
			[UsedImplicitly]
			Default = 0,
			[UsedImplicitly]
			Door = 1,
			[UsedImplicitly]
			Window = 2,
			[UsedImplicitly]
			DEPRECATED_WholeWallDoor = 3,
			[UsedImplicitly]
			ServingHatch = 4,
			[UsedImplicitly]
			Research = 5,
			[UsedImplicitly]
			Landscape = 6,
			[UsedImplicitly]
			Machine = 7,
			[UsedImplicitly]
			Special = 8,
			[UsedImplicitly]
			OtherSingleItems = 9,
			[UsedImplicitly]
			SideDoor = 10,
			[UsedImplicitly]
			PlotObject = 11,
			[UsedImplicitly]
			Ambulance = 12
		}

		public enum Size
		{
			[UsedImplicitly]
			Small = 0,
			[UsedImplicitly]
			Medium = 1,
			[UsedImplicitly]
			Large = 2
		}

		public enum CollisionType
		{
			[UsedImplicitly]
			Default = 0,
			[UsedImplicitly]
			Rug = 1
		}

		public enum FixedWallPlacementOption
		{
			[UsedImplicitly]
			None = 0,
			[UsedImplicitly]
			AmbulanceBayEntrance = 1
		}

		[fsProperty]
		[HideInInspector]
		private Guid _guid;

		[InspectorTooltip("Type of the item")]
		[fsProperty]
		private Type _type;

		[InspectorOrder(0.0)]
		[FullInspector.InspectorName("Name")]
		[fsProperty]
		private LocalisedString _localisedName;

		[InspectorOrder(0.0)]
		[FullInspector.InspectorName("Description")]
		[fsProperty]
		private LocalisedString _localisedDescription;

		[InspectorOrder(0.0)]
		[fsProperty]
		private LocalisedString _functionalDescription;

		[InspectorOrder(0.0)]
		[fsProperty("DebugTag")]
		private string _debugTag;

		[FullInspector.InspectorName("Deprecated")]
		[InspectorTooltip("If an item is marked as deprecated it won't appear in any menus (but can still be loaded from saves etc)")]
		[fsProperty]
		private bool _itemDeprecated;

		[InspectorTooltip("Icon to display on menus etc.")]
		[fsProperty]
		private Sprite _icon;

		[InspectorTooltip("Icon without backing etc.")]
		[fsProperty]
		private Sprite _iconWithoutBacking;

		[InspectorTooltip("Icon to display on job assignment etc.")]
		[fsProperty]
		private Sprite _jobAssignmentIcon;

		[InspectorTooltip("Cost of the item")]
		[fsProperty]
		private int _cost;

		[InspectorTooltip("Energy Cost per Month")]
		[fsProperty]
		private int _energyCost;

		[InspectorTooltip("Is the item initially available to the player?")]
		[fsProperty("InitiallyAvailable")]
		private bool _initiallyAvailable = true;

		[InspectorTooltip("If true, only available if the item is white listed by the level.")]
		[fsProperty("MustBeWhiteListed")]
		private bool _mustBeWhiteListed;

		[InspectorTooltip("Is this item saved in room layouts?")]
		[fsProperty("SaveInRoomLayout")]
		private bool _saveInRoomLayout = true;

		[InspectorTooltip("Silver unlock cost")]
		[fsProperty]
		[SerializeField]
		private int _silverCost;

		[InspectorTooltip("Should the user be required to unlock before placing?")]
		[fsProperty]
		[SerializeField]
		private bool _lockedFreeItem;

		[InspectorTooltip("Unlocked message")]
		[fsProperty]
		private LocalisedString _unlockedMessage;

		[fsProperty]
		private float _prestige;

		[fsProperty("HospitalLevelPoints")]
		private float _hospitalLevelPoints;

		[InspectorTooltip("Size of the item")]
		[fsProperty]
		private Size _size;

		[InspectorTooltip("Size of the item")]
		[fsProperty("PlayPlacmentSFX")]
		private bool _playPlacmentSFX = true;

		[InspectorTooltip("Item is only valid when placed against a wall")]
		[fsProperty]
		private bool _placeOnWall;

		[InspectorTooltip("Item only occupies wall space not floor")]
		[fsProperty]
		private bool _occupyWallOnly;

		[InspectorTooltip("Can this item be placed on a corner")]
		[fsProperty]
		private bool _allowOnCorner = true;

		[InspectorTooltip("Grid snap when placing")]
		[fsProperty]
		private float _gridSnap = 1f;

		[InspectorTooltip("Rotation snap when placing")]
		[fsProperty]
		private float _rotationSnap = 90f;

		[InspectorTooltip("Default rotation when item is being placing")]
		[fsProperty("DefaultRotation")]
		private float _defaultRotation;

		[InspectorTooltip("Use wall magnetism")]
		[fsProperty]
		private bool _wallMagnetism;

		[InspectorTooltip("Amount rotation is offset when using wall magnetism")]
		[fsProperty]
		private float _wallMagnetismRotation;

		[InspectorTooltip("Distance to check for wall magnetism")]
		[fsProperty]
		private float _wallMagnetismDistance = 2f;

		[InspectorTooltip("Should this item remain on the cursor after placement")]
		[fsProperty]
		private bool _singlePlace = true;

		[InspectorTooltip("Does the item have collision")]
		[fsProperty]
		private bool _hasCollision = true;

		[InspectorTooltip("Does the item have vertical collision")]
		[fsProperty("UseVerticalCollision")]
		private readonly bool _useVerticalCollision;

		[InspectorTooltip("Does the item collide with items of same type?")]
		[fsProperty]
		private bool _collideWithSameType;

		[InspectorTooltip("Does the item collide with rugs?")]
		[fsProperty]
		private bool _collideWithRugs;

		[InspectorTooltip("Some items need more complex collision information, rugs for example, can't collide with other rugs.")]
		[fsProperty]
		private CollisionType _collisionType;

		[InspectorTooltip("Should this item move out of the way of other rooms/items")]
		[fsProperty("MoveOutOfWay")]
		private bool _moveOutOfWay;

		[InspectorTooltip("Ignore item placement validation checks")]
		[fsProperty]
		private bool _ignoreValidation;

		[InspectorTooltip("Can this object be selected")]
		[fsProperty]
		private bool _isSelectable = true;

		[InspectorTooltip("Does it have a tooltip?")]
		[fsProperty]
		private bool _hasTooltip = true;

		[InspectorTooltip("Show queue positions for interacting characters")]
		[fsProperty]
		private bool _showQueuePositions;

		[InspectorTooltip("Should status icons be shown")]
		[fsProperty]
		private bool _showStatusIcon = true;

		[InspectorTooltip("Should this item affect navigation")]
		[fsProperty]
		private bool _affectsNavigation = true;

		[InspectorTooltip("Should this item remove wall pieces")]
		[fsProperty]
		private bool _removeWalls;

		[InspectorTooltip("Should particles be disabled when editing this item")]
		[fsProperty("DisableParticlesOnEdit")]
		private bool _disableParticlesOnEdit;

		[InspectorTooltip("Item visualisation prefab")]
		[fsProperty]
		private GameObject _prefab;

		[InspectorTooltip("Blueprint item visualisation prefab")]
		[fsProperty]
		private GameObject _blueprintPrefab;

		[InspectorTooltip("List of room types this item can be placed in")]
		[fsProperty]
		private RoomDefinition.Type[] _canBePlacedIn;

		[InspectorTooltip("List of room types this item can't be placed in")]
		[fsProperty]
		private RoomDefinition.Type[] _cantBePlacedIn;

		[InspectorTooltip("Attributes")]
		[fsProperty]
		private ObjectAttributes.Definition[] _attributes;

		[InspectorTooltip("Maintenance attribute modifier")]
		[fsProperty("_maintenanceModifer")]
		private float _maintenanceModifer;

		[InspectorTooltip("Maintenance functional level")]
		[fsProperty("_maintenanceFunctionalLevel")]
		private float _maintenanceFunctionalLevel = 100f;

		[InspectorTooltip("Override for the maintenance icon (if needed)")]
		[fsProperty("_maintenanceIconOverride")]
		private Sprite _maintenanceIconOverride;

		[InspectorTooltip("Janitor priority score multiplier")]
		[fsProperty("_janitorPriority")]
		private float _janitorPriority = 1f;

		[InspectorTooltip("Rate at which Janitors repair this item")]
		[fsProperty("JanitorRepairRate")]
		private float _janitorRepairRate = 10f;

		[InspectorTooltip("Whether janitors ignore this item (despite it having a maintenance value)")]
		[fsProperty("IgnoredByJanitors")]
		private bool _ignoredByJanitors;

		[InspectorTooltip("Describe the type of maintenance that will be required on this item")]
		[fsProperty("_maintenanceDescription")]
		private JobMaintenance.JobDescription _maintenanceDescription;

		[InspectorTooltip("Describe the type of service job to help track")]
		[fsProperty("_serviceDescription")]
		private JobService.JobDescription _serviceDescription;

		[InspectorTooltip("List of room modifiers this item will apply")]
		[fsProperty("_roomModifiers")]
		private RoomModifier[] _roomModifiers;

		[InspectorTooltip("Attribute modifiers applied when this type of interaction is triggered")]
		[fsProperty("_interactionAttributeModifiers")]
		private InteractionAttributeModifier[] _interactionAttributeModifiers;

		[InspectorTooltip("Data view mode to display")]
		[fsProperty("DataViewMode")]
		private DataViewManager.Mode _dataViewMode;

		[InspectorTooltip("Hover menu prefab override")]
		[fsProperty]
		private GameObject _hoverMenuPrefab;

		[InspectorTooltip("Select menu prefab override")]
		[fsProperty]
		private GameObject _selectMenuPrefab;

		[InspectorTooltip("The DLC package that is required to access this item.  null means no DLC required")]
		[fsProperty("DlcPackRequired")]
		private SharedInstance<DLCItemDefinition> _dlcPackRequired;

		[InspectorTooltip("Is there a Collaborative research project required?  null means no research required")]
		[fsProperty("CollaborativeResearchRequired")]
		private SharedInstance<CollaborativeProjectDefinition> _collaborativeResearchRequired;

		[InspectorTooltip("Is there a Super Bug victory node required? null means no victory node required")]
		[fsProperty("SuperBugVictoryRequired")]
		private SharedInstance<SuperBugRequirement> _superBugVictoryRequired;

		[InspectorMargin(10)]
		[fsProperty("Upgrades")]
		private SharedInstance<RoomItemUpgradeDefinition>[] _upgrades;

		[InspectorMargin(10)]
		[InspectorHeader("Interaction Data")]
		[InspectorTooltip("Only one character can interact at a time")]
		[fsProperty("SingleInteractor")]
		private bool _singleInteractor;

		[InspectorTooltip("Interactions will always animate, even when off screen etc.")]
		[fsProperty("InteractionsAlwayAnimate")]
		private bool _interactionsAlwayAnimate;

		[InspectorTooltip("Minimum start locations that need to be valid")]
		[FullInspector.InspectorName("Min Valid Start Locations")]
		[fsProperty("MinValidInteractions")]
		private int _minValidInteractions = 1;

		[fsProperty("Interactions")]
		private InteractionDefinition[] _interactions;

		[fsProperty("Filters")]
		private RoomItemFilter[] _filters;

		[fsProperty("PlacementEffect")]
		private GameObject _placementEffect;

		[fsProperty("SpawnLimitCategory")]
		private SharedInstance<ItemSpawnLimits.Category> _spawnLimitCategory;

		[fsProperty("MinimumQueuePositionAllowedToSatisyNeed")]
		private readonly int _minimumQueuePositionAllowedToSatisyNeed;

		[fsProperty]
		[InspectorTooltip("Components to add to this entity")]
		private EntityComponent[] _components;

		[InspectorTooltip("Does the pick up button appear in the UI?")]
		[fsProperty]
		private bool _canBePickedUp = true;

		[InspectorTooltip("Does holding the mouse button on this trigger the PickUpMenu?")]
		[fsProperty]
		private bool _canDragHoldSelect = true;

		[InspectorTooltip("Does the pick up button appear in the UI?")]
		[fsProperty]
		private bool _canBeSold = true;

		[InspectorTooltip("Whether this item generates 1 unit of electricity")]
		[fsProperty]
		private bool _generatesElectricity;

		[InspectorTooltip("How this item contributes to the hospital's Eco Rating when placed")]
		[fsProperty]
		private float _ecoRatingModifier;

		[InspectorTooltip("If this is an ambulance, give it a config that defines its ambulance stats/attributes")]
		[fsProperty]
		private SharedInstance<AmbulanceConfig> _ambulanceConfig;

		[InspectorTooltip("Restrict this item so it can only snap to and be placed on certain types of walls")]
		[fsProperty]
		private FixedWallPlacementOption _fixedWallPlacement;

		[InspectorTooltip("The unique ID of the Prime Gaming content drop this item belongs to.")]
		[fsProperty]
		private int _primeEntitlementRequired;

		[fsProperty]
		private bool _isAnAmbulance;

		public ISilverUnlockToken SilverUnlockToken => this;

		public Type ItemType => _type;

		public string DebugTag
		{
			get
			{
				return _debugTag;
			}
			set
			{
				_debugTag = value;
			}
		}

		public bool ItemDeprecated => _itemDeprecated;

		public bool InitiallyAvailable => _initiallyAvailable;

		public bool MustBeWhiteListed => _mustBeWhiteListed;

		public bool SaveInRoomLayout => _saveInRoomLayout;

		public bool LockedFreeItem => _lockedFreeItem;

		public float HospitalLevelPoints => _hospitalLevelPoints;

		public Size ItemSize => _size;

		public bool PlayPlacmentSFX => _playPlacmentSFX;

		public bool PlaceOnWall => _placeOnWall;

		public bool OccupyWallOnly => _occupyWallOnly;

		public bool AllowOnCorner => _allowOnCorner;

		public float GridSnap => _gridSnap;

		public float RotationSnap => _rotationSnap;

		public float DefaultRotation => _defaultRotation;

		public bool WallMagnetism => _wallMagnetism;

		public float WallMagnetismRotation => _wallMagnetismRotation;

		public float WallMagnetismDistance => _wallMagnetismDistance;

		public bool SinglePlace => _singlePlace;

		public bool HasCollision => _hasCollision;

		public bool UseVerticalCollision => _useVerticalCollision;

		public bool CollideWithSameType => _collideWithSameType;

		public bool CollideWithRugs => _collideWithRugs;

		public CollisionType ItemCollisionType => _collisionType;

		public bool MoveOutOfWay => _moveOutOfWay;

		public bool IgnoreValidation => _ignoreValidation;

		public bool IsSelectable => _isSelectable;

		public bool HasTooltip => _hasTooltip;

		public bool ShowQueuePositions => _showQueuePositions;

		public bool ShowStatusIcon => _showStatusIcon;

		public bool AffectsNavigation => _affectsNavigation;

		public bool RemoveWalls => _removeWalls;

		public bool DisableParticlesOnEdit => _disableParticlesOnEdit;

		public RoomDefinition.Type[] CanBePlacedInRoomTypes => _canBePlacedIn;

		public RoomDefinition.Type[] CantBePlacedInRoomTypes => _cantBePlacedIn;

		public ObjectAttributes.Definition[] Attributes => _attributes;

		public float MaintenanceModifer => _maintenanceModifer;

		public float MaintenanceFunctionalLevel => _maintenanceFunctionalLevel;

		public Sprite MaintenanceIconOverride => _maintenanceIconOverride;

		public float JanitorPriority => _janitorPriority;

		public float JanitorRepairRate => _janitorRepairRate;

		public bool IgnoredByJanitors => _ignoredByJanitors;

		public JobMaintenance.JobDescription MaintenanceDescription => _maintenanceDescription;

		public JobService.JobDescription ServiceDescription => _serviceDescription;

		public RoomModifier[] RoomModifiers => _roomModifiers;

		public InteractionAttributeModifier[] InteractionAttributeModifiers => _interactionAttributeModifiers;

		public DataViewManager.Mode DataViewMode => _dataViewMode;

		public GameObject HoverMenuPrefab => _hoverMenuPrefab;

		public GameObject SelectMenuPrefab => _selectMenuPrefab;

		public SharedInstance<DLCItemDefinition> DlcPackRequired => _dlcPackRequired;

		public SharedInstance<CollaborativeProjectDefinition> CollaborativeResearchRequired => _collaborativeResearchRequired;

		public SharedInstance<SuperBugRequirement> SuperBugVictoryRequired => _superBugVictoryRequired;

		public SharedInstance<RoomItemUpgradeDefinition>[] Upgrades => _upgrades;

		public bool SingleInteractor => _singleInteractor;

		public bool InteractionsAlwayAnimate => _interactionsAlwayAnimate;

		public int MinValidInteractions => _minValidInteractions;

		public InteractionDefinition[] Interactions
		{
			get
			{
				return _interactions;
			}
			set
			{
				_interactions = value;
			}
		}

		public RoomItemFilter[] Filters => _filters;

		public GameObject PlacementEffect => _placementEffect;

		public SharedInstance<ItemSpawnLimits.Category> SpawnLimitCategory => _spawnLimitCategory;

		public int MinimumQueuePositionAllowedToSatisyNeed => _minimumQueuePositionAllowedToSatisyNeed;

		public EntityComponent[] Components => _components;

		public bool CanBePickedUp => _canBePickedUp;

		public bool CanDragHoldSelect => _canDragHoldSelect;

		public bool GeneratesElectricity => _generatesElectricity;

		public float EcoRatingModifier => _ecoRatingModifier;

		public SharedInstance<AmbulanceConfig> BaseAmbulanceConfig => _ambulanceConfig;

		public bool IsAnAmbulance => _isAnAmbulance;

		public int PrimeEntitlementRequired => _primeEntitlementRequired;

		public FixedWallPlacementOption FixedWallPlacement => _fixedWallPlacement;

		public Guid GUID => _guid;

		public override string ToString()
		{
			return _localisedName.ToString();
		}

		public virtual string ToLocalisedString()
		{
			return _localisedName.TranslationPlural(1);
		}

		public float GetAttributeModifer(ObjectAttributes.Type type)
		{
			if (type == ObjectAttributes.Type.Maintenance)
			{
				return _maintenanceModifer;
			}
			return 0f;
		}

		public bool CanBePlacedIn(RoomDefinition.Type roomType)
		{
			bool flag = _canBePlacedIn.Contains(roomType);
			if (roomType == RoomDefinition.Type.AmbulanceBay && !flag)
			{
				return false;
			}
			bool num = _canBePlacedIn == null || _canBePlacedIn.Length == 0 || flag;
			bool flag2 = _cantBePlacedIn != null && _cantBePlacedIn.Length != 0 && _cantBePlacedIn.Contains(roomType);
			if (num)
			{
				return !flag2;
			}
			return false;
		}

		public bool AllowCollisionOutsideRoom()
		{
			if (_type != Type.Door)
			{
				return _type == Type.ServingHatch;
			}
			return true;
		}

		public void IterateModifiers<T>(Action<T> callback) where T : RoomModifier
		{
			RoomModifier[] roomModifiers = _roomModifiers;
			foreach (RoomModifier roomModifier in roomModifiers)
			{
				if (roomModifier is T)
				{
					callback((T)roomModifier);
				}
			}
		}

		public bool CanBeSold()
		{
			if (_type != Type.Door && _type != Type.Window)
			{
				return _canBeSold;
			}
			return false;
		}

		public bool CanBeSoldWhenBuiltOver()
		{
			if (_type != Type.Door && _type != Type.Window && _type != Type.SideDoor && _type != Type.PlotObject)
			{
				return _type != Type.Ambulance;
			}
			return false;
		}

		public string GetSanitizedName()
		{
			return GetName().Replace("'", "_");
		}

		public int SilverCost()
		{
			return _silverCost;
		}

		public LocalisedString GetUnlockName()
		{
			return _localisedName;
		}

		public LocalisedString GetUnlockMessage()
		{
			return _unlockedMessage;
		}

		public Sprite GetUnlockIcon()
		{
			return _icon;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.RoomItems;
		}

		public bool AllowFreePlacement()
		{
			if (_type == Type.Window)
			{
				return false;
			}
			if (_type == Type.Door && CanBePlacedIn(RoomDefinition.Type.Reception))
			{
				return false;
			}
			return true;
		}

		[CanBeNull]
		public RoomItemUpgradeDefinition GetUpgrade(int upgradeLevel)
		{
			upgradeLevel--;
			if (Upgrades == null || upgradeLevel < 0 || upgradeLevel >= Upgrades.Length)
			{
				return null;
			}
			return Upgrades[upgradeLevel].Instance;
		}

		[CanBeNull]
		public RoomItemUpgradeDefinition GetNextUpgrade(int upgradeLevel)
		{
			if (Upgrades == null || upgradeLevel >= Upgrades.Length)
			{
				return null;
			}
			return Upgrades[upgradeLevel].Instance;
		}

		public string GetName(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.LocalisedName.ToString();
			}
			return _localisedName.ToString();
		}

		public string GetLocalisedName(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.LocalisedName.TranslationPlural(1);
			}
			return _localisedName.TranslationPlural(1);
		}

		public string GetLocalisedNamePlural(int count, int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.LocalisedName.TranslationPlural(count);
			}
			return _localisedName.TranslationPlural(count);
		}

		public int GetCost(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return _cost + Upgrades[upgradeLevel - 1].Instance.Cost;
			}
			return _cost;
		}

		public int EnergyCost(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return _energyCost + Upgrades[upgradeLevel - 1].Instance.EnergyCost;
			}
			return _energyCost;
		}

		public float GetPrestige(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.Prestige;
			}
			return _prestige;
		}

		public string GetDescription(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.LocalisedDescription.Translation;
			}
			return _localisedDescription.Translation;
		}

		public string GetFunctionalDescription()
		{
			if (_functionalDescription.Term == null)
			{
				return null;
			}
			return _functionalDescription.Translation;
		}

		public Sprite GetIcon(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.Icon;
			}
			return _icon;
		}

		public Sprite GetJobAssignmentIcon()
		{
			return _jobAssignmentIcon;
		}

		public GameObject GetPrefab(int upgradeLevel = 0)
		{
			if (upgradeLevel == 0)
			{
				return _prefab;
			}
			GameObject prefab = Upgrades[upgradeLevel - 1].Instance.Prefab;
			if (!(prefab != null))
			{
				return _prefab;
			}
			return prefab;
		}

		public Sprite GetIconWithoutBacking()
		{
			return _iconWithoutBacking;
		}

		public GameObject GetBlueprintPrefab(int upgradeLevel = 0)
		{
			if (upgradeLevel == 0)
			{
				if (!(_blueprintPrefab != null))
				{
					return _prefab;
				}
				return _blueprintPrefab;
			}
			GameObject prefab = Upgrades[upgradeLevel - 1].Instance.Prefab;
			GameObject blueprintPrefab = Upgrades[upgradeLevel - 1].Instance.BlueprintPrefab;
			GameObject gameObject = ((blueprintPrefab != null) ? blueprintPrefab : prefab);
			if (!(gameObject != null))
			{
				return _prefab;
			}
			return gameObject;
		}

		public GameObject GetUpgradeAddOnPrefab(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.AddOnPrefab;
			}
			return null;
		}

		public SharedInstance<AmbulanceConfig> GetAmbulanceConfig(int upgradeLevel = 0)
		{
			if (upgradeLevel != 0)
			{
				return Upgrades[upgradeLevel - 1].Instance.AmbulanceConfig;
			}
			return BaseAmbulanceConfig;
		}

		public GameObject GetUpgradeAddOnBlueprintPrefab(int upgradeLevel = 0)
		{
			if (upgradeLevel == 0)
			{
				return null;
			}
			GameObject addOnPrefab = Upgrades[upgradeLevel - 1].Instance.AddOnPrefab;
			GameObject addOnBlueprintPrefab = Upgrades[upgradeLevel - 1].Instance.AddOnBlueprintPrefab;
			if (!(addOnBlueprintPrefab != null))
			{
				return addOnPrefab;
			}
			return addOnBlueprintPrefab;
		}

		public List<StaffRequired> GetRequiredStaff(bool includeRoomModifier)
		{
			List<StaffRequired> results = new List<StaffRequired>();
			EntityComponent[] components = _components;
			for (int i = 0; i < components.Length; i++)
			{
				if (components[i] is RoomItemJobComponent roomItemJobComponent)
				{
					results.Add(roomItemJobComponent.StaffRequired);
				}
			}
			if (includeRoomModifier)
			{
				IterateModifiers(delegate(RoomModifierRequiredStaff modifier)
				{
					results.Add(modifier.StaffRequired);
				});
			}
			return results;
		}

		public Vector3 GetEditLiftOffset(RoomItem item)
		{
			if (_type == Type.Door || _type == Type.Window)
			{
				return Vector3.zero;
			}
			if (_placeOnWall)
			{
				return -0.05f * item.GridRotation.DirectionVector();
			}
			return 0.1f * Vector3.up;
		}

		public bool ValidQueuePositionForNeed(int queuePosition)
		{
			if (queuePosition != -1)
			{
				return queuePosition >= MinimumQueuePositionAllowedToSatisyNeed;
			}
			return true;
		}

		public bool IsExcludedFromGameMode(Level level)
		{
			if (!Components.IsEmpty())
			{
				EntityComponent[] components = Components;
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i] is RoomItemExcludeFromGameMode roomItemExcludeFromGameMode && roomItemExcludeFromGameMode.IsExcluded(level))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
