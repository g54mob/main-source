public class AddStunMinesMod : BaseResupplyMod
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
			return "adds stun mines";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddStunMinesMod()
	{
		_name = string.Format("Add {0} Stun Mines", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddStunMinesMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
