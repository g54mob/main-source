public class TransportOutpostHint : BaseMessageHint
{
	public TransportOutpostHint()
		: base("Docking to an Outpost would damage your ship.\r\nUse your transporter, instead! ex: transport 1 r2", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_TRANSPOST", true);
		return base.Completed();
	}
}
