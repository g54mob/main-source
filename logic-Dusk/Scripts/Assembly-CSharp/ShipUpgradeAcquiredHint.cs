public class ShipUpgradeAcquiredHint : BaseMessageHint
{
	public ShipUpgradeAcquiredHint()
		: base("Use [S]hip Config menu to install new ship\r\nupgrade", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_SU", true);
		return base.Completed();
	}
}
