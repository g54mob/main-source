public class CraftFuelMod : IModification
{
	public string Description
	{
		get
		{
			return "Assemble Fuel";
		}
	}

	public int MaxAllowed
	{
		get
		{
			return 5;
		}
	}

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.None;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Assemble Fuel";
		}
	}

	public int ScrapCost
	{
		get
		{
			return -15;
		}
	}

	public string TargetName
	{
		get
		{
			return "Fuel";
		}
	}

	public void SetTarget(object itemToReceiveMod)
	{
	}

	public bool CanApplyModToTarget()
	{
		return true;
	}

	public void ApplyModToTarget()
	{
	}

	public IModification CopyModification()
	{
		return this;
	}
}
