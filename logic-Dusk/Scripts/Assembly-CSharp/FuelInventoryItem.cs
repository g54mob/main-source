public class FuelInventoryItem : IInventoryItem
{
	private string guiName = string.Empty;

	private string guiSuffix = string.Empty;

	private string _guiValue = string.Empty;

	public int Id { get; private set; }

	public string GroupKey
	{
		get
		{
			return string.Format("{0}_{1}", "INVITMF", Id);
		}
	}

	public InventoryTypeEnum InventoryType
	{
		get
		{
			return InventoryTypeEnum.Fuel;
		}
	}

	public string Name
	{
		get
		{
			return "Fuel";
		}
	}

	public string Suffix
	{
		get
		{
			return string.Empty;
		}
	}

	public string Description
	{
		get
		{
			return string.Empty;
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
			return "Ship";
		}
	}

	public virtual float Weight
	{
		get
		{
			return 0f;
		}
	}

	public virtual float SellValue
	{
		get
		{
			return 1f;
		}
	}

	public bool IsBroken
	{
		get
		{
			return false;
		}
	}

	public bool AgesDuringTravel
	{
		get
		{
			return true;
		}
	}

	public ModificationStorageIdEnum AppliedModifications { get; set; }

	public bool AddDaysTraveled(int additionalDays)
	{
		return true;
	}
}
