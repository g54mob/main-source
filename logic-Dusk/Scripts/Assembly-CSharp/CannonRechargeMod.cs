using UnityEngine;

public class CannonRechargeMod : IModification
{
	private CannonPermUpgrade targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.CannonRecharge;
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
			return "one-time recharge of cannon";
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
		targetUpgrade = itemToReceiveMod as CannonPermUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (targetUpgrade == null)
		{
			Debug.LogError("target sonic upgrade is null!!!");
			return false;
		}
		if (targetUpgrade.IsBroken || (targetUpgrade.AppliedModifications & ModificationStorageIdEnum.CannonRecharge) == ModificationStorageIdEnum.CannonRecharge || targetUpgrade.Quantity >= targetUpgrade.Capacity)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (targetUpgrade == null)
		{
			Debug.LogError("target sonic upgrade is null!!!");
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
		IModification modification = new CannonRechargeMod();
		modification.SetTarget(targetUpgrade);
		return modification;
	}
}
