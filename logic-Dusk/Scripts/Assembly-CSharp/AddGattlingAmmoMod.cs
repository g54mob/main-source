public class AddGattlingAmmoMod : BaseResupplyMod
{
	protected override int ResourceIncreaseValue
	{
		get
		{
			return 50;
		}
	}

	public override string Description
	{
		get
		{
			return "adds turret ammo";
		}
	}

	public override int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public AddGattlingAmmoMod()
	{
		_name = string.Format("Add {0} Bullets", ResourceIncreaseValue);
	}

	public override IModification CopyModification()
	{
		IModification modification = new AddGattlingAmmoMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
