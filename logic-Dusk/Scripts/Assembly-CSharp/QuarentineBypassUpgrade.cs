public class QuarentineBypassUpgrade : BaseShipUpgrade
{
	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.Quarantine;
		}
	}

	public override bool IsPermanentUpgrade
	{
		get
		{
			return false;
		}
	}

	public override string Name
	{
		get
		{
			return "Quarantine Bypass";
		}
	}

	public override string Description
	{
		get
		{
			return "Allows boarding of quarantined ships, stations, and outposts";
		}
	}

	public override string CommandValue
	{
		get
		{
			return string.Empty;
		}
	}

	public QuarentineBypassUpgrade(int id)
		: base(id)
	{
	}
}
