public class MotionHint : BaseMessageHint
{
	public MotionHint()
		: base("use 'motion' in schematic view to ensure unexplored\r\nrooms are safe", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_MOTION", true);
		return base.Completed();
	}
}
