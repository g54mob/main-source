public class ShipWearingDownHint : BaseMessageHint
{
	public ShipWearingDownHint()
		: base("Your current ship is taking wear. Consider\ntrying to 'commandeer' another vessel before it\ndeteriorates", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_SHPWR", true);
		return base.Completed();
	}
}
