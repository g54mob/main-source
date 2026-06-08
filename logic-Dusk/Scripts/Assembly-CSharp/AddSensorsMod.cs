public class AddSensorsMod : BaseResupplyMod
{
	protected override int ResourceIncreaseValue
	{
		get
		{
			return 25;
		}
	}

	public override string Description
	{
		get
		{
			return "adds sensors";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddSensorsMod()
	{
		_name = string.Format("Add {0} Sensors", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddSensorsMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
