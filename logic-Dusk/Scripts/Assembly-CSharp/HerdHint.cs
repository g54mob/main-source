public class HerdHint : BaseMessageHint
{
	public HerdHint(string message, object data)
		: base(message, data)
	{
		base.Priority = 10;
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_HERD", true);
		return base.Completed();
	}
}
