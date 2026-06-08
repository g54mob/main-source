public class CloseAirlockHint : BaseMessageHint
{
	public CloseAirlockHint(string roomLabel)
		: base(string.Format("Close airlock leading to room {0} to keep radiation\r\nout of derelict!", roomLabel), null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_ALOCK_CLOSE", true);
		return base.Completed();
	}
}
