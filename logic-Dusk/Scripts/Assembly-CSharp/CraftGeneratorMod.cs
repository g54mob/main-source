public class CraftGeneratorMod : IModification
{
	public string Description
	{
		get
		{
			return "Assemble a new generator upgrade";
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
			return "Assemble new Generator";
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
			return "New Generator";
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
