public class RerouteSUHint : BaseMessageHint
{
	public RerouteSUHint()
		: base("use 'reroute' to reroute a power around a ship\r\n'help reroute' for more info", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_SU_RRT", true);
		return base.Completed();
	}
}
