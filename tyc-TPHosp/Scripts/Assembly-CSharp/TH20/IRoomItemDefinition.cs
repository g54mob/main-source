using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public interface IRoomItemDefinition : IPriceModifier, IEntityDefinition, ISilverUnlockable
	{
		RoomItemDefinition.Type ItemType { get; }

		string DebugTag { get; set; }

		bool InitiallyAvailable { get; }

		bool SaveInRoomLayout { get; }

		float HospitalLevelPoints { get; }

		RoomItemDefinition.Size ItemSize { get; }

		bool PlayPlacmentSFX { get; }

		bool PlaceOnWall { get; }

		bool OccupyWallOnly { get; }

		bool AllowOnCorner { get; }

		float GridSnap { get; }

		float RotationSnap { get; }

		float DefaultRotation { get; }

		bool WallMagnetism { get; }

		float WallMagnetismRotation { get; }

		float WallMagnetismDistance { get; }

		bool SinglePlace { get; }

		bool HasCollision { get; }

		bool UseVerticalCollision { get; }

		bool CollideWithSameType { get; }

		bool CollideWithRugs { get; }

		RoomItemDefinition.CollisionType ItemCollisionType { get; }

		bool MoveOutOfWay { get; }

		bool IgnoreValidation { get; }

		bool IsSelectable { get; }

		bool HasTooltip { get; }

		bool ShowQueuePositions { get; }

		bool ShowStatusIcon { get; }

		bool AffectsNavigation { get; }

		bool RemoveWalls { get; }

		bool DisableParticlesOnEdit { get; }

		RoomDefinition.Type[] CanBePlacedInRoomTypes { get; }

		RoomDefinition.Type[] CantBePlacedInRoomTypes { get; }

		ObjectAttributes.Definition[] Attributes { get; }

		float MaintenanceModifer { get; }

		float MaintenanceFunctionalLevel { get; }

		Sprite MaintenanceIconOverride { get; }

		float JanitorPriority { get; }

		float JanitorRepairRate { get; }

		bool IgnoredByJanitors { get; }

		bool GeneratesElectricity { get; }

		float EcoRatingModifier { get; }

		JobMaintenance.JobDescription MaintenanceDescription { get; }

		JobService.JobDescription ServiceDescription { get; }

		RoomModifier[] RoomModifiers { get; }

		InteractionAttributeModifier[] InteractionAttributeModifiers { get; }

		DataViewManager.Mode DataViewMode { get; }

		GameObject HoverMenuPrefab { get; }

		GameObject SelectMenuPrefab { get; }

		SharedInstance<DLCItemDefinition> DlcPackRequired { get; }

		int PrimeEntitlementRequired { get; }

		SharedInstance<RoomItemUpgradeDefinition>[] Upgrades { get; }

		bool SingleInteractor { get; }

		bool InteractionsAlwayAnimate { get; }

		int MinValidInteractions { get; }

		InteractionDefinition[] Interactions { get; set; }

		RoomItemFilter[] Filters { get; }

		GameObject PlacementEffect { get; }

		SharedInstance<ItemSpawnLimits.Category> SpawnLimitCategory { get; }

		int MinimumQueuePositionAllowedToSatisyNeed { get; }

		Guid GUID { get; }

		bool CanBePickedUp { get; }

		bool CanDragHoldSelect { get; }

		bool MustBeWhiteListed { get; }

		SharedInstance<AmbulanceConfig> BaseAmbulanceConfig { get; }

		bool IsAnAmbulance { get; }

		RoomItemDefinition.FixedWallPlacementOption FixedWallPlacement { get; }

		new string ToString();

		string ToLocalisedString();

		float GetAttributeModifer(ObjectAttributes.Type type);

		bool CanBePlacedIn(RoomDefinition.Type roomType);

		bool AllowCollisionOutsideRoom();

		void IterateModifiers<T>(Action<T> callback) where T : RoomModifier;

		bool CanBeSold();

		bool CanBeSoldWhenBuiltOver();

		string GetSanitizedName();

		bool AllowFreePlacement();

		[CanBeNull]
		RoomItemUpgradeDefinition GetUpgrade(int upgradeLevel);

		[CanBeNull]
		RoomItemUpgradeDefinition GetNextUpgrade(int upgradeLevel);

		string GetName(int upgradeLevel = 0);

		string GetLocalisedName(int upgradeLevel = 0);

		string GetLocalisedNamePlural(int count, int upgradeLevel = 0);

		int GetCost(int upgradeLevel = 0);

		int EnergyCost(int upgradeLevel = 0);

		float GetPrestige(int upgradeLevel = 0);

		string GetDescription(int upgradeLevel = 0);

		string GetFunctionalDescription();

		Sprite GetIcon(int upgradeLevel = 0);

		Sprite GetJobAssignmentIcon();

		GameObject GetPrefab(int upgradeLevel = 0);

		GameObject GetBlueprintPrefab(int upgradeLevel = 0);

		GameObject GetUpgradeAddOnPrefab(int upgradeLevel = 0);

		GameObject GetUpgradeAddOnBlueprintPrefab(int upgradeLevel = 0);

		SharedInstance<AmbulanceConfig> GetAmbulanceConfig(int upgradeLevel = 0);

		List<StaffRequired> GetRequiredStaff(bool includeRoomModifier);

		Vector3 GetEditLiftOffset(RoomItem item);

		bool ValidQueuePositionForNeed(int queuePosition);
	}
}
