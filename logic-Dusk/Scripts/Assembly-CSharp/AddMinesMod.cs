public class AddMinesMod : BaseResupplyMod
{
	protected override int ResourceIncreaseValue
	{
		get
		{
			return 2;
		}
	}

	public override string Description
	{
		get
		{
			return "adds proximety mines";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddMinesMod()
	{
		_name = string.Format("Add {0} Proximity Mines", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddMinesMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
