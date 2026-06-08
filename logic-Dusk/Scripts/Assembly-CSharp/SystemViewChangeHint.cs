public class SystemViewChangeHint : BaseMessageHint
{
	public SystemViewChangeHint()
		: base("Use [space] or [3] key to inspect a system", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_VIEWS", true);
		return base.Completed();
	}
}
