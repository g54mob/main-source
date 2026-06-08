public class AddProbesMod : BaseResupplyMod
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
			return "adds probes";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddProbesMod()
	{
		_name = string.Format("Add {0} Probes", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddProbesMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
