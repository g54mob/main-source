using UnityEngine;

public class ExpandedInventoryItem : IInventoryItem
{
	private string _suffix;

	private string guiName = string.Empty;

	private string guiSuffix = string.Empty;

	private string _guiValue = string.Empty;

	private string _guiInventoryType = string.Empty;

	public IInventoryItem RealItem { get; private set; }

	public string GroupKey
	{
		get
		{
			return RealItem.GroupKey;
		}
	}

	public InventoryTypeEnum InventoryType
	{
		get
		{
			return RealItem.InventoryType;
		}
	}

	public string Name
	{
		get
		{
			return RealItem.Name;
		}
	}

	public string Suffix
	{
		get
		{
			return RealItem.Suffix + _suffix;
		}
	}

	public string Description
	{
		get
		{
			return RealItem.Description;
		}
	}

	public string guiValue
	{
		get
		{
			if (guiName != Name || guiSuffix != Suffix)
			{
				_guiValue = string.Format("{0}{1}", Name, Suffix);
				guiName = Name;
				guiSuffix = Suffix;
			}
			return _guiValue;
		}
	}

	public string guiInventoryType
	{
		get
		{
			if (string.IsNullOrEmpty(_guiInventoryType))
			{
				_guiInventoryType = ((InventoryType != InventoryTypeEnum.DroneUpgrade) ? "Ship" : "Drone") + " Upgrade";
			}
			return _guiInventoryType;
		}
	}

	public float Weight
	{
		get
		{
			return RealItem.Weight;
		}
	}

	public float SellValue
	{
		get
		{
			return RealItem.SellValue;
		}
	}

	public bool IsBroken
	{
		get
		{
			return RealItem.IsBroken;
		}
	}

	public bool AgesDuringTravel
	{
		get
		{
			return RealItem.AgesDuringTravel;
		}
	}

	public ModificationStorageIdEnum AppliedModifications
	{
		get
		{
			return RealItem.AppliedModifications;
		}
	}

	public ExpandedInventoryItem(IInventoryItem item, string suffix)
	{
		RealItem = item;
		_suffix = suffix;
	}

	public bool AddDaysTraveled(int additionalDays)
	{
		Debug.LogWarning("Did we really mean to age this item?? - " + Name);
		return true;
	}
}
