public class LongRangeScannerUpgrade : BaseShipUpgrade
{
	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.LongRangeScanner;
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
			return "Long Range Scanner";
		}
	}

	public override string Description
	{
		get
		{
			return "Allows for further scanning of systems in the Galaxy Map";
		}
	}

	public override string CommandValue
	{
		get
		{
			return string.Empty;
		}
	}

	public LongRangeScannerUpgrade(int id)
		: base(id)
	{
	}
}
