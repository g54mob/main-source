public class HerdBlindHint : BaseMessageHint
{
	public HerdBlindHint(string message, object data)
		: base(message, data)
	{
		base.Priority = 10;
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_HERD_BLD", true);
		return base.Completed();
	}
}
