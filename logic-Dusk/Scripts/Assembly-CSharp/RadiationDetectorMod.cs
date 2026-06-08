using UnityEngine;

public class RadiationDetectorMod : IModification
{
	private ShipSurveyor targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.SUSurveyorRadiation;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Detect rooms with weak hulls";
		}
	}

	public string Description
	{
		get
		{
			return "Adds an overlay to the schematic of rooms most likely to be filled with radiation";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)targetUpgrade).Name;
		}
	}

	public int ScrapCost
	{
		get
		{
			return -5;
		}
	}

	public int MaxAllowed
	{
		get
		{
			return 1;
		}
	}

	public void SetTarget(object itemToReceiveMod)
	{
		targetUpgrade = itemToReceiveMod as ShipSurveyor;
	}

	public bool CanApplyModToTarget()
	{
		if (targetUpgrade == null)
		{
			Debug.LogError("target Surveyor upgrade is null!!!");
			return false;
		}
		if (targetUpgrade.IsBroken || targetUpgrade.HasRadiationDetectorMod)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (targetUpgrade == null)
		{
			Debug.LogError("target surveyor upgrade is null!!!");
			return;
		}
		targetUpgrade.AppliedModifications |= ModificationStorageId;
		string parentKey = UniverseSaveFile.Get(targetUpgrade.GroupKey, "P", string.Empty);
		string parentKey2;
		int shipUpgradeSlot = GalaxyMapManager.GetShipUpgradeSlot(targetUpgrade, out parentKey2);
		targetUpgrade.SaveData(parentKey, shipUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new RadiationDetectorMod();
		modification.SetTarget(targetUpgrade);
		return modification;
	}
}
