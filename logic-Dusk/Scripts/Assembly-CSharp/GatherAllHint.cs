public class GatherAllHint : BaseMessageHint
{
	public GatherAllHint()
		: base("try 'gather all' to gather multiple scrap and/or\nfuel", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_GATALL", true);
		return base.Completed();
	}
}
