using UnityEngine;

public class DecontaminateRechargeMod : IModification
{
	private DecontaminatePermUpgrade targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.DecontaminateRecharge;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Recharge to full";
		}
	}

	public string Description
	{
		get
		{
			return "one-time recharge of decontaminator";
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
			return -4;
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
		targetUpgrade = itemToReceiveMod as DecontaminatePermUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (targetUpgrade == null)
		{
			Debug.LogError("target sonic upgrade is null!!!");
			return false;
		}
		if (targetUpgrade.IsBroken || (targetUpgrade.AppliedModifications & ModificationStorageIdEnum.DecontaminateRecharge) == ModificationStorageIdEnum.DecontaminateRecharge || targetUpgrade.Quantity >= targetUpgrade.Capacity)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (targetUpgrade == null)
		{
			Debug.LogError("target decontaminate upgrade is null!!!");
			return;
		}
		targetUpgrade.OverrideQuantity(targetUpgrade.Capacity);
		string parentKey = UniverseSaveFile.Get(targetUpgrade.GroupKey, "P", string.Empty);
		string parentKey2;
		int shipUpgradeSlot = GalaxyMapManager.GetShipUpgradeSlot(targetUpgrade, out parentKey2);
		targetUpgrade.SaveData(parentKey, shipUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new DecontaminateRechargeMod();
		modification.SetTarget(targetUpgrade);
		return modification;
	}
}
