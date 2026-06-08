public class CraftGathererMod : IModification
{
	public string Description
	{
		get
		{
			return "Assemble a new gather upgrade";
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
			return "Assemble new Gather";
		}
	}

	public int ScrapCost
	{
		get
		{
			return -8;
		}
	}

	public string TargetName
	{
		get
		{
			return "New Gather";
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
