public class AddMotionSensorsMod : BaseResupplyMod
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
			return "adds motion sensors";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddMotionSensorsMod()
	{
		_name = string.Format("Add {0} Motion Sensors", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddMotionSensorsMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
