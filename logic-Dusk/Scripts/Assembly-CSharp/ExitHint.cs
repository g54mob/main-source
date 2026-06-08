public class ExitHint : BaseMessageHint
{
	public ExitHint()
		: base("use 'exit' to return to mothership", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_EXIT", true);
		return base.Completed();
	}
}
