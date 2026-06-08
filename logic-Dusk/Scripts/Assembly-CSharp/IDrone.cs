using System.Collections.Generic;
using UnityEngine;

public interface IDrone : IHasHitpoints, IOverrideHitpoints, IToggleVisibilityInSchematic, IHasVideoThatCanFail
{
	DroneViewProcessor DVP { get; set; }

	int InternalID { get; set; }

	int DroneNumber { get; set; }

	int DVPSeed { get; set; }

	int CSID { get; set; }

	string DroneName { get; set; }

	string DVPName { get; set; }

	string guiDroneNote { get; }

	string guiDroneStatus { get; }

	int DroneVisualIndex { get; set; }

	float OriginalSpeed { get; set; }

	bool IsVisible { get; set; }

	DungeonInfo DungeonLeftIn { get; set; }

	Vector3 LastPosition { get; set; }

	Quaternion LastRotation { get; set; }

	int DaysTraveledWhileDead { get; set; }

	List<BaseDroneUpgrade> Upgrades { get; set; }

	int NumberOfUpgradeSlots { get; set; }

	bool InterfaceDisconnected { get; set; }

	bool CanBeFullyRepaired { get; set; }

	bool IsUnderPlayerControl { get; }

	float TimeInMission { get; set; }

	float TraitVeer { get; set; }

	float TraitPermVeer { get; set; }

	float TraitPitchOffset { get; set; }

	EngineTypeEnum engineType { get; set; }

	ModificationStorageIdEnum AppliedModifications { get; set; }

	bool AddDroneUpgrade(BaseDroneUpgrade upgrade);

	bool AddDroneUpgrade(int slotNumber, BaseDroneUpgrade upgrade);

	void RemoveDroneUpgrade(BaseDroneUpgrade upgrade);

	void RemoveDroneUpgrade(int slotNumber);

	int NumberOfUpgradesInstalled();

	void RemoveAllUpgrades();

	bool HasUpgrade(DroneUpgradeType upgradeType);
}
