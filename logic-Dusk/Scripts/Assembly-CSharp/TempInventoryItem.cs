public class TempInventoryItem : IInventoryItem
{
	private string guiName = string.Empty;

	private string guiSuffix = string.Empty;

	private string _guiValue = string.Empty;

	private string _guiInventoryType = string.Empty;

	public IInventoryItem OriginalItem { get; private set; }

	public InventoryTypeEnum InventoryType { get; private set; }

	public string GroupKey { get; private set; }

	public string Name
	{
		get
		{
			return OriginalItem.Name + " " + OriginalItem.Suffix;
		}
	}

	public string Suffix { get; private set; }

	public string Description { get; private set; }

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

	public float Weight { get; private set; }

	public float SellValue { get; private set; }

	public bool IsBroken { get; private set; }

	public bool AgesDuringTravel { get; private set; }

	public ModificationStorageIdEnum AppliedModifications
	{
		get
		{
			return OriginalItem.AppliedModifications;
		}
	}

	public TempInventoryItem(IInventoryItem item, string overrideSuffix)
	{
		InventoryType = item.InventoryType;
		GroupKey = item.GroupKey;
		Suffix = overrideSuffix;
		Weight = item.Weight;
		SellValue = item.SellValue;
		IsBroken = item.IsBroken;
		OriginalItem = item;
	}

	public bool AddDaysTraveled(int additionalDays)
	{
		return false;
	}
}
