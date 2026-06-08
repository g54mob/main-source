public class NurseryCompletedHint : BaseMessageHint
{
	public NurseryCompletedHint()
		: base("All objects in this system have been explored.\nPress [2] or [SPACE] to view other systems.", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_NCOMPLETE", true);
		return base.Completed();
	}
}
