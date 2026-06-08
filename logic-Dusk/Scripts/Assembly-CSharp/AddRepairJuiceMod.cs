public class AddRepairJuiceMod : BaseResupplyMod
{
	public override int ScrapCost
	{
		get
		{
			return 5;
		}
	}

	protected override int ResourceIncreaseValue
	{
		get
		{
			return 1;
		}
	}

	public override string Description
	{
		get
		{
			return string.Empty;
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 1;
		}
	}

	public AddRepairJuiceMod()
	{
		_name = string.Format("Add {0} Repair Juice", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddRepairJuiceMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
