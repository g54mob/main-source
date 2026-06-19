using System;
using System.Collections.Generic;
using FullInspector;
using FullSerializerSave;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	public class RoomItemDefinitionUGC : IRoomItemDefinition, IPriceModifier, IEntityDefinition, ISilverUnlockable
	{
		[fsProperty]
		private RoomItemDefinition _roomItemDefinitionBase;

		[fsProperty]
		private string _contentID;

		[DontSave]
		private UGCRuntimePrefabManager _ugcRuntimePrefabManager;

		[DontSave]
		private UGCRoomItemDefinitionDatabase _ugcRoomItemDefinitionDatabase;

		[DontSave]
		private GameItemBase _extContentGameItem;

		public GameItemBase ExtContentGameItem => GetExtContentGameItem();

		public string ContentID => _contentID;

		public ISilverUnlockToken SilverUnlockToken => new UGCSilverUnlockToken(_contentID);

		public RoomItemDefinition.Type ItemType => _roomItemDefinitionBase.ItemType;

		public string DebugTag
		{
			get
			{
				return _roomItemDefinitionBase.DebugTag;
			}
			set
			{
				_roomItemDefinitionBase.DebugTag = value;
			}
		}

		public bool InitiallyAvailable => _roomItemDefinitionBase.InitiallyAvailable;

		public bool SaveInRoomLayout => _roomItemDefinitionBase.SaveInRoomLayout;

		public float HospitalLevelPoints => _roomItemDefinitionBase.HospitalLevelPoints;

		public RoomItemDefinition.Size ItemSize => _roomItemDefinitionBase.ItemSize;

		public bool PlayPlacmentSFX => _roomItemDefinitionBase.PlayPlacmentSFX;

		public bool PlaceOnWall => _roomItemDefinitionBase.PlaceOnWall;

		public bool OccupyWallOnly => _roomItemDefinitionBase.OccupyWallOnly;

		public bool AllowOnCorner => _roomItemDefinitionBase.AllowOnCorner;

		public float GridSnap => _roomItemDefinitionBase.GridSnap;

		public float RotationSnap => _roomItemDefinitionBase.RotationSnap;

		public float DefaultRotation => _roomItemDefinitionBase.DefaultRotation;

		public bool WallMagnetism => _roomItemDefinitionBase.WallMagnetism;

		public float WallMagnetismRotation => _roomItemDefinitionBase.WallMagnetismRotation;

		public float WallMagnetismDistance => _roomItemDefinitionBase.WallMagnetismDistance;

		public bool SinglePlace => _roomItemDefinitionBase.SinglePlace;

		public bool HasCollision => _roomItemDefinitionBase.HasCollision;

		public bool UseVerticalCollision => _roomItemDefinitionBase.UseVerticalCollision;

		public bool CollideWithSameType => _roomItemDefinitionBase.CollideWithSameType;

		public bool CollideWithRugs => _roomItemDefinitionBase.CollideWithRugs;

		public RoomItemDefinition.CollisionType ItemCollisionType => _roomItemDefinitionBase.ItemCollisionType;

		public bool MoveOutOfWay => _roomItemDefinitionBase.MoveOutOfWay;

		public bool IgnoreValidation => _roomItemDefinitionBase.IgnoreValidation;

		public bool IsSelectable => _roomItemDefinitionBase.IsSelectable;

		public bool HasTooltip => _roomItemDefinitionBase.HasTooltip;

		public bool ShowQueuePositions => _roomItemDefinitionBase.ShowQueuePositions;

		public bool ShowStatusIcon => _roomItemDefinitionBase.ShowStatusIcon;

		public bool AffectsNavigation => _roomItemDefinitionBase.AffectsNavigation;

		public bool RemoveWalls => _roomItemDefinitionBase.RemoveWalls;

		public bool DisableParticlesOnEdit => _roomItemDefinitionBase.DisableParticlesOnEdit;

		public RoomDefinition.Type[] CanBePlacedInRoomTypes => _roomItemDefinitionBase.CanBePlacedInRoomTypes;

		public RoomDefinition.Type[] CantBePlacedInRoomTypes => _roomItemDefinitionBase.CantBePlacedInRoomTypes;

		public ObjectAttributes.Definition[] Attributes => _roomItemDefinitionBase.Attributes;

		public float MaintenanceModifer => _roomItemDefinitionBase.MaintenanceModifer;

		public float MaintenanceFunctionalLevel => _roomItemDefinitionBase.MaintenanceFunctionalLevel;

		public Sprite MaintenanceIconOverride => _roomItemDefinitionBase.MaintenanceIconOverride;

		public float JanitorPriority => _roomItemDefinitionBase.JanitorPriority;

		public float JanitorRepairRate => _roomItemDefinitionBase.JanitorRepairRate;

		public bool IgnoredByJanitors => _roomItemDefinitionBase.IgnoredByJanitors;

		public bool GeneratesElectricity => _roomItemDefinitionBase.GeneratesElectricity;

		public float EcoRatingModifier => _roomItemDefinitionBase.EcoRatingModifier;

		public JobMaintenance.JobDescription MaintenanceDescription => _roomItemDefinitionBase.MaintenanceDescription;

		public JobService.JobDescription ServiceDescription => _roomItemDefinitionBase.ServiceDescription;

		public RoomModifier[] RoomModifiers => _roomItemDefinitionBase.RoomModifiers;

		public InteractionAttributeModifier[] InteractionAttributeModifiers => _roomItemDefinitionBase.InteractionAttributeModifiers;

		public DataViewManager.Mode DataViewMode => _roomItemDefinitionBase.DataViewMode;

		public GameObject HoverMenuPrefab => _roomItemDefinitionBase.HoverMenuPrefab;

		public GameObject SelectMenuPrefab => _roomItemDefinitionBase.SelectMenuPrefab;

		public SharedInstance<DLCItemDefinition> DlcPackRequired => _roomItemDefinitionBase.DlcPackRequired;

		public int PrimeEntitlementRequired => _roomItemDefinitionBase.PrimeEntitlementRequired;

		public SharedInstance<RoomItemUpgradeDefinition>[] Upgrades => _roomItemDefinitionBase.Upgrades;

		public bool SingleInteractor => _roomItemDefinitionBase.SingleInteractor;

		public bool InteractionsAlwayAnimate => _roomItemDefinitionBase.InteractionsAlwayAnimate;

		public int MinValidInteractions => _roomItemDefinitionBase.MinValidInteractions;

		public InteractionDefinition[] Interactions
		{
			get
			{
				return _roomItemDefinitionBase.Interactions;
			}
			set
			{
				_roomItemDefinitionBase.Interactions = value;
			}
		}

		public RoomItemFilter[] Filters => _roomItemDefinitionBase.Filters;

		public GameObject PlacementEffect => _roomItemDefinitionBase.PlacementEffect;

		public SharedInstance<ItemSpawnLimits.Category> SpawnLimitCategory => _roomItemDefinitionBase.SpawnLimitCategory;

		public int MinimumQueuePositionAllowedToSatisyNeed => _roomItemDefinitionBase.MinimumQueuePositionAllowedToSatisyNeed;

		public Guid GUID => _roomItemDefinitionBase.GUID;

		public EntityComponent[] Components => _roomItemDefinitionBase.Components;

		public bool CanBePickedUp => true;

		public bool CanDragHoldSelect => true;

		public bool MustBeWhiteListed => false;

		public SharedInstance<AmbulanceConfig> BaseAmbulanceConfig => null;

		public bool IsAnAmbulance => false;

		public RoomItemDefinition.FixedWallPlacementOption FixedWallPlacement => RoomItemDefinition.FixedWallPlacementOption.None;

		public RoomItemDefinitionUGC(string contentID, RoomItemDefinition roomItemDefinitionBase, UGCRuntimePrefabManager ugcFakePrefabManager, UGCRoomItemDefinitionDatabase ugcRoomItemDefinitionDatabase)
		{
			_roomItemDefinitionBase = roomItemDefinitionBase;
			_contentID = contentID;
			_ugcRuntimePrefabManager = ugcFakePrefabManager;
			_ugcRoomItemDefinitionDatabase = ugcRoomItemDefinitionDatabase;
		}

		public void RestoreFromSave(UGCRuntimePrefabManager ugcFakePrefabManager, UGCRoomItemDefinitionDatabase ugcRoomItemDefinitionDatabase)
		{
			_ugcRuntimePrefabManager = ugcFakePrefabManager;
			_ugcRoomItemDefinitionDatabase = ugcRoomItemDefinitionDatabase;
		}

		public bool AllowCollisionOutsideRoom()
		{
			return _roomItemDefinitionBase.AllowCollisionOutsideRoom();
		}

		public bool AllowFreePlacement()
		{
			return _roomItemDefinitionBase.AllowFreePlacement();
		}

		public bool CanBePlacedIn(RoomDefinition.Type roomType)
		{
			return _roomItemDefinitionBase.CanBePlacedIn(roomType);
		}

		public bool CanBeSold()
		{
			return _roomItemDefinitionBase.CanBeSold();
		}

		public bool CanBeSoldWhenBuiltOver()
		{
			return _roomItemDefinitionBase.CanBeSoldWhenBuiltOver();
		}

		public int EnergyCost(int upgradeLevel = 0)
		{
			return _roomItemDefinitionBase.EnergyCost(upgradeLevel);
		}

		public float GetAttributeModifer(ObjectAttributes.Type type)
		{
			return _roomItemDefinitionBase.GetAttributeModifer(type);
		}

		public GameObject GetBlueprintPrefab(int upgradeLevel = 0)
		{
			GameObject runtimePrefab = _ugcRuntimePrefabManager.GetRuntimePrefab(new UGCRuntimePrefabKey(ContentID, upgradeLevel));
			if (runtimePrefab != null)
			{
				return runtimePrefab;
			}
			return _roomItemDefinitionBase.GetBlueprintPrefab(upgradeLevel);
		}

		public int GetCost(int upgradeLevel = 0)
		{
			if (_ugcRoomItemDefinitionDatabase.TryGetCost(_contentID, out var cost))
			{
				return cost;
			}
			return _roomItemDefinitionBase.GetCost(upgradeLevel);
		}

		public string GetDescription(int upgradeLevel = 0)
		{
			if (ExtContentGameItem != null)
			{
				return ExtContentUtils.GetGameItemInGameDescription(GetExtContentGameItem());
			}
			return _roomItemDefinitionBase.GetDescription(upgradeLevel);
		}

		public Vector3 GetEditLiftOffset(RoomItem item)
		{
			return _roomItemDefinitionBase.GetEditLiftOffset(item);
		}

		public string GetFunctionalDescription()
		{
			return _roomItemDefinitionBase.GetFunctionalDescription();
		}

		public Sprite GetIcon(int upgradeLevel = 0)
		{
			if (_ugcRoomItemDefinitionDatabase.TryGetIcon(_contentID, out var icon))
			{
				return icon;
			}
			return _roomItemDefinitionBase.GetIcon(upgradeLevel);
		}

		public Sprite GetJobAssignmentIcon()
		{
			return _roomItemDefinitionBase.GetJobAssignmentIcon();
		}

		public string GetLocalisedName(int upgradeLevel = 0)
		{
			string extContentName = GetExtContentName();
			if (!extContentName.IsNullOrEmpty())
			{
				return extContentName;
			}
			return _roomItemDefinitionBase.GetLocalisedName(upgradeLevel);
		}

		public string GetLocalisedNamePlural(int count, int upgradeLevel = 0)
		{
			string extContentName = GetExtContentName();
			if (!extContentName.IsNullOrEmpty())
			{
				return extContentName;
			}
			return _roomItemDefinitionBase.GetLocalisedNamePlural(count, upgradeLevel);
		}

		public string GetName(int upgradeLevel = 0)
		{
			string extContentName = GetExtContentName();
			if (!extContentName.IsNullOrEmpty())
			{
				return extContentName;
			}
			return _roomItemDefinitionBase.GetName(upgradeLevel);
		}

		public RoomItemUpgradeDefinition GetNextUpgrade(int upgradeLevel)
		{
			return _roomItemDefinitionBase.GetNextUpgrade(upgradeLevel);
		}

		public GameObject GetPrefab(int upgradeLevel = 0)
		{
			GameObject runtimePrefab = _ugcRuntimePrefabManager.GetRuntimePrefab(new UGCRuntimePrefabKey(ContentID, upgradeLevel));
			if (runtimePrefab != null)
			{
				return runtimePrefab;
			}
			return _roomItemDefinitionBase.GetPrefab(upgradeLevel);
		}

		public float GetPrestige(int upgradeLevel = 0)
		{
			return _roomItemDefinitionBase.GetPrestige(upgradeLevel);
		}

		public SharedInstance<AmbulanceConfig> GetAmbulanceConfig(int upgradeLevel = 0)
		{
			return null;
		}

		public List<StaffRequired> GetRequiredStaff(bool includeRoomModifier)
		{
			return _roomItemDefinitionBase.GetRequiredStaff(includeRoomModifier);
		}

		public string GetSanitizedName()
		{
			return _roomItemDefinitionBase.GetSanitizedName();
		}

		public Sprite GetUnlockIcon()
		{
			return _roomItemDefinitionBase.GetUnlockIcon();
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.RoomItems;
		}

		public LocalisedString GetUnlockMessage()
		{
			return _roomItemDefinitionBase.GetUnlockMessage();
		}

		public LocalisedString GetUnlockName()
		{
			return _roomItemDefinitionBase.GetUnlockName();
		}

		public RoomItemUpgradeDefinition GetUpgrade(int upgradeLevel)
		{
			return _roomItemDefinitionBase.GetUpgrade(upgradeLevel);
		}

		public GameObject GetUpgradeAddOnBlueprintPrefab(int upgradeLevel = 0)
		{
			return _roomItemDefinitionBase.GetUpgradeAddOnBlueprintPrefab(upgradeLevel);
		}

		public GameObject GetUpgradeAddOnPrefab(int upgradeLevel = 0)
		{
			return _roomItemDefinitionBase.GetUpgradeAddOnPrefab(upgradeLevel);
		}

		public void IterateModifiers<T>(Action<T> callback) where T : RoomModifier
		{
			_roomItemDefinitionBase.IterateModifiers(callback);
		}

		public int SilverCost()
		{
			if (_ugcRoomItemDefinitionDatabase.TryGetSilverCost(_contentID, out var silverCost))
			{
				return silverCost;
			}
			return _roomItemDefinitionBase.SilverCost();
		}

		public string ToLocalisedString()
		{
			return _roomItemDefinitionBase.ToLocalisedString();
		}

		public bool ValidQueuePositionForNeed(int queuePosition)
		{
			return _roomItemDefinitionBase.ValidQueuePositionForNeed(queuePosition);
		}

		public void OverrideIsSelectable(bool newSelectableState)
		{
		}

		public void OverrideCanBeSold(bool newSellableState)
		{
		}

		private GameItemBase GetExtContentGameItem()
		{
			if (_extContentGameItem == null)
			{
				_extContentGameItem = ExtContentUtils.ExtContentManager.FindGameItemByContentID(_contentID);
			}
			return _extContentGameItem;
		}

		private string GetExtContentName()
		{
			return ExtContentUtils.GetGameItemInGameName(GetExtContentGameItem());
		}
	}
}
