public class AddLuresMod : BaseResupplyMod
{
	protected override int ResourceIncreaseValue
	{
		get
		{
			return 3;
		}
	}

	public override string Description
	{
		get
		{
			return "adds lures";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddLuresMod()
	{
		_name = string.Format("Add {0} Lures", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddLuresMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
