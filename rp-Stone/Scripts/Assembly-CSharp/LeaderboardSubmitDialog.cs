public class LeaderboardSubmitDialog : TwoChoiceDialog
{
	public AsciiString title;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			title.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}
}
