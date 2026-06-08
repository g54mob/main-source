public class CommonHeader : AsciiObject
{
	public DialogButton prevButton;

	public DialogButton nextButton;

	public AsciiString title;

	public Separator separator;

	public override void UpdateTic()
	{
		if (prevButton.enabled)
		{
			prevButton.UpdateTic();
		}
		if (nextButton.enabled)
		{
			nextButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		title.Draw(r, offsetX, offsetY);
		separator.Draw(r, offsetX, offsetY);
		if (prevButton.enabled)
		{
			prevButton.Draw(r, offsetX, offsetY);
		}
		if (nextButton.enabled)
		{
			nextButton.Draw(r, offsetX, offsetY);
		}
	}
}
