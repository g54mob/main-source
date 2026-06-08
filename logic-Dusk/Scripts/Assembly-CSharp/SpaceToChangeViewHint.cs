public class SpaceToChangeViewHint : BaseMessageHint
{
	public SpaceToChangeViewHint()
		: base("Use <space> key to toggle between drone and schematic\r\nview", null)
	{
	}

	public override IHintState Completed()
	{
		MarkCompleted();
		return base.Completed();
	}

	public static void MarkCompleted()
	{
		GameSaveFile.Save("WS_FIRSTDUN_TUT", true);
	}
}
