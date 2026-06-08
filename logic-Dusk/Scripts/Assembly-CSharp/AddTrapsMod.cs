public class AddTrapsMod : BaseResupplyMod
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
			return "adds trap mines";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddTrapsMod()
	{
		_name = string.Format("Add {0} Trap Mines", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddTrapsMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
