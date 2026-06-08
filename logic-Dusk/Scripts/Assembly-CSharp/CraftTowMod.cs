public class CraftTowMod : IModification
{
	public string Description
	{
		get
		{
			return "Assemble a new tow upgrade";
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
			return "Assemble new Tow";
		}
	}

	public int ScrapCost
	{
		get
		{
			return -10;
		}
	}

	public string TargetName
	{
		get
		{
			return "New Tow";
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
